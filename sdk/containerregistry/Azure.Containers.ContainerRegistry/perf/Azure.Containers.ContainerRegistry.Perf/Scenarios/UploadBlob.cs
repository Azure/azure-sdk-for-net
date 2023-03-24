// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class UploadBlob : ContainerRegistryPerfTest
    {
        private readonly ContainerRegistryContentClient _client;

        public UploadBlob(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryContentClient(new Uri(PerfTestEnvironment.Instance.Endpoint), ContainerRegistryPerfTest.RepositoryName, PerfTestEnvironment.Instance.Credential);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            using Stream stream = new MemoryStream(GetRandomBuffer(BlobSize));

            _client.UploadBlob(stream, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using Stream stream = new MemoryStream(GetRandomBuffer(BlobSize));

            await _client.UploadBlobAsync(stream, cancellationToken);
        }
    }
}
