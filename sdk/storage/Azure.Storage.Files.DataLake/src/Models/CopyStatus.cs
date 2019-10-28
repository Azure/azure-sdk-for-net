// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// CopyStatus values
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
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
