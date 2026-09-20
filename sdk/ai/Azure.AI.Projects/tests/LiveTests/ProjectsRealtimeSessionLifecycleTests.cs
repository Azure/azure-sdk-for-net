// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE session lifecycle tests for Voice Agent realtime streaming -- mirrors the pattern used by
// sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/LifecycleTests.cs, adapted to
// ProjectsRealtimeSessionClient's realtime protocol surface. Covers response cancel, conversation
// item delete, and input audio buffer clear.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.LiveTests;

public class ProjectsRealtimeSessionLifecycleTests : ProjectsRealtimeLiveTestBase
{
    public ProjectsRealtimeSessionLifecycleTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<ProjectsRealtimeSessionClient> StartLifecycleSessionAsync(AIProjectClient client, CancellationToken cancellationToken)
    {
        Azure.AI.Projects.Agents.AgentAdministrationClient agentsClient = client.AgentAdministrationClient;
        try
        {
            await agentsClient.GetAgentAsync(LIFECYCLE_AGENT_NAME, cancellationToken);
        }
        catch
        {
            Azure.AI.Projects.Agents.VoiceAgentDefinition definition = new()
            {
                ModelType = Azure.AI.Projects.Agents.VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "You are a helpful assistant. Always answer with a very long, detailed reply.",
            };
            definition.OutputModalities.Add(Azure.AI.Projects.Agents.VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                LIFECYCLE_AGENT_NAME,
                new Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }

        return (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(LIFECYCLE_AGENT_NAME, intent: null, cancellationToken: cancellationToken);
    }

    // -----------------------------------------------------------------------
    // Verifies: cancelling an in-progress response results in a response.done
    // event with status = cancelled.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task ResponseCancelResultsInCancelledStatus()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        using ProjectsRealtimeSessionClient session = await StartLifecycleSessionAsync(client, timeout.Token);

        await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Tell me a very long story about the ocean."), timeout.Token);
        await session.StartResponseAsync(timeout.Token);

        bool cancelSent = false;
        RealtimeResponseStatus? status = null;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            Console.WriteLine($"[event] {update.Kind}");
            if (!cancelSent && update is RealtimeServerUpdateResponseCreated)
            {
                await session.CancelResponseAsync(timeout.Token);
                cancelSent = true;
            }
            else if (update is RealtimeServerUpdateResponseDone doneUpdate)
            {
                status = doneUpdate.Response.Status;
                break;
            }
        }

        Console.WriteLine($"Final response status: {status}");
        Assert.That(status, Is.EqualTo(RealtimeResponseStatus.Cancelled), "A cancelled response must report status = cancelled.");
    }

    // -----------------------------------------------------------------------
    // Verifies: deleting a conversation item produces a conversation.item.deleted
    // event with the matching item ID.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task ConversationItemDeleteProducesDeletedEvent()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        using ProjectsRealtimeSessionClient session = await StartLifecycleSessionAsync(client, timeout.Token);

        await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("This item will be deleted."), timeout.Token);

        string itemId = null;
        string deletedItemId = null;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            Console.WriteLine($"[event] {update.Kind}");
            if (itemId is null && update is RealtimeServerUpdateConversationItemCreated createdUpdate && createdUpdate.Item is RealtimeMessageItem messageItem)
            {
                itemId = messageItem.Id;
                await session.DeleteItemAsync(itemId, timeout.Token);
            }
            else if (update is RealtimeServerUpdateConversationItemDeleted deletedUpdate)
            {
                deletedItemId = deletedUpdate.ItemId;
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
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        using ProjectsRealtimeSessionClient session = await StartLifecycleSessionAsync(client, timeout.Token);

        // 100 ms of silence at 24 kHz, 16-bit PCM.
        byte[] silenceChunk = new byte[24000 * sizeof(short) / 10];
        await session.SendInputAudioAsync(BinaryData.FromBytes(silenceChunk), timeout.Token);
        await session.SendInputAudioAsync(BinaryData.FromBytes(silenceChunk), timeout.Token);
        await session.ClearInputAudioAsync(timeout.Token);

        bool cleared = false;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            Console.WriteLine($"[event] {update.Kind}");
            if (update is RealtimeServerUpdateInputAudioBufferCleared)
            {
                cleared = true;
                break;
            }
        }

        Assert.That(cleared, Is.True, "Expected input_audio_buffer.cleared event after ClearInputAudioAsync.");
    }
}
