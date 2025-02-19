// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Perf
{
    public class UploadDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private string _sourceDirectory;
        private BlobContainerClient _destinationContainer;

        public UploadDirectory(DirectoryTransferOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            _sourceDirectory = CreateLocalDirectory(populate: true);
            _destinationContainer = await CreateBlobContainerAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            if (_sourceDirectory != null)
            {
                Directory.Delete(_sourceDirectory, true);
            }
            if (_destinationContainer != null)
            {
                await _destinationContainer.DeleteIfExistsAsync();
            }
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            StorageResource source = LocalFilesStorageResourceProvider.FromDirectory(_sourceDirectory);
            StorageResource destination = await BlobResourceProvider.FromContainerAsync(_destinationContainer.Uri);

            await RunAndVerifyTransferAsync(source, destination, cancellationToken);
        }
    }
}
