// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal interface IBlobWrittenWatcher
    {
        void Notify(BlobWithContainer<BlobBaseClient> blobWritten);
    }
}
