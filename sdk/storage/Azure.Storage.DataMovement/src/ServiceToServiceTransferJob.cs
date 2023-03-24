// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal ServiceToServiceTransferJob(
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
        internal ServiceToServiceTransferJob(
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
            int partNum = 0;
            if (_jobParts.Count == 0)
            {
                if (_isSingleResource)
                {
                    // Single resource transfer, we can skip to chunking the job.
                    ServiceToServiceJobPart part = await ServiceToServiceJobPart.CreateJobPartAsync(
                        job: this,
                        partNumber: partNum).ConfigureAwait(false);
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
                        ServiceToServiceJobPart part = await ServiceToServiceJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNum,
                            sourceResource: resource,
                            destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName),
                            length: resource.Length).ConfigureAwait(false);
                        _jobParts.Add(part);
                        yield return part;
                        partNum++;
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
