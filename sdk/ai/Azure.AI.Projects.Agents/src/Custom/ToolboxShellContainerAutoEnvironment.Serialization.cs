// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Containers;

namespace Azure.AI.Projects.Agents;

[CodeGenSerialization(nameof(MemoryLimit), SerializationValueHook = nameof(SerializeMemoryLimitValue), DeserializationValueHook = nameof(DeserializeMemoryLimitValue))]
public partial class ToolboxShellContainerAutoEnvironment
{
    // CUSTOM: ContainerMemoryLimit is a string-valued struct from the OpenAI library, not a model. The generated
    // code routes it through ModelReaderWriter, which throws "No ModelReaderWriterTypeBuilder found".
    // Read and write it as a JSON string instead.
    private void SerializeMemoryLimitValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(MemoryLimit.Value.ToString());
    }

    private static void DeserializeMemoryLimitValue(JsonProperty property, ref ContainerMemoryLimit? memoryLimit, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            memoryLimit = null;
            return;
        }
        memoryLimit = new ContainerMemoryLimit(property.Value.GetString());
    }
}
