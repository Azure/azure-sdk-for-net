// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

/// <summary>
/// Builds metadata for hosted MCP (Model Context Protocol) tools from API responses.
/// </summary>
internal static class McpToolsMetadataBuilder
{
    /// <summary>
    /// Enriches raw tool dictionaries with hosted tool definitions from configuration.
    /// Filters tools to only include those that match configured hosted MCP tools.
    /// </summary>
    /// <param name="rawTools">The list of raw tool dictionaries from the API response.</param>
    /// <param name="hostedMcpTools">The list of hosted MCP tools from configuration.</param>
    public static void EnrichWithHostedToolDefinitions(
        List<Dictionary<string, object?>> rawTools,
        IReadOnlyList<FoundryHostedMcpTool> hostedMcpTools)
    {
        if (rawTools.Count == 0 || hostedMcpTools.Count == 0)
        {
            return;
        }

        var toolsByName = hostedMcpTools
            .GroupBy(tool => tool.Name, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

        var filteredTools = new List<Dictionary<string, object?>>(rawTools.Count);

        foreach (var raw in rawTools)
        {
            var (toolName, _) = ToolMetadataExtractor.ExtractNameDescription(raw);
            if (string.IsNullOrWhiteSpace(toolName) ||
                !toolsByName.TryGetValue(toolName, out var foundryTool))
            {
                continue;
            }

            raw["foundry_tool"] = foundryTool;
            filteredTools.Add(raw);
        }

        rawTools.Clear();
        rawTools.AddRange(filteredTools);
    }
}
