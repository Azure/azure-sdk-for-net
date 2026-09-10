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

        /// <summary>
        /// The staleness allowed before refusing a write or evicting telemetry. Retention cleanup
        /// and other processes can remove blobs without updating this instance's running total.
        /// </summary>
        private const long EvictionRecountIntervalMilliseconds = 1000;

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
        private StorageAccounting _accounting = new(0, 0, 0, 0, false);
        private long _lastRecountMilliseconds;
        private int _recountInProgress;
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
            _accounting = new StorageAccounting(TryCalculateRootSize(out var size) ? size : 0, 0, 0, 0, false);
        }

        internal IEnumerable<EndpointStorage> Partitions => _partitions.Values;

        internal long CurrentSizeBytes => Volatile.Read(ref _accounting).TotalBytes;

        internal ExportResult SaveTelemetry(EndpointStorage storage, byte[] content)
            => storage.BlobProvider.SaveTelemetry(content);

        /// <summary>
        /// Requests reconciliation after successful drain deletions. An overlapping write keeps
        /// its reservation and retries reconciliation when it settles. Eviction cannot use a
        /// dirty snapshot. Recounting avoids double-crediting previously excluded leased blobs.
        /// </summary>
        internal void DeleteAndUpdateBudget(Func<bool> delete)
        {
            BeginDeletion();
            var deleted = false;
            try
            {
                deleted = delete();
            }
            finally
            {
                CompleteDeletion(0, deleted);
            }

            if (deleted)
            {
                TryRecount();
            }
        }

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

            RecountIfStale(RecountIntervalMilliseconds);

            if (TryReserve(buffer.Length))
            {
                return TryCreateBlob(inner, buffer, leasePeriodMilliseconds, out blob);
            }

            // Being over budget is the one moment the total has to be trusted, so re-derive it on a
            // much shorter leash before anything is refused or deleted on the strength of it.
            RecountIfStale(EvictionRecountIntervalMilliseconds);

            if (TryReserve(buffer.Length))
            {
                return TryCreateBlob(inner, buffer, leasePeriodMilliseconds, out blob);
            }

            return TryReserveWithEviction(buffer.Length) && TryCreateBlob(inner, buffer, leasePeriodMilliseconds, out blob);
        }

        private bool TryReserveWithEviction(long length)
        {
            for (var attempt = 0; attempt < 3; attempt++)
            {
                if (TryReserve(length))
                {
                    return true;
                }

                var before = Volatile.Read(ref _accounting);
                if (before.NeedsRecount || before.Deletions != 0)
                {
                    if (TryRecount())
                    {
                        continue;
                    }

                    if (ReferenceEquals(before, Volatile.Read(ref _accounting)) && !before.HasMutations)
                    {
                        return false;
                    }

                    continue;
                }

                // Serialized: two writers selecting the same blob would both measure it, both see their
                // delete succeed - File.Delete does not fail on a file that is already gone - and both
                // credit its bytes back, leaving the total below what is actually on disk.
                lock (_evictLock)
                {
                    if (TryReserve(length))
                    {
                        return true;
                    }

                    before = Volatile.Read(ref _accounting);
                    if (before.NeedsRecount || before.Deletions != 0)
                    {
                        continue;
                    }

                    // Inside the lock: computed outside, another writer could take the room this
                    // measured, leaving the eviction below paid for and the write still refused.
                    var shortfall = before.TotalBytes + length - _maxSizeBytes;
                    var candidates = SelectOldest(MaxBlobsToEvict);

                    long evictable = 0;
                    for (int i = 0; i < candidates.Count; i++)
                    {
                        evictable += FileLength(candidates[i].Path);
                    }

                    // Deleting everything on offer would still leave the write refused, so delete nothing.
                    if (evictable < shortfall)
                    {
                        if (!ReferenceEquals(before, Volatile.Read(ref _accounting)))
                        {
                            continue;
                        }

                        return false;
                    }

                    var reconcile = false;
                    for (int i = 0; i < candidates.Count; i++)
                    {
                        // Checked before each delete, not after: room may have appeared while this writer
                        // waited for the lock, and evicting first would spend a blob to discover that.
                        if (TryReserve(length))
                        {
                            return true;
                        }

                        TryEvict(candidates[i], length, out reconcile);
                        if (reconcile)
                        {
                            break;
                        }
                    }

                    if (!reconcile)
                    {
                        return TryReserve(length);
                    }
                }
            }

            return false;
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
                var current = Volatile.Read(ref _accounting);

                if (current.TotalBytes + length > _maxSizeBytes)
                {
                    return false;
                }

                var next = new StorageAccounting(current.DiskBytes, current.ReservedBytes + length,
                    current.Writers + 1, current.Deletions, current.NeedsRecount);
                if (ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, current), current))
                {
                    return true;
                }
            }
        }

        private bool TryCreateBlob(FileBlobProvider inner, byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob? blob)
        {
            var created = false;
            try
            {
                created = leasePeriodMilliseconds > 0
                    ? inner.TryCreateBlob(new ReadOnlySpan<byte>(buffer), leasePeriodMilliseconds, out blob)
                    : inner.TryCreateBlob(new ReadOnlySpan<byte>(buffer), out blob);
                return created;
            }
            finally
            {
                CompleteWrite(buffer.Length, created);
            }
        }

        private void CompleteWrite(long length, bool created)
        {
            while (true)
            {
                var current = Volatile.Read(ref _accounting);
                var next = new StorageAccounting(current.DiskBytes + (created ? length : 0), current.ReservedBytes - length,
                    current.Writers - 1, current.Deletions, current.NeedsRecount);
                if (ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, current), current))
                {
                    if (next.NeedsRecount && !next.HasMutations)
                    {
                        TryRecount();
                    }

                    return;
                }
            }
        }

        private void BeginDeletion()
        {
            while (true)
            {
                var current = Volatile.Read(ref _accounting);
                var next = new StorageAccounting(current.DiskBytes, current.ReservedBytes, current.Writers,
                    current.Deletions + 1, current.NeedsRecount);
                if (ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, current), current))
                {
                    return;
                }
            }
        }

        private void CompleteDeletion(long evictedBytes, bool needsRecount)
        {
            while (true)
            {
                var current = Volatile.Read(ref _accounting);
                var next = new StorageAccounting(current.DiskBytes - evictedBytes, current.ReservedBytes, current.Writers,
                    current.Deletions - 1, current.NeedsRecount || needsRecount);
                if (ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, current), current))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Re-derives the running total from disk at most once per <see cref="RecountIntervalMilliseconds"/>.
        /// </summary>
        /// <remarks>
        /// The total drifts between recounts: retention deletes bypass it, and
        /// another process may share the root. That is the same tolerance <c>DirectorySizeTracker</c>
        /// documents for itself - a false positive costs one refused write that is retried, a false
        /// negative costs one blob of overshoot. Re-deriving is what keeps the drift bounded, and it
        /// is why a failed measurement is no longer a permanent bypass of the cap.
        /// </remarks>
        private void RecountIfStale(long maxAgeMilliseconds)
        {
            var now = _clock.ElapsedMilliseconds;
            var last = Interlocked.Read(ref _lastRecountMilliseconds);

            if (now - last < maxAgeMilliseconds)
            {
                return;
            }

            if (Interlocked.CompareExchange(ref _lastRecountMilliseconds, now, last) != last)
            {
                return;
            }

            TryRecount();
        }

        /// <summary>
        /// Publishes a disk measurement only if no tracked mutation overlaps the scan. Optional
        /// file enumeration lets tests pause a scan without changing production timing.
        /// </summary>
        internal bool TryRecount(IEnumerable<string>? files = null)
        {
            if (Interlocked.CompareExchange(ref _recountInProgress, 1, 0) != 0)
            {
                return false;
            }

            try
            {
                return TryRecountCore(files);
            }
            finally
            {
                Volatile.Write(ref _recountInProgress, 0);
            }
        }

        private bool TryRecountCore(IEnumerable<string>? files)
        {
            var snapshot = Volatile.Read(ref _accounting);
            if (snapshot.HasMutations)
            {
                return false;
            }

            long size;
            if (!(files == null ? TryCalculateRootSize(out size) : TryCalculateSize(files, out size)))
            {
                return false;
            }

            var next = new StorageAccounting(size, 0, 0, 0, false);
            if (!ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, snapshot), snapshot))
            {
                return false;
            }

            Interlocked.Exchange(ref _lastRecountMilliseconds, _clock.ElapsedMilliseconds);
            return true;
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

                return TryCalculateSize(Directory.EnumerateFiles(_rootDirectory, "*.blob", SearchOption.AllDirectories), out size);
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static bool TryCalculateSize(IEnumerable<string> files, out long size)
        {
            size = 0;

            try
            {
                // Only blobs: a leased or half-written file is named .lock or .tmp, which eviction
                // cannot select. Counting bytes that cannot be reclaimed is what let a restart pin
                // the budget at zero headroom.
                foreach (var file in files)
                {
                    try
                    {
                        size += new FileInfo(file).Length;
                    }
                    catch (FileNotFoundException)
                    {
                    }
                    catch (DirectoryNotFoundException)
                    {
                    }
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

        private bool TryBeginEviction(long requestedBytes)
        {
            while (true)
            {
                var current = Volatile.Read(ref _accounting);
                if (current.NeedsRecount || current.Deletions != 0 || current.TotalBytes + requestedBytes <= _maxSizeBytes)
                {
                    return false;
                }

                var next = new StorageAccounting(current.DiskBytes, current.ReservedBytes, current.Writers,
                    current.Deletions + 1, current.NeedsRecount);
                if (ReferenceEquals(Interlocked.CompareExchange(ref _accounting, next, current), current))
                {
                    return true;
                }
            }
        }

        private bool TryEvict(EvictionCandidate candidate, long requestedBytes, out bool reconcile)
        {
            reconcile = !TryBeginEviction(requestedBytes);
            if (reconcile)
            {
                return false;
            }

            long deletedBytes = 0;
            try
            {
                return TryEvictCore(candidate, out deletedBytes);
            }
            finally
            {
                CompleteDeletion(deletedBytes, false);
            }
        }

        private static bool TryEvictCore(EvictionCandidate candidate, out long deletedBytes)
        {
            deletedBytes = 0;
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

            deletedBytes = length;

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
        /// Each transition publishes a new identity, including successful writes whose total charge
        /// is unchanged. A recount CAS therefore detects completed mutations as well as active ones.
        /// </summary>
        private sealed class StorageAccounting
        {
            internal StorageAccounting(long diskBytes, long reservedBytes, int writers, int deletions, bool needsRecount)
            {
                DiskBytes = diskBytes;
                ReservedBytes = reservedBytes;
                Writers = writers;
                Deletions = deletions;
                NeedsRecount = needsRecount;
            }

            internal long DiskBytes { get; }

            internal long ReservedBytes { get; }

            internal int Writers { get; }

            internal int Deletions { get; }

            internal bool NeedsRecount { get; }

            internal bool HasMutations => Writers != 0 || Deletions != 0;

            internal long TotalBytes => DiskBytes + ReservedBytes;
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
