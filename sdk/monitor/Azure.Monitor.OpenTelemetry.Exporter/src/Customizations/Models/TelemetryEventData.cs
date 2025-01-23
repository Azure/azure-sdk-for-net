// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryEventData
    {
        public TelemetryEventData(int version, string name, ChangeTrackingDictionary<string, string> properties, string? message, LogRecord logRecord) : base(version)
        {
            Name = name;
            Properties = properties;
            Measurements = new ChangeTrackingDictionary<string, double>();

            // TODO: THIS IS A TEST
            properties.Add("Message", message ?? "NULL");

#pragma warning disable CS0618 // Type or member is obsolete
            // TODO: Remove warning disable with next Stable release.
            properties.Add("Severity", LogsHelper.GetSeverityLevel(logRecord.LogLevel).ToString());
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
