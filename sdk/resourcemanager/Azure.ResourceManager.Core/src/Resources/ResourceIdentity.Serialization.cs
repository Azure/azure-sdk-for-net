// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    [JsonConverter(typeof(ResourceIdentityConverter))]
    public partial class ResourceIdentity : IUtf8JsonSerializable
    {
        /// <summary>
        /// Converts an <see cref="ResourceIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SystemAssignedIdentity))
            {
                writer.WritePropertyName("systemAssignedIdentity");
                writer.WriteObjectValue(SystemAssignedIdentity);
            }

            if (Optional.IsCollectionDefined(UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var item in UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static ResourceIdentity DeserializeResourceIdentity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
            {
                throw new ArgumentException("JsonElement cannot be undefined ", nameof(element));
            }

            Optional<SystemAssignedIdentity> systemAssignedIdentity = default;
            IDictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userAssignedIdentities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        userAssignedIdentities = null;
                        continue;
                    }

                    userAssignedIdentities = new Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity>();
                    string resourceId = string.Empty;
                    foreach (var keyValuePair in property.Value.EnumerateObject())
                    {
                        resourceId = keyValuePair.Name;
                        var userAssignedIdentity = UserAssignedIdentity.DeserializeUserAssignedIdentity(keyValuePair.Value);
                        userAssignedIdentities.Add(new ResourceGroupResourceIdentifier(resourceId), userAssignedIdentity);
                    }

                    continue;
                }

                if (property.NameEquals("systemAssignedIdentity"))
                {
                    systemAssignedIdentity = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(property.Value);
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
