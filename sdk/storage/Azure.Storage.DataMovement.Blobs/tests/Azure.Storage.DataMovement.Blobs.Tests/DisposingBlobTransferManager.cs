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
        public BlobTransferManager transferManager { get; private set; }

        public DisposingBlobTransferManager(BlobTransferManager client)
        {
            transferManager = client;
        }

        public async ValueTask DisposeAsync()
        {
            if (transferManager != null)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        transferManager.CancelTransfers();
                        transferManager.Clean();
                    });
                    transferManager = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
