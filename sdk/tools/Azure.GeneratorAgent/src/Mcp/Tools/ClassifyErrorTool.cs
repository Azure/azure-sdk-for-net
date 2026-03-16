// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that classifies a single build error against the deterministic fix registry.
/// </summary>
[McpServerToolType]
public static class ClassifyErrorTool
{
    [McpServerTool(Name = "classify_error"), Description("Classify a single build error as deterministic (with tool + args) or requires-reasoning.")]
    public static string Execute(
        [Description("JSON object representing a BuildError with filePath, line, column, code, message, severity")] string errorJson)
    {
        try
        {
            var error = JsonSerializer.Deserialize<BuildError>(errorJson);
            if (error is null)
            {
                return JsonSerializer.Serialize(new { success = false, error = "Failed to deserialize error object" });
            }

            var classified = DeterministicFixRegistry.Classify(error);
            return JsonSerializer.Serialize(new { success = true, result = classified });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }
}
