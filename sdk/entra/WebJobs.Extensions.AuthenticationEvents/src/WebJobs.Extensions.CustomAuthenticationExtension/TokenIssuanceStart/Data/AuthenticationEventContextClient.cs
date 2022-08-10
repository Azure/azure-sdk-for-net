// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    /// <summary>Represents the Client Data Model Object.</summary>
    public class AuthenticationEventContextClient
    {
        /// <summary>Gets the ip.</summary>
        /// <value>The ip.</value>
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        /// <value>The locale.</value>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>Gets or sets the market.</summary>
        /// <value>The market.</value>
        [JsonPropertyName("market")]
        public string Market { get; set; }
    }
}