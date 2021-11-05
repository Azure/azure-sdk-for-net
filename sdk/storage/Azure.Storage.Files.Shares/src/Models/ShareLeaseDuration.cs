// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// When a share is leased, specifies whether the lease is of infinite or fixed duration.
    /// </summary>
    [CodeGenModel("LeaseDurationType")]
    public enum ShareLeaseDuration
    {
        /// <summary>
        /// infinite
        /// </summary>
        Infinite,

        /// <summary>
        /// fixed
        /// </summary>
        Fixed
    }
}
