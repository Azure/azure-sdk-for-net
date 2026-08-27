// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Determines whether locality-aware routing is used for the parallel range
    /// requests issued by a download. This is a performance optimization only -
    /// the bytes returned are identical regardless of the mode used.
    /// </summary>
    public enum LayoutAwareRouting
    {
        /// <summary>
        /// Default. The locality-aware routing behavior is determined by the client
        /// library and may be updated in future releases.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Never route range requests based on the blob's layout. All requests are
        /// sent to the client's configured endpoint.
        /// </summary>
        Disabled = 1,

        /// <summary>
        /// Opt in to locality-aware routing. The blob's layout is fetched on demand
        /// and cached (with automatic background refresh), and each range download is
        /// routed to the optimal endpoint for the chunk being read.
        /// </summary>
        Enabled = 2
    }
}
