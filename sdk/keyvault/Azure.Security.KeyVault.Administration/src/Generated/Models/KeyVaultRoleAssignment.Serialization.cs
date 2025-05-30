// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace Azure.Security.KeyVault.Administration
{
    public partial class KeyVaultRoleAssignment
    {
        internal static KeyVaultRoleAssignment DeserializeKeyVaultRoleAssignment(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string name = default;
            string type = default;
            KeyVaultRoleAssignmentProperties properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = KeyVaultRoleAssignmentProperties.DeserializeKeyVaultRoleAssignmentProperties(property.Value);
                    continue;
                }
            }
            return new KeyVaultRoleAssignment(id, name, type, properties);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static KeyVaultRoleAssignment FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeKeyVaultRoleAssignment(document.RootElement);
        }
    }
}
