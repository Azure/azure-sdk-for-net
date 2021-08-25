// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An enumeration of handles.
    /// </summary>
    internal class StorageHandlesSegment
    {
        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Handles
        /// </summary>
        public System.Collections.Generic.IEnumerable<ShareFileHandle> Handles { get; internal set; }

        /// <summary>
        /// Creates a new StorageHandlesSegment instance
        /// </summary>
        public StorageHandlesSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new StorageHandlesSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal StorageHandlesSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Handles = new System.Collections.Generic.List<ShareFileHandle>();
            }
        }
    }
}
