// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core.Pipeline;

using OpenTelemetry.Exporter.AzureMonitor.ConnectionString;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// This class encapsulates transmitting a collection of <see cref="TelemetryItem"/> to the configured Ingestion Endpoint.
    /// </summary>
    internal class AzureMonitorTransmitter
    {
        private readonly ApplicationInsightsRestClient applicationInsightsRestClient;
        private readonly AzureMonitorExporterOptions options;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions exporterOptions)
        {
            ConnectionStringParser.GetValues(exporterOptions.ConnectionString, out _, out string ingestionEndpoint);

            options = exporterOptions;
            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
        }

        public async ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            if (cancellationToken.IsCancellationRequested)
            {
                return 0;
            }

            Azure.Response<TrackResponse> response;

            if (async)
            {
                // TODO: RequestFailedException is thrown when http response is not equal to 200 or 206. Implement logic to catch exception.
                response = await this.applicationInsightsRestClient.TrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = this.applicationInsightsRestClient.TrackAsync(telemetryItems, cancellationToken).Result;
            }

            // TODO: Handle exception, check telemetryItems has items
            return response.Value.ItemsAccepted.GetValueOrDefault();
        }
    }
}
