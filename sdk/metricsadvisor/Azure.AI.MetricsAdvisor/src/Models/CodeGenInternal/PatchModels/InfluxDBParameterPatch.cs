// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class InfluxDBParameterPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ConnectionString))
            {
                writer.WritePropertyName("connectionString");
                writer.WriteStringValue(ConnectionString);
            }
            writer.WriteNullObjectValue("database", Database);
            writer.WriteNullObjectValue("userName", UserName);
            writer.WriteNullObjectValue("password", Password);
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password");
                writer.WriteStringValue(Password);
            }
            writer.WriteNullObjectValue("query", Query);
            writer.WriteEndObject();
        }
    }
}
