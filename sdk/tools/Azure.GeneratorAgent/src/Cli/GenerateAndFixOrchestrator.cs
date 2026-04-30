// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;

namespace Azure.GeneratorAgent.Cli;

/// <summary>
/// End-to-end orchestrator for the <c>generate-and-fix</c> CI workflow.
///
/// Mirrors the dpg/mpg migration skill but without an LLM:
///   1. Run code generation.
///   2. Snapshot Generated/.
///   3. Loop: build → classify → batch_fix (deterministic only, customization code only).
///   4. Verify Generated/ is unchanged.
///
/// All "fixes only in custom code" enforcement happens here and in the underlying
/// fix tools (which already call <c>GeneratedPathGuard.ValidateNotGenerated</c>).
/// </summary>
public sealed class GenerateAndFixOrchestrator
{
    private readonly IOrchestratorSteps _steps;
    private readonly Action<string> _logProgress;

    /// <summary>
    /// Creates a new orchestrator.
    /// </summary>
    /// <param name="steps">Workflow step implementation. Defaults to <see cref="DefaultOrchestratorSteps"/>.</param>
    /// <param name="logProgress">
    /// Callback that receives human-readable progress lines. Tests can capture them; the
    /// CLI front-end writes them to stderr.
    /// </param>
    public GenerateAndFixOrchestrator(IOrchestratorSteps? steps = null, Action<string>? logProgress = null)
    {
        _steps = steps ?? new DefaultOrchestratorSteps();
        _logProgress = logProgress ?? (_ => { });
    }

    /// <summary>
    /// Runs the workflow described in the class summary.
    /// </summary>
    public async Task<GenerateAndFixResult> RunAsync(GenerateAndFixOptions options, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(options.ProjectPath))
        {
            return Fail(GenerateAndFixExitReason.UsageError, "ProjectPath is required.");
        }

        if (options.MaxIterations <= 0)
        {
            return Fail(GenerateAndFixExitReason.UsageError, "MaxIterations must be a positive integer.");
        }

        var result = new GenerateAndFixResult();

        // ── 1. Generate ────────────────────────────────────────────────
        if (!options.SkipGeneration)
        {
            _logProgress($"[1/4] Running code generation for {options.ProjectPath}");
            var (genSuccess, genOutput, genError) = await _steps
                .RunCodeGenerationAsync(options.ProjectPath, options.LocalSpecsPath, cancellationToken)
                .ConfigureAwait(false);

            if (!genSuccess)
            {
                result.Success = false;
                result.Reason = GenerateAndFixExitReason.GenerationFailed;
                result.ExitReason = result.Reason.ToString();
                result.Message = genError ?? "Code generation failed.";
                _logProgress($"  ✗ Code generation failed: {result.Message}");
                _logProgress(genOutput);
                return result;
            }
            _logProgress("  ✓ Code generation succeeded");
        }
        else
        {
            _logProgress("[1/4] Skipping code generation (--skip-generation)");
        }

        // ── 2. Snapshot ────────────────────────────────────────────────
        _logProgress("[2/4] Snapshotting Generated/ for tamper detection");
        var snapshotCount = _steps.TakeGeneratedSnapshot(options.ProjectPath);
        _logProgress($"  ✓ Snapshotted {snapshotCount} file(s)");

        // ── 3. Build–fix loop ──────────────────────────────────────────
        _logProgress($"[3/4] Build–fix loop (max {options.MaxIterations} iteration(s))");
        for (var iteration = 1; iteration <= options.MaxIterations; iteration++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            result.Iterations = iteration;
            _logProgress($"  Iteration {iteration}: building…");

            var (buildResult, classified) = await _steps
                .BuildAndClassifyAsync(options.ProjectPath, cancellationToken)
                .ConfigureAwait(false);

            if (buildResult.Success)
            {
                _logProgress("  ✓ Build is clean — exiting fix loop");
                break;
            }

            _logProgress($"    {buildResult.Errors.Count} error(s) reported");

            // Filter to deterministic fixes that target customization code only.
            var fixOps = new List<FixOperation>();
            var skippedGenerated = 0;
            foreach (var ce in classified)
            {
                if (!ce.IsDeterministic || ce.ToolName is null || ce.ToolArgs is null)
                {
                    continue;
                }

                if (TargetsGenerated(ce.ToolArgs))
                {
                    skippedGenerated++;
                    continue;
                }

                fixOps.Add(new FixOperation
                {
                    ToolName = ce.ToolName,
                    ToolArgs = new Dictionary<string, string>(ce.ToolArgs)
                });
            }

            if (skippedGenerated > 0)
            {
                _logProgress($"    Skipped {skippedGenerated} fix(es) targeting Generated/ (must be fixed in custom code)");
            }

            if (fixOps.Count == 0)
            {
                result.RemainingErrors = classified;
                return Fail(
                    result,
                    GenerateAndFixExitReason.BuildFailed,
                    $"No deterministic fixes available for {classified.Count} error(s) after iteration {iteration}. " +
                    "These errors require human intervention.");
            }

            _logProgress($"    Applying {fixOps.Count} deterministic fix(es)");
            var fixResults = _steps.ApplyFixes(fixOps);

            var appliedThisIteration = 0;
            foreach (var fr in fixResults)
            {
                if (fr.Success)
                {
                    appliedThisIteration++;
                    result.TotalFixesApplied++;
                    result.FixesByTool[fr.Tool] = result.FixesByTool.GetValueOrDefault(fr.Tool) + 1;
                }
                else
                {
                    _logProgress($"      ✗ {fr.Tool}: {fr.Message}");
                }
            }

            _logProgress($"    {appliedThisIteration}/{fixOps.Count} fix(es) succeeded this iteration");

            if (appliedThisIteration == 0)
            {
                // No-progress guard: if every fix failed, the next iteration would
                // produce the same errors. Bail out instead of looping uselessly.
                result.RemainingErrors = classified;
                return Fail(
                    result,
                    GenerateAndFixExitReason.BuildFailed,
                    $"No fixes succeeded in iteration {iteration}; aborting to avoid an infinite loop.");
            }
        }

        // If the loop fell through without a clean build, we hit the iteration cap.
        if (result.Iterations == options.MaxIterations)
        {
            var (finalBuild, finalClassified) = await _steps
                .BuildAndClassifyAsync(options.ProjectPath, cancellationToken)
                .ConfigureAwait(false);

            if (!finalBuild.Success)
            {
                result.RemainingErrors = finalClassified;
                return Fail(
                    result,
                    GenerateAndFixExitReason.BuildFailed,
                    $"Reached --max-iterations={options.MaxIterations} without a clean build.");
            }
        }

        // ── 4. Verify Generated/ ───────────────────────────────────────
        _logProgress("[4/4] Verifying Generated/ is unchanged");
        var violations = _steps.VerifyGeneratedUnchanged(options.ProjectPath);
        if (violations.Count > 0)
        {
            result.GeneratedViolations = violations;
            return Fail(
                result,
                GenerateAndFixExitReason.GeneratedViolation,
                $"{violations.Count} file(s) in Generated/ were modified during the fix loop and could not be reverted.");
        }
        _logProgress("  ✓ Generated/ is unchanged");

        result.Success = true;
        result.Reason = GenerateAndFixExitReason.Success;
        result.ExitReason = result.Reason.ToString();
        result.Message = $"Build clean after {result.Iterations} iteration(s); applied {result.TotalFixesApplied} fix(es).";
        _logProgress("✓ " + result.Message);
        return result;
    }

    /// <summary>
    /// Returns true if any of the well-known "filePath" arguments would point inside Generated/.
    /// </summary>
    private static bool TargetsGenerated(IReadOnlyDictionary<string, string> toolArgs)
    {
        foreach (var key in s_pathArgKeys)
        {
            if (toolArgs.TryGetValue(key, out var path)
                && !string.IsNullOrWhiteSpace(path)
                && GeneratedPathGuard.IsInGeneratedDirectory(path))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Tool-args keys that may carry a file path the fixer will write to.
    /// (Kept in sync with <see cref="BatchFixTool"/>'s switch.)
    /// </summary>
    private static readonly string[] s_pathArgKeys = { "filePath" };

    private GenerateAndFixResult Fail(GenerateAndFixExitReason reason, string message)
        => Fail(new GenerateAndFixResult(), reason, message);

    private GenerateAndFixResult Fail(GenerateAndFixResult result, GenerateAndFixExitReason reason, string message)
    {
        result.Success = false;
        result.Reason = reason;
        result.ExitReason = reason.ToString();
        result.Message = message;
        _logProgress("✗ " + message);
        return result;
    }
}
