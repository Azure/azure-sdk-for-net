// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Extensions.PersistentStorage;
using OpenTelemetry.Extensions.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// This class encapsulates transmitting a collection of <see cref="TelemetryItem"/> to the configured Ingestion Endpoint.
    /// </summary>
    internal class AzureMonitorTransmitter : ITransmitter
    {
        private readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        internal PersistentBlobProvider _storage;
        private readonly string _instrumentationKey;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Retry.MaxRetries = 0;
            ConnectionString.ConnectionStringParser.GetValues(options.ConnectionString, out _instrumentationKey, out string ingestionEndpoint);
            _applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), host: ingestionEndpoint);

            if (!options.DisableOfflineStorage)
            {
                try
                {
                    _storage = new FileBlobProvider(options.StorageDirectory);
                }
                catch (Exception)
                {
                    // TODO:
                    // log exception
                    // Remove this when we add an option to disable offline storage.
                    // So if someone opts in for storage and we cannot initialize, we can throw.
                    // Change needed on persistent storage side to throw if not able to create storage directory.
                }
            }
        }

        public string InstrumentationKey
        {
            get
            {
                return _instrumentationKey;
            }
        }

        public async ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            ExportResult result = ExportResult.Failure;
            if (cancellationToken.IsCancellationRequested)
            {
                return result;
            }

            try
            {
                using var httpMessage = async ?
                    await _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false) :
                    _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).Result;

                result = IsSuccess(httpMessage);

                if (result == ExportResult.Failure && _storage != null)
                {
                    result = HandleFailures(httpMessage);
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToTransmit{EventLevelSuffix.Error}", ex.LogAsyncException());
            }

            return result;
        }

        public async ValueTask TransmitFromStorage(long maxFilesToTransmit, bool async, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            long files = maxFilesToTransmit;
            while (files > 0)
            {
                try
                {
                    // TODO: Do we need more lease time?
                    if (_storage.TryGetBlob(out var blob) && blob.TryLease(1000))
                    {
                        blob.TryRead(out var data);
                        using var httpMessage = async ?
                            await _applicationInsightsRestClient.InternalTrackAsync(data, cancellationToken).ConfigureAwait(false) :
                            _applicationInsightsRestClient.InternalTrackAsync(data, cancellationToken).Result;

                        var result = IsSuccess(httpMessage);

                        if (result == ExportResult.Success)
                        {
                            blob.TryDelete();
                        }
                        else
                        {
                            HandleFailures(httpMessage, blob);
                        }
                    }
                    else
                    {
                        // no files to process
                        return;
                    }
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.Write($"FailedToTransmitFromStorage{EventLevelSuffix.Error}", ex.LogAsyncException());
                }

                files--;
            }
        }

        private static ExportResult IsSuccess(HttpMessage httpMessage)
        {
            if (httpMessage.HasResponse && httpMessage.Response.Status == ResponseStatusCodes.Success)
            {
                return ExportResult.Success;
            }

            return ExportResult.Failure;
        }

        private ExportResult HandleFailures(HttpMessage httpMessage)
        {
            ExportResult result = ExportResult.Failure;
            byte[] content;
            int retryInterval;

            if (!httpMessage.HasResponse)
            {
                // HttpRequestException
                content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                result = _storage.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
            }
            else
            {
                switch (httpMessage.Response.Status)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        TrackResponse trackResponse = HttpPipelineHelper.GetTrackResponse(httpMessage);
                        content = HttpPipelineHelper.GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                        if (content != null)
                        {
                            retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                            result = _storage.SaveTelemetry(content, retryInterval);
                        }
                        break;
                    case ResponseStatusCodes.RequestTimeout:
                    case ResponseStatusCodes.ResponseCodeTooManyRequests:
                    case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                        // Parse retry-after header
                        // Send Messages To Storage
                        content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                        retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                        result = _storage.SaveTelemetry(content, retryInterval);
                        break;
                    case ResponseStatusCodes.InternalServerError:
                    case ResponseStatusCodes.BadGateway:
                    case ResponseStatusCodes.ServiceUnavailable:
                    case ResponseStatusCodes.GatewayTimeout:
                        // Send Messages To Storage
                        content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                        result = _storage.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
                        break;
                    default:
                        // Log Non-Retriable Status and don't retry or store;
                        break;
                }
            }

            return result;
        }

        private void HandleFailures(HttpMessage httpMessage, PersistentBlob blob)
        {
            int retryInterval;

            if (!httpMessage.HasResponse)
            {
                // HttpRequestException
                // Extend lease time so that it is not picked again for retry.
                blob.TryLease(HttpPipelineHelper.MinimumRetryInterval);
            }
            else
            {
                switch (httpMessage.Response.Status)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        // Delete existing file
                        TrackResponse trackResponse = HttpPipelineHelper.GetTrackResponse(httpMessage);
                        var content = HttpPipelineHelper.GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                        if (content != null)
                        {
                            retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                            blob.TryDelete();
                            _storage.SaveTelemetry(content, retryInterval);
                        }
                        break;
                    case ResponseStatusCodes.RequestTimeout:
                    case ResponseStatusCodes.ResponseCodeTooManyRequests:
                    case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                        // Extend lease time using retry interval period
                        // so that it is not picked up again before that.
                        retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                        blob.TryLease(retryInterval);
                        break;
                    case ResponseStatusCodes.InternalServerError:
                    case ResponseStatusCodes.BadGateway:
                    case ResponseStatusCodes.ServiceUnavailable:
                    case ResponseStatusCodes.GatewayTimeout:
                        // Extend lease time so that it is not picked up again
                        blob.TryLease(HttpPipelineHelper.MinimumRetryInterval);
                        break;
                    default:
                        // Log Non-Retriable Status and don't retry or store;
                        // File will be cleared by maintenance job
                        break;
                }
            }
        }
    }
}
