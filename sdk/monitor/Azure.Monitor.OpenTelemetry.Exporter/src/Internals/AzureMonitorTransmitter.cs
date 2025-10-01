// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;
using OpenTelemetry.PersistentStorage.FileSystem;

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
        private readonly bool _isAadEnabled;
        private bool _disposed;

        public AzureMonitorTransmitter(AzureMonitorExporterOptions options, IPlatform platform)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Retry.MaxRetries = 0;

            _connectionVars = InitializeConnectionVars(options, platform);

            _transmissionStateManager = new TransmissionStateManager();

            _applicationInsightsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            _fileBlobProvider = InitializeOfflineStorage(platform, _connectionVars, options.DisableOfflineStorage, options.StorageDirectory);

            if (_fileBlobProvider != null)
            {
                _transmitFromStorageHandler = new TransmitFromStorageHandler(_applicationInsightsRestClient, _fileBlobProvider, _transmissionStateManager, _connectionVars, _isAadEnabled);
            }

            _statsbeat = InitializeStatsbeat(options, _connectionVars, platform);
        }

        internal static ConnectionVars InitializeConnectionVars(AzureMonitorExporterOptions options, IPlatform platform)
        {
            if (options.ConnectionString == null)
            {
                var connectionString = platform.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING);

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return ConnectionStringParser.GetValues(connectionString!);
                }
            }
            else
            {
                return ConnectionStringParser.GetValues(options.ConnectionString);
            }

            throw new InvalidOperationException("A connection string was not found. Please set your connection string.");
        }

        private static ApplicationInsightsRestClient InitializeRestClient(AzureMonitorExporterOptions options, ConnectionVars connectionVars, out bool isAadEnabled)
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

                isAadEnabled = true;
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                AzureMonitorExporterEventSource.Log.SetAADCredentialsToPipeline(options.Credential.GetType().Name, scope);
            }
            else
            {
                isAadEnabled = false;
                var httpPipelinePolicy = new HttpPipelinePolicy[] { new IngestionRedirectPolicy() };
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
            }

            return new ApplicationInsightsRestClient(new ClientDiagnostics(options), pipeline, host: connectionVars.IngestionEndpoint);
        }

        private static PersistentBlobProvider? InitializeOfflineStorage(IPlatform platform, ConnectionVars connectionVars, bool disableOfflineStorage, string? configuredStorageDirectory)
        {
            if (!disableOfflineStorage)
            {
                try
                {
                    var storageDirectory = StorageHelper.GetStorageDirectory(
                        platform: platform,
                        configuredStorageDirectory: configuredStorageDirectory,
                        instrumentationKey: connectionVars.InstrumentationKey);

                    AzureMonitorExporterEventSource.Log.InitializedPersistentStorage(connectionVars.InstrumentationKey, storageDirectory);

                    return new FileBlobProvider(storageDirectory);
                }
                catch (Exception ex)
                {
                    // TODO: Should we throw if customer has opted for storage?
                    AzureMonitorExporterEventSource.Log.FailedToInitializePersistentStorage(connectionVars.InstrumentationKey, ex);

                    return null;
                }
            }

            return null;
        }

        private static AzureMonitorStatsbeat? InitializeStatsbeat(AzureMonitorExporterOptions options, ConnectionVars connectionVars, IPlatform platform)
        {
            if (options.EnableStatsbeat && connectionVars != null)
            {
                try
                {
                    var disableStatsbeat = platform.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATSBEAT_DISABLED);
                    if (string.Equals(disableStatsbeat, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        AzureMonitorExporterEventSource.Log.StatsbeatDisabled();

                        return null;
                    }

                    return new AzureMonitorStatsbeat(connectionVars, platform);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.ErrorInitializingStatsbeat(connectionVars, ex);
                }
            }

            return null;
        }

        public string InstrumentationKey => _connectionVars.InstrumentationKey;

        public async ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
        {
            ExportResult result = ExportResult.Failure;
            if (cancellationToken.IsCancellationRequested)
            {
                return result;
            }

            try
            {
                if (_transmissionStateManager.State == TransmissionState.Closed)
                {
                    using var httpMessage = async ?
                    await _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false) :
                    _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).Result;

                    result = HttpPipelineHelper.IsSuccess(httpMessage);

                    if (result == ExportResult.Failure && _fileBlobProvider != null)
                    {
                        _transmissionStateManager.EnableBackOff(httpMessage.HasResponse ? httpMessage.Response : null);
                        var transmissionResult = HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _fileBlobProvider, null, _connectionVars, origin, _isAadEnabled);
                        result = transmissionResult.ExportResult;
                    }
                    else
                    {
                        _transmissionStateManager.ResetConsecutiveErrors();
                        _transmissionStateManager.CloseTransmission();
                        AzureMonitorExporterEventSource.Log.TransmissionSuccess(origin, _isAadEnabled, _connectionVars.InstrumentationKey);
                    }
                }
                else
                {
                    byte[] requestContent = HttpPipelineHelper.GetSerializedContent(telemetryItems);
                    if (_fileBlobProvider != null)
                    {
                        result = _fileBlobProvider.SaveTelemetry(requestContent);
                    }
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.TransmitterFailed(origin, _isAadEnabled, _connectionVars.InstrumentationKey, ex);
            }

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorTransmitter));
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
