// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class UriToStreamTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal UriToStreamTransferJob(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            SingleTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job for container transfer
        /// </summary>
        internal UriToStreamTransferJob(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ContainerTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool)
        {
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public override async IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync()
        {
            JobPartStatusEvents += JobPartEvent;
            await OnJobStatusChangedAsync(StorageTransferStatus.InProgress).ConfigureAwait(false);
            int partNumber = 0;

            if (_jobParts.Count == 0)
            {
                // Starting brand new job
                if (_isSingleResource)
                {
                    // Single resource transfer, we can skip to chunking the job.
                    UriToStreamJobPart part = await UriToStreamJobPart.CreateJobPartAsync(
                        job: this,
                        partNumber: partNumber,
                        isFinalPart: true).ConfigureAwait(false);
                    _jobParts.Add(part);
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
                    if (part.JobPartStatus != StorageTransferStatus.Completed)
                    {
                        part.JobPartStatus = StorageTransferStatus.Queued;
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
                    await foreach (JobPartInternal part in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return part;
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
            StorageResource lastResource = default;
            await foreach (StorageResource resource
                in _sourceResourceContainer.GetStorageResourcesAsync(
                    cancellationToken: _cancellationToken).ConfigureAwait(false))
            {
                if (lastResource != default)
                {
                    string sourceName = lastResource.Path.Substring(_sourceResourceContainer.Path.Length + 1);
                    if (!existingSources.Contains(sourceName))
                    {
                        // Because AsyncEnumerable doesn't let us know which storage resource is the last resource
                        // we only yield return when we know this is not the last storage resource to be listed
                        // from the container.
                        UriToStreamJobPart part = await UriToStreamJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNumber,
                            sourceResource: lastResource,
                            destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName),
                            isFinalPart: false).ConfigureAwait(false);
                        _jobParts.Add(part);
                        yield return part;
                        partNumber++;
                    }
                }
                lastResource = resource;
            }
            // It's possible to have no job parts in a job
            if (lastResource != default)
            {
                // Return last part but enable the part to be the last job part of the entire job
                // so we know that we've finished listing in the container
                string lastSourceName = lastResource.Path.Substring(_sourceResourceContainer.Path.Length + 1);
                UriToStreamJobPart lastPart = await UriToStreamJobPart.CreateJobPartAsync(
                        job: this,
                        partNumber: partNumber,
                        sourceResource: lastResource,
                        destinationResource: _destinationResourceContainer.GetChildStorageResource(lastSourceName),
                        isFinalPart: true).ConfigureAwait(false);
                _jobParts.Add(lastPart);
                yield return lastPart;
            }
        }
    }
}
