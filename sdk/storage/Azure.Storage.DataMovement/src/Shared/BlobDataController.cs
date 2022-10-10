// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Controller the data moving from Blobs to destination
    /// </summary>
    public class BlobDataController : DataController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlobDataController(DataControllerOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="transferOptions"></param>
        /// <returns></returns>
        public async Task<DataTransfer> StartTransferAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            SingleTransferOptions transferOptions = default)
        {
            if (sourceResource == default)
            {
                throw Errors.ArgumentNull(nameof(sourceResource));
            }
            if (destinationResource == default)
            {
                throw Errors.ArgumentNull(nameof(destinationResource));
            }

            transferOptions = transferOptions == default ? new SingleTransferOptions(): transferOptions;

            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            DataTransfer dataTransfer = new DataTransfer();
            TransferJobInternal transferJobInternal;
            if (sourceResource.CanProduceUri() == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Stream to Uri job (Upload Job)
                    transferJobInternal = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        queueChunkTask: QueueJobChunkAsync,
                        CheckPointFolderPath: Options.CheckPointFolderPath,
                        errorHandling: Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures,
                        arrayPool: _arrayPool);
                    // Queue Job
                    await QueueJobAsync(transferJobInternal).ConfigureAwait(false);
                    _dataTransfers.Add(dataTransfer);
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else if (sourceResource.CanProduceUri() == ProduceUriType.ProducesUri)
            {
                // Source is remote
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Most likely a copy operation.
                    throw new NotImplementedException();
                }
                else
                {
                    // Download to local operation
                    // BlobDownloadJob();
                    throw new NotImplementedException();
                }
            }
            return dataTransfer;
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="transferOptions"></param>
        /// <returns></returns>
        public async Task<DataTransfer> StartTransferAsync(
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ContainerTransferOptions transferOptions = default)
        {
            if (sourceResource == default)
            {
                throw Errors.ArgumentNull(nameof(sourceResource));
            }
            if (destinationResource == default)
            {
                throw Errors.ArgumentNull(nameof(destinationResource));
            }

            transferOptions = transferOptions == default ? new ContainerTransferOptions() : transferOptions;

            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            DataTransfer dataTransfer = new DataTransfer();
            TransferJobInternal transferJobInternal;
            if (sourceResource.CanProduceUri() == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Stream to Uri job (Upload Job)
                    transferJobInternal = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        queueChunkTask: QueueJobChunkAsync,
                        CheckPointFolderPath: Options.CheckPointFolderPath,
                        errorHandling: Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures,
                        arrayPool: _arrayPool);
                    // Queue Job
                    await QueueJobAsync(transferJobInternal).ConfigureAwait(false);
                    _dataTransfers.Add(dataTransfer);
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else if (sourceResource.CanProduceUri() == ProduceUriType.ProducesUri)
            {
                // Source is remote
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Most likely a copy operation.
                    throw new NotImplementedException();
                }
                else
                {
                    // Download to local operation
                    // BlobDownloadJob();
                    throw new NotImplementedException();
                }
            }
            return dataTransfer;
        }
    }
}
