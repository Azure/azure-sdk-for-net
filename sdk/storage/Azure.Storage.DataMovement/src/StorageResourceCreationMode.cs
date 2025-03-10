// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the behavior when a transfer resource already exists.
    /// </summary>
    public enum StorageResourceCreationMode
    {
        /// <summary>
        /// The default value. This will be <see cref="FailIfExists"/> or, when resuming a transfer, it
        /// will use the value that was used when first starting the transfer. Any other value will override
        /// the behavior on resume.
        /// <para/>
        /// NOTE: If a transfer was paused/stopped before all resources were enumerated, any unenumerated
        /// resource will use the value of <see cref="FailIfExists"/> on resume.
        /// </summary>
        Default = 0,

        /// <summary>
        /// If the resource already exists in the destination path, a failure will be thrown.
        /// <para/>
        /// The value for <see cref="TransferManagerOptions.ErrorMode"/> will determine if
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
