// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001, AAIP002, OPENAI001, OPENAI002

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentContractCompatibilityTests
{
    [TestCase(RecordedTestMode.Playback, 1)]
    [TestCase(RecordedTestMode.Record, 0)]
    [TestCase(RecordedTestMode.Live, 0)]
    public void LegacySkillsRouteNormalizationIsPlaybackOnly(RecordedTestMode mode, int expectedCount)
    {
        SanitizerFixture fixture = new(mode);
        ProjectsTestSanitizers.ApplySanitizers(fixture);
        var sanitizers = fixture.UriRegexSanitizers
            .Where(sanitizer => sanitizer.Body.Regex == ProjectsTestSanitizers.LegacySkillsPathPattern).ToList();
        Assert.That(sanitizers, Has.Count.EqualTo(expectedCount));
        if (expectedCount > 0)
        {
            Assert.That(sanitizers[0].Body.Value, Is.EqualTo(ProjectsTestSanitizers.LegacySkillsPathReplacement));
        }
    }

    [TestCase("https://example.test/api/projects/project/skills?limit=3&order=asc&api-version=v1",
        "https://example.test/api/projects/project/openai/v1/skills?limit=3&order=asc&api-version=v1")]
    [TestCase("https://example.test/api/projects/project/skills/skill/versions?api-version=v1",
        "https://example.test/api/projects/project/openai/v1/skills/skill/versions?api-version=v1")]
    [TestCase("https://example.test/api/projects/project/skills/skill/versions/1/content",
        "https://example.test/api/projects/project/openai/v1/skills/skill/versions/1/content")]
    [TestCase("https://example.test/api/projects/skills/skills",
        "https://example.test/api/projects/skills/openai/v1/skills")]
    [TestCase("https://example.test/api/projects/project/openai/v1/skills?api-version=v1",
        "https://example.test/api/projects/project/openai/v1/skills?api-version=v1")]
    [TestCase("https://example.test/api/projects/project/skills_extra",
        "https://example.test/api/projects/project/skills_extra")]
    [TestCase("https://example.test/api/projects/project/agents/skills",
        "https://example.test/api/projects/project/agents/skills")]
    [TestCase("https://example.test/skills/skill",
        "https://example.test/skills/skill")]
    [TestCase("https://example.test/api/projects/project/agents?next=/api/projects/other/skills",
        "https://example.test/api/projects/project/agents?next=/api/projects/other/skills")]
    public void LegacySkillsRecordingRoutesPreserveOtherPaths(string uri, string expected)
    {
        string normalized = Regex.Replace(uri, ProjectsTestSanitizers.LegacySkillsPathPattern,
            ProjectsTestSanitizers.LegacySkillsPathReplacement);
        Assert.That(normalized, Is.EqualTo(expected));
    }

    [Test]
    public void GeneratedSkillsRequestsUseOpenAIV1RoutesWithoutPlaybackNormalization()
    {
        ProjectAgentSkills client = new(null, ClientPipeline.Create(),
            new Uri("https://example.test/api/projects/project"), "v1");
        using PipelineMessage list = client.CreateGetSkillsRequest(null, null, null, null, null);
        using BinaryContent content = BinaryContent.Create(BinaryData.FromString("{}"));
        using PipelineMessage create = client.CreateCreateSkillVersionRequest("skill-name", content, null);
        Assert.Multiple(() =>
        {
            Assert.That(list.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/project/openai/v1/skills"));
            Assert.That(create.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/project/openai/v1/skills/skill-name/versions"));
        });
    }

    [TestCase(typeof(VoiceAgentDefinition))]
    [TestCase(typeof(VoiceAgentBaseDefinition))]
    [TestCase(typeof(VoiceAgentSubProtocol))]
    [TestCase(typeof(VoiceAgentSubagentConfig))]
    [TestCase(typeof(VoiceAgentDelegateSubagentConfig))]
    [TestCase(typeof(VoiceAgentTool))]
    [TestCase(typeof(VoiceAgentMcpTool))]
    [TestCase(typeof(VoiceConversation))]
    [TestCase(typeof(VoiceAudioItem))]
    [TestCase(typeof(VoiceGeneratedAudioItem))]
    [TestCase(typeof(VoiceRecording))]
    [TestCase(typeof(TelephonyAddress))]
    [TestCase(typeof(PhoneNumber))]
    [TestCase(typeof(TeamsAddress))]
    [TestCase(typeof(TelephonyBinding))]
    [TestCase(typeof(TwilioTelephonyBinding))]
    [TestCase(typeof(TeamsPhoneExtensibilityTelephonyBinding))]
    [TestCase(typeof(BetaVoiceAgentsConversations))]
    [TestCase(typeof(BetaVoiceAgentsTelephony))]
    [TestCase(typeof(BetaVoiceAgentsTelephonyGetTelephonyCallsCollectionResult))]
    [TestCase(typeof(BetaVoiceAgentsTelephonyGetTelephonyCallsAsyncCollectionResult))]
    [TestCase(typeof(BetaVoiceAgentsTelephonyGetTelephonyCallJobsCollectionResult))]
    [TestCase(typeof(BetaVoiceAgentsTelephonyGetTelephonyCallJobsAsyncCollectionResult))]
    [TestCase(typeof(GenerateVoiceAgentRequest))]
    public void CoreVoiceTypesAreNotBlanketPreview(Type type)
    {
        Assert.That(type.GetCustomAttribute<ExperimentalAttribute>(), Is.Null,
            "Conditional preview variants must not mark the whole GA type experimental.");
    }

    [TestCase(typeof(VoiceAgentLiveDefinition))]
    [TestCase(typeof(BetaVoiceAgentsLiveConversations))]
    [TestCase(typeof(VoiceAgentInlineSubagentConfig))]
    [TestCase(typeof(SipAddress))]
    [TestCase(typeof(SipTelephonyBinding))]
    [TestCase(typeof(TelephonyCampaign))]
    [TestCase(typeof(VoiceAgentPostCallConfig))]
    public void RequiredVoicePreviewTypesRetainOptIn(Type type)
    {
        Assert.That(type.GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
    }

    [Test]
    public void PostCallRemainsPreviewOnOtherwiseStableVoiceDefinition()
    {
        Assert.That(typeof(VoiceAgentDefinition).GetProperty(nameof(VoiceAgentDefinition.PostCall))
            .GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
    }

    [Test]
    public void CoreConversationClientFactoryIsNotPreview()
    {
        Assert.That(typeof(AgentAdministrationClient)
            .GetMethod(nameof(AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations))
            .GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(AgentAdministrationClient)
            .GetMethod(nameof(AgentAdministrationClient.GetBetaVoiceAgentTelephony))
            .GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
    }

    [TestCase(typeof(VoiceConversation))]
    [TestCase(typeof(VoiceResult))]
    [TestCase(typeof(TelephonyBinding))]
    [TestCase(typeof(TelephonyAddress))]
    public void StableSerializationMembersDoNotRequirePreviewOptIn(Type type)
    {
        MethodInfo[] members = type.GetMethods(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(method => method.Name is "op_Implicit" or "op_Explicit" or
                "JsonModelCreateCore" or "JsonModelWriteCore" or
                "PersistableModelCreateCore" or "PersistableModelWriteCore").ToArray();
        Assert.That(members, Is.Not.Empty);
        foreach (MethodInfo method in members)
        {
            Assert.That(method.GetCustomAttribute<ExperimentalAttribute>(), Is.Null, method.Name);
        }
    }

    [Test]
    public void McpToolboxRequestHeaderBindingsRoundTrip()
    {
        MCPToolboxTool tool = ModelReaderWriter.Read<MCPToolboxTool>(BinaryData.FromString("""
            {"type":"mcp","server_label":"support","project_connection_id":"support-connection","request_header_bindings":[{"header_name":"X-Request-Id","source":"client_headers","required":true}]}
            """));
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(tool, new("W")));
        JsonElement binding = document.RootElement.GetProperty("request_header_bindings")[0];
        Assert.Multiple(() =>
        {
            Assert.That(tool.RequestHeaderBindings, Has.Count.EqualTo(1));
            Assert.That(tool.RequestHeaderBindings[0].HeaderName, Is.EqualTo("X-Request-Id"));
            Assert.That(tool.RequestHeaderBindings[0].Source.ToString(), Is.EqualTo("client_headers"));
            Assert.That(tool.RequestHeaderBindings[0].Required, Is.True);
            Assert.That(binding.GetProperty("header_name").GetString(), Is.EqualTo("X-Request-Id"));
            Assert.That(binding.GetProperty("source").GetString(), Is.EqualTo("client_headers"));
            Assert.That(binding.GetProperty("required").GetBoolean(), Is.True);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void DelegateConfigurationSupportsLegacyAndExplicitDiscriminators(bool includeDiscriminator)
    {
        string discriminator = includeDiscriminator ? "\"subagent_type\":\"delegate\"," : string.Empty;
        BinaryData data = BinaryData.FromString(
            "{" + discriminator + "\"subagents\":[{\"agent_name\":\"specialist\",\"agent_capabilities\":\"Answers questions\"}]}");

        VoiceAgentSubagentConfig configuration = ModelReaderWriter.Read<VoiceAgentSubagentConfig>(data);

        Assert.That(configuration, Is.TypeOf<VoiceAgentDelegateSubagentConfig>());
        VoiceAgentDelegateSubagentConfig delegated = (VoiceAgentDelegateSubagentConfig)configuration;
        Assert.Multiple(() =>
        {
            Assert.That(delegated.Subagents, Has.Count.EqualTo(1));
            Assert.That(delegated.Subagents[0].AgentName, Is.EqualTo("specialist"));
            Assert.That(delegated.Subagents[0].AgentCapabilities, Is.EqualTo("Answers questions"));
        });

        BinaryData written = ModelReaderWriter.Write(configuration, new("W"));
        using JsonDocument document = JsonDocument.Parse(written);
        Assert.That(document.RootElement.GetProperty("subagent_type").GetString(), Is.EqualTo("delegate"));
        VoiceAgentSubagentConfig restored = ModelReaderWriter.Read<VoiceAgentSubagentConfig>(written);
        Assert.That(restored, Is.TypeOf<VoiceAgentDelegateSubagentConfig>());
        Assert.That(((VoiceAgentDelegateSubagentConfig)restored).Subagents[0].AgentName, Is.EqualTo("specialist"));
    }

    [Test]
    public void UnknownSubagentModeRemainsForwardCompatible()
    {
        BinaryData data = BinaryData.FromString("{\"subagent_type\":\"future\",\"future_setting\":7}");
        VoiceAgentSubagentConfig configuration = ModelReaderWriter.Read<VoiceAgentSubagentConfig>(data);

        Assert.That(configuration, Is.Not.InstanceOf<VoiceAgentDelegateSubagentConfig>());
        Assert.That(configuration, Is.Not.InstanceOf<VoiceAgentInlineSubagentConfig>());
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(configuration));
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("subagent_type").GetString(), Is.EqualTo("future"));
            Assert.That(document.RootElement.GetProperty("future_setting").GetInt32(), Is.EqualTo(7));
        });
    }

    [Test]
    public void InlineConfigurationPreservesHandoffFieldsAndDurationUnits()
    {
        InlineVoiceSubagent entrypoint = new("$entrypoint", "Initial specialist");
        entrypoint.HandoffConditions.Add(new("route_to_specialist", "specialist", "The caller needs specialist help")
        {
            Delay = TimeSpan.FromMilliseconds(250),
            TransferMessage = null
        });
        VoiceAgentSubagentConfig configuration = new VoiceAgentInlineSubagentConfig(
            [entrypoint, new("specialist", "Answers specialist questions")]);

        BinaryData data = ModelReaderWriter.Write(configuration, new("W"));
        using JsonDocument document = JsonDocument.Parse(data);
        JsonElement first = document.RootElement.GetProperty("subagents")[0];
        JsonElement handoff = first.GetProperty("handoff_conditions")[0];
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("subagent_type").GetString(), Is.EqualTo("inline"));
            Assert.That(first.GetProperty("description").GetString(), Is.EqualTo("Initial specialist"));
            Assert.That(first.TryGetProperty("display_description", out _), Is.False);
            Assert.That(handoff.GetProperty("delay_ms").GetInt32(), Is.EqualTo(250));
            Assert.That(handoff.GetProperty("transfer_message").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });

        VoiceAgentSubagentConfig restored = ModelReaderWriter.Read<VoiceAgentSubagentConfig>(data);
        Assert.That(restored, Is.TypeOf<VoiceAgentInlineSubagentConfig>());
        Assert.That(((VoiceAgentInlineSubagentConfig)restored).Subagents[0].HandoffConditions[0].Delay,
            Is.EqualTo(TimeSpan.FromMilliseconds(250)));
    }

    [Test]
    public void OutputAudioRetainsFlatInheritedVoiceFields()
    {
        VoiceAgentAudioOutputConfig output = new()
        {
            Voice = "alloy",
            Speed = 1.1f,
            Format = new RealtimePcmAudioFormat { Rate = 24000 }
        };
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(output, new("W")));

        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("voice").GetString(), Is.EqualTo("alloy"));
            Assert.That(document.RootElement.GetProperty("speed").GetSingle(), Is.EqualTo(1.1f));
            Assert.That(document.RootElement.GetProperty("format").GetProperty("rate").GetInt32(), Is.EqualTo(24000));
        });

        VoiceAgentAudioOutputConfig restored = ModelReaderWriter.Read<VoiceAgentAudioOutputConfig>(
            BinaryData.FromString(document.RootElement.GetRawText()));
        Assert.Multiple(() =>
        {
            Assert.That(restored.Voice, Is.EqualTo(output.Voice));
            Assert.That(restored.Speed, Is.EqualTo(output.Speed));
            Assert.That(restored.Format, Is.TypeOf<RealtimePcmAudioFormat>());
        });
    }

    [Test]
    public void OutputAudioModelFactoryKeepsExistingParameterOrder()
    {
        string[] originalParameters =
        [
            "format", "voice", "voiceType", "voiceLocale", "speed", "voiceTemperature", "customLexiconUrl",
            "customTextNormalizationUrl", "preferLocales", "style", "pitch", "volume", "customVoiceEndpointId",
            "personalVoiceModel", "outputAudioTimestampTypes"
        ];
        string[] parameters = typeof(ProjectsAgentsModelFactory)
            .GetMethod(nameof(ProjectsAgentsModelFactory.VoiceAgentAudioOutputConfig))
            .GetParameters().Select(parameter => parameter.Name).ToArray();

        Assert.That(parameters, Is.EqualTo(originalParameters));
    }

    [Test]
    public void TelephonyAndSystemToolTransferDestinationsUsePublishedTypeDiscriminators()
    {
        PhoneNumber telephony = new("+15555550123");
        VoiceAgentTransferDestination systemTool = new(VoiceAgentTransferDestinationType.PhoneNumber, "+15555550123");
        using JsonDocument telephonyDocument = JsonDocument.Parse(ModelReaderWriter.Write(telephony, new("W")));
        using JsonDocument systemToolDocument = JsonDocument.Parse(ModelReaderWriter.Write(systemTool, new("W")));

        Assert.Multiple(() =>
        {
            Assert.That(telephonyDocument.RootElement.GetProperty("type").GetString(), Is.EqualTo("phone_number"));
            Assert.That(telephonyDocument.RootElement.TryGetProperty("kind", out _), Is.False);
            Assert.That(systemToolDocument.RootElement.GetProperty("type").GetString(), Is.EqualTo("phone_number"));
            Assert.That(systemToolDocument.RootElement.TryGetProperty("kind", out _), Is.False);
        });
    }

    [TestCase(1)]
    [TestCase(20)]
    [TestCase(300)]
    public void TransferRingTimeoutRoundTripsAsDurationInWireSeconds(int seconds)
    {
        VoiceAgentTransferRouting routing = new(VoiceAgentTransferStrategy.Sequential)
        {
            RingTimeoutSeconds = TimeSpan.FromSeconds(seconds)
        };
        BinaryData data = ModelReaderWriter.Write(routing, new("W"));
        using JsonDocument document = JsonDocument.Parse(data);
        Assert.That(document.RootElement.GetProperty("ring_timeout_seconds").GetDouble(), Is.EqualTo(seconds));
        VoiceAgentTransferRouting restored = ModelReaderWriter.Read<VoiceAgentTransferRouting>(data);
        Assert.That(restored.RingTimeoutSeconds, Is.EqualTo(TimeSpan.FromSeconds(seconds)));
    }

    [TestCase(null)]
    [TestCase(30)]
    public void SystemToolTimeoutUsesSecondsWithoutInventingServiceDefaults(int? timeoutSeconds)
    {
        VoiceAgentEndConversationSystemTool tool = new()
        {
            TimeoutSeconds = timeoutSeconds.HasValue ? TimeSpan.FromSeconds(timeoutSeconds.Value) : null
        };
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(tool, new("W")));

        Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("end_conversation"));
        if (timeoutSeconds.HasValue)
        {
            Assert.That(document.RootElement.GetProperty("timeout_seconds").GetInt32(), Is.EqualTo(timeoutSeconds.Value));
        }
        else
        {
            Assert.That(document.RootElement.TryGetProperty("timeout_seconds", out _), Is.False);
        }
    }

    private sealed class SanitizerFixture : RecordedTestBase<AgentsTestEnvironment>
    {
        public SanitizerFixture(RecordedTestMode mode) : base(false, mode)
        {
        }
    }
}
