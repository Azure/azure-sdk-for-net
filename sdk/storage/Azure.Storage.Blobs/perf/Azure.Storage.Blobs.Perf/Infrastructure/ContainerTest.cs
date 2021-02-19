﻿//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class ContainerTest<TOptions> : ServiceTest<TOptions> where TOptions : PerfOptions
    {
        // See https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata for
        // restrictions on blob containers and blob storage naming.
        protected static string ContainerName { get; } = $"ContainerTest-{Guid.NewGuid()}".ToLowerInvariant();

        protected BlobContainerClient BlobContainerClient { get; private set; }

        public ContainerTest(TOptions options) : base(options)
        {
            BlobContainerClient = BlobServiceClient.GetBlobContainerClient(ContainerName);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await BlobContainerClient.CreateAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            await BlobContainerClient.DeleteAsync();
            await base.GlobalCleanupAsync();
        }
    }
}
