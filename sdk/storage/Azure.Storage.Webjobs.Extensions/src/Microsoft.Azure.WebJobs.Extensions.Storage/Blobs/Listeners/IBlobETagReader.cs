// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // $$$ Delete this; unused - mock the ICloudBlob instead 
    internal interface IBlobETagReader
    {
        Task<string> GetETagAsync(ICloudBlob blob, CancellationToken cancellationToken);
    }
}
