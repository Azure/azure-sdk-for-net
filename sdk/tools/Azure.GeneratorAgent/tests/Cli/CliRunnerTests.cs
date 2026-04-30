// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.GeneratorAgent.Cli;
using Azure.GeneratorAgent.Mcp;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests.Cli;

[TestFixture]
public class CliRunnerTests
{
    private StringWriter _stdout = null!;
    private StringWriter _stderr = null!;

    [SetUp]
    public void SetUp()
    {
        _stdout = new StringWriter();
        _stderr = new StringWriter();
    }

    [Test]
    public async Task NoArgs_PrintsUsage_ReturnsExit4()
    {
        var exit = await CliRunner.RunAsync(Array.Empty<string>(), _stdout, _stderr);

        Assert.That(exit, Is.EqualTo((int)GenerateAndFixExitReason.UsageError));
        Assert.That(_stderr.ToString(), Does.Contain("Usage:"));
    }

    [Test]
    public async Task Help_PrintsUsageToStdout_ReturnsZero()
    {
        var exit = await CliRunner.RunAsync(new[] { "--help" }, _stdout, _stderr);

        Assert.That(exit, Is.EqualTo(0));
        Assert.That(_stdout.ToString(), Does.Contain("Usage:"));
    }

    [Test]
    public async Task UnknownCommand_ReturnsUsageError()
    {
        var exit = await CliRunner.RunAsync(new[] { "do-the-thing" }, _stdout, _stderr);

        Assert.That(exit, Is.EqualTo((int)GenerateAndFixExitReason.UsageError));
        Assert.That(_stderr.ToString(), Does.Contain("Unknown command"));
    }

    [Test]
    public async Task GenerateAndFix_MissingProject_ReturnsUsageError()
    {
        var exit = await CliRunner.RunAsync(new[] { "generate-and-fix" }, _stdout, _stderr);

        Assert.That(exit, Is.EqualTo((int)GenerateAndFixExitReason.UsageError));
        Assert.That(_stderr.ToString(), Does.Contain("--project"));
    }

    [Test]
    public async Task GenerateAndFix_BadMaxIterations_ReturnsUsageError()
    {
        var exit = await CliRunner.RunAsync(
            new[] { "generate-and-fix", "--project", "x", "--max-iterations", "-1" },
            _stdout, _stderr);

        Assert.That(exit, Is.EqualTo((int)GenerateAndFixExitReason.UsageError));
    }

    [Test]
    public async Task GenerateAndFix_HappyPath_WritesJsonSummaryToStdout()
    {
        var steps = new FakeOrchestratorSteps();
        steps.BuildResponses.Enqueue((TestFixtures.Clean(), new List<Mcp.ClassifiedError>()));

        var exit = await CliRunner.RunAsync(
            new[] { "generate-and-fix", "--project", Path.GetTempPath(), "--skip-generation" },
            _stdout, _stderr, steps);

        Assert.That(exit, Is.EqualTo(0));
        var stdoutText = _stdout.ToString();
        using var doc = JsonDocument.Parse(stdoutText);
        Assert.That(doc.RootElement.GetProperty("success").GetBoolean(), Is.True);
        Assert.That(doc.RootElement.GetProperty("exitReason").GetString(), Is.EqualTo("Success"));
    }

    [Test]
    public async Task GenerateAndFix_BuildFails_PropagatesExitCode1()
    {
        var steps = new FakeOrchestratorSteps();
        steps.BuildResponses.Enqueue((
            TestFixtures.Failed(1),
            new List<Mcp.ClassifiedError> { TestFixtures.NonDeterministic("src/Foo.cs") }));

        var exit = await CliRunner.RunAsync(
            new[] { "generate-and-fix", "-p", Path.GetTempPath(), "--skip-generation" },
            _stdout, _stderr, steps);

        Assert.That(exit, Is.EqualTo((int)GenerateAndFixExitReason.BuildFailed));
        Assert.That(_stdout.ToString(), Does.Contain("\"success\": false"));
    }

    [Test]
    public void TryParseGenerateAndFixOptions_AcceptsAllFlags()
    {
        var ok = CliRunner.TryParseGenerateAndFixOptions(
            new[]
            {
                "generate-and-fix",
                "--project", "C:\\foo",
                "--specs-path", "C:\\bar",
                "--max-iterations", "3",
                "--skip-generation",
            },
            _stderr,
            out var options);

        Assert.That(ok, Is.True);
        Assert.That(options.ProjectPath, Is.EqualTo(Path.GetFullPath("C:\\foo")));
        Assert.That(options.LocalSpecsPath, Is.EqualTo(Path.GetFullPath("C:\\bar")));
        Assert.That(options.MaxIterations, Is.EqualTo(3));
        Assert.That(options.SkipGeneration, Is.True);
    }
}
