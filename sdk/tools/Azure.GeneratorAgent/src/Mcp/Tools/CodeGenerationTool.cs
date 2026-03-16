// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
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
            return JsonSerializer.Serialize(new { success = true, output = Truncate(output, 3000) });
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

            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "build /t:generateCode",
                WorkingDirectory = workDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi)!;
            var stdout = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
            var stderr = await process.StandardError.ReadToEndAsync().ConfigureAwait(false);
            await process.WaitForExitAsync().ConfigureAwait(false);

            var output = stdout;
            if (!string.IsNullOrWhiteSpace(stderr))
            {
                output += Environment.NewLine + stderr;
            }

            return (process.ExitCode == 0, output, process.ExitCode != 0 ? $"Code generation failed with exit code {process.ExitCode}" : null);
        }
        catch (Exception ex)
        {
            return (false, string.Empty, ex.Message);
        }
    }

    private static string Truncate(string value, int maxLength)
    {
        return value.Length <= maxLength ? value : value[..maxLength] + "... (truncated)";
    }
}
