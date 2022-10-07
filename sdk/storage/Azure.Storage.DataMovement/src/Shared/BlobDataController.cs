// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Controller the data moving from Blobs to destination
    /// </summary>
    public class BlobDataController : DataController
    {
        private List<DataTransfer> _dataTransfers;
        /// <summary>
        /// Constructor
        /// </summary>
        public BlobDataController()
        {
            _dataTransfers = new List<DataTransfer>();
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <returns></returns>
        public DataTransfer StartTransfer(StorageResource sourceResource, StorageResource destinationResource)
        {
            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            if (sourceResource.CanProduceUri() == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Upload Operation
                    // BlobTransferUploadJob();
                    throw new NotImplementedException();
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
            DataTransfer dataTransfer = new DataTransfer("");
            _dataTransfers.Add(dataTransfer);
            return dataTransfer;
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <returns></returns>
        public DataTransfer StartTransfer(StorageResourceContainer sourceResource, StorageResourceContainer destinationResource)
        {
            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            if (sourceResource.CanProduceUri() == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri() == ProduceUriType.ProducesUri)
                {
                    // Upload Operation
                    // BlobTransferUploadJob();
                    throw new NotImplementedException();
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
                }
                else
                {
                    // Download to local operation
                    // BlobDownloadJob();
                }
            }
            DataTransfer dataTransfer = new DataTransfer("");
            _dataTransfers.Add(dataTransfer);
            return dataTransfer;
        }

        private DataTransfer transferViaUri(StorageResource from, StorageResource to)
        {
            throw new NotImplementedException();
        }

        private DataTransfer transferViaStream(StorageResource from, StorageResource to)
        {
            throw new NotImplementedException();
        }
    }
}
