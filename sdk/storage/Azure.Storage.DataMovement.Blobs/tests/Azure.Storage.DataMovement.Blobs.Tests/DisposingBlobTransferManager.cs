// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class DisposingBlobTransferManager : IDisposingContainer<BlobTransferManager>
    {
        public BlobTransferManager TransferManager => Container;

        public BlobTransferManager Container { get; private set; }

        public DisposingBlobTransferManager(BlobTransferManager client)
        {
            Container = client;
        }

        public async ValueTask DisposeAsync()
        {
            if (TransferManager != null)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        TransferManager.CancelTransfers();
                        TransferManager.Clean();
                    });
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
