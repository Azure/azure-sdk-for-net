// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Perf.Options;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    public class DownloadToFile : BlobTest<PartitionedTransferOptions>
    {
        private string _tempFile;

        public DownloadToFile(PartitionedTransferOptions options)
            : base(options, createBlob: true, singletonBlob: true)
        {
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            string tempDir = Path.GetTempPath();
            string randomFileName = Path.GetRandomFileName();
            _tempFile = Path.Combine(tempDir, randomFileName);
        }

        public override async Task CleanupAsync()
        {
            if (_tempFile != null && File.Exists(_tempFile))
            {
                File.Delete(_tempFile);
            }
            await base.CleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            BlobClient.DownloadTo(_tempFile, new BlobDownloadToOptions()
            {
                TransferOptions = Options.StorageTransferOptions,
            }, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await BlobClient.DownloadToAsync(_tempFile, new BlobDownloadToOptions()
            {
                TransferOptions = Options.StorageTransferOptions,
            }, cancellationToken);
        }
    }
}
