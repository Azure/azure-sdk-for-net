// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

/// <summary>
/// Builds metadata for connected tools from API responses.
/// </summary>
internal static class ConnectedToolsMetadataBuilder
{
    /// <summary>
    /// Parses and enriches tools from a JSON element with foundry tool information.
    /// </summary>
    /// <param name="toolsElement">The JSON element containing tools from the API response.</param>
    /// <param name="foundryTools">The list of foundry connected tools to match against.</param>
    /// <returns>A list of enriched tool dictionaries ready for descriptor building.</returns>
    public static List<Dictionary<string, object?>> ParseEnrichedTools(
        JsonElement toolsElement,
        IReadOnlyList<FoundryConnectedTool> foundryTools)
    {
        var enrichedTools = new List<Dictionary<string, object?>>();

        foreach (var toolEntry in toolsElement.EnumerateArray())
        {
            if (!toolEntry.TryGetProperty("remoteServer", out var remoteServer))
            {
                continue;
            }

            var projectConnectionId = remoteServer.GetProperty("projectConnectionId").GetString();
            var protocol = remoteServer.GetProperty("protocol").GetString();

            var foundryTool = foundryTools.FirstOrDefault(td =>
                string.Equals(td.Type, protocol, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(td.ProjectConnectionId, projectConnectionId, StringComparison.OrdinalIgnoreCase));

            if (!toolEntry.TryGetProperty("manifest", out var manifestArray))
            {
                continue;
            }

            foreach (var manifest in manifestArray.EnumerateArray())
            {
                var enrichedTool = new Dictionary<string, object?>
                {
                    ["name"] = manifest.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null,
                    ["description"] = manifest.TryGetProperty("description", out var descEl) ? descEl.GetString() : null,
                    ["foundry_tool"] = foundryTool,
                    ["projectConnectionId"] = projectConnectionId,
                    ["protocol"] = protocol
                };

                if (manifest.TryGetProperty("parameters", out var parametersEl))
                {
                    enrichedTool["inputSchema"] = JsonSerializer.Deserialize<Dictionary<string, object?>>(
                        parametersEl.GetRawText(),
                        JsonExtensions.DefaultJsonSerializerOptions);
                }

                enrichedTools.Add(enrichedTool);
            }
        }

        return enrichedTools;
    }
}
