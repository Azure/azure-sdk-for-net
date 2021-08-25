// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Perf.Infrastructure;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public class DownloadSasUriBlobClient : DownloadSasUriTest<SizeOptions>
    {
        private readonly BlobClient _blobClient;

        public DownloadSasUriBlobClient(SizeOptions options) : base(options)
        {
            _blobClient = new BlobClient(SasUri);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _blobClient.DownloadTo(Stream.Null, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _blobClient.DownloadToAsync(Stream.Null, cancellationToken);
        }
    }
}
