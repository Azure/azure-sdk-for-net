// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    [JsonConverter(typeof(ResourceIdentityConverter))]
    public partial class ResourceIdentity : IUtf8JsonSerializable
    {
        private const string SystemAssigned = "SystemAssigned";
        private const string UserAssigned = "UserAssigned";
        private const string SystemAndUserAssigned = "SystemAssigned, UserAssigned";

        /// <summary>
        /// Converts an <see cref="ResourceIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.WriteStartObject();
            writer.WritePropertyName("identity");

            if (!Optional.IsDefined(SystemAssignedIdentity) && UserAssignedIdentities.Count == 0)
            {
                writer.WriteStringValue("null");
                writer.WriteEndObject();
                writer.Flush();
                return;
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(SystemAssignedIdentity) && Optional.IsCollectionDefined(UserAssignedIdentities) && UserAssignedIdentities.Count != 0)
            {
                writer.WriteObjectValue(SystemAssignedIdentity);
                writer.WritePropertyName("type");
                writer.WriteStringValue(SystemAndUserAssigned);
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var keyValuePair in UserAssignedIdentities)
                {
                    writer.WritePropertyName(keyValuePair.Key);
                    writer.WriteObjectValue(keyValuePair.Value);
                }

                writer.WriteEndObject();
            }
            else if (Optional.IsDefined(SystemAssignedIdentity))
            {
                writer.WriteObjectValue(SystemAssignedIdentity);
                writer.WritePropertyName("type");
                writer.WriteStringValue(SystemAssigned);
            }
            else if (Optional.IsCollectionDefined(UserAssignedIdentities) && UserAssignedIdentities.Count != 0)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(UserAssigned);
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var keyValuePair in UserAssignedIdentities)
                {
                    writer.WritePropertyName(keyValuePair.Key);
                    writer.WriteObjectValue(keyValuePair.Value);
                }

                writer.WriteEndObject();
            }

            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
        }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="ResourceIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an <see cref="ResourceIdentity"/>. </param>
        /// <returns> New Identity object with JSON values. </returns>
        internal static ResourceIdentity DeserializeResourceIdentity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
            {
                throw new ArgumentException("JsonElement cannot be undefined ", nameof(element));
            }

            Optional<SystemAssignedIdentity> systemAssignedIdentity = default;
            IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            string type = string.Empty;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userAssignedIdentities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        userAssignedIdentities = null;
                        continue;
                    }

                    string resourceId = string.Empty;
                    foreach (var keyValuePair in property.Value.EnumerateObject())
                    {
                        resourceId = keyValuePair.Name;
                        var userAssignedIdentity = UserAssignedIdentity.DeserializeUserAssignedIdentity(keyValuePair.Value);
                        userAssignedIdentities.Add(new ResourceIdentifier(resourceId), userAssignedIdentity);
                    }

                    continue;
                }

                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        throw new InvalidOperationException("The type property had a JsonValueKind equal to Null");
                    }

                    type = property.Value.GetString();
                }

                if (type.Equals(SystemAssigned))
                {
                    systemAssignedIdentity = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(element);
                    continue;
                }

                if (type.Equals(SystemAndUserAssigned))
                {
                    systemAssignedIdentity = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(element);
                    continue;
                }
            }

            return new ResourceIdentity(systemAssignedIdentity, userAssignedIdentities);
        }

        internal partial class ResourceIdentityConverter : JsonConverter<ResourceIdentity>
        {
            public override void Write(Utf8JsonWriter writer, ResourceIdentity resourceIdentity, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(resourceIdentity);
            }
            public override ResourceIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeResourceIdentity(document.RootElement);
            }
        }
    }
}
