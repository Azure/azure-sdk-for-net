// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// Whether the task counts have been validated.
    /// </summary>
    public enum TaskCountValidationStatus
    {
        /// <summary>
        /// The task counts have been validated and are guaranteed to match the List Tasks results.
        /// </summary>
        Validated,

        /// <summary>
        ///  The Batch service has not been able to check state counts against the task states as reported in the List Tasks API.
        /// </summary>
        Unvalidated
    }
}
