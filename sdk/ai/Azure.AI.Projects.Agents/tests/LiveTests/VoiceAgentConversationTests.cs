// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE basic conversation tests for Voice Agent WebSocket streaming — mirrors the pattern used
// by sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/BasicConversationTests.cs, adapted to
// VoiceAgentSession's realtime protocol surface. Covers a simple text turn and the interop
// between a persisted realtime session and the AgentEndpointConversations REST surface.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Agents.Tests.LiveTests;

public class VoiceAgentConversationTests : VoiceAgentLiveTestBase
{
    public VoiceAgentConversationTests(bool isAsync) : base(isAsync)
    {
    }

    /// <summary>
    /// Builds a PCM audio format at the given sample rate. <see cref="RealtimePcmAudioFormat.Rate"/> is
    /// read-only in the current OpenAI SDK "patch model" shape, so the rate must be set through the
    /// underlying <see cref="System.ClientModel.Primitives.JsonPatch"/> instead of an object initializer.
    /// </summary>
    private static RealtimePcmAudioFormat CreatePcmAudioFormat(int rate)
    {
        RealtimePcmAudioFormat format = new();
        format.Patch.Set("$.rate"u8, rate);
        return format;
    }

    private async Task EnsureConversationAgentAsync(AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(CONVERSATION_AGENT_NAME, cancellationToken);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                CONVERSATION_AGENT_NAME,
                new ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }
    }

    private async Task EnsureAudioConversationAgentAsync(AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(AUDIO_CONVERSATION_AGENT_NAME, cancellationToken);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
                Audio = new VoiceAgentAudioConfig
                {
                    Input = new VoiceAgentAudioInputConfig
                    {
                        Format = CreatePcmAudioFormat(24000),
                    },
                },
            };
            definition.OutputModalities.Add(VoiceOutputModality.Audio);
            await agentsClient.CreateAgentVersionAsync(
                AUDIO_CONVERSATION_AGENT_NAME,
                new ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }
    }

    // -----------------------------------------------------------------------
    // Verifies: a simple text-only turn produces a completed text response.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task TextConversationProducesTextResponse()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureConversationAgentAsync(agentsClient, timeout.Token);

        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
        await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
            CONVERSATION_AGENT_NAME,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "Say hello in one short sentence." } }
            }),
            cancellationToken: timeout.Token);
        await session.StartResponseAsync(cancellationToken: timeout.Token);

        string responseText = string.Empty;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            if (update.EventType == RealtimeServerEventType.ResponseOutputTextDone)
            {
                using JsonDocument document = JsonDocument.Parse(update.Data);
                responseText = document.RootElement.GetProperty("text").GetString();
            }
            else if (update.EventType == RealtimeServerEventType.ResponseDone)
            {
                break;
            }
        }

        Assert.That(responseText, Is.Not.Null.And.Not.Empty, "Expected a non-empty text response.");
    }

    // -----------------------------------------------------------------------
    // Verifies: a session started with Store = true produces a conversation
    // that becomes retrievable through the AgentEndpointConversations REST
    // surface once the session closes.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task PersistedConversationIsRetrievableAfterSession()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureConversationAgentAsync(agentsClient, timeout.Token);

        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
        string conversationId;
        await using (VoiceAgentSession session = await realtimeClient.StartSessionAsync(
            CONVERSATION_AGENT_NAME,
            new VoiceAgentConnectionOptions { Store = true },
            timeout.Token))
        {
            await session.AddItemAsync(
                BinaryData.FromObjectAsJson(new
                {
                    type = "message",
                    role = "user",
                    content = new[] { new { type = "input_text", text = "Say hello in one short sentence." } }
                }),
                cancellationToken: timeout.Token);
            await session.StartResponseAsync(cancellationToken: timeout.Token);

            conversationId = null;
            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                if (update.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }

                if (update.EventType == RealtimeServerEventType.ResponseDone)
                {
                    using JsonDocument document = JsonDocument.Parse(update.Data);
                    conversationId = document.RootElement.GetProperty("response").GetProperty("conversation_id").GetString();
                    break;
                }
            }
            await session.CloseAsync(timeout.Token);
        }

        Assert.That(conversationId, Is.Not.Null.And.Not.Empty, "Expected the response.done event to report a conversation ID when Store = true.");

        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
        VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(
            CONVERSATION_AGENT_NAME,
            conversationId,
            timeout.Token);
        Assert.That(conversation.Id, Is.EqualTo(conversationId));

        bool listed = await conversationsClient
            .GetAgentConversationsAsync(CONVERSATION_AGENT_NAME, cancellationToken: timeout.Token)
            .AnyAsync(c => c.Id == conversationId);
        Assert.That(listed, Is.True, "The persisted conversation must appear when listing the agent's conversations.");

        List<RealtimeItem> items = await conversationsClient
            .GetAgentConversationItemsAsync(CONVERSATION_AGENT_NAME, conversationId, cancellationToken: timeout.Token)
            .ToListAsync();
        Assert.That(items, Is.Not.Empty, "Expected at least one persisted conversation item.");

        List<VoiceResponse> responses = await conversationsClient
            .GetAgentConversationResponsesAsync(CONVERSATION_AGENT_NAME, conversationId, cancellationToken: timeout.Token)
            .ToListAsync();
        Assert.That(responses, Is.Not.Empty, "Expected at least one persisted response.");
    }

    // -----------------------------------------------------------------------
    // Verifies: an audio-modality turn streams input PCM audio and produces a
    // non-empty accumulated audio response.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task AudioConversationProducesAudioResponse()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureAudioConversationAgentAsync(agentsClient, timeout.Token);

        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
        await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
            AUDIO_CONVERSATION_AGENT_NAME,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "Say hello in one short sentence." } }
            }),
            cancellationToken: timeout.Token);

        // 100 ms of silence at 24 kHz, 16-bit PCM, exercising the audio-input path.
        byte[] silenceChunk = new byte[24000 * sizeof(short) / 10];
        await session.SendInputAudioAsync(BinaryData.FromBytes(silenceChunk), timeout.Token);
        await session.StartResponseAsync(cancellationToken: timeout.Token);

        using MemoryStream responseAudio = new();
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            if (update.EventType == RealtimeServerEventType.ResponseOutputAudioDelta)
            {
                using JsonDocument document = JsonDocument.Parse(update.Data);
                byte[] audioChunk = Convert.FromBase64String(document.RootElement.GetProperty("delta").GetString());
                await responseAudio.WriteAsync(audioChunk, 0, audioChunk.Length, timeout.Token);
            }
            else if (update.EventType == RealtimeServerEventType.ResponseDone)
            {
                break;
            }
        }

        Assert.That(responseAudio.Length, Is.GreaterThan(0), "Expected a non-empty audio response.");
    }
}
