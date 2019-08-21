// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
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
        public NtfsAttributes? FileAttributes { get; set; }

        /// <summary>
        /// The file permission key of the file's FilePermission.
        /// </summary>
        public string FilePermissionKey{ get; set; }

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
            this.FileAttributes = CloudFileNtfsAttributesHelper.ToAttributes(rawStorageFileInfo.FileAttributes);
            this.FilePermissionKey = rawStorageFileInfo.FilePermissionKey;
            this.FileCreationTime = rawStorageFileInfo.FileCreationTime;
            this.FileLastWriteTime = rawStorageFileInfo.FileLastWriteTime;
            this.FileChangeTime = rawStorageFileInfo.FileChangeTime;
            this.FileId = rawStorageFileInfo.FileId;
            this.ParentId = rawStorageFileInfo.FileParentId;

        }

        internal FileSmbProperties(RawStorageFileProperties rawStorageFileProperties)
        {
            this.FileAttributes = CloudFileNtfsAttributesHelper.ToAttributes(rawStorageFileProperties.FileAttributes);
            this.FilePermissionKey = rawStorageFileProperties.FilePermissionKey;
            this.FileCreationTime = rawStorageFileProperties.FileCreationTime;
            this.FileLastWriteTime = rawStorageFileProperties.FileLastWriteTime;
            this.FileChangeTime = rawStorageFileProperties.FileChangeTime;
            this.FileId = rawStorageFileProperties.FileId;
            this.ParentId = rawStorageFileProperties.FileParentId;
        }

        internal FileSmbProperties(FlattenedStorageFileProperties flattenedStorageFileProperties)
        {
            this.FileAttributes = CloudFileNtfsAttributesHelper.ToAttributes(flattenedStorageFileProperties.FileAttributes);
            this.FilePermissionKey = flattenedStorageFileProperties.FilePermissionKey;
            this.FileCreationTime = flattenedStorageFileProperties.FileCreationTime;
            this.FileLastWriteTime = flattenedStorageFileProperties.FileLastWriteTime;
            this.FileChangeTime = flattenedStorageFileProperties.FileChangeTime;
            this.FileId = flattenedStorageFileProperties.FileId;
            this.ParentId = flattenedStorageFileProperties.FileParentId;
        }

        internal FileSmbProperties(RawStorageDirectoryInfo RawStorageDirectoryInfo)
        {
            this.FileAttributes = CloudFileNtfsAttributesHelper.ToAttributes(RawStorageDirectoryInfo.FileAttributes);
            this.FilePermissionKey = RawStorageDirectoryInfo.FilePermissionKey;
            this.FileCreationTime = RawStorageDirectoryInfo.FileCreationTime;
            this.FileLastWriteTime = RawStorageDirectoryInfo.FileLastWriteTime;
            this.FileChangeTime = RawStorageDirectoryInfo.FileChangeTime;
            this.FileId = RawStorageDirectoryInfo.FileId;
            this.ParentId = RawStorageDirectoryInfo.FileParentId;
        }

        internal FileSmbProperties(RawStorageDirectoryProperties rawStorageDirectoryProperties)
        {
            this.FileAttributes = CloudFileNtfsAttributesHelper.ToAttributes(rawStorageDirectoryProperties.FileAttributes);
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
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
            => other is FileSmbProperties && this.Equals((FileSmbProperties)other);

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
        /// <param name="other">The instance to compare to.</param>
        public bool Equals(FileSmbProperties other)
            => this.FileAttributes == other.FileAttributes
            && this.FilePermissionKey == other.FilePermissionKey
            && this.FileCreationTime == other.FileCreationTime
            && this.FileLastWriteTime == other.FileLastWriteTime
            && this.FileChangeTime == other.FileChangeTime
            && this.FileId == other.FileId
            && this.ParentId == other.ParentId;

        internal string FileCreationTimeToString()
            => this.FileCreationTime.HasValue ? DateTimeOffSetToString(this.FileCreationTime.Value) : null;

        internal string FileLastWriteTimeToString()
            => this.FileLastWriteTime.HasValue ? DateTimeOffSetToString(this.FileLastWriteTime.Value) : null;

        private static string DateTimeOffSetToString(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff'Z'", CultureInfo.InvariantCulture);
    }
}
