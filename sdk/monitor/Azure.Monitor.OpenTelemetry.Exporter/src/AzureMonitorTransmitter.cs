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
            try
            {
                storage = new FileStorage(options.StorageDirectory);
            }
            catch (Exception)
            {
                // TODO:
                // log exception
                // Remove this when we add an option to disable offline storage.
                // So if someone opts in for storage and we cannot initialize, we can throw.
                // Change needed on persistent storage side to throw if not able to create storage directory.
            }
            ConnectionStringParser.GetValues(options.ConnectionString, out _, out string ingestionEndpoint);

            applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);
        }

        public async ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            // TODO
            // Change return type of this function to ExportResult
            int result = 0;
            if (cancellationToken.IsCancellationRequested)
            {
                return result;
            }

            try
            {
                using var message = async ? await this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false) :
                    this.applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).Result;

                if (message != null)
                {
                    if (storage == null && message.HasResponse && message.Response.Status == ResponseStatusCodes.Success)
                    {
                        result = 1;
                    }
                    else
                    {
                        ApplyPolicies(message);
                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToTransmit{EventLevelSuffix.Error}", ex.LogAsyncException());
            }

            return result;
        }

        private void ApplyPolicies(HttpMessage message)
        {
            if (message.HasResponse)
            {
                HandleFailureResponseCodes(message);
            }
            else
            {
                var content = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                storage.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
            }
        }

        private void HandleFailureResponseCodes(HttpMessage message)
        {
            byte[] content;
            int retryInterval;
            switch (message.Response.Status)
            {
                case ResponseStatusCodes.Success:
                    // log successful message
                    break;
                case ResponseStatusCodes.PartialSuccess:
                    // Parse retry-after header
                    // Send Failed Messages To Storage
                    TrackResponse response = HttpPipelineHelper.GetTrackResponse(message);
                    content = HttpPipelineHelper.GetPartialContentForRetry(response, message);
                    if (content != null)
                    {
                        retryInterval = HttpPipelineHelper.GetRetryInterval(message);
                        storage.SaveTelemetry(content, retryInterval);
                    }
                    break;
                case ResponseStatusCodes.RequestTimeout:
                case ResponseStatusCodes.ResponseCodeTooManyRequests:
                case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    // Parse retry-after header
                    // Send Messages To Storage
                    content = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                    retryInterval = HttpPipelineHelper.GetRetryInterval(message);
                    storage.SaveTelemetry(content, retryInterval);
                    break;
                case ResponseStatusCodes.InternalServerError:
                case ResponseStatusCodes.BadGateway:
                case ResponseStatusCodes.ServiceUnavailable:
                case ResponseStatusCodes.GatewayTimeout:
                    // Send Messages To Storage
                    content = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                    storage.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
                    break;
                default:
                    // Log Non-Retriable Status and don't retry or store;
                    break;
            }
        }
    }
}
