// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Service Copy Status
    /// </summary>
    public enum ServiceCopyStatus
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
