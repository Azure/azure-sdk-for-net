// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Specifies the overwrite behavior for when a file to download
    /// already exists in the destination path specified.
    /// </summary>
    public enum DownloadOverwriteMethod
    {
        /// <summary>
        /// Overwrites the file if it already exists. No error will be thrown.
        /// </summary>
        Overwrite = default,

        /// <summary>
        /// If the file/blob already exists in the destination path, a failure will be thrown.
        /// All parallel downloads in progress will finish, but no further
        /// files in the directory to download will continue.
        /// </summary>
        Fail = 1,

        /// <summary>
        /// If the file/blob already exists in the destination path, no failure will be thrown.
        /// The file will simply be skipped over and other parallel downloads in progress
        /// will finish and the rest of the files in the directory to download will continue.
        ///
        /// TODO: write about it's different than the ErrorHandlingOptions
        /// </summary>
        Skip = 2,
    }
}
