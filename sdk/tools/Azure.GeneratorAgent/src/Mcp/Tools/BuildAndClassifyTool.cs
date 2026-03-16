// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that runs dotnet build, parses the output, and classifies each error
/// as deterministic or requiring LLM reasoning.
/// </summary>
[McpServerToolType]
public static class BuildAndClassifyTool
{
    [McpServerTool(Name = "build_and_classify"), Description("Run dotnet build on a project, parse errors, and classify each as deterministic or requires-reasoning.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the project directory or .csproj file")] string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var (buildOutput, exitCode) = await RunBuildAsync(normalizedPath).ConfigureAwait(false);
            var errors = BuildOutputParser.Parse(buildOutput);
            var classified = errors.Select(DeterministicFixRegistry.Classify).ToList();

            return JsonSerializer.Serialize(new
            {
                success = exitCode == 0,
                exitCode,
                totalErrors = errors.Count,
                deterministicCount = classified.Count(c => c.IsDeterministic),
                requiresReasoningCount = classified.Count(c => !c.IsDeterministic),
                classifiedErrors = classified,
                rawOutput = Truncate(buildOutput, 5000)
            });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process build + classify for the orchestrator.
    /// </summary>
    public static async Task<(BuildResult BuildResult, List<ClassifiedError> Classified)> ExecuteInProcessAsync(string projectPath)
    {
        var normalizedPath = Path.GetFullPath(projectPath);
        var (buildOutput, exitCode) = await RunBuildAsync(normalizedPath).ConfigureAwait(false);
        var errors = BuildOutputParser.Parse(buildOutput);
        var classified = errors.Select(DeterministicFixRegistry.Classify).ToList();

        var buildResult = new BuildResult
        {
            Success = exitCode == 0,
            Errors = errors,
            RawOutput = buildOutput
        };

        return (buildResult, classified);
    }

    private static async Task<(string Output, int ExitCode)> RunBuildAsync(string projectPath)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "build /clp:ErrorsOnly",
            WorkingDirectory = Directory.Exists(projectPath) ? projectPath : Path.GetDirectoryName(projectPath)!,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi)!;
        var stdout = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
        var stderr = await process.StandardError.ReadToEndAsync().ConfigureAwait(false);
        await process.WaitForExitAsync().ConfigureAwait(false);

        var combinedOutput = stdout;
        if (!string.IsNullOrWhiteSpace(stderr))
        {
            combinedOutput += Environment.NewLine + stderr;
        }

        return (combinedOutput, process.ExitCode);
    }

    private static string Truncate(string value, int maxLength)
    {
        return value.Length <= maxLength ? value : value[..maxLength] + "... (truncated)";
    }
}
