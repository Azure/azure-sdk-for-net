// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Azure.Core;
using Azure.Core.Pipeline;

using Azure.Monitor.OpenTelemetry.Exporter.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Extensions.Storage;

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
            storage = new LocalFileStorage(options.StorageFolder);
            ConnectionStringParser.GetValues(options.ConnectionString, out _, out string ingestionEndpoint);
            options.Retry.MaxRetries = 0;

            options.AddPolicy(new IngestionResponsePolicy(storage), HttpPipelinePosition.PerCall);

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

        public async ValueTask TransmitFromStorage(bool async, CancellationToken cancellationToken)
        {
            foreach (var blob in storage.GetBlobs())
            {
                // todo: time to lease?
                blob.Lease(10000);
                var batch = blob.Read();
                int itemsAccepted = 0;
                if (batch != null)
                {
                    if (async)
                    {
                        itemsAccepted = await this.applicationInsightsRestClient.InternalTrackAsync(batch, storage, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        itemsAccepted = this.applicationInsightsRestClient.InternalTrackAsync(batch, storage, cancellationToken).Result;
                    }

                    // Delete the blob here
                    // as new one will be created in case of failure
                    blob.Delete();
                    if (itemsAccepted != 0)
                    {
                        // log successfull transmit from storage.
                    }
                    else
                    {
                        // log unsuccessfull attempt
                    }
                }
            }
        }
    }
}
