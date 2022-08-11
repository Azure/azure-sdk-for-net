// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Or Data class that represents the inbound Json payload, also has helper functions for serialization.</summary>
    public abstract class AuthEventData
    {
        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("tenantId")]
        public Guid TenantId { get; set; }

        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("authenticationEventListenerId")]
        public Guid AuthenticationEventListenerId { get; set; }

        /// <summary>Gets or sets the custom extension identifier.</summary>
        /// <value>The custom extension identifier.</value>
        [JsonPropertyName("AuthenticationEventsId")]
        public Guid AuthenticationEventsId { get; set; }

        /// <summary>Gets the Json settings.
        /// Which is over-ridable for sub class.</summary>
        /// <value>The json settings.</value>
        private JsonSerializerOptions JsonSettings
        {
            get
            {
                var jsonOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                InitJsonSerializerSettings(jsonOptions);
                return jsonOptions;
            }
        }

        internal virtual void InitJsonSerializerSettings(JsonSerializerOptions jsonSerializerSettings) { }

        /// <summary>De-serializes the json the its associated typed object.</summary>
        /// <param name="json">The json containing the typed structure.</param>
        /// <returns>Returns the typed structure that inherits EventData.</returns>
        internal virtual AuthEventData FromJson(AuthEventJsonElement json) => (AuthEventData)JsonSerializer.Deserialize(json.ToString(), GetType(), JsonSettings);

        /// <summary>Creates an instance of a EventDaa sub class based on the type and json payload via reflection.</summary>
        /// <param name="type">The type to create.</param>
        /// <param name="json">The json payload.</param>
        /// <returns>A created instance of EventData based on the Type.</returns>
        /// <seealso cref="AuthEventData"/>
        internal static AuthEventData CreateInstance(Type type, AuthEventJsonElement json)
        {
            AuthEventData data = (AuthEventData)Activator.CreateInstance(type, true);
            return data.FromJson(json);
        }
    }
}
