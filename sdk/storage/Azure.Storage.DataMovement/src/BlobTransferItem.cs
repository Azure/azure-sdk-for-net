using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Blob Transfer Job
    /// </summary>
    internal class BlobTransferItem : StorageTransferItem
    {
        private BlobTransferJob _transferJob;

        public BlobTransferJob TransferJob => _transferJob;

        public BlobTransferItem(BlobTransferJob transferJob)
        {
            _transferJob = transferJob;
        }
    }
}
