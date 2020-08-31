// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal sealed class ScanContainersStrategy : IBlobListenerStrategy
    {
        private static readonly TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

        private readonly IDictionary<BlobContainerClient, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>> _registrations;
        private readonly IDictionary<BlobContainerClient, DateTime> _lastModifiedTimestamps;
        private readonly ConcurrentQueue<(BlobContainerClient, BlobBaseClient)> _blobWrittenNotifications;

        public ScanContainersStrategy()
        {
            _registrations = new Dictionary<BlobContainerClient, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>>(
                new CloudBlobContainerComparer());
            _lastModifiedTimestamps = new Dictionary<BlobContainerClient, DateTime>(
                new CloudBlobContainerComparer());
            _blobWrittenNotifications = new ConcurrentQueue<(BlobContainerClient, BlobBaseClient)>();
        }

        public void Notify(BlobContainerClient container, BlobBaseClient blobWritten)
        {
            _blobWrittenNotifications.Enqueue((container, blobWritten));
        }

        public Task RegisterAsync(BlobServiceClient blobServiceClient, BlobContainerClient container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken)
        {
            // Register and Execute are not concurrency-safe.
            // Avoiding calling Register while Execute is running is the caller's responsibility.
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

            if (!_lastModifiedTimestamps.ContainsKey(container))
            {
                _lastModifiedTimestamps.Add(container, DateTime.MinValue);
            }

            return Task.FromResult(0);
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            List<(BlobContainerClient, BlobBaseClient)> failedNotifications = new List<(BlobContainerClient, BlobBaseClient)>();

            // Drain the background queue of blob written notifications.
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (!_blobWrittenNotifications.TryDequeue(out var tupple))
                {
                    break;
                }

                await NotifyRegistrationsAsync(tupple.Item1, tupple.Item2, failedNotifications, cancellationToken).ConfigureAwait(false);
            }

            foreach (BlobContainerClient container in _registrations.Keys)
            {
                cancellationToken.ThrowIfCancellationRequested();
                DateTime lastScanTimestamp = _lastModifiedTimestamps[container];
                Tuple<IEnumerable<BlobBaseClient>, DateTime> newBlobsResult = await PollNewBlobsAsync(container,
                    lastScanTimestamp, cancellationToken).ConfigureAwait(false);
                IEnumerable<BlobBaseClient> newBlobs = newBlobsResult.Item1;
                _lastModifiedTimestamps[container] = newBlobsResult.Item2;

                foreach (BlobBaseClient newBlob in newBlobs)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NotifyRegistrationsAsync(container, newBlob, failedNotifications, cancellationToken).ConfigureAwait(false);
                }
            }

            // Re-add any failed notifications for the next iteration.
            foreach ((BlobContainerClient, BlobBaseClient) failedNotification in failedNotifications)
            {
                _blobWrittenNotifications.Enqueue(failedNotification);
            }

            // Run subsequent iterations at 2 second intervals.
            return new TaskSeriesCommandResult(wait: Task.Delay(TwoSeconds));
        }

        public void Cancel()
        {
        }

        public void Start()
        {
        }

        public void Dispose()
        {
        }

        private async Task NotifyRegistrationsAsync(BlobContainerClient container, BlobBaseClient blob, ICollection<(BlobContainerClient, BlobBaseClient)> failedNotifications,
            CancellationToken cancellationToken)
        {
            // Blob written notifications are host-wide, so filter out things that aren't in the container list.
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
                    PollId = null,
                    TriggerSource = BlobTriggerSource.ContainerScan
                };

                FunctionResult result = await registration.ExecuteAsync(context, cancellationToken).ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    // If notification failed, try again on the next iteration.
                    failedNotifications.Add((container, blob));
                }
            }
        }

        public static async Task<Tuple<IEnumerable<BlobBaseClient>, DateTime>> PollNewBlobsAsync(
            BlobContainerClient container, DateTime previousTimestamp, CancellationToken cancellationToken)
        {
            DateTime updatedTimestamp = previousTimestamp;

            IAsyncEnumerable<BlobItem> currentBlobs;

            try
            {
                currentBlobs = container.GetBlobsAsync(cancellationToken: cancellationToken);


                List<BlobBaseClient> newBlobs = new List<BlobBaseClient>();

                // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
                await foreach (BlobItem currentBlob in currentBlobs.ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var properties = currentBlob.Properties;
                    DateTime lastModifiedTimestamp = properties.LastModified.Value.UtcDateTime;

                    if (lastModifiedTimestamp > updatedTimestamp)
                    {
                        updatedTimestamp = lastModifiedTimestamp;
                    }

                    if (lastModifiedTimestamp > previousTimestamp)
                    {
                        // TODO (kasobol-msft) check type here
                        newBlobs.Add(container.GetBlobClient(currentBlob.Name));
                    }
                }

                return new Tuple<IEnumerable<BlobBaseClient>, DateTime>(newBlobs, updatedTimestamp);
            }
            catch (RequestFailedException exception)
            {
                if (exception.IsNotFound())
                {
                    return new Tuple<IEnumerable<BlobBaseClient>, DateTime>(
                        Enumerable.Empty<BlobBaseClient>(), updatedTimestamp);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
