// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

[CodeGenSerialization(nameof(Status), SerializationValueHook = nameof(SerializeStatusValue), DeserializationValueHook = nameof(DeserializeStatusValue))]
[CodeGenSerialization(nameof(OutputModalities), SerializationValueHook = nameof(SerializeOutputModalitiesValue), DeserializationValueHook = nameof(DeserializeOutputModalitiesValue))]
public partial class VoiceResult
{
    // CUSTOM: RealtimeResponseStatus and RealtimeOutputModality are string-valued structs from the
    // OpenAI library, not models. The generated code routes them through ModelReaderWriter, which
    // throws "No ModelReaderWriterTypeBuilder found". Read and write them as JSON strings instead.
    private void SerializeStatusValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(Status.Value.ToString());
    }

    private static void DeserializeStatusValue(JsonProperty property, ref RealtimeResponseStatus? status, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            return;
        }
        status = new RealtimeResponseStatus(property.Value.GetString());
    }

    private void SerializeOutputModalitiesValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartArray();
        foreach (RealtimeOutputModality item in OutputModalities)
        {
            writer.WriteStringValue(item.ToString());
        }
        writer.WriteEndArray();
    }

    private static void DeserializeOutputModalitiesValue(JsonProperty property, ref IList<RealtimeOutputModality> outputModalities, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            return;
        }
        List<RealtimeOutputModality> array = new List<RealtimeOutputModality>();
        foreach (JsonElement item in property.Value.EnumerateArray())
        {
            array.Add(new RealtimeOutputModality(item.GetString()));
        }
        outputModalities = array;
    }
}
