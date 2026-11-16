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
    private const string LegacyDefaultsPrefix = "MemoryStores=V1Preview,WorkflowAgents=V1Preview,";

    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void RetiredFeatureNormalizationIsPlaybackOnly(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        ProjectsTestSanitizers.ApplySanitizers(fixture);
        var sanitizers = fixture.HeaderRegexSanitizers.Where(sanitizer =>
            sanitizer.Body.Key == "Foundry-Features" &&
            sanitizer.Body.Regex == ProjectsTestSanitizers.LegacyAgentInsightsFeaturePattern).ToList();

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

    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void LegacyDefaultVoiceFeatureNormalizationIsPlaybackOnly(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        ProjectsTestSanitizers.ApplySanitizers(fixture);
        var sanitizers = fixture.HeaderRegexSanitizers.Where(sanitizer =>
            sanitizer.Body.Key == "Foundry-Features" &&
            sanitizer.Body.Regex == ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern).ToList();

        Assert.That(sanitizers, Has.Count.EqualTo(expectedCount));
        Assert.That(fixture.IgnoredHeaders, Does.Not.Contain("Foundry-Features"));
        if (expectedCount > 0)
        {
            Assert.That(sanitizers[0].Body.Value, Is.EqualTo(ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement));
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
        string normalized = Regex.Replace(value, ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern,
            ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement);
        Assert.That(normalized, Is.EqualTo(expected));
        Assert.That(Regex.Replace(normalized, ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeaturePattern,
            ProjectsTestSanitizers.LegacyDefaultVoiceAgentFeatureReplacement), Is.EqualTo(expected));
    }

    private sealed class SanitizerFixture : RecordedTestBase<ProjectsOpenAITestEnvironment>
    {
        public SanitizerFixture(RecordedTestMode mode) : base(false, mode)
        {
        }
    }
}
