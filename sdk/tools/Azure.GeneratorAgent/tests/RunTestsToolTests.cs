// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class RunTestsToolTests
{
    [Test]
    public void ParseTestOutput_PassingTests_ReturnsSuccess()
    {
        var output = """
            Starting test execution, please wait...
            A total of 1 test files matched the specified pattern.
            Passed!  - Failed:     0, Passed:    42, Skipped:     0, Total:    42, Duration: 1 s - MyTests.dll (net10.0)
            """;

        var result = RunTestsTool.ParseTestOutput(output, exitCode: 0);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Passed, Is.EqualTo(42));
            Assert.That(result.Failed, Is.EqualTo(0));
            Assert.That(result.Skipped, Is.EqualTo(0));
            Assert.That(result.Total, Is.EqualTo(42));
            Assert.That(result.Failures, Is.Empty);
        });
    }

    [Test]
    public void ParseTestOutput_FailingTests_ReturnsFailures()
    {
        var output = """
            Starting test execution, please wait...
            A total of 1 test files matched the specified pattern.
            Failed MyNamespace.MyTests.TestMethod1 [42 ms]
              Error Message:
               Assert.That(actual, Is.EqualTo(expected))
            Failed!  - Failed:     2, Passed:    10, Skipped:     1, Total:    13, Duration: 3 s - MyTests.dll (net10.0)
            """;

        var result = RunTestsTool.ParseTestOutput(output, exitCode: 1);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.False);
            Assert.That(result.ExitCode, Is.EqualTo(1));
            Assert.That(result.Passed, Is.EqualTo(10));
            Assert.That(result.Failed, Is.EqualTo(2));
            Assert.That(result.Skipped, Is.EqualTo(1));
            Assert.That(result.Total, Is.EqualTo(13));
            Assert.That(result.Failures, Is.Not.Empty);
            Assert.That(result.Failures[0], Does.Contain("TestMethod1"));
        });
    }

    [Test]
    public void ParseTestOutput_NoSummaryLine_StillSetsExitCode()
    {
        var output = "Build failed. Some error occurred.";

        var result = RunTestsTool.ParseTestOutput(output, exitCode: 1);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.False);
            Assert.That(result.ExitCode, Is.EqualTo(1));
            Assert.That(result.Total, Is.EqualTo(0));
        });
    }

    [Test]
    public void ParseTestOutput_EmptyOutput_ReturnsDefaults()
    {
        var result = RunTestsTool.ParseTestOutput("", exitCode: 0);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Passed, Is.EqualTo(0));
            Assert.That(result.Total, Is.EqualTo(0));
            Assert.That(result.Failures, Is.Empty);
        });
    }

    [Test]
    public void ParseTestOutput_XStyleFailures_ExtractsFailureLines()
    {
        var output = """
            X TestMethod2 [15 ms]
              Expected: 5
              But was:  3
            Passed!  - Failed:     1, Passed:     9, Skipped:     0, Total:    10
            """;

        var result = RunTestsTool.ParseTestOutput(output, exitCode: 1);

        Assert.Multiple(() =>
        {
            Assert.That(result.Failures, Has.Count.EqualTo(1));
            Assert.That(result.Failures[0], Does.Contain("TestMethod2"));
            Assert.That(result.Failures[0], Does.Contain("Expected: 5"));
        });
    }
}
