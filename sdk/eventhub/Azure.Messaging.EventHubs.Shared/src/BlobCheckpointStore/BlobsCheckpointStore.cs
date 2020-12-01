// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    internal partial class BlobsCheckpointStore : StorageManager
    {
#pragma warning disable CA1802 // Use a constant field
        /// <summary>A message to use when throwing exception when checkpoint container or blob does not exists.</summary>
        private static readonly string BlobsResourceDoesNotExist = "The Azure Storage Blobs container or blob used by the Event Processor Client does not exist.";
#pragma warning restore CA1810

        /// <summary>A regular expression used to capture strings enclosed in double quotes.</summary>
        private static readonly Regex DoubleQuotesExpression = new Regex("\"(.*)\"", RegexOptions.Compiled);

        /// <summary>An ETag value to be used for permissive matching when querying Storage.</summary>
        private static readonly ETag IfNoneMatchAllTag = new ETag("*");

        /// <summary>
        ///   Specifies a string that filters the results to return only checkpoint blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        ///
        private const string CheckpointPrefix = "{0}/{1}/{2}/checkpoint/";

        /// <summary>
        ///   Specifies a string that filters the results to return only ownership blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        ///
        private const string OwnershipPrefix = "{0}/{1}/{2}/ownership/";

        /// <summary>
        ///   The client used to interact with the Azure Blob Storage service.
        /// </summary>
        ///
        private BlobContainerClient ContainerClient { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   <see cref="BlobsCheckpointStore" />.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobsCheckpointStore" /> class.
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
            BlobsCheckpointStoreCreated(nameof(BlobsCheckpointStore), blobContainerClient.AccountName, blobContainerClient.Name);
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the storage blob service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                                     string eventHubName,
                                                                                                     string consumerGroup,
                                                                                                     CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ListOwnershipStart(fullyQualifiedNamespace, eventHubName, consumerGroup);

            List<EventProcessorPartitionOwnership> result = null;

            try
            {
                var prefix = string.Format(CultureInfo.InvariantCulture, OwnershipPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());

                async Task<List<EventProcessorPartitionOwnership>> listOwnershipAsync(CancellationToken listOwnershipToken)
                {
                    var ownershipList = new List<EventProcessorPartitionOwnership>();

                    await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, cancellationToken: listOwnershipToken).ConfigureAwait(false))
                    {
                        // In case this key does not exist, ownerIdentifier is set to null.  This will force the PartitionOwnership constructor
                        // to throw an exception.

                        blob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

                        ownershipList.Add(new EventProcessorPartitionOwnership
                        {
                            FullyQualifiedNamespace = fullyQualifiedNamespace,
                            EventHubName = eventHubName,
                            ConsumerGroup = consumerGroup,
                            OwnerIdentifier = ownerIdentifier,
                            PartitionId = blob.Name.Substring(prefix.Length),
                            LastModifiedTime = blob.Properties.LastModified.GetValueOrDefault(),
                            Version = blob.Properties.ETag.ToString()
                        });
                    }

                    return ownershipList;
                };

                result = await ApplyRetryPolicy(listOwnershipAsync, cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                ListOwnershipError(fullyQualifiedNamespace, eventHubName, consumerGroup, ex);
                throw new RequestFailedException(BlobsResourceDoesNotExist);
            }
            finally
            {
                ListOwnershipComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, result?.Count ?? 0);
            }
        }

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership.</returns>
        ///
        public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> partitionOwnership,
                                                                                                      CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var claimedOwnership = new List<EventProcessorPartitionOwnership>();
            var metadata = new Dictionary<string, string>();

            Response<BlobContentInfo> contentInfoResponse;
            Response<BlobInfo> infoResponse;

            foreach (EventProcessorPartitionOwnership ownership in partitionOwnership)
            {
                ClaimOwnershipStart(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
                metadata[BlobMetadataKey.OwnerIdentifier] = ownership.OwnerIdentifier;

                var blobRequestConditions = new BlobRequestConditions();
                var blobName = string.Format(CultureInfo.InvariantCulture, OwnershipPrefix + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLowerInvariant(), ownership.EventHubName.ToLowerInvariant(), ownership.ConsumerGroup.ToLowerInvariant());
                var blobClient = ContainerClient.GetBlobClient(blobName);

                try
                {
                    // Even though documentation states otherwise, we cannot use UploadAsync when the blob already exists in
                    // the current storage SDK.  For this reason, we are using the specified ETag as an indication of what
                    // method to use.

                    if (ownership.Version == null)
                    {
                        blobRequestConditions.IfNoneMatch = IfNoneMatchAllTag;

                        async Task<Response<BlobContentInfo>> uploadBlobAsync(CancellationToken uploadToken)
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

                                OwnershipNotClaimable(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex.Message);
                                return null;
                            }
                        };

                        contentInfoResponse = await ApplyRetryPolicy(uploadBlobAsync, cancellationToken).ConfigureAwait(false);

                        if (contentInfoResponse == null)
                        {
                            continue;
                        }

                        ownership.LastModifiedTime = contentInfoResponse.Value.LastModified;
                        ownership.Version = contentInfoResponse.Value.ETag.ToString();
                    }
                    else
                    {
                        blobRequestConditions.IfMatch = new ETag(ownership.Version);
                        infoResponse = await ApplyRetryPolicy(uploadToken => blobClient.SetMetadataAsync(metadata, blobRequestConditions, uploadToken), cancellationToken).ConfigureAwait(false);

                        ownership.LastModifiedTime = infoResponse.Value.LastModified;
                        ownership.Version = infoResponse.Value.ETag.ToString();
                    }

                    // Small workaround to retrieve the eTag.  The current storage SDK returns it enclosed in
                    // double quotes ('"ETAG_VALUE"' instead of 'ETAG_VALUE').

                    var match = DoubleQuotesExpression.Match(ownership.Version);

                    if (match.Success)
                    {
                        ownership.Version = match.Groups[1].ToString();
                    }

                    claimedOwnership.Add(ownership);
                    OwnershipClaimed(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    OwnershipNotClaimable(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex.ToString());
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound || ex.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    ClaimOwnershipError(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex);
                    throw new RequestFailedException(BlobsResourceDoesNotExist);
                }
                catch (Exception ex)
                {
                    ClaimOwnershipError(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex);
                    throw;
                }
                finally
                {
                    ClaimOwnershipComplete(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
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
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An enumerable containing all the existing checkpoints for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                                               string eventHubName,
                                                                                               string consumerGroup,
                                                                                               CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ListCheckpointsStart(fullyQualifiedNamespace, eventHubName, consumerGroup);

            var prefix = string.Format(CultureInfo.InvariantCulture, CheckpointPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());
            var checkpointCount = 0;

            async Task<IEnumerable<EventProcessorCheckpoint>> listCheckpointsAsync(CancellationToken listCheckpointsToken)
            {
                var checkpoints = new List<EventProcessorCheckpoint>();

                await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, cancellationToken: listCheckpointsToken).ConfigureAwait(false))
                {
                    var partitionId = blob.Name.Substring(prefix.Length);
                    var startingPosition = default(EventPosition?);
                    var offset = default(long?);
                    var sequenceNumber = default(long?);

                    if (blob.Metadata.TryGetValue(BlobMetadataKey.Offset, out var str) && long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                    {
                        offset = result;
                        startingPosition = EventPosition.FromOffset(result, false);
                    }
                    else if (blob.Metadata.TryGetValue(BlobMetadataKey.SequenceNumber, out str) && long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
                    {
                        sequenceNumber = result;
                        startingPosition = EventPosition.FromSequenceNumber(result, false);
                    }

                    // If either the offset or the sequence number was not populated,
                    // this is not a valid checkpoint.

                    if (startingPosition.HasValue)
                    {
                        checkpoints.Add(new BlobStorageCheckpoint
                        {
                            FullyQualifiedNamespace = fullyQualifiedNamespace,
                            EventHubName = eventHubName,
                            ConsumerGroup = consumerGroup,
                            PartitionId = partitionId,
                            StartingPosition = startingPosition.Value,
                            Offset = offset,
                            SequenceNumber = sequenceNumber
                        });
                    }
                    else
                    {
                        InvalidCheckpointFound(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);
                    }
                }

                checkpointCount = checkpoints.Count;
                return checkpoints;
            };

            try
            {
                return await ApplyRetryPolicy(listCheckpointsAsync, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                ListCheckpointsError(fullyQualifiedNamespace, eventHubName, consumerGroup, ex);
                throw new RequestFailedException(BlobsResourceDoesNotExist);
            }
            catch (Exception ex)
            {
                ListCheckpointsError(fullyQualifiedNamespace, eventHubName, consumerGroup, ex);
                throw;
            }
            finally
            {
                ListCheckpointsComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, checkpointCount);
            }
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the storage blob service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        /// <param name="eventData">The event to use as the basis for the checkpoint's starting position.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override async Task UpdateCheckpointAsync(EventProcessorCheckpoint checkpoint,
                                                         EventData eventData,
                                                         CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            UpdateCheckpointStart(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup);

            var blobName = string.Format(CultureInfo.InvariantCulture, CheckpointPrefix + checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace.ToLowerInvariant(), checkpoint.EventHubName.ToLowerInvariant(), checkpoint.ConsumerGroup.ToLowerInvariant());
            var blobClient = ContainerClient.GetBlobClient(blobName);

            var metadata = new Dictionary<string, string>()
            {
                { BlobMetadataKey.Offset, eventData.Offset.ToString(CultureInfo.InvariantCulture) },
                { BlobMetadataKey.SequenceNumber, eventData.SequenceNumber.ToString(CultureInfo.InvariantCulture) }
            };

            try
            {
                try
                {
                    // Assume the blob is present and attempt to set the metadata.

                    await ApplyRetryPolicy(token => blobClient.SetMetadataAsync(metadata, cancellationToken: token), cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when ((ex.ErrorCode == BlobErrorCode.BlobNotFound) || (ex.ErrorCode == BlobErrorCode.ContainerNotFound))
                {
                    // If the blob wasn't present, fall-back to trying to create a new one.

                    await ApplyRetryPolicy(async token =>
                    {
                        using var blobContent = new MemoryStream(Array.Empty<byte>());
                        await blobClient.UploadAsync(blobContent, metadata: metadata, cancellationToken: token).ConfigureAwait(false);
                    }, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                UpdateCheckpointError(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, ex);
                throw new RequestFailedException(BlobsResourceDoesNotExist);
            }
            catch (Exception ex)
            {
                UpdateCheckpointError(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, ex);
                throw;
            }
            finally
            {
                UpdateCheckpointComplete(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup);
            }
        }

        /// <summary>
        ///   Applies the checkpoint store's <see cref="RetryPolicy" /> to a specified function.
        /// </summary>
        ///
        /// <param name="functionToRetry">The function to which the retry policy should be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The value returned by the function to which the retry policy has been applied.</returns>
        ///
        private async Task ApplyRetryPolicy(Func<CancellationToken, Task> functionToRetry,
                                            CancellationToken cancellationToken)
        {
            TimeSpan? retryDelay;

            var failedAttemptCount = 0;
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);
            var timeoutTokenSource = default(CancellationTokenSource);
            var linkedTokenSource = default(CancellationTokenSource);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    timeoutTokenSource = new CancellationTokenSource(tryTimeout);
                    linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutTokenSource.Token);

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
                    }
                    else
                    {
                        timeoutTokenSource?.Token.ThrowIfCancellationRequested<TimeoutException>();
                        throw;
                    }
                }
                finally
                {
                    timeoutTokenSource?.Dispose();
                    linkedTokenSource?.Dispose();
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
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <typeparam name="T">The type returned by the function to be executed.</typeparam>
        ///
        /// <returns>The value returned by the function to which the retry policy has been applied.</returns>
        ///
        private async Task<T> ApplyRetryPolicy<T>(Func<CancellationToken, Task<T>> functionToRetry,
                                                  CancellationToken cancellationToken)
        {
            var result = default(T);

            async Task wrapper(CancellationToken token)
            {
                result = await functionToRetry(token).ConfigureAwait(false);
            };

            await ApplyRetryPolicy(wrapper, cancellationToken).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="ownershipCount">The amount of ownership received from the storage service.</param>
        ///
        partial void ListOwnershipComplete(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, int ownershipCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of ownership.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void ListOwnershipError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, Exception exception);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        partial void ListOwnershipStart(string fullyQualifiedNamespace, string eventHubName, string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        /// <param name="checkpointCount">The amount of checkpoints received from the storage service.</param>
        ///
        partial void ListCheckpointsComplete(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, int checkpointCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of checkpoints.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void ListCheckpointsError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, Exception exception);

        /// <summary>
        ///   Indicates that invalid checkpoint data was found during an attempt to retrieve a list of checkpoints.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the data is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the data is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the data is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the data is associated with.</param>
        ///
        partial void InvalidCheckpointFound(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        ///
        partial void ListCheckpointsStart(string fullyQualifiedNamespace, string eventHubName, string consumerGroup);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void UpdateCheckpointError(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, Exception exception);

        /// <summary>
        ///   Indicates that an attempt to update a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        partial void UpdateCheckpointComplete(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        partial void UpdateCheckpointStart(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve claim partition ownership has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void ClaimOwnershipComplete(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier);

        /// <summary>
        ///   Indicates that an exception was encountered while attempting to retrieve claim partition ownership.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void ClaimOwnershipError(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier, Exception exception);

        /// <summary>
        ///   Indicates that ownership was unable to be claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="message">The message for the failure.</param>
        ///
        partial void OwnershipNotClaimable(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier, string message);

        /// <summary>
        ///   Indicates that ownership was successfully claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void OwnershipClaimed(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier);

        /// <summary>
        ///   Indicates that an attempt to claim a partition ownership has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void ClaimOwnershipStart(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier);

        /// <summary>
        ///   Indicates that a <see cref="BlobsCheckpointStore" /> was created.
        /// </summary>
        ///
        /// <param name="typeName">The type name for the checkpoint store.</param>
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="containerName">The name of the associated container client.</param>
        ///
        partial void BlobsCheckpointStoreCreated(string typeName, string accountName, string containerName);

        /// <summary>
        ///   Contains the information to reflect the state of event processing for a given Event Hub partition.
        ///   Provides access to the offset and the sequence number retrieved from the blob.
        /// </summary>
        public class BlobStorageCheckpoint : EventProcessorCheckpoint
        {
            public long? Offset { get; set; }
            public long? SequenceNumber { get; set; }
        }
    }
}