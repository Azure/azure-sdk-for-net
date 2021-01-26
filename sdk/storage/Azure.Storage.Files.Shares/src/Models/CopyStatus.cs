// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// State of the copy operation identified by 'x-ms-copy-id'.
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    [CodeGenModel("CopyStatusType")]
    public enum CopyStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// pending
        /// </summary>
        Pending,

        /// <summary>
        /// success
        /// </summary>
        Success,

        /// <summary>
        /// aborted
        /// </summary>
        Aborted,

        /// <summary>
        /// failed
        /// </summary>
        Failed
    }
}
