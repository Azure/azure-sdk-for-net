﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for ShareFileClient.StartCopy() and .StartCopyAsync().
    /// </summary>
    public class ShareFileCopyOptions
    {
        /// <summary>
        /// Optional custom metadata to set on the destination file.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Optional SMB properties to set on the destination file.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set for the destination file.
        /// </summary>
        public string FilePermission { get; set; }

        /// <summary>
        /// Specifies the option to copy file security descriptor from source file or
        /// to set it using the value which is defined by the header value of FilePermission
        /// or FilePermissionKey.
        /// </summary>
        public PermissionCopyMode? FilePermissionCopyMode { get; set; }

        /// <summary>
        /// Optional boolean specifying to overwrite the target file if it already
        /// exists and has read-only attribute set.
        /// </summary>
        public bool? IgnoreReadOnly { get; set; }

        /// <summary>
        /// Optional boolean Specifying to set archive attribute on a target file. True
        /// means archive attribute will be set on a target file despite attribute
        /// overrides or a source file state.
        /// </summary>
        public bool? Archive { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on copying the file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// SMB properties to copy from the source file.
        /// </summary>
        public CopyableFileSmbProperties SmbPropertiesToCopy { get; set; }
    }
}
