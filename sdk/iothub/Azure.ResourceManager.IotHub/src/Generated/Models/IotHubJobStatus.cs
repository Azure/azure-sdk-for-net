// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.IotHub.Models
{
    /// <summary> The status of the job. </summary>
    public enum IotHubJobStatus
    {
        /// <summary> unknown. </summary>
        Unknown,
        /// <summary> enqueued. </summary>
        Enqueued,
        /// <summary> running. </summary>
        Running,
        /// <summary> completed. </summary>
        Completed,
        /// <summary> failed. </summary>
        Failed,
        /// <summary> cancelled. </summary>
        Cancelled
    }
}
