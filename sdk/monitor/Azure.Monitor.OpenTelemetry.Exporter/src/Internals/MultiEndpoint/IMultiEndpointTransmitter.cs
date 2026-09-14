// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    internal interface IMultiEndpointTransmitter : ITransmitter
    {
        /// <summary>
        /// Which destinations this transmitter may address. Restrictive only while an Entra ID
        /// credential is configured, because the token would otherwise follow telemetry to
        /// whatever host it names.
        /// </summary>
        EndpointTrustPolicy TrustPolicy { get; }

        /// <summary>
        /// Sends each endpoint group to its own ingestion endpoint and blocks until every group has
        /// completed. A group that cannot be sent - the endpoint is backing off, or shutdown is
        /// persisting only - is written to that endpoint's storage partition and counts as success.
        /// Failure means a group was neither delivered nor stored.
        /// </summary>
        ExportResult Track(EndpointRouteBatch routeBatch, TelemetryItemOrigin origin, CancellationToken cancellationToken);
    }
}
