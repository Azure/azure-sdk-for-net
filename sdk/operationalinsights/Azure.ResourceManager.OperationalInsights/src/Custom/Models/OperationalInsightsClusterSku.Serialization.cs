// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("OperationalInsightsClusterSku")]
namespace Azure.ResourceManager.OperationalInsights.Models
{
    public partial class OperationalInsightsClusterSku : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(Capacity.Value.ToSerialInt64());
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static OperationalInsightsClusterSku DeserializeOperationalInsightsClusterSku(JsonElement element)
        {
            Optional<OperationalInsightsClusterCapacity> capacity = default;
            Optional<OperationalInsightsClusterSkuName> name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt64().ToOperationalInsightsClusterCapacity();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    name = new OperationalInsightsClusterSkuName(property.Value.GetString());
                    continue;
                }
            }
            return new OperationalInsightsClusterSku(Optional.ToNullable(capacity), Optional.ToNullable(name));
        }
    }
}
