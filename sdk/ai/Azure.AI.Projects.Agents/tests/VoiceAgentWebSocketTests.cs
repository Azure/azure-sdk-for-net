// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents.Tests.Samples;
using NUnit.Framework;
using OpenAI;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentWebSocketTests
{
    [Test]
    public void SerializesVoiceAgentRestConfiguration()
    {
        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = "voice-model",
            Instructions = "Keep replies short and natural.",
            Audio = new VoiceAgentAudioConfig
            {
                Input = new VoiceAgentAudioInputConfig
                {
                    Format = new RealtimePcmAudioFormat { Rate = 24000 },
                    NoiseReduction = new VoiceAgentNoiseReduction(VoiceAgentNoiseReductionType.NearField),
                    TurnDetection = new VoiceAgentServerVadTurnDetection
                    {
                        Threshold = 0.5,
                        PrefixPaddingMs = 300,
                        SilenceDurationMs = 500
                    },
                    Transcription = new VoiceAgentInputTranscription(VoiceAgentInputTranscriptionModel.Whisper1)
                },
                Output = new VoiceAgentAudioOutputConfig
                {
                    Voice = "en-US-AvaNeural",
                    VoiceType = VoiceType.AzureStandard
                }
            },
            Store = true
        };
        definition.OutputModalities.Add(VoiceOutputModality.Audio);
        definition.Tools.Add(new VoiceAgentEndConversationSystemTool());

        BinaryData data = ((IPersistableModel<VoiceAgentDefinition>)definition).Write(ModelReaderWriterOptions.Json);
        using JsonDocument document = JsonDocument.Parse(data);
        JsonElement root = document.RootElement;

        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("kind").GetString(), Is.EqualTo("voice"));
            Assert.That(root.GetProperty("model_type").GetString(), Is.EqualTo("self_deployed"));
            Assert.That(root.GetProperty("model").GetString(), Is.EqualTo("voice-model"));
            Assert.That(root.GetProperty("audio").GetProperty("input").GetProperty("format").GetProperty("type").GetString(), Is.EqualTo("audio/pcm"));
            Assert.That(root.GetProperty("audio").GetProperty("input").GetProperty("format").GetProperty("rate").GetInt32(), Is.EqualTo(24000));
            Assert.That(root.GetProperty("audio").GetProperty("output").GetProperty("voice").GetString(), Is.EqualTo("en-US-AvaNeural"));
            Assert.That(root.GetProperty("output_modalities")[0].GetString(), Is.EqualTo("audio"));
            Assert.That(root.GetProperty("tools")[0].GetProperty("name").GetString(), Is.EqualTo("end_conversation"));
            Assert.That(root.GetProperty("store").GetBoolean(), Is.True);
        });
    }

    [Test]
    public void DeserializesVoiceResponseAndPersistedAssistantOutput()
    {
        using JsonDocument document = JsonDocument.Parse("""
            {
              "id": "resp_123",
              "conversation_id": "conv_123",
              "object": "realtime.response",
              "status": "completed",
              "output_modalities": ["audio"],
              "output": [
                {
                  "id": "item_123",
                  "object": "realtime.item",
                  "type": "message",
                  "status": "completed",
                  "role": "assistant",
                  "content": [],
                  "created_at": 1720000000,
                  "response_id": "resp_123"
                }
              ]
            }
            """);

        VoiceResponse response = VoiceResponse.DeserializeVoiceResponse(
            document.RootElement,
            ModelReaderWriterOptions.Json);
        RealtimeItem assistantMessage = response.Output.Single();
        BinaryData outputData = ModelReaderWriter.Write(assistantMessage);
        using JsonDocument outputDocument = JsonDocument.Parse(outputData);

        Assert.Multiple(() =>
        {
            Assert.That(response.Id, Is.EqualTo("resp_123"));
            Assert.That(response.ConversationId, Is.EqualTo("conv_123"));
            Assert.That(response.OutputModalities, Has.Count.EqualTo(1));
            Assert.That(response.OutputModalities[0], Is.EqualTo(VoiceResponseBaseOutputModality.Audio));
            Assert.That(response.Output, Has.Count.EqualTo(1));
            Assert.That(assistantMessage, Is.Not.Null);
            Assert.That(outputDocument.RootElement.GetProperty("type").GetString(), Is.EqualTo("message"));
            Assert.That(outputDocument.RootElement.GetProperty("id").GetString(), Is.EqualTo("item_123"));
            Assert.That(outputDocument.RootElement.GetProperty("response_id").GetString(), Is.EqualTo("resp_123"));
        });
    }

    [Test]
    public void CreatesExpectedFoundryWebSocketUri()
    {
        VoiceAgentWebSocket client = new(
            clientDiagnostics: new ClientDiagnostics(new AgentAdministrationClientOptions(), true),
            pipeline: ClientPipeline.Create(new AgentAdministrationClientOptions()),
            endpoint: new Uri("https://example.services.ai.azure.com/api/projects/my-project/"),
            apiVersion: "v1",
            tokenProvider: null);
        VoiceAgentConnectionOptions options = new()
        {
            SessionId = "session 1",
            AgentVersion = "4",
            Store = true,
            StructuredInputs = BinaryData.FromObjectAsJson(new { topic = "space" }),
            Transport = "webrtc"
        };

        Uri uri = client.CreateWebSocketUri("agent/name", options);

        Assert.Multiple(() =>
        {
            Assert.That(uri.Scheme, Is.EqualTo("wss"));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice"));
            Assert.That(uri.Query, Does.Contain("api-version=v1"));
            Assert.That(uri.Query, Does.Contain("agent_session_id=session%201"));
            Assert.That(uri.Query, Does.Contain("x-agent-version-override=4"));
            Assert.That(uri.Query, Does.Contain("store=true"));
            Assert.That(uri.Query, Does.Contain("x-ms-client-sdk=Azure-VoiceAgents-SDK%2F.NET"));
            Assert.That(uri.Query, Does.Contain("transport=webrtc"));
            Assert.That(uri.Query, Does.Contain($"structured_input={Uri.EscapeDataString("{\"topic\":\"space\"}")}"));
        });
    }

    [Test]
    public void CreatesExpectedConversationRestUris()
    {
        AgentAdministrationClient administrationClient = new(
            new Uri("https://example.services.ai.azure.com/api/projects/my-project"),
            new AgentAdministrationClientOptions());
        AgentEndpointConversations conversations = administrationClient.GetAgentEndpointConversations();

        using PipelineMessage list = conversations.CreateGetAgentConversationsRequest(
            "agent/name",
            limit: 10,
            order: "desc",
            after: "after id",
            before: null,
            options: null);
        using PipelineMessage responseItems = conversations.CreateGetAgentConversationResponseItemsRequest(
            "agent/name",
            "conversation/id",
            "response/id",
            limit: null,
            order: null,
            after: null,
            before: null,
            options: null);
        using PipelineMessage itemAudio = conversations.CreateGetAgentConversationItemAudioContentRequest(
            "agent/name",
            "conversation/id",
            "item/id",
            options: null);
        using PipelineMessage conversationAudio = conversations.CreateGetAgentConversationAudioContentRequest(
            "agent/name",
            "conversation/id",
            options: null);

        Assert.Multiple(() =>
        {
            Assert.That(list.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice/conversations"));
            Assert.That(list.Request.Uri.Query, Does.Contain("limit=10"));
            Assert.That(list.Request.Uri.Query, Does.Contain("order=desc"));
            Assert.That(list.Request.Uri.Query, Does.Contain("after=after%20id"));
            Assert.That(responseItems.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice/conversations/conversation%2Fid/responses/response%2Fid/items"));
            Assert.That(itemAudio.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice/conversations/conversation%2Fid/items/item%2Fid/audio/content"));
            Assert.That(conversationAudio.Request.Uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice/conversations/conversation%2Fid/audio/content"));
        });
    }

    [Test]
    public async Task ReassemblesFragmentedMessages()
    {
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame("hel", WebSocketMessageType.Text, endOfMessage: false),
            new TestWebSocket.Frame("lo", WebSocketMessageType.Text, endOfMessage: true),
            TestWebSocket.Frame.Close());
        await using VoiceAgentSession session = new(webSocket);
        List<VoiceAgentSessionMessage> messages = new();

        await foreach (VoiceAgentSessionMessage message in session.ReceiveUpdatesAsync())
        {
            messages.Add(message);
        }

        Assert.That(messages, Has.Count.EqualTo(1));
        Assert.That(messages[0].MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(messages[0].Data.ToString(), Is.EqualTo("hello"));
    }

    [Test]
    public async Task SendsTextAndBinaryFrames()
    {
        TestWebSocket webSocket = new();
        await using VoiceAgentSession session = new(webSocket);

        await session.SendCommandAsync(BinaryData.FromString("{\"type\":\"response.create\"}"));
        await session.SendBinaryAsync(BinaryData.FromBytes(new byte[] { 1, 2, 3 }));

        Assert.That(webSocket.SentFrames, Has.Count.EqualTo(2));
        Assert.That(webSocket.SentFrames[0].MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(Encoding.UTF8.GetString(webSocket.SentFrames[0].Data), Is.EqualTo("{\"type\":\"response.create\"}"));
        Assert.That(webSocket.SentFrames[1].MessageType, Is.EqualTo(WebSocketMessageType.Binary));
        Assert.That(webSocket.SentFrames[1].Data, Is.EqualTo(new byte[] { 1, 2, 3 }));
    }

    [Test]
    public async Task StreamsInputAudioAndSendsBufferControls()
    {
        byte[] audio = new byte[20 * 1024];
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i] = (byte)(i % 251);
        }

        TestWebSocket webSocket = new();
        await using VoiceAgentSession session = new(webSocket);

        await session.SendInputAudioAsync(new MemoryStream(audio));
        await session.CommitPendingAudioAsync();
        await session.ClearInputAudioAsync();
        await session.ClearOutputAudioAsync();

        List<JsonElement> events = webSocket.SentFrames
            .Select(frame => JsonDocument.Parse(frame.Data).RootElement.Clone())
            .ToList();
        byte[] streamedAudio = events
            .Where(item => item.GetProperty("type").GetString() == "input_audio_buffer.append")
            .SelectMany(item => Convert.FromBase64String(item.GetProperty("audio").GetString()))
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(events.Count(item => item.GetProperty("type").GetString() == "input_audio_buffer.append"), Is.GreaterThan(1));
            Assert.That(streamedAudio, Is.EqualTo(audio));
            Assert.That(events[^3].GetProperty("type").GetString(), Is.EqualTo("input_audio_buffer.commit"));
            Assert.That(events[^2].GetProperty("type").GetString(), Is.EqualTo("input_audio_buffer.clear"));
            Assert.That(events[^1].GetProperty("type").GetString(), Is.EqualTo("output_audio_buffer.clear"));
        });
    }

    [Test]
    public async Task SendAudioInputStreamsAudioConcurrentlyWithReceiving()
    {
        byte[] inputAudio = new byte[20 * 1024];
        for (int i = 0; i < inputAudio.Length; i++)
        {
            inputAudio[i] = (byte)(i % 251);
        }
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame(
                "{\"type\":\"response.done\",\"response\":{\"status\":\"completed\",\"conversation_id\":\"conv_123\"}}",
                WebSocketMessageType.Text,
                endOfMessage: true));
        await using VoiceAgentSession session = new(webSocket);
        using MemoryStream input = new(inputAudio);

        // Verifies VoiceAgentSession supports concurrent Send/Receive on the same session: a
        // send-only loop runs alongside a single receive loop, since ReceiveUpdatesAsync is a
        // one-shot stream that must only be enumerated once per session.
        static async Task SendAllAsync(VoiceAgentSession session, Stream inputPcm)
        {
            byte[] buffer = new byte[1200];
            int bytesRead;
            while ((bytesRead = await inputPcm.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await session.SendInputAudioAsync(BinaryData.FromBytes(buffer.AsMemory(0, bytesRead)));
            }
        }

        Task sendTask = SendAllAsync(session, input);
        List<VoiceAgentSessionMessage> received = new();
        await foreach (VoiceAgentSessionMessage message in session.ReceiveUpdatesAsync())
        {
            received.Add(message);
            if (message.EventType == RealtimeServerEventType.ResponseDone)
            {
                break;
            }
        }
        await sendTask;

        List<JsonElement> sentEvents = webSocket.SentFrames
            .Select(frame => JsonDocument.Parse(frame.Data).RootElement.Clone())
            .ToList();
        byte[] streamedInput = sentEvents
            .Where(item => item.GetProperty("type").GetString() == "input_audio_buffer.append")
            .SelectMany(item => Convert.FromBase64String(item.GetProperty("audio").GetString()))
            .ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(streamedInput, Is.EqualTo(inputAudio));
            Assert.That(sentEvents.Select(item => item.GetProperty("type").GetString()),
                Has.All.EqualTo("input_audio_buffer.append"));
            Assert.That(received, Has.Count.EqualTo(1));
        });
    }

    [TestCase("{\"type\":\"error\",\"error\":{\"message\":\"Invalid audio configuration\"}}", "Invalid audio configuration")]
    [TestCase("{\"type\":\"response.done\",\"response\":{\"status\":\"failed\",\"status_details\":{\"error\":{\"message\":\"Model unavailable\"}}}}", "Model unavailable")]
    [TestCase("{\"type\":\"response.done\",\"response\":{\"status\":\"incomplete\"}}", "incomplete")]
    public void SampleSurfacesRealtimeFailures(string payload, string expectedMessage)
    {
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame(payload, WebSocketMessageType.Text, endOfMessage: true));
        using VoiceAgentSession session = new(webSocket);
        using MemoryStream input = new();
        using MemoryStream output = new();

        InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await Sample_VoiceAgent.StreamAudioTurnAsync(session, input, output));

        Assert.That(exception.Message, Does.Contain(expectedMessage));
    }

    [Test]
    public void SampleRejectsPrematureSessionClosure()
    {
        TestWebSocket webSocket = new(TestWebSocket.Frame.Close());
        using VoiceAgentSession session = new(webSocket);
        using MemoryStream input = new();
        using MemoryStream output = new();

        InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await Sample_VoiceAgent.StreamAudioTurnAsync(session, input, output));

        Assert.That(exception.Message, Does.Contain("closed before the audio response completed"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SampleCapturesSessionConversationAndDrainsGreeting(bool hasGreeting)
    {
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame(
                "{\"type\":\"session.created\",\"conversation_id\":\"conv_session\",\"session\":{\"id\":\"session_123\"}}",
                WebSocketMessageType.Text,
                endOfMessage: true),
            new TestWebSocket.Frame(
                "{\"type\":\"response.done\",\"response\":{\"status\":\"completed\"}}",
                WebSocketMessageType.Text,
                endOfMessage: true));
        await using VoiceAgentSession session = new(webSocket);

        string conversationId = await Sample_VoiceAgent.WaitForSessionReadyAsync(session, hasGreeting);

        Assert.Multiple(() =>
        {
            Assert.That(conversationId, Is.EqualTo("conv_session"));
            Assert.That(webSocket.SentFrames, Is.Empty);
            Assert.That(webSocket.PendingFrameCount, Is.EqualTo(hasGreeting ? 0 : 1));
        });
    }

    [Test]
    public async Task SampleUsesSessionConversationWhenResponseOmitsIt()
    {
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame(
                "{\"type\":\"session.created\",\"conversation_id\":\"conv_session\"}",
                WebSocketMessageType.Text,
                endOfMessage: true),
            new TestWebSocket.Frame(
                "{\"type\":\"response.done\",\"response\":{\"status\":\"completed\"}}",
                WebSocketMessageType.Text,
                endOfMessage: true));
        await using VoiceAgentSession session = new(webSocket);
        using MemoryStream input = new();
        using MemoryStream output = new();

        string conversationId = await Sample_VoiceAgent.StreamAudioTurnAsync(session, input, output);

        Assert.That(conversationId, Is.EqualTo("conv_session"));
    }

    [Test]
    public async Task SendsRealtimeConvenienceEvents()
    {
        TestWebSocket webSocket = new();
        await using VoiceAgentSession session = new(webSocket);

        await session.ConfigureSessionAsync(BinaryData.FromObjectAsJson(new { type = "realtime", instructions = "Be concise." }));
        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new { type = "message", role = "user" }),
            previousItemId: "item-0");
        await session.RequestItemRetrievalAsync("item-1");
        await session.DeleteItemAsync("item-2");
        await session.TruncateItemAsync("item-3", contentIndex: 1, audioEndTime: TimeSpan.FromMilliseconds(1250));
        await session.StartResponseAsync(BinaryData.FromObjectAsJson(new { output_modalities = new[] { "audio" } }));
        await session.CancelResponseAsync();

        List<JsonElement> events = webSocket.SentFrames
            .Select(frame => JsonDocument.Parse(frame.Data).RootElement.Clone())
            .ToList();

        Assert.Multiple(() =>
        {
            Assert.That(events.Select(item => item.GetProperty("type").GetString()), Is.EqualTo(new[]
            {
                "session.update",
                "conversation.item.create",
                "conversation.item.retrieve",
                "conversation.item.delete",
                "conversation.item.truncate",
                "response.create",
                "response.cancel"
            }));
            Assert.That(events[0].GetProperty("session").GetProperty("instructions").GetString(), Is.EqualTo("Be concise."));
            Assert.That(events[0].GetProperty("session").GetProperty("type").GetString(), Is.EqualTo("realtime"));
            Assert.That(events[1].GetProperty("previous_item_id").GetString(), Is.EqualTo("item-0"));
            Assert.That(events[1].GetProperty("item").GetProperty("role").GetString(), Is.EqualTo("user"));
            Assert.That(events[4].GetProperty("content_index").GetInt32(), Is.EqualTo(1));
            Assert.That(events[4].GetProperty("audio_end_ms").GetInt64(), Is.EqualTo(1250));
            Assert.That(events[5].GetProperty("response").GetProperty("output_modalities")[0].GetString(), Is.EqualTo("audio"));
        });
    }

    [Test]
    public async Task SendsAvatarAndRtcCallEvents()
    {
        TestWebSocket webSocket = new();
        await using VoiceAgentSession session = new(webSocket);

        await session.ConnectAvatarAsync("client-sdp-offer");
        await session.CreateRtcCallSdpAsync("rtc-sdp-offer", BinaryData.FromObjectAsJson(new { model = "voice-model" }));

        List<JsonElement> events = webSocket.SentFrames
            .Select(frame => JsonDocument.Parse(frame.Data).RootElement.Clone())
            .ToList();

        Assert.Multiple(() =>
        {
            Assert.That(events.Select(item => item.GetProperty("type").GetString()), Is.EqualTo(new[]
            {
                "session.avatar.connect",
                "rtc.call.sdp.create"
            }));
            Assert.That(events[0].GetProperty("client_sdp").GetString(), Is.EqualTo("client-sdp-offer"));
            Assert.That(events[1].GetProperty("sdp_offer").GetString(), Is.EqualTo("rtc-sdp-offer"));
            Assert.That(events[1].GetProperty("session").GetProperty("model").GetString(), Is.EqualTo("voice-model"));
        });
    }

    [Test]
    public void ClientCommandsRejectMissingRequiredArguments()
    {
        Assert.Multiple(() =>
        {
            Assert.That(() => new VoiceAgentClientCommandSessionAvatarConnect(null), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => new VoiceAgentClientCommandRtcCallSdpCreate(null), Throws.TypeOf<ArgumentNullException>());
        });
    }

    [Test]
    public void ClientCommandsExposeTypedProperties()
    {
        VoiceAgentClientCommandSessionAvatarConnect avatarCommand = new("client-sdp-offer");
        VoiceAgentClientCommandRtcCallSdpCreate rtcCommand = new("rtc-sdp-offer", BinaryData.FromObjectAsJson(new { model = "voice-model" }));

        Assert.Multiple(() =>
        {
            Assert.That(avatarCommand.ClientSdp, Is.EqualTo("client-sdp-offer"));
            Assert.That(avatarCommand.Kind.ToString(), Is.EqualTo("session.avatar.connect"));
            Assert.That(rtcCommand.SdpOffer, Is.EqualTo("rtc-sdp-offer"));
            Assert.That(rtcCommand.Kind.ToString(), Is.EqualTo("rtc.call.sdp.create"));
        });
    }

    // Verifies gap #4's fix: a custom RealtimeServerUpdate subclass built on VoiceAgentServerUpdateBase<TSelf>
    // deserializes correctly via ModelReaderWriter.Read<T>, both for a type with typed properties
    // (VoiceAgentServerUpdateSessionAvatarConnecting) and one exposing only the universal EventId
    // (VoiceAgentServerUpdateSessionSubagentStarted), proving the base class works for any subclass.
    [Test]
    public void ServerUpdatesRoundTripTypedPropertiesFromRawJson()
    {
        BinaryData avatarJson = BinaryData.FromString(
            """{"type":"session.avatar.connecting","event_id":"evt-1","server_sdp":"server-sdp-answer"}""");
        BinaryData rtcJson = BinaryData.FromString(
            """{"type":"rtc.call.sdp.created","event_id":"evt-2","rtc_call_id":"call-1","sdp_answer":"rtc-sdp-answer"}""");
        BinaryData subagentJson = BinaryData.FromString(
            """{"type":"session.subagent.started","event_id":"evt-3"}""");

        VoiceAgentServerUpdateSessionAvatarConnecting avatarUpdate =
            ModelReaderWriter.Read<VoiceAgentServerUpdateSessionAvatarConnecting>(avatarJson, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        VoiceAgentServerUpdateRtcCallSdpCreated rtcUpdate =
            ModelReaderWriter.Read<VoiceAgentServerUpdateRtcCallSdpCreated>(rtcJson, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        VoiceAgentServerUpdateSessionSubagentStarted subagentUpdate =
            ModelReaderWriter.Read<VoiceAgentServerUpdateSessionSubagentStarted>(subagentJson, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.Multiple(() =>
        {
            Assert.That(avatarUpdate.Kind.ToString(), Is.EqualTo("session.avatar.connecting"));
            Assert.That(avatarUpdate.EventId, Is.EqualTo("evt-1"));
            Assert.That(avatarUpdate.ServerSdp, Is.EqualTo("server-sdp-answer"));
            Assert.That(rtcUpdate.EventId, Is.EqualTo("evt-2"));
            Assert.That(rtcUpdate.RtcCallId, Is.EqualTo("call-1"));
            Assert.That(rtcUpdate.SdpAnswer, Is.EqualTo("rtc-sdp-answer"));
            Assert.That(subagentUpdate.EventId, Is.EqualTo("evt-3"));
        });
    }

    // Verifies AsFoundryServerUpdate<T>(): the extension method a caller uses when they receive an
    // opaque, generic RealtimeServerUpdate (what OpenAI's own base client returns for an
    // unrecognized event kind, simulated here) and want to convert it to our typed subclass.
    [Test]
    public void AsFoundryServerUpdateConvertsGenericUpdateToTypedSubclass()
    {
        BinaryData json = BinaryData.FromString(
            """{"type":"session.avatar.connecting","event_id":"evt-9","server_sdp":"server-sdp-answer"}""");
        RealtimeServerUpdate genericUpdate = ModelReaderWriter.Read<RealtimeServerUpdate>(json, ModelReaderWriterOptions.Json, OpenAIContext.Default);

        VoiceAgentServerUpdateSessionAvatarConnecting typedUpdate = genericUpdate.AsFoundryServerUpdate<VoiceAgentServerUpdateSessionAvatarConnecting>();

        Assert.Multiple(() =>
        {
            Assert.That(typedUpdate.EventId, Is.EqualTo("evt-9"));
            Assert.That(typedUpdate.ServerSdp, Is.EqualTo("server-sdp-answer"));
        });
    }

    [Test]
    public void VoiceAgentSessionMessageAsConvertsToTypedServerUpdate()
    {
        VoiceAgentSessionMessage message = new(
            WebSocketMessageType.Text,
            BinaryData.FromString("""{"type":"rtc.call.sdp.created","event_id":"evt-7","rtc_call_id":"call-2","sdp_answer":"rtc-sdp-answer-2"}"""));

        VoiceAgentServerUpdateRtcCallSdpCreated typedUpdate = message.As<VoiceAgentServerUpdateRtcCallSdpCreated>();

        Assert.Multiple(() =>
        {
            Assert.That(message.EventType.ToString(), Is.EqualTo("rtc.call.sdp.created"));
            Assert.That(typedUpdate.EventId, Is.EqualTo("evt-7"));
            Assert.That(typedUpdate.RtcCallId, Is.EqualTo("call-2"));
            Assert.That(typedUpdate.SdpAnswer, Is.EqualTo("rtc-sdp-answer-2"));
        });
    }

    [Test]
    public void OpenAIStyleSessionAndSecretMembersAreNotSupported()
    {
        VoiceAgentWebSocket client = new(
            clientDiagnostics: new ClientDiagnostics(new AgentAdministrationClientOptions(), true),
            pipeline: ClientPipeline.Create(new AgentAdministrationClientOptions()),
            endpoint: new Uri("https://example.services.ai.azure.com/api/projects/my-project"),
            apiVersion: "v1",
            tokenProvider: null);

        Assert.Multiple(() =>
        {
            Assert.That(() => client.StartSession("model", "intent"), Throws.TypeOf<NotSupportedException>());
            Assert.That(() => client.StartSessionAsync("model", "intent"), Throws.TypeOf<NotSupportedException>());
            Assert.That(() => client.CreateRealtimeClientSecret(BinaryContent.Create(BinaryData.FromString("{}")), null), Throws.TypeOf<NotSupportedException>());
            Assert.That(() => client.CreateRealtimeClientSecretAsync(BinaryContent.Create(BinaryData.FromString("{}")), null), Throws.TypeOf<NotSupportedException>());
            Assert.That(() => client.CreateRealtimeClientSecret(new CreateClientSecretOptions()), Throws.TypeOf<NotSupportedException>());
            Assert.That(() => client.CreateRealtimeClientSecretAsync(new CreateClientSecretOptions()), Throws.TypeOf<NotSupportedException>());
        });
    }

    [Test]
    public async Task RaisesCommandHooksAndParsesEventTypes()
    {
        VoiceAgentWebSocket client = new(
            clientDiagnostics: new ClientDiagnostics(new AgentAdministrationClientOptions(), true),
            pipeline: ClientPipeline.Create(new AgentAdministrationClientOptions()),
            endpoint: new Uri("https://example.services.ai.azure.com/api/projects/my-project"),
            apiVersion: "v1",
            tokenProvider: null);
        List<BinaryData> sent = new();
        List<BinaryData> received = new();
        client.OnSendingCommand += (_, data) => sent.Add(data);
        client.OnReceivingCommand += (_, data) => received.Add(data);

        TestWebSocket webSocket = new(
            new TestWebSocket.Frame("{\"type\":\"response.done\"}", WebSocketMessageType.Text, endOfMessage: true),
            TestWebSocket.Frame.Close());
        await using VoiceAgentSession session = new(webSocket, client);
        await session.StartResponseAsync();

        List<VoiceAgentSessionMessage> messages = new();
        await foreach (VoiceAgentSessionMessage message in session.ReceiveUpdatesAsync())
        {
            messages.Add(message);
        }

        VoiceAgentSessionMessage invalidJson = new(
            WebSocketMessageType.Text,
            BinaryData.FromString("not-json"));
        VoiceAgentSessionMessage binary = new(
            WebSocketMessageType.Binary,
            BinaryData.FromBytes(new byte[] { 1 }));

        Assert.Multiple(() =>
        {
            Assert.That(sent, Has.Count.EqualTo(1));
            Assert.That(JsonDocument.Parse(sent[0]).RootElement.GetProperty("type").GetString(), Is.EqualTo("response.create"));
            Assert.That(received, Has.Count.EqualTo(1));
            Assert.That(received[0].ToString(), Is.EqualTo("{\"type\":\"response.done\"}"));
            Assert.That(messages, Has.Count.EqualTo(1));
            Assert.That(messages[0].EventType, Is.EqualTo(RealtimeServerEventType.ResponseDone));
            Assert.That(invalidJson.EventType, Is.Null);
            Assert.That(binary.EventType, Is.Null);
        });
    }

    private sealed class TestWebSocket : WebSocket
    {
        private readonly Queue<Frame> _receivedFrames;
        private WebSocketCloseStatus? _closeStatus;
        private string _closeStatusDescription;
        private WebSocketState _state = WebSocketState.Open;

        internal TestWebSocket(params Frame[] receivedFrames)
        {
            _receivedFrames = new Queue<Frame>(receivedFrames);
        }

        internal List<SentFrame> SentFrames { get; } = new();
        internal int PendingFrameCount => _receivedFrames.Count;

        public override WebSocketCloseStatus? CloseStatus => _closeStatus;
        public override string CloseStatusDescription => _closeStatusDescription;
        public override WebSocketState State => _state;
        public override string SubProtocol => "realtime";

        public override void Abort() => _state = WebSocketState.Aborted;

        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            _closeStatus = closeStatus;
            _closeStatusDescription = statusDescription;
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
            => CloseAsync(closeStatus, statusDescription, cancellationToken);

        public override void Dispose() => _state = WebSocketState.Closed;

        public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            Frame frame = _receivedFrames.Dequeue();
            if (frame.MessageType == WebSocketMessageType.Close)
            {
                _state = WebSocketState.CloseReceived;
                // OpenAI.Realtime's receive loop (which VoiceAgentSession now delegates to) detects the end of
                // the stream via CloseStatus.HasValue, not MessageType, so a real close status is required here.
                return Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true, WebSocketCloseStatus.NormalClosure, null));
            }

            Array.Copy(frame.Data, 0, buffer.Array, buffer.Offset, frame.Data.Length);
            return Task.FromResult(new WebSocketReceiveResult(frame.Data.Length, frame.MessageType, frame.EndOfMessage));
        }

        public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            byte[] data = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, data, 0, buffer.Count);
            SentFrames.Add(new SentFrame(messageType, data));
            return Task.CompletedTask;
        }

        internal sealed class Frame
        {
            internal Frame(string data, WebSocketMessageType messageType, bool endOfMessage)
                : this(Encoding.UTF8.GetBytes(data), messageType, endOfMessage)
            {
            }

            private Frame(byte[] data, WebSocketMessageType messageType, bool endOfMessage)
            {
                Data = data;
                MessageType = messageType;
                EndOfMessage = endOfMessage;
            }

            internal byte[] Data { get; }
            internal WebSocketMessageType MessageType { get; }
            internal bool EndOfMessage { get; }

            internal static Frame Close() => new(Array.Empty<byte>(), WebSocketMessageType.Close, true);
        }

        internal sealed class SentFrame
        {
            internal SentFrame(WebSocketMessageType messageType, byte[] data)
            {
                MessageType = messageType;
                Data = data;
            }

            internal WebSocketMessageType MessageType { get; }
            internal byte[] Data { get; }
        }
    }
}
