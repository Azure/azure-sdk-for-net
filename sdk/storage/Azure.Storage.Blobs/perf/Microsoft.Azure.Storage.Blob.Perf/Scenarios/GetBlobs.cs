// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.Blob.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on listing blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{CountOptions}" />
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
                var blobName = $"Microsoft.Azure.Storage.Blob.Perf.Scenarios.GetBlobs-{Guid.NewGuid()}";
                uploadTasks[i] = CloudBlobContainer.GetBlockBlobReference(blobName).UploadFromStreamAsync(Stream.Null);
            }
            await Task.WhenAll(uploadTasks);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            // Enumerate collection to ensure all IListBlobItems are downloaded
            foreach (var _ in CloudBlobContainer.ListBlobs())
            { }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            BlobContinuationToken continuationToken = null;
            do
            {
                var result = await CloudBlobContainer.ListBlobsSegmentedAsync(continuationToken, cancellationToken);
                continuationToken = result.ContinuationToken;

                // Enumerate collection to ensure all IListBlobItems are downloaded
                foreach (var _ in result.Results)
                { }
            }
            while (continuationToken != null);
        }
    }
}
