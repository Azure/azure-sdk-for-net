// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryEventData
    {
        public TelemetryEventData(int version, string name, IDictionary<string, string> properties, string? message, LogRecord logRecord) : base(version)
        {
            Name = name;
            Properties = properties;
            Measurements = new ChangeTrackingDictionary<string, double>();

            // TODO: REMOVE THIS. I'm evaluating if the message property is something that should be recorded
            properties.Add("Message (THIS IS A TEST)", message ?? "NULL");

#pragma warning disable CS0618 // Type or member is obsolete
            // TODO: Remove warning disable with next Stable release.
            properties.Add("Severity", LogsHelper.GetSeverityLevel(logRecord.LogLevel).ToString());
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
