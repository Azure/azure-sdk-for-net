namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class PerfCounterConstants
    {
        internal const string PerfCounterMeterName = "PerfCounterMeter";
        internal const string ExceptionRateInstrumentName = "ExceptionRate";
        internal const string RequestRateInstrumentName = "RequestRate";
        internal const string ProcessCpuInstrumentName = "ProcessCpu";
        internal const string ProcessCpuNormalizedInstrumentName = "ProcessCpuNormalized";
        internal const string ProcessPrivateBytesInstrumentName = "ProcessPrivateBytes";

        // breeze perf counter names
        internal const string ExceptionRateMetricIdValue = "\.NET CLR Exceptions(??APP_CLR_PROC??)\# of Exceps Thrown / sec";
        internal const string RequestRateMetricIdValue = "\ASP.NET Applications(??APP_W3SVC_PROC??)\Requests/Sec";
        internal const string ProcessCpuMetricIdValue = "\Process(??APP_WIN32_PROC??)\% Processor Time";
        internal const string ProcessCpuNormalizedMetricIdValue = "\Process(??APP_WIN32_PROC??)\% Processor Time Normalized";
        internal const string ProcessPrivateBytesMetricIdValue = "\Process(??APP_WIN32_PROC??)\Private Bytes";

    }
}
