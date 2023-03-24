// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class DownloadBlob : ContainerRegistryPerfTest
    {
        private readonly ContainerRegistryContentClient _client;

        private string _digest;

        public DownloadBlob(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryContentClient(new Uri(PerfTestEnvironment.Instance.Endpoint), ContainerRegistryPerfTest.RepositoryName, PerfTestEnvironment.Instance.Credential);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            using Stream stream = new MemoryStream(GetRandomBuffer(BlobSize));
            UploadRegistryBlobResult result = await _client.UploadBlobAsync(stream);
            _digest = result.Digest;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            using Stream stream = new MemoryStream();

            _client.DownloadBlobTo(_digest, stream, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using Stream stream = new MemoryStream();

            await _client.DownloadBlobToAsync(_digest, stream, cancellationToken);
        }
    }
}
