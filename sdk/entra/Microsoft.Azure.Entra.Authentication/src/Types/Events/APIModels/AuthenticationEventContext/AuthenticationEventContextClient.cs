// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Represents the client context data that will be sent to the registered custom extension.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AuthenticationEventContextClient
    {
        /// <summary>Gets or sets the client ip.</summary>
        /// <value>The client ip.</value>
        [JsonProperty("ip")]
        public string ClientIP { get; set; }

        /// <summary>Gets or sets the locale string.</summary>
        /// <value>The locale string.</value>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>Gets or sets the market string.</summary>
        /// <value>The market string.</value>
        [JsonProperty("market")]
        public string Market { get; set; }
    }
}
