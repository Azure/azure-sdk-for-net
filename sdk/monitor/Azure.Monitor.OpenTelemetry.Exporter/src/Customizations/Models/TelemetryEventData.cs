// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        }
    }
}
