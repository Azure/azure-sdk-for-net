// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.ComponentModel;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Describes a file or directory returned by
    /// <see cref="ShareDirectoryClient.GetFilesAndDirectoriesAsync(ShareDirectoryGetFilesAndDirectoriesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ShareFileItem
    {
        /// <summary>
        /// Gets a value indicating whether this item is a directory.
        /// </summary>
        public bool IsDirectory { get; }

        /// <summary>
        /// Gets the name of this item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the properties of this item.
        /// </summary>
        public ShareFileItemProperties Properties { get; }

        /// <summary>
        /// Gets the file attributes.
        /// </summary>
        public NtfsFileAttributes? FileAttributes { get; }

        /// <summary>
        /// Gets the permission key.
        /// </summary>
        public string PermissionKey { get; }

        /// <summary>
        /// Gets an optional value indicating the file size, if this item is
        /// a file.
        /// </summary>
        public long? FileSize { get; }

        internal ShareFileItem(
            bool isDirectory,
            string name,
            string id,
            ShareFileItemProperties properties,
            NtfsFileAttributes? fileAttributes,
            string permissionKey,
            long? fileSize)
        {
            IsDirectory = isDirectory;
            Name = name;
            Id = id;
            Properties = properties;
            FileAttributes = fileAttributes;
            PermissionKey = permissionKey;
            FileSize = fileSize;
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileItem instance for mocking.
        /// </summary>
        public static ShareFileItem ShareFileItem(
            bool isDirectory = default,
            string name = default,
            long? fileSize = default,
            string id = default,
            ShareFileItemProperties properties = default,
            NtfsFileAttributes? fileAttributes = default,
            string permissionKey = default) =>
            new ShareFileItem(
                isDirectory: isDirectory,
                name: name,
                id: id,
                properties: properties,
                fileAttributes: fileAttributes,
                permissionKey: permissionKey,
                fileSize: fileSize);

        /// <summary>
        /// Creates a new StorageFileItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareFileItem StorageFileItem(
            bool isDirectory,
            string name,
            long? fileSize) =>
            new ShareFileItem(
                isDirectory: isDirectory,
                name: name,
                id: null,
                properties: null,
                fileAttributes: null,
                permissionKey: null,
                fileSize: fileSize);
    }
}
