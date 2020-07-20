// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal interface IBlobCausalityReader
    {
        Task<Guid?> GetWriterAsync(ICloudBlob blob, CancellationToken cancellationToken);
    }
}
