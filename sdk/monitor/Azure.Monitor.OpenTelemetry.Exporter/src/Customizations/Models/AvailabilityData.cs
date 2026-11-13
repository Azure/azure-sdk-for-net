// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class AvailabilityData
    {
        public AvailabilityData(int version, AvailabilityInfo availabilityInfo, ChangeTrackingDictionary<string, string> properties, LogRecord logRecord)
            : this(version, availabilityInfo.Id, availabilityInfo.Name, availabilityInfo.Duration, availabilityInfo.Success)
        {
            RunLocation = availabilityInfo.RunLocation;
            Message = availabilityInfo.Message;
            Properties = properties;
            Measurements = new ChangeTrackingDictionary<string, double>();
        }
    }
}
