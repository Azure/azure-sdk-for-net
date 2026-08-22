// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmitFromStorageHandler : IDisposable
    {
        private const int TimerIntervalMilliseconds = 120000;

        /// <summary>
        /// Must exceed the time a single transmission can take, otherwise another process reclaims
        /// the lease mid-upload and duplicate telemetry becomes routine rather than rare.
        /// </summary>
        internal const int LeasePeriodMilliseconds = 180000;
        /// <summary>
        /// Caps a single drain request. Without it a hung endpoint holds the drain for the pipeline's
        /// network timeout, blocking later passes, and would erode the margin over the lease period.
        /// </summary>
        internal const int DrainPostBudgetMilliseconds = 30000;

        /// <summary>
        /// Only yields to application startup. Kept small so a process that exits in a few hundred
        /// milliseconds still gets the drain underway.
        /// </summary>
        internal const int EagerDrainDelayMilliseconds = 50;

        private const int MaxBlobsPerBatch = 50;

        private const int MaxBatchBytes = 2 * 1024 * 1024;

        private const int MaxDrainMilliseconds = 30000;

        private const string LeaseTimestampFormat = "yyyy-MM-ddTHHmmss.fffffffZ";

        /// <summary>
        /// Set by tests that assert on storage contents and cannot tolerate a background drain.
        /// </summary>
        internal static bool DisableEagerDrainForTesting;

        /// <summary>
        /// Set by tests that assert on what shutdown persisted. Shutdown starts the drain without
        /// waiting for it, so it would otherwise be free to lease and delete those blobs while the
        /// assertions run.
        /// </summary>
        internal static bool DisableShutdownDrainForTesting;

        private readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        private readonly ConnectionVars _connectionVars;
        internal PersistentBlobProvider _blobProvider;
        private readonly TransmissionStateManager _transmissionStateManager;
        private readonly System.Timers.Timer _transmitFromStorageTimer;
        private readonly bool _isAadEnabled;
        private readonly NetworkSdkStatsManager? _networkSdkStatsManager;
        private readonly string? _storageDirectory;
        private int _drainInProgress;
        private bool _disposed;

        internal TransmitFromStorageHandler(ApplicationInsightsRestClient applicationInsightsRestClient, PersistentBlobProvider blobProvider, TransmissionStateManager transmissionStateManager, ConnectionVars connectionVars, bool isAadEnabled, NetworkSdkStatsManager? networkSdkStatsManager = null, string? storageDirectory = null)
        {
            _applicationInsightsRestClient = applicationInsightsRestClient;
            _connectionVars = connectionVars;
            _isAadEnabled = isAadEnabled;
            _blobProvider = blobProvider;
            _transmissionStateManager = transmissionStateManager;
            _networkSdkStatsManager = networkSdkStatsManager;
            _storageDirectory = storageDirectory;
            _transmitFromStorageTimer = new System.Timers.Timer();
            _transmitFromStorageTimer.Elapsed += TransmitFromStorage;
            _transmitFromStorageTimer.AutoReset = true;
            _transmitFromStorageTimer.Interval = TimerIntervalMilliseconds;
            _transmitFromStorageTimer.Start();

            ScheduleEagerDrain();
        }

        /// <summary>
        /// Short-lived processes exit long before the first timer tick, so telemetry left behind by
        /// previous runs is uploaded near startup instead. Concurrent invocations sharing a storage
        /// directory are separated by blob leases, not by staggering this.
        /// </summary>
        private void ScheduleEagerDrain()
        {
            if (DisableEagerDrainForTesting)
            {
                return;
            }

            _ = Task.Run(async () =>
            {
                await Task.Delay(EagerDrainDelayMilliseconds).ConfigureAwait(false);
                Drain();
            });
        }

        internal void TransmitFromStorage(object? sender, ElapsedEventArgs? e) => Drain();

        internal Task DrainAsync() => DisableShutdownDrainForTesting ? Task.CompletedTask : Task.Run(Drain);

        internal void Drain()
        {
            if (Interlocked.CompareExchange(ref _drainInProgress, 1, 0) != 0)
            {
                return;
            }

            try
            {
                ReclaimExpiredLeases();
                DrainBlobs();
            }
            catch (ObjectDisposedException)
            {
                // Expected: the process began tearing down the pipeline while this drain was in
                // flight. Nothing is lost, the blobs are still on disk.
            }
            catch (Exception ex)
            {
                _networkSdkStatsManager?.TrackException(requestHost: null, exceptionType: ex.GetType().FullName);
                AzureMonitorExporterEventSource.Log.FailedToTransmitFromStorage(_isAadEnabled, _connectionVars.InstrumentationKey, ex);
            }
            finally
            {
                Interlocked.Exchange(ref _drainInProgress, 0);
            }
        }

        private void DrainBlobs()
        {
            // Snapshotted up front so deleting blobs cannot invalidate the enumeration. The order the
            // provider yields is kept: newest first, because a backlog is worth less to a customer
            // than knowing what is happening now. A backlog too large to drain loses its oldest end,
            // either to eviction or to the ingestion age limit.
            var blobs = new List<PersistentBlob>(_blobProvider.GetBlobs());
            if (blobs.Count == 0)
            {
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            var batch = new List<PendingBlob>(MaxBlobsPerBatch);
            var payload = new MemoryStream();

            foreach (var blob in blobs)
            {
                if (_transmissionStateManager.State != TransmissionState.Closed || stopwatch.ElapsedMilliseconds >= MaxDrainMilliseconds)
                {
                    break;
                }

                if (!blob.TryLease(LeasePeriodMilliseconds))
                {
                    continue;
                }

                if (!blob.TryRead(out var data))
                {
                    // A read can fail transiently. Leave it leased so a later pass retries rather
                    // than deleting telemetry that is probably still good.
                    continue;
                }

                if (data == null || data.Length == 0)
                {
                    blob.TryDelete();
                    continue;
                }

                if (batch.Count > 0 && (batch.Count >= MaxBlobsPerBatch || payload.Length + data.Length >= MaxBatchBytes))
                {
                    if (!TransmitBatch(batch, payload.ToArray()))
                    {
                        return;
                    }

                    batch.Clear();
                    payload.SetLength(0);
                }

                AppendPayload(payload, data);
                batch.Add(new PendingBlob(blob, data));
            }

            if (batch.Count > 0)
            {
                TransmitBatch(batch, payload.ToArray());
            }
        }

        /// <summary>
        /// Blobs hold newline delimited JSON. Trailing newlines are dropped so that concatenating
        /// two blobs cannot produce a blank record that ingestion would reject.
        /// </summary>
        private static void AppendPayload(MemoryStream payload, byte[] data)
        {
            var length = data.Length;
            while (length > 0 && (data[length - 1] == (byte)'\n' || data[length - 1] == (byte)'\r'))
            {
                length--;
            }

            if (length == 0)
            {
                return;
            }

            if (payload.Length > 0)
            {
                payload.WriteByte((byte)'\n');
            }

            payload.Write(data, 0, length);
        }

        /// <returns><see langword="true"/> when draining may continue.</returns>
        private bool TransmitBatch(List<PendingBlob> batch, byte[] payload)
        {
            var telemetrySchemaTypeCounter = CountTelemetryTypes(payload);

            var stopwatch = _networkSdkStatsManager != null ? Stopwatch.StartNew() : null;

            using var requestBudget = new CancellationTokenSource(DrainPostBudgetMilliseconds);
            using var httpMessage = _applicationInsightsRestClient.InternalTrackAsync(payload, requestBudget.Token).Result;

            stopwatch?.Stop();

            var result = HttpPipelineHelper.IsSuccess(httpMessage, telemetrySchemaTypeCounter);

            if (_networkSdkStatsManager != null && httpMessage.HasResponse)
            {
                _networkSdkStatsManager.TrackDuration(httpMessage.Request.Uri.Host, stopwatch!.Elapsed.TotalMilliseconds);
            }

            if (result == ExportResult.Success)
            {
                _networkSdkStatsManager?.TrackSuccess(httpMessage.Request.Uri.Host);

                _transmissionStateManager.ResetConsecutiveErrors();
                _transmissionStateManager.CloseTransmission();

                AzureMonitorExporterEventSource.Log.TransmitFromStorageSuccess(_isAadEnabled, _connectionVars.InstrumentationKey);

                DeleteAll(batch);
                return true;
            }

            if (_networkSdkStatsManager != null)
            {
                if (httpMessage.HasResponse)
                {
                    // 206 partial-success per-envelope handling happens in
                    // HttpPipelineHelper.HandlePartialSuccess.
                    _networkSdkStatsManager.TrackResponseFailure(httpMessage.Request.Uri.Host, httpMessage.Response.Status);
                }
                else
                {
                    _networkSdkStatsManager.TrackException(httpMessage.Request.Uri.Host, exceptionType: null);
                }
            }

            var statusCode = httpMessage.HasResponse ? httpMessage.Response.Status : 0;

            // A coalesced payload can be rejected outright because of one bad blob, so isolate the
            // constituents rather than discarding telemetry that would have been accepted.
            if (batch.Count > 1 && httpMessage.HasResponse && statusCode != ResponseStatusCodes.PartialSuccess && !HttpPipelineHelper.IsRetriableStatus(statusCode))
            {
                AzureMonitorExporterEventSource.Log.CoalescedBatchRejected(batch.Count, statusCode);
                return TransmitIndividually(batch);
            }

            _transmissionStateManager.EnableBackOff(httpMessage.HasResponse ? httpMessage.Response : null);

            // No blob is passed because this batch may span many of them: a partial success
            // re-persists the retryable subset as a single new blob, after which every blob in the
            // batch has been superseded and is deleted here.
            var transmissionResult = HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _blobProvider, blob: null, _connectionVars, TelemetryItemOrigin.Storage, _isAadEnabled, telemetrySchemaTypeCounter, _networkSdkStatsManager);

            if (statusCode == ResponseStatusCodes.PartialSuccess)
            {
                // Only discard the originals once the retryable subset has been re-persisted, or
                // there was nothing retryable. An unreadable response body would otherwise take the
                // whole batch with it.
                if (transmissionResult.PartialSuccessHandled)
                {
                    DeleteAll(batch);
                }

                return true;
            }

            if (httpMessage.HasResponse && !HttpPipelineHelper.IsRetriableStatus(statusCode))
            {
                // Ingestion will never accept this payload; keeping it would wedge the backlog.
                DeleteAll(batch);
                return true;
            }

            // Retriable, or no response at all: leave the blobs leased so a later pass reclaims them.
            return false;
        }

        private bool TransmitIndividually(List<PendingBlob> batch)
        {
            var single = new List<PendingBlob>(1);

            foreach (var pending in batch)
            {
                single.Clear();
                single.Add(pending);

                var payload = new MemoryStream();
                AppendPayload(payload, pending.Data);

                if (!TransmitBatch(single, payload.ToArray()))
                {
                    return false;
                }
            }

            return true;
        }

        private static void DeleteAll(List<PendingBlob> batch)
        {
            foreach (var pending in batch)
            {
                // If the delete fails the batch may be transmitted again, resulting in duplicates.
                if (!pending.Blob.TryDelete())
                {
                    AzureMonitorExporterEventSource.Log.DeletedFailed();
                }
            }
        }

        private static TelemetrySchemaTypeCounter CountTelemetryTypes(byte[] payload)
        {
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            try
            {
                var telemetryItems = Encoding.UTF8.GetString(payload).Split('\n');
                for (int i = 0; i < telemetryItems.Length; i++)
                {
                    var (telemetryType, telemetrySuccess) = HttpPipelineHelper.GetTelemetryDetailsFromJson(telemetryItems[i]);
                    HttpPipelineHelper.IncrementCounterByType(telemetrySchemaTypeCounter, telemetryType, telemetrySuccess);
                }
            }
            catch (Exception)
            {
                // Counting is best effort; a malformed payload must not stop transmission.
            }

            return telemetrySchemaTypeCounter;
        }

        /// <summary>
        /// A leased blob is renamed to "*.lock", which matches neither the provider's blob
        /// enumeration nor its retention sweep. The provider only un-leases during a maintenance
        /// tick, which a short-lived process never reaches, so a run that died mid-upload would
        /// otherwise strand that telemetry permanently.
        /// </summary>
        private void ReclaimExpiredLeases()
        {
            if (_storageDirectory == null || !Directory.Exists(_storageDirectory))
            {
                return;
            }

            foreach (var file in Directory.EnumerateFiles(_storageDirectory, "*.lock", SearchOption.TopDirectoryOnly))
            {
                // Located within the file name so that a storage directory containing '@' cannot
                // skew the target path.
                var fileName = Path.GetFileName(file);
                var separatorIndex = fileName.LastIndexOf('@');
                if (separatorIndex < 0)
                {
                    continue;
                }

                if (!TryGetLeaseExpiry(fileName, out var expiry) || expiry > DateTime.UtcNow)
                {
                    continue;
                }

                try
                {
                    File.Move(file, Path.Combine(_storageDirectory, fileName.Substring(0, separatorIndex)));
                }
                catch (Exception)
                {
                    // Another process reclaimed the same lease first. Whichever move won owns the
                    // blob; this one simply moves on.
                }
            }
        }

        private static bool TryGetLeaseExpiry(string fileName, out DateTime expiry)
        {
            expiry = default;

            var withoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var separatorIndex = withoutExtension.LastIndexOf('@');
            if (separatorIndex < 0)
            {
                return false;
            }

            return DateTime.TryParseExact(
                withoutExtension.Substring(separatorIndex + 1),
                LeaseTimestampFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                out expiry);
        }

        private readonly struct PendingBlob
        {
            internal PendingBlob(PersistentBlob blob, byte[] data)
            {
                Blob = blob;
                Data = data;
            }

            internal PersistentBlob Blob { get; }

            internal byte[] Data { get; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transmitFromStorageTimer?.Dispose();
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
