// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path
    /// </summary>
    public class PathItem
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// isDirectory
        /// </summary>
        public bool? IsDirectory { get; internal set; }

        /// <summary>
        /// lastModified
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// eTag
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// contentLength
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// owner
        /// </summary>
        public string Owner { get; internal set; }

        /// <summary>
        /// group
        /// </summary>
        public string Group { get; internal set; }

        /// <summary>
        /// permissions
        /// </summary>
        public string Permissions { get; internal set; }

        /// <summary>
        /// Created on.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// Expiry-Time.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; internal set; }

        /// <summary>
        /// The name of the encryption scope under which the blob is encrypted.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// Encryption context of the file.  Encryption context is metadata that is not encrypted when stored on the file.
        /// The primary application of this field is to store non-encrypted data that can be used to derive the customer-provided key
        /// for a file.
        /// Not applicable for directories.
        /// </summary>
        public string EncryptionContext { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathItem instances.
        /// You can use DataLakeModelFactory.PathItem instead.
        /// </summary>
        internal PathItem() { }
    }
}
