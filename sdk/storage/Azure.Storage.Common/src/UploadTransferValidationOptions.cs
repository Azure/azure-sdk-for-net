// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Options for additional content integrity checks on upload.
    /// </summary>
    public class UploadTransferValidationOptions
    {
        /// <summary>
        /// Checksum algorithm to use.
        /// </summary>
        public StorageChecksumAlgorithm ChecksumAlgorithm { get; set; } = StorageChecksumAlgorithm.None;

        /// <summary>
        /// Optional. Can only be specified on specific operations and not at the client level.
        /// An existing checksum of the data to be uploaded. Not all upload APIs can use this
        /// value, and will throw if one is provided. Please check documentation on specific
        /// APIs for whether this can be used.
        /// </summary>
        public ReadOnlyMemory<byte> PrecalculatedChecksum { get; set; }
    }
}
