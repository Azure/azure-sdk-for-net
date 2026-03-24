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
    [McpServerTool(Name = "run_code_generation"), Description("Run dotnet build /t:generateCode in a project's src directory. Optionally pass a local specs repo path to use during iteration.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory")] string projectPath,
        [Description("Optional. Absolute path to local azure-rest-api-specs clone. When provided, passes /p:LocalSpecRepo to the build.")] string? localSpecsPath = null)
    {
        try
        {
            var (success, output, error) = await ExecuteInProcessAsync(projectPath, localSpecsPath).ConfigureAwait(false);
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
    public static async Task<(bool Success, string Output, string? Error)> ExecuteInProcessAsync(string projectPath, string? localSpecsPath = null)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            var workDir = Directory.Exists(srcPath) ? srcPath : normalizedPath;
            var buildArgs = BuildArguments(localSpecsPath);

            var (output, exitCode) = await ProcessRunner.RunAsync("dotnet", buildArgs, workDir).ConfigureAwait(false);

            return (exitCode == 0, output, exitCode != 0 ? $"Code generation failed with exit code {exitCode}" : null);
        }
        catch (Exception ex)
        {
            return (false, string.Empty, ex.Message);
        }
    }

    /// <summary>
    /// Builds the dotnet build arguments for code generation.
    /// </summary>
    internal static string BuildArguments(string? localSpecsPath)
    {
        var args = "build /t:generateCode";
        if (!string.IsNullOrWhiteSpace(localSpecsPath))
        {
            args += $" /p:LocalSpecRepo={Path.GetFullPath(localSpecsPath)}";
        }
        return args;
    }
}
