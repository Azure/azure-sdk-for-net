// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that parses raw MSBuild output into structured error objects.
/// </summary>
[McpServerToolType]
public static class ParseBuildOutputTool
{
    [McpServerTool(Name = "parse_build_output"), Description("Parse raw MSBuild output into structured error objects with file, line, code, and message.")]
    public static string Execute(
        [Description("Raw MSBuild console output")] string buildOutput)
    {
        try
        {
            var errors = BuildOutputParser.Parse(buildOutput);
            var isSuccess = BuildOutputParser.IsSuccess(buildOutput);

            return JsonSerializer.Serialize(new
            {
                success = true,
                buildSucceeded = isSuccess,
                errorCount = errors.Count(e => e.Severity == "error"),
                warningCount = errors.Count(e => e.Severity == "warning"),
                errors
            });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }
}
