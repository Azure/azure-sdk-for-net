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
        /// Prevent direct instantiation of PathInfo instances.
        /// You can use DataLakeModelFactory.PathInfo instead.
        /// </summary>
        internal PathInfo() { }
    }
}
