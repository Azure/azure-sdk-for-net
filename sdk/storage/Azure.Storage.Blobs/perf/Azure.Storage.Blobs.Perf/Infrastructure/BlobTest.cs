// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class BlobTest<TOptions> : ContainerTest<TOptions> where TOptions : SizeOptions
    {
        private readonly bool _createBlob;
        private readonly bool _singletonBlob;

        protected string BlobName { get; }
        protected BlobClient BlobClient { get; private set; }

        /// <param name="options">Test options.</param>
        /// <param name="createBlob">Whether to create the blob on the service during setup.</param>
        /// <param name="singletonBlob">Whether to use a global blob vs individual blobs.</param>
        public BlobTest(TOptions options, bool createBlob, bool singletonBlob) : base(options)
        {
            BlobName = "Azure.Storage.Blobs.Perf.BlobTest" + (singletonBlob ? "" : $"-{Guid.NewGuid()}");
            BlobClient = BlobContainerClient.GetBlobClient(BlobName);

            _createBlob = createBlob;
            _singletonBlob = singletonBlob;
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            if (_createBlob && _singletonBlob)
            {
                await CreateBlobAsync();
            }
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            if (_createBlob && !_singletonBlob)
            {
                await CreateBlobAsync();
            }
        }

        private async Task CreateBlobAsync()
        {
            using Stream stream = RandomStream.Create(Options.Size);
            // No need to delete file in cleanup, since ContainerTest.GlobalCleanup() deletes the whole container
            await BlobClient.UploadAsync(stream, overwrite: true);
        }
    }
}
