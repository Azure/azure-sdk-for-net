// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Options for additional content integrity checks on upload.
    /// </summary>
    public class UploadTransferValidationOptions
    {
        /// <summary>
        /// Checksum algorithm to use. If left unset (<see cref="ValidationAlgorithm.Auto"/>),
        /// the library will pick for you.
        /// </summary>
        public ValidationAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Optional. Can only be specified on specific operations. An existing checksum of
        /// the data to be uploaded. Not all upload APIs can use this value, and will throw
        /// if one is provided. Please check documentation on specific APIs for whether this
        /// can be used.
        /// </summary>
        public byte[] PrecalculatedChecksum { get; set; }
    }
}
