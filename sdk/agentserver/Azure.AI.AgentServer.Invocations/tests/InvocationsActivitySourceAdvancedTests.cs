// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
[NonParallelizable]
public class InvocationsActivitySourceAdvancedTests
{
    private const string TestSourceName = "test.invocations.advanced";
    private static readonly ActivitySource s_testSource = new(TestSourceName);

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
        Activity.Current = null;
    }

    [Test]
    public void PropagateInvocationBaggage_TruncatesXRequestId_At256Characters()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, StringValues>(),
            IsolationContext.Empty);

        var longRequestId = new string('x', 300);
        var headers = new HeaderDictionary { ["x-request-id"] = longRequestId };

        source.PropagateInvocationBaggage(context, headers);

        var baggageValue = Activity.Current!.GetBaggageItem("x-request-id");
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
    }

    [Test]
    public void PropagateInvocationBaggage_DoesNotTruncateXRequestId_WhenExactly256()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, StringValues>(),
            IsolationContext.Empty);

        var exactRequestId = new string('y', 256);
        var headers = new HeaderDictionary { ["x-request-id"] = exactRequestId };

        source.PropagateInvocationBaggage(context, headers);

        var baggageValue = Activity.Current!.GetBaggageItem("x-request-id");
        Assert.That(baggageValue, Is.EqualTo(exactRequestId));
    }

    [Test]
    public void ProtectedConstructor_CanBeSubclassed()
    {
        // Verify subclass construction works (testability hook)
        var source = new TestableActivitySource("custom.name");
        Assert.That(source, Is.Not.Null);
    }

    [Test]
    public void ProtectedConstructor_WithNull_DoesNotThrow()
    {
        // Null name should not throw
        var source = new TestableActivitySource(null);
        Assert.That(source, Is.Not.Null);
    }

    /// <summary>
    /// Subclass that exposes the protected constructor for testing.
    /// </summary>
    private sealed class TestableActivitySource : InvocationsActivitySource
    {
        public TestableActivitySource(string? name) : base(name) { }
    }
}
