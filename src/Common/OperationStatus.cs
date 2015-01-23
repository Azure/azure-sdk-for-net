// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure
{
    /// <summary>
    /// The status of the asynchronous request.
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// The asynchronous request is in progress.
        /// </summary>
        InProgress,

        /// <summary>
        /// The asynchronous request succeeded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The asynchronous request failed.
        /// </summary>
        Failed
    }
}
