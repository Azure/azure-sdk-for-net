// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Infrastructure
{
    public abstract class DownloadSasUriTest<TOptions> : ContainerTest<TOptions> where TOptions : SizeOptions
    {
        private readonly BlobClient _blobClient;

        protected Uri SasUri { get; private set; }

        public DownloadSasUriTest(TOptions options) : base(options)
        {
            _blobClient = BlobContainerClient.GetBlobClient("_blobName");

            var sharedKeyBlobClient = new BlobClient(_blobClient.Uri, StorageSharedKeyCredential);

            if (sharedKeyBlobClient.CanGenerateSasUri)
            {
                var sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = _blobClient.GetParentBlobContainerClient().Name,
                    BlobName = _blobClient.Name,
                    Resource = "b",
                    ExpiresOn = DateTimeOffset.UtcNow.AddDays(1),
                };

                sasBuilder.SetPermissions(BlobSasPermissions.Read);

                SasUri = sharedKeyBlobClient.GenerateSasUri(sasBuilder);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            using var stream = RandomStream.Create(Options.Size);
            await _blobClient.UploadAsync(stream);
        }
    }
}
