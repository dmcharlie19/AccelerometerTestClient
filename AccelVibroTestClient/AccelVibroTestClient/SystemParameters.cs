/*-----------------------------------------------------------------------------
SystemParameters.cs


-----------------------------------------------------------------------------*/
using System;

namespace AccelVibroTestClient
{
    public enum TestExecutionStates
    {
        error = -1,
        wait = 0,
        connected = 1,
        paramsAccepted = 2,
        measureStarted = 3,
        measureCompleted = 4
    }

    public enum CommandLineArgumentsParsingResult
    {
        ArgumentNotFound,
        Success,
        IncorrectSyntax
    }

    static public class SystemParameters
    {
        // Пути к внешним программам, которые используются в работе

        public const string RTT_JLINK = @"JLink_V630\JLink.exe";
        public const string NRFJPROG_PATH  = @"nrfjprog\nrfjprog.exe";
        public const string PYTHON = @"py\python.exe";
        public const string PY_SCRIPT    = @"py\DataProcessing.py";

        // Максимальное количество строк в файле лога. Придостижении делается вывод о зависании встроенного ПО
        public const int MAX_LINES_IN_LOG = 10000;

        /// <summary>
        /// Коды, возвращаемые приложением
        /// </summary>
        public const int RETURN_CODE_SUCCESS                    = 0;
        public const int RETURN_CODE_FAIL                       = -1;
        public const int RETURN_CODE_FAILED_ARG_PARAMETR        = -2;
        public const int RETURN_CODE_FAILED_PROGRAMM_FIRMWARE   = -3;
        public const int RETURN_CODE_FAILED_START_TEST          = -4;
        public const int RETURN_CODE_FAILED_STOP_TEST           = -5;
        public const int RETURN_CODE_TEST_FAILED                = -6;
        public static bool SUCCESSED(int res)
        {
            return (res >= 0);
        }
        public static bool FAILED(int res)
        {
            return (res < 0);
        }
    }
}
