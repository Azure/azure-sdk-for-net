// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options associated with transfer progress tracking.
    /// </summary>
    public class TransferProgressHandlerOptions
    {
        /// <summary>
        /// Optional. An <see cref="IProgress{StorageTransferProgress}"/> for tracking progress of the transfer.
        /// See <see cref="TransferProgress"/> for details on what is tracked.
        /// </summary>
        public IProgress<TransferProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Set to true to populate BytesTransferred of <see cref="TransferProgress.BytesTransferred"/> of <see cref="ProgressHandler"/>
        /// in progress reports. Set to false to not track BytesTransferred (value will be null).
        /// Default value is false.
        /// </summary>
        public bool TrackBytesTransferred { get; set; } = false;
    }
}
