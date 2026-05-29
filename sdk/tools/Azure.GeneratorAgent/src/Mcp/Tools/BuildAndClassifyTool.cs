// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
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
    [McpServerTool(Name = "build_and_classify"), Description("Run dotnet build on a project, parse errors, and classify each as deterministic or requires-reasoning. Returns up to 20 errors per call — fix those first, then re-run to see remaining errors.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the project directory or .csproj file")] string projectPath)
    {
        try
        {
            var (buildResult, classified) = await ExecuteInProcessAsync(projectPath).ConfigureAwait(false);
            var deterministicCount = classified.Count(c => c.IsDeterministic);

            // Cap returned errors to avoid overwhelming the LLM — total count is still reported
            var returnedErrors = classified.Take(20).ToList();

            // Auto-verify Generated/ integrity when a snapshot exists
            object? generatedGuardResult = null;
            var normalizedPath = Path.GetFullPath(projectPath);
            if (GeneratedSnapshotTool.HasSnapshot(normalizedPath))
            {
                var verification = GeneratedSnapshotTool.VerifyInProcess(normalizedPath, autoRevert: true);
                if (verification.HasViolations)
                {
                    generatedGuardResult = new
                    {
                        violated = true,
                        verification.Message,
                        violations = verification.Violations.Select(v => new { v.RelativePath, type = v.Type.ToString() })
                    };
                }
            }

            return JsonSerializer.Serialize(new
            {
                success = buildResult.Success,
                exitCode = buildResult.ExitCode,
                totalErrors = buildResult.Errors.Count,
                returnedErrors = returnedErrors.Count,
                deterministicCount,
                requiresReasoningCount = classified.Count - deterministicCount,
                classifiedErrors = returnedErrors,
                rawOutput = CSharpPatterns.Truncate(buildResult.RawOutput, 5000),
                buildFailureHint = !buildResult.Success && buildResult.Errors.Count == 0
                    ? GetBuildFailureHint(buildResult.RawOutput)
                    : (string?)null,
                generatedGuard = generatedGuardResult
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
        var index = GeneratedCodeIndex.Build(normalizedPath);
        var classified = errors.Select(e => DeterministicFixRegistry.Classify(e, index)).ToList();

        var buildResult = new BuildResult
        {
            Success = exitCode == 0,
            ExitCode = exitCode,
            Errors = errors,
            RawOutput = buildOutput
        };

        return (buildResult, classified);
    }

    private static async Task<(string Output, int ExitCode)> RunBuildAsync(string projectPath)
    {
        var workDir = Directory.Exists(projectPath) ? projectPath : (Path.GetDirectoryName(projectPath) ?? projectPath);

        // If the path is the package root (contains a src/ subdirectory), build from src/
        var srcDir = Path.Combine(workDir, "src");
        if (Directory.Exists(srcDir))
        {
            workDir = srcDir;
        }

        return await ProcessRunner.RunAsync("dotnet", "build /clp:ErrorsOnly", workDir).ConfigureAwait(false);
    }

    private static string GetBuildFailureHint(string buildOutput)
    {
        var lines = buildOutput.Split('\n');
        var relevantLines = lines
            .Select(l => l.Trim())
            .Where(l => l.Length > 0 && (
                l.Contains("error", StringComparison.OrdinalIgnoreCase) ||
                l.Contains("failed", StringComparison.OrdinalIgnoreCase)))
            .Take(20)
            .ToArray();

        var hint = "Build failed but no structured errors were parsed.";
        if (relevantLines.Length > 0)
        {
            hint += " Potentially relevant lines:\n" + string.Join('\n', relevantLines);
        }
        else
        {
            hint += " Check rawOutput for details.";
        }

        return hint;
    }
}
