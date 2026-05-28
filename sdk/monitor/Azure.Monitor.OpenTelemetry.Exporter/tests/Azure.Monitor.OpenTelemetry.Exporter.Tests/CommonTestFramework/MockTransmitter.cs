// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal class MockTransmitter : ITransmitter
    {
        public readonly IList<TelemetryItem> TelemetryItems;

        public string InstrumentationKey => "00000000-0000-0000-0000-000000000000";

        public MockTransmitter(IList<TelemetryItem> telemetryItems)
        {
            this.TelemetryItems = telemetryItems;
        }

        public ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
        {
            foreach (var telemetryItem in telemetryItems)
            {
                this.TelemetryItems.Add(telemetryItem);
            }

            return new ValueTask<ExportResult>(Task.FromResult(ExportResult.Success));
        }

        public ValueTask TransmitFromStorage(long maxFileToTransmit, bool async, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
