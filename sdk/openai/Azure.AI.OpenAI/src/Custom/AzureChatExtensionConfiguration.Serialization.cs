// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class AzureChatExtensionConfiguration : IUtf8JsonSerializable
    {
        internal void StartCommonSerialization(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());

            // CUSTOM CODE NOTE: Everything *except* 'type' goes into 'parameters'
            writer.WriteStartObject("parameters"u8);
        }

        internal void EndCommonSerialization(Utf8JsonWriter writer)
        {
            if (Optional.IsDefined(Parameters))
            {
                Dictionary<string, object> parameterDictionary
                    = JsonSerializer.Deserialize<Dictionary<string, object>>(
                        Parameters.ToString(),
                        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (KeyValuePair<string, object> pair in parameterDictionary)
                {
                    writer.WritePropertyName(pair.Key);
                    writer.WriteObjectValue(pair.Value);
                }
            }
            // CUSTOM CODE NOTE: End of induced 'parameters' first, then the parent object
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
