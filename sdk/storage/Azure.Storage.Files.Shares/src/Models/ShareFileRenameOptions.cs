// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for renaming a File or Directory.
    /// </summary>
    public class ShareFileRenameOptions
    {
        /// <summary>
        /// Optional. A boolean value for if the destination file already exists, whether this request will overwrite the file or not.
        /// If true, the rename will succeed and will overwrite the destination file. If not provided or if false and the destination
        /// file does exist, the request will not overwrite the destination file. If provided and the destination file doesn’t exist,
        /// the rename will succeed.
        /// </summary>
        public bool? ReplaceIfExists { get; set; }

        /// <summary>
        /// Optional.  A boolean value that specifies whether the ReadOnly attribute on a preexisting destination file should be respected.
        /// If true, the rename will succeed, otherwise, a previous file at the destination with the ReadOnly attribute set will cause the
        /// rename to fail.
        /// </summary>
        public bool? IgnoreReadOnly { get; set; }

        /// <summary>
        /// Source request conditions.  This parameter is only applicable if the source is a file.
        /// </summary>
        public ShareFileRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Destination request conditions.
        /// </summary>
        public ShareFileRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional SMB properties to set on the destination file or directory.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set on the destination file or directory.
        /// </summary>
        public string FilePermission { get; set; }

        /// <summary>
        /// Optional format of the <see cref="FilePermission"/>.
        /// </summary>
        public FilePermissionFormat? FilePermissionFormat { get; set; }

        /// <summary>
        /// Optional custom metadata to set on the destination.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Optional content type to set on the File.
        /// Note that this parameter does not apply for Directories.
        /// </summary>
        public string ContentType { get; set; }
    }
}
