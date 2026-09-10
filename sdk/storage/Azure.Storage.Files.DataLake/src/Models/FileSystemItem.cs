// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// An Azure Data Lake file system.
    /// </summary>
    [CodeGenSuppress("LastModified", typeof(string))]
    [CodeGenSuppress("ETag", typeof(string))]
    public partial class FileSystemItem
    {
        /// <summary>
        /// The name of the file system.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Deleted.
        /// </summary>
        public bool? IsDeleted { get; internal set; }

        /// <summary>
        /// Version.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// <see cref="FileSystemProperties"/> of the file system.
        /// </summary>
        public FileSystemProperties Properties { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemItem instances.
        /// You can use DataLakeModelFactory.FileSystemItem instead.
        /// </summary>
        internal FileSystemItem() { }
    }
}
