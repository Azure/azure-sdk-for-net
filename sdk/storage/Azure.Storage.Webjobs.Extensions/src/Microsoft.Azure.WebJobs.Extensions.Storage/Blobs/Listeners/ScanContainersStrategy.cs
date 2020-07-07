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

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal sealed class ScanContainersStrategy : IBlobListenerStrategy
    {
        private static readonly TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

        private readonly IDictionary<CloudBlobContainer, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>> _registrations;
        private readonly IDictionary<CloudBlobContainer, DateTime> _lastModifiedTimestamps;
        private readonly ConcurrentQueue<ICloudBlob> _blobWrittenNotifications;

        public ScanContainersStrategy()
        {
            _registrations = new Dictionary<CloudBlobContainer, ICollection<ITriggerExecutor<BlobTriggerExecutorContext>>>(
                new CloudBlobContainerComparer());
            _lastModifiedTimestamps = new Dictionary<CloudBlobContainer, DateTime>(
                new CloudBlobContainerComparer());
            _blobWrittenNotifications = new ConcurrentQueue<ICloudBlob>();
        }

        public void Notify(ICloudBlob blobWritten)
        {
            _blobWrittenNotifications.Enqueue(blobWritten);
        }

        public Task RegisterAsync(CloudBlobContainer container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
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
            List<ICloudBlob> failedNotifications = new List<ICloudBlob>();

            // Drain the background queue of blob written notifications.
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (!_blobWrittenNotifications.TryDequeue(out ICloudBlob blob))
                {
                    break;
                }

                await NotifyRegistrationsAsync(blob, failedNotifications, cancellationToken);
            }

            foreach (CloudBlobContainer container in _registrations.Keys)
            {
                cancellationToken.ThrowIfCancellationRequested();
                DateTime lastScanTimestamp = _lastModifiedTimestamps[container];
                Tuple<IEnumerable<ICloudBlob>, DateTime> newBlobsResult = await PollNewBlobsAsync(container,
                    lastScanTimestamp, cancellationToken);
                IEnumerable<ICloudBlob> newBlobs = newBlobsResult.Item1;
                _lastModifiedTimestamps[container] = newBlobsResult.Item2;

                foreach (ICloudBlob newBlob in newBlobs)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NotifyRegistrationsAsync(newBlob, failedNotifications, cancellationToken);
                }
            }

            // Re-add any failed notifications for the next iteration.
            foreach (ICloudBlob failedNotification in failedNotifications)
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

        private async Task NotifyRegistrationsAsync(ICloudBlob blob, ICollection<ICloudBlob> failedNotifications,
            CancellationToken cancellationToken)
        {
            CloudBlobContainer container = blob.Container;

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

                FunctionResult result = await registration.ExecuteAsync(context, cancellationToken);
                if (!result.Succeeded)
                {
                    // If notification failed, try again on the next iteration.
                    failedNotifications.Add(blob);
                }
            }
        }

        public static async Task<Tuple<IEnumerable<ICloudBlob>, DateTime>> PollNewBlobsAsync(
            CloudBlobContainer container, DateTime previousTimestamp, CancellationToken cancellationToken)
        {
            DateTime updatedTimestamp = previousTimestamp;

            IList<IListBlobItem> currentBlobs;

            try
            {
                currentBlobs = (await container.ListBlobsAsync(prefix: null, useFlatBlobListing: true,
                    cancellationToken: cancellationToken)).ToList();
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFound())
                {
                    return new Tuple<IEnumerable<ICloudBlob>, DateTime>(
                        Enumerable.Empty<ICloudBlob>(), updatedTimestamp);
                }
                else
                {
                    throw;
                }
            }

            List<ICloudBlob> newBlobs = new List<ICloudBlob>();

            // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
            foreach (ICloudBlob currentBlob in currentBlobs)
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
                    newBlobs.Add(currentBlob);
                }
            }

            return new Tuple<IEnumerable<ICloudBlob>, DateTime>(newBlobs, updatedTimestamp);
        }
    }
}
