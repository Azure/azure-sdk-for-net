// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The system properties for a path.
    /// </summary>
    public class PathSystemProperties
    {
        /// <summary>
        /// The creation time of the file or directory.
        /// </summary>
        public DateTimeOffset? CreationTime { get; internal set; }

        /// <summary>
        /// The last modified time of the file or directory.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; internal set; }

        /// <summary>
        /// The eTag of the file or directory.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The content length of the file or directory.
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// If the path is a directory.
        /// </summary>
        public bool? IsDirectory { get; internal set; }

        /// <summary>
        /// If the path is server encrypted.
        /// </summary>
        public bool? IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// The expiration time of the file or directory.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; internal set; }

        /// <summary>
        /// The encryption scope of the file or directory.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// The encryption context of the file or directory.
        /// </summary>
        public string EncryptionContext { get; internal set; }

        /// <summary>
        /// The owner of the file or directory.
        /// </summary>
        public string Owner { get; internal set; }

        /// <summary>
        /// The owning group of the file or directory.
        /// </summary>
        public string Group { get; internal set; }

        /// <summary>
        /// The POSIX access permissions for the file owner, the file owning group, and others.
        /// </summary>
        public PathPermissions Permissions { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathSystemProperties instances.
        /// You can use DataLakeModelFactory.PathSystemProperties instead.
        /// </summary>
        internal PathSystemProperties() { }
    }
}
