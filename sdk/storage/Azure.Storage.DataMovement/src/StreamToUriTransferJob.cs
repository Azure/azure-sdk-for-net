// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using System.Buffers;
using System.Linq;

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
        /// Resume respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public override void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default)
        {
            throw new NotImplementedException();
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
            if (_isSingleResource)
            {
                // Single resource transfer, we can skip to chunking the job.
                StreamToUriJobPart part = new StreamToUriJobPart(this, partNumber);
                _jobParts.Add(part);
                yield return part;
            }
            else
            {
                // Call listing operation on the source container
                await foreach (StorageResource resource
                    in _sourceResourceContainer.GetStorageResourcesAsync(
                        cancellationToken:_cancellationTokenSource.Token).ConfigureAwait(false))
                {
                    // Pass each storage resource found in each list call
                    if (!resource.IsContainer)
                    {
                        string sourceName = resource.Path.Substring(_sourceResourceContainer.Path.Length + 1);
                        StreamToUriJobPart part = new StreamToUriJobPart(
                            job: this,
                            partNumber: partNumber,
                            sourceResource: resource,
                            destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName));
                        _jobParts.Add(part);
                        yield return part;
                        partNumber++;
                    }
                    // When we have to deal with files we have to manually go and create each subdirectory
                }
            }
            _enumerationComplete = true;
            await OnEnumerationComplete().ConfigureAwait(false);
        }
    }
}
