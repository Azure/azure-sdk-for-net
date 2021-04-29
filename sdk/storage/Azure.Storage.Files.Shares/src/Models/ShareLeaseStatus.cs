// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The current lease status of the share.
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    [CodeGenModel("LeaseStatusType")]
    public enum ShareLeaseStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// locked
        /// </summary>
        Locked,

        /// <summary>
        /// unlocked
        /// </summary>
        Unlocked
    }
}
