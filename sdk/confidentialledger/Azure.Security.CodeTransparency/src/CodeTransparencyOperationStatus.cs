// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Represents the status of an operation in CTS.
    /// </summary>
    public enum CodeTransparencyOperationStatus
    {
        /// <summary>
        /// The operation is still running.
        /// </summary>
        Running,
        /// <summary>
        /// The operation failed.
        /// </summary>
        Failed,
        /// <summary>
        /// The operation succeeded and a transaction ID has been recorded.
        /// </summary>
        Succeeded
    }
}
