// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using OpenTelemetry.PersistentStorage.Abstractions;
using OpenTelemetry.PersistentStorage.FileSystem;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant
{
    /// <summary>
    /// Offline storage and back-off state, partitioned by ingestion endpoint. The directory is derived
    /// from the endpoint, not the other way round, so a partition is only reopened when that endpoint
    /// is routed again. The instrumentation key is not part of the path because it already travels
    /// inside each serialized envelope.
    /// </summary>
    internal sealed class MultiTenantStorage : IDisposable
    {
        /// <summary>
        /// Appended to the host's storage directory to form a sibling root. Partitions must not be
        /// nested inside it: <c>DirectorySizeTracker</c> sums subdirectories recursively, so a tenant
        /// backlog would consume the host's own storage quota while its top-level capacity probe
        /// still reported the directory as empty.
        /// </summary>
        internal const string RootDirectorySuffix = ".tenants";

        /// <summary>
        /// Bounds the number of endpoint partitions, each of which owns a directory, a drain timer,
        /// and a blob provider. A caller routing past this loses persistence for the excess
        /// endpoints rather than growing without limit.
        /// </summary>
        internal const int MaxEndpointPartitions = 64;

        private readonly ConcurrentDictionary<string, EndpointStorage> _partitions = new(StringComparer.Ordinal);
        private readonly ApplicationInsightsRestClient _restClient;
        private readonly ConnectionVars _connectionVars;
        private readonly NetworkSdkStatsManager? _networkSdkStatsManager;
        private readonly string _rootDirectory;
        private readonly long _maxSizeBytes;
        private readonly bool _isAadEnabled;
        private readonly object _createLock = new();
        private bool _disposed;

        internal MultiTenantStorage(
            ApplicationInsightsRestClient restClient,
            ConnectionVars connectionVars,
            bool isAadEnabled,
            string rootDirectory,
            long maxSizeBytes,
            NetworkSdkStatsManager? networkSdkStatsManager)
        {
            _restClient = restClient;
            _connectionVars = connectionVars;
            _isAadEnabled = isAadEnabled;
            _rootDirectory = rootDirectory;
            _maxSizeBytes = maxSizeBytes;
            _networkSdkStatsManager = networkSdkStatsManager;
        }

        internal IEnumerable<EndpointStorage> Partitions => _partitions.Values;

        /// <summary>
        /// Returns the partition for an endpoint, creating it on first use. Returns
        /// <see langword="null"/> when the partition cannot be created, in which case the caller
        /// transmits without a persistence fallback.
        /// </summary>
        internal EndpointStorage? TryGet(string ingestionEndpoint)
        {
            if (_partitions.TryGetValue(ingestionEndpoint, out var existing))
            {
                return existing;
            }

            if (_disposed)
            {
                return null;
            }

            lock (_createLock)
            {
                if (_partitions.TryGetValue(ingestionEndpoint, out existing))
                {
                    return existing;
                }

                if (_disposed || _partitions.Count >= MaxEndpointPartitions)
                {
                    return null;
                }

                try
                {
                    var directory = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash(ingestionEndpoint));
                    var blobProvider = new FileBlobProvider(directory, maxSizeInBytes: _maxSizeBytes);
                    var trackUri = ApplicationInsightsRestClient.CreateTrackUri(ingestionEndpoint);
                    var transmissionStateManager = new TransmissionStateManager();

                    var created = new EndpointStorage(
                        directory,
                        blobProvider,
                        transmissionStateManager,
                        new TransmitFromStorageHandler(_restClient, blobProvider, transmissionStateManager, _connectionVars, _isAadEnabled, _networkSdkStatsManager, directory, trackUri));

                    _partitions[ingestionEndpoint] = created;

                    AzureMonitorExporterEventSource.Log.InitializedPersistentStorage(_connectionVars.InstrumentationKey, directory);

                    return created;
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToInitializePersistentStorage(_connectionVars.InstrumentationKey, ex);

                    return null;
                }
            }
        }

        public void Dispose()
        {
            lock (_createLock)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;
            }

            foreach (var partition in _partitions.Values)
            {
                partition.Dispose();
            }

            _partitions.Clear();
        }

        internal sealed class EndpointStorage : IDisposable
        {
            internal EndpointStorage(
                string directory,
                PersistentBlobProvider blobProvider,
                TransmissionStateManager transmissionStateManager,
                TransmitFromStorageHandler transmitFromStorageHandler)
            {
                Directory = directory;
                BlobProvider = blobProvider;
                TransmissionStateManager = transmissionStateManager;
                TransmitFromStorageHandler = transmitFromStorageHandler;
            }

            internal string Directory { get; }

            internal PersistentBlobProvider BlobProvider { get; }

            internal TransmissionStateManager TransmissionStateManager { get; }

            internal TransmitFromStorageHandler TransmitFromStorageHandler { get; }

            public void Dispose()
            {
                TransmitFromStorageHandler.Dispose();
                TransmissionStateManager.Dispose();
                (BlobProvider as FileBlobProvider)?.Dispose();
            }
        }
    }
}
