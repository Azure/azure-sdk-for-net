// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Holds transfer information
    /// </summary>
    public class DataTransfer : IAsyncDisposable
    {
        /// <summary>
        /// Defines whether the DataTransfer has completed.
        /// </summary>
        public bool HasCompleted => _state.HasCompleted;

        /// <summary>
        /// Defines the current Transfer Status of the Data Transfer.
        /// </summary>
        public StorageTransferStatus TransferStatus => _state.Status;

        /// <summary>
        /// DataTransfer Identification.
        /// </summary>
        public string Id => _state.Id;

        /// <summary>
        /// Defines the current state of the transfer.
        /// </summary>
        internal DataTransferState _state;

        /// <summary>
        /// Only to be created internally by the transfer manager.
        /// </summary>
        internal DataTransfer()
        {
            _state = new DataTransferState();
        }

        /// <summary>
        /// For mocking
        /// </summary>
        /// <param name="status"></param>
        internal DataTransfer(StorageTransferStatus status)
        {
            _state = new DataTransferState(status);
        }

        /// <summary>
        /// Only to be created internally by the transfer manager when someone
        /// provides a valid job plan file to resume from.
        /// </summary>
        internal DataTransfer(string id, long bytesTransferred = 0)
        {
            _state = new DataTransferState(id, bytesTransferred);
        }

        /// <summary>
        /// Disposes the DataTransfer object.
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await _state.DisposeAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ensures completion of the DataTransfer and attempts to get result
        /// </summary>
        public void EnsureCompleted(CancellationToken cancellationToken = default)
        {
#if DEBUG
            VerifyTaskCompleted(HasCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            AwaitCompletion(cancellationToken);
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(bool isCompleted)
        {
            if (!isCompleted)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }

        /// <summary>
        /// Waits until the data transfer itself has completed
        /// </summary>
        /// <param name="cancellationToken"></param>
        public Task AwaitCompletion(CancellationToken cancellationToken = default)
        {
            while (!HasCompleted)
            {
#if DEBUG
                VerifyTaskCompleted(HasCompleted);
#endif
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            }

            return Task.CompletedTask;
        }
    }
}
