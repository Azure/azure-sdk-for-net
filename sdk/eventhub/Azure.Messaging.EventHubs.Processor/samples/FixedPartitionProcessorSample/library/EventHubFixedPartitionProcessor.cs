namespace EventHubProcessors;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Extensions.Logging;

/// <summary>
/// This class consumes events from an Event Hub with a fixed number of partitions. It supports batching.
/// It supports automatic checkpointing on lease renewal.
/// </summary>
[ExcludeFromCodeCoverage]
public class EventHubFixedPartitionProcessor : EventProcessor<EventProcessorPartition>, IDisposable
{
    private readonly BlobContainerClient containerClient;
    private readonly EventHubFixedPartitionProcessorOptions options;
    private readonly ILogger<EventHubFixedPartitionProcessor> logger;
    private readonly Dictionary<string, AzureBlobLease> owned = new();
    private readonly SemaphoreSlim stateLock = new(1, 1);
    private readonly SemaphoreSlim ownedLock = new(1, 1);
    private readonly long[] dirtyOffsets = new long[32];
    private readonly long[] committedOffsets = new long[32];
    private readonly Random random = new();
    private CancellationTokenSource cancellationTokenSource;
    private string[] partitions = null;
    private bool disposed = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventHubFixedPartitionProcessor"/> class.
    /// </summary>
    /// <param name="consumerGroup">The consumer group.</param>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="maxBatchCount">The maximum batch count.</param>
    /// <param name="containerClient">The container client.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public EventHubFixedPartitionProcessor(
        string consumerGroup,
        string connectionString,
        int maxBatchCount,
        BlobContainerClient containerClient,
        EventHubFixedPartitionProcessorOptions options,
        ILogger<EventHubFixedPartitionProcessor> logger)
    : base(maxBatchCount, consumerGroup, connectionString, options)
    {
        this.containerClient = containerClient;
        this.options = options;
        this.logger = logger;
    }

    /// <summary>
    /// Represents a method that will be called when partitions are assigned.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="partitionId">The partition id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task OnAssignedDelegateAsync(object sender, string partitionId);

    /// <summary>
    /// Represents a method that will be called when partitions are renewed.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="partitionId">The partition id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task OnRenewedDelegateAsync(object sender, string partitionId);

    /// <summary>
    /// Represents a method that will be called when partitions are released.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="partitionId">The partition id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task OnReleasedDelegateAsync(object sender, string partitionId);

    /// <summary>
    /// Represents a method that will be called when a batch of events is received.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="events">The events.</param>
    /// <param name="partition">The partition.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task OnBatchAsyncDelegate(object sender, IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken);

    /// <summary>
    /// Represents a method that will be called when an exception is raised trying to get a batch of events.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="partition">The partition.</param>
    /// <param name="operationDescription">The operation that was being attempted.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task OnErrorAsyncDelegate(object sender, Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken);

    /// <summary>
    /// Represents an event that is raised when partitions are assigned to this instance.
    /// </summary>
    public event OnAssignedDelegateAsync OnAssignedAsync;

    /// <summary>
    /// Represents an event that is raised when partitions are renewed for this instance.
    /// </summary>
    public event OnRenewedDelegateAsync OnRenewedAsync;

    /// <summary>
    /// Represents an event that is raised when partitions are released from this instance.
    /// </summary>
    public event OnReleasedDelegateAsync OnReleasedAsync;

    /// <summary>
    /// Represents an event that is raised when a batch is ready for processing.
    /// </summary>
    public event OnBatchAsyncDelegate OnBatchAsync;

    /// <summary>
    /// Represents an event that is raised when an exception is raised.
    /// </summary>
    public event OnErrorAsyncDelegate OnErrorAsync;

    /// <summary>
    /// This returns a list of partitions that are owned by this instance.
    /// </summary>
    /// <returns>The partitions.</returns>
    public async Task<List<string>> GetOwnedPartitionIdsAsync()
    {
        await this.ownedLock.WaitAsync();
        try
        {
            return this.owned.Keys.ToList();
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    /// <summary>
    /// This starts getting leases and events from Event Hub.
    /// </summary>
    /// <param name="cancellationToken">If cancelled, the processing of events from Event Hub will soon stop.</param>
    /// <returns>A Task indicating completion.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the processor has already been started.</exception>
    /// <exception cref="PartitionIdOutOfRangeException">Thrown if the partition ID is not as expected.</exception>
    public override async Task StartProcessingAsync(CancellationToken cancellationToken = default)
    {
        // ensure there are no race conditions with multiple starts or stops
        await this.stateLock.WaitAsync(cancellationToken);
        try
        {
            // ensure it cannot be started more than once
            if (this.partitions is not null)
            {
                throw new InvalidOperationException("This processor has already been started.");
            }

            // log the start
            this.logger.LogDebug("starting EventHubFixedPartitionProcessor blob leasing...");

            // create a new CTS based on the cancellation token; this way the StopProcessingAsync method can cancel if necessary
            this.cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // set all offsets to uninitialized
            for (int i = 0; i < 32; i++)
            {
                Interlocked.Exchange(ref this.dirtyOffsets[i], -1);
                Interlocked.Exchange(ref this.committedOffsets[i], -1);
            }

            // get a list of all partition ids
            await using var connection = this.CreateConnection();
            var path = $"{connection.FullyQualifiedNamespace}/{connection.EventHubName}/{this.ConsumerGroup}/ownership";
            this.partitions = await this.ListPartitionIdsAsync(connection, this.cancellationTokenSource.Token);
            foreach (var partition in this.partitions)
            {
                // ensure numeric and in range
                if (!int.TryParse(partition, out int idx) || idx < 0 || idx > 31)
                {
                    throw new PartitionIdOutOfRangeException(partition);
                }

                // create a blob for each partition
                var blob = $"{path}/{partition}";
                try
                {
                    BlobClient blobClient = this.containerClient.GetBlobClient(blob);
                    BlobRequestConditions requestConditions = new() { IfNoneMatch = ETag.All };
                    using MemoryStream emptyStream = new(Array.Empty<byte>());
                    this.logger.LogDebug("attempting to create blob '{b}' for EventHubFixedPartitionProcessor.", blob);
                    BlobContentInfo info = await blobClient.UploadAsync(emptyStream, conditions: requestConditions, cancellationToken: this.cancellationTokenSource.Token);
                    this.logger.LogInformation("created blob '{b}' for EventHubFixedPartitionProcessor.", blob);
                }
                catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobAlreadyExists || e.ErrorCode == BlobErrorCode.ConditionNotMet || e.ErrorCode == BlobErrorCode.LeaseIdMissing)
                {
                    this.logger.LogDebug("blob '{b}' for EventHubFixedPartitionProcessor already existed.", blob);
                }
            }

            // start the loop
            _ = Task.Run(
                async () =>
                {
                    this.logger.LogInformation("started EventHubFixedPartitionProcessor blob leasing.");
                    while (true)
                    {
                        if (!this.cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            await this.AssignAsync(path, this.cancellationTokenSource.Token);
                            await this.RenewAsync(path, this.cancellationTokenSource.Token);
                        }

                        await this.ReleaseAsync();
                        await Task.Delay(1000, this.cancellationTokenSource.Token);
                    }
                }, cancellationToken: this.cancellationTokenSource.Token);

            // run the base
            await base.StartProcessingAsync(this.cancellationTokenSource.Token);
        }
        finally
        {
            this.stateLock.Release();
        }
    }

    /// <summary>
    /// This stops the processing of events from Event Hub.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the stopping.</param>
    /// <returns>A Task indicating completion.</returns>
    public override async Task StopProcessingAsync(CancellationToken cancellationToken = default)
    {
        // ensure there are no race conditions with multiple starts or stops
        await this.stateLock.WaitAsync(cancellationToken);
        try
        {
            this.cancellationTokenSource.Cancel();
            await base.StopProcessingAsync(cancellationToken);
        }
        finally
        {
            this.stateLock.Release();
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes of the managed and unmanaged resources used by the <see cref="EventHubFixedPartitionProcessor"/> instance.
    /// </summary>
    /// <param name="disposing">True if the method is being called from the Dispose method, false otherwise.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                // Dispose managed resources here
                this.cancellationTokenSource?.Dispose();
            }

            // Dispose unmanaged resources here
            this.disposed = true;
        }
    }

    /// <summary>
    /// This announces to the processor when new partitions are available for processing.
    /// </summary>
    /// <param name="desiredOwnership">The partitions that are desired. This has no bearing on the result.</param>
    /// <param name="cancellationToken">The cancellation token to stop this process.</param>
    /// <returns>The partitions that this processor owns.</returns>
    protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(
        IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
        CancellationToken cancellationToken)
    {
        var ownerships = new List<EventProcessorPartitionOwnership>();

        var ownedPartitions = await this.GetOwnedPartitionIdsAsync();
        foreach (var partition in ownedPartitions)
        {
            ownerships.Add(new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = this.FullyQualifiedNamespace,
                EventHubName = this.EventHubName,
                ConsumerGroup = this.ConsumerGroup,
                PartitionId = partition,
                OwnerIdentifier = this.Identifier,
            });
        }

        return ownerships;
    }

    /// <summary>
    /// Gets a list of partitions that could be owned. This is not used.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of partitions that could be owned.</returns>
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());
    }

    /// <summary>
    /// This is called whenever there is a batch of events available for processing.
    /// </summary>
    /// <param name="events">The batch of events.</param>
    /// <param name="partition">The partition.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A Task indicating completion.</returns>
    protected override async Task OnProcessingEventBatchAsync(
        IEnumerable<EventData> events,
        EventProcessorPartition partition,
        CancellationToken cancellationToken)
    {
        try
        {
            // empty check
            if (events is null || !events.Any())
            {
                return;
            }

            // process
            if (this.OnBatchAsync is not null)
            {
                await this.OnBatchAsync(this, events, partition, cancellationToken);
            }

            // checkpoint
            if (this.options.ShouldCheckpoint && int.TryParse(partition.PartitionId, out int idx))
            {
                Interlocked.Exchange(ref this.dirtyOffsets[idx], events.Last().Offset);
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an exception was raised during EventHubFixedPartitionProcessor.OnProcessingEventBatchAsync()...");
        }
    }

    /// <summary>
    /// This is called whenever there is an error during processing.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="partition">The partition.</param>
    /// <param name="operationDescription">The operation that was being attempted.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A Task indicating completion.</returns>
    protected override async Task OnProcessingErrorAsync(
        Exception exception,
        EventProcessorPartition partition,
        string operationDescription,
        CancellationToken cancellationToken)
    {
        try
        {
            if (this.OnErrorAsync is not null)
            {
                await this.OnErrorAsync(this, exception, partition, operationDescription, cancellationToken);
            }
            else
            {
                this.logger.LogError(exception, "an exception was raised while EventHubFixedPartitionProcessor was looking for events...");
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an exception was raised during EventHubFixedPartitionProcessor.OnProcessingErrorAsync()...");
        }
    }

    /// <summary>
    /// This is called when ownership of a partition is claimed to determine where to resume reading.
    /// </summary>
    /// <param name="partitionId">The partition ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The checkpoint position.</returns>
    protected override Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, CancellationToken cancellationToken)
    {
        if (this.options.ShouldCheckpoint && int.TryParse(partitionId, out int idx) && idx >= 0 && idx <= 31)
        {
            var offset = Interlocked.Read(ref this.dirtyOffsets[idx]); // -1 is the uninitialized value
            if (offset > -1)
            {
                this.logger.LogDebug("checkpoint obtained for partition {p} at offset {o} for EventHubFixedPartitionProcessor.", partitionId, offset);
                return Task.FromResult(new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = this.FullyQualifiedNamespace,
                    EventHubName = this.EventHubName,
                    ConsumerGroup = this.ConsumerGroup,
                    PartitionId = partitionId,
                    StartingPosition = EventPosition.FromOffset(offset),
                });
            }
        }

        return Task.FromResult<EventProcessorCheckpoint>(null);
    }

    private async Task<Dictionary<string, AzureBlobLease>> GetOwnedPartitionsAsync()
    {
        await this.ownedLock.WaitAsync();
        try
        {
            return this.owned.ToDictionary(x => x.Key, x => x.Value);
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    private async Task<int> GetOwnedCountAsync()
    {
        await this.ownedLock.WaitAsync();
        try
        {
            return this.owned.Count;
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    private async Task<IOrderedEnumerable<BlobItem>> FilterAndShuffleAsync(List<BlobItem> blobs)
    {
        await this.ownedLock.WaitAsync();
        try
        {
            var shuffled = blobs
                .Where(x => !this.owned.ContainsKey(x.Name))
                .OrderBy(x => this.random.Next());
            return shuffled;
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    private async Task TakeOwnershipAsync(string partition, AzureBlobLease lease)
    {
        await this.ownedLock.WaitAsync();
        try
        {
            this.owned.Add(partition, lease);
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    private async Task DropOwnershipAsync(string partition)
    {
        await this.ownedLock.WaitAsync();
        try
        {
            this.owned.Remove(partition);
        }
        finally
        {
            this.ownedLock.Release();
        }
    }

    private async Task AssignAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            // shortcut if everything is already owned
            var count = await this.GetOwnedCountAsync();
            if (count >= this.options.MaxPartitions)
            {
                return;
            }

            // get list of blobs
            this.logger.LogDebug("getting a list of blobs for EventHubFixedPartitionProcessor assignment...");
            var blobs = new List<BlobItem>();
            await foreach (BlobItem blob in this.containerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: path, cancellationToken: cancellationToken))
            {
                blobs.Add(blob);
            }

            this.logger.LogDebug("got {c} blobs for EventHubFixedPartitionProcessor assignment.", blobs.Count);

            // filter and shuffle
            var shuffled = await this.FilterAndShuffleAsync(blobs);
            this.logger.LogDebug("shuffled and filtered to {b} blobs for EventHubFixedPartitionProcessor assignment.", blobs.Count);

            // try to get leases
            foreach (var blob in shuffled)
            {
                try
                {
                    // identify the blob
                    var blobPath = blob.Name;
                    var blobName = blob.Name.Split("/").Last();
                    var blobClient = this.containerClient.GetBlobClient(blobPath);
                    var leaseClient = blobClient.GetBlobLeaseClient();

                    // attempt getting a lease
                    this.logger.LogDebug("attempting to gain a lease on blob '{b}' for EventHubFixedPartitionProcessor assignment...", blobPath);
                    var lease = await leaseClient.AcquireAsync(this.options.PartitionOwnershipExpirationInterval, cancellationToken: cancellationToken);
                    this.logger.LogInformation("blob '{b}' was available for leasing and assigned during EventHubFixedPartitionProcessor assignment.", blobPath);

                    // get the offset
                    if (this.options.ShouldCheckpoint && int.TryParse(blobName, out int idx) && idx >= 0 && idx <= 31)
                    {
                        var cnd = new BlobRequestConditions { LeaseId = lease.Value.LeaseId };
                        var res = await blobClient.DownloadContentAsync(cnd, cancellationToken);
                        var raw = res.Value?.Content?.ToString();
                        if (long.TryParse(raw, out long offset))
                        {
                            Interlocked.Exchange(ref this.dirtyOffsets[idx], offset);
                            Interlocked.Exchange(ref this.committedOffsets[idx], offset);
                        }
                    }

                    // take ownership
                    await this.TakeOwnershipAsync(blobName, new AzureBlobLease
                    {
                        Id = lease.Value.LeaseId,
                        RenewAt = DateTime.UtcNow.Add(this.options.LoadBalancingUpdateInterval),
                        TimeoutAt = DateTime.UtcNow.Add(this.options.PartitionOwnershipExpirationInterval),
                    });

                    // notify of assignment
                    if (this.OnAssignedAsync is not null)
                    {
                        await this.OnAssignedAsync(this, blobName);
                    }

                    break; // only assign 1 at a time
                }
                catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.LeaseAlreadyPresent || e.ErrorCode == BlobErrorCode.LeaseIdMissing)
                {
                    // ignore
                }
            }
        }
        catch (TaskCanceledException)
        {
            // ignore
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an exception was raised during EventHubFixedPartitionProcessor assignment.");
        }
    }

    private async Task RenewAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            var exceptions = new List<Exception>();
            var ownedPartitions = await this.GetOwnedPartitionsAsync();
            foreach (var pair in ownedPartitions)
            {
                try
                {
                    if (DateTime.UtcNow > pair.Value.RenewAt)
                    {
                        // identify the blob
                        var blobPath = $"{path}/{pair.Key}";
                        var blobName = pair.Key;
                        var blobClient = this.containerClient.GetBlobClient(blobPath);
                        var leaseClient = blobClient.GetBlobLeaseClient(pair.Value.Id);

                        // renew the lease
                        this.logger.LogDebug("attempting to renew the lease on blob '{b}' for EventHubFixedPartitionProcessor...", blobPath);
                        var lease = await leaseClient.RenewAsync(cancellationToken: cancellationToken);
                        this.logger.LogDebug("successfully renewed the lease on blob '{b}' for EventHubFixedPartitionProcessor.", blobPath);
                        pair.Value.RenewAt = DateTime.UtcNow.Add(this.options.LoadBalancingUpdateInterval);
                        pair.Value.TimeoutAt = DateTime.UtcNow.Add(this.options.PartitionOwnershipExpirationInterval);

                        // write the checkpint
                        if (this.options.ShouldCheckpoint && int.TryParse(blobName, out int idx) && idx >= 0 && idx <= 31)
                        {
                            var dirtyOffset = Interlocked.Read(ref this.dirtyOffsets[idx]);
                            var committedOffset = Interlocked.Read(ref this.committedOffsets[idx]);
                            if (dirtyOffset > -1 && dirtyOffset != committedOffset)
                            {
                                this.logger.LogDebug("writing the offset '{o}' to blob '{b}' for EventHubFixedPartitionProcessor...", dirtyOffset, blobPath);
                                using MemoryStream ms = new();
                                using StreamWriter sw = new(ms);
                                await sw.WriteAsync(dirtyOffset.ToString());
                                await sw.FlushAsync();
                                ms.Position = 0;
                                var cnd = new BlobRequestConditions { LeaseId = lease.Value.LeaseId };
                                await blobClient.UploadAsync(ms, conditions: cnd, cancellationToken: cancellationToken);
                                Interlocked.Exchange(ref this.committedOffsets[idx], dirtyOffset);
                                this.logger.LogDebug("successfully wrote the offset of '{o}' to blob '{b}' for EventHubFixedPartitionProcessor...", dirtyOffset, blobPath);
                            }
                        }

                        // notify of renewal
                        if (this.OnRenewedAsync is not null)
                        {
                            await this.OnRenewedAsync(this, blobName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
        catch (TaskCanceledException)
        {
            // ignore
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an exception was raised during EventHubFixedPartitionProcessor renewal...");
        }
    }

    private async Task ReleaseAsync()
    {
        try
        {
            // mark for deletion
            var markedForDeletion = new List<string>();
            var ownedPartitions = await this.GetOwnedPartitionsAsync();
            foreach (var pair in ownedPartitions)
            {
                if (DateTime.UtcNow > pair.Value.TimeoutAt)
                {
                    markedForDeletion.Add(pair.Key);
                }
            }

            // delete
            foreach (var key in markedForDeletion)
            {
                // release
                await this.DropOwnershipAsync(key);
                this.logger.LogWarning("ownership of key {k} was released due to failed renewals in EventHubFixedPartitionProcessor.", key);

                // notify of release
                if (this.OnReleasedAsync is not null)
                {
                    await this.OnReleasedAsync(this, key);
                }
            }
        }
        catch (TaskCanceledException)
        {
            // ignore
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an exception was raised during EventHubFixedPartitionProcessor release...");
        }
    }
}