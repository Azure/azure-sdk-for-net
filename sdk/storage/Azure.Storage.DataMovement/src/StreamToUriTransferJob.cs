// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using System.Buffers;

namespace Azure.Storage.DataMovement
{
    internal class StreamToUriTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal StreamToUriTransferJob(
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
        /// Create Storage Transfer Job.
        /// </summary>
        internal StreamToUriTransferJob(
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
                if (_isSingleResource)
                {
                    // Single resource transfer, we can skip to chunking the job.
                    StreamToUriJobPart part = await StreamToUriJobPart.CreateJobPartAsync(this, partNumber).ConfigureAwait(false);
                    _jobParts.Add(part);
                    yield return part;
                }
                else
                {
                    // Call listing operation on the source container
                    await foreach (StorageResource resource
                        in _sourceResourceContainer.GetStorageResourcesAsync(
                            cancellationToken: _cancellationToken).ConfigureAwait(false))
                    {
                        // Pass each storage resource found in each list call
                        if (!resource.IsContainer)
                        {
                            string sourceName = resource.Path.Substring(_sourceResourceContainer.Path.Length + 1);
                            StreamToUriJobPart part = await StreamToUriJobPart.CreateJobPartAsync(
                                job: this,
                                partNumber: partNumber,
                                sourceResource: resource,
                                destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName)).ConfigureAwait(false);
                            _jobParts.Add(part);
                            yield return part;
                            partNumber++;
                        }
                        // When we have to deal with files we have to manually go and create each subdirectory
                    }
                }
            }
            else
            {
                // Resuming old job with existing job parts
                foreach (JobPartInternal part in _jobParts)
                {
                    if (part.JobPartStatus != StorageTransferStatus.Completed)
                    {
                        part.JobPartStatus = StorageTransferStatus.Queued;
                        yield return part;
                    }
                }
            }
            _enumerationComplete = true;
            await OnEnumerationComplete().ConfigureAwait(false);
        }
    }
}
