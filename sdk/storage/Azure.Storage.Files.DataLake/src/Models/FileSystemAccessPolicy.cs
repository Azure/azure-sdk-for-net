// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystemAccessPolicy.
    /// </summary>
    public class FileSystemAccessPolicy
    {
        /// <summary>
        /// A <see cref="PublicAccessType"/> indicating whether data in the file system may
        /// be accessed publicly and the level of access.
        /// </summary>
        public PublicAccessType DataLakePublicAccess { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request service version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> the file system was last modified.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A collection of signed identifiers stored on the file system.
        /// </summary>
        public IEnumerable<DataLakeSignedIdentifier> SignedIdentifiers { get; internal set; }

        /// <summary>
        /// Creates a new FileSystemAccessPolicy instance.
        /// </summary>
        public FileSystemAccessPolicy()
        {
            SignedIdentifiers = new List<DataLakeSignedIdentifier>();
        }
    }
}
