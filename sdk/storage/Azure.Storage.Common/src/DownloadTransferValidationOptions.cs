// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Options for additional content integrity checks on download.
    /// </summary>
    public class DownloadTransferValidationOptions
    {
        /// <summary>
        /// Checksum algorithm to use.
        /// </summary>
        public StorageChecksumAlgorithm ChecksumAlgorithm { get; set; } = StorageChecksumAlgorithm.None;

        /// <summary>
        /// Defaults to true. False can only be specified on specific operations and not at the client level.
        /// Indicates whether the SDK should validate the content
        /// body against the content hash before returning contents to the caller.
        /// If set to false, caller is responsible for extracting the hash out
        /// of the <see cref="Response{T}"/> and validating the hash themselves.
        /// </summary>
        public bool AutoValidateChecksum { get; set; } = true;
    }
}
