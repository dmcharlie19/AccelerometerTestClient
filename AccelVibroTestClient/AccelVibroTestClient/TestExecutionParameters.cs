/*-----------------------------------------------------------------------------
TestExecutionParameters.cs

Параметры прохождения тестирования
-----------------------------------------------------------------------------*/
using System;

namespace AccelVibroTestClient
{
    public enum AxisState
    {
        ONLY_X = 1,
        ONLY_Y = 2,
        ONLY_Z = 3
    };

    public enum FilterState
    {
        FilterDisable = 0,
        LPF = 1,
        HPF = 2
    };

    public class TestExecutionParameters
    {
        public uint scale;
        public uint MeasureCount;
        public FilterState filterState;
        public uint Bandwidth;
        public AxisState Axis;
    }
}
