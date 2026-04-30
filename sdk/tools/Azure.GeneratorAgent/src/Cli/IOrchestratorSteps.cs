// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;

namespace Azure.GeneratorAgent.Cli;

/// <summary>
/// Abstraction over the workflow steps the orchestrator depends on. Production code uses
/// <see cref="DefaultOrchestratorSteps"/>, which delegates to the in-process MCP tools.
/// Tests provide mocks to drive the orchestrator through specific scenarios without
/// invoking dotnet build, git, or the file system.
/// </summary>
public interface IOrchestratorSteps
{
    /// <summary>
    /// Runs <c>dotnet build /t:generateCode</c>.
    /// </summary>
    Task<(bool Success, string Output, string? Error)> RunCodeGenerationAsync(
        string projectPath, string? localSpecsPath, CancellationToken cancellationToken);

    /// <summary>
    /// Snapshots the contents of the project's <c>Generated/</c> directory.
    /// </summary>
    int TakeGeneratedSnapshot(string projectPath);

    /// <summary>
    /// Runs <c>dotnet build</c> and classifies the resulting errors.
    /// </summary>
    Task<(BuildResult BuildResult, List<ClassifiedError> Classified)> BuildAndClassifyAsync(
        string projectPath, CancellationToken cancellationToken);

    /// <summary>
    /// Applies a batch of deterministic fixes.
    /// </summary>
    List<FixResult> ApplyFixes(List<FixOperation> fixes);

    /// <summary>
    /// Verifies that no files in <c>Generated/</c> were modified since the snapshot.
    /// Returns the list of relative paths that violate the contract (after auto-revert).
    /// </summary>
    List<string> VerifyGeneratedUnchanged(string projectPath);
}

/// <summary>
/// Production implementation: delegates each step to the real MCP tool's in-process method.
/// </summary>
public sealed class DefaultOrchestratorSteps : IOrchestratorSteps
{
    public Task<(bool Success, string Output, string? Error)> RunCodeGenerationAsync(
        string projectPath, string? localSpecsPath, CancellationToken cancellationToken)
        => CodeGenerationTool.ExecuteInProcessAsync(projectPath, localSpecsPath, cancellationToken);

    public int TakeGeneratedSnapshot(string projectPath)
    {
        var result = GeneratedSnapshotTool.TakeSnapshotInProcess(projectPath);
        return result.FileCount;
    }

    public Task<(BuildResult BuildResult, List<ClassifiedError> Classified)> BuildAndClassifyAsync(
        string projectPath, CancellationToken cancellationToken)
        => BuildAndClassifyTool.ExecuteInProcessAsync(projectPath);

    public List<FixResult> ApplyFixes(List<FixOperation> fixes)
        => BatchFixTool.ExecuteInProcess(fixes);

    public List<string> VerifyGeneratedUnchanged(string projectPath)
    {
        var result = GeneratedSnapshotTool.VerifyInProcess(projectPath, autoRevert: true);

        // After auto-revert, anything still present (e.g., revert failed, or "Added" file
        // that couldn't be deleted) is a real violation.
        if (!result.HasViolations)
        {
            return new List<string>();
        }

        // Re-verify to filter out anything the auto-revert successfully cleaned up.
        var post = GeneratedSnapshotTool.VerifyInProcess(projectPath, autoRevert: false);
        return post.Violations.Select(v => v.RelativePath).ToList();
    }
}
