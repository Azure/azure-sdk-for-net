// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Cli;
using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;

namespace Azure.GeneratorAgent.Tests.Cli;

/// <summary>
/// In-memory test double for <see cref="IOrchestratorSteps"/>. Each method records its
/// invocations and returns a queued response so tests can drive the orchestrator
/// through specific scenarios without invoking dotnet, git, or the file system.
/// </summary>
internal sealed class FakeOrchestratorSteps : IOrchestratorSteps
{
    public Func<string, string?, CancellationToken, (bool, string, string?)>? OnRunCodeGeneration { get; set; }
    public Func<string, int>? OnTakeSnapshot { get; set; }
    public Queue<(BuildResult BuildResult, List<ClassifiedError> Classified)> BuildResponses { get; } = new();
    public Queue<List<FixResult>> FixResponses { get; } = new();
    public Func<string, List<string>>? OnVerify { get; set; }

    public int CodeGenerationCalls { get; private set; }
    public int SnapshotCalls { get; private set; }
    public int BuildCalls { get; private set; }
    public int FixCalls { get; private set; }
    public int VerifyCalls { get; private set; }
    public List<List<FixOperation>> FixCallArgs { get; } = new();

    public Task<(bool Success, string Output, string? Error)> RunCodeGenerationAsync(
        string projectPath, string? localSpecsPath, CancellationToken cancellationToken)
    {
        CodeGenerationCalls++;
        var (s, o, e) = OnRunCodeGeneration?.Invoke(projectPath, localSpecsPath, cancellationToken)
            ?? (true, string.Empty, null);
        return Task.FromResult((s, o, e));
    }

    public int TakeGeneratedSnapshot(string projectPath)
    {
        SnapshotCalls++;
        return OnTakeSnapshot?.Invoke(projectPath) ?? 0;
    }

    public Task<(BuildResult BuildResult, List<ClassifiedError> Classified)> BuildAndClassifyAsync(
        string projectPath, CancellationToken cancellationToken)
    {
        BuildCalls++;
        if (BuildResponses.Count == 0)
        {
            throw new InvalidOperationException("No queued build response.");
        }
        return Task.FromResult(BuildResponses.Dequeue());
    }

    public List<FixResult> ApplyFixes(List<FixOperation> fixes)
    {
        FixCalls++;
        FixCallArgs.Add(fixes);
        if (FixResponses.Count == 0)
        {
            // Default: every fix succeeds.
            return fixes.Select(f => new FixResult(true, f.ToolName, "ok")).ToList();
        }
        return FixResponses.Dequeue();
    }

    public List<string> VerifyGeneratedUnchanged(string projectPath)
    {
        VerifyCalls++;
        return OnVerify?.Invoke(projectPath) ?? new List<string>();
    }
}

/// <summary>
/// Helpers for building <see cref="BuildResult"/> / <see cref="ClassifiedError"/>
/// fixtures used by the orchestrator tests.
/// </summary>
internal static class TestFixtures
{
    public static BuildResult Clean() => new() { Success = true, ExitCode = 0 };

    public static BuildResult Failed(int errorCount = 1) => new()
    {
        Success = false,
        ExitCode = 1,
        Errors = Enumerable.Range(0, errorCount).Select(i => new BuildError
        {
            Code = "CS0246",
            FilePath = $"src/Foo{i}.cs",
            Message = $"placeholder error {i}"
        }).ToList()
    };

    public static ClassifiedError Deterministic(string tool, string filePath, string code = "CS0246") => new()
    {
        Error = new BuildError { Code = code, FilePath = filePath, Message = "x" },
        IsDeterministic = true,
        ToolName = tool,
        ToolArgs = new Dictionary<string, string> { ["filePath"] = filePath },
        Reason = "test"
    };

    public static ClassifiedError NonDeterministic(string filePath, string code = "CS0103") => new()
    {
        Error = new BuildError { Code = code, FilePath = filePath, Message = "x" },
        IsDeterministic = false,
        Reason = "requires reasoning"
    };
}
