// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // $$$ Delete this; unused - mock the ICloudBlob instead
    internal interface IBlobETagReader
    {
        Task<string> GetETagAsync(BlobBaseClient blob, CancellationToken cancellationToken);
    }
}
