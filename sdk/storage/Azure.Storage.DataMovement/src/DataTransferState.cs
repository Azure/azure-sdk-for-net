// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the types of the state a transfer can have.
    /// </summary>
    public enum DataTransferState
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None = 0,

        /// <summary>
        /// The transfer has been queued up but has not yet started.
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The transfer has started, but has not yet completed.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The transfer is in progress and is in the process of being paused.
        ///
        /// Transfer can be stopped if  <see cref="TransferManager.PauseTransferIfRunningAsync(string, System.Threading.CancellationToken)"/>
        /// or <see cref="DataTransfer.PauseAsync(CancellationToken)"/> is called.
        /// </summary>
        Pausing = 3,

        /// <summary>
        /// The transfer is in progress and is in the process of being stopped.
        ///
        /// Transfer can be stopped if <see cref="DataTransferErrorMode.StopOnAnyFailure"/> is
        /// enabled in the <see cref="TransferManagerOptions.ErrorHandling"/>.
        /// </summary>
        Stopping = 4,

        /// <summary>
        /// The transfer has been paused. When transfer is paused
        /// (e.g. see <see cref="TransferManager.PauseTransferIfRunningAsync(string, System.Threading.CancellationToken)"/>)
        /// during the transfer, this will be the value.
        /// </summary>
        Paused = 5,

        /// <summary>
        /// The transfer has come to a completed state. If the transfer has started and
        /// has fully stopped will also come to this state.
        /// </summary>
        Completed = 6
    }
}
