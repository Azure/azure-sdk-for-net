// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal class BlobCausalityReader : IBlobCausalityReader
    {
        private static readonly BlobCausalityReader Singleton = new BlobCausalityReader();

        private BlobCausalityReader()
        {
        }

        public static BlobCausalityReader Instance
        {
            get { return Singleton; }
        }

        public Task<Guid?> GetWriterAsync(ICloudBlob blob, CancellationToken cancellationToken)
        {
            return BlobCausalityManager.GetWriterAsync(blob, cancellationToken);
        }
    }
}
