// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE conversation/response lifecycle tests — mirrors test_live_realtime_lifecycle.py
// (Python PR #47299). Covers response cancel, conversation item delete, and input
// audio buffer clear operations.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class LifecycleTests : VoiceLiveTestBase
    {
        public LifecycleTests() : base(true) { }
        public LifecycleTests(bool isAsync) : base(isAsync) { }

        // -----------------------------------------------------------------------
        // Mirrors: test_realtime_service_response_cancel
        // Verifies: cancelling an in-progress response results in a response.done
        // event with status = Cancelled.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task ResponseCancelResultsInCancelledStatus()
        {
            var client = GetLiveClient();

            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
                Instructions = "You are a helpful assistant. Always answer with a very long, detailed reply.",
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);
            options.Modalities.Add(InteractionModality.Audio);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            // Seed a user message so the model has something to respond to.
            await session.AddItemAsync(
                new UserMessageItem(new InputTextContentPart("Tell me a very long story about the ocean.")),
                TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            // Wait until the response is actually in progress, then cancel it.
            await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            await session.CancelResponseAsync(TimeoutToken).ConfigureAwait(false);

            // Drain until response.done.
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            var done = SafeCast<SessionUpdateResponseDone>(responseItems[responseItems.Count - 1]);

            Assert.AreEqual(SessionResponseStatus.Cancelled, done.Response.Status,
                "Cancelled response must have status = Cancelled");
        }

        // -----------------------------------------------------------------------
        // Mirrors: test_realtime_service_conversation_item_delete
        // Verifies: deleting a conversation item produces a conversation.item.deleted
        // event with the matching item ID.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task ConversationItemDeleteProducesDeletedEvent()
        {
            var client = GetLiveClient();

            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
                Instructions = "You are a helpful assistant.",
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            // Create a conversation item.
            await session.AddItemAsync(
                new UserMessageItem(new InputTextContentPart("This item will be deleted.")),
                TimeoutToken).ConfigureAwait(false);
            var created = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var itemId = created.Item.Id;

            // Delete it and verify the server acknowledges.
            await session.DeleteItemAsync(itemId, TimeoutToken).ConfigureAwait(false);
            var deleted = await GetNextUpdate<SessionUpdateConversationItemDeleted>(updatesEnum).ConfigureAwait(false);

            Assert.AreEqual(itemId, deleted.ItemId,
                "Deleted event must reference the same item ID that was deleted");
        }

        // -----------------------------------------------------------------------
        // Mirrors: test_realtime_service_input_audio_buffer_clear
        // Verifies: clearing the input audio buffer produces an
        // input_audio_buffer.cleared event.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task InputAudioBufferClearProducesClearedEvent()
        {
            var client = GetLiveClient();

            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
                InputAudioFormat = InputAudioFormat.Pcm16,
                // Disable VAD so the buffer is not auto-committed before we clear it.
                TurnDetection = new NoTurnDetection(),
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);
            options.Modalities.Add(InteractionModality.Audio);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            // Send some audio into the buffer.
            var silenceChunk = new byte[3200]; // 100 ms of silence at 16 kHz PCM16
            await session.SendInputAudioAsync(silenceChunk, TimeoutToken).ConfigureAwait(false);
            await session.SendInputAudioAsync(silenceChunk, TimeoutToken).ConfigureAwait(false);

            // Clear the buffer and verify the server acknowledges.
            await session.ClearInputAudioAsync(TimeoutToken).ConfigureAwait(false);
            var cleared = await GetNextUpdate<SessionUpdateInputAudioBufferCleared>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(cleared, "Expected input_audio_buffer.cleared event after ClearInputAudioAsync");
        }
    }
}
