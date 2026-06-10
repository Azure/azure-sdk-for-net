// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Cli;
using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests.Cli;

[TestFixture]
public class GenerateAndFixOrchestratorTests
{
    private FakeOrchestratorSteps _steps = null!;
    private GenerateAndFixOptions _options = null!;
    private List<string> _progress = null!;

    [SetUp]
    public void SetUp()
    {
        _steps = new FakeOrchestratorSteps();
        _options = new GenerateAndFixOptions
        {
            ProjectPath = Path.Combine(Path.GetTempPath(), "FakeProject"),
            MaxIterations = 5,
        };
        _progress = new List<string>();
    }

    private GenerateAndFixOrchestrator CreateOrchestrator()
        => new(_steps, msg => _progress.Add(msg));

    [Test]
    public async Task UsageError_WhenProjectPathMissing()
    {
        var result = await CreateOrchestrator().RunAsync(new GenerateAndFixOptions { ProjectPath = "" });

        Assert.That(result.Success, Is.False);
        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.UsageError));
    }

    [Test]
    public async Task UsageError_WhenMaxIterationsNonPositive()
    {
        _options = new GenerateAndFixOptions { ProjectPath = "x", MaxIterations = 0 };
        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.UsageError));
    }

    [Test]
    public async Task GenerationFailure_ExitsWithGenerationFailedReason()
    {
        _steps.OnRunCodeGeneration = (_, _, _) => (false, "gen output", "boom");

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Success, Is.False);
        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.GenerationFailed));
        Assert.That(result.Message, Does.Contain("boom"));
        // We must not snapshot, build, fix, or verify after a failed generation.
        Assert.That(_steps.SnapshotCalls, Is.EqualTo(0));
        Assert.That(_steps.BuildCalls, Is.EqualTo(0));
    }

    [Test]
    public async Task CleanBuildOnFirstIteration_ReturnsSuccessImmediately()
    {
        _steps.BuildResponses.Enqueue((TestFixtures.Clean(), new List<ClassifiedError>()));

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Success, Is.True);
        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.Success));
        Assert.That(result.Iterations, Is.EqualTo(1));
        Assert.That(result.TotalFixesApplied, Is.EqualTo(0));
        Assert.That(_steps.FixCalls, Is.EqualTo(0));
        Assert.That(_steps.VerifyCalls, Is.EqualTo(1));
    }

    [Test]
    public async Task DeterministicErrorsAreFixed_ThenBuildClean_ReturnsSuccess()
    {
        // First build: one deterministic error. Second build: clean.
        var customFile = Path.Combine(Path.GetTempPath(), "FakeProject", "src", "Custom", "Foo.cs");
        _steps.BuildResponses.Enqueue((
            TestFixtures.Failed(1),
            new List<ClassifiedError> { TestFixtures.Deterministic("add_using_directive", customFile) }));
        _steps.BuildResponses.Enqueue((TestFixtures.Clean(), new List<ClassifiedError>()));

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Success, Is.True);
        Assert.That(result.Iterations, Is.EqualTo(2));
        Assert.That(result.TotalFixesApplied, Is.EqualTo(1));
        Assert.That(result.FixesByTool["add_using_directive"], Is.EqualTo(1));
        Assert.That(_steps.FixCalls, Is.EqualTo(1));
    }

    [Test]
    public async Task NonDeterministicErrors_ExitsWithBuildFailed()
    {
        _steps.BuildResponses.Enqueue((
            TestFixtures.Failed(1),
            new List<ClassifiedError> { TestFixtures.NonDeterministic("src/Foo.cs") }));

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Success, Is.False);
        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.BuildFailed));
        Assert.That(result.RemainingErrors, Has.Count.EqualTo(1));
        Assert.That(_steps.FixCalls, Is.EqualTo(0));
    }

    [Test]
    public async Task DeterministicFixTargetingGenerated_IsSkipped()
    {
        var generatedFile = Path.Combine(Path.GetTempPath(), "FakeProject", "src", "Generated", "Bad.cs");
        _steps.BuildResponses.Enqueue((
            TestFixtures.Failed(1),
            new List<ClassifiedError> { TestFixtures.Deterministic("regex_replacement", generatedFile) }));

        var result = await CreateOrchestrator().RunAsync(_options);

        // No fixable errors after filtering -> BuildFailed, no fix call.
        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.BuildFailed));
        Assert.That(_steps.FixCalls, Is.EqualTo(0));
        Assert.That(string.Join('\n', _progress), Does.Contain("Skipped 1 fix"));
    }

    [Test]
    public async Task NoProgressGuard_StopsLoopWhenAllFixesFail()
    {
        var customFile = Path.Combine(Path.GetTempPath(), "FakeProject", "src", "Custom", "Foo.cs");
        _steps.BuildResponses.Enqueue((
            TestFixtures.Failed(1),
            new List<ClassifiedError> { TestFixtures.Deterministic("regex_replacement", customFile) }));
        _steps.FixResponses.Enqueue(new List<FixResult>
        {
            new FixResult(false, "regex_replacement", "could not match")
        });

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.BuildFailed));
        Assert.That(_steps.BuildCalls, Is.EqualTo(1), "no second build attempt after zero progress");
        Assert.That(result.Message, Does.Contain("No fixes succeeded"));
    }

    [Test]
    public async Task MaxIterationsCap_StopsLoopWithBuildFailed()
    {
        _options = new GenerateAndFixOptions { ProjectPath = _options.ProjectPath, MaxIterations = 2 };
        var customFile = Path.Combine(Path.GetTempPath(), "FakeProject", "src", "Custom", "Foo.cs");

        // Three failing builds (every iteration succeeds at fixing but the next build still fails).
        for (var i = 0; i < 3; i++)
        {
            _steps.BuildResponses.Enqueue((
                TestFixtures.Failed(1),
                new List<ClassifiedError> { TestFixtures.Deterministic("add_using_directive", customFile) }));
        }

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.BuildFailed));
        Assert.That(result.Iterations, Is.EqualTo(2));
        Assert.That(result.Message, Does.Contain("max-iterations"));
    }

    [Test]
    public async Task GeneratedViolation_ReturnsExit3()
    {
        _steps.BuildResponses.Enqueue((TestFixtures.Clean(), new List<ClassifiedError>()));
        _steps.OnVerify = _ => new List<string> { "src/Generated/Leaked.cs" };

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Reason, Is.EqualTo(GenerateAndFixExitReason.GeneratedViolation));
        Assert.That(result.GeneratedViolations, Contains.Item("src/Generated/Leaked.cs"));
    }

    [Test]
    public async Task SkipGeneration_BypassesGenerationStep()
    {
        _options = new GenerateAndFixOptions
        {
            ProjectPath = _options.ProjectPath,
            MaxIterations = 5,
            SkipGeneration = true,
        };
        _steps.BuildResponses.Enqueue((TestFixtures.Clean(), new List<ClassifiedError>()));

        var result = await CreateOrchestrator().RunAsync(_options);

        Assert.That(result.Success, Is.True);
        Assert.That(_steps.CodeGenerationCalls, Is.EqualTo(0));
        Assert.That(_steps.SnapshotCalls, Is.EqualTo(1));
    }
}
