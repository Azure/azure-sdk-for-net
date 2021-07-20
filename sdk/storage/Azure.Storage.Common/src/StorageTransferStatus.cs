// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage
{
    /// <summary>
    /// StorageTransferStatus keeps track of the transfer results
    /// </summary>
    public class StorageTransferStatus
    {
        /// <summary>
        /// Bytes transferred.
        /// </summary>
        public long BytesTransferred { get; internal set;  }

        /// <summary>
        /// Number of Files or Blobs tranferred.
        /// </summary>
        public long SuccessfulTransfers { get; internal set; }

        /// <summary>
        /// Number of files that failed/
        /// </summary>
        public long FailedTransfers { get; internal set; }

        /// <summary>
        /// Number of files that were skipped.
        /// </summary>
        public long SkippedTransfers { get; internal set; }
    }
}
