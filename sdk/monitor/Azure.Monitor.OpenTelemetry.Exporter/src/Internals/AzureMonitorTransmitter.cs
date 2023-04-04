// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        internal readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        internal PersistentBlobProvider? _fileBlobProvider;
        private readonly AzureMonitorStatsbeat? _statsbeat;
        private readonly ConnectionVars _connectionVars;
        internal readonly TransmissionStateManager _transmissionStateManager;
        internal readonly TransmitFromStorageHandler? _transmitFromStorageHandler;
        private bool _disposed;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Retry.MaxRetries = 0;

            _connectionVars = InitializeConnectionVars(options);

            _applicationInsightsRestClient = InitializeRestClient(options, _connectionVars);

            _transmissionStateManager = new TransmissionStateManager();

            _fileBlobProvider = InitializeOfflineStorage(options);

            if (_fileBlobProvider != null)
            {
                _transmitFromStorageHandler = new TransmitFromStorageHandler(_applicationInsightsRestClient, _fileBlobProvider, _transmissionStateManager);
            }

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

            throw new InvalidOperationException("A connection string was not found. Please set your connection string.");
        }

        private static ApplicationInsightsRestClient InitializeRestClient(AzureMonitorExporterOptions options, ConnectionVars connectionVars)
        {
            HttpPipeline pipeline;

            if (options.Credential != null)
            {
                var scope = AadHelper.GetScope(connectionVars.AadAudience);
                var httpPipelinePolicy = new HttpPipelinePolicy[]
                {
                    new BearerTokenAuthenticationPolicy(options.Credential, scope),
                    new IngestionRedirectPolicy()
                };

                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                AzureMonitorExporterEventSource.Log.WriteInformational("SetAADCredentialsToPipeline", $"HttpPipelineBuilder is built with AAD Credentials. TokenCredential: {options.Credential.GetType().Name} Scope: {scope}");
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

                    return new AzureMonitorStatsbeat(connectionVars);
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

                result = HttpPipelineHelper.IsSuccess(httpMessage);

                if (result == ExportResult.Failure && _fileBlobProvider != null)
                {
                    _transmissionStateManager.EnableBackOff(httpMessage.Response);
                    result = HttpPipelineHelper.HandleFailures(httpMessage, _fileBlobProvider);
                }
                else
                {
                    _transmissionStateManager.ResetConsecutiveErrors();
                    _transmissionStateManager.CloseTransmission();
                    AzureMonitorExporterEventSource.Log.WriteInformational("TransmissionSuccess", "Successfully transmitted a batch of telemetry Items.");
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToTransmit", ex);
            }

            return result;
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
                    if (fileBlobProvider != null)
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
