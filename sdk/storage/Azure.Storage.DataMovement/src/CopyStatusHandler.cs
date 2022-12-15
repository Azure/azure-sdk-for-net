// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class CopyStatusHandler : IDisposable
    {
        #region Delegate Definitions
        public delegate Task QueueGetPropertiesInternal();
        public delegate Task UpdateTransferStatusInternal(StorageTransferStatus status);
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly QueueGetPropertiesInternal _queueGetPropertiesTask;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly UpdateTransferStatusInternal _updateTransferStatus;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedHandler;

        public struct Behaviors
        {
            public QueueGetPropertiesInternal QueueGetPropertiesTask { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public UpdateTransferStatusInternal UpdateTransferStatus { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
        }

        private event SyncAsyncEventHandler<CopyStatusEventArgs> _getStatusHandler;
        internal SyncAsyncEventHandler<CopyStatusEventArgs> GetGetStatusHandler() => _getStatusHandler;

        public CopyStatusHandler(Behaviors behaviors)
        {
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            _queueGetPropertiesTask = behaviors.QueueGetPropertiesTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueGetPropertiesTask));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _updateTransferStatus = behaviors.UpdateTransferStatus
                ?? throw Errors.ArgumentNull(nameof(behaviors.UpdateTransferStatus));

            _getStatusHandler += StatusEvent;
        }

        public void Dispose()
        {
            Cleanup();
        }

        public void Cleanup()
        {
            _getStatusHandler -= StatusEvent;
        }

        private async Task StatusEvent(CopyStatusEventArgs args)
        {
            // Use progress tracker to get the amount of bytes transferred
            // Nothing needs to be done except update the bytes transfered if it was updated.
            _reportProgressInBytes(args.CurrentBytesTransferred);
            if (args.CopyStatus == ServiceCopyStatus.Success)
            {
                // Add CommitBlockList task to the channel
                await _updateTransferStatus(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            else if (args.CopyStatus == ServiceCopyStatus.Aborted)
            {
                await _invokeFailedHandler(
                        new Exception($"Error: Copy was aborted. Copy Id: {args.CopyId}")).ConfigureAwait(false);
            }
            else if (args.CopyStatus == ServiceCopyStatus.Failed)
            {
                await _invokeFailedHandler(
                        new Exception($"Error: Copy Failed. Copy Id: {args.CopyId}")).ConfigureAwait(false);
            }
            else // ServiceCopyStatus.Pending
            {
                // If it's still pending let's queue up another task
                await _queueGetPropertiesTask().ConfigureAwait(false);
            }
        }

        public async Task InvokeEvent(CopyStatusEventArgs args)
        {
            await _getStatusHandler.Invoke(args).ConfigureAwait(false);
        }
    }
}
