// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{StorageTransferOptionsOptions}" />
    public sealed class DownloadBlob : BlobTest<Options.PartitionedTransferOptions>
    {
        public DownloadBlob(Options.PartitionedTransferOptions options)
            : base(options, createBlob: true, singletonBlob: true)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            BlobClient.DownloadTo(Stream.Null, new BlobDownloadToOptions()
            {
                TransferOptions = Options.StorageTransferOptions,
            }, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await BlobClient.DownloadToAsync(Stream.Null, new BlobDownloadToOptions()
            {
                TransferOptions = Options.StorageTransferOptions,
            }, cancellationToken);
        }
    }
}
