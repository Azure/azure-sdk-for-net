// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Perf
{
    public class DownloadDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private BlobContainerClient _sourceContainer;
        private string _destinationDirectory;

        public DownloadDirectory(DirectoryTransferOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            _sourceContainer = await CreateBlobContainerAsync(populate: true);
            _destinationDirectory = CreateLocalDirectory();
        }

        public override async Task GlobalCleanupAsync()
        {
            if (_sourceContainer != null)
            {
                await _sourceContainer.DeleteIfExistsAsync();
            }
            if (_destinationDirectory != null)
            {
                Directory.Delete(_destinationDirectory, true);
            }
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            StorageResource source = await BlobResourceProvider.FromContainerAsync(_sourceContainer.Uri);
            StorageResource destination = LocalFilesStorageResourceProvider.FromDirectory(_destinationDirectory);

            await RunAndVerifyTransferAsync(source, destination, cancellationToken);
        }
    }
}
