// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE session lifecycle tests for Voice Agent WebSocket streaming — mirrors the pattern used
// by sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/LifecycleTests.cs, adapted to
// VoiceAgentSession's realtime protocol surface. Covers response cancel, conversation item
// delete, and input audio buffer clear.

using System;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.LiveTests;

public class VoiceAgentSessionLifecycleTests : VoiceAgentLiveTestBase
{
    public VoiceAgentSessionLifecycleTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<VoiceAgentSession> StartLifecycleSessionAsync(AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(LIFECYCLE_AGENT_NAME, cancellationToken);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "You are a helpful assistant. Always answer with a very long, detailed reply.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                LIFECYCLE_AGENT_NAME,
                new ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }

        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
        return await realtimeClient.StartSessionAsync(LIFECYCLE_AGENT_NAME, cancellationToken: cancellationToken);
    }

    // -----------------------------------------------------------------------
    // Verifies: cancelling an in-progress response results in a response.done
    // event with status = "cancelled".
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task ResponseCancelResultsInCancelledStatus()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await using VoiceAgentSession session = await StartLifecycleSessionAsync(agentsClient, timeout.Token);

        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "Tell me a very long story about the ocean." } }
            }),
            cancellationToken: timeout.Token);
        await session.StartResponseAsync(cancellationToken: timeout.Token);

        bool cancelSent = false;
        string status = null;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            if (!cancelSent && update.EventType == RealtimeServerEventType.ResponseCreated)
            {
                await session.CancelResponseAsync(timeout.Token);
                cancelSent = true;
            }
            else if (update.EventType == RealtimeServerEventType.ResponseDone)
            {
                using JsonDocument document = JsonDocument.Parse(update.Data);
                status = document.RootElement.GetProperty("response").GetProperty("status").GetString();
                break;
            }
        }

        Assert.That(status, Is.EqualTo("cancelled"), "A cancelled response must report status = cancelled.");
    }

    // -----------------------------------------------------------------------
    // Verifies: deleting a conversation item produces a conversation.item.deleted
    // event with the matching item ID.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task ConversationItemDeleteProducesDeletedEvent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await using VoiceAgentSession session = await StartLifecycleSessionAsync(agentsClient, timeout.Token);

        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "This item will be deleted." } }
            }),
            cancellationToken: timeout.Token);

        string itemId = null;
        string deletedItemId = null;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            using JsonDocument document = JsonDocument.Parse(update.Data);
            if (itemId is null && update.EventType == RealtimeServerEventType.ConversationItemCreated)
            {
                itemId = document.RootElement.GetProperty("item").GetProperty("id").GetString();
                await session.DeleteItemAsync(itemId, timeout.Token);
            }
            else if (update.EventType == RealtimeServerEventType.ConversationItemDeleted)
            {
                deletedItemId = document.RootElement.GetProperty("item_id").GetString();
                break;
            }
        }

        Assert.That(itemId, Is.Not.Null.And.Not.Empty);
        Assert.That(deletedItemId, Is.EqualTo(itemId),
            "The deleted event must reference the same item ID that was deleted.");
    }

    // -----------------------------------------------------------------------
    // Verifies: clearing the input audio buffer produces an
    // input_audio_buffer.cleared event.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task InputAudioBufferClearProducesClearedEvent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await using VoiceAgentSession session = await StartLifecycleSessionAsync(agentsClient, timeout.Token);

        // 100 ms of silence at 24 kHz, 16-bit PCM.
        byte[] silenceChunk = new byte[24000 * sizeof(short) / 10];
        await session.SendInputAudioAsync(BinaryData.FromBytes(silenceChunk), timeout.Token);
        await session.SendInputAudioAsync(BinaryData.FromBytes(silenceChunk), timeout.Token);
        await session.ClearInputAudioAsync(timeout.Token);

        bool cleared = false;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.EventType == RealtimeServerEventType.InputAudioBufferCleared)
            {
                cleared = true;
                break;
            }
        }

        Assert.That(cleared, Is.True, "Expected input_audio_buffer.cleared event after ClearInputAudioAsync.");
    }
}
