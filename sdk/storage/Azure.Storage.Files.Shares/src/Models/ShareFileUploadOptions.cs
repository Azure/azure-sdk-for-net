// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Share File.
    /// </summary>
    public class ShareFileUploadOptions
    {
        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to apply to the request.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }
    }
}
