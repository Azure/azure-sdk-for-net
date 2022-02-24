// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

[assembly: CodeGenSuppressType("ManagedServiceIdentity")]
namespace Azure.ResourceManager.Models
{
    [JsonConverter(typeof(ManagedServiceIdentityConverter))]
    public partial class ManagedServiceIdentity
    {
        internal static void Write(Utf8JsonWriter writer, ManagedServiceIdentity model, JsonSerializerOptions options = default)
        {
            writer.WriteStartObject();
            JsonSerializer.Serialize(writer, model.Type, options);
            if (Optional.IsCollectionDefined(model.UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var item in model.UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        writer.WriteObjectValue(item.Value);
                    }
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static ManagedServiceIdentity DeserializeManagedServiceIdentity(JsonElement element, JsonSerializerOptions options = default)
        {
            Optional<Guid> principalId = default;
            Optional<Guid> tenantId = default;
            ManagedServiceIdentityType type = default;
            Optional<IDictionary<string, UserAssignedIdentity>> userAssignedIdentities = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    principalId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = JsonSerializer.Deserialize<ManagedServiceIdentityType>("{"+property.ToString()+"}", options);
                    continue;
                }
                if (property.NameEquals("userAssignedIdentities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, UserAssignedIdentity> dictionary = new Dictionary<string, UserAssignedIdentity>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, UserAssignedIdentity.DeserializeUserAssignedIdentity(property0.Value));
                    }
                    userAssignedIdentities = dictionary;
                    continue;
                }
            }
            return new ManagedServiceIdentity(Optional.ToNullable(principalId), Optional.ToNullable(tenantId), type, Optional.ToDictionary(userAssignedIdentities));
        }

        internal partial class ManagedServiceIdentityConverter : JsonConverter<ManagedServiceIdentity>
        {
            public override void Write(Utf8JsonWriter writer, ManagedServiceIdentity model, JsonSerializerOptions options)
            {
                ManagedServiceIdentity.Write(writer, model, options);
            }
            public override ManagedServiceIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeManagedServiceIdentity(document.RootElement, options);
            }
        }
    }
}
