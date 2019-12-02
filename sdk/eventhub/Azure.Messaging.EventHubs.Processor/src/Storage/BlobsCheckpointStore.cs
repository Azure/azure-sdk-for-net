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
        public override Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                 string eventHubName,
                                                                                 string consumerGroup,
                                                                                 CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var prefix = string.Format(OwnershipPrefix, fullyQualifiedNamespace.ToLower(), eventHubName.ToLower(), consumerGroup.ToLower());

            Func<CancellationToken, Task<IEnumerable<PartitionOwnership>>> listOwnershipAsync = async listOwnershipToken =>
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

            try
            {
                return ApplyRetryPolicy(listOwnershipAsync, cancellationToken);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                throw new RequestFailedException(Resources.BlobsResourceDoesNotExist);
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

                var blobName = string.Format(OwnershipPrefix + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLower(), ownership.EventHubName.ToLower(), ownership.ConsumerGroup.ToLower());
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

                                // TODO: Add log  - "Ownership with partition id = '{ ownership.PartitionId }' is not claimable."
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

                        Func<CancellationToken, Task<Response<BlobInfo>>> overwriteBlobAsync = async uploadToken =>
                        {
                            try
                            {
                                return await blobClient.SetMetadataAsync(metadata, blobRequestConditions, uploadToken);
                            }
                            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                            {
                                // No ownership was found, which means the ETag should have been set to null in order to
                                // claim this ownership.  For this reason, we consider it a failure and don't try again.

                                // TODO: Add log  - "Ownership with partition id = '{ ownership.PartitionId }' is not claimable."
                                return null;
                            }
                        };

                        infoResponse = await ApplyRetryPolicy(overwriteBlobAsync, cancellationToken).ConfigureAwait(false);

                        if (infoResponse == null)
                        {
                            continue;
                        }

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

                    // TODO: Add log  - "Ownership with partition id = '{ ownership.PartitionId }' claimed."
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    // TODO: Add log  - "Ownership with partition id = '{ ownership.PartitionId }' is not claimable."
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
        public override Task<IEnumerable<Checkpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                           string eventHubName,
                                                                           string consumerGroup,
                                                                           CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var prefix = string.Format(CheckpointPrefix, fullyQualifiedNamespace.ToLower(), eventHubName.ToLower(), consumerGroup.ToLower());

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

                return checkpoints;
            };

            try
            {
                return ApplyRetryPolicy(listCheckpointsAsync, cancellationToken);
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
        public override Task UpdateCheckpointAsync(Checkpoint checkpoint,
                                                   CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var blobName = string.Format(CheckpointPrefix + checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace.ToLower(), checkpoint.EventHubName.ToLower(), checkpoint.ConsumerGroup.ToLower());
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
                return ApplyRetryPolicy(updateCheckpointAsync, cancellationToken);
                // TODO: Add log  - "Checkpoint with partition id = '{ checkpoint.PartitionId }' updated."
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                // TODO: Add log  - "Checkpoint with partition id = '{ checkpoint.PartitionId }' could not be updated because specified container does not exist."
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
