﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystemInfo.
    /// </summary>
    public class FileSystemInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> the file system was last modified. Any operation that modifies the
        /// file system, including an update of the file systems's metadata or properties, changes the last-modified
        /// time of the file system.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemInfo instances.
        /// You can use DataLakeModelFactory.FileSystemInfo instead.
        /// </summary>
        internal FileSystemInfo() { }
    }
}
