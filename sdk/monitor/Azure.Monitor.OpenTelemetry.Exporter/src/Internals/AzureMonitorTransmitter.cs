// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Extensions.PersistentStorage;
using OpenTelemetry.Extensions.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// This class encapsulates transmitting a collection of <see cref="TelemetryItem"/> to the configured Ingestion Endpoint.
    /// </summary>
    internal class AzureMonitorTransmitter : ITransmitter
    {
        private readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        internal PersistentBlobProvider? _fileBlobProvider;
        private readonly AzureMonitorStatsbeat? _statsbeat;
        private readonly ConnectionVars _connectionVars;
        private bool _disposed;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options, TokenCredential? credential = null)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Retry.MaxRetries = 0;

            _connectionVars = InitializeConnectionVars(options);

            _applicationInsightsRestClient = InitializeRestClient(options, _connectionVars, credential);

            _fileBlobProvider = InitializeOfflineStorage(options);

            _statsbeat = InitializeStatsbeat(options, _connectionVars);
        }

        private static ConnectionVars InitializeConnectionVars(AzureMonitorExporterOptions options)
        {
            if (options.ConnectionString == null)
            {
                var connectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return ConnectionStringParser.GetValues(connectionString);
                }
            }
            else
            {
                return ConnectionStringParser.GetValues(options.ConnectionString);
            }

            throw new InvalidOperationException("A connection string was not found. This MUST be provided via either AzureMonitorExporterOptions or set in the environment variable 'APPLICATIONINSIGHTS_CONNECTION_STRING'");
        }

        private static ApplicationInsightsRestClient InitializeRestClient(AzureMonitorExporterOptions options, ConnectionVars connectionVars, TokenCredential? credential)
        {
            HttpPipeline pipeline;

            if (credential != null)
            {
                var scope = AadHelper.GetScope(connectionVars.AadAudience);
                var httpPipelinePolicy = new HttpPipelinePolicy[]
                {
                    new BearerTokenAuthenticationPolicy(credential, scope),
                    new IngestionRedirectPolicy()
                };

                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                AzureMonitorExporterEventSource.Log.WriteInformational("SetAADCredentialsToPipeline", $"HttpPipelineBuilder is built with AAD Credentials. TokenCredential: {credential.GetType().Name} Scope: {scope}");
            }
            else
            {
                var httpPipelinePolicy = new HttpPipelinePolicy[] { new IngestionRedirectPolicy() };
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
            }

            return new ApplicationInsightsRestClient(new ClientDiagnostics(options), pipeline, host: connectionVars.IngestionEndpoint);
        }

        private static PersistentBlobProvider? InitializeOfflineStorage(AzureMonitorExporterOptions options)
        {
            if (!options.DisableOfflineStorage)
            {
                try
                {
                    var storageDirectory = options.StorageDirectory
                        ?? StorageHelper.GetDefaultStorageDirectory()
                        ?? throw new InvalidOperationException("Unable to determine offline storage directory.");

                    // TODO: Fallback to default location if location provided via options does not work.
                    AzureMonitorExporterEventSource.Log.WriteInformational("InitializedPersistentStorage", storageDirectory);

                    return new FileBlobProvider(storageDirectory);
                }
                catch (Exception ex)
                {
                    // TODO:
                    // Remove this when we add an option to disable offline storage.
                    // So if someone opts in for storage and we cannot initialize, we can throw.
                    // Change needed on persistent storage side to throw if not able to create storage directory.
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToInitializePersistentStorage", ex);

                    return null;
                }
            }

            return null;
        }

        private static AzureMonitorStatsbeat? InitializeStatsbeat(AzureMonitorExporterOptions options, ConnectionVars connectionVars)
        {
            if (options.EnableStatsbeat && connectionVars != null)
            {
                try
                {
                    var disableStatsbeat = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_STATSBEAT_DISABLED");
                    if (string.Equals(disableStatsbeat, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        AzureMonitorExporterEventSource.Log.WriteInformational("StatsbeatInitialization: ", "Statsbeat was disabled via environment variable");

                        return null;
                    }

                    // TODO: uncomment following line for enablement.
                    // return new AzureMonitorStatsbeat(connectionVars);
                    return null;
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteWarning($"ErrorInitializingStatsbeatFor:{connectionVars.InstrumentationKey}", ex);
                }
            }

            return null;
        }

        public string InstrumentationKey => _connectionVars.InstrumentationKey;

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

            if (_fileBlobProvider == null)
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
            if (_fileBlobProvider == null)
            {
                return ExportResult.Failure;
            }

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
                            _fileBlobProvider?.SaveTelemetry(content, retryInterval);
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

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.WriteVerbose(name: nameof(AzureMonitorTransmitter), message: $"{nameof(AzureMonitorTransmitter)} has been disposed.");
                    _statsbeat?.Dispose();
                    var fileBlobProvider = _fileBlobProvider as FileBlobProvider;
                    if ( fileBlobProvider != null )
                    {
                        fileBlobProvider.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
