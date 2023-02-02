// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;
using System.Linq;

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
            TransferCheckpointer CheckPointFolderPath,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  CheckPointFolderPath,
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
                    UriToStreamJobPart part = new UriToStreamJobPart(this, partNumber);
                    _jobParts.Add(part);
                    yield return part;
                }
                else
                {
                    // Call listing operation on the source container
                    await foreach (StorageResource resource
                        in _sourceResourceContainer.GetStorageResourcesAsync(
                            cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false))
                    {
                        // Pass each storage resource found in each list call
                        string sourceName = resource.Path.Substring(_sourceResourceContainer.Path.Length + 1);
                        UriToStreamJobPart part = new UriToStreamJobPart(
                            job: this,
                            partNumber: partNumber,
                            sourceResource: resource,
                            destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName),
                            length: resource.Length);
                        _jobParts.Add(part);

                        yield return part;
                        partNumber++;
                    }
                }
            }
            else
            {
                // Resuming old job with existing job parts
                foreach (JobPartInternal part in _jobParts)
                {
                    // Skip over job parts that have already completed. If they were in a failed
                    // or skipped state we can retry them.
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
