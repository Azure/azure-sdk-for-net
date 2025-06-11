// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for creating a file with data.
    /// </summary>
    public class ShareFileCreateWithDataOptions
    {
        /// <summary>
        /// Required. The content to upload to the file.  Must be less than or equal to 4 MiB in size.
        /// </summary>
        public Stream Content { get; set; }

        /// <summary>
        /// Optional parameters for creating a file.
        /// </summary>
        public ShareFileCreateOptions CreateOptions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="ShareClientOptions.TransferValidation"/> settings.
        /// hashing on uploads.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
