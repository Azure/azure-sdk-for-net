// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Either a <see cref="Prefix"/> or <see cref="Path"/>.
    /// </summary>
    internal class PathHierarchyDeletedItem
    {
        /// <summary>
        /// Gets a prefix, relative to the delimiter used to get the paths.
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        /// Gets a path.
        /// </summary>
        public PathDeletedItem Path { get; internal set; }

        /// <summary>
        /// Gets a value indicating if this item represents a <see cref="Prefix"/>.
        /// </summary>
        public bool IsPrefix => Prefix != null;

        /// <summary>
        /// Gets a value indicating if this item represents a <see cref="Path"/>.
        /// </summary>
        public bool IsPath => Path != null;

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal PathHierarchyDeletedItem() { }
    }
}
