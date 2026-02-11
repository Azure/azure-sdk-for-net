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

        ///// <summary>
        ///// Optional, only applicable to SMB directories.
        ///// How attributes and permissions should be set on the file.
        ///// New: automatically adds the ARCHIVE file attribute flag to the file and uses
        ///// Windows create file permissions semantics (ex: inherit from parent).
        ///// Restore: does not modify file attribute flag and uses Windows update file permissions semantics.
        ///// If Restore is specified, the file permission must also be provided, otherwise PropertySemantics will default to New.
        ///// </summary>
        //public FilePropertySemantics? PropertySemantics { get; set; }
    }
}
