// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// LeaseState values
    /// </summary>
    public enum LeaseState
    {
        /// <summary>
        /// available
        /// </summary>
        Available,

        /// <summary>
        /// leased
        /// </summary>
        Leased,

        /// <summary>
        /// expired
        /// </summary>
        Expired,

        /// <summary>
        /// breaking
        /// </summary>
        Breaking,

        /// <summary>
        /// broken
        /// </summary>
        Broken
    }
}
