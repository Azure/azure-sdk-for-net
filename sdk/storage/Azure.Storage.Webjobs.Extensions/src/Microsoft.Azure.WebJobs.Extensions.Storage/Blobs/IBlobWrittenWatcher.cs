// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal interface IBlobWrittenWatcher
    {
        void Notify(ICloudBlob blobWritten);
    }
}
