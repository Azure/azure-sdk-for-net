// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the behavior when a transfer resource already exists.
    /// </summary>
    public enum StorageResourceCreationPreference
    {
        /// <summary>
        /// The default value will be <see cref="FailIfExists"/> when
        /// starting a new transfer.
        /// When resuming a transfer, the value will default to the value used when first starting
        /// the transfer for all resources that were successfully enumerated and the regular default
        /// for any remaining resources.
        /// </summary>
        Default = 0,

        /// <summary>
        /// If the resource already exists in the destination path, a failure will be thrown.
        /// <para/>
        /// The value for <see cref="TransferManagerOptions.ErrorHandling"/> will determine if
        /// the transfer continues after the failure or not.
        /// </summary>
        FailIfExists = 1,

        /// <summary>
        /// Overwrites the resource if it already exists. No error will be thrown.
        /// </summary>
        OverwriteIfExists = 2,

        /// <summary>
        /// If the resource already exists in the destination path, no failure will be thrown.
        /// The resource will simply be skipped over and the transfer will continue.
        ///
        /// If ErrorHandlingOptions.StopOnAnyFailures is set, the resource will still be skipped.
        /// </summary>
        SkipIfExists = 3,
    }
}
