// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>Data model for custom extension API response</summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CustomExtensionCalloutResponse
    {
        /// <summary>Gets or sets the custom extension type.</summary>
        /// <value>The custom extension type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the custom extension callout response source that can be set by customer.
        /// Maximum length is 256
        /// </summary>
        /// <value>Source of response</value>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets Data that is received from custom extension endpoint.
        /// Typically contains actions with corresponding configuration,
        /// which define what a custom extension can tell Azure AD to do for a given event.
        /// </summary>
        /// <value>Data recieved from the custom extension</value>
        [JsonProperty("data")]
        public CustomExtensionCalloutResponseData Data { get; set; }
    }
}