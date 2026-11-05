// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.RegularExpressions;
using Azure.AI.Extensions.OpenAI.Tests.Utils;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Extensions.OpenAI.Tests;

public class ProjectsTestSanitizerTests
{
    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void RetiredFeatureNormalizationIsPlaybackOnly(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        ProjectsTestSanitizers.ApplySanitizers(fixture);
        var sanitizers = fixture.HeaderRegexSanitizers.Where(sanitizer => sanitizer.Body.Key == "Foundry-Features").ToList();

        Assert.That(sanitizers, Has.Count.EqualTo(expectedCount));
        if (expectedCount > 0)
        {
            Assert.That(sanitizers[0].Body.Regex, Is.EqualTo(ProjectsTestSanitizers.LegacyAgentInsightsFeaturePattern));
            Assert.That(sanitizers[0].Body.Value, Is.Empty);
        }
    }

    [TestCase("AgentInsights=V1Preview,VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("VoiceAgents=V1Preview,AgentInsights=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("A=V1Preview,AgentInsights=V1Preview,B=V1Preview", "A=V1Preview,B=V1Preview")]
    [TestCase("AgentInsights=V1Preview", "")]
    [TestCase("VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase("OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra", "OtherAgentInsights=V1Preview,AgentInsights=V1PreviewExtra")]
    public void NormalizationPreservesEveryOtherFeature(string value, string expected)
        => Assert.That(Regex.Replace(value, ProjectsTestSanitizers.LegacyAgentInsightsFeaturePattern, ""), Is.EqualTo(expected));

    private sealed class SanitizerFixture : RecordedTestBase<ProjectsOpenAITestEnvironment>
    {
        public SanitizerFixture(RecordedTestMode mode) : base(false, mode)
        {
        }
    }
}
