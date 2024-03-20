// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>Enum for the type of event the handler is for</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType
    {
        /// <summary>
        /// OnTokenIssuanceStart event type.
        /// </summary>
        [JsonProperty("tokenIssuanceStart")]
        OnTokenIssuanceStart,
    }
}
