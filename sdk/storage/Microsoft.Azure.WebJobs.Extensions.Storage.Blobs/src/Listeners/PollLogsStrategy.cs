// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    // A hybrid strategy that begins with a full container scan and then does incremental updates via log polling.
    internal sealed partial class PollLogsStrategy : IBlobListenerStrategy
    {
        private static readonly TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

        private readonly IDictionary<BlobContainerClient, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>> _registrations;
        private readonly IDictionary<BlobServiceClient, BlobLogListener> _logListeners;
        private readonly Thread _initialScanThread;
        private readonly ConcurrentQueue<BlobNotification> _blobsFoundFromScanOrNotification;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger<BlobListener> _logger;
        private readonly IWebJobsExceptionHandler _exceptionHandler;

        private bool _performInitialScan;
        private bool _disposed;

        public PollLogsStrategy(IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger, bool performInitialScan = true)
        {
            _registrations = new Dictionary<BlobContainerClient, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>>(
                new CloudBlobContainerComparer());
            _logListeners = new Dictionary<BlobServiceClient, BlobLogListener>(new CloudBlobClientComparer());
            _initialScanThread = new Thread(ScanContainers);
            _blobsFoundFromScanOrNotification = new ConcurrentQueue<BlobNotification>();
            _cancellationTokenSource = new CancellationTokenSource();
            _performInitialScan = performInitialScan;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
        }

        public async Task RegisterAsync(
            BlobServiceClient primaryBlobServiceClient,
            BlobServiceClient targetBlobServiceClient,
            BlobContainerClient container,
            ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
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

            if (targetBlobServiceClient == default)
            {
                // If no target client is specified, use the primary.
                BlobLogListener logListener = await BlobLogListener.CreateAsync(primaryBlobServiceClient, _logger, cancellationToken).ConfigureAwait(false);
                _logListeners.Add(primaryBlobServiceClient, logListener);
            }
            else if (!_logListeners.ContainsKey(targetBlobServiceClient))
            {
                try
                {
                    BlobLogListener logListener = await BlobLogListener.CreateAsync(targetBlobServiceClient, _logger, cancellationToken).ConfigureAwait(false);
                    _logListeners.Add(targetBlobServiceClient, logListener);
                }
                // TODO: verify if this is the only permissions error code, or other possible permissions errors
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.AuthorizationPermissionMismatch)
                {
                    Logger.LoggingNotEnabledOnTargetAccount(_logger, targetBlobServiceClient.Uri.AbsoluteUri);

                    // Fallback to primary client if target client does not have the permissions to be used.
                    BlobLogListener logListener = await BlobLogListener.CreateAsync(primaryBlobServiceClient, _logger, cancellationToken).ConfigureAwait(false);
                    _logListeners.Add(primaryBlobServiceClient, logListener);
                }
            }
        }

        public void Notify(BlobWithContainer<BlobBaseClient> blobWritten)
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

                await NotifyRegistrationsAsync(notification.Blob, notification.PollId, cancellationToken).ConfigureAwait(false);
            }

            // Poll the logs (to detect ongoing writes).
            foreach (BlobLogListener logListener in _logListeners.Values)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // assign a unique id for tracking
                string pollId = Guid.NewGuid().ToString();

                IEnumerable<BlobWithContainer<BlobBaseClient>> recentWrites = await logListener.GetRecentBlobWritesAsync(cancellationToken).ConfigureAwait(false);

                // Filter and group these by container for easier logging.
                var recentWritesGroupedByContainer = recentWrites
                    .Where(p => _registrations.ContainsKey(p.BlobContainerClient))
                    .GroupBy(p => p.BlobContainerClient.Name);

                foreach (var containerGroup in recentWritesGroupedByContainer)
                {
                    BlobWithContainer<BlobBaseClient>[] blobs = containerGroup.ToArray();

                    Logger.ScanBlobLogs(_logger, containerGroup.Key, pollId, blobs.Length);

                    foreach (BlobWithContainer<BlobBaseClient> blob in blobs)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await NotifyRegistrationsAsync(blob, pollId, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            // Run subsequent iterations at 2 second intervals.
            return new TaskSeriesCommandResult(wait: Task.Delay(TwoSeconds, CancellationToken.None));
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

        private async Task NotifyRegistrationsAsync(BlobWithContainer<BlobBaseClient> blob, string pollId, CancellationToken cancellationToken)
        {
            // Log listening is client-wide and blob written notifications are host-wide, so filter out things that
            // aren't in the container list.
            if (!_registrations.ContainsKey(blob.BlobContainerClient))
            {
                return;
            }

            foreach (ITriggerExecutor<BlobTriggerExecutorContext> registration in _registrations[blob.BlobContainerClient])
            {
                cancellationToken.ThrowIfCancellationRequested();

                BlobTriggerExecutorContext context = new BlobTriggerExecutorContext
                {
                    Blob = blob,
                    PollId = pollId,
                    TriggerSource = BlobTriggerScanSource.LogScan
                };

                FunctionResult result = await registration.ExecuteAsync(context, cancellationToken).ConfigureAwait(false);
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

            foreach (BlobContainerClient container in _registrations.Keys)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                List<BlobItem> items;

                try
                {
                    // Non-async is correct here. ScanContainers occurs on a background thread. Unless it blocks, no one
                    // else is around to observe the results.
                    items = container.GetBlobs(
                        traits: BlobTraits.None,
                        states: BlobStates.None,
                        prefix: null,
                        cancellationToken: CancellationToken.None).ToList();
                }
                catch (RequestFailedException exception)
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
                foreach (BlobItem item in items)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    _blobsFoundFromScanOrNotification
                        .Enqueue(new BlobNotification(new BlobWithContainer<BlobBaseClient>(container, container.GetBlobClient(item.Name)), pollId));
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

        private async Task<bool> CheckLoggingEnabledAsync(BlobServiceClient blobClient, CancellationToken cancellationToken)
        {
            BlobServiceProperties serviceProperties = await blobClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);

            // Retrieve the logging settings.
            BlobAnalyticsLogging loggingProperties = serviceProperties.Logging;

            if (!loggingProperties.Write)
            {
                // Log an error if logging is not enabled.
                Logger.LoggingNotEnabledOnTargetAccount(_logger, blobClient.Uri.AbsoluteUri);
                return false;
            }
            // Logging is enabled.
            return true;
        }
    }
}
