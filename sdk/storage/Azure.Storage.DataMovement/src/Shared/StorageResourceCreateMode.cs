// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines how creating a transfer file resource should go
    /// if the resource already exists or does not exist.
    /// </summary>
    public enum StorageResourceCreateMode
    {
        /// <summary>
        /// Default. Overwrites the file if it already exists. No error will be thrown.
        /// </summary>
        Overwrite = default,

        /// <summary>
        /// If the file/blob already exists in the destination path, a failure will be thrown.
        /// All parallel downloads in progress will finish, but no further
        /// files in the directory to download will continue.
        ///
        /// If ErrorHandlingOptions.ContinueOnFailure is enabled, then this will get overrided
        /// and the transfer will complete regardless of failure.
        /// </summary>
        Fail = 1,

        /// <summary>
        /// If the file/blob already exists in the destination path, no failure will be thrown.
        /// The file will simply be skipped over and other parallel downloads in progress
        /// will finish and the rest of the files in the directory to download will continue.
        ///
        /// If ErrorHandlingOptions.StopOnAllFailures is set, the download will still be skipped.
        /// </summary>
        Skip = 2,
    }
}
