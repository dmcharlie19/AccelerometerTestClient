/*-----------------------------------------------------------------------------
FlashProgrammer.cs

Класс для загрузки прошивки в память МК.
Используется стороння программа nrfjprog.
-----------------------------------------------------------------------------*/
using System.Diagnostics;
using System.Text;

namespace AccelVibroTestClient
{
    class FlashProgrammer
    {
        public static int ProgrammFlash()
        {
            // 1. Очистка памяти
            int res = ExecuteNrfjprogProcess("--eraseall");
            if (res != 0)
                return SystemParameters.RETURN_CODE_FAIL;

            // 2. Загрузка прошивки в память
            string arg = "--program " + "IIS3DWBTest_Debug.hex";
            res = ExecuteNrfjprogProcess(arg);
            if (res != 0)
                return SystemParameters.RETURN_CODE_FAIL;

            // 3. Перезапуск
            res = ExecuteNrfjprogProcess("--reset");
            if (res != 0)
                return SystemParameters.RETURN_CODE_FAIL;

            return SystemParameters.RETURN_CODE_SUCCESS;
        }

        public static int RestartProgramm()
        {
            // Перезапуск
            int res = ExecuteNrfjprogProcess("--reset");
            if (res != 0)
                return SystemParameters.RETURN_CODE_FAIL;

            return SystemParameters.RETURN_CODE_SUCCESS;
        }

        // Обработчики выходного потока данных процесса
        private static void OutputDataStreamHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            MainForm.ShowMessage(outLine.Data);
        }
        private static void OutputErrorStreamHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            MainForm.ShowMessageError(outLine.Data);
        }

        private static int ExecuteNrfjprogProcess(string arg )
        {
            Process process = new Process();

            process.StartInfo.FileName = SystemParameters.NRFJPROG_PATH;
            process.StartInfo.Arguments = arg;

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);

            var output = new StringBuilder();
            process.OutputDataReceived += OutputDataStreamHandler;
            process.ErrorDataReceived += OutputErrorStreamHandler;

            // run the process
            process.Start();

            // start reading output to events
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit(20000);

            return process.ExitCode;
        }
    }
}
