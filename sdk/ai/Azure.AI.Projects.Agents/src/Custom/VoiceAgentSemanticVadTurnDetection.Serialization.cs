// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

[CodeGenSerialization(nameof(Eagerness), SerializationValueHook = nameof(SerializeEagernessValue), DeserializationValueHook = nameof(DeserializeEagernessValue))]
public partial class VoiceAgentSemanticVadTurnDetection
{
    // CUSTOM: RealtimeSemanticVadEagernessLevel is a string-valued struct from the OpenAI library, not a model. The generated
    // code routes it through ModelReaderWriter, which throws "No ModelReaderWriterTypeBuilder found".
    // Read and write it as a JSON string instead.
    private void SerializeEagernessValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(Eagerness.Value.ToString());
    }

    private static void DeserializeEagernessValue(JsonProperty property, ref RealtimeSemanticVadEagernessLevel? eagerness, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            eagerness = null;
            return;
        }
        eagerness = new RealtimeSemanticVadEagernessLevel(property.Value.GetString());
    }
}
