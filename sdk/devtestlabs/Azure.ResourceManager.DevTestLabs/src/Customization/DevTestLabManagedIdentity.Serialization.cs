// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DevTestLabs.Models
{
    // This customization is here to override the serialization and deserialization for `ManagedIdentityType`
    public partial class DevTestLabManagedIdentity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ManagedIdentityType))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(ManagedIdentityType.ToString());
            }
            if (Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId");
                writer.WriteStringValue(PrincipalId.Value);
            }
            if (Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId");
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsDefined(ClientSecretUri))
            {
                writer.WritePropertyName("clientSecretUrl");
                writer.WriteStringValue(ClientSecretUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static DevTestLabManagedIdentity DeserializeDevTestLabManagedIdentity(JsonElement element)
        {
            Optional<ManagedServiceIdentityType> type = default;
            Optional<Guid> principalId = default;
            Optional<Guid> tenantId = default;
            Optional<Uri> clientSecretUrl = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = JsonSerializer.Deserialize<ManagedServiceIdentityType>("{" + property.ToString() + "}");
                    continue;
                }
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
                if (property.NameEquals("clientSecretUrl"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        clientSecretUrl = null;
                        continue;
                    }
                    clientSecretUrl = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new DevTestLabManagedIdentity(type, Optional.ToNullable(principalId), Optional.ToNullable(tenantId), clientSecretUrl.Value);
        }
    }
}
