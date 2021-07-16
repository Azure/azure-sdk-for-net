// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// DataLakeDirectoryUploadOptions for
    /// </summary>
    public class ShareDirectoryUploadOptions
    {
        /// <summary>
        /// Describes whether or not the directory being uploaded should
        /// be located under it's own subdirectory server-side.
        /// </summary>
        public bool? UploadToSubdirectory { get; set; }
    }
}
