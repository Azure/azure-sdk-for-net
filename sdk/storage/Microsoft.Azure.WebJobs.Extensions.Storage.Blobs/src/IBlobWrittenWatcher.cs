// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal interface IBlobWrittenWatcher
    {
        void Notify(BlobWithContainer<BlobBaseClient> blobWritten);
    }
}
