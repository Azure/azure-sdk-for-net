// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.Storage.DataMovement.Perf
{
    public class UploadDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private string _sourceDirectory;
        private CloudBlobContainer _destinationContainer;

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
            System.IO.Directory.Delete(_sourceDirectory, true);
            await _destinationContainer.DeleteIfExistsAsync();
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            TransferStatus transfer = await TransferManager.UploadDirectoryAsync(
                _sourceDirectory,
                _destinationContainer.GetDirectoryReference(string.Empty),
                new UploadDirectoryOptions()
                {
                    Recursive = true
                },
                DefaultTransferContext,
                CancellationToken.None);  // Don't pass cancellation token to let ransfer finish gracefully
            AssertTransferStatus(transfer);
        }
    }
}
