// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal class MockTransmitter : ITransmitter, IMultiTenantTransmitter
    {
        public readonly IList<TelemetryItem> TelemetryItems;

        public string InstrumentationKey => "00000000-0000-0000-0000-000000000000";

        public MockTransmitter(IList<TelemetryItem> telemetryItems)
        {
            this.TelemetryItems = telemetryItems;
        }

        public ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
        {
            lock (this.TelemetryItems)
            {
                TrackAsyncCallCount++;

                foreach (var telemetryItem in telemetryItems)
                {
                    this.TelemetryItems.Add(telemetryItem);
                }
            }

            return new ValueTask<ExportResult>(Task.FromResult(ExportResult.Success));
        }

        public int TrackAsyncCallCount { get; private set; }

        /// <summary>
        /// Per multi-tenant send: the destination endpoint and the items delivered to it.
        /// </summary>
        public readonly List<(string IngestionEndpoint, TelemetryItem[] TelemetryItems)> Sends = new();

        public ExportResult MultiTenantResult { get; set; } = ExportResult.Success;

        public ExportResult Track(EndpointRouteBatch routeBatch, TelemetryItemOrigin origin, CancellationToken cancellationToken)
        {
            lock (this.Sends)
            {
                for (int i = 0; i < routeBatch.Count; i++)
                {
                    var group = routeBatch[i];
                    Sends.Add((group.IngestionEndpoint, group.TelemetryItems.ToArray()));
                }
            }

            return MultiTenantResult;
        }

        public ValueTask TransmitFromStorage(long maxFileToTransmit, bool async, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IDisposable BeginPersistOnlyScope()
        {
            PersistOnlyScopeCount++;
            return new NoopScope();
        }

        public void DrainStorage(int waitMilliseconds) => DrainStorageCallCount++;

        public int PersistOnlyScopeCount { get; private set; }

        public int DrainStorageCallCount { get; private set; }

        public void Dispose()
        {
        }

        private sealed class NoopScope : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
