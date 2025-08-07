// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Or Data class that represents the inbound Json payload, also has helper functions for serialization.</summary>
    public abstract class WebJobsAuthenticationEventData
    {
        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("tenantId")]
        [RequireNonDefault]
        public Guid TenantId { get; set; }

        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("authenticationEventListenerId")]
        [RequireNonDefault]
        public Guid AuthenticationEventListenerId { get; set; }

        /// <summary>Gets or sets the custom authentication extension identifier.</summary>
        /// <value>The custom authentication extension identifier. </value>
        [JsonPropertyName("customAuthenticationExtensionId")]
        [RequireNonDefault]
        public Guid CustomAuthenticationExtensionId { get; set; }

        /// <summary>Gets the Json settings.
        /// Which is over-ridable for sub class.</summary>
        /// <value>The json settings.</value>
        private static JsonSerializerOptions JsonSettings
        {
            get
            {
                var jsonOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                return jsonOptions;
            }
        }

        /// <summary>De-serializes the json the its associated typed object.</summary>
        /// <param name="json">The json containing the typed structure.</param>
        /// <returns>Returns the typed structure that inherits EventData.</returns>
        internal virtual WebJobsAuthenticationEventData FromJson(AuthenticationEventJsonElement json) => (WebJobsAuthenticationEventData)JsonSerializer.Deserialize(json.ToString(), GetType(), JsonSettings);

        /// <summary>Creates an instance of a EventDaa sub class based on the type and json payload via reflection.</summary>
        /// <param name="type">The type to create.</param>
        /// <param name="json">The json payload.</param>
        /// <returns>A created instance of EventData based on the Type.</returns>
        /// <seealso cref="WebJobsAuthenticationEventData"/>
        internal static WebJobsAuthenticationEventData CreateInstance(Type type, AuthenticationEventJsonElement json)
        {
            WebJobsAuthenticationEventData data = (WebJobsAuthenticationEventData)Activator.CreateInstance(type, true);
            return data.FromJson(json);
        }
    }
}
