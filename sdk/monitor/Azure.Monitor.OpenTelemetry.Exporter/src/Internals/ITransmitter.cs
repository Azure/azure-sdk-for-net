// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal interface ITransmitter : IDisposable
    {
        /// <summary>
        /// Sent telemetry and return the number of items Accepted.
        /// </summary>
        ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken);

        string InstrumentationKey { get; }

        /// <summary>
        /// While the returned scope is held, telemetry is written to persistent storage instead of
        /// being transmitted. Held across the shutdown drain so process exit costs a file write
        /// rather than an ingestion round trip.
        /// </summary>
        IDisposable BeginPersistOnlyScope();

        /// <summary>
        /// Starts a background drain of persisted telemetry and waits at most
        /// <paramref name="waitMilliseconds"/> for it. Anything left behind stays on disk and is
        /// picked up by a later drain, in this process or the next one.
        /// </summary>
        void DrainStorage(int waitMilliseconds);
    }
}
