/*-----------------------------------------------------------------------------
TraceReader.cs

Класс отвечающий за чтение трассировки из файла лога.
Отслеживается время и прогресс выполнения теста, а также его результат
-----------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;


namespace AccelVibroTestClient
{
    class RTTclient
    {
        private static TestExecutionStates _state;    // текущее состояние теста
        private static int _dataCounter;              // счетчик точек

        private static Process _rttViwerProcess;

        private static FileStream _fileWriter;

        //TCP
        private static TcpClient tcpClient;
        private static NetworkStream stream;
        private static Thread _TCPDataReaderhread;

        // Возможные запросы в датчик
        public static String СONNECT = "CONNECT";
        public static String START = "START";

        // Возможные ответы датчика
        public static String FAILED_CONNECTION = "FAILED_CONNECTION";
        public static String CONNECTION_DONE = "CONNECTION_DONE";

        public static String ERROR_PARAMETERS = "ERROR_PARAMETER";
        public static String PARAMETERS_ACCEPTED = "PARAMETERS_ACCEPTED";

        public static String MEASURE_STARTED = "MEASURE_STARTED";
        public static String MEASURE_DONE = "MEASURE_DONE";
        public static String MEASURE_FAIL = "MEASURE_FAIL";

        // Имена временных файлов,необходимых для работы
        public const string LOG_FILE_NAME = "tempLogFile.txt";

        public static TestExecutionParameters param;

        public static int StartClient()
        {
            // Запуск процесса rttViwer
            _rttViwerProcess = new Process();
            StartRttViwerProcess();

            int res = StartTcpTelnetConnection();
            if (SystemParameters.FAILED(res))
            {
                MainForm.ShowMessageError("Failed establish Tcp Telnet Connection");
                CloseClient();
                return res;
            }
            return res;
        }

        public static int DoMeasure(TestExecutionParameters p)
        {
            param = p;

            _fileWriter?.Close();

            string filter = param.filterState.ToString();
            string odr = "BW" + param.Bandwidth.ToString();

            MainForm.ShowMessage("\r"+ param.Axis.ToString() + "  "+ param.scale.ToString() + "g" + "  " +
                filter + "  " + odr);

            // Перезапуск прошивки
            FlashProgrammer.RestartProgramm();
            
            Thread.Sleep(2000);

            // Ожидаем условий старта
            int res = WaitStartConditions();
            if (SystemParameters.FAILED(res))
            {
                MainForm.ShowMessageError("Failed Wait Start Conditions");
                CloseClient();
                return res;
            }

            //Записываем параметры измерения
            res = WriteMeasureParams();
            if (SystemParameters.FAILED(res))
            {
                MainForm.ShowMessageError("Failed Write Measure Params");
                CloseClient();
                return res;
            }

            // Проводим измерение
            res = DoAccelMeasure();
            if (SystemParameters.FAILED(res))
            {
                MainForm.ShowMessageError("Failed accel Measure");
                CloseClient();
                return res;
            }

            return res;
        }

        private static int WaitStartConditions()
        {
            _state = TestExecutionStates.wait;
            TCPDataWriter(СONNECT);

            while ((_state != TestExecutionStates.connected) && (_state != TestExecutionStates.error))
                ;

            return (_state == TestExecutionStates.connected) ? SystemParameters.RETURN_CODE_SUCCESS : SystemParameters.RETURN_CODE_FAIL;
        }

        private static int WriteMeasureParams()
        {
            if (_state != TestExecutionStates.connected)
                return SystemParameters.RETURN_CODE_FAIL;

            int res = WriteParam(param.scale.ToString());
            if (SystemParameters.FAILED(res))
                return SystemParameters.RETURN_CODE_FAIL;

            res = WriteParam(param.MeasureCount.ToString());
            if (SystemParameters.FAILED(res))
                return SystemParameters.RETURN_CODE_FAIL;

            res = WriteParam(Convert.ToInt16(param.filterState).ToString());
            if (SystemParameters.FAILED(res))
                return SystemParameters.RETURN_CODE_FAIL;

            res = WriteParam(param.Bandwidth.ToString());
            if (SystemParameters.FAILED(res))
                return SystemParameters.RETURN_CODE_FAIL;

            res = WriteParam(Convert.ToInt16(param.Axis).ToString());
            if (SystemParameters.FAILED(res))
                return SystemParameters.RETURN_CODE_FAIL;

            return SystemParameters.RETURN_CODE_SUCCESS;
        }

        private static int WriteParam(String param)
        {
            _state = TestExecutionStates.connected;

            TCPDataWriter(param);

            while ((_state != TestExecutionStates.paramsAccepted) && (_state != TestExecutionStates.error))
                ;

            return (_state == TestExecutionStates.paramsAccepted) ? SystemParameters.RETURN_CODE_SUCCESS : SystemParameters.RETURN_CODE_FAIL;
        }

        private static int DoAccelMeasure()
        {
            if (_state != TestExecutionStates.paramsAccepted)
                return SystemParameters.RETURN_CODE_FAIL;

            _fileWriter = new FileStream(LOG_FILE_NAME, FileMode.Create);
            
            _dataCounter = 0;
            TCPDataWriter(START);

            while ((_state != TestExecutionStates.measureStarted) && (_state != TestExecutionStates.error))
                ;

            while ((_state != TestExecutionStates.measureCompleted) && (_state != TestExecutionStates.error))
                ;

            _fileWriter.Close();
            _fileWriter = null;
            MeasureProcessing();

            if (_state == TestExecutionStates.measureCompleted)
            {
                MainForm.ShowMessage("data Count =  " + _dataCounter.ToString());
                return SystemParameters.RETURN_CODE_SUCCESS;
            }
            else
                return SystemParameters.RETURN_CODE_FAIL;
        }

        private static void MeasureProcessing()
        {
            FileStream reader = new FileStream(LOG_FILE_NAME, FileMode.Open);
            byte[] array = new byte[2];
            string fileName = GetLogFile();
            StreamWriter writer = new StreamWriter(fileName);
            while (reader.Position != reader.Length)
            {
                reader.Read(array, 0, 2);
                Int16 c = (Int16)(array[1] * 256 + array[0]);

                writer.WriteLine(c.ToString());
                _dataCounter++;
            }

            reader.Close();
            writer.Close();

            SignalProcessing.GetSKO(fileName, param.scale);
        }

        // Запуск и настройка процесса Rtt Viver
        private static void StartRttViwerProcess()
        {
            String args = @"-device nRF52832_xxAA -if swd -speed 50000 -autoconnect 1";

            _rttViwerProcess.StartInfo.FileName = SystemParameters.RTT_JLINK;
            _rttViwerProcess.StartInfo.Arguments = args;
            _rttViwerProcess.StartInfo.CreateNoWindow = false;
            _rttViwerProcess.StartInfo.UseShellExecute = false;
            _rttViwerProcess.Start();
        }

        private static void TCPDataWriter(String outStr)
        {
            Byte[] encodedBytes = Encoding.ASCII.GetBytes(outStr+"\r");
            if (stream.CanWrite)
                stream.Write(encodedBytes, 0, encodedBytes.Length);
        }

        private static void TCPDataReader()
        {
            byte[] data = new byte[10000];


            while (true)
            {
                int bytes = stream.Read(data, 0, data.Length);

                String outLine = Encoding.UTF8.GetString(data, 0, bytes);

                bool showData = true;
                switch (_state)
                {
                    case TestExecutionStates.wait:
                        if (outLine.Contains(FAILED_CONNECTION))
                            _state = TestExecutionStates.error;
                        else if (outLine.Contains(CONNECTION_DONE))
                            _state = TestExecutionStates.connected;
                        break;

                    case TestExecutionStates.connected:
                        if (outLine.Contains(ERROR_PARAMETERS))
                            _state = TestExecutionStates.error;
                        else if (outLine.Contains(PARAMETERS_ACCEPTED))
                            _state = TestExecutionStates.paramsAccepted;
                        break;

                    case TestExecutionStates.paramsAccepted:
                        if (outLine.Contains(MEASURE_STARTED))
                            _state = TestExecutionStates.measureStarted;
                        break;

                    case TestExecutionStates.measureStarted:
                        showData = false;

                        if (outLine.Contains(MEASURE_FAIL))
                        {
                            _fileWriter.Write(data, 0, bytes - MEASURE_FAIL.Length-1);
                            _state = TestExecutionStates.error;
                            MainForm.ShowMessage(MEASURE_FAIL);
                        }
                        else if (outLine.Contains(MEASURE_DONE))
                        {
                            _fileWriter.Write(data, 0, bytes - MEASURE_DONE.Length-1);
                            _state = TestExecutionStates.measureCompleted;
                            MainForm.ShowMessage(MEASURE_DONE);
                        }
                        else
                        {
                            if (_fileWriter.CanWrite)
                                _fileWriter.Write(data, 0, bytes);
                        }
                        break;
                }
            if (showData)
                MainForm.ShowMessage(outLine);
            }
        }
        private static int StartTcpTelnetConnection()
        {
            try
            {
                IPAddress adress = IPAddress.Parse("127.0.0.1");
                IPEndPoint host = new IPEndPoint(adress, 19021);
                tcpClient = new TcpClient();
                tcpClient.Connect(host);

                stream = tcpClient.GetStream();

                _TCPDataReaderhread = new Thread(new ThreadStart(TCPDataReader));
                _TCPDataReaderhread.Start();
            }
            catch
            {
                return SystemParameters.RETURN_CODE_FAIL;
            }

            return SystemParameters.RETURN_CODE_SUCCESS;
        }

        public static void CloseClient()
        {
            try
            {
                if (_TCPDataReaderhread != null)
                    _TCPDataReaderhread.Abort();

                stream?.Close();
                tcpClient?.Close();
                _fileWriter?.Close();

                _rttViwerProcess.Kill();
                _rttViwerProcess.WaitForExit(1000);

            }
            catch
            {
                MainForm.ShowMessage("Failed Stop Rtt Process");
            }
        }

        private static String GetLogFile()
        {
            String dir = @"Logs\" + param.Axis.ToString();
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        

            string date = DateTime.Now.Hour.ToString() + '_' +
                DateTime.Now.Minute.ToString() + '_' +
                DateTime.Now.Second.ToString();

            string filter = param.filterState.ToString();
            string odr = "BW" + param.Bandwidth.ToString();

            return dir + @"\" + 
                param.scale.ToString() +"g" + '_' +
                filter + '_' +
                odr + '_' +
                date + 
                ".log";
        }
    }
}
