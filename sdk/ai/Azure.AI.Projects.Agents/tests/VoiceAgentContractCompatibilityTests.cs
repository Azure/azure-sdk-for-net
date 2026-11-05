// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001, OPENAI001, OPENAI002

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentContractCompatibilityTests
{
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
}
