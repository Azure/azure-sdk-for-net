// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace OpenTelemetry.Exporter.AzureMonitor.Models
{
    public partial class TelemetryItem
    {
        public TelemetryItem Clone(string telemetryName, DateTimeOffset dateTimeOffset)
        {
            TelemetryItem telemetryItem = new TelemetryItem(telemetryName, dateTimeOffset)
            {
                InstrumentationKey = this.InstrumentationKey
            };

            foreach (var tag in this.Tags)
            {
                telemetryItem.Tags.Add(tag);
            }

            return telemetryItem;
        }
    }
}
