// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.DataMovement
{
    internal class TransferEventsInternal
    {
        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<TransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferItemFailedEventArgs> TransferFailedEventHandler;

        internal SyncAsyncEventHandler<TransferItemFailedEventArgs> GetFailed() => TransferFailedEventHandler;
    }
}
