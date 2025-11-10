// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The status of the mark data.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MarkStatus
    {
        /// <summary>
        /// The marker is completed
        /// </summary>
        Completed,

        /// <summary>
        /// The marker is in cancelled
        /// </summary>
        Cancelled,
    }
}
