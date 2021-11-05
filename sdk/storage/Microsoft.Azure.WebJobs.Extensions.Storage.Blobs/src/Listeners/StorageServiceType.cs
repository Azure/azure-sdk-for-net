// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Enumerates possible values of the requested storage service field declared by
    /// Storage Analytics Log format.
    /// </summary>
    internal enum StorageServiceType
    {
        Blob,
        Queue
    }
}
