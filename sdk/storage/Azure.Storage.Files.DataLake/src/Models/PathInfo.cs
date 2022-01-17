// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// PathInfo
    /// </summary>
    public class PathInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the path was last modified. Any operation that modifies the path,
        /// including an update of the paths's metadata or properties, changes the last-modified time of the path.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the path. This header is only returned when the path was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathInfo instances.
        /// You can use DataLakeModelFactory.PathInfo instead.
        /// </summary>
        internal PathInfo() { }
    }
}
