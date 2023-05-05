// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Status of Import Job
    /// </summary>
    [CodeGenModel("Status")]
    public enum ImportJobStatus
    {
        /// <summary> notstarted. </summary>
        Notstarted,
        /// <summary> running. </summary>
        Running,
        /// <summary> failed. </summary>
        Failed,
        /// <summary> succeeded. </summary>
        Succeeded,
        /// <summary> cancelling. </summary>
        Cancelling,
        /// <summary> cancelled. </summary>
        Cancelled
    }
}
