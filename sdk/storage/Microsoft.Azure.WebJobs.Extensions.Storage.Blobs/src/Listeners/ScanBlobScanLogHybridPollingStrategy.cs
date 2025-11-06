// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal sealed partial class ScanBlobScanLogHybridPollingStrategy : IBlobListenerStrategy
    {
        private static readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(10);
        private readonly IDictionary<BlobContainerClient, ContainerScanInfo> _scanInfo;
        private readonly ConcurrentQueue<BlobNotification> _blobsFoundFromScanOrNotification;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly ILogger<BlobListener> _logger;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private IBlobScanInfoManager _blobScanInfoManager;
        // A budget is allocated representing the number of blobs to be listed in a polling
        // interval, each container will get its share of _scanBlobLimitPerPoll/number of containers.
        // this share will be listed for each container each polling interval
        private int _scanBlobLimitPerPoll = 10000;
        private PollLogsStrategy _pollLogStrategy;
        private bool _disposed;

        public ScanBlobScanLogHybridPollingStrategy(IBlobScanInfoManager blobScanInfoManager, IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger) : base()
        {
            _blobScanInfoManager = blobScanInfoManager;
            _scanInfo = new Dictionary<BlobContainerClient, ContainerScanInfo>(new CloudBlobContainerComparer());
            _pollLogStrategy = new PollLogsStrategy(exceptionHandler, logger, performInitialScan: false);
            _cancellationTokenSource = new CancellationTokenSource();
            _blobsFoundFromScanOrNotification = new ConcurrentQueue<BlobNotification>();
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Start()
        {
            ThrowIfDisposed();
            _pollLogStrategy.Start();
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _pollLogStrategy.Cancel();
            _cancellationTokenSource.Cancel();
        }

        public async Task RegisterAsync(BlobServiceClient blobServiceClient, BlobContainerClient container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor, CancellationToken cancellationToken)
        {
            // Register and Execute are not concurrency-safe.
            // Avoiding calling Register while Execute is running is the caller's responsibility.
            ThrowIfDisposed();

            // Register all in logPolling, there is no problem if we get 2 notifications of the new blob
            await _pollLogStrategy.RegisterAsync(blobServiceClient, container, triggerExecutor, cancellationToken).ConfigureAwait(false);

            if (!_scanInfo.TryGetValue(container, out ContainerScanInfo containerScanInfo))
            {
                // First, try to load serialized scanInfo for this container.
                DateTime? latestStoredScan = await _blobScanInfoManager.LoadLatestScanAsync(blobServiceClient.AccountName, container.Name).ConfigureAwait(false);

                containerScanInfo = new ContainerScanInfo()
                {
                    Registrations = new List<ITriggerExecutor<BlobTriggerExecutorContext>>(),
                    LastSweepCycleLatestModified = latestStoredScan ?? DateTime.MinValue,
                    CurrentSweepCycleLatestModified = DateTime.MinValue,
                    ContinuationToken = null
                };

                Logger.InitializedScanInfo(_logger, container.Name, containerScanInfo.LastSweepCycleLatestModified);

                _scanInfo.Add(container, containerScanInfo);
            }

            containerScanInfo.Registrations.Add(triggerExecutor);
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            Task logPollingTask = _pollLogStrategy.ExecuteAsync(cancellationToken);
            List<BlobNotification> failedNotifications = new List<BlobNotification>();
            List<Task> notifications = new List<Task>();

            // Drain the background queue of blob written notifications.
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (!_blobsFoundFromScanOrNotification.TryDequeue(out BlobNotification failedNotification))
                {
                    break;
                }

                notifications.Add(NotifyRegistrationsAsync(failedNotification.Blob, failedNotifications, failedNotification.PollId, cancellationToken));
            }

            await Task.WhenAll(notifications).ConfigureAwait(false);

            List<Task> pollingTasks = new List<Task>();
            pollingTasks.Add(logPollingTask);

            foreach (KeyValuePair<BlobContainerClient, ContainerScanInfo> containerScanInfoPair in _scanInfo)
            {
                pollingTasks.Add(PollAndNotify(containerScanInfoPair.Key, containerScanInfoPair.Value, failedNotifications, cancellationToken));
            }

            // Re-add any failed notifications for the next iteration.
            foreach (var failedNotification in failedNotifications)
            {
                _blobsFoundFromScanOrNotification.Enqueue(failedNotification);
            }

            await Task.WhenAll(pollingTasks).ConfigureAwait(false);

            // Run subsequent iterations at "_pollingInterval" second intervals.
            return new TaskSeriesCommandResult(wait: Task.Delay(PollingInterval, CancellationToken.None));
        }

        private async Task PollAndNotify(BlobContainerClient container, ContainerScanInfo containerScanInfo,
            List<BlobNotification> failedNotifications, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            DateTime lastScan = containerScanInfo.LastSweepCycleLatestModified;

            // For tracking
            string clientRequestId = Guid.NewGuid().ToString();

            IEnumerable<BlobBaseClient> newBlobs = await PollNewBlobsAsync(container, containerScanInfo, clientRequestId, cancellationToken).ConfigureAwait(false);

            foreach (var newBlob in newBlobs)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await NotifyRegistrationsAsync(new BlobWithContainer<BlobBaseClient>(container, newBlob), failedNotifications, clientRequestId, cancellationToken).ConfigureAwait(false);
            }

            // if the 'LatestModified' has changed, update it in the manager
            if (containerScanInfo.LastSweepCycleLatestModified > lastScan)
            {
                DateTime latestScan = containerScanInfo.LastSweepCycleLatestModified;

                // It's possible that we had some blobs that we failed to move to the queue. We want to make sure
                // we continue to find these if the host needs to restart.
                if (failedNotifications.Any())
                {
                    // TODO (kasobol-msft) this call to GetProperties is suboptimal figure out how to propagate data from listing here.
                    latestScan = failedNotifications.Select(p => p.Blob).Min(n => n.BlobClient.GetProperties().Value.LastModified.UtcDateTime);
                }

                // Store our timestamp slightly earlier than the last timestamp. This is a failsafe for any blobs that created
                // milliseconds after our last scan (blob timestamps round to the second). This way we make sure to pick those
                // up on a host restart.
                await _blobScanInfoManager.UpdateLatestScanAsync(container.AccountName,
                    container.Name, latestScan.AddMilliseconds(-1)).ConfigureAwait(false);
            }
        }

        public void Notify(BlobWithContainer<BlobBaseClient> blobWritten)
        {
            ThrowIfDisposed();
            _blobsFoundFromScanOrNotification.Enqueue(new BlobNotification(blobWritten, null));
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _pollLogStrategy.Dispose();
                _cancellationTokenSource.Dispose();
                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        /// <summary>
        /// This method is called each polling interval for all containers. The method divides the
        /// budget of allocated number of blobs to query, for each container we query a page of
        /// that size and we keep the continuation token for the next time. AS a curser, we use
        /// the time stamp when the current cycle on the container started. blobs newer than that
        /// time will be considered new and registrations will be notified
        /// </summary>
        /// <param name="container"></param>
        /// <param name="containerScanInfo"> Information that includes the last cycle start
        /// the continuation token and the current cycle start for a container</param>
        /// <param name="clientRequestId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BlobBaseClient>> PollNewBlobsAsync(
            BlobContainerClient container, ContainerScanInfo containerScanInfo, string clientRequestId, CancellationToken cancellationToken)
        {
            IEnumerable<BlobItem> currentBlobs;
            int blobPollLimitPerContainer = _scanBlobLimitPerPoll / _scanInfo.Count;
            string continuationToken = containerScanInfo.ContinuationToken;
            Page<BlobItem> page;

            // if starting the cycle, reset the sweep time
            if (continuationToken == null)
            {
                containerScanInfo.CurrentSweepCycleLatestModified = DateTime.MinValue;
            }

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                AsyncPageable<BlobItem> blobsAsyncPageable = container.GetBlobsAsync(
                    traits: BlobTraits.None,
                    states: BlobStates.None,
                    prefix: null,
                    cancellationToken: cancellationToken);
                IAsyncEnumerable<Page<BlobItem>> pages = blobsAsyncPageable.AsPages(continuationToken: continuationToken, pageSizeHint: blobPollLimitPerContainer);
                IAsyncEnumerator<Page<BlobItem>> pagesEnumerator = pages.GetAsyncEnumerator(cancellationToken);
                if (await pagesEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    page = pagesEnumerator.Current;
                    currentBlobs = page.Values;
                }
                else
                {
                    return Enumerable.Empty<BlobBaseClient>();
                }
            }
            catch (RequestFailedException exception)
            {
                if (exception.IsNotFound())
                {
                    Logger.ContainerDoesNotExist(_logger, container.Name);
                    return Enumerable.Empty<BlobBaseClient>();
                }
                else
                {
                    throw;
                }
            }

            List<BlobBaseClient> newBlobs = new List<BlobBaseClient>();

            // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
            foreach (BlobItem currentBlob in currentBlobs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var properties = currentBlob.Properties;
                DateTime lastModifiedTimestamp = properties.LastModified.Value.UtcDateTime;

                if (lastModifiedTimestamp > containerScanInfo.CurrentSweepCycleLatestModified)
                {
                    containerScanInfo.CurrentSweepCycleLatestModified = lastModifiedTimestamp;
                }

                // Blob timestamps are rounded to the nearest second, so make sure we continue to check
                // the previous timestamp to catch any blobs that came in slightly after our previous poll.
                if (lastModifiedTimestamp >= containerScanInfo.LastSweepCycleLatestModified)
                {
                    newBlobs.Add(container.GetBlobClient(currentBlob.Name));
                }
            }

            Logger.PollBlobContainer(_logger, container.Name, containerScanInfo.LastSweepCycleLatestModified, clientRequestId,
                newBlobs.Count, sw.ElapsedMilliseconds, !string.IsNullOrWhiteSpace(page.ContinuationToken));

            // record continuation token for next chunk retrieval
            containerScanInfo.ContinuationToken = page.ContinuationToken;

            // if ending a cycle then copy currentSweepCycleStartTime to lastSweepCycleStartTime, if changed
            if (string.IsNullOrEmpty(page.ContinuationToken) &&
                containerScanInfo.CurrentSweepCycleLatestModified > containerScanInfo.LastSweepCycleLatestModified)
            {
                containerScanInfo.LastSweepCycleLatestModified = containerScanInfo.CurrentSweepCycleLatestModified;
            }

            return newBlobs;
        }

        private async Task NotifyRegistrationsAsync(BlobWithContainer<BlobBaseClient> blob, ICollection<BlobNotification> failedNotifications, string clientRequestId, CancellationToken cancellationToken)
        {
            // Blob written notifications are host-wide, so filter out things that aren't in the container list.
            if (!_scanInfo.TryGetValue(blob.BlobContainerClient, out ContainerScanInfo containerScanInfo))
            {
                return;
            }

            foreach (ITriggerExecutor<BlobTriggerExecutorContext> registration in containerScanInfo.Registrations)
            {
                cancellationToken.ThrowIfCancellationRequested();

                BlobTriggerExecutorContext context = new BlobTriggerExecutorContext
                {
                    Blob = blob,
                    PollId = clientRequestId,
                    TriggerSource = BlobTriggerScanSource.ContainerScan
                };

                FunctionResult result = await registration.ExecuteAsync(context, cancellationToken).ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    // If notification failed, try again on the next iteration.
                    failedNotifications.Add(new BlobNotification(blob, clientRequestId));
                }
            }
        }
    }
}
