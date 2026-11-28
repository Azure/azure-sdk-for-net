// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;
# pragma warning disable AAIP002

[CodeGenSerialization(nameof(AllowedTools), DeserializationValueHook = nameof(DeserializeAllowedToolsValue))]
[CodeGenSerialization(nameof(ConnectorId), SerializationValueHook = nameof(SerializeConnectorIdValue), DeserializationValueHook = nameof(DeserializeConnectorIdValue))]
public partial class McpToolboxTool : IJsonModel<McpToolboxTool>
{
    // CUSTOM: Accepts the MCP shorthand allowed_tools array form and normalizes it into McpToolFilter.
    private static void DeserializeAllowedToolsValue(JsonProperty property, ref McpToolFilter allowedTools, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            allowedTools = null;
            return;
        }

        if (property.Value.ValueKind == JsonValueKind.Object)
        {
            allowedTools = ModelReaderWriter.Read<McpToolFilter>(property.Value.GetUtf8Bytes(), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
            return;
        }

        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            // Initialize the collection to respect an empty array during normalization.
            allowedTools = new McpToolFilter()
            {
                ToolNames = { }
            };
            foreach (JsonElement item in property.Value.EnumerateArray())
            {
                allowedTools.ToolNames.Add(item.ValueKind == JsonValueKind.Null ? null : item.GetString());
            }
            return;
        }

        throw new InvalidOperationException($"Expected allowed_tools to be null, an object, or an array but found {property.Value.ValueKind}.");
    }

    // CUSTOM: McpToolConnectorId is a string-valued struct from the OpenAI library, not a model. The generated
    // code routes it through ModelReaderWriter, which throws "No ModelReaderWriterTypeBuilder found".
    // Read and write it as a JSON string instead.
    private void SerializeConnectorIdValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(ConnectorId.Value.ToString());
    }

    private static void DeserializeConnectorIdValue(JsonProperty property, ref McpToolConnectorId? connectorId, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            connectorId = null;
            return;
        }
        connectorId = new McpToolConnectorId(property.Value.GetString());
    }
}
