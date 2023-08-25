// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    internal class UriToStreamTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal UriToStreamTransferJob(
            DataTransfer dataTransfer,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job for container transfer
        /// </summary>
        internal UriToStreamTransferJob(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public override async IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync()
        {
            await OnJobStatusChangedAsync(DataTransferStatus.InProgress).ConfigureAwait(false);
            int partNumber = 0;

            if (_jobParts.Count == 0)
            {
                // Starting brand new job
                if (_isSingleResource)
                {
                    UriToStreamJobPart part = default;
                    try
                    {
                        // Single resource transfer, we can skip to chunking the job.
                        part = await UriToStreamJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNumber,
                            isFinalPart: true).ConfigureAwait(false);
                        AppendJobPart(part);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                        yield break;
                    }
                    yield return part;
                }
                else
                {
                    await foreach (JobPartInternal part in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return part;
                    }
                }
            }
            else
            {
                // Resuming old job with existing job parts
                bool isFinalPartFound = false;
                foreach (JobPartInternal part in _jobParts)
                {
                    if (part.JobPartStatus != DataTransferStatus.Completed)
                    {
                        part.JobPartStatus = DataTransferStatus.Queued;
                        yield return part;

                        if (part.IsFinalPart)
                        {
                            // If we found the final part then we don't have to relist the container.
                            isFinalPartFound = true;
                        }
                    }
                }
                if (!isFinalPartFound)
                {
                    await foreach (JobPartInternal jobPartInternal in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return jobPartInternal;
                    }
                }
            }
            _enumerationComplete = true;
            await OnEnumerationComplete().ConfigureAwait(false);
        }

        private async IAsyncEnumerable<JobPartInternal> GetStorageResourcesAsync()
        {
            // Start the partNumber based on the last part number. If this is a new job,
            // the count will automatically be at 0 (the beginning).
            int partNumber = _jobParts.Count;
            List<string> existingSources = GetJobPartSourceResourcePaths();
            // Call listing operation on the source container
            IAsyncEnumerator<StorageResource> enumerator;

            // Obtain enumerator and check for any point of failure before we attempt to list
            // and fail gracefully.
            try
            {
                enumerator = _sourceResourceContainer.GetStorageResourcesAsync(
                        cancellationToken: _cancellationToken).GetAsyncEnumerator();
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                yield break;
            }

            // List the container keep track of the last job part in order to store it properly
            // so we know we finished enumerating/listed.
            bool enumerationCompleted = false;
            StorageResource lastResource = default;
            while (!enumerationCompleted)
            {
                try
                {
                    if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        enumerationCompleted = true;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }

                StorageResource current = enumerator.Current;
                if (lastResource != default)
                {
                    string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                    string sourceName = string.IsNullOrEmpty(containerUriPath)
                        ? lastResource.Uri.GetPath()
                        : lastResource.Uri.GetPath().Substring(containerUriPath.Length + 1);

                    if (!existingSources.Contains(sourceName))
                    {
                        // Because AsyncEnumerable doesn't let us know which storage resource is the last resource
                        // we only yield return when we know this is not the last storage resource to be listed
                        // from the container.
                        UriToStreamJobPart part;
                        try
                        {
                            part = await UriToStreamJobPart.CreateJobPartAsync(
                                job: this,
                                partNumber: partNumber,
                                sourceResource: (StorageResourceItem)lastResource,
                                destinationResource: _destinationResourceContainer.GetStorageResourceReference(sourceName),
                                isFinalPart: false).ConfigureAwait(false);
                            AppendJobPart(part);
                        }
                        catch (Exception ex)
                        {
                            await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                            yield break;
                        }
                        yield return part;
                        partNumber++;
                    }
                }
                lastResource = current;
            }

            // It's possible to have no job parts in a job
            if (lastResource != default)
            {
                UriToStreamJobPart lastPart;
                try
                {
                    // Return last part but enable the part to be the last job part of the entire job
                    // so we know that we've finished listing in the container
                    string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                    string lastSourceName = string.IsNullOrEmpty(containerUriPath)
                        ? lastResource.Uri.GetPath()
                        : lastResource.Uri.GetPath().Substring(containerUriPath.Length + 1);

                    lastPart = await UriToStreamJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNumber,
                            sourceResource: (StorageResourceItem) lastResource,
                            destinationResource: _destinationResourceContainer.GetStorageResourceReference(lastSourceName),
                            isFinalPart: true).ConfigureAwait(false);
                    AppendJobPart(lastPart);
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }
                yield return lastPart;
            }
        }
    }
}
