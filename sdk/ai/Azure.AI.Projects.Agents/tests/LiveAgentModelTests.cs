// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable AAIP001, AAIP002

namespace Azure.AI.Projects.Agents.Tests;

public class LiveAgentModelTests
{
    [TestCase("session.start", typeof(LiveSessionStartEvent))]
    [TestCase("session.update", typeof(LiveClientEventLiveSessionUpdateParam))]
    [TestCase("session.input_audio.append", typeof(LiveClientEventLiveInputAudioAppendEvent))]
    [TestCase("session.input_audio.mute", typeof(LiveClientEventLiveInputAudioMuteParam))]
    [TestCase("session.input_audio.unmute", typeof(LiveClientEventLiveInputAudioUnmuteParam))]
    [TestCase("session.instructions.append", typeof(LiveClientEventLiveInstructionsAppendParam))]
    [TestCase("session.thinking.append", typeof(LiveClientEventLiveThinkingAppendParam))]
    [TestCase("session.commentary.append", typeof(LiveClientEventLiveCommentaryAppendParam))]
    [TestCase("response.item.create", typeof(LiveClientEventLiveResponseItemCreateParam))]
    [TestCase("response.create", typeof(LiveClientEventLiveResponseCreateParam))]
    [TestCase("session.close", typeof(LiveClientEventLiveSessionCloseParam))]
    public void ClientEventDiscriminatesNativeTypes(string type, Type expectedType)
    {
        LiveClientEvent value = Read<LiveClientEvent>($$"""{"type":"{{type}}"}""");
        Assert.That(value, Is.TypeOf(expectedType));
    }

    [TestCase("session.input_audio.append", typeof(LiveInputAudioAppend))]
    [TestCase("session.output_audio.delta", typeof(LiveOutputAudioDelta))]
    [TestCase("transport.dtmf.received", typeof(LiveTransportDTMFReceived))]
    [TestCase("transport.dtmf.send", typeof(LiveTransportDTMFSend))]
    [TestCase("transport.ringing", typeof(LiveTransportRinging))]
    [TestCase("transport.answered", typeof(LiveTransportAnswered))]
    [TestCase("transport.failed", typeof(LiveTransportFailed))]
    [TestCase("session.started", typeof(LiveServerEventLiveSessionStarted))]
    [TestCase("session.updated", typeof(LiveServerEventLiveSessionUpdated))]
    [TestCase("session.input_audio.muted", typeof(LiveServerEventLiveInputAudioMuted))]
    [TestCase("session.input_audio.unmuted", typeof(LiveServerEventLiveInputAudioUnmuted))]
    [TestCase("session.instructions.appended", typeof(LiveServerEventLiveInstructionsAppended))]
    [TestCase("session.thinking.appended", typeof(LiveServerEventLiveThinkingAppended))]
    [TestCase("session.commentary.appended", typeof(LiveServerEventLiveCommentaryAppended))]
    [TestCase("session.input_transcript.delta", typeof(LiveServerEventLiveInputTranscriptDelta))]
    [TestCase("session.output_transcript.delta", typeof(LiveServerEventLiveOutputTranscriptDelta))]
    [TestCase("session.delegation.created", typeof(LiveServerEventLiveDelegationCreated))]
    [TestCase("response.event", typeof(LiveServerEventLiveResponseEvent))]
    [TestCase("session.usage.updated", typeof(LiveServerEventLiveSessionUsageUpdated))]
    [TestCase("session.closed", typeof(LiveServerEventLiveSessionClosed))]
    [TestCase("error", typeof(LiveServerEventLiveErrorEvent))]
    [TestCase("info", typeof(LiveServerEventLiveInfoEvent))]
    public void ServerEventDiscriminatesNativeTypes(string type, Type expectedType)
    {
        LiveServerEvent value = Read<LiveServerEvent>($$"""{"type":"{{type}}"}""");
        Assert.That(value, Is.TypeOf(expectedType));
    }

    private static IEnumerable<TestCaseData> ClientEvents()
    {
        yield return new TestCaseData(new LiveSessionStartEvent(new LiveSessionCreateParams(ModelIdsLive.GptLive1)), "session.start");
        yield return new TestCaseData(new LiveClientEventLiveSessionUpdateParam(new LiveSessionUpdateParams()), "session.update");
        yield return new TestCaseData(new LiveClientEventLiveInputAudioAppendEvent("AAE="), "session.input_audio.append");
        yield return new TestCaseData(new LiveClientEventLiveInputAudioMuteParam(), "session.input_audio.mute");
        yield return new TestCaseData(new LiveClientEventLiveInputAudioUnmuteParam(), "session.input_audio.unmute");
        yield return new TestCaseData(new LiveClientEventLiveInstructionsAppendParam("delegation_1", "Instructions"), "session.instructions.append");
        yield return new TestCaseData(new LiveClientEventLiveThinkingAppendParam("delegation_1", "Context"), "session.thinking.append");
        yield return new TestCaseData(new LiveClientEventLiveCommentaryAppendParam("delegation_1", "Commentary"), "session.commentary.append");
        yield return new TestCaseData(new LiveClientEventLiveResponseItemCreateParam(ResponseItem.CreateUserMessageItem("Hello")), "response.item.create");
        yield return new TestCaseData(new LiveClientEventLiveResponseCreateParam(), "response.create");
        yield return new TestCaseData(new LiveClientEventLiveSessionCloseParam(), "session.close");
    }

    [TestCaseSource(nameof(ClientEvents))]
    public void ClientConstructorsSetFixedWireDiscriminator(LiveClientEvent value, string type)
    {
        using JsonDocument document = JsonDocument.Parse(Write(value));
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo(type));
            Assert.That(document.RootElement.EnumerateObject().Count(p => p.Name == "type"), Is.EqualTo(1));
            Assert.That(typeof(LiveClientEvent).GetProperty("Type"), Is.Null, "Consumers must not change a concrete event's discriminator.");
            Assert.That(Read<LiveClientEvent>(document.RootElement.GetRawText()), Is.TypeOf(value.GetType()));
        });
    }

    [Test]
    public void SessionStartRoundTripsNativeConfiguration()
    {
        LiveSessionStartEvent value = new(new LiveSessionCreateParams(ModelIdsLive.GptLive1)
        {
            Instructions = "Answer briefly.",
            Store = true,
            Audio = new LiveInitialSessionAudioParam
            {
                Format = new LiveSessionAudioFormatPCMParam(LiveSessionAudioFormatPCMParamRate._24000)
            },
            Delegation = BinaryData.FromString("""{"type":"client"}""")
        })
        {
            EventId = "start_1"
        };

        LiveSessionStartEvent roundTrip = (LiveSessionStartEvent)Read<LiveClientEvent>(Write(value).ToString());
        using JsonDocument document = JsonDocument.Parse(Write(roundTrip));
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.EventId, Is.EqualTo("start_1"));
            Assert.That(roundTrip.Session.Model, Is.EqualTo(ModelIdsLive.GptLive1));
            Assert.That(roundTrip.Session.Store, Is.True);
            Assert.That(roundTrip.Session.Audio.Format, Is.TypeOf<LiveSessionAudioFormatPCMParam>());
            Assert.That(document.RootElement.GetProperty("session").GetProperty("audio").GetProperty("format").GetProperty("rate").GetInt32(), Is.EqualTo(24000));
            Assert.That(document.RootElement.GetProperty("session").GetProperty("delegation").ValueKind, Is.EqualTo(JsonValueKind.Object));
        });
    }

    [Test]
    public void SessionStartedRoundTripsResolvedConfigurationAndConversationId()
    {
        const string json = """
            {"type":"session.started","event_id":"server_1","client_event_id":"start_1","conversation_id":"conv_1",
             "session":{"id":"session_1","model":"gpt-live-1","expires_at":1900000000,"store":true}}
            """;
        LiveServerEventLiveSessionStarted value = (LiveServerEventLiveSessionStarted)Read<LiveServerEvent>(json);
        LiveServerEventLiveSessionStarted roundTrip = (LiveServerEventLiveSessionStarted)Read<LiveServerEvent>(Write<LiveServerEvent>(value).ToString());
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.EventId, Is.EqualTo("server_1"));
            Assert.That(roundTrip.ClientEventId, Is.EqualTo("start_1"));
            Assert.That(roundTrip.ConversationId, Is.EqualTo("conv_1"));
            Assert.That(roundTrip.Session.Id, Is.EqualTo("session_1"));
            Assert.That(roundTrip.Session.ExpiresAt, Is.EqualTo(1900000000));
            Assert.That(roundTrip.Session.Store, Is.True);
        });
    }

    [Test]
    public void AudioEventsPreserveBase64WithoutJsonOrDoubleEncoding()
    {
        byte[] audio = [0, 1, 127, 128, 254, 255];
        string base64 = Convert.ToBase64String(audio);
        LiveClientEvent input = new LiveClientEventLiveInputAudioAppendEvent(base64);
        using JsonDocument inputJson = JsonDocument.Parse(Write(input));
        LiveOutputAudioDelta output = (LiveOutputAudioDelta)Read<LiveServerEvent>($$"""
            {"type":"session.output_audio.delta","delta":"{{base64}}","start_ms":0,"end_ms":20}
            """);
        LiveOutputAudioDelta roundTrip = (LiveOutputAudioDelta)Read<LiveServerEvent>(Write<LiveServerEvent>(output).ToString());
        Assert.Multiple(() =>
        {
            Assert.That(inputJson.RootElement.GetProperty("audio").GetString(), Is.EqualTo(base64));
            Assert.That(Convert.FromBase64String(roundTrip.Delta), Is.EqualTo(audio));
            Assert.That(roundTrip.StartMs, Is.Zero);
            Assert.That(roundTrip.EndMs, Is.EqualTo(20));
        });
    }

    [Test]
    public void WireFormatRoundTripsThroughNativeEventRoots()
    {
        ModelReaderWriterOptions wire = new("W");
        LiveClientEvent sent = new LiveClientEventLiveInputAudioAppendEvent("AAH+/w==") { EventId = "audio_1" };
        BinaryData payload = ModelReaderWriter.Write(sent, wire, AzureAIProjectsAgentsContext.Default);
        LiveClientEventLiveInputAudioAppendEvent roundTrip = (LiveClientEventLiveInputAudioAppendEvent)ModelReaderWriter.Read<LiveClientEvent>(
            payload, wire, AzureAIProjectsAgentsContext.Default);
        LiveServerEvent received = ModelReaderWriter.Read<LiveServerEvent>(
            BinaryData.FromString("""{"type":"session.output_audio.delta","delta":"AAH+/w=="}"""),
            wire, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(received, wire, AzureAIProjectsAgentsContext.Default));
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Audio, Is.EqualTo("AAH+/w=="));
            Assert.That(roundTrip.EventId, Is.EqualTo("audio_1"));
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.output_audio.delta"));
            Assert.That(document.RootElement.GetProperty("delta").GetString(), Is.EqualTo("AAH+/w=="));
        });
    }

    [Test]
    public void ResponseItemUsesExistingOpenAIModelAndRoundTrips()
    {
        LiveClientEventLiveResponseItemCreateParam value = new(ResponseItem.CreateFunctionCallOutputItem("call_1", "tool result"));
        using JsonDocument document = JsonDocument.Parse(Write<LiveClientEvent>(value));
        LiveClientEventLiveResponseItemCreateParam roundTrip = (LiveClientEventLiveResponseItemCreateParam)Read<LiveClientEvent>(document.RootElement.GetRawText());
        using JsonDocument roundTripJson = JsonDocument.Parse(Write<LiveClientEvent>(roundTrip));
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Item, Is.InstanceOf<ResponseItem>());
            Assert.That(roundTripJson.RootElement.GetProperty("item").GetProperty("type").GetString(), Is.EqualTo("function_call_output"));
            Assert.That(roundTripJson.RootElement.GetProperty("item").GetProperty("call_id").GetString(), Is.EqualTo("call_1"));
            Assert.That(roundTripJson.RootElement.GetProperty("item").GetProperty("output").GetString(), Is.EqualTo("tool result"));
        });
    }

    [Test]
    public void UnknownNativeEventsPreserveDiscriminatorAndPayload()
    {
        const string json = """{"type":"session.future","event_id":"future_1","nested":{"bytes":"AAE="},"sequence":42}""";
        LiveServerEvent server = Read<LiveServerEvent>(json);
        LiveClientEvent client = Read<LiveClientEvent>(json);
        using JsonDocument serverJson = JsonDocument.Parse(Write(server));
        using JsonDocument clientJson = JsonDocument.Parse(Write(client));
        foreach (JsonElement root in new[] { serverJson.RootElement, clientJson.RootElement })
        {
            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("session.future"));
                Assert.That(root.GetProperty("event_id").GetString(), Is.EqualTo("future_1"));
                Assert.That(root.GetProperty("nested").GetProperty("bytes").GetString(), Is.EqualTo("AAE="));
                Assert.That(root.GetProperty("sequence").GetInt32(), Is.EqualTo(42));
            });
        }
    }

    [Test]
    public void KnownNativeEventsPreserveUnknownFields()
    {
        LiveServerEvent value = Read<LiveServerEvent>("""{"type":"info","event_id":"info_1","code":"notice","message":"hello","future":{"enabled":true}}""");
        using JsonDocument document = JsonDocument.Parse(Write(value));
        Assert.That(document.RootElement.GetProperty("future").GetProperty("enabled").GetBoolean(), Is.True);
    }

    [Test]
    public void UnknownClosedEnumIsReportedRatherThanDefaulted()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Read<LiveServerEvent>("""{"type":"session.closed","event_id":"closed_1","reason":"future_reason"}"""));
        Assert.Throws<ArgumentOutOfRangeException>(() => Read<LiveAudioFormat>("""{"type":"audio/pcm","rate":48000}"""));
    }

    [TestCase(null, typeof(VoiceAgentDefinition))]
    [TestCase("realtime", typeof(VoiceAgentDefinition))]
    [TestCase("live", typeof(VoiceAgentLiveDefinition))]
    public void VoiceDefinitionDispatchesAtBothRoots(string protocol, Type expectedType)
    {
        string protocolProperty = protocol == null ? "" : $",\"sub_protocol\":\"{protocol}\"";
        string json = $$"""{"kind":"voice","model":"deployment","model_type":"self_deployed"{{protocolProperty}}}""";
        ProjectsAgentDefinition root = Read<ProjectsAgentDefinition>(json);
        VoiceAgentBaseDefinition voice = Read<VoiceAgentBaseDefinition>(json);
        Assert.Multiple(() =>
        {
            Assert.That(root, Is.TypeOf(expectedType));
            Assert.That(voice, Is.TypeOf(expectedType));
        });
        using JsonDocument document = JsonDocument.Parse(Write(root));
        Assert.That(document.RootElement.TryGetProperty("sub_protocol", out _), Is.EqualTo(protocol != null));
    }

    [TestCase("\"future\"")]
    [TestCase("null")]
    [TestCase("42")]
    public void InvalidVoiceProtocolDoesNotFallBackToRealtime(string protocol)
    {
        string json = $$"""{"kind":"voice","model":"deployment","sub_protocol":{{protocol}}}""";
        Assert.Throws<JsonException>(() => Read<ProjectsAgentDefinition>(json));
        Assert.Throws<JsonException>(() => Read<VoiceAgentBaseDefinition>(json));
    }

    [Test]
    public void FailedLiveConversationRetainsInternalErrorOnRoundTrip()
    {
        VoiceAgentLiveConversation value = Read<VoiceAgentLiveConversation>("""
            {"id":"conv_1","object":"voice.conversation","status":"failed","created_at":1700000000,
             "last_error":{"code":"storage_failure","message":"Could not finalize."}}
            """);
        Assert.That(value.LastError, Is.Not.Null);
        using JsonDocument document = JsonDocument.Parse(Write(value));
        Assert.That(document.RootElement.GetProperty("last_error").GetProperty("code").GetString(), Is.EqualTo("storage_failure"));
    }

    [TestCase("input", null, typeof(VoiceAgentLiveInputConversationItem))]
    [TestCase("output", null, typeof(VoiceAgentLiveOutputConversationItem))]
    [TestCase("delegation", "client", typeof(VoiceAgentLiveClientDelegationConversationItem))]
    [TestCase("delegation", "responses", typeof(VoiceAgentLiveResponsesDelegationConversationItem))]
    [TestCase("delegation", "foundry_managed_agent", typeof(VoiceAgentLiveFoundryManagedAgentDelegationItem))]
    public void StoredLiveItemsDiscriminateKindAndDelegationTarget(string kind, string target, Type expectedType)
    {
        string targetProperty = target == null ? "" : $",\"target\":\"{target}\"";
        if (target == "foundry_managed_agent")
        {
            targetProperty += ""","agent_name":"backend","agent_version":"1","offset_ms":0,"output":[],"status":"completed" """;
        }
        string json = $$"""{"id":"item_1","type":"{{kind}}"{{targetProperty}},"created_at":1700000000}""";
        VoiceAgentLiveConversationItem value = Read<VoiceAgentLiveConversationItem>(json);
        Assert.That(value, Is.TypeOf(expectedType));
        Assert.That(Read<VoiceAgentLiveConversationItem>(Write(value).ToString()), Is.TypeOf(expectedType));
    }

    [Test]
    public void MicrosoftCopilotHarnessAndFactoriesRemainAvailable()
    {
        AgentHarness harness = new MicrosoftCopilotHarness();
        AgentHarness mock = ProjectsAgentsModelFactory.MicrosoftCopilotHarness();
        Assert.Multiple(() =>
        {
            Assert.That(Read<AgentHarness>(Write(harness).ToString()), Is.TypeOf<MicrosoftCopilotHarness>());
            Assert.That(mock, Is.TypeOf<MicrosoftCopilotHarness>());
        });
    }

    [Test]
    public void VoiceModelFactoriesPreserveLegacySignatureAndFixedDiscriminators()
    {
        VoiceAgentDefinition realtime = ProjectsAgentsModelFactory.VoiceAgentDefinition(null, VoiceModelType.SelfDeployed, "realtime-deployment");
        VoiceAgentDefinition defaultRealtime = ProjectsAgentsModelFactory.VoiceAgentDefinition();
        VoiceAgentLiveDefinition live = ProjectsAgentsModelFactory.VoiceAgentLiveDefinition(model: "live-deployment");
        using JsonDocument realtimeJson = JsonDocument.Parse(Write(realtime));
        using JsonDocument liveJson = JsonDocument.Parse(Write(live));
        Assert.Multiple(() =>
        {
            Assert.That(defaultRealtime, Is.Not.Null);
            Assert.That(realtimeJson.RootElement.GetProperty("kind").GetString(), Is.EqualTo("voice"));
            Assert.That(realtimeJson.RootElement.TryGetProperty("sub_protocol", out _), Is.False);
            Assert.That(liveJson.RootElement.GetProperty("kind").GetString(), Is.EqualTo("voice"));
            Assert.That(liveJson.RootElement.GetProperty("sub_protocol").GetString(), Is.EqualTo("live"));
            Assert.That(liveJson.RootElement.GetProperty("model_type").GetString(), Is.EqualTo("self_deployed"));
            Assert.That(live.Model, Is.EqualTo("live-deployment"));
        });
    }

    [TestCase("session.started")]
    [TestCase("session.updated")]
    [TestCase("session.closed")]
    public void SessionLifecycleRoundTripsFoundryManagedDelegationOwner(string eventType)
    {
        string closing = eventType == "session.closed" ? ""","reason":"close_requested","usage":{"seconds":1}""" : "";
        string json = $$$$"""
            {"type":"{{{{eventType}}}}","event_id":"event_1"{{{{closing}}}},
             "session":{"id":"live_1","model":"gpt-live-1","expires_at":1900000000,"status":"active",
               "audio":{"format":{"type":"audio/pcm","rate":24000}},
               "delegation":{"type":"foundry_managed_agent","agent_name":"backend","agent_version":"2"}}}
            """;
        LiveServerEvent value = Read<LiveServerEvent>(json);
        LiveServerEvent roundTrip = Read<LiveServerEvent>(Write(value).ToString());
        foreach (LiveServerEvent serverEvent in new[] { value, roundTrip })
        {
            VoiceAgentLiveSessionResource session = serverEvent switch
            {
                LiveServerEventLiveSessionStarted started => started.Session,
                LiveServerEventLiveSessionUpdated updated => updated.Session,
                LiveServerEventLiveSessionClosed closed => closed.Session,
                _ => throw new InvalidOperationException("Unexpected lifecycle event.")
            };
            VoiceAgentLiveManagedAgentDelegation owner = Read<VoiceAgentLiveManagedAgentDelegation>(session.Delegation.ToString());
            Assert.Multiple(() =>
            {
                Assert.That(session.Id, Is.EqualTo("live_1"));
                Assert.That(session.Model, Is.EqualTo(ModelIdsLive.GptLive1));
                Assert.That(session.ExpiresAt, Is.EqualTo(1900000000));
                Assert.That(session.Status, Is.EqualTo("active"));
                Assert.That(session.Audio.Format, Is.TypeOf<LiveSessionAudioFormatPCMParam>());
                Assert.That(owner.Type, Is.EqualTo("foundry_managed_agent"));
                Assert.That(owner.AgentName, Is.EqualTo("backend"));
                Assert.That(owner.AgentVersion, Is.EqualTo("2"));
            });
        }
    }

    [TestCase("client")]
    [TestCase("responses")]
    [TestCase("foundry_managed_agent")]
    [TestCase("future_owner")]
    public void DelegationCreatedRoundTripsFoundryAndNativeTargets(string target)
    {
        string responseId = target == "responses" ? ""","response_id":"response_1" """ : "";
        LiveServerEvent value = Read<LiveServerEvent>($$$$"""
            {"type":"session.delegation.created","event_id":"event_1","offset_ms":100,
             "delegation":{"id":"delegation_1","type":"delegation","target":"{{{{target}}}}"{{{{responseId}}}}}}
            """);
        LiveServerEventLiveDelegationCreated roundTrip = (LiveServerEventLiveDelegationCreated)Read<LiveServerEvent>(Write(value).ToString());
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Delegation, Is.TypeOf<VoiceAgentLiveDelegationItem>());
            Assert.That(roundTrip.Delegation.Id, Is.EqualTo("delegation_1"));
            Assert.That(roundTrip.Delegation.Type, Is.EqualTo("delegation"));
            Assert.That(roundTrip.Delegation.Target.ToString(), Is.EqualTo(target));
            Assert.That(roundTrip.Delegation.ResponseId, Is.EqualTo(target == "responses" ? "response_1" : null));
            Assert.That(roundTrip.OffsetMs, Is.EqualTo(100));
        });
    }

    [TestCase(typeof(LiveServerEventLiveSessionStarted))]
    [TestCase(typeof(LiveServerEventLiveSessionUpdated))]
    [TestCase(typeof(LiveServerEventLiveSessionClosed))]
    [TestCase(typeof(LiveServerEventLiveDelegationCreated))]
    public void FoundryEventModelsHaveExactlyOneExperimentalAttribute(Type eventType)
    {
        Assert.That(eventType.GetCustomAttributesData().Count(attribute =>
            attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute" &&
            attribute.ConstructorArguments.Count == 1 &&
            Equals(attribute.ConstructorArguments[0].Value, "AAIP001")), Is.EqualTo(1));
    }

    private static T Read<T>(string json) => ModelReaderWriter.Read<T>(
        BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

    private static BinaryData Write<T>(T value) => ModelReaderWriter.Write(
        value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
}
