// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using System.Net.Sockets;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal static partial class SiteKeyContent
    {
        internal static SiteKey DeserializeSiteKey(this string encodedSiteKey)
        {
            string jsonString  = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedSiteKey));
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);
            return DeserializeSiteKeyFromJSON(jsonElement);
        }

        internal static SiteKey DeserializeSiteKeyFromJSON(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException("Expected a JSON object at the root level of SiteKey document.");
            }

            ResourceIdentifier resourceId = default;
            string aadEndpoint = default;
            string armEndpoint = default;
            string tenantId = default;
            string clientId = default;
            string clientSecret = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceId"u8))
                {
                    resourceId = new ResourceIdentifier(property.Value.GetString());
                    BootstrapConfigurationResource.ValidateResourceId(resourceId);
                }
                else if (property.NameEquals("aadEndpoint"u8))
                {
                    aadEndpoint = property.Value.GetString();
                }
                else if (property.NameEquals("armEndPoint"u8))
                {
                    armEndpoint = property.Value.GetString();
                }
                else if (property.NameEquals("tenantId"u8))
                {
                    tenantId = property.Value.GetString();
                    CheckValidGuid(tenantId, "tenantId");
                }
                else if (property.NameEquals("clientId"u8))
                {
                    clientId = property.Value.GetString();
                    CheckValidGuid(clientId, "clientId");
                }
                else if (property.NameEquals("clientSecret"u8))
                {
                    clientSecret = property.Value.GetString();
                }
                else
                {
                    throw new JsonException($"Invalid/Unknown property found.");
                }
            }

            return new SiteKey
            {
                ResourceId = resourceId.ToString(),
                AadEndpoint = aadEndpoint,
                TenantId = tenantId,
                ClientId = clientId,
                ArmEndPoint = armEndpoint,
                ClientSecret = clientSecret
            };
        }

        private static void CheckValidGuid(string value, string propertyName)
        {
            if (!Guid.TryParse(value, out _))
            {
                throw new JsonException($"Expected a UUID for {propertyName}.");
            }
        }
    }
}
