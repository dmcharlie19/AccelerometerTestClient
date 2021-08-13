using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Linq;

namespace AccelVibroTestClient
{
    public partial class MainForm : Form
    {
        private static MainForm _instance = null;
        private Thread _testexecutionThread;

        Bitmap _failImage = new Bitmap(@"resurse/fail.jpg", true);
        Bitmap _okImage = new Bitmap(@"resurse/ok.jpg", true);

        private static TestExecutionParameters parameters = new TestExecutionParameters();
        public MainForm()
        {
            _instance = this;
            _testexecutionThread = null;
            InitializeComponent();

            stopTestButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxResult.Visible = false;

            //comboBox.SelectedIndex = 0;
            MeasureCount.SelectedIndex = 0;
        }


        void UpdateTestList()
        {

        }

        private void MainForm_Closing(object sender, EventArgs e)
        {
            if (_testexecutionThread != null)
                _testexecutionThread.Abort();

            RTTclient.CloseClient();
            _instance = null;
        }

        private void ExecuteTest()
        {
            // Чтение и анализ трассировки
            int res = RTTclient.DoMeasure(parameters);

            Invoke(new Action(() =>
            {
                if (SystemParameters.SUCCESSED(res))
                    pictureBoxResult.Image = _okImage;
                else
                    pictureBoxResult.Image = _failImage;

                pictureBoxResult.Visible = true;
            }));
        }


        private void startTestButton_Click(object sender, EventArgs e)
        {

            pictureBoxResult.Visible = false;
            LogTextBox.Clear();
            startTestButton.Enabled = false;
            stopTestButton.Enabled = true;

            // Запуск процессов
            int res = RTTclient.StartClient();

            if (SystemParameters.FAILED(res))
            {
                pictureBoxResult.Image = _failImage;
                pictureBoxResult.Visible = true;
                startTestButton.Enabled = true;
                stopTestButton.Enabled = false;
            }
        }

        private void stopTestButton_Click(object sender, EventArgs e)
        {
            if (_testexecutionThread != null)
                _testexecutionThread.Abort();

            _testexecutionThread = null;

            startTestButton.Enabled = true;
            stopTestButton.Enabled = false;

            RTTclient.CloseClient();
        }

        private void StartMeasure_Click(object sender, EventArgs e)
        {
            parameters.scale = Convert.ToUInt32(scale16g.Checked) << 4 |
                Convert.ToUInt32(scale8g.Checked) << 3 |
                Convert.ToUInt32(scale4g.Checked) << 2 |
                Convert.ToUInt32(scale2g.Checked) << 1;

            parameters.MeasureCount = Convert.ToUInt32(MeasureCount.SelectedItem) * 1000;
            parameters.filterState = ((disable.Checked) ? FilterState.FilterDisable : (HPF.Checked ? FilterState.HPF : FilterState.LPF));
            parameters.Bandwidth = Convert.ToUInt32(Bandwidth.SelectedItem);

            parameters.Axis = (AxisState)(Convert.ToUInt32(axisX.Checked) |
                                       Convert.ToUInt32(axisY.Checked) << 1 |
                                       Convert.ToUInt32(axisZ.Checked) * 3);


            if ((parameters.filterState != 0) && parameters.Bandwidth == 0)
            {
                MessageBox.Show("Выберите полосу пропускания");
                return;
            }

            pictureBoxResult.Visible = false;
            //LogTextBox.Clear();

            _testexecutionThread = new Thread(new ThreadStart(ExecuteTest));
            _testexecutionThread.Start();
        }

        /// <summary>Показать сообщение в окне журнала</summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="color">Цвет сообщения</param>
        private void ShowMessageImpl(string message, Color color)
        {
            Invoke(new Action(() =>
            {
                if (string.IsNullOrEmpty(message) || message.Length < 1)
                    return;

                LogTextBox.SelectionColor = color;
                if (message[message.Length - 1] == '\r')
                {
                    string[] lines = LogTextBox.Lines;
                    lines[lines.Length - 1] = message.Substring(0, message.Length - 1);
                    LogTextBox.Lines = lines;
                }
                else
                    LogTextBox.AppendText((string.IsNullOrEmpty(LogTextBox.Text) ? "" : Environment.NewLine) + message);

                LogTextBox.Focus();
                LogTextBox.SelectionStart = LogTextBox.Text.Length;
                if (color == Color.Red)
                {
                    pictureBoxResult.Visible = true;
                    pictureBoxResult.Image = _failImage;
                }
            }
            ));
        }

        public static void ShowMessageError(string message)
        {
            if (_instance != null)
                _instance.ShowMessageImpl(message, Color.Red);
        }
        public static void ShowMessage(string message)
        {
            if (_instance != null)
                _instance.ShowMessageImpl(message, Color.Black);
        }

        public static MainForm GetInstance()
        {
            return _instance;
        }

        public bool GetSigProcessing()
        {
            return sigProc.Checked;
        }

        private void Logs_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = "explorer";
            Proc.StartInfo.Arguments = @"logs";
            Proc.Start();
        }

        private void doFirmware_Click(object sender, EventArgs e)
        {
            int res = FlashProgrammer.ProgrammFlash();
            if (SystemParameters.FAILED(res))
                ShowMessage("Ошибка загрузки прошивки в память");
            else
                ShowMessage("прошивка загружена в память");
        }
    }
}
