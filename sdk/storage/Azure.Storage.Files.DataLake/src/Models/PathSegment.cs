// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// An enumeration of paths.
    /// </summary>
    internal class PathSegment
    {
        /// <summary>
        /// If the number of paths to be listed exceeds the maxResults limit, a continuation token is returned.
        /// When a continuation token is returned in the response, it must be specified in a subsequent invocation
        /// of the list operation to continue listing the paths.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// PathItems
        /// </summary>
        public IEnumerable<PathItem> Paths { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathSegment instances.
        /// You can use DataLakeModelFactory.PathSegment instead.
        /// </summary>
        internal PathSegment() { }
    }
}
