// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    public partial class PersonalizerRankMultiSlotOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(ContextFeatures))
            {
                writer.WritePropertyName("contextFeatures");
                using var jsonDocument = JsonDocument.Parse(JsonSerializer.Serialize(ContextFeatures));
                jsonDocument.WriteTo(writer);
            }
            writer.WritePropertyName("actions");
            writer.WriteStartArray();
            foreach (var item in Actions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("slots");
            writer.WriteStartArray();
            foreach (var item in Slots)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(EventId))
            {
                writer.WritePropertyName("eventId");
                writer.WriteStringValue(EventId);
            }
            if (Optional.IsDefined(DeferActivation))
            {
                writer.WritePropertyName("deferActivation");
                writer.WriteBooleanValue(DeferActivation.Value);
            }
            writer.WriteEndObject();
        }
    }
}
