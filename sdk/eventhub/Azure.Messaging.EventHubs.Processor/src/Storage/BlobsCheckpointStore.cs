// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    internal sealed class BlobsCheckpointStore : PartitionManager
    {
        /// <summary>A regular expression used to capture strings enclosed in double quotes.</summary>
        private static readonly Regex DoubleQuotesExpression = new Regex("\"(.*)\"", RegexOptions.Compiled);

        /// <summary>
        ///   Specifies a string that filters the results to return only checkpoint blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        private const string CheckpointPrefix = "{0}/{1}/{2}/checkpoint/";

        /// <summary>
        ///   Specifies a string that filters the results to return only ownership blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        private const string OwnershipPrefix = "{0}/{1}/{2}/ownership/";

        /// <summary>
        ///   The client used to interact with the Azure Blob Storage service.
        /// </summary>
        private BlobContainerClient ContainerClient { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   <see cref="BlobsCheckpointStore" />.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The instance of <see cref="BlobEventStoreEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal BlobEventStoreEventSource Logger { get; set; } = BlobEventStoreEventSource.Log;

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobsCheckpointStore"/> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client used to interact with the Azure Blob Storage service.</param>
        /// <param name="retryPolicy">The retry policy to use as the basis for interacting with the Storage Blobs service.</param>
        ///
        public BlobsCheckpointStore(BlobContainerClient blobContainerClient,
                                    EventHubsRetryPolicy retryPolicy)
        {
            Argument.AssertNotNull(blobContainerClient, nameof(blobContainerClient));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            ContainerClient = blobContainerClient;
            RetryPolicy = retryPolicy;
            Logger.BlobsCheckpointStoreCreated(blobContainerClient.AccountName, blobContainerClient.Name);
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the storage blob service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                       string eventHubName,
                                                                                       string consumerGroup,
                                                                                       CancellationToken cancellationToken)
        {
            Logger.ListOwnershipAsyncStart(fullyQualifiedNamespace, eventHubName, consumerGroup);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            List<PartitionOwnership> result = null;

            try
            {
                var prefix = string.Format(OwnershipPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());

                Func<CancellationToken, Task<List<PartitionOwnership>>> listOwnershipAsync = async listOwnershipToken =>
                {
                    var ownershipList = new List<PartitionOwnership>();

                    await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, cancellationToken: listOwnershipToken).ConfigureAwait(false))
                    {
                        // In case this key does not exist, ownerIdentifier is set to null.  This will force the PartitionOwnership constructor
                        // to throw an exception.

                        blob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

                        ownershipList.Add(new PartitionOwnership(
                            fullyQualifiedNamespace,
                            eventHubName,
                            consumerGroup,
                            ownerIdentifier,
                            blob.Name.Substring(prefix.Length),
                            blob.Properties.LastModified,
                            blob.Properties.ETag.ToString()
                        ));
                    }

                    return ownershipList;
                };

                result = await ApplyRetryPolicy(listOwnershipAsync, cancellationToken);
                return result;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                Logger.ListOwnershipAsyncError(fullyQualifiedNamespace, eventHubName, consumerGroup, ex.ToString());
                throw new RequestFailedException(Resources.BlobsResourceDoesNotExist);
            }
            finally
            {
                Logger.ListOwnershipAsyncComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, result?.Count ?? 0);
            }
        }

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership.</returns>
        ///
        public override async Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership,
                                                                                        CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var claimedOwnership = new List<PartitionOwnership>();
            var metadata = new Dictionary<string, string>();

            Response<BlobContentInfo> contentInfoResponse;
            Response<BlobInfo> infoResponse;

            foreach (PartitionOwnership ownership in partitionOwnership)
            {
                metadata[BlobMetadataKey.OwnerIdentifier] = ownership.OwnerIdentifier;

                var blobRequestConditions = new BlobRequestConditions();

                var blobName = string.Format(OwnershipPrefix + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLowerInvariant(), ownership.EventHubName.ToLowerInvariant(), ownership.ConsumerGroup.ToLowerInvariant());
                var blobClient = ContainerClient.GetBlobClient(blobName);

                try
                {
                    // Even though documentation states otherwise, we cannot use UploadAsync when the blob already exists in
                    // the current storage SDK.  For this reason, we are using the specified ETag as an indication of what
                    // method to use.

                    if (ownership.ETag == null)
                    {
                        blobRequestConditions.IfNoneMatch = new ETag("*");

                        Func<CancellationToken, Task<Response<BlobContentInfo>>> uploadBlobAsync = async uploadToken =>
                        {
                            using var blobContent = new MemoryStream(Array.Empty<byte>());

                            try
                            {
                                return await blobClient.UploadAsync(blobContent, metadata: metadata, conditions: blobRequestConditions, cancellationToken: uploadToken).ConfigureAwait(false);
                            }
                            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                            {
                                // A blob could have just been created by another Event Processor that claimed ownership of this
                                // partition.  In this case, there's no point in retrying because we don't have the correct ETag.

                                Logger.OwnershipNotClaimable(ownership.PartitionId, ownership.OwnerIdentifier);
                                return null;
                            }
                        };

                        contentInfoResponse = await ApplyRetryPolicy(uploadBlobAsync, cancellationToken).ConfigureAwait(false);

                        if (contentInfoResponse == null)
                        {
                            continue;
                        }

                        ownership.LastModifiedTime = contentInfoResponse.Value.LastModified;
                        ownership.ETag = contentInfoResponse.Value.ETag.ToString();
                    }
                    else
                    {
                        blobRequestConditions.IfMatch = new ETag(ownership.ETag);

                        Func<CancellationToken, Task<Response<BlobInfo>>> overwriteBlobAsync = uploadToken =>
                            blobClient.SetMetadataAsync(metadata, blobRequestConditions, uploadToken);

                        infoResponse = await ApplyRetryPolicy(overwriteBlobAsync, cancellationToken).ConfigureAwait(false);

                        ownership.LastModifiedTime = infoResponse.Value.LastModified;
                        ownership.ETag = infoResponse.Value.ETag.ToString();
                    }

                    // Small workaround to retrieve the eTag.  The current storage SDK returns it enclosed in
                    // double quotes ('"ETAG_VALUE"' instead of 'ETAG_VALUE').

                    var match = DoubleQuotesExpression.Match(ownership.ETag);

                    if (match.Success)
                    {
                        ownership.ETag = match.Groups[1].ToString();
                    }

                    claimedOwnership.Add(ownership);

                    Logger.OwnershipClaimed(ownership.PartitionId, ownership.OwnerIdentifier);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    Logger.OwnershipNotClaimable(ownership.PartitionId, ownership.OwnerIdentifier, ex.ToString());
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound || ex.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    throw new RequestFailedException(Resources.BlobsResourceDoesNotExist);
                }
            }

            return claimedOwnership;
        }

        /// <summary>
        ///   Retrieves a list of all the checkpoints in a data store for a given namespace, Event Hub and consumer group.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing all the existing checkpoints for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<Checkpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                                 string eventHubName,
                                                                                 string consumerGroup,
                                                                                 CancellationToken cancellationToken)
        {
            Logger.ListCheckpointsAsyncStart(fullyQualifiedNamespace, eventHubName, consumerGroup);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var prefix = string.Format(CheckpointPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());

            Func<CancellationToken, Task<IEnumerable<Checkpoint>>> listCheckpointsAsync = async listCheckpointsToken =>
            {
                var checkpoints = new List<Checkpoint>();

                await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, cancellationToken: listCheckpointsToken).ConfigureAwait(false))
                {
                    long offset = 0;
                    long sequenceNumber = 0;

                    if (blob.Metadata.TryGetValue(BlobMetadataKey.Offset, out var str) && long.TryParse(str, out var result))
                    {
                        offset = result;
                    }

                    if (blob.Metadata.TryGetValue(BlobMetadataKey.SequenceNumber, out str) && long.TryParse(str, out result))
                    {
                        sequenceNumber = result;
                    }

                    checkpoints.Add(new Checkpoint(
                        fullyQualifiedNamespace,
                        eventHubName,
                        consumerGroup,
                        blob.Name.Substring(prefix.Length),
                        offset,
                        sequenceNumber
                    ));
                }

                Logger.ListCheckpointsAsyncComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, checkpoints.Count);
                return checkpoints;
            };

            try
            {
                return await ApplyRetryPolicy(listCheckpointsAsync, cancellationToken);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                throw new RequestFailedException(Resources.BlobsResourceDoesNotExist);
            }
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the storage blob service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override async Task UpdateCheckpointAsync(Checkpoint checkpoint,
                                                         CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var blobName = string.Format(CheckpointPrefix + checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace.ToLowerInvariant(), checkpoint.EventHubName.ToLowerInvariant(), checkpoint.ConsumerGroup.ToLowerInvariant());
            var blobClient = ContainerClient.GetBlobClient(blobName);

            var metadata = new Dictionary<string, string>()
            {
                { BlobMetadataKey.Offset, checkpoint.Offset.ToString() },
                { BlobMetadataKey.SequenceNumber, checkpoint.SequenceNumber.ToString() }
            };

            Func<CancellationToken, Task> updateCheckpointAsync = async updateCheckpointToken =>
            {
                using var blobContent = new MemoryStream(Array.Empty<byte>());
                await blobClient.UploadAsync(blobContent, metadata: metadata, cancellationToken: updateCheckpointToken);
            };

            try
            {
                await ApplyRetryPolicy(updateCheckpointAsync, cancellationToken);
                Logger.CheckpointUpdated(checkpoint.PartitionId);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                Logger.CheckpointUpdateError(checkpoint.PartitionId, ex.ToString());
                throw new RequestFailedException(Resources.BlobsResourceDoesNotExist);
            }
        }

        /// <summary>
        ///   Applies the checkpoint store's <see cref="RetryPolicy" /> to a specified function.
        /// </summary>
        ///
        /// <param name="functionToRetry">The function to which the retry policy should be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The value returned by the function to which the retry policy has been applied.</returns>
        ///
        private async Task ApplyRetryPolicy(Func<CancellationToken, Task> functionToRetry,
                                            CancellationToken cancellationToken)
        {
            var failedAttemptCount = 0;
            var retryDelay = default(TimeSpan?);
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);

            var stopWatch = Stopwatch.StartNew();

            while (!cancellationToken.IsCancellationRequested)
            {
                using var timeoutTokenSource = new CancellationTokenSource(tryTimeout);

                try
                {
                    using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutTokenSource.Token);

                    await functionToRetry(linkedTokenSource.Token).ConfigureAwait(false);

                    return;
                }
                catch (Exception ex)
                {
                    // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                    // Otherwise, mark the exception as active and break out of the loop.

                    ++failedAttemptCount;
                    retryDelay = RetryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                    if ((retryDelay.HasValue) && (!cancellationToken.IsCancellationRequested))
                    {
                        await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);

                        tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                        stopWatch.Reset();
                    }
                    else
                    {
                        timeoutTokenSource.Token.ThrowIfCancellationRequested<TimeoutException>();
                        throw;
                    }
                }
            }

            // If no value has been returned nor exception thrown by this point,
            // then cancellation has been requested.

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Applies the checkpoint store's <see cref="RetryPolicy" /> to a specified function.
        /// </summary>
        ///
        /// <param name="functionToRetry">The function to which the retry policy should be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <typeparam name="T">The type returned by the function to be executed.</typeparam>
        ///
        /// <returns>The value returned by the function to which the retry policy has been applied.</returns>
        ///
        private async Task<T> ApplyRetryPolicy<T>(Func<CancellationToken, Task<T>> functionToRetry,
                                                  CancellationToken cancellationToken)
        {
            // This method wraps a Func<CancellationToken, Task<T>> inside a Func<CancellationToken, Task>
            // so we can make use of the other ApplyRetryPolicy method without repeating code.

            T result = default;

            Func<CancellationToken, Task> wrapper = async token =>
            {
                result = await functionToRetry(token);
            };

            await ApplyRetryPolicy(wrapper, cancellationToken);

            return result;
        }
    }
}
