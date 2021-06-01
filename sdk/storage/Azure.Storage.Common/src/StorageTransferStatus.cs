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
        public long bytesTransferred { get; set; }

        /// <summary>
        /// Number of Files or Blobs tranferred.
        /// </summary>
        public long successfulTransfers { get; internal set; }

        // TODO: failures and skips
    }
}
