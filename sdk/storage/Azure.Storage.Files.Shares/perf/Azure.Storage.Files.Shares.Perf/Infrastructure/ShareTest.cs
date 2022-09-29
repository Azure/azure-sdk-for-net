// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf
{
    public abstract class ShareTest<TOptions> : ServiceTest<TOptions> where TOptions : PerfOptions
    {
        // See https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata for
        // restrictions on blob containers and blob storage naming.
        protected static string ShareName { get; } = $"ShareTest-{Guid.NewGuid()}".ToLowerInvariant();

        protected ShareClient ShareClient { get; private set; }

        public ShareTest(TOptions options) : base(options)
        {
            ShareClient = ShareServiceClient.GetShareClient(ShareName);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await ShareClient.CreateIfNotExistsAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            await ShareClient.DeleteIfExistsAsync();
            await base.GlobalCleanupAsync();
        }
    }
}
