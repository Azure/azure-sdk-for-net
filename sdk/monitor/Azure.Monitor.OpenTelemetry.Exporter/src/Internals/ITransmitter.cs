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
        ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken, TelemetryCounter telemetryCounter);
        string InstrumentationKey { get; }
    }
}
