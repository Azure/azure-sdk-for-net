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
/// US5 / CC-RE4 steering contract: conversation turns route through the Core steerable multi-turn
/// task, so Core owns steering (queue, fork/lock preconditions, pending-input accounting) and the
/// Responses layer only performs dispatch selection plus the Core-exception → HTTP-409 mapping.
///
/// The dispatch-selection and exception-mapping surface is verified deterministically with a fake
/// <see cref="ITaskInvoker"/> (no timing gates); one end-to-end test then proves the composition is
/// wired to the real Core engine (real steering enqueue + drain).
/// </summary>
public class TestSteerableConversationContractTests
{
    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

    private static async Task<JsonDocument> ParseAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(body);
    }

    // ---- Deterministic dispatch-selection + exception-mapping (fake invoker) ----

    [Test]
    public async Task SteeredTurn_QueuedBehindActiveTurn_ReturnsQueuedEnvelope()
    {
        var invoker = new FakeTaskInvoker { NextIsQueued = true };
        using var factory = NewFactory(
            invoker,
            o =>
            {
                o.SteerableConversations = true;
                o.ResilientBackground = true;
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true, conversation = "conv-queue" }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("queued"));

        // The conversation routes through the multi-turn (steering) task keyed by the chain id, with
        // the response id as the per-turn input id.
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.MultiTurnTaskName));
        Assert.That(invoker.LastOptions!.TaskId, Is.Not.Null.And.Not.Empty);
        Assert.That(invoker.LastOptions!.InputId, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task StaleAntecedent_MapsToConversationForkNotSupported409()
    {
        // A fork references a valid past turn that is no longer the most recent turn of the chain.
        // History validation must succeed (the antecedent exists), so the request reaches dispatch,
        // where Core rejects the non-extending turn with a last-input-id precondition failure.
        var root = Path.Combine(Path.GetTempPath(), "steer-fork-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        string antecedentId = Azure.AI.AgentServer.Responses.IdGenerator.NewResponseId();
        var seedProvider = new FileResponsesProvider(responsesDir);
        var antecedent = new ResponseObject(antecedentId, "test-model");
        antecedent.SetCompleted();
        await seedProvider.CreateResponseAsync(
            new CreateResponseRequest(antecedent, null, null), PlatformContext.Empty);

        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new LastInputIdPreconditionFailedException("resp-latest"),
        };

        try
        {
            using var factory = new TestWebApplicationFactory(
                configureOptions: o =>
                {
                    o.SteerableConversations = true;
                    o.ResilientBackground = true;
                },
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskInvoker>(invoker);
                    services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                    services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
                });
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                "/responses",
                Json(new
                {
                    model = "test",
                    background = true,
                    conversation = "conv-fork",
                    previous_response_id = antecedentId,
                }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
            using var doc = await ParseAsync(response);
            var error = doc.RootElement.GetProperty("error");
            Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("conversation_fork_not_supported"));
            Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("conflict"));
            Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("previous_response_id"));

            // A supplied previous_response_id becomes the ifLastInputId fork precondition.
            Assert.That(invoker.LastOptions!.IfLastInputId, Is.EqualTo(antecedentId));
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

    [Test]
    public async Task ConcurrentTurn_NonSteerable_MapsToConversationLocked409()
    {
        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new TaskConflictException(Azure.AI.AgentServer.Core.Tasks.TaskStatus.InProgress),
        };
        using var factory = NewFactory(
            invoker,
            o =>
            {
                // Non-steerable conversation, but resilient-background still routes a conversation
                // through the multi-turn task (registered non-steerable) so a concurrent turn is a
                // lock conflict rather than a steering enqueue.
                o.SteerableConversations = false;
                o.ResilientBackground = true;
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true, conversation = "conv-lock" }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        using var doc = await ParseAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("conversation_locked"));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("conflict"));
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.MultiTurnTaskName));
    }

    [Test]
    public async Task ConcurrentTurn_DefaultOptions_MapsToConversationLocked409()
    {
        // Gap A (US5 acceptance scenario 4, FR-051): a conversation_id chain MUST get concurrency
        // protection even with DEFAULT options (ResilientBackground=false, SteerableConversations=false).
        // Parity with Python `_pick_primitive`: any conversation_id routes through the multi-turn task
        // (registered non-steerable here), so a concurrent turn overlapping the active turn is a Core
        // lock conflict → HTTP 409 conversation_locked — independent of both feature options.
        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new TaskConflictException(Azure.AI.AgentServer.Core.Tasks.TaskStatus.InProgress),
        };
        using var factory = NewFactory(
            invoker,
            _ =>
            {
                // DEFAULT options — deliberately set neither flag.
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true, conversation = "conv-lock" }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        using var doc = await ParseAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("conversation_locked"));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("conflict"));
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.MultiTurnTaskName));
    }

    [Test]
    public async Task ForegroundConcurrentTurn_DefaultOptions_MapsToConversationLocked409()
    {
        // Finding D (FR-052 concurrent-overlap lock): a FOREGROUND (background=false) conversation turn
        // must route through the multi-turn task too (parity with Python `_pick_primitive`, which is
        // NOT background-gated). A concurrent turn overlapping the active turn is a Core lock conflict
        // → HTTP 409 conversation_locked, even with DEFAULT options.
        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new TaskConflictException(Azure.AI.AgentServer.Core.Tasks.TaskStatus.InProgress),
        };
        using var factory = NewFactory(
            invoker,
            _ =>
            {
                // DEFAULT options — deliberately set neither flag.
            });
        using var client = factory.CreateClient();

        // No background field → foreground.
        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", conversation = "conv-fg-lock" }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        using var doc = await ParseAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("conversation_locked"));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("conflict"));
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.MultiTurnTaskName));
    }

    [Test]
    public async Task ForegroundForkTurn_DefaultOptions_MapsToConversationForkNotSupported409()
    {
        // Finding D (FR-051 fork rejection): a FOREGROUND fork (previous_response_id not the chain head)
        // must be rejected with HTTP 409 conversation_fork_not_supported — the same as background,
        // regardless of background gating.
        var root = Path.Combine(Path.GetTempPath(), "steer-fg-fork-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        string antecedentId = Azure.AI.AgentServer.Responses.IdGenerator.NewResponseId();
        var seedProvider = new FileResponsesProvider(responsesDir);
        var antecedent = new ResponseObject(antecedentId, "test-model");
        antecedent.SetCompleted();
        await seedProvider.CreateResponseAsync(
            new CreateResponseRequest(antecedent, null, null), PlatformContext.Empty);

        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new LastInputIdPreconditionFailedException("resp-latest"),
        };

        try
        {
            using var factory = new TestWebApplicationFactory(
                configureOptions: _ =>
                {
                    // DEFAULT options — foreground fork rejection is not gated on either flag.
                },
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskInvoker>(invoker);
                    services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                    services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
                });
            using var client = factory.CreateClient();

            // No background field → foreground.
            var response = await client.PostAsync(
                "/responses",
                Json(new
                {
                    model = "test",
                    conversation = "conv-fg-fork",
                    previous_response_id = antecedentId,
                }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
            using var doc = await ParseAsync(response);
            var error = doc.RootElement.GetProperty("error");
            Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("conversation_fork_not_supported"));
            Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("conflict"));
            Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("previous_response_id"));
            Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.MultiTurnTaskName));
            Assert.That(invoker.LastOptions!.IfLastInputId, Is.EqualTo(antecedentId));
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

    [Test]
    public async Task StoredBackgroundTurn_DefaultOptions_RoutesToOneShotTaskWithMarkFailedDisposition()
    {
        // Gap B (FR-012 Row 2, FR-013): a stored, background, NON-resilient response (default options)
        // must be tracked by a Core one-shot task so a next-lifetime crash-recovery scan marks it failed
        // (disposition=mark-failed). Parity assertion: the task input payload carries the mark-failed
        // disposition (DecideDisposition(store:true, background:true, resilientBackground:false)). The
        // fake short-circuits via IsQueued only to observe the dispatch decision without running the
        // handler (store defaults to true; no conversation → one-shot, not multi-turn).
        var invoker = new FakeTaskInvoker { NextIsQueued = true };
        using var factory = NewFactory(
            invoker,
            _ =>
            {
                // DEFAULT options — non-resilient, non-steerable.
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.OneShotTaskName));
        Assert.That(invoker.LastOptions!.TaskId, Is.EqualTo(invoker.LastOptions!.InputId));

        // The tracked task carries the Row 2 mark-failed disposition so recovery fails (not re-invokes) it.
        var input = invoker.LastInput as ResponseTaskInput;
        Assert.That(input, Is.Not.Null, "the one-shot task input must be a ResponseTaskInput");
        Assert.That(input!.Payload.Disposition, Is.EqualTo(ResponseRecoveryPayload.DispositionMarkFailed));
        Assert.That(
            ResponseResilienceDispatch.DecideDisposition(store: true, background: true, resilientBackground: false),
            Is.EqualTo(ResponseRecoveryPayload.DispositionMarkFailed));
    }

    [Test]
    public async Task SteeringQueueFull_MapsToConversationLocked409()
    {
        var invoker = new FakeTaskInvoker
        {
            ThrowOnStart = new SteeringQueueFullException(),
        };
        using var factory = NewFactory(
            invoker,
            o =>
            {
                o.SteerableConversations = true;
                o.ResilientBackground = true;
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true, conversation = "conv-full" }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        using var doc = await ParseAsync(response);
        Assert.That(
            doc.RootElement.GetProperty("error").GetProperty("code").GetString(),
            Is.EqualTo("conversation_locked"));
    }

    [Test]
    public async Task NonConversationalResilientTurn_RoutesToOneShotTask()
    {
        // No conversation / previous_response_id and non-steerable → the one-shot resilient task
        // (task id == input id == response id). The fake short-circuits via IsQueued only to observe
        // the dispatch decision without running the handler.
        var invoker = new FakeTaskInvoker { NextIsQueued = true };
        using var factory = NewFactory(
            invoker,
            o =>
            {
                o.SteerableConversations = false;
                o.ResilientBackground = true;
            });
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", background = true }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.OneShotTaskName));
        Assert.That(invoker.LastOptions!.TaskId, Is.EqualTo(invoker.LastOptions!.InputId));
    }

    [Test]
    public async Task PreviousResponseIdAlone_NonSteerable_RoutesToOneShotTask()
    {
        // Parity with Python `_pick_primitive`: previous_response_id is NOT a multi-turn trigger. A
        // non-steerable, non-conversational turn that only carries previous_response_id must route to
        // the one-shot task (no fork/lock precondition), not multi-turn.
        var root = Path.Combine(Path.GetTempPath(), "steer-oneshot-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        string antecedentId = Azure.AI.AgentServer.Responses.IdGenerator.NewResponseId();
        var seedProvider = new FileResponsesProvider(responsesDir);
        var antecedent = new ResponseObject(antecedentId, "test-model");
        antecedent.SetCompleted();
        await seedProvider.CreateResponseAsync(
            new CreateResponseRequest(antecedent, null, null), PlatformContext.Empty);

        var invoker = new FakeTaskInvoker { NextIsQueued = true };
        try
        {
            using var factory = new TestWebApplicationFactory(
                configureOptions: o =>
                {
                    o.SteerableConversations = false;
                    o.ResilientBackground = true;
                },
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskInvoker>(invoker);
                    services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                    services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
                });
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, previous_response_id = antecedentId }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(invoker.LastTaskName, Is.EqualTo(ResponsesResilientTaskHandler.OneShotTaskName));
            Assert.That(invoker.LastOptions!.IfLastInputId, Is.Null);
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

    [Test]
    public async Task ForegroundSteerableConversation_RunsInlineAndPersists()
    {
        // Regression guard: a FOREGROUND (non-background) steerable conversation turn now routes
        // through the Core multi-turn task for arbitration (conversation_locked / fork), then the
        // endpoint awaits the terminal turn and returns the final persisted response by id. The turn
        // must complete and be durably retrievable.
        var root = Path.Combine(Path.GetTempPath(), "steer-fg-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        try
        {
            using var factory = new TestWebApplicationFactory(
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

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", conversation = "conv-fg" }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = await ParseAsync(response);
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
            var responseId = doc.RootElement.GetProperty("id").GetString()!;

            // The completed turn is durably retrievable (the inline path persisted with a real context).
            var get = await client.GetAsync($"/responses/{responseId}");
            Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));
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

    [Test]
    public async Task ForegroundSteerable_StoreFalse_ReturnsEphemeralResponse_NotRetrievable()
    {
        // Regression guard (GAP3 final): under SteerableConversations=true EVERY request is
        // pickMultiTurn=true, so a FOREGROUND non-streaming store=false request routes through the
        // multi-turn task for arbitration. store=false responses are NOT persisted/retrievable (B14),
        // so the endpoint must return the in-memory terminal snapshot rather than fetching by id
        // (which would 404). Previously this path always called GetAsync → ResourceNotFoundException
        // → the POST failed.
        var root = Path.Combine(Path.GetTempPath(), "steer-fg-nostore-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        try
        {
            using var factory = new TestWebApplicationFactory(
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

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", store = false }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "a store=false foreground request must not fail even when routed through the multi-turn task");
            using var doc = await ParseAsync(response);
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
            var responseId = doc.RootElement.GetProperty("id").GetString()!;

            // B14: a store=false response is ephemeral and NOT retrievable.
            var get = await client.GetAsync($"/responses/{responseId}");
            Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
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

    // ---- Real end-to-end composition (real Core engine: enqueue + drain) ----
    [Test]
    public async Task RealComposition_ConcurrentSteeredTurn_EnqueuesThenDrains()
    {
        var root = Path.Combine(Path.GetTempPath(), "steer-e2e-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstTurnEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var steeredTurnEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // Capture the live active-turn context so the test can assert its PendingInputCount
        // (Core's live steering-queue accounting) once the second turn has been enqueued.
        ResponseContext? activeContext = null;

        var handler = new TestHandler
        {
            EventFactory = (request, context, ct) =>
            {
                if (context.IsSteeredTurn)
                {
                    steeredTurnEntered.TrySetResult();
                }
                else
                {
                    activeContext = context;
                }

                return EmitGatedAsync(request, context, gate, firstTurnEntered, ct);
            },
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

            // Turn 1: enters the handler and blocks so the chain stays in-flight.
            var turn1 = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, conversation = "conv-real" }));
            Assert.That(turn1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            await firstTurnEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));

            // Turn 2 on the same conversation: enqueued as steering behind the active turn.
            var turn2 = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, conversation = "conv-real" }));
            Assert.That(turn2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using (var doc2 = await ParseAsync(turn2))
            {
                Assert.That(doc2.RootElement.GetProperty("status").GetString(), Is.EqualTo("queued"));
            }

            // While the active turn is still blocked, its context reflects the pending steering
            // input via Core's live queue accounting (FR-029/US5 PendingInputCount contract).
            Assert.That(activeContext, Is.Not.Null, "the active (non-steered) turn context must have been captured");
            await AssertEventuallyAsync(
                () => activeContext!.PendingInputCount >= 1,
                TimeSpan.FromSeconds(5),
                "active turn PendingInputCount should observe the enqueued steering input");

            // Release the active turn; the queued turn then drains as a steered re-entry.
            gate.SetResult();

            // The queued turn re-enters the handler as a steered turn (IsSteeredTurn=true).
            await steeredTurnEntered.Task.WaitAsync(TimeSpan.FromSeconds(15));

            // The active turn reaches a terminal state.
            using (var turn1Doc = await ParseAsync(turn1))
            {
                var turn1Id = turn1Doc.RootElement.GetProperty("id").GetString()!;
                await WaitForTerminalAsync(client, turn1Id, TimeSpan.FromSeconds(15));
            }
        }
        finally
        {
            gate.TrySetResult();
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    // ---- Real end-to-end composition: FOREGROUND concurrent overlap (Finding D, FR-052) ----
    [Test]
    public async Task RealComposition_ForegroundConcurrentTurn_OneSucceedsOtherLocked()
    {
        // Two concurrent FOREGROUND POSTs on the same conversation (SteerableConversations=false):
        // exactly one wins and runs the turn to a terminal 200; the overlapping one is rejected with
        // HTTP 409 conversation_locked. This proves foreground multi-turn now goes through the Core
        // multi-turn task (real engine) and gets concurrency arbitration, not background-gated.
        var root = Path.Combine(Path.GetTempPath(), "steer-fg-e2e-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstTurnEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        var handler = new TestHandler
        {
            EventFactory = (request, context, ct) => EmitGatedAsync(request, context, gate, firstTurnEntered, ct),
        };

        try
        {
            using var factory = new TestWebApplicationFactory(
                handler,
                configureOptions: o =>
                {
                    // Non-steerable → a concurrent turn is a lock conflict (not a steering enqueue).
                    o.SteerableConversations = false;
                },
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                    services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
                });
            using var client = factory.CreateClient();

            // Turn 1 (FOREGROUND): blocks until terminal, so fire it without awaiting; the handler
            // gates on `gate` to keep the chain in-flight while turn 2 races in.
            var turn1Task = client.PostAsync(
                "/responses",
                Json(new { model = "test", conversation = "conv-fg-real" }));
            await firstTurnEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));

            // Turn 2 on the same conversation while turn 1 holds the lock → 409 conversation_locked.
            var turn2 = await client.PostAsync(
                "/responses",
                Json(new { model = "test", conversation = "conv-fg-real" }));
            Assert.That(turn2.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
            using (var doc2 = await ParseAsync(turn2))
            {
                Assert.That(
                    doc2.RootElement.GetProperty("error").GetProperty("code").GetString(),
                    Is.EqualTo("conversation_locked"));
            }

            // Release turn 1; it completes with a terminal 200 and the final response.
            gate.SetResult();
            var turn1 = await turn1Task.WaitAsync(TimeSpan.FromSeconds(15));
            Assert.That(turn1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using (var turn1Doc = await ParseAsync(turn1))
            {
                Assert.That(turn1Doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
            }
        }
        finally
        {
            gate.TrySetResult();
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitGatedAsync(
        CreateResponse request,
        ResponseContext context,
        TaskCompletionSource gate,
        TaskCompletionSource entered,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);

        // Signal only from the first (non-steered) turn so the test knows the chain is in-flight.
        if (!context.IsSteeredTurn)
        {
            entered.TrySetResult();
            await gate.Task.WaitAsync(ct);
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async Task AssertEventuallyAsync(Func<bool> condition, TimeSpan timeout, string message)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            if (condition())
            {
                return;
            }

            await Task.Delay(50);
        }

        Assert.That(condition(), Is.True, message);
    }

    private static async Task WaitForTerminalAsync(HttpClient client, string responseId, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await ParseAsync(get);
                var status = doc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response '{responseId}' did not reach a terminal state within {timeout}.");
    }

    private static TestWebApplicationFactory NewFactory(
        ITaskInvoker invoker,
        Action<ResponsesServerOptions> configureOptions)
    {
        // Isolate the Core task/response stores at fresh empty dirs so the always-on durability
        // service cold-start scan finds nothing and cannot pick up shared/leftover state.
        var root = Path.Combine(Path.GetTempPath(), "steer-unit-" + Guid.NewGuid().ToString("N"));
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);

        return new TestWebApplicationFactory(
            configureOptions: configureOptions,
            configureTestServices: services =>
            {
                services.AddSingleton(invoker);
                services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
            });
    }

    /// <summary>
    /// A minimal <see cref="ITaskInvoker"/> test double that captures the dispatch decision and
    /// either throws a configured Core steering exception or returns a queued handle — enough to
    /// verify the Responses dispatch selection and exception→409 mapping without running the handler.
    /// </summary>
    private sealed class FakeTaskInvoker : ITaskInvoker
    {
        public bool NextIsQueued { get; set; }

        public Exception? ThrowOnStart { get; set; }

        public string? LastTaskName { get; private set; }

        public RunOptions? LastOptions { get; private set; }

        public object? LastInput { get; private set; }

        public Task<TaskRun<TOutput>> StartAsync<TInput, TOutput>(
            string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
        {
            LastTaskName = name;
            LastOptions = options;
            LastInput = input;

            if (ThrowOnStart is not null)
            {
                return Task.FromException<TaskRun<TOutput>>(ThrowOnStart);
            }

            return Task.FromResult<TaskRun<TOutput>>(new FakeTaskRun<TOutput>(NextIsQueued));
        }

        public Task<TOutput> RunAsync<TInput, TOutput>(
            string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
            string name, string taskId, CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRun<TOutput>?>(null);

        public Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
            string name, string taskId, string inputId, CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRun<TOutput>?>(null);
    }

    private sealed class FakeTaskRun<TOutput> : TaskRun<TOutput>
    {
        private readonly bool _isQueued;

        public FakeTaskRun(bool isQueued) => _isQueued = isQueued;

        public override bool IsQueued => _isQueued;

        public override Task<TOutput> GetResultAsync(CancellationToken cancellationToken = default)
            => new TaskCompletionSource<TOutput>().Task;
    }
}
