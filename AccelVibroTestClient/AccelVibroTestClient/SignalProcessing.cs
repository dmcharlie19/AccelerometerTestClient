using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace AccelVibroTestClient
{
    class SignalProcessing
    {
        public static void GetSKO(String fileName, uint scale)
        {
            StreamReader reader = new StreamReader(fileName);

            const UInt16 discardedSampl = 0;
            UInt32 discSamplcount = 0;
            List<float> list = new List<float>();
            while (!reader.EndOfStream)
            {
                var s = Convert.ToInt16(reader.ReadLine());
                if (discSamplcount >= discardedSampl)
                    list.Add(ConvertToMG(scale, s));

                discSamplcount++;
            }
            reader.Close();

            Int64 sum = 0;
            Int64 sumPow2 = 0;
            foreach (Int16 v in list)
            {
                sum += v;
                sumPow2 += v * v;
            }

            float average = sum / list.Count;
            double SKZ = Math.Sqrt(sumPow2 / list.Count);

            double summa = 0;
            foreach (Int16 v in list)
            {
                summa += (v - average) * (v - average);
            }
            double SKO = Math.Sqrt(summa / list.Count);

            MainForm.ShowMessage(String.Format("среднее = {0}", Math.Round(average, 2)));
            MainForm.ShowMessage(String.Format("СКЗ = {0}", Math.Round(SKZ, 2)));
            MainForm.ShowMessage(String.Format("СКО = {0}", Math.Round(SKO, 2)));

            if (MainForm.GetInstance().GetSigProcessing())
                DrawGraphPython(list);
        }

        private static float ConvertToMG(uint scale, Int16 val)
        {
            switch (scale)
            {
                case 2:
                    return val * 0.061f;
                case 4:
                    return val * 0.122f;
                case 8:
                    return val * 0.244f;
                case 16:
                    return val * 0.488f;

            }
            return 0;
        }

        private static void DrawGraphPython(List<float> list)
        {
            StreamWriter wr = new StreamWriter(@"py\logFile.txt");
            foreach (Int16 v in list)
            {
                wr.WriteLine(v.ToString());
            }
            wr.Close();

            Process pr = new Process();
            pr.StartInfo.FileName = SystemParameters.PYTHON;
            pr.StartInfo.Arguments = SystemParameters.PY_SCRIPT;
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.UseShellExecute = false;
            pr.StartInfo.RedirectStandardInput = true;
            pr.Start();

            pr.WaitForExit();
        }

    }
}
