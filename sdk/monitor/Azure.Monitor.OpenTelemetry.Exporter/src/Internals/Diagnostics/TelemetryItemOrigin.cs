// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    /// <summary>
    /// This is used for internal logs, to distinguish where a TelemetryItem originated from.
    /// </summary>
    /// <remarks>
    /// Because each Exporter can have a unique configuration, it's possible
    /// for one Exporter to have issues not experienced by any others in a process.
    /// </remarks>
    internal enum TelemetryItemOrigin
    {
        AzureMonitorTraceExporter,
        AzureMonitorMetricExporter,
        AzureMonitorLogExporter,
        Storage,
        UnitTest,
    }
}
