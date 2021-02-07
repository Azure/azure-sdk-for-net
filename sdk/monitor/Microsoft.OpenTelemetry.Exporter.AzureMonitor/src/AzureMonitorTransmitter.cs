// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// This class encapsulates transmitting a collection of <see cref="TelemetryItem"/> to the configured Ingestion Endpoint.
    /// </summary>
    internal class AzureMonitorTransmitter : ITransmitter
    {
        private readonly ApplicationInsightsRestClient applicationInsightsRestClient;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options)
        {
            ConnectionStringParser.GetValues(options.ConnectionString, out _, out string ingestionEndpoint);
            options.Retry.MaxRetries = 0;
            options.AddPolicy(new IngestionResponsePolicy(), HttpPipelinePosition.PerCall);

            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
        }

        public async ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return 0;
            }

            int itemsAccepted = 0;

            try
            {
                if (async)
                {
                    itemsAccepted = await this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    itemsAccepted = this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).Result;
                }
            }
            catch (Exception ex)
            {
                if (ex?.InnerException?.InnerException?.Source == "System.Net.Http")
                {
                    // TODO: Network issue. Send Telemetry Items To Storage
                }

                AzureMonitorExporterEventSource.Log.Write($"FailedToSend{EventLevelSuffix.Error}", ex.LogAsyncException());
            }

            return itemsAccepted;
        }
    }
}
