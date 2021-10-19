// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class ServicePrincipalInKVParamPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("keyVaultEndpoint", KeyVaultEndpoint);
            writer.WriteNullObjectValue("keyVaultClientId", KeyVaultClientId);
            if (Optional.IsDefined(KeyVaultClientSecret))
            {
                writer.WritePropertyName("keyVaultClientSecret");
                writer.WriteStringValue(KeyVaultClientSecret);
            }
            writer.WriteNullObjectValue("servicePrincipalIdNameInKV", ServicePrincipalIdNameInKV);
            writer.WriteNullObjectValue("servicePrincipalSecretNameInKV", ServicePrincipalSecretNameInKV);
            writer.WriteNullObjectValue("tenantId", TenantId);
            writer.WriteEndObject();
        }
    }
}
