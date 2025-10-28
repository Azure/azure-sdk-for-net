// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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

            int maxConcurrent = 500;
            using var semaphore = new SemaphoreSlim(maxConcurrent, maxConcurrent);

            var uploadTasks = Enumerable.Range(0, Options.Count)
                .Select(async i =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        string blobName = Guid.NewGuid().ToString();
                        await BlobContainerClient.GetBlobClient(blobName).UploadAsync(Stream.Null, overwrite: true);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });

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
