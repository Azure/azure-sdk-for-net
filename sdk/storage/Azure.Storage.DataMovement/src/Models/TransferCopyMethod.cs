// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Type Service copy method to specify when performing a service to service transfer.
    /// </summary>
    public enum TransferCopyMethod
    {
        /// <summary>
        /// Default. Will automatically be set to <see cref="SyncCopy"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Default. For blobs sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>
        /// if we know the blob size and it's less than 256 MiB. Otherwise we send n amount of
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
        /// </summary>
        SyncCopy = 1,

        /// <summary>
        /// For Blobs sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">Copy Blob</see>
        /// for blob operations. This utilizes the
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blobbaseclient.startcopyfromuri?view=azure-dotnet">BlobBaseClient.StartCopyFromUri</see>
        ///
        /// For block blob sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>
        /// if we know the blob size and it's less than 256 MiB. Otherwise we send n amount of
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
        ///
        /// This method utilizes <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blockblobclient.syncuploadfromuri?view=azure-dotnet#azure-storage-blobs-specialized-blockblobclient-syncuploadfromuri(system-uri-azure-storage-blobs-models-blobsyncuploadfromurioptions-system-threading-cancellationtoken)">BlockBlobClient.SyncUploadFromUri</see>
        /// </summary>
        AsyncCopy = 2,
    }
}
