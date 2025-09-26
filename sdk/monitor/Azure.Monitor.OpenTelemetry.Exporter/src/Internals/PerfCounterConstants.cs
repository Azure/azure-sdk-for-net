// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class PerfCounterConstants
    {
        internal const string PerfCounterMeterName = "PerfCounterMeter";
        internal const string RequestRateInstrumentationName = "RequestCounterRate";
        internal const string ProcessCpuInstrumentationName = "ProcessCpu";
        internal const string ProcessCpuNormalizedInstrumentationName = "ProcessCpuNormalized";
        internal const string ProcessPrivateBytesInstrumentationName = "ProcessPrivateBytes";
        internal const string ExceptionRateName = "AzureMonitorExceptionRate";

        // Breeze perf counter names
        internal const string ExceptionRateMetricIdValue = "\\.NET CLR Exceptions(??APP_CLR_PROC??)\\# of Exceps Thrown / sec";
        internal const string RequestRateMetricIdValue = "\\ASP.NET Applications(??APP_W3SVC_PROC??)\\Requests/Sec";
        internal const string ProcessCpuMetricIdValue = "\\Process(??APP_WIN32_PROC??)\\% Processor Time";
        internal const string ProcessCpuNormalizedMetricIdValue = "\\Process(??APP_WIN32_PROC??)\\% Processor Time Normalized";
        internal const string ProcessPrivateBytesMetricIdValue = "\\Process(??APP_WIN32_PROC??)\\Private Bytes";
    }
}
