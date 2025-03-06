// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.Storage.DataMovement.Perf
{
    public class DownloadDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private CloudBlobContainer _sourceContainer;
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
            await _sourceContainer.DeleteIfExistsAsync();
            System.IO.Directory.Delete(_destinationDirectory, true);
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            TransferStatus transfer = await TransferManager.DownloadDirectoryAsync(
                _sourceContainer.GetDirectoryReference(string.Empty),
                _destinationDirectory,
                new DownloadDirectoryOptions()
                {
                    Recursive = true
                },
                DefaultTransferContext,
                CancellationToken.None);  // Don't pass cancellation token to let ransfer finish gracefully
            AssertTransferStatus(transfer);
        }
    }
}
