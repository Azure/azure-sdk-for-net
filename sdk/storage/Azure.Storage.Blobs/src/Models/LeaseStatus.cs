// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// LeaseStatus.
    /// </summary>
    [CodeGenModel("LeaseStatusType")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum LeaseStatus
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
