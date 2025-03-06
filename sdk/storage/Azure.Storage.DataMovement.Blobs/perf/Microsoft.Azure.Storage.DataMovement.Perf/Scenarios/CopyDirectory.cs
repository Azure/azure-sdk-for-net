// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.Storage.DataMovement.Perf
{
    public class CopyDirectory : DirectoryTransferTest<DirectoryTransferOptions>
    {
        private CloudBlobContainer _sourceContainer;
        private CloudBlobContainer _destinationContainer;

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
            await _sourceContainer.DeleteIfExistsAsync();
            await _destinationContainer.DeleteIfExistsAsync();
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            TransferStatus transfer = await TransferManager.CopyDirectoryAsync(
                _sourceContainer.GetDirectoryReference(string.Empty),
                _destinationContainer.GetDirectoryReference(string.Empty),
                CopyMethod.ServiceSideSyncCopy,
                new CopyDirectoryOptions()
                {
                    Recursive = true
                },
                DefaultTransferContext,
                CancellationToken.None);  // Don't pass cancellation token to let ransfer finish gracefully
            AssertTransferStatus(transfer);
        }
    }
}
