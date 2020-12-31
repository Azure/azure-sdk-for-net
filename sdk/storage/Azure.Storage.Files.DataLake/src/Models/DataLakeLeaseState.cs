// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Lease state values.
    /// </summary>
    public enum DataLakeLeaseState
    {
        /// <summary>
        /// Available.
        /// </summary>
        Available,

        /// <summary>
        /// Leased.
        /// </summary>
        Leased,

        /// <summary>
        /// Expired.
        /// </summary>
        Expired,

        /// <summary>
        /// Breaking.
        /// </summary>
        Breaking,

        /// <summary>
        /// Broken.
        /// </summary>
        Broken
    }
}
