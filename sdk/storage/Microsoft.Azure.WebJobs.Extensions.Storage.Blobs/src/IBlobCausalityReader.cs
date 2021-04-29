// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal interface IBlobCausalityReader
    {
        Task<Guid?> GetWriterAsync(BlobBaseClient blob, CancellationToken cancellationToken);
    }
}
