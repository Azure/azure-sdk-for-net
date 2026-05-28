// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AzureLogAnalyticsParameterPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("tenantId", TenantId);
            writer.WriteNullObjectValue("clientId", ClientId);
            if (Optional.IsDefined(ClientSecret))
            {
                writer.WritePropertyName("clientSecret");
                writer.WriteStringValue(ClientSecret);
            }
            writer.WriteNullObjectValue("workspaceId", WorkspaceId);
            writer.WriteNullObjectValue("query", Query);
            writer.WriteEndObject();
        }
    }
}
