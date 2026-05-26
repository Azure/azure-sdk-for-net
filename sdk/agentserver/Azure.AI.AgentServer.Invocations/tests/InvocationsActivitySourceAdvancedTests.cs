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
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void StartInvocationActivity_TruncatesXRequestId_At256Characters()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        FoundryEnvironment.Reload();

        // Use a unique activity source name to avoid cross-fixture interference
        const string sourceName = "test.truncation.256";
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new TestableActivitySource(sourceName);
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, StringValues>(),
            IsolationContext.Empty);

        // Create x-request-id longer than 256 characters
        var longRequestId = new string('x', 300);
        var headers = new HeaderDictionary { ["x-request-id"] = longRequestId };

        using var activity = source.StartInvocationActivity(context, headers);

        Assert.That(activity, Is.Not.Null);

        var tagValue = activity!.GetTagItem("azure.ai.agentserver.x-request-id") as string;
        Assert.That(tagValue, Is.Not.Null);
        Assert.That(tagValue!.Length, Is.EqualTo(256));

        var baggageValue = activity.GetBaggageItem("x-request-id");
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
    }

    [Test]
    public void StartInvocationActivity_DoesNotTruncateXRequestId_WhenExactly256()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        FoundryEnvironment.Reload();

        const string sourceName = "test.truncation.exact";
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new TestableActivitySource(sourceName);
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, StringValues>(),
            IsolationContext.Empty);

        var exactRequestId = new string('y', 256);
        var headers = new HeaderDictionary { ["x-request-id"] = exactRequestId };

        using var activity = source.StartInvocationActivity(context, headers);

        Assert.That(activity, Is.Not.Null);

        var tagValue = activity!.GetTagItem("azure.ai.agentserver.x-request-id") as string;
        Assert.That(tagValue, Is.EqualTo(exactRequestId));
    }

    [Test]
    public void ProtectedConstructor_WithCustomName_CreatesCustomActivitySource()
    {
        const string sourceName = "custom.invocations.test";
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new TestableActivitySource(sourceName);
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.Source.Name, Is.EqualTo(sourceName));
    }

    [Test]
    public void ProtectedConstructor_WithNull_FallsBackToDefaultName()
    {
        // Verify the null fallback by checking the actual source name resolved.
        // Register a listener for DefaultName to confirm the source uses it.
        const string sourceName = "test.null-fallback.sentinel";
        var capturedDefaultSourceName = (string?)null;

        using var sentinel = new ActivityListener
        {
            ShouldListenTo = source =>
            {
                if (source.Name == InvocationsActivitySource.DefaultName)
                {
                    capturedDefaultSourceName = source.Name;
                }
                // Only listen to our sentinel name (never matches) to avoid side effects
                return source.Name == sourceName;
            },
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.None,
        };
        ActivitySource.AddActivityListener(sentinel);

        // Creating the source with null should fall back to DefaultName,
        // which triggers the ShouldListenTo callback above
        _ = new TestableActivitySource(null);

        Assert.That(capturedDefaultSourceName, Is.EqualTo(InvocationsActivitySource.DefaultName));
    }

    /// <summary>
    /// Subclass that exposes the protected constructor for testing.
    /// </summary>
    private sealed class TestableActivitySource : InvocationsActivitySource
    {
        public TestableActivitySource(string? name) : base(name) { }
    }
}
