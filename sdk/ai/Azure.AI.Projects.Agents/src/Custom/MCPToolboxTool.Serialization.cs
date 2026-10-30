// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;
# pragma warning disable AAIP002

[CodeGenSerialization(nameof(AllowedTools), DeserializationValueHook = nameof(DeserializeAllowedToolsValue))]
public partial class MCPToolboxTool : IJsonModel<MCPToolboxTool>
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
}
