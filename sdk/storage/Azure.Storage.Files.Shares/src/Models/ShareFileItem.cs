// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Describes a file or directory returned by
    /// <see cref="ShareDirectoryClient.GetFilesAndDirectoriesAsync"/>.
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
        /// Gets an optional value indicating the file size, if this item is
        /// a file.
        /// </summary>
        public long? FileSize { get; }

        internal ShareFileItem(bool isDirectory, string name, long? fileSize = null)
        {
            IsDirectory = isDirectory;
            Name = name;
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
        public static ShareFileItem StorageFileItem(
            bool isDirectory, string name, long? fileSize) =>
            new ShareFileItem(isDirectory, name, fileSize);
    }
}
