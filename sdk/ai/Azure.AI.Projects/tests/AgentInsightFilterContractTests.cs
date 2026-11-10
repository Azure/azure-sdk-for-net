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
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class AgentInsightFilterContractTests
{
    [TestCase("AgentInsights=V1Preview,VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("VoiceAgents=V1Preview,AgentInsights=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("A=V1Preview,AgentInsights=V1Preview,B=V1Preview", "A=V1Preview,B=V1Preview")]
    [TestCase("AgentInsights=V1Preview", "")]
    [TestCase("OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra", "OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra")]
    public void LegacyRecordingNormalizationRemovesOnlyTheRetiredFeature(string value, string expected)
        => Assert.That(Regex.Replace(value, Utils.ProjectsTestSanitizers.LegacyAgentInsightsFeaturePattern, ""), Is.EqualTo(expected));

    [Test]
    public async Task InsightCollectionFiltersUseSingularWireParameters([Values(false, true)] bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)
            .WithContent("""{"data":[],"has_more":false}"""))
        { ExpectSyncPipeline = !isAsync };
        AIProjectClient project = new(
            new Uri("https://example.services.ai.azure.com/api/projects/project"),
            new FakeTokenProvider(), new() { Transport = transport });
        string[] categories = ["latency", "quality"];
        AgentInsightSeverity[] severities = [AgentInsightSeverity.High, AgentInsightSeverity.Low];
        AgentInsightStatus[] statuses = [AgentInsightStatus.Active, AgentInsightStatus.Resolved];
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
            Assert.That(query["category"], Is.EqualTo("latency,quality"));
            Assert.That(query["severity"], Is.EqualTo("high,low"));
            Assert.That(query["status"], Is.EqualTo("active,resolved"));
            Assert.That(query["include_details"], Is.EqualTo("true"));
            Assert.That(query["limit"], Is.EqualTo("7"));
            Assert.That(query.ContainsKey("categories"), Is.False);
            Assert.That(query.ContainsKey("severities"), Is.False);
            Assert.That(query.ContainsKey("statuses"), Is.False);
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
            Assert.That(features, Does.Not.Contain("AgentInsights="));
        });
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
