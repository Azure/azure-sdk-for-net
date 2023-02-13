// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class CopyStatusEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// The copy status of the get properties request
        /// </summary>
        public ServiceCopyStatus CopyStatus { get; }

        /// <summary>
        /// The copy id
        /// </summary>
        public string CopyId { get; }

        /// <summary>
        /// Current Bytes Transferred
        /// </summary>
        public long CurrentBytesTransferred { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CopyStatusEventArgs(
            string transferId,
            ServiceCopyStatus status,
            string copyId,
            long bytesTransferred,
            bool isRunningSynchronously,
            CancellationToken cancellationToken) :
            base(transferId, isRunningSynchronously, cancellationToken)
        {
            CopyStatus = status;
            CopyId = copyId;
            CurrentBytesTransferred = bytesTransferred;
        }
    }
}
