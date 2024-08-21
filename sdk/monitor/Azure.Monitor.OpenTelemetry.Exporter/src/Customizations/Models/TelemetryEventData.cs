// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryEventData
    {
        public TelemetryEventData(int version, LogRecord logRecord) : base(version)
        {
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            Name = logRecord.EventId.Name;

            if (logRecord.Attributes != null)
            {
                foreach (var kv in logRecord.Attributes)
                {
                    Properties.Add(kv.Key, kv.Value?.ToString());
                }
            }
        }
    }
}
