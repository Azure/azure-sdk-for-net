// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// US7 (FR-060/061): conversation-chain metadata written and flushed by a resilient handler must be
/// durable — persisted into the Core task record so it survives into later turns / recovery. On the
/// resilient path the metadata facade is backed by the Core <c>TaskMetadata</c> checkpoint store
/// (mirroring Python's <c>_DeveloperMetadataFacade</c> over <c>TaskMetadata</c>); this test proves the
/// flush actually persists by reading it back from a second turn of the same conversation whose Core
/// task metadata is hydrated from the record.
/// </summary>
public class TestConversationChainMetadataDurabilityTests
{
    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

    private static async Task<JsonDocument> ParseAsync(HttpResponseMessage response)
        => JsonDocument.Parse(await response.Content.ReadAsStringAsync());

    [Test]
    public async Task FlushedChainMetadata_IsDurable_AndVisibleToNextTurn()
    {
        var root = Path.Combine(Path.GetTempPath(), "md-durable-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        int invocationCount = 0;
        var handler = new TestHandler
        {
            EventFactory = (request, context, ct) =>
                DriveAsync(request, context, () => Interlocked.Increment(ref invocationCount), ct),
        };

        try
        {
            using var factory = new TestWebApplicationFactory(
                handler,
                configureOptions: o =>
                {
                    o.SteerableConversations = true;
                    o.ResilientBackground = true;
                },
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                    services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
                });
            using var client = factory.CreateClient();

            // Turn 1: writes chain metadata and flushes it durably, then completes.
            var turn1 = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, conversation = "conv-md" }));
            Assert.That(turn1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string turn1Id;
            using (var doc1 = await ParseAsync(turn1))
            {
                turn1Id = doc1.RootElement.GetProperty("id").GetString()!;
            }

            await WaitForStatusAsync(client, turn1Id, "completed", TimeSpan.FromSeconds(15));

            // Turn 2 on the same conversation chain: its handler throws unless it can read back the
            // metadata turn 1 flushed. A durable flush → turn 2 completes; a no-op flush → turn 2 fails.
            // Turn 1 is already "completed", but the Core multi-turn task may still hold the chain lock
            // for a moment while it suspends — poll-retry until it is released to avoid a transient 409.
            var turn2 = await PostTurnAwaitingLockReleaseAsync(
                client,
                "/responses",
                () => Json(new { model = "test", background = true, conversation = "conv-md", previous_response_id = turn1Id }),
                TimeSpan.FromSeconds(15));
            Assert.That(turn2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string turn2Id;
            using (var doc2 = await ParseAsync(turn2))
            {
                turn2Id = doc2.RootElement.GetProperty("id").GetString()!;
            }

            await WaitForStatusAsync(client, turn2Id, "completed", TimeSpan.FromSeconds(15));
        }
        finally
        {
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DriveAsync(
        CreateResponse request,
        ResponseContext context,
        Func<int> nextTurn,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);

        if (nextTurn() == 1)
        {
            context.MetadataNamespace("agent").Set("phase", "analyze");
            await context.MetadataNamespace("agent").FlushAsync(ct);
        }
        else
        {
            if (!context.MetadataNamespace("agent").TryGet("phase", out var value) || value != "analyze")
            {
                throw new InvalidOperationException(
                    "Durable conversation-chain metadata flushed on turn 1 was not visible on turn 2 — flush did not persist.");
            }
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        string? last = null;
        while (DateTime.UtcNow < deadline)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await ParseAsync(get);
                last = doc.RootElement.GetProperty("status").GetString();
                if (last is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    Assert.That(last, Is.EqualTo(expected), $"Response '{responseId}' terminal status.");
                    return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response '{responseId}' did not reach a terminal state within {timeout} (last status: {last ?? "none"}).");
    }

    // Serial multi-turn turns are serialized by Core's conversation lock. A turn's response record
    // flips to "completed" a moment before the Core multi-turn task suspends and releases that lock,
    // so a follow-up turn POSTed in that window can be (correctly) rejected with 409 conversation_locked.
    // Poll-retry the follow-up turn until the lock is released, bridging the completed→suspended gap
    // deterministically (a bounded poll loop, not a fixed delay). A fresh request body is built per
    // attempt because HttpContent is single-use.
    private static async Task<HttpResponseMessage> PostTurnAwaitingLockReleaseAsync(
        HttpClient client, string url, Func<HttpContent> body, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (true)
        {
            var response = await client.PostAsync(url, body());
            if (response.StatusCode != HttpStatusCode.Conflict || DateTime.UtcNow >= deadline)
            {
                return response;
            }

            response.Dispose();
            await Task.Delay(50);
        }
    }
}
