// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // A hybrid strategy that begins with a full container scan and then does incremental updates via log polling.
    internal sealed partial class PollLogsStrategy : IBlobListenerStrategy
    {
        private static readonly TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

        private readonly IDictionary<CloudBlobContainer, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>> _registrations;
        private readonly IDictionary<CloudBlobClient, BlobLogListener> _logListeners;
        private readonly Thread _initialScanThread;
        private readonly ConcurrentQueue<BlobNotification> _blobsFoundFromScanOrNotification;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger<BlobListener> _logger;
        private readonly IWebJobsExceptionHandler _exceptionHandler;

        private bool _performInitialScan;
        private bool _disposed;

        public PollLogsStrategy(IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger, bool performInitialScan = true)
        {
            _registrations = new Dictionary<CloudBlobContainer, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>>(
                new CloudBlobContainerComparer());
            _logListeners = new Dictionary<CloudBlobClient, BlobLogListener>(new CloudBlobClientComparer());
            _initialScanThread = new Thread(ScanContainers);
            _blobsFoundFromScanOrNotification = new ConcurrentQueue<BlobNotification>();
            _cancellationTokenSource = new CancellationTokenSource();
            _performInitialScan = performInitialScan;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
        }

        public async Task RegisterAsync(CloudBlobContainer container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            // Initial background scans for all containers happen on first Execute call.
            // Prevent accidental late registrations.
            // (Also prevents incorrect concurrent execution of Register with Execute.)
            if (_initialScanThread.ThreadState != ThreadState.Unstarted)
            {
                throw new InvalidOperationException("All registrations must be created before execution begins.");
            }

            ICollection<ITriggerExecutor<BlobTriggerExecutorContext>> containerRegistrations;

            if (_registrations.ContainsKey(container))
            {
                containerRegistrations = _registrations[container];
            }
            else
            {
                containerRegistrations = new List<ITriggerExecutor<BlobTriggerExecutorContext>>();
                _registrations.Add(container, containerRegistrations);
            }

            containerRegistrations.Add(triggerExecutor);

            CloudBlobClient client = container.ServiceClient;

            if (!_logListeners.ContainsKey(client))
            {
                BlobLogListener logListener = await BlobLogListener.CreateAsync(client, _exceptionHandler, _logger, cancellationToken);
                _logListeners.Add(client, logListener);
            }
        }

        public void Notify(ICloudBlob blobWritten)
        {
            ThrowIfDisposed();
            _blobsFoundFromScanOrNotification.Enqueue(new BlobNotification(blobWritten, null));
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            // Drain the background queue (for initial container scans and blob written notifications).
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (!_blobsFoundFromScanOrNotification.TryDequeue(out BlobNotification notification))
                {
                    break;
                }

                await NotifyRegistrationsAsync(notification.Blob, notification.PollId, cancellationToken);
            }

            // Poll the logs (to detect ongoing writes).
            foreach (BlobLogListener logListener in _logListeners.Values)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // assign a unique id for tracking
                string pollId = Guid.NewGuid().ToString();

                IEnumerable<ICloudBlob> recentWrites = await logListener.GetRecentBlobWritesAsync(cancellationToken);

                // Filter and group these by container for easier logging.
                var recentWritesGroupedByContainer = recentWrites
                    .Where(p => _registrations.ContainsKey(p.Container))
                    .GroupBy(p => p.Container.Name);

                foreach (var containerGroup in recentWritesGroupedByContainer)
                {
                    ICloudBlob[] blobs = containerGroup.ToArray();

                    Logger.ScanBlobLogs(_logger, containerGroup.Key, pollId, blobs.Length);

                    foreach (ICloudBlob blob in blobs)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await NotifyRegistrationsAsync(blob, pollId, cancellationToken);
                    }
                }
            }

            // Run subsequent iterations at 2 second intervals.
            return new TaskSeriesCommandResult(wait: Task.Delay(TwoSeconds));
        }

        public void Start()
        {
            ThrowIfDisposed();

            // Start a background scan of the container on first execution. Later writes will be found via polling logs.
            // Thread monitors _cancellationTokenSource.Token (that's the only way this thread is controlled).
            if (_performInitialScan)
            {
                _initialScanThread.Start(_cancellationTokenSource.Token);
            }
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _cancellationTokenSource.Dispose();
                _disposed = true;
            }
        }

        private async Task NotifyRegistrationsAsync(ICloudBlob blob, string pollId, CancellationToken cancellationToken)
        {
            CloudBlobContainer container = blob.Container;

            // Log listening is client-wide and blob written notifications are host-wide, so filter out things that
            // aren't in the container list.
            if (!_registrations.ContainsKey(container))
            {
                return;
            }

            foreach (ITriggerExecutor<BlobTriggerExecutorContext> registration in _registrations[container])
            {
                cancellationToken.ThrowIfCancellationRequested();

                BlobTriggerExecutorContext context = new BlobTriggerExecutorContext
                {
                    Blob = blob,
                    PollId = pollId,
                    TriggerSource = BlobTriggerSource.LogScan
                };

                FunctionResult result = await registration.ExecuteAsync(context, cancellationToken);
                if (!result.Succeeded)
                {
                    // If notification failed, try again on the next iteration.

                    BlobNotification notification = new BlobNotification(blob, pollId);
                    _blobsFoundFromScanOrNotification.Enqueue(notification);
                }
            }
        }

        private void ScanContainers(object state)
        {
            CancellationToken cancellationToken = (CancellationToken)state;

            // assign a unique id for tracking
            string pollId = Guid.NewGuid().ToString();

            foreach (CloudBlobContainer container in _registrations.Keys)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                List<IListBlobItem> items;

                try
                {
                    // Non-async is correct here. ScanContainers occurs on a background thread. Unless it blocks, no one
                    // else is around to observe the results.
                    items = container.ListBlobsAsync(prefix: null, useFlatBlobListing: true,
                        cancellationToken: CancellationToken.None).GetAwaiter().GetResult().ToList();
                }
                catch (StorageException exception)
                {
                    if (exception.IsNotFound())
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }

                // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
                foreach (ICloudBlob item in items)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    _blobsFoundFromScanOrNotification.Enqueue(new BlobNotification(item, pollId));
                }
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }
    }
}
