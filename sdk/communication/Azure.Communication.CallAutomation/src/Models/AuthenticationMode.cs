// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Authentication mode for retrieving different types of authentication information.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    internal enum AuthenticationMode
    {
        /// <summary>
        /// Retrieve only the Authorization header value for AAD token extraction.
        /// </summary>
        AadToken,
        /// <summary>
        /// Retrieve comprehensive HMAC authentication information including signature, date, and content SHA256.
        /// </summary>
        Hmac
    }
}
