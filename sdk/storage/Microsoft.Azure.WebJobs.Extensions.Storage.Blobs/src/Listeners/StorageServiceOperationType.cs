// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Enumerates the operations that are logged for the corresponding storage service.
    /// </summary>
    /// <remarks>
    /// The only items included here are the ones used by BlobTrigger.
    /// See full list of possible operations at <a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh343260.aspx"/>, but
    /// note that currently it is slightly buggy (PreflightBlobRequest should be BlobPreflightRequest, and GetLeaseInfo
    /// should be GetBlobLeaseInfo).
    /// </remarks>
    internal enum StorageServiceOperationType
    {
        ClearPage,
        CopyBlob,
        CopyBlobDestination,
        SetBlobMetadata,
        SetBlobProperties,
        PutBlob,
        PutBlockList,
        PutPage
    }
}
