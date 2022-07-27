// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Options for additional content integrity checks on transfer.
    /// </summary>
    public class TransferValidationOptions
    {
        /// <summary>
        /// Checksum algorithm to use. If left unset (<see cref="StorageChecksumAlgorithm.Auto"/>),
        /// the library will pick for you.
        /// </summary>
        public UploadTransferValidationOptions Upload { get; } = new();

        /// <summary>
        /// Optional. Can only be specified on specific operations. An existing checksum of
        /// the data to be uploaded. Not all upload APIs can use this value, and will throw
        /// if one is provided. Please check documentation on specific APIs for whether this
        /// can be used.
        /// </summary>
        public DownloadTransferValidationOptions Download { get; } = new();
    }
}
