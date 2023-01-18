﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
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
        internal PersistentBlobProvider _fileBlobProvider;
        private readonly string _instrumentationKey;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options, TokenCredential credential = null)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Retry.MaxRetries = 0;
            ConnectionStringParser.GetValues(options.ConnectionString, out _instrumentationKey, out string ingestionEndpoint);

            HttpPipeline pipeline;
            if (credential != null)
            {
                var httpPipelinePolicy = new HttpPipelinePolicy[]
                                             {
                                                 new BearerTokenAuthenticationPolicy(credential, "https://monitor.azure.com//.default"),
                                                 new IngestionRedirectPolicy()
                                             };

                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                AzureMonitorExporterEventSource.Log.WriteInformational("SetAADCredentialsToPipeline", "HttpPipelineBuilder is built with AAD Credentials");
            }
            else
            {
                var httpPipelinePolicy = new HttpPipelinePolicy[] { new IngestionRedirectPolicy() };
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
            }

            _applicationInsightsRestClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), pipeline, host: ingestionEndpoint);

            if (!options.DisableOfflineStorage)
            {
                try
                {
                    var storageDirectory = options.StorageDirectory ?? StorageHelper.GetDefaultStorageDirectory();

                    // TODO: Fallback to default location if location provided via options does not work.
                    _fileBlobProvider = new FileBlobProvider(storageDirectory);

                    AzureMonitorExporterEventSource.Log.WriteInformational("InitializedPersistentStorage", storageDirectory);
                }
                catch (Exception ex)
                {
                    // TODO:
                    // Remove this when we add an option to disable offline storage.
                    // So if someone opts in for storage and we cannot initialize, we can throw.
                    // Change needed on persistent storage side to throw if not able to create storage directory.
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToInitializePersistentStorage", ex);
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

                if (result == ExportResult.Failure && _fileBlobProvider != null)
                {
                    result = HandleFailures(httpMessage);
                }
                else
                {
                    AzureMonitorExporterEventSource.Log.WriteInformational("TransmissionSuccess", "Successfully transmitted a batch of telemetry Items.");
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToTransmit", ex);
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
                    if (_fileBlobProvider.TryGetBlob(out var blob) && blob.TryLease(1000))
                    {
                        blob.TryRead(out var data);
                        using var httpMessage = async ?
                            await _applicationInsightsRestClient.InternalTrackAsync(data, cancellationToken).ConfigureAwait(false) :
                            _applicationInsightsRestClient.InternalTrackAsync(data, cancellationToken).Result;

                        var result = IsSuccess(httpMessage);

                        if (result == ExportResult.Success)
                        {
                            AzureMonitorExporterEventSource.Log.WriteInformational("TransmitFromStorageSuccess", "Successfully transmitted a blob from storage.");

                            // In case if the delete fails, there is a possibility
                            // that the current batch will be transmitted more than once resulting in duplicates.
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
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToTransmitFromStorage", ex);
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
            int statusCode = 0;
            byte[] content;
            int retryInterval;

            if (!httpMessage.HasResponse)
            {
                // HttpRequestException
                content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                result = _fileBlobProvider.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
            }
            else
            {
                statusCode = httpMessage.Response.Status;
                switch (statusCode)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        TrackResponse trackResponse = HttpPipelineHelper.GetTrackResponse(httpMessage);
                        content = HttpPipelineHelper.GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                        if (content != null)
                        {
                            retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                            result = _fileBlobProvider.SaveTelemetry(content, retryInterval);
                        }
                        break;
                    case ResponseStatusCodes.RequestTimeout:
                    case ResponseStatusCodes.ResponseCodeTooManyRequests:
                    case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                        // Parse retry-after header
                        // Send Messages To Storage
                        content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                        retryInterval = HttpPipelineHelper.GetRetryInterval(httpMessage.Response);
                        result = _fileBlobProvider.SaveTelemetry(content, retryInterval);
                        break;
                    case ResponseStatusCodes.Unauthorized:
                    case ResponseStatusCodes.Forbidden:
                    case ResponseStatusCodes.InternalServerError:
                    case ResponseStatusCodes.BadGateway:
                    case ResponseStatusCodes.ServiceUnavailable:
                    case ResponseStatusCodes.GatewayTimeout:
                        // Send Messages To Storage
                        content = HttpPipelineHelper.GetRequestContent(httpMessage.Request.Content);
                        result = _fileBlobProvider.SaveTelemetry(content, HttpPipelineHelper.MinimumRetryInterval);
                        break;
                    default:
                        // Log Non-Retriable Status and don't retry or store;
                        break;
                }
            }

            if (result == ExportResult.Success)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmit", $"Error code is {statusCode}: Telemetry is stored offline for retry");
            }
            else
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmit", $"Error code is {statusCode}: Telemetry is dropped");
            }

            return result;
        }

        private void HandleFailures(HttpMessage httpMessage, PersistentBlob blob)
        {
            int retryInterval;
            int statusCode = 0;
            bool shouldRetry = true;

            if (!httpMessage.HasResponse)
            {
                // HttpRequestException
                // Extend lease time so that it is not picked again for retry.
                blob.TryLease(HttpPipelineHelper.MinimumRetryInterval);
            }
            else
            {
                statusCode = httpMessage.Response.Status;
                switch (statusCode)
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
                            _fileBlobProvider.SaveTelemetry(content, retryInterval);
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
                    case ResponseStatusCodes.Unauthorized:
                    case ResponseStatusCodes.Forbidden:
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
                        shouldRetry = false;
                        break;
                }
            }

            if (shouldRetry)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmitFromStorage", $"Error code is {statusCode}: Telemetry is stored offline for retry");
            }
            else
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmitFromStorage", $"Error code is {statusCode}: Telemetry is dropped");
            }
        }
    }
}
