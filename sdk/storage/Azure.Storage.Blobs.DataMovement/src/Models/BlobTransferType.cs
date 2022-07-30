// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Defines the type of transfer the job is performing.
    /// This is used in the <see cref="BlobTransferJobProperties"/>.
    /// </summary>
    public class BlobTransferType
    {
        /// <summary>
        /// Resource Type to transfer
        /// </summary>
        public enum ResourceType
        {
            /// <summary>
            /// Folder transfer
            /// </summary>
            BlobFolder = 1,

            /// <summary>
            /// Single Blob transfer. (Default)
            /// </summary>
            Blob = 0,
        }

        /// <summary>
        /// Operation Transfer Type
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// For Blobs sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">Copy Blob</see>
            /// for blob operations. This utilizes the
            /// <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blobbaseclient.startcopyfromuri?view=azure-dotnet">BlobBaseClient.StartCopyFromUri</see>
            /// </summary>
            Copy = 5,

            /// <summary>
            /// For blobs sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>
            /// if we know the blob size and it's less than 256 MiB. Otherwise we send n amount of
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
            /// </summary>
            SyncCopy = 4,

            /// <summary>
            /// For blobs we will essentially download the blob (or each block of the blob ) to a local temporary destination, then upload the blob (or block)
            /// to the destination blob (or block).
            /// </summary>
            DownloadThenUploadCopy = 3,

            /// <summary>
            /// For block blob sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>
            /// if we know the blob size and it's less than 256 MiB. Otherwise we send n amount of
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
            ///
            /// This method utilizes <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blockblobclient.syncuploadfromuri?view=azure-dotnet#azure-storage-blobs-specialized-blockblobclient-syncuploadfromuri(system-uri-azure-storage-blobs-models-blobsyncuploadfromurioptions-system-threading-cancellationtoken)">BlockBlobClient.SyncUploadFromUri</see>
            /// </summary>
            UploadFromUriCopy = 2,

            /// <summary>
            /// Download
            /// </summary>
            Download = 1,

            /// <summary>
            /// Upload
            /// </summary>
            Upload = ~0
        }

        /// <summary>
        /// Resource Type
        /// </summary>
        public ResourceType Resource { get; internal set; }

        /// <summary>
        /// Operation Type
        /// </summary>
        public OperationType Operation { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BlobTransferType()
        {
        }
    }
}
