// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    public abstract partial class AuthBaseInfo : IUtf8JsonSerializable
    {
        internal static AuthBaseInfo DeserializeAuthBaseInfo(JsonElement element)
        {
            if (element.TryGetProperty("authType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "secret": return SecretAuthInfo.DeserializeSecretAuthInfo(element);
                    case "servicePrincipalCertificate": return ServicePrincipalCertificateAuthInfo.DeserializeServicePrincipalCertificateAuthInfo(element);
                    case "servicePrincipalSecret": return ServicePrincipalSecretAuthInfo.DeserializeServicePrincipalSecretAuthInfo(element);
                    case "systemAssignedIdentity": return SystemAssignedIdentityAuthInfo.DeserializeSystemAssignedIdentityAuthInfo(element);
                    case "userAssignedIdentity": return UserAssignedIdentityAuthInfo.DeserializeUserAssignedIdentityAuthInfo(element);
                }
            }
            throw new JsonException($"The deserialization of {typeof(AuthBaseInfo)} failed because of the invalid discriminator value.");
        }
    }
}
