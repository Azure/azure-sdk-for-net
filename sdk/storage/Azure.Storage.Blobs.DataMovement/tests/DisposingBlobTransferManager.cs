// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs;

namespace Azure.Storage.Blobs.DataMovement.Tests
{
    public class DisposingBlobTransferManager : IDisposingContainer<BlobTransferManager>
    {
        public BlobTransferManager TransferManager => Container;

        public BlobTransferManager Container { get; private set; }

        public DisposingBlobTransferManager(BlobTransferManager client)
        {
            Container = client;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async ValueTask DisposeAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (TransferManager != null)
            {
                try
                {
                    /*
                    await Task.Run(() =>
                    {
                        TransferManager.CancelAllTransferJobsAsync();
                        TransferManager.CleanAsync();
                    }
                    */
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
