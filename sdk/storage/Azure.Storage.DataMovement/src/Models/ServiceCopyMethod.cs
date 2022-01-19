// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Copy Method.
    /// Users can specify what type copy to occur.
    /// </summary>
    public enum ServiceCopyMethod
    {
        /// <summary>
        /// For Blobs sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">Copy Blob</see>
        /// for blob operations. This utilizes the
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blobbaseclient.startcopyfromuri?view=azure-dotnet">BlobBaseClient.StartCopyFromUri</see>
        /// For SMB Files <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-file">Copy File</see>
        /// </summary>
        ServiceSideAsyncCopy,

        /// <summary>
        /// For block blob sends <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>
        /// if we know the blob size and it's less than 256 MiB. Otherwise we send n amount of
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
        /// for SMB File it will send it <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range-from-url">Put Range From Url</see>
        /// </summary>
        ServiceSideSyncCopy
    }
}
