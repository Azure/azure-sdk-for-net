// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>Add commentMore actions
    /// Enum representing the prefix to be used for SIP X headers.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SipHeaderPrefix
    {
        /// <summary>
        /// Use the legacy "X-MS-Custom-" prefix.
        /// </summary>
        XmsCustom = 0,

        /// <summary>
        /// Use the generic "X-" prefix.
        /// </summary>
        X = 1
    }
}
