// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Perf.Options;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    public class UploadFromFile : BlobTest<PartitionedTransferOptions>
    {
        private string _tempFile;

        public UploadFromFile(PartitionedTransferOptions options)
            : base(options, createBlob: true, singletonBlob: true)
        {
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            string tempDir = Path.GetTempPath();
            string randomFileName = Path.GetRandomFileName();
            _tempFile = Path.Combine(tempDir, randomFileName);

            using (Stream data = RandomStream.Create(Options.Size))
            using (FileStream fileStream = File.Create(_tempFile))
            {
                await data.CopyToAsync(fileStream);
            }
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
            BlobClient.Upload(_tempFile, new BlobUploadOptions
            {
                TransferOptions = Options.StorageTransferOptions,
            },
            cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await BlobClient.UploadAsync(_tempFile, new BlobUploadOptions
            {
                TransferOptions = Options.StorageTransferOptions,
            },
            cancellationToken);
        }
    }
}
