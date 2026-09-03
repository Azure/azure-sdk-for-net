// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant
{
    internal interface IMultiTenantTransmitter : ITransmitter
    {
        /// <summary>
        /// Sends each endpoint group to its own ingestion endpoint and blocks until every group has
        /// completed. Returns <see cref="ExportResult.Success"/> only when all of them succeeded.
        /// </summary>
        ExportResult Track(EndpointRouteBatch routeBatch, TelemetryItemOrigin origin, CancellationToken cancellationToken);
    }
}
