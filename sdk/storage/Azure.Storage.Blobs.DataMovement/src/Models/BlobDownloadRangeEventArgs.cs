// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    internal class BlobDownloadRangeEventArgs : StorageTransferEventArgs
    {
        public bool Success { get; }

        public long Offset { get; }

        /// <summary>
        /// Will be 0 if Success is false
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Stream results of the range downloaded
        /// </summary>
        public BlobDownloadStreamingResult Result { get;  }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="success"></param>
        /// <param name="offset"></param>
        /// <param name="result"></param>
        /// <param name="bytesTransferred"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public BlobDownloadRangeEventArgs(
            string transferId,
            bool success,
            long offset,
            long bytesTransferred,
            BlobDownloadStreamingResult result,
            bool isRunningSynchronously,
            CancellationToken cancellationToken) :
            base(transferId, isRunningSynchronously, cancellationToken)
        {
            Success = success;
            Offset = offset;
            BytesTransferred = bytesTransferred;
            Result = result;
        }
    }
}
