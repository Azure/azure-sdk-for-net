// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Perf
{
    public class CopyDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private BlobContainerClient _sourceContainer;
        private BlobContainerClient _destinationContainer;

        public CopyDirectory(DirectoryTransferOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            _sourceContainer = await CreateBlobContainerAsync(populate: true);
            _destinationContainer = await CreateBlobContainerAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            if (_sourceContainer != null)
            {
                await _sourceContainer.DeleteIfExistsAsync();
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
            StorageResource source = await BlobResourceProvider.FromContainerAsync(_sourceContainer.Uri);
            StorageResource destination = await BlobResourceProvider.FromContainerAsync(_destinationContainer.Uri);

            await RunAndVerifyTransferAsync(source, destination, cancellationToken);
        }
    }
}
