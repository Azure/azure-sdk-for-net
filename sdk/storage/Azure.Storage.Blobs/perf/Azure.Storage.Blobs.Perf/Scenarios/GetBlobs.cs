//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on listing blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{PerfOptions}" />
    public sealed class GetBlobs : ContainerTest<CountOptions>
    {
        public GetBlobs(CountOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            var uploadTasks = new Task[Options.Count];
            for (var i = 0; i < uploadTasks.Length; i++)
            {
                var blobName = $"Azure.Storage.Blobs.Perf.Scenarios.DownloadBlob-{Guid.NewGuid()}";
                uploadTasks[i] = BlobContainerClient.GetBlobClient(blobName).UploadAsync(Stream.Null, overwrite: true);
            }
            await Task.WhenAll(uploadTasks);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            // Enumerate collection to ensure all BlobItems are downloaded
            foreach (var _ in BlobContainerClient.GetBlobs(cancellationToken: cancellationToken))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            // Enumerate collection to ensure all BlobItems are downloaded
            await foreach (var _ in BlobContainerClient.GetBlobsAsync(cancellationToken: cancellationToken))
            {
            }
        }
    }
}
