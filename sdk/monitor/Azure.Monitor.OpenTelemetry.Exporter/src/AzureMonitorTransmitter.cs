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
        private static System.Timers.Timer aTimer;
        public AzureMonitorTransmitter(AzureMonitorExporterOptions options)
        {
            ConnectionStringParser.GetValues(options.ConnectionString, out _, out string ingestionEndpoint);
            options.Retry.MaxRetries = 0;
            options.AddPolicy(new IngestionResponsePolicy(), HttpPipelinePosition.PerCall);

            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
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

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            foreach (var blobItem in AzureMonitorConverter.storage.GetBlobs())
            {
                Console.WriteLine(((LocalFileBlob)blobItem).FullPath);
            }

            // Get blob.
            IPersistentBlob blob = AzureMonitorConverter.storage.GetBlob();

            if (blob != null)
            {
                blob.Lease(100000);
                var items = blob.Read();
                try
                {
                    var itemAccepted = this.applicationInsightsRestClient.InternalTrackAsync(items, CancellationToken.None).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                blob.Delete();
            }
        }
    }
}
