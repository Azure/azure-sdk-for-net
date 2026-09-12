// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal partial class MockTransmitter : IMultiTenantTransmitter
    {
        public readonly List<(string IngestionEndpoint, TelemetryItem[] TelemetryItems)> Sends = new();

        public ExportResult MultiTenantResult { get; set; } = ExportResult.Success;

        public ExportResult Track(EndpointRouteBatch routeBatch, TelemetryItemOrigin origin, CancellationToken cancellationToken)
        {
            lock (this.Sends)
            {
                for (int groupIndex = 0; groupIndex < routeBatch.Count; groupIndex++)
                {
                    var group = routeBatch[groupIndex];
                    Sends.Add((group.IngestionEndpoint, group.TelemetryItems.ToArray()));
                }
            }

            return MultiTenantResult;
        }
    }
}