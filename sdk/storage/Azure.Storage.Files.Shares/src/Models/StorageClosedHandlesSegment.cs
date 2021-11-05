// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// StorageClosedHandlesSegment.
    /// </summary>
    public class StorageClosedHandlesSegment
    {
        /// <summary>
        /// A string describing next handle to be closed. It is returned when more handles need to be closed to complete the request.
        /// </summary>
        public string Marker { get; internal set; }

        /// <summary>
        /// Contains count of number of handles closed.
        /// </summary>
        public int NumberOfHandlesClosed { get; internal set; }

        /// <summary>
        /// Contains count of number of handles that failed to close.
        /// </summary>
        public int NumberOfHandlesFailedToClose { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of StorageClosedHandlesSegment instances.
        /// You can use ShareModelFactory.StorageClosedHandlesSegment instead.
        /// </summary>
        internal StorageClosedHandlesSegment() { }
    }
}
