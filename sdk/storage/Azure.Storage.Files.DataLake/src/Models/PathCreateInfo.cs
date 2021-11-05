// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path CreateResult
    /// </summary>
    public class PathCreateInfo
    {
        /// <summary>
        /// Path info for the file or directory.
        /// </summary>
        public PathInfo PathInfo { get; internal set; }

        /// <summary>
        /// When renaming a directory, the number of paths that are renamed with each invocation is limited.
        /// If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.
        /// When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename
        /// operation to continue renaming the directory.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathCreateInfo instances.
        /// You can use DataLakeModelFactory.PathCreateInfo instead.
        /// </summary>
        internal PathCreateInfo() { }
    }
}
