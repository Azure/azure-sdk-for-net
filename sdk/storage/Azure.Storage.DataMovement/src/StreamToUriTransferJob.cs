// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using System.Threading.Tasks;
using System.Threading;
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
        /// Gets the status of the transfer job
        /// </summary>
        /// <returns>StorageTransferStatus with the value of the status of the job</returns>
        public override Task PauseTransferJobAsync()
        {
            throw new NotImplementedException();
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
            if (_isSingleResource)
            {
                // Single resource transfer, we can skip to chunking the job.
                StreamToUriJobPart part = new StreamToUriJobPart(
                    dataTransfer: _dataTransfer,
                    sourceResource: _sourceResource,
                    destinationResource: _destinationResource,
                    maximumTransferChunkSize: _maximumTransferChunkSize,
                    initialTransferSize: _initialTransferSize,
                    errorHandling: _errorHandling,
                    checkpointer: _checkpointer,
                    uploadPool: _arrayPool,
                    events: _events,
                    cancellationTokenSource: _cancellationTokenSource);
                _jobParts.Add(part);
                yield return part;
            }
            else
            {
                // Call listing operation on the source container
                await foreach (StorageResource resource
                    in _sourceResourceContainer.ListStorageResources(
                        cancellationToken:_cancellationTokenSource.Token).ConfigureAwait(false))
                {
                    // Pass each storage resource found in each list call
                    StreamToUriJobPart part = new StreamToUriJobPart(
                        dataTransfer: _dataTransfer,
                        sourceResource: resource,
                        destinationResource: _destinationResourceContainer.GetStorageResource(resource.GetPath()),
                        maximumTransferChunkSize: _maximumTransferChunkSize,
                        initialTransferSize: _initialTransferSize,
                        errorHandling: _errorHandling,
                        checkpointer: _checkpointer,
                        uploadPool: _arrayPool,
                        events: _events,
                        cancellationTokenSource: _cancellationTokenSource);
                    _jobParts.Add(part);
                    yield return part;
                }
            }
            if (_jobParts.All((JobPartInternal x) => x.JobPartStatus == StorageTransferStatus.Completed))
            {
                await _events.InvokeTransferStatus(
                    new TransferStatusEventArgs(
                        transferId: _dataTransfer.Id,
                        transferStatus: StorageTransferStatus.Completed,
                        isRunningSynchronously: true,
                        cancellationToken: _cancellationTokenSource.Token)).ConfigureAwait(false);
            }
            else
            {
                // Add event to keep track to make sure we update the main transfer status.
            }
        }
    }
}
