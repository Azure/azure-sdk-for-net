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
        /// Source request conditions.
        /// </summary>
        public ShareFileRequestConditions SourceRequestConditions { get; set; }

        /// <summary>
        ///  Destination request conditions.
        /// </summary>
        public ShareFileRequestConditions DestinationRequestConditions { get; set; }

        /// <summary>
        /// The file system attributes for this file.
        /// </summary>
        public NtfsFileAttributes? FileAttributes { get; set; }

        /// <summary>
        /// The creation time of the file.
        /// </summary>
        public DateTimeOffset? FileCreatedOn { get; set; }

        /// <summary>
        /// The last write time of the file.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn { get; set; }

        /// <summary>
        /// Optional file permission to set on the destination.
        /// </summary>
        public string FilePermission { get; set; }

        /// <summary>
        /// Optional if FilePermission is not specified. This can only be specified if FilePermission is not specified.
        /// </summary>
        public string FilePermissionKey { get; set; }

        /// <summary>
        /// Optional. Sets the file’s content type. If this property is not specified on the request, then the property will
        /// be cleared for the file. Subsequent calls to Get File Properties will not return this property, unless it is explicitly
        /// set on the file again.
        /// </summary>
        public string ContentType { get; set; }
    }
}
