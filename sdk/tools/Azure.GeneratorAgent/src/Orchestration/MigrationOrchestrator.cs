// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent.Orchestration;

/// <summary>
/// Orchestrates the full migration pipeline by applying deterministic tools first,
/// then delegating only non-deterministic work to the LLM via CopilotService.
/// </summary>
public sealed class MigrationOrchestrator
{
    private readonly ILogger<MigrationOrchestrator> _logger;
    private const int MaxBuildFixIterations = 10;

    public MigrationOrchestrator(ILogger<MigrationOrchestrator> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Runs the full migration pipeline: pregen cleanup → codegen → build-fix (src) → sample migration → test project build-fix → finalization.
    /// </summary>
    public async Task RunFullPipelineAsync(
        string projectPath,
        CopilotService copilotService,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting full migration pipeline for: {ProjectPath}", projectPath);

        // Phase 0: Pre-generation cleanup
        _logger.LogInformation("=== Phase 0: Pre-generation cleanup ===");
        var (cleanupSuccess, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(projectPath);
        if (cleanupSuccess && filesModified > 0)
        {
            _logger.LogInformation("Removed IncludeAutorestDependency from {Count} csproj file(s)", filesModified);
        }

        // Phase 1: Code generation
        _logger.LogInformation("=== Phase 1: Code generation ===");
        var (codegenSuccess, codegenOutput, codegenError) = await CodeGenerationTool.ExecuteInProcessAsync(projectPath).ConfigureAwait(false);
        if (!codegenSuccess)
        {
            _logger.LogWarning("Code generation failed: {Error}. Continuing to build-fix cycle.", codegenError);
        }

        // Phase 2: Build and fix (src)
        _logger.LogInformation("=== Phase 2: Build and fix (src) ===");
        await RunBuildFixCycleAsync(Path.Combine(projectPath, "src"), copilotService, MaxBuildFixIterations, cancellationToken).ConfigureAwait(false);

        // Phase 3: Test project build
        _logger.LogInformation("=== Phase 3: Test project build ===");
        var (sampleSuccess, samplesMoved, _) = SampleMigrationTool.ExecuteInProcess(projectPath);
        if (sampleSuccess && samplesMoved > 0)
        {
            _logger.LogInformation("Migrated {Count} test sample file(s) from Generated/Samples/ to Samples/", samplesMoved);
        }

        var testsPath = Path.Combine(projectPath, "tests");
        if (Directory.Exists(testsPath))
        {
            await RunBuildFixCycleAsync(testsPath, copilotService, MaxBuildFixIterations, cancellationToken).ConfigureAwait(false);
        }

        // Phase 4: Finalization
        _logger.LogInformation("=== Phase 4: Finalization ===");
        var (finSuccess, finOutput, finError) = await FinalizationTool.ExecuteInProcessAsync(projectPath).ConfigureAwait(false);
        if (finSuccess)
        {
            _logger.LogInformation("Finalization completed: {Output}", finOutput);
        }
        else
        {
            _logger.LogWarning("Finalization failed: {Error}", finError);
        }

        _logger.LogInformation("Migration pipeline completed for: {ProjectPath}", projectPath);
    }

    /// <summary>
    /// Runs the build-fix cycle: build → classify → apply deterministic fixes → LLM for rest → repeat.
    /// </summary>
    public async Task RunBuildFixCycleAsync(
        string buildPath,
        CopilotService copilotService,
        int maxIterations,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting build-fix cycle for: {BuildPath}", buildPath);

        for (var iteration = 1; iteration <= maxIterations; iteration++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _logger.LogInformation("=== Build-Fix Iteration {Iteration}/{MaxIterations} ===", iteration, maxIterations);

            // Step 1: Build and classify
            var (buildResult, classified) = await BuildAndClassifyTool.ExecuteInProcessAsync(buildPath).ConfigureAwait(false);

            if (buildResult.Success)
            {
                _logger.LogInformation("Build succeeded on iteration {Iteration}", iteration);
                return;
            }

            _logger.LogInformation("Build failed with {ErrorCount} errors", buildResult.Errors.Count);

            var deterministicFixes = classified.Where(c => c.IsDeterministic && c.ToolArgs is { Count: > 0 }).ToList();
            var requiresReasoning = classified.Where(c => !c.IsDeterministic || c.ToolArgs is null or { Count: 0 }).ToList();

            _logger.LogInformation("Classified: {Deterministic} deterministic, {Reasoning} requires reasoning",
                deterministicFixes.Count, requiresReasoning.Count);

            // Step 2: Apply all deterministic fixes
            if (deterministicFixes.Count > 0)
            {
                var fixOps = deterministicFixes
                    .Select(c => new FixOperation { Tool = c.ToolName!, Args = c.ToolArgs! })
                    .ToList();

                var results = BatchFixTool.ExecuteInProcess(fixOps);
                var successCount = results.Count(r => r.Success);
                _logger.LogInformation("Applied {Success}/{Total} deterministic fixes", successCount, results.Count);

                // If we applied some deterministic fixes, rebuild before going to LLM
                if (successCount > 0 && requiresReasoning.Count > 0)
                {
                    _logger.LogInformation("Rebuilding after deterministic fixes before sending to LLM...");
                    var (rebuildResult, reclassified) = await BuildAndClassifyTool.ExecuteInProcessAsync(buildPath).ConfigureAwait(false);

                    if (rebuildResult.Success)
                    {
                        _logger.LogInformation("Build succeeded after deterministic fixes on iteration {Iteration}", iteration);
                        return;
                    }

                    requiresReasoning = reclassified.Where(c => !c.IsDeterministic).ToList();
                    _logger.LogInformation("After rebuild: {Remaining} errors still require reasoning", requiresReasoning.Count);
                }
                else if (successCount > 0)
                {
                    continue;
                }
            }

            // Step 3: Send remaining errors to LLM
            if (requiresReasoning.Count > 0)
            {
                var errorSummary = FormatErrorsForLlm(requiresReasoning);
                _logger.LogInformation("Sending {Count} non-deterministic errors to LLM", requiresReasoning.Count);

                await copilotService.HandleBuildFixCycleAsync(
                    buildPath,
                    preClassifiedErrors: errorSummary,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else if (deterministicFixes.Count == 0)
            {
                _logger.LogWarning("No fixes could be applied on iteration {Iteration}, stopping", iteration);
                break;
            }
        }

        _logger.LogWarning("Build-fix cycle completed after max iterations");
    }

    private static string FormatErrorsForLlm(List<ClassifiedError> errors)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"The following {errors.Count} build errors could not be fixed deterministically and require your analysis:");
        sb.AppendLine();

        foreach (var classified in errors)
        {
            var err = classified.Error;
            var location = string.IsNullOrEmpty(err.FilePath)
                ? "(project-level)"
                : $"{err.FilePath}({err.Line},{err.Column})";

            sb.AppendLine($"  {location}: {err.Severity} {err.Code}: {err.Message}");
        }

        return sb.ToString();
    }
}
