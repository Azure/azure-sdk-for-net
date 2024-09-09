// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal static class SiteKeyContent
    {
        internal static SiteKey DeserializeSiteKey(this string encodedSiteKey) => SiteKeyContent.DeserializeSiteKeyFromJSON(JsonSerializer.Deserialize<JsonElement>(Encoding.UTF8.GetString(Convert.FromBase64String(encodedSiteKey)), (JsonSerializerOptions)null));

        internal static SiteKey DeserializeSiteKeyFromJSON(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
                throw new JsonException("Expected a JSON object at the root level of SiteKey document.");
            ResourceIdentifier resourceIdentifier = null;
            string str1 = null;
            string str2 = null;
            string str3 = null;
            string str4 = null;
            string str5 = null;
            JsonElement.ObjectEnumerator objectEnumerator = element.EnumerateObject();
            JsonElement jsonElement;
            foreach (JsonProperty jsonProperty in objectEnumerator)
            {
                if (jsonProperty.NameEquals("resourceId"))
                {
                    jsonElement = jsonProperty.Value;
                    resourceIdentifier = new ResourceIdentifier(jsonElement.GetString());
                }
                else if (jsonProperty.NameEquals("aadEndpoint"))
                {
                    jsonElement = jsonProperty.Value;
                    str1 = jsonElement.GetString();
                }
                else if (jsonProperty.NameEquals("armEndPoint"))
                {
                    jsonElement = jsonProperty.Value;
                    str2 = jsonElement.GetString();
                }
                else if (jsonProperty.NameEquals("tenantId"))
                {
                    jsonElement = jsonProperty.Value;
                    str3 = jsonElement.GetString();
                    SiteKeyContent.CheckValidGuid(str3, "tenantId");
                }
                else if (jsonProperty.NameEquals("clientId"))
                {
                    jsonElement = jsonProperty.Value;
                    str4 = jsonElement.GetString();
                    SiteKeyContent.CheckValidGuid(str4, "clientId");
                }
                else if (jsonProperty.NameEquals("clientSecret"))
                {
                    jsonElement = jsonProperty.Value;
                    str5 = jsonElement.GetString();
                }
                else
                {
                    throw new JsonException("Invalid/Unknown property found.");
                }
            }
            return new SiteKey()
            {
                ResourceId = resourceIdentifier.ToString(),
                AadEndpoint = str1,
                TenantId = str3,
                ClientId = str4,
                ArmEndPoint = str2,
                ClientSecret = str5
            };
        }

        private static void CheckValidGuid(string value, string propertyName)
        {
            if (!Guid.TryParse(value, out Guid _))
                throw new JsonException("Expected a UUID for " + propertyName + ".");
        }

        internal static TokenCredential GenerateTokenCredential(this SiteKey siteKey)
        {
            ClientCertificateCredentialOptions credentialOptions1 = new ClientCertificateCredentialOptions();
            credentialOptions1.AuthorityHost = new Uri(siteKey.AadEndpoint);
            credentialOptions1.SendCertificateChain = true;
            return new ClientCertificateCredential(siteKey.TenantId, siteKey.ClientId, new X509Certificate2(Convert.FromBase64String(siteKey.ClientSecret)), credentialOptions1);
        }

        internal static ArmClient CreateArmClient(
          this SiteKey siteKey,
          ArmClientOptions armClientOptions)
        {
            if (armClientOptions == null)
                armClientOptions = new ArmClientOptions();
            armClientOptions.Environment = new ArmEnvironment(new Uri(siteKey.ArmEndPoint), siteKey.ArmEndPoint);
            return new ArmClient(siteKey.GenerateTokenCredential(), new ResourceIdentifier(siteKey.ResourceId).SubscriptionId, armClientOptions);
        }
    }
}
