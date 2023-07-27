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
        /// Options on upload.
        /// </summary>
        public UploadTransferValidationOptions Upload { get; } = new();

        /// <summary>
        /// Options on download.
        /// </summary>
        public DownloadTransferValidationOptions Download { get; } = new();
    }
}
