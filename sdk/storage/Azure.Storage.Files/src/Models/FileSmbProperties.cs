// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// The SMB properties for a file.
    /// </summary>
    public struct FileSmbProperties : IEquatable<FileSmbProperties>
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
        public DateTimeOffset? FileCreationTime { get; set; }

        /// <summary>
        /// The last write time of the file.
        /// </summary>
        public DateTimeOffset? FileLastWriteTime { get; set; }

        /// <summary>
        /// The change time of the file.
        /// </summary>
        public DateTimeOffset? FileChangeTime { get; internal set; }

        /// <summary>
        /// The fileId of the file.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parentId of the file
        /// </summary>
        public string ParentId { get; internal set; }

        internal FileSmbProperties(RawStorageFileInfo rawStorageFileInfo)
        {
            this.FileAttributes = NtfsFileAttributes.Parse(rawStorageFileInfo.FileAttributes);
            this.FilePermissionKey = rawStorageFileInfo.FilePermissionKey;
            this.FileCreationTime = rawStorageFileInfo.FileCreationTime;
            this.FileLastWriteTime = rawStorageFileInfo.FileLastWriteTime;
            this.FileChangeTime = rawStorageFileInfo.FileChangeTime;
            this.FileId = rawStorageFileInfo.FileId;
            this.ParentId = rawStorageFileInfo.FileParentId;

        }

        internal FileSmbProperties(RawStorageFileProperties rawStorageFileProperties)
        {
            this.FileAttributes = NtfsFileAttributes.Parse(rawStorageFileProperties.FileAttributes);
            this.FilePermissionKey = rawStorageFileProperties.FilePermissionKey;
            this.FileCreationTime = rawStorageFileProperties.FileCreationTime;
            this.FileLastWriteTime = rawStorageFileProperties.FileLastWriteTime;
            this.FileChangeTime = rawStorageFileProperties.FileChangeTime;
            this.FileId = rawStorageFileProperties.FileId;
            this.ParentId = rawStorageFileProperties.FileParentId;
        }

        internal FileSmbProperties(FlattenedStorageFileProperties flattenedStorageFileProperties)
        {
            this.FileAttributes = NtfsFileAttributes.Parse(flattenedStorageFileProperties.FileAttributes);
            this.FilePermissionKey = flattenedStorageFileProperties.FilePermissionKey;
            this.FileCreationTime = flattenedStorageFileProperties.FileCreationTime;
            this.FileLastWriteTime = flattenedStorageFileProperties.FileLastWriteTime;
            this.FileChangeTime = flattenedStorageFileProperties.FileChangeTime;
            this.FileId = flattenedStorageFileProperties.FileId;
            this.ParentId = flattenedStorageFileProperties.FileParentId;
        }

        internal FileSmbProperties(RawStorageDirectoryInfo rawStorageDirectoryInfo)
        {
            this.FileAttributes = NtfsFileAttributes.Parse(rawStorageDirectoryInfo.FileAttributes);
            this.FilePermissionKey = rawStorageDirectoryInfo.FilePermissionKey;
            this.FileCreationTime = rawStorageDirectoryInfo.FileCreationTime;
            this.FileLastWriteTime = rawStorageDirectoryInfo.FileLastWriteTime;
            this.FileChangeTime = rawStorageDirectoryInfo.FileChangeTime;
            this.FileId = rawStorageDirectoryInfo.FileId;
            this.ParentId = rawStorageDirectoryInfo.FileParentId;
        }

        internal FileSmbProperties(RawStorageDirectoryProperties rawStorageDirectoryProperties)
        {
            this.FileAttributes = NtfsFileAttributes.Parse(rawStorageDirectoryProperties.FileAttributes);
            this.FilePermissionKey = rawStorageDirectoryProperties.FilePermissionKey;
            this.FileCreationTime = rawStorageDirectoryProperties.FileCreationTime;
            this.FileLastWriteTime = rawStorageDirectoryProperties.FileLastWriteTime;
            this.FileChangeTime = rawStorageDirectoryProperties.FileChangeTime;
            this.FileId = rawStorageDirectoryProperties.FileId;
            this.ParentId = rawStorageDirectoryProperties.FileParentId;
        }

        /// <summary>
        /// Checks if two FileSmbProperties are equal.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns></returns>
        public override bool Equals(object other)
            => other is FileSmbProperties props && this.Equals(props);

        /// <summary>
        /// Gets the hash code for the FileSmbProperties.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => this.FileAttributes.GetHashCode()
            ^ this.FilePermissionKey.GetHashCode()
            ^ this.FileCreationTime.GetHashCode()
            ^ this.FileLastWriteTime.GetHashCode()
            ^ this.FileChangeTime.GetHashCode()
            ^ this.FileId.GetHashCode()
            ^ this.ParentId.GetHashCode();

        /// <summary>
        /// Check if two FileSmbProperties instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(FileSmbProperties left, FileSmbProperties right) => left.Equals(right);

        /// <summary>
        /// Check if two FileSmbProperties instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(FileSmbProperties left, FileSmbProperties right) => !(left == right);

        /// <summary>
        /// Check if two FileSmbProperties instances are equal.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        public bool Equals(FileSmbProperties other)
            => this.FileAttributes == other.FileAttributes
            && this.FilePermissionKey == other.FilePermissionKey
            && this.FileCreationTime == other.FileCreationTime
            && this.FileLastWriteTime == other.FileLastWriteTime
            && this.FileChangeTime == other.FileChangeTime
            && this.FileId == other.FileId
            && this.ParentId == other.ParentId;

        internal string FileCreationTimeToString()
            => NullableDateTimeOffsetToString(this.FileCreationTime);

        internal string FileLastWriteTimeToString()
            => NullableDateTimeOffsetToString(this.FileLastWriteTime);

        private static string NullableDateTimeOffsetToString(DateTimeOffset? dateTimeOffset)
            => dateTimeOffset.HasValue ? DateTimeOffSetToString(dateTimeOffset.Value) : null;

        private static string DateTimeOffSetToString(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime.ToString(Constants.File.FileTimeFormat, CultureInfo.InvariantCulture);
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
            DateTimeOffset? fileChangeTime,
            string fileId,
            string parentId) => new FileSmbProperties
            {
                FileChangeTime = fileChangeTime,
                FileId = fileId,
                ParentId = parentId
            };
    }
}
