// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;

    class PartitionManager
    {
        readonly EventProcessorHost host;
        readonly ConcurrentDictionary<string, PartitionPump> partitionPumps;

        IList<string> partitionIds;
        CancellationTokenSource cancellationTokenSource;
        Task runTask;

        internal PartitionManager(EventProcessorHost host)
        {
            this.host = host;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.partitionPumps = new ConcurrentDictionary<string, PartitionPump>();
        }

        public async Task<IEnumerable<string>> GetPartitionIdsAsync()
        {
            if (this.partitionIds == null)
            {
                EventHubClient eventHubClient = null;
                try
                {
                    eventHubClient = this.host.CreateEventHubClient();
                    eventHubClient.WebProxy = this.host.EventProcessorOptions.WebProxy;
                    var runtimeInfo = await eventHubClient.GetRuntimeInformationAsync().ConfigureAwait(false);
                    this.partitionIds = runtimeInfo.PartitionIds.ToList();
                }
                catch (Exception e)
                {
                    throw new EventProcessorConfigurationException("Encountered error while fetching the list of EventHub PartitionIds", e);
                }
                finally
                {
                    if (eventHubClient != null)
                    {
                        await eventHubClient.CloseAsync().ConfigureAwait(false);
                    }
                }

                ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, $"PartitionCount: {this.partitionIds.Count}");
            }

            return this.partitionIds;
        }

        public async Task StartAsync()
        {
            if (this.runTask != null)
            {
                throw new InvalidOperationException("A PartitionManager cannot be started multiple times.");
            }

            await this.InitializeStoresAsync().ConfigureAwait(false);

            this.runTask = this.RunAsync();
        }

        public async Task StopAsync()
        {
            this.cancellationTokenSource.Cancel();
            var localRunTask = this.runTask;
            if (localRunTask != null)
            {
                await localRunTask.ConfigureAwait(false);
            }

            // once it is closed let's reset the task
            this.runTask = null;
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        async Task RunAsync()
        {
            try
            {
                await this.RunLoopAsync(this.cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (TaskCanceledException) when (this.cancellationTokenSource.IsCancellationRequested)
            {
                // Expected during host shutdown.
            }
            catch (Exception e)
            {
                // Ideally RunLoop should never throw.
                ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, "Exception from partition manager main loop, shutting down", e.ToString());
                this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, "N/A", e, EventProcessorHostActionStrings.PartitionManagerMainLoop);
            }

            try
            {
                // Cleanup
                ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, "Shutting down all pumps");
                await this.RemoveAllPumpsAsync(CloseReason.Shutdown).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, "Failure during shutdown", e.ToString());
                this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, "N/A", e, EventProcessorHostActionStrings.PartitionManagerCleanup);
            }
        }

        async Task InitializeStoresAsync() //throws InterruptedException, ExecutionException, ExceptionWithAction
        {
            // Make sure the lease store exists
            ILeaseManager leaseManager = this.host.LeaseManager;
            if (!await leaseManager.LeaseStoreExistsAsync().ConfigureAwait(false))
            {
                await RetryAsync(() => leaseManager.CreateLeaseStoreIfNotExistsAsync(), null, "Failure creating lease store for this Event Hub, retrying",
                        "Out of retries creating lease store for this Event Hub", EventProcessorHostActionStrings.CreatingLeaseStore, 5).ConfigureAwait(false);
            }
            // else
            //	lease store already exists, no work needed

            var partitionIds = await this.GetPartitionIdsAsync().ConfigureAwait(false);

            // Now make sure the leases exist
            var createLeaseTasks = new List<Task>();
            foreach (string id in partitionIds)
            {
                var subjectId = id;
                createLeaseTasks.Add(RetryAsync(() => leaseManager.CreateLeaseIfNotExistsAsync(subjectId), subjectId, $"Failure creating lease for partition {subjectId}, retrying",
                        $"Out of retries creating lease for partition {subjectId}", EventProcessorHostActionStrings.CreatingLease, 5));
            }

            await Task.WhenAll(createLeaseTasks).ConfigureAwait(false);

            // Make sure the checkpoint store exists
            ICheckpointManager checkpointManager = this.host.CheckpointManager;
            if (!await checkpointManager.CheckpointStoreExistsAsync().ConfigureAwait(false))
            {
                await RetryAsync(() => checkpointManager.CreateCheckpointStoreIfNotExistsAsync(), null, "Failure creating checkpoint store for this Event Hub, retrying",
                        "Out of retries creating checkpoint store for this Event Hub", EventProcessorHostActionStrings.CreatingCheckpointStore, 5).ConfigureAwait(false);
            }
            // else
            //	checkpoint store already exists, no work needed

            // Now make sure the checkpoints exist
            var createCheckpointTasks = new List<Task>();
            foreach (string id in partitionIds)
            {
                var subjectId = id;
                createCheckpointTasks.Add(RetryAsync(() => checkpointManager.CreateCheckpointIfNotExistsAsync(subjectId), subjectId, $"Failure creating checkpoint for partition {subjectId}, retrying",
                        $"Out of retries creating checkpoint for partition {subjectId}", EventProcessorHostActionStrings.CreatingCheckpoint, 5));
            }

            await Task.WhenAll(createCheckpointTasks).ConfigureAwait(false);
        }

        // Throws if it runs out of retries. If it returns, action succeeded.
        async Task RetryAsync(Func<Task> lambda, string partitionId, string retryMessage, string finalFailureMessage, string action, int maxRetries) // throws ExceptionWithAction
        {
            Exception finalException = null;
            bool createdOK = false;
            int retryCount = 0;
            do
            {
                try
                {
                    await lambda().ConfigureAwait(false);
                    createdOK = true;
                }
                catch (Exception ex)
                {
                    if (partitionId != null)
                    {
                        ProcessorEventSource.Log.PartitionPumpWarning(this.host.HostName, partitionId, retryMessage, ex.ToString());
                    }
                    else
                    {
                        ProcessorEventSource.Log.EventProcessorHostWarning(this.host.HostName, retryMessage, ex.ToString());
                    }

                    this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, partitionId, ex, action);

                    finalException = ex;
                    retryCount++;
                }
            }
            while (!createdOK && (retryCount < maxRetries));

            if (!createdOK)
            {
                if (partitionId != null)
                {
                    ProcessorEventSource.Log.PartitionPumpError(this.host.HostName, partitionId, finalFailureMessage);
                }
                else
                {
                    ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, finalFailureMessage, null);
                }

                throw new EventProcessorRuntimeException(finalFailureMessage, action, finalException);
            }
        }

        async Task RunLoopAsync(CancellationToken cancellationToken) // throws Exception, ExceptionWithAction
        {
            var loopStopwatch = new Stopwatch();

            while (!cancellationToken.IsCancellationRequested)
            {
                // Mark start time so we can use the duration taken to calculate renew interval.
                loopStopwatch.Restart();

                ILeaseManager leaseManager = this.host.LeaseManager;
                var allLeases = new ConcurrentDictionary<string, Lease>();
                var leasesOwnedByOthers = new ConcurrentDictionary<string, Lease>();

                // Inspect all leases.
                // Acquire any expired leases.
                // Renew any leases that currently belong to us.
                IEnumerable<Lease> downloadedLeases;
                var renewLeaseTasks = new List<Task>();
                int ourLeaseCount = 0;

                try
                { 
                    try
                    {
                        downloadedLeases = await leaseManager.GetAllLeasesAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, "Exception during downloading leases", e.Message);
                        this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, "N/A", e, EventProcessorHostActionStrings.DownloadingLeases);

                        // Avoid tight spin if getallleases call keeps failing.
                        await Task.Delay(1000).ConfigureAwait(false);

                        continue;
                    }

                    // First things first, renew owned leases.
                    foreach (var lease in downloadedLeases)
                    {
                        var subjectLease = lease;

                        try
                        {
                            allLeases[subjectLease.PartitionId] = subjectLease;
                            if (subjectLease.Owner == this.host.HostName && !(await subjectLease.IsExpired().ConfigureAwait(false)))
                            {
                                ourLeaseCount++;

                                // Get lease from partition since we need the token at this point.
                                if (!this.partitionPumps.TryGetValue(subjectLease.PartitionId, out var capturedPump))
                                {
                                    continue;
                                }

                                var capturedLease = capturedPump.Lease;

                                ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, capturedLease.PartitionId, "Trying to renew lease.");
                                renewLeaseTasks.Add(leaseManager.RenewLeaseAsync(capturedLease).ContinueWith(renewResult =>
                                {
                                    if (renewResult.IsFaulted)
                                    {
                                        // Might have failed due to intermittent error or lease-lost.
                                        // Just log here, expired leases will be picked by same or another host anyway.
                                        ProcessorEventSource.Log.PartitionPumpError(
                                            this.host.HostName,
                                            capturedLease.PartitionId, 
                                            "Failed to renew lease.", 
                                            renewResult.Exception?.Message);

                                        this.host.EventProcessorOptions.NotifyOfException(
                                            this.host.HostName,
                                            capturedLease.PartitionId,
                                            renewResult.Exception,
                                            EventProcessorHostActionStrings.RenewingLease);

                                        // Nullify the owner on the lease in case this host lost it.
                                        // This helps to remove pump earlier reducing duplicate receives.
                                        if (renewResult.Exception?.GetBaseException() is LeaseLostException)
                                        {
                                            allLeases[capturedLease.PartitionId].Owner = null;
                                        }
                                    }
                                }, cancellationToken));
                            }
                            else if (!await subjectLease.IsExpired().ConfigureAwait(false))
                            {
                                leasesOwnedByOthers[subjectLease.PartitionId] = subjectLease;
                            }
                        }
                        catch (Exception e)
                        {
                            ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, "Failure during checking lease.", e.ToString());
                            this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, "N/A", e, EventProcessorHostActionStrings.CheckingLeases);
                        }
                    }

                    // Wait until we are done with renewing our own leases here.
                    // In theory, this should never throw, error are logged and notified in the renew tasks.
                    await Task.WhenAll(renewLeaseTasks).ConfigureAwait(false);
                    ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, "Lease renewal is finished.");

                    // Check any expired leases that we can grab here.
                    ourLeaseCount += await this.AcquireExpiredLeasesAsync(allLeases, leasesOwnedByOthers, ourLeaseCount, cancellationToken);
                    ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, "Expired lease check is finished.");

                    // Grab more leases if available and needed for load balancing
                    if (leasesOwnedByOthers.Count > 0)
                    {
                        Lease stealThisLease = WhichLeaseToSteal(leasesOwnedByOthers.Values, ourLeaseCount);

                        // Don't attempt to steal the lease if current host has a pump for this partition id
                        // This is possible when current pump is in failed state due to lease moved to some other host.
                        if (stealThisLease != null && !this.partitionPumps.ContainsKey(stealThisLease.PartitionId))
                        {
                            try
                            {
                                // Get fresh content of lease subject to acquire.
                                var downloadedLease = await leaseManager.GetLeaseAsync(stealThisLease.PartitionId).ConfigureAwait(false);
                                allLeases[stealThisLease.PartitionId] = downloadedLease;

                                // Don't attempt to steal if lease is already expired.
                                // Expired leases are picked up by other hosts quickly.
                                // Don't attempt to steal if owner has changed from the calculation time to refresh time.
                                if (!await downloadedLease.IsExpired().ConfigureAwait(false)
                                    && downloadedLease.Owner == stealThisLease.Owner)
                                {
                                    ProcessorEventSource.Log.PartitionPumpStealLeaseStart(this.host.HostName, downloadedLease.PartitionId);
                                    if (await leaseManager.AcquireLeaseAsync(downloadedLease).ConfigureAwait(false))
                                    {
                                        // Succeeded in stealing lease
                                        ProcessorEventSource.Log.PartitionPumpStealLeaseStop(this.host.HostName, downloadedLease.PartitionId);
                                        ourLeaseCount++;
                                    }
                                    else
                                    {
                                        // Acquisition failed. Make sure we don't leave the lease as owned.
                                        allLeases[stealThisLease.PartitionId].Owner = null;

                                        ProcessorEventSource.Log.EventProcessorHostWarning(this.host.HostName,
                                            "Failed to steal lease for partition " + downloadedLease.PartitionId, null);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName,
                                    "Exception during stealing lease for partition " + stealThisLease.PartitionId, e.ToString());
                                this.host.EventProcessorOptions.NotifyOfException(this.host.HostName,
                                    stealThisLease.PartitionId, e, EventProcessorHostActionStrings.StealingLease);

                                // Acquisition failed. Make sure we don't leave the lease as owned.
                                allLeases[stealThisLease.PartitionId].Owner = null;
                            }
                        }
                    }

                    // Update pump with new state of leases on owned partitions in parallel.
                    var createRemovePumpTasks = new List<Task>();
                    foreach (string partitionId in allLeases.Keys)
                    {
                        var subjectPartitionId = partitionId;

                        Lease updatedLease = allLeases[subjectPartitionId];
                        ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, $"Lease on partition {updatedLease.PartitionId} owned by {updatedLease.Owner}");

                        if (updatedLease.Owner == this.host.HostName)
                        {
                            createRemovePumpTasks.Add(Task.Run(async () =>
                            {
                                try
                                {
                                    await this.CheckAndAddPumpAsync(subjectPartitionId, updatedLease).ConfigureAwait(false);
                                }
                                catch (Exception e)
                                {
                                    ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, $"Exception during add pump on partition {subjectPartitionId}", e.Message);
                                    this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, subjectPartitionId, e, EventProcessorHostActionStrings.PartitionPumpManagement);
                                }
                            }, cancellationToken));
                        }
                        else if (this.partitionPumps.ContainsKey(partitionId))
                        {
                            createRemovePumpTasks.Add(Task.Run(async () =>
                            {
                                try
                                {
                                    await this.TryRemovePumpAsync(subjectPartitionId, CloseReason.LeaseLost).ConfigureAwait(false);
                                }
                                catch (Exception e)
                                {
                                    ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, $"Exception during remove pump on partition {subjectPartitionId}", e.Message);
                                    this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, subjectPartitionId, e, EventProcessorHostActionStrings.PartitionPumpManagement);
                                }
                            }, cancellationToken));
                        }
                    }

                    await Task.WhenAll(createRemovePumpTasks).ConfigureAwait(false);
                    ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, "Pump update is finished.");
                }
                catch (Exception e)
                {
                    // TaskCancelledException is expected furing host unregister.
                    if (e is TaskCanceledException)
                    {
                        continue;
                    }

                    // Loop should not exit unless signalled via cancellation token. Log any failures and continue.
                    ProcessorEventSource.Log.EventProcessorHostError(this.host.HostName, "Exception from partition manager main loop, continuing", e.Message);
                    this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, "N/A", e, EventProcessorHostActionStrings.PartitionPumpManagement);
                }
                finally
                {
                    // Consider reducing the wait time with last lease-walkthrough's time taken.
                    var elapsedTime = loopStopwatch.Elapsed;
                    if (leaseManager.LeaseRenewInterval > elapsedTime)
                    {
                        await Task.Delay(leaseManager.LeaseRenewInterval.Subtract(elapsedTime), cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        async Task<int> AcquireExpiredLeasesAsync(
            ConcurrentDictionary<string, Lease> allLeases, 
            ConcurrentDictionary<string, Lease> leasesOwnedByOthers,
            int ownedCount,
            CancellationToken cancellationToken)
        {
            var totalAcquired = 0;
            var hosts = new List<string>();

            // Find distinct hosts actively owning leases.
            foreach (var lease in allLeases.Values)
            {
                if (lease.Owner != null && !hosts.Contains(lease.Owner) && !(await lease.IsExpired().ConfigureAwait(false)))
                {
                    hosts.Add(lease.Owner);
                }
            }

            // Calculate how many more leases we can own.
            var hostCount = hosts.Count() == 0 ? 1 : hosts.Count();
            var targetLeaseCount = (int)Math.Ceiling((double)allLeases.Count / (double)hostCount) - ownedCount;

            // Attempt to acquire expired leases now up to allowed target lease count.
            var tasks = new List<Task>();
            foreach (var possibleLease in allLeases.Values)
            {
                // Break if we already acquired enough number of leases.
                if (targetLeaseCount <= 0)
                {
                    break;
                }

                var subjectLease = possibleLease;

                if (await subjectLease.IsExpired().ConfigureAwait(false))
                {
                    targetLeaseCount--;
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            // Get fresh content of lease subject to acquire.
                            var downloadedLease = await this.host.LeaseManager.GetLeaseAsync(subjectLease.PartitionId).ConfigureAwait(false);
                            allLeases[subjectLease.PartitionId] = downloadedLease;

                            // Check expired once more here incase another host have already leased this since we populated the list.
                            if (await downloadedLease.IsExpired().ConfigureAwait(false))
                            {
                                ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, downloadedLease.PartitionId, "Trying to acquire lease.");
                                if (await this.host.LeaseManager.AcquireLeaseAsync(downloadedLease).ConfigureAwait(false))
                                {
                                    ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, downloadedLease.PartitionId, "Acquired lease.");
                                    leasesOwnedByOthers.TryRemove(downloadedLease.PartitionId, out var removedLease);
                                    Interlocked.Increment(ref totalAcquired);
                                }
                                else
                                {
                                    // Acquisition failed. Make sure we don't leave the lease as owned.
                                    allLeases[subjectLease.PartitionId].Owner = null;

                                    ProcessorEventSource.Log.EventProcessorHostWarning(this.host.HostName,
                                        "Failed to acquire lease for partition " + downloadedLease.PartitionId, null);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            ProcessorEventSource.Log.PartitionPumpError(this.host.HostName, subjectLease.PartitionId, "Failure during acquiring lease", e.ToString());
                            this.host.EventProcessorOptions.NotifyOfException(this.host.HostName, subjectLease.PartitionId, e, EventProcessorHostActionStrings.CheckingLeases);

                            // Acquisition failed. Make sure we don't leave the lease as owned.
                            allLeases[subjectLease.PartitionId].Owner = null;
                        }
                    }, cancellationToken));
                }
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);

            return totalAcquired;
        }

        async Task CheckAndAddPumpAsync(string partitionId, Lease lease)
        {
            PartitionPump capturedPump;
            if (this.partitionPumps.TryGetValue(partitionId, out capturedPump))
            {
                // There already is a pump. Make sure the pump is working and replace the lease.
                if (capturedPump.PumpStatus != PartitionPumpStatus.Running && capturedPump.PumpStatus != PartitionPumpStatus.Opening)
                {
                    // The existing pump is bad. Remove it.
                    await TryRemovePumpAsync(partitionId, CloseReason.Shutdown).ConfigureAwait(false);
                }
                else
                {
                    // Lease token can show up empty here if lease content download has failed or not recently acquired.
                    // Don't update the token if so.
                    if (!string.IsNullOrWhiteSpace(lease.Token))
                    {
                        // Pump is working, just replace the lease token.
                        ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, partitionId, "Updating lease token for pump");
                        capturedPump.SetLeaseToken(lease.Token);
                    }
                    else
                    {
                        ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, partitionId, "Skipping to update lease token for pump");
                    }
                }
            }
            else
            {
                // No existing pump, create a new one.
                await CreateNewPumpAsync(partitionId).ConfigureAwait(false);
            }
        }

        async Task CreateNewPumpAsync(string partitionId)
        {
            // Refresh lease content and do last minute check to reduce partition moves.
            var refreshedLease = await this.host.LeaseManager.GetLeaseAsync(partitionId).ConfigureAwait(false);
            if (refreshedLease.Owner != this.host.HostName || await refreshedLease.IsExpired().ConfigureAwait(false))
            {
                // Partition moved to some other node after lease acquisition.
                // Return w/o creating the pump.
                ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, partitionId, $"Partition moved to another host or expired after acquisition.");
                return;
            }

            PartitionPump newPartitionPump = new EventHubPartitionPump(this.host, refreshedLease);
            await newPartitionPump.OpenAsync().ConfigureAwait(false);
            this.partitionPumps.TryAdd(partitionId, newPartitionPump); // do the put after start, if the start fails then put doesn't happen
            ProcessorEventSource.Log.PartitionPumpInfo(this.host.HostName, partitionId, "Created new PartitionPump");
        }

        async Task TryRemovePumpAsync(string partitionId, CloseReason reason)
        {
            PartitionPump capturedPump;
            if (this.partitionPumps.TryRemove(partitionId, out capturedPump))
            {
                if (!capturedPump.IsClosing)
                {
                    // Don't block on close call more than renew interval if close reason is lease-lost.
                    // Otherwise we can block indefinetely.
                    var closeTask = capturedPump.CloseAsync(reason);
                    if (reason == CloseReason.LeaseLost)
                    {
                        await this.WaitTaskTimeoutAsync(closeTask, this.host.LeaseManager.LeaseRenewInterval).ConfigureAwait(false);
                    }
                    else
                    {
                        await closeTask.ConfigureAwait(false);
                    }
                }
                // else, pump is already closing/closed, don't need to try to shut it down again
            }
        }

        /// <summary>
        /// Awaits given task up to provided wait time.
        /// Throws OperationCanceledException when wait time is exhausted.
        /// </summary>
        async Task WaitTaskTimeoutAsync(Task task, TimeSpan waitTime)
        {
            using (var cts = new CancellationTokenSource())
            {
                var timeoutTask = Task.Delay(waitTime, cts.Token);
                var completedTask = await Task.WhenAny(task, timeoutTask).ConfigureAwait(false);

                if (completedTask == task)
                {
                    cts.Cancel();
                }
                else
                {
                    // Throw OperationCanceledException, caller will log the failures appropriately.
                    throw new OperationCanceledException();
                }
            }
        }

        Task RemoveAllPumpsAsync(CloseReason reason)
        {
            List<Task> tasks = new List<Task>();
            var keys = new List<string>(this.partitionPumps.Keys);
            foreach (string partitionId in keys)
            {
                tasks.Add(this.TryRemovePumpAsync(partitionId, reason));
            }

            return Task.WhenAll(tasks);
        }

        Lease WhichLeaseToSteal(IEnumerable<Lease> stealableLeases, int haveLeaseCount)
        {
            IDictionary<string, int> countsByOwner = CountLeasesByOwner(stealableLeases);

            // Consider all leases might be already released where we won't have any entry in the return counts map.
            if (countsByOwner.Count == 0)
            {
                return null;
            }

            var biggestOwner = countsByOwner.OrderByDescending(o => o.Value).First();
            Lease stealThisLease = null;

            // If the number of leases is a multiple of the number of hosts, then the desired configuration is
            // that all hosts own the name number of leases, and the difference between the "biggest" owner and
            // any other is 0.
            //
            // If the number of leases is not a multiple of the number of hosts, then the most even configuration
            // possible is for some hosts to have (leases/hosts) leases and others to have ((leases/hosts) + 1).
            // For example, for 16 partitions distributed over five hosts, the distribution would be 4, 3, 3, 3, 3,
            // or any of the possible reorderings.
            //
            // In either case, if the difference between this host and the biggest owner is 2 or more, then the
            // system is not in the most evenly-distributed configuration, so steal one lease from the biggest.
            // If there is a tie for biggest, we pick whichever appears first in the list because
            // it doesn't really matter which "biggest" is trimmed down.
            //
            // Stealing one at a time prevents flapping because it reduces the difference between the biggest and
            // this host by two at a time. If the starting difference is two or greater, then the difference cannot
            // end up below 0. This host may become tied for biggest, but it cannot become larger than the host that
            // it is stealing from.

            if ((biggestOwner.Value - haveLeaseCount) >= 2)
            {
                stealThisLease = stealableLeases.First(l => l.Owner == biggestOwner.Key);
                ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, $"Proposed to steal lease for partition {stealThisLease.PartitionId} from {biggestOwner.Key}");
            }

            return stealThisLease;
        }

        Dictionary<string, int> CountLeasesByOwner(IEnumerable<Lease> leases)
        {
            var counts = leases.Where(lease => lease.Owner != null).GroupBy(lease => lease.Owner).Select(group => new
            {
                Owner = group.Key,
                Count = group.Count()
            });

            // Log ownership mapping.
            foreach (var owner in counts)
            {
                ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, $"Host {owner.Owner} owns {owner.Count} leases");
            }

            ProcessorEventSource.Log.EventProcessorHostInfo(this.host.HostName, $"Total hosts in list: {counts.Count()}");

            return counts.ToDictionary(e => e.Owner, e => e.Count);
        }
    }
}