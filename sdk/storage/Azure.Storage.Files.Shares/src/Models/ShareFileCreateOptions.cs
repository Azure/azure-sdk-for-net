﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for creating a file.
    /// </summary>
    public class ShareFileCreateOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the file.
        /// </summary>
        public ShareFileHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for the file.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Optional SMB properties to set for the file.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set on file.
        /// </summary>
        public ShareFilePermission FilePermission { get; set; }
    }
}
