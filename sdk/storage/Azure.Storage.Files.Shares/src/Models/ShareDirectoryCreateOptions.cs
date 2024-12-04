// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for creating a directory.
    /// </summary>
    public class ShareDirectoryCreateOptions
    {
        /// <summary>
        /// Optional custom metadata to set for the directory.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Optional SMB properties to set for the directory.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set on the directory.
        /// </summary>
        public ShareFilePermission FilePermission { get; set; }

        /// <summary>
        /// <summary>
        /// Optional properties to set on NFS directories.
        /// Note that this property is only applicable to directories created in NFS shares.
        /// </summary>
        /// </summary>
        public FilePosixProperties PosixProperties { get; set; }
    }
}
