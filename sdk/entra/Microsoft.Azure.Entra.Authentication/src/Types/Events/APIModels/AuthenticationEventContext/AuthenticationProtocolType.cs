// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// The authentication protocol used for the request to Azure AD.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthenticationProtocolType
    {
        /// <summary>
        /// Represents the OAuth 2.0 protocol
        /// </summary>
        [EnumMember(Value = "OAUTH2.0")]
        OAUTH2 = 0,

        /// <summary>
        /// Represents the SAML protocol
        /// </summary>
        [EnumMember(Value = "SAML")]
        SAML = 1,

        /// <summary>
        /// Represents the WS-FED protocol
        /// </summary>
        [EnumMember(Value = "WS-FED")]
        WSFED = 2,

        /// <summary>
        /// Make the enum evolable with an unknown future value.
        /// </summary>
        UnkownFutureValue = 3,
    }
}
