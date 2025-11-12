// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
        /// Note that this property is only applicable to files created in SMB shares.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set on file.
        /// </summary>
        public ShareFilePermission FilePermission { get; set; }

        /// <summary>
        /// Optional properties to set on NFS files.
        /// Note that this property is only applicable to files created in NFS shares.
        /// </summary>
        public FilePosixProperties PosixProperties { get; set; }

        ///// <summary>
        ///// Optional, only applicable to SMB files.
        ///// How attributes and permissions should be set on the file.
        ///// New: automatically adds the ARCHIVE file attribute flag to the file and uses
        ///// Windows create file permissions semantics (ex: inherit from parent).
        ///// Restore: does not modify file attribute flag and uses Windows update file permissions semantics.
        ///// If Restore is specified, the file permission must also be provided or PropertySemantics will default to New.
        ///// </summary>
        //public FilePropertySemantics? PropertySemantics { get; set; }

        ///// <summary>
        ///// Optional, valid for version 2026-02-06 and later.
        ///// The content to upload to the file when it is created.  Must be less than or equal to 4 MiB in size.
        ///// </summary>
        //public Stream Content { get; set; }

        ///// <summary>
        ///// Optional, only valid if Content is specified. <see cref="IProgress{Long}"/> to provide
        ///// progress updates about data transfers.
        ///// </summary>
        //public IProgress<long> ProgressHandler { get; set; }

        ///// <summary>
        ///// Optional, only valid if Content is specified. Override settings for this client'
        ///// <see cref="ShareClientOptions.TransferValidation"/> settings hashing on uploads.
        ///// </summary>
        //public UploadTransferValidationOptions TransferValidation { get; set; }
    }
}
