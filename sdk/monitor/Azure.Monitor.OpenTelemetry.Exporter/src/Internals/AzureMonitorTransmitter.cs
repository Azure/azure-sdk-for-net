// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
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
        private const long StorageMaxSizeBytes = 52428800;

        internal readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        internal PersistentBlobProvider? _fileBlobProvider;
        internal readonly AzureMonitorStatsbeat? _statsbeat;
        private readonly ConnectionVars _connectionVars;
        internal readonly TransmissionStateManager _transmissionStateManager;
        internal readonly TransmitFromStorageHandler? _transmitFromStorageHandler;
        private readonly bool _isAadEnabled;
        private readonly string? _storageDirectory;
        private readonly object _drainLock = new();
        private int _referenceCount;
        private int _persistOnlyScopeCount;
        private Task? _inFlightDrain;
        private Stopwatch? _drainStarted;
        private int _drainWaitMilliseconds;
        internal bool _disposed;

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

            _fileBlobProvider = InitializeOfflineStorage(platform, _connectionVars, options.DisableOfflineStorage, options.StorageDirectory, out var storageDirectory);

            _storageDirectory = storageDirectory;

            _statsbeat = InitializeStatsbeat(options, _connectionVars, platform);

            if (_fileBlobProvider != null)
            {
                _transmitFromStorageHandler = new TransmitFromStorageHandler(_applicationInsightsRestClient, _fileBlobProvider, _transmissionStateManager, _connectionVars, _isAadEnabled, _statsbeat?.NetworkSdkStatsManager, storageDirectory);
            }
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

        private static PersistentBlobProvider? InitializeOfflineStorage(IPlatform platform, ConnectionVars connectionVars, bool disableOfflineStorage, string? configuredStorageDirectory, out string? storageDirectory)
        {
            storageDirectory = null;

            if (!disableOfflineStorage)
            {
                try
                {
                    storageDirectory = StorageHelper.GetStorageDirectory(
                        platform: platform,
                        configuredStorageDirectory: configuredStorageDirectory,
                        instrumentationKey: connectionVars.InstrumentationKey);

                    AzureMonitorExporterEventSource.Log.InitializedPersistentStorage(connectionVars.InstrumentationKey, storageDirectory);

                    return new FileBlobProvider(storageDirectory, maxSizeInBytes: StorageMaxSizeBytes);
                }
                catch (Exception ex)
                {
                    // TODO: Should we throw if customer has opted for storage?
                    AzureMonitorExporterEventSource.Log.FailedToInitializePersistentStorage(connectionVars.InstrumentationKey, ex);

                    storageDirectory = null;
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

                    var disableAllSdkStats = platform.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_SDKSTATS_DISABLED_ALL);
                    if (string.Equals(disableAllSdkStats, "true", StringComparison.OrdinalIgnoreCase))
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

        internal bool IsPersistOnly => Volatile.Read(ref _persistOnlyScopeCount) > 0;

        internal Task? InFlightDrain => _inFlightDrain;

        public IDisposable BeginPersistOnlyScope() => new PersistOnlyScope(this);

        /// <summary>
        /// Records that another exporter shares this instance. Balanced by <see cref="Dispose()"/>.
        /// </summary>
        internal void AddReference() => Interlocked.Increment(ref _referenceCount);

        public void DrainStorage(int waitMilliseconds)
        {
            var handler = _transmitFromStorageHandler;
            if (handler == null)
            {
                return;
            }

            Task drain;

            lock (_drainLock)
            {
                var existing = _inFlightDrain;
                if (existing != null && !existing.IsCompleted)
                {
                    // Each signal shuts down separately but shares this transmitter. Replacing a
                    // running drain with a fresh task would hand Dispose a no-op to wait on and let
                    // teardown proceed underneath the real one.
                    drain = existing;
                    waitMilliseconds = GetRemainingDrainWait();
                }
                else
                {
                    _drainWaitMilliseconds = waitMilliseconds;
                    _drainStarted = Stopwatch.StartNew();
                    drain = handler.DrainAsync();
                    _inFlightDrain = drain;
                }
            }

            WaitForDrain(drain, waitMilliseconds);
        }

        /// <summary>
        /// Whatever is left of the budget the caller already granted to <see cref="DrainStorage"/>,
        /// so that shutdown never spends it twice.
        /// </summary>
        private int GetRemainingDrainWait()
        {
            if (_drainStarted == null)
            {
                return 0;
            }

            var elapsed = _drainStarted.ElapsedMilliseconds;

            return elapsed >= _drainWaitMilliseconds ? 0 : (int)(_drainWaitMilliseconds - elapsed);
        }

        private static void WaitForDrain(Task drain, int waitMilliseconds)
        {
            if (waitMilliseconds <= 0)
            {
                return;
            }

            try
            {
                drain.Wait(waitMilliseconds);
            }
            catch (Exception)
            {
                // The drain reports its own failures, and anything it could not deliver is still
                // on disk for the next attempt.
            }
        }

        /// <summary>
        /// Writes telemetry to persistent storage instead of transmitting it. Used on the shutdown
        /// path, where an ingestion round trip would either block process exit or be killed by it.
        /// </summary>
        private ExportResult SaveForLaterTransmission(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, PersistentBlobProvider blobProvider)
        {
            try
            {
                var result = blobProvider.SaveTelemetryWithEviction(HttpPipelineHelper.GetSerializedContent(telemetryItems), _storageDirectory, StorageMaxSizeBytes);

                if (result == ExportResult.Success)
                {
                    CustomerSdkStatsHelper.TrackRetry(telemetrySchemaTypeCounter, (int)DropCode.ShutdownPersisted, null);
                }
                else
                {
                    CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, persistentBlobProviderExists: true);
                }

                return result;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToPersistOnShutdown(_connectionVars.InstrumentationKey, ex);
                CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, (int)DropCode.ClientException, CustomerSdkStatsHelper.GetDropReason(ex));

                return ExportResult.Failure;
            }
        }

        public async ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
        {
            ExportResult result = ExportResult.Failure;
            if (cancellationToken.IsCancellationRequested)
            {
                return result;
            }

            var blobProvider = _fileBlobProvider;
            if (IsPersistOnly && blobProvider != null)
            {
                return SaveForLaterTransmission(telemetryItems, telemetrySchemaTypeCounter, blobProvider);
            }

            // Without persistent storage the request itself is the durability, so it gets its own
            // budget rather than inheriting the pipeline's 100 second network timeout.
            using CancellationTokenSource? fallbackBudget = IsPersistOnly
                ? new CancellationTokenSource(PersistOnShutdownConfig.FallbackPostBudgetMilliseconds)
                : null;
            using CancellationTokenSource? linkedSource = fallbackBudget == null
                ? null
                : CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, fallbackBudget.Token);

            if (linkedSource != null)
            {
                cancellationToken = linkedSource.Token;
            }

            var networkSdkStats = _statsbeat?.NetworkSdkStatsManager;

            try
            {
                if (_transmissionStateManager.State == TransmissionState.Closed)
                {
                    var stopwatch = networkSdkStats != null ? System.Diagnostics.Stopwatch.StartNew() : null;

                    using var httpMessage = async ?
                    await _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).ConfigureAwait(false) :
                    _applicationInsightsRestClient.InternalTrackAsync(telemetryItems, cancellationToken).Result;

                    stopwatch?.Stop();

                    result = HttpPipelineHelper.IsSuccess(httpMessage, telemetrySchemaTypeCounter);

                    if (networkSdkStats != null)
                    {
                        var requestHost = httpMessage.Request.Uri.Host;

                        if (httpMessage.HasResponse)
                        {
                            // Request_Duration is recorded for every request that received a
                            // response, regardless of outcome.
                            networkSdkStats.TrackDuration(requestHost, stopwatch!.Elapsed.TotalMilliseconds);
                        }

                        if (result == ExportResult.Success)
                        {
                            // Record Network SDKStats Request_Success_Count for HTTP 200.
                            // request.Uri reflects any redirect followed by IngestionRedirectPolicy,
                            // so the host recorded matches the stamp that returned the response.
                            networkSdkStats.TrackSuccess(requestHost);
                        }
                        else if (httpMessage.HasResponse)
                        {
                            // Classify the top-level non-success response as retry / throttle /
                            // failure. 206 partial-success per-envelope handling happens in
                            // HttpPipelineHelper.HandlePartialSuccess.
                            networkSdkStats.TrackResponseFailure(requestHost, httpMessage.Response.Status);
                        }
                        else
                        {
                            // No response code received: count as an exception.
                            networkSdkStats.TrackException(requestHost, exceptionType: null);
                        }
                    }

                    if (result == ExportResult.Failure && _fileBlobProvider != null)
                    {
                        _transmissionStateManager.EnableBackOff(httpMessage.HasResponse ? httpMessage.Response : null);
                        var transmissionResult = HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _fileBlobProvider, null, _connectionVars, origin, _isAadEnabled, telemetrySchemaTypeCounter, networkSdkStats);
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
                        result = _fileBlobProvider.SaveTelemetryWithEviction(requestContent, _storageDirectory, StorageMaxSizeBytes);
                    }

                    if (result == ExportResult.Success)
                    {
                        CustomerSdkStatsHelper.TrackRetry(telemetrySchemaTypeCounter, (int)DropCode.BackOffEnabled, null);
                    }
                    else
                    {
                        CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, _fileBlobProvider != null);
                    }
                }
            }
            catch (Exception ex)
            {
                networkSdkStats?.TrackException(requestHost: null, exceptionType: ex.GetType().FullName);
                AzureMonitorExporterEventSource.Log.TransmitterFailed(origin, _isAadEnabled, _connectionVars.InstrumentationKey, ex);
                CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, (int)DropCode.ClientException, CustomerSdkStatsHelper.GetDropReason(ex));
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

                    // Give an in-flight drain whatever is left of the budget the caller allowed
                    // before the HTTP pipeline goes away. Whatever it does not finish stays on disk.
                    Task? drain;
                    int remaining;
                    lock (_drainLock)
                    {
                        drain = _inFlightDrain;
                        remaining = GetRemainingDrainWait();
                    }

                    if (drain != null)
                    {
                        WaitForDrain(drain, remaining);
                    }

                    _transmitFromStorageHandler?.Dispose();
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
            // Every exporter using the same connection string shares this instance, so tearing it
            // down when the first of them is disposed would stop storage draining for the rest.
            if (Interlocked.Decrement(ref _referenceCount) > 0)
            {
                return;
            }

            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private sealed class PersistOnlyScope : IDisposable
        {
            private AzureMonitorTransmitter? _owner;

            internal PersistOnlyScope(AzureMonitorTransmitter owner)
            {
                _owner = owner;
                Interlocked.Increment(ref owner._persistOnlyScopeCount);
            }

            public void Dispose()
            {
                var owner = Interlocked.Exchange(ref _owner, null);
                if (owner != null)
                {
                    Interlocked.Decrement(ref owner._persistOnlyScopeCount);
                }
            }
        }
    }
}
