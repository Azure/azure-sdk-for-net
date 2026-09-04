// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using OpenTelemetry;
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

        /// <summary>
        /// One budget for every tenant combined, not per endpoint. A per-folder cap would multiply
        /// by the partition count and put the process's disk footprint at the mercy of how many
        /// regions it happens to route to.
        /// </summary>
        internal const long TotalStorageMaxSizeBytes = 104857600;

        /// <summary>
        /// How many blobs one write may consider evicting. Sized well above the largest batch the
        /// drain will re-persist, so a legitimate write is not refused for want of candidates.
        /// </summary>
        private const int MaxBlobsToEvict = 256;

        /// <summary>
        /// How stale the running size may get before it is re-derived from disk. Throttled for the
        /// whole store rather than per endpoint, so a fan-out across failing endpoints costs one
        /// walk instead of one each.
        /// </summary>
        private const long RecountIntervalMilliseconds = 30000;

        private readonly ConcurrentDictionary<string, EndpointStorage> _partitions = new(StringComparer.Ordinal);
        private readonly ApplicationInsightsRestClient _restClient;
        private readonly ConnectionVars _connectionVars;
        private readonly NetworkSdkStatsManager? _networkSdkStatsManager;
        private readonly string _rootDirectory;
        private readonly long _maxSizeBytes;
        private readonly bool _isAadEnabled;
        private readonly object _createLock = new();
        private readonly object _evictLock = new();
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private long _currentSizeBytes;
        private long _lastRecountMilliseconds;
        private volatile bool _disposed;

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

            // A failure here only means the running total starts low; writes add to it and the next
            // successful recount corrects it.
            _currentSizeBytes = TryCalculateRootSize(out var size) ? size : 0;
        }

        internal IEnumerable<EndpointStorage> Partitions => _partitions.Values;

        internal ExportResult SaveTelemetry(EndpointStorage storage, byte[] content)
            => storage.BlobProvider.SaveTelemetry(content);

        /// <summary>
        /// Writes to the endpoint's partition, evicting oldest-first across every partition when the
        /// write does not fit.
        /// </summary>
        /// <remarks>
        /// Eviction only runs when the shared budget is what is in the way, and only after the
        /// candidates have been shown to cover the shortfall. A write can also fail for reasons
        /// eviction cannot help with - a removed directory, a full disk, a denied ACL - and deleting
        /// the backlog for those destroys other tenants' telemetry without saving this batch.
        /// </remarks>
        internal bool TryCreateBlobWithinBudget(FileBlobProvider inner, byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob? blob)
        {
            blob = null;

            // No amount of eviction makes room for a payload larger than the whole budget.
            if (buffer.Length > _maxSizeBytes)
            {
                return false;
            }

            RecountIfStale();

            if (TryReserve(buffer.Length))
            {
                return TryCreateBlob(inner, buffer, leasePeriodMilliseconds, out blob);
            }

            var reserved = false;

            // Serialized: two writers selecting the same blob would both measure it, both see their
            // delete succeed - File.Delete does not fail on a file that is already gone - and both
            // credit its bytes back, leaving the total below what is actually on disk.
            lock (_evictLock)
            {
                // Inside the lock: computed outside, another writer could take the room this
                // measured, leaving the eviction below paid for and the write still refused.
                var shortfall = Interlocked.Read(ref _currentSizeBytes) + buffer.Length - _maxSizeBytes;
                var candidates = SelectOldest(MaxBlobsToEvict);

                long evictable = 0;
                for (int i = 0; i < candidates.Count; i++)
                {
                    evictable += FileLength(candidates[i].Path);
                }

                // Deleting everything on offer would still leave the write refused, so delete nothing.
                if (evictable < shortfall)
                {
                    return false;
                }

                for (int i = 0; i < candidates.Count && !reserved; i++)
                {
                    TryEvict(candidates[i]);
                    reserved = TryReserve(buffer.Length);
                }
            }

            // Outside the lock: the write is the slow part, and holding it here would serialize
            // every partition's failure path behind one disk write.
            return reserved && TryCreateBlob(inner, buffer, leasePeriodMilliseconds, out blob);
        }

        /// <summary>
        /// Claims the bytes before the write, so two callers cannot both see the same room and take
        /// it. Checking and then incrementing separately let concurrent exports exceed the shared
        /// budget by one payload each.
        /// </summary>
        private bool TryReserve(long length)
        {
            while (true)
            {
                var current = Interlocked.Read(ref _currentSizeBytes);

                if (current + length > _maxSizeBytes)
                {
                    return false;
                }

                if (Interlocked.CompareExchange(ref _currentSizeBytes, current + length, current) == current)
                {
                    return true;
                }
            }
        }

        private bool TryCreateBlob(FileBlobProvider inner, byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob? blob)
        {
            var created = leasePeriodMilliseconds > 0
                ? inner.TryCreateBlob(buffer, leasePeriodMilliseconds, out blob)
                : inner.TryCreateBlob(buffer, out blob);

            if (!created)
            {
                // Give the reservation back; nothing was written.
                Interlocked.Add(ref _currentSizeBytes, -buffer.Length);
            }

            return created;
        }

        /// <summary>
        /// Re-derives the running total from disk at most once per <see cref="RecountIntervalMilliseconds"/>.
        /// </summary>
        /// <remarks>
        /// The total drifts between recounts: retention deletes bypass it, drains remove blobs, and
        /// another process may share the root. That is the same tolerance <c>DirectorySizeTracker</c>
        /// documents for itself - a false positive costs one refused write that is retried, a false
        /// negative costs one blob of overshoot. Re-deriving is what keeps the drift bounded, and it
        /// is why a failed measurement is no longer a permanent bypass of the cap.
        /// </remarks>
        private void RecountIfStale()
        {
            var now = _clock.ElapsedMilliseconds;
            var last = Interlocked.Read(ref _lastRecountMilliseconds);

            if (now - last < RecountIntervalMilliseconds)
            {
                return;
            }

            if (Interlocked.CompareExchange(ref _lastRecountMilliseconds, now, last) != last)
            {
                return;
            }

            if (TryCalculateRootSize(out var size))
            {
                // Sampled after the walk, not before: a write that landed while the walk was running
                // has already added itself to the total, and the walk may have counted it as well.
                // Correcting against the later sample errs towards a brief overshoot rather than
                // towards evicting telemetry that is still wanted.
                var current = Interlocked.Read(ref _currentSizeBytes);

                Interlocked.Add(ref _currentSizeBytes, size - current);
            }
        }

        private bool TryCalculateRootSize(out long size)
        {
            size = 0;

            try
            {
                if (!Directory.Exists(_rootDirectory))
                {
                    return true;
                }

                // Only blobs: a leased or half-written file is named .lock or .tmp, which eviction
                // cannot select. Counting bytes that cannot be reclaimed is what let a restart pin
                // the budget at zero headroom.
                foreach (var file in Directory.EnumerateFiles(_rootDirectory, "*.blob", SearchOption.AllDirectories))
                {
                    size += new FileInfo(file).Length;
                }

                return true;
            }
            catch (Exception)
            {
                // Keep whatever total we already had rather than replacing it with a guess.
                return false;
            }
        }

        private static long FileLength(string path)
        {
            try
            {
                var info = new FileInfo(path);

                return info.Exists ? info.Length : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// The globally oldest blobs across the whole root, in ascending age order.
        /// </summary>
        /// <remarks>
        /// Blob names are timestamp-prefixed and sort lexicographically, so oldest-first is a
        /// comparison on the file name and works across directories. Oldest-first is the half of an
        /// existing policy that was never implemented: the drain sends newest-first, which leaves the
        /// tail of a backlog to be reclaimed here or by the ingestion age limit.
        /// <para/>
        /// Directories with no open partition are included. Restricting eviction to partitions routed
        /// in this process meant a restart could leave the root over budget with nothing it was
        /// allowed to delete, so it deleted the telemetry the current run had just written instead.
        /// Those directories have no provider and therefore no size tracker to desynchronize, which
        /// is why deleting the file directly is correct for them and not for the rest.
        /// </remarks>
        private List<EvictionCandidate> SelectOldest(int count)
        {
            var candidates = new List<EvictionCandidate>(count);
            var openDirectoryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var partition in _partitions.Values)
            {
                openDirectoryNames.Add(Path.GetFileName(partition.Directory));

                try
                {
                    foreach (var blob in partition.Inner.GetBlobs())
                    {
                        if (blob is FileBlob fileBlob)
                        {
                            Offer(candidates, count, new EvictionCandidate(Path.GetFileName(fileBlob.FullPath), fileBlob, fileBlob.FullPath));
                        }
                    }
                }
                catch (Exception)
                {
                    // Selection is best effort; a partition that cannot be enumerated is skipped and
                    // the shortfall check below decides whether the write can proceed.
                }
            }

            try
            {
                if (Directory.Exists(_rootDirectory))
                {
                    foreach (var directory in Directory.EnumerateDirectories(_rootDirectory))
                    {
                        if (openDirectoryNames.Contains(Path.GetFileName(directory)))
                        {
                            continue;
                        }

                        foreach (var file in Directory.EnumerateFiles(directory, "*.blob", SearchOption.AllDirectories))
                        {
                            Offer(candidates, count, new EvictionCandidate(Path.GetFileName(file), blob: null, file));
                        }
                    }
                }
            }
            catch (Exception)
            {
                // As above: an unreadable root yields fewer candidates, not a forced eviction.
            }

            return candidates;
        }

        /// <summary>
        /// Keeps the list to the oldest <paramref name="count"/> entries, ascending. Bounded so a
        /// full root does not materialize thousands of entries to discard all but a few.
        /// </summary>
        private static void Offer(List<EvictionCandidate> candidates, int count, EvictionCandidate candidate)
        {
            if (candidates.Count == count && string.CompareOrdinal(candidate.Name, candidates[count - 1].Name) >= 0)
            {
                return;
            }

            var index = candidates.Count;
            while (index > 0 && string.CompareOrdinal(candidate.Name, candidates[index - 1].Name) < 0)
            {
                index--;
            }

            candidates.Insert(index, candidate);

            if (candidates.Count > count)
            {
                candidates.RemoveAt(candidates.Count - 1);
            }
        }

        private bool TryEvict(EvictionCandidate candidate)
        {
            // Measured before deletion because the length is unreadable afterwards.
            var length = FileLength(candidate.Path);

            if (candidate.Blob != null)
            {
                // Goes through the blob so the owning provider's size tracker is decremented too.
                if (!candidate.Blob.TryDelete())
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    File.Delete(candidate.Path);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            Interlocked.Add(ref _currentSizeBytes, -length);

            return true;
        }

        private readonly struct EvictionCandidate
        {
            internal EvictionCandidate(string name, PersistentBlob? blob, string path)
            {
                Name = name;
                Blob = blob;
                Path = path;
            }

            /// <summary>File name only: the timestamp prefix orders blobs across directories.</summary>
            internal string Name { get; }

            /// <summary>Set only when an open partition owns the blob.</summary>
            internal PersistentBlob? Blob { get; }

            internal string Path { get; }
        }

        /// <summary>
        /// Returns the partition for an endpoint, creating it on first use. Returns
        /// <see langword="null"/> when the partition cannot be created, in which case the caller
        /// transmits without a persistence fallback.
        /// </summary>
        internal EndpointStorage? TryGet(string ingestionEndpoint)
        {
            // Checked first: Dispose empties the dictionary before tearing partitions down, so a
            // hit after this point cannot be on one that is already disposed.
            if (_disposed)
            {
                return null;
            }

            if (_partitions.TryGetValue(ingestionEndpoint, out var existing))
            {
                return existing;
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

                    // A backstop only. The shared budget is enforced by BudgetedBlobProvider, which is
                    // the only handle handed out, because this cap cannot see across partitions.
                    var innerProvider = new FileBlobProvider(directory, maxSizeInBytes: _maxSizeBytes);
                    var blobProvider = new BudgetedBlobProvider(this, innerProvider, ingestionEndpoint);
                    var trackUri = ApplicationInsightsRestClient.CreateTrackUri(ingestionEndpoint);
                    var transmissionStateManager = new TransmissionStateManager(ingestionEndpoint);

                    var created = new EndpointStorage(
                        directory,
                        innerProvider,
                        blobProvider,
                        transmissionStateManager,
                        new TransmitFromStorageHandler(_restClient, blobProvider, transmissionStateManager, _connectionVars, _isAadEnabled, _networkSdkStatsManager, directory, trackUri));

                    _partitions[ingestionEndpoint] = created;

                    AzureMonitorExporterEventSource.Log.InitializedPersistentStorage(_connectionVars.InstrumentationKey, directory);

                    // The directory is a one-way hash, so without this there is no way to tell which
                    // endpoint a partition on disk belongs to.
                    AzureMonitorExporterEventSource.Log.MultiTenantPartitionCreated(ingestionEndpoint, directory);

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
            EndpointStorage[] partitions;

            lock (_createLock)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;

                // Removed before being disposed, so a concurrent caller cannot be handed one.
                partitions = new List<EndpointStorage>(_partitions.Values).ToArray();
                _partitions.Clear();
            }

            foreach (var partition in partitions)
            {
                partition.Dispose();
            }
        }

        internal sealed class EndpointStorage : IDisposable
        {
            internal EndpointStorage(
                string directory,
                FileBlobProvider inner,
                PersistentBlobProvider blobProvider,
                TransmissionStateManager transmissionStateManager,
                TransmitFromStorageHandler transmitFromStorageHandler)
            {
                Directory = directory;
                Inner = inner;
                BlobProvider = blobProvider;
                TransmissionStateManager = transmissionStateManager;
                TransmitFromStorageHandler = transmitFromStorageHandler;
            }

            internal string Directory { get; }

            /// <summary>Eviction only, so that deletes reach the provider's own size tracker.</summary>
            internal FileBlobProvider Inner { get; }

            internal PersistentBlobProvider BlobProvider { get; }

            internal TransmissionStateManager TransmissionStateManager { get; }

            internal TransmitFromStorageHandler TransmitFromStorageHandler { get; }

            public void Dispose()
            {
                TransmitFromStorageHandler.Dispose();
                TransmissionStateManager.Dispose();
                Inner.Dispose();
            }
        }
    }
}
