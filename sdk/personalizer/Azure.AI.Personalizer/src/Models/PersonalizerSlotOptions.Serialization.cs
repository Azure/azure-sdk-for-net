// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    public partial class PersonalizerSlotOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            if (Optional.IsCollectionDefined(Features))
            {
                writer.WritePropertyName("features");
                using var jsonDocument = JsonDocument.Parse(JsonSerializer.Serialize(Features));
                jsonDocument.WriteTo(writer);
            }
            if (Optional.IsCollectionDefined(ExcludedActions))
            {
                writer.WritePropertyName("excludedActions");
                writer.WriteStartArray();
                foreach (var item in ExcludedActions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("baselineAction");
            writer.WriteStringValue(BaselineAction);
            writer.WriteEndObject();
        }
    }
}
