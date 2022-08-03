// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    internal class BlobStageBlockEventArgs : StorageTransferEventArgs
    {
        public bool IsSinglePut { get;}

        public bool Success { get; }

        public long Offset { get; }

        /// <summary>
        /// Will be 0 if Success is false
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isSinglePut"></param>
        /// <param name="transferId"></param>
        /// <param name="success"></param>
        /// <param name="offset"></param>
        /// <param name="bytesTransferred"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public BlobStageBlockEventArgs(
            string transferId,
            bool isSinglePut,
            bool success,
            long offset,
            long bytesTransferred,
            bool isRunningSynchronously,
            CancellationToken cancellationToken) :
            base(transferId, isRunningSynchronously, cancellationToken)
        {
            IsSinglePut = isSinglePut;
            Success = success;
            Offset = offset;
            BytesTransferred = bytesTransferred;
        }
    }
}
