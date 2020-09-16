﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;
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

        public Task<Guid?> GetWriterAsync(BlobBaseClient blob, CancellationToken cancellationToken)
        {
            return BlobCausalityManager.GetWriterAsync(blob, cancellationToken);
        }
    }
}
