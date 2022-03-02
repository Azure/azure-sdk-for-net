// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// Indicates whether the invocation of a long running operation should return once it has
    /// started or wait for the operation to fully complete before returning.
    /// </summary>
    public enum WaitUntil
    {
        /// <summary>
        /// Indicates the method should wait until the operation fully completes.
        /// </summary>
        Completed,
        /// <summary>
        /// Indicates the method should return once the operation has started.
        /// </summary>
        Started
    }
}
