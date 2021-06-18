// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobTransferJob : StorageTransferJob
    {
        private string _localPath;

        public string localPath => _localPath;

        private BlobBaseClient _blobClient;

        public BlobTransferJob(string localpath, BlobBaseClient client)
        {
            _blobClient = client.CloneClient();
        }
    }
}
