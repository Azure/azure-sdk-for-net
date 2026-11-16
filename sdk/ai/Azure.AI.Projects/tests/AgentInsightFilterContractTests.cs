// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class AgentInsightFilterContractTests
{
    private const string LegacyDefaultsPrefix = "MemoryStores=V1Preview,WorkflowAgents=V1Preview,";

    [TestCase("AgentInsights=V1Preview,VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("VoiceAgents=V1Preview,AgentInsights=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("A=V1Preview,AgentInsights=V1Preview,B=V1Preview", "A=V1Preview,B=V1Preview")]
    [TestCase("AgentInsights=V1Preview", "")]
    [TestCase("OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra", "OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra")]
    public void PlaybackNormalizationRemovesOnlyAgentInsightsFeature(string value, string expected)
        => Assert.That(Regex.Replace(value, Utils.ProjectsTestSanitizers.PlaybackAgentInsightsFeaturePattern, ""), Is.EqualTo(expected));

    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void LegacyDefaultVoiceFeatureNormalizationIsPlaybackOnly(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        Utils.ProjectsTestSanitizers.ApplySanitizers(fixture);
        var sanitizers = fixture.HeaderRegexSanitizers.Where(sanitizer =>
            sanitizer.Body.Key == "Foundry-Features" &&
            sanitizer.Body.Regex == Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern).ToList();

        Assert.That(sanitizers, Has.Count.EqualTo(expectedCount));
        Assert.That(fixture.IgnoredHeaders, Does.Not.Contain("Foundry-Features"));
        Assert.That(fixture.CustomSanitizers.OfType<RemoveHeaderSanitizer>()
            .Where(sanitizer => sanitizer.Body.HeadersForRemoval == "Foundry-Features"), Is.Empty);
        if (expectedCount > 0)
        {
            Assert.That(sanitizers[0].Body.Value, Is.EqualTo(Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement));
        }
    }

    [TestCase(LegacyDefaultsPrefix + "DraftAgents=V1Preview,VoiceAgents=V1Preview,ModelRouterControls=V1Preview",
        LegacyDefaultsPrefix + "DraftAgents=V1Preview,ModelRouterControls=V1Preview")]
    [TestCase(LegacyDefaultsPrefix + "Routines=V2Preview,DraftAgents=V1Preview,VoiceAgents=V1Preview,ModelRouterControls=V1Preview,GitHubCopilot=V1Preview",
        LegacyDefaultsPrefix + "Routines=V2Preview,DraftAgents=V1Preview,ModelRouterControls=V1Preview,GitHubCopilot=V1Preview")]
    [TestCase("VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("DraftAgents=V1Preview,VoiceAgents=V1Preview,ModelRouterControls=V1Preview",
        "DraftAgents=V1Preview,VoiceAgents=V1Preview,ModelRouterControls=V1Preview")]
    [TestCase(LegacyDefaultsPrefix + "DraftAgents=V1Preview,ModelRouterControls=V1Preview,VoiceAgents=V1Preview",
        LegacyDefaultsPrefix + "DraftAgents=V1Preview,ModelRouterControls=V1Preview,VoiceAgents=V1Preview")]
    [TestCase(LegacyDefaultsPrefix + "DraftAgents=V1Preview,VoiceAgents=V2Preview,ModelRouterControls=V1Preview",
        LegacyDefaultsPrefix + "DraftAgents=V1Preview,VoiceAgents=V2Preview,ModelRouterControls=V1Preview")]
    public void LegacyDefaultVoiceNormalizationPreservesOtherFlagsAndExplicitOptIns(string value, string expected)
    {
        string normalized = Regex.Replace(value, Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern,
            Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement);
        Assert.That(normalized, Is.EqualTo(expected));
        Assert.That(Regex.Replace(normalized, Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern,
            Utils.ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement), Is.EqualTo(expected));
    }

    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void LegacyLiveVoiceHeaderRemovalIsPlaybackOnlyAndFixtureScoped(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        Utils.ProjectsTestSanitizers.ApplySanitizers(fixture);
        string[] ignoredBefore = fixture.IgnoredHeaders.ToArray();
        var customBefore = fixture.CustomSanitizers.ToArray();
        var headersBefore = fixture.HeaderRegexSanitizers.ToArray();
        var bodiesBefore = fixture.BodyRegexSanitizers.ToArray();
        var urisBefore = fixture.UriRegexSanitizers.ToArray();

        Utils.ProjectsTestSanitizers.ApplyLegacyLiveVoiceRecordingHeaders(fixture);

        var additions = fixture.CustomSanitizers.Except(customBefore).ToArray();
        var removers = additions.OfType<RemoveHeaderSanitizer>().ToArray();
        Assert.That(additions, Has.Length.EqualTo(expectedCount));
        Assert.That(removers, Has.Length.EqualTo(expectedCount));
        if (expectedCount > 0)
        {
            Assert.That(removers[0].Body.HeadersForRemoval, Is.EqualTo("Foundry-Features"));
        }
        Assert.Multiple(() =>
        {
            Assert.That(fixture.IgnoredHeaders, Is.EquivalentTo(ignoredBefore));
            Assert.That(customBefore.Except(fixture.CustomSanitizers), Is.Empty);
            Assert.That(fixture.HeaderRegexSanitizers, Is.EqualTo(headersBefore));
            Assert.That(fixture.BodyRegexSanitizers, Is.EqualTo(bodiesBefore));
            Assert.That(fixture.UriRegexSanitizers, Is.EqualTo(urisBefore));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task InsightCollectionFiltersMayBeOmitted(bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)
            .WithContent("""{"data":[],"has_more":false}"""))
        { ExpectSyncPipeline = !isAsync };
        AIProjectClient project = new(
            new Uri("https://example.services.ai.azure.com/api/projects/project"),
            new FakeTokenProvider(), new() { Transport = transport });
        if (isAsync)
        {
            await foreach (AgentInsight _ in project.AgentInsightMonitors.GetInsightsAsync("monitor"))
            {
                Assert.Fail("The canned terminal page is empty.");
            }
        }
        else
        {
            Assert.That(project.AgentInsightMonitors.GetInsights("monitor").ToList(), Is.Empty);
        }

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(transport.Requests[0].Uri.Query, Does.Not.Contain("categories=")
            .And.Not.Contain("severities=").And.Not.Contain("statuses=")
            .And.Not.Contain("category=").And.Not.Contain("severity=").And.Not.Contain("status="));
    }

    [Test]
    public async Task InsightCollectionFiltersUsePluralWireParameters(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool multiple)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)
            .WithContent("""{"data":[],"has_more":false}"""))
        { ExpectSyncPipeline = !isAsync };
        AIProjectClient project = new(
            new Uri("https://example.services.ai.azure.com/api/projects/project"),
            new FakeTokenProvider(), new() { Transport = transport });
        string[] categories = multiple ? ["latency", "quality"] : ["latency"];
        AgentInsightSeverity[] severities = multiple
            ? [AgentInsightSeverity.High, AgentInsightSeverity.Low] : [AgentInsightSeverity.High];
        AgentInsightStatus[] statuses = multiple
            ? [AgentInsightStatus.Active, AgentInsightStatus.Resolved] : [AgentInsightStatus.Active];
        if (isAsync)
        {
            await foreach (AgentInsight _ in project.AgentInsightMonitors.GetInsightsAsync(
                "monitor /?", limit: 7, categories: categories, severities: severities,
                statuses: statuses, includeDetails: true))
            {
                Assert.Fail("The canned terminal page is empty.");
            }
        }
        else
        {
            Assert.That(project.AgentInsightMonitors.GetInsights(
                "monitor /?", limit: 7, categories: categories, severities: severities,
                statuses: statuses, includeDetails: true).ToList(), Is.Empty);
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        Dictionary<string, string> query = request.Uri.Query.TrimStart('?').Split('&')
            .Select(pair => pair.Split(new[] { '=' }, 2))
            .ToDictionary(pair => Uri.UnescapeDataString(pair[0]), pair => Uri.UnescapeDataString(pair[1]));
        Assert.Multiple(() =>
        {
            Assert.That(request.Uri.AbsolutePath, Does.EndWith("/agent_insight_monitors/monitor%20%2F%3F/insights"));
            Assert.That(query["categories"], Is.EqualTo(string.Join(",", categories)));
            Assert.That(query["severities"], Is.EqualTo(multiple ? "high,low" : "high"));
            Assert.That(query["statuses"], Is.EqualTo(multiple ? "active,resolved" : "active"));
            Assert.That(query["include_details"], Is.EqualTo("true"));
            Assert.That(query["limit"], Is.EqualTo("7"));
            Assert.That(query.ContainsKey("category"), Is.False);
            Assert.That(query.ContainsKey("severity"), Is.False);
            Assert.That(query.ContainsKey("status"), Is.False);
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
            Assert.That(features, Does.Contain("AgentInsights=V1Preview"));
        });
    }

    private sealed class SanitizerFixture : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public SanitizerFixture(RecordedTestMode mode) : base(false, mode)
        {
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
