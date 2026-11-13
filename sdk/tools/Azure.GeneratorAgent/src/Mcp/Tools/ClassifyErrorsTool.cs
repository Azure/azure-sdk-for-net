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
    [McpServerTool(Name = "classify_errors"), Description("Classify a batch of build errors. Returns each error classified as deterministic or requires-reasoning. Provide projectPath for dynamic type resolution from Generated/ code.")]
    public static string Execute(
        [Description("JSON array of BuildError objects")] string errorsJson,
        [Description("Optional: absolute path to the project directory for dynamic type resolution from Generated/ code")] string? projectPath = null)
    {
        try
        {
            var errors = JsonSerializer.Deserialize<List<BuildError>>(errorsJson);
            if (errors is null)
            {
                return JsonSerializer.Serialize(new { success = false, error = "Failed to deserialize error array" });
            }

            var index = projectPath is not null ? GeneratedCodeIndex.Build(projectPath) : null;
            var classified = errors.Select(e => DeterministicFixRegistry.Classify(e, index)).ToList();
            var deterministicCount = classified.Count(c => c.IsDeterministic);

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
