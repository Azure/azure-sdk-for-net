//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Sas;
using Azure.Test.Perf;
using Azure.Storage.Blobs.Perf.Core;
using System.Threading;
using System.IO;

namespace Azure.Storage.Blobs.Perf
{
    public class StorageDownloadSasUriTest : SasUriTest<SizeOptions>
    {
        private readonly BlobClient _blobClient;

        public StorageDownloadSasUriTest(SizeOptions options) : base(options)
        {
            _blobClient = new BlobClient(SasUri);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _blobClient.DownloadToAsync(Stream.Null, cancellationToken);
        }
    }
}
