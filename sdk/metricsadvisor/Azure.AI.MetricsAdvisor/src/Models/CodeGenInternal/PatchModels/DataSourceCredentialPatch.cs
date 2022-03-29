// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataSourceCredentialPatch
    {
        protected void SerializeCommonProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("dataSourceCredentialType");
            writer.WriteStringValue(DataSourceCredentialType.ToString());
            writer.WriteNullObjectValue("dataSourceCredentialName", DataSourceCredentialName);
            writer.WriteNullObjectValue("dataSourceCredentialDescription", DataSourceCredentialDescription);
        }

        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            SerializeCommonProperties(writer);
            writer.WriteEndObject();
        }
    }
}
