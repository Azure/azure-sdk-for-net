namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class PerfCounterConstants
    {
        internal const string PerfCounterMeterName = "PerfCounterMeter";
        internal const string ExceptionRateGauge = "ExceptionRateGauge";
        internal const string RequestRateGauge = "RequestRateGauge";
        internal const string ProcessCpuGauge = "ProcessCpuGauge";
        internal const string ProcessCpuNormalizedGauge = "ProcessCpuNormalizedGauge";
        internal const string ProcessPrivateBytesGauge = "ProcessPrivateBytesGauge";
    }
}
