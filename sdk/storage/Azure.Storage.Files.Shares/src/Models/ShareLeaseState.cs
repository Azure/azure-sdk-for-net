// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Lease state of the share.
    /// </summary>
    [CodeGenModel("LeaseStateType")]
    public enum ShareLeaseState
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
