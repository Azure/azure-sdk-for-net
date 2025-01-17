// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The SMB properties for a file.
    /// </summary>
    public class FileSmbProperties
    {
        /// <summary>
        /// The file system attributes for this file.
        /// </summary>
        public NtfsFileAttributes? FileAttributes { get; set; }

        /// <summary>
        /// The key of the file permission.
        /// </summary>
        public string FilePermissionKey { get; set; }

        /// <summary>
        /// The creation time of the file.
        /// </summary>
        public DateTimeOffset? FileCreatedOn { get; set; }

        /// <summary>
        /// The last write time of the file.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn { get; set; }

        /// <summary>
        /// The change time of the file.
        /// </summary>
        public DateTimeOffset? FileChangedOn { get; set; }

        /// <summary>
        /// The fileId of the file.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parentId of the file
        /// </summary>
        public string ParentId { get; internal set; }

        /// <summary>
        /// Creates a new FileSmbProperties instance.
        /// </summary>
        public FileSmbProperties() {}

        /// <summary>
        /// Checks if two FileSmbProperties are equal.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
            => base.Equals(other);

        /// <summary>
        /// Gets the hash code for the FileSmbProperties.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new FileSmbProperties instance for mocking.
        /// </summary>
        public static FileSmbProperties FileSmbProperties(
            DateTimeOffset? fileChangedOn,
            string fileId,
            string parentId) => new FileSmbProperties
            {
                FileChangedOn = fileChangedOn,
                FileId = fileId,
                ParentId = parentId
            };
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class SharesModelFactory
    {
        /// <summary>
        /// Creates a new FileSmbProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileSmbProperties FileSmbProperties(
            DateTimeOffset? fileChangedOn,
            string fileId,
            string parentId) => new FileSmbProperties
            {
                FileChangedOn = fileChangedOn,
                FileId = fileId,
                ParentId = parentId
            };
    }
}
