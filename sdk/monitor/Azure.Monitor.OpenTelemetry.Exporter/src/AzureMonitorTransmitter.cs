// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;

using Azure.Monitor.OpenTelemetry.Exporter.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Contrib.Extensions.PersistentStorage;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// This class encapsulates transmitting a collection of <see cref="TelemetryItem"/> to the configured Ingestion Endpoint.
    /// </summary>
    internal class AzureMonitorTransmitter : ITransmitter
    {
        private readonly ApplicationInsightsRestClient applicationInsightsRestClient;
        internal IPersistentStorage storage;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options)
        {
            storage = new FileStorage(options.StorageDirectory);
            ConnectionStringParser.GetValues(options.ConnectionString, out _, out string ingestionEndpoint);
            options.Retry.MaxRetries = 0;
            options.AddPolicy(new IngestionResponsePolicy(this), HttpPipelinePosition.PerCall);

            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
        }

        public async ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return 0;
            }

            int itemsAccepted = 0;

            if (async)
            {
                itemsAccepted = await this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, storage, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                itemsAccepted = this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, storage, cancellationToken).Result;
            }

            return itemsAccepted;
        }
    }
}
