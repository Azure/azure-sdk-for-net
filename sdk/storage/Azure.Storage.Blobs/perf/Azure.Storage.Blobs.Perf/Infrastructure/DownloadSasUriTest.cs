// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Infrastructure
{
    public abstract class DownloadSasUriTest<TOptions> : BlobTest<TOptions> where TOptions : SizeOptions
    {
        protected Uri SasUri { get; private set; }

        public DownloadSasUriTest(TOptions options)
            : base(options, createBlob: true, singletonBlob: true)
        {
            var sharedKeyBlobClient = new BlobClient(BlobClient.Uri, StorageSharedKeyCredential);

            if (sharedKeyBlobClient.CanGenerateSasUri)
            {
                SasUri = sharedKeyBlobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddDays(1));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
