//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{StorageTransferOptionsOptions}" />
    public sealed class DownloadBlob : ContainerTest<StorageTransferOptionsOptions>
    {
        private readonly BlobClient _blobClient;

        public DownloadBlob(StorageTransferOptionsOptions options) : base(options)
        {
            _blobClient = BlobContainerClient.GetBlobClient("Azure.Storage.Blobs.Perf.Scenarios.DownloadBlob");
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            using Stream stream = RandomStream.Create(Options.Size);

            // No need to delete file in GlobalCleanup(), since ContainerTest.GlobalCleanup() deletes the whole container
            await _blobClient.UploadAsync(stream);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _blobClient.DownloadTo(Stream.Null, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _blobClient.DownloadToAsync(Stream.Null, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }
    }
}
