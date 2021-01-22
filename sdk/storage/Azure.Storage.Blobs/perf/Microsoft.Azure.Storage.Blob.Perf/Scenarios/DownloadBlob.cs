//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.Blob.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class DownloadBlob : ContainerTest<SizeOptions>
    {
        private readonly CloudBlockBlob _cloudBlockBlob;

        public DownloadBlob(SizeOptions options) : base(options)
        {
            _cloudBlockBlob = CloudBlobContainer.GetBlockBlobReference("Microsoft.Azure.Storage.Blob.Perf.Scenarios.DownloadBlob");
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            using Stream stream = RandomStream.Create(Options.Size);

            // No need to delete file in GlobalCleanup(), since ContainerTest.GlobalCleanup() deletes the whole container
            await _cloudBlockBlob.UploadFromStreamAsync(stream);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _cloudBlockBlob.DownloadToStream(Stream.Null);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _cloudBlockBlob.DownloadToStreamAsync(Stream.Null, cancellationToken);
        }
    }
}
