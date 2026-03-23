// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that runs code generation (dotnet build /t:generateCode).
/// </summary>
[McpServerToolType]
public static class CodeGenerationTool
{
    [McpServerTool(Name = "run_code_generation"), Description("Run dotnet build /t:generateCode in a project's src directory.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory")] string projectPath)
    {
        try
        {
            var (success, output, error) = await ExecuteInProcessAsync(projectPath).ConfigureAwait(false);
            if (!success)
            {
                return JsonSerializer.Serialize(new { success = false, error, output });
            }
            return JsonSerializer.Serialize(new { success = true, output = CSharpPatterns.Truncate(output, 3000) });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static async Task<(bool Success, string Output, string? Error)> ExecuteInProcessAsync(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            var workDir = Directory.Exists(srcPath) ? srcPath : normalizedPath;

            var (output, exitCode) = await ProcessRunner.RunAsync("dotnet", "build /t:generateCode", workDir).ConfigureAwait(false);

            return (exitCode == 0, output, exitCode != 0 ? $"Code generation failed with exit code {exitCode}" : null);
        }
        catch (Exception ex)
        {
            return (false, string.Empty, ex.Message);
        }
    }


}
