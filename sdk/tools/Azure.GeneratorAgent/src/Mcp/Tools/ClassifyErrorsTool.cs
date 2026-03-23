// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that classifies a batch of build errors against the deterministic fix registry.
/// </summary>
[McpServerToolType]
public static class ClassifyErrorsTool
{
    [McpServerTool(Name = "classify_errors"), Description("Classify a batch of build errors. Returns each error classified as deterministic or requires-reasoning.")]
    public static string Execute(
        [Description("JSON array of BuildError objects")] string errorsJson)
    {
        try
        {
            var errors = JsonSerializer.Deserialize<List<BuildError>>(errorsJson);
            if (errors is null)
            {
                return JsonSerializer.Serialize(new { success = false, error = "Failed to deserialize error array" });
            }

            var classified = errors.Select(DeterministicFixRegistry.Classify).ToList();
            var deterministicCount = 0;
            foreach (var c in classified)
            {
                if (c.IsDeterministic)
                {
                    deterministicCount++;
                }
            }

            return JsonSerializer.Serialize(new
            {
                success = true,
                total = classified.Count,
                deterministicCount,
                requiresReasoningCount = classified.Count - deterministicCount,
                results = classified
            });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }
}
