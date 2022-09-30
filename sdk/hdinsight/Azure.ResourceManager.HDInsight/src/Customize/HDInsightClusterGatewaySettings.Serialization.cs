// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("HDInsightClusterGatewaySettings")]

namespace Azure.ResourceManager.HDInsight.Models
{
    public partial class HDInsightClusterGatewaySettings
    {
        internal static HDInsightClusterGatewaySettings DeserializeHDInsightClusterGatewaySettings(JsonElement element)
        {
            Optional<bool> restAuthCredentialIsEnabled = default;
            Optional<string> restAuthCredentialUsername = default;
            Optional<string> restAuthCredentialPassword = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("restAuthCredential.isEnabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    if (property.Value.ValueKind == JsonValueKind.String)
                    {
                        restAuthCredentialIsEnabled = bool.Parse(property.Value.GetString());
                        continue;
                    }
                    restAuthCredentialIsEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("restAuthCredential.username"))
                {
                    restAuthCredentialUsername = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("restAuthCredential.password"))
                {
                    restAuthCredentialPassword = property.Value.GetString();
                    continue;
                }
            }
            return new HDInsightClusterGatewaySettings(Optional.ToNullable(restAuthCredentialIsEnabled), restAuthCredentialUsername.Value, restAuthCredentialPassword.Value);
        }
    }
}
