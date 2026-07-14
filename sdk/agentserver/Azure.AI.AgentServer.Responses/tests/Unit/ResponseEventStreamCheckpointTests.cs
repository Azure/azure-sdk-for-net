// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ResponseEventStream.Checkpoint"/> and its orchestration cutpoints
/// C4/C5 (Row 11 / FR-030..037). A checkpoint yielded at a phase boundary persists the current
/// <c>stream.Response</c> snapshot (gated to resilient background); a checkpoint after the terminal
/// event is dropped (C4/FR-034); a transient checkpoint-store failure is swallowed and the response
/// still completes (C5/FR-035).
/// </summary>
public class ResponseEventStreamCheckpointTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;
    private readonly string _tasksDir;

    public ResponseEventStreamCheckpointTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "ckpt-" + Guid.NewGuid().ToString("N"));
        _responsesDir = Path.Combine(_root, "responses");
        _tasksDir = Path.Combine(_root, "tasks");
        Directory.CreateDirectory(_responsesDir);
        Directory.CreateDirectory(_tasksDir);
    }

    public void Dispose()
    {
        try
        {
            if (Directory.Exists(_root))
            {
                Directory.Delete(_root, recursive: true);
            }
        }
        catch (IOException)
        {
        }
    }

    [Test]
    public void Checkpoint_ReturnsCheckpointControlEvent_CarryingResponse()
    {
        var ctx = new StubContext("caresp_unit");
        var request = new CreateResponse { Model = "test-model", Background = true };
        var stream = new ResponseEventStream(ctx, request);

        var evt = stream.Checkpoint();

        Assert.That(evt, Is.InstanceOf<ResponseCheckpointEvent>());
        Assert.That(((ResponseCheckpointEvent)evt).Response, Is.SameAs(stream.Response));
    }

    [Test]
    public async Task Checkpoint_BeforeTerminal_PersistsExtraSnapshot()
    {
        var counter = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));

        using var factory = NewResilientHost(
            new TestHandler { EventFactory = (req, ctx, ct) => CheckpointLifecycle(ctx, req, checkpointAfterTerminal: false, ct) },
            counter);
        using var client = factory.CreateClient();

        await DrainBackgroundStreamAsync(client);

        // created → CreateResponseAsync (1 Create). Pre-terminal checkpoint (1 Update) + terminal
        // (1 Update) = 2 Updates when the checkpoint actually persists.
        Assert.That(counter.CreateCount, Is.EqualTo(1));
        Assert.That(counter.UpdateCount, Is.EqualTo(2));
    }

    [Test]
    public async Task Checkpoint_AfterTerminal_IsDropped()
    {
        var counter = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));

        using var factory = NewResilientHost(
            new TestHandler { EventFactory = (req, ctx, ct) => CheckpointLifecycle(ctx, req, checkpointAfterTerminal: true, ct) },
            counter);
        using var client = factory.CreateClient();

        await DrainBackgroundStreamAsync(client);

        // C4/FR-034: the checkpoint after the terminal event is dropped, so only the terminal write
        // updates the record (1 Update) — the post-terminal checkpoint does not add a second.
        Assert.That(counter.CreateCount, Is.EqualTo(1));
        Assert.That(counter.UpdateCount, Is.EqualTo(1));
    }

    [Test]
    public async Task Checkpoint_StoreFailure_IsSwallowed_ResponseCompletes()
    {
        // Fail the FIRST UpdateResponseAsync (the pre-terminal checkpoint), succeed the rest.
        var counter = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir))
        {
            FailUpdateCallNumber = 1,
        };

        using var factory = NewResilientHost(
            new TestHandler { EventFactory = (req, ctx, ct) => CheckpointLifecycle(ctx, req, checkpointAfterTerminal: false, ct) },
            counter);
        using var client = factory.CreateClient();

        var events = await DrainBackgroundStreamAsync(client);

        // C5/FR-035: the checkpoint store failure is swallowed — the handler is not faulted and the
        // response still reaches a completed terminal state (the terminal write succeeds).
        Assert.That(events, Does.Contain("response.completed"));
        Assert.That(events, Does.Not.Contain("response.failed"));
        Assert.That(counter.UpdateAttemptCount, Is.GreaterThanOrEqualTo(2));
    }

    // ── Helpers ──────────────────────────────────────────────

    private TestWebApplicationFactory NewResilientHost(TestHandler handler, ResponsesProvider provider)
        => new(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(provider);
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(_tasksDir));
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });

    private static async Task<string> DrainBackgroundStreamAsync(HttpClient client)
    {
        var body = JsonSerializer.Serialize(new
        {
            model = "test-model",
            background = true,
            stream = true,
        });
        using var content = new StringContent(body, Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/responses", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CheckpointLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        bool checkpointAfterTerminal,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Emit one output item so the checkpoint snapshot differs from the response.created
        // snapshot (otherwise the byte-identical checkpoint would be deduplicated — FR-030).
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("hello");
        yield return text.EmitTextDone("hello");
        yield return text.EmitDone();
        yield return message.EmitDone();

        if (!checkpointAfterTerminal)
        {
            yield return stream.Checkpoint();
        }

        await Task.Yield();
        yield return stream.EmitCompleted();

        if (checkpointAfterTerminal)
        {
            // C4: a checkpoint after the terminal event must be silently dropped.
            yield return stream.Checkpoint();
        }
    }

    /// <summary>
    /// A <see cref="ResponsesProvider"/> wrapper that counts Create/Update calls and can be
    /// configured to fail a specific Update call number (to exercise C5 checkpoint-store failure).
    /// </summary>
    private sealed class CountingResponsesProvider : ResponsesProvider
    {
        private readonly ResponsesProvider _inner;
        private int _createCount;
        private int _updateCount;
        private int _updateAttempts;

        public CountingResponsesProvider(ResponsesProvider inner) => _inner = inner;

        public int CreateCount => Volatile.Read(ref _createCount);

        public int UpdateCount => Volatile.Read(ref _updateCount);

        public int UpdateAttemptCount => Volatile.Read(ref _updateAttempts);

        /// <summary>1-based Update call number to fail, or 0 to never fail.</summary>
        public int FailUpdateCallNumber { get; init; }

        public override Task CreateResponseAsync(
            CreateResponseRequest request, PlatformContext context, CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _createCount);
            return _inner.CreateResponseAsync(request, context, cancellationToken);
        }

        public override Task UpdateResponseAsync(
            ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default)
        {
            var attempt = Interlocked.Increment(ref _updateAttempts);
            if (FailUpdateCallNumber != 0 && attempt == FailUpdateCallNumber)
            {
                throw new IOException("Simulated transient checkpoint store failure.");
            }

            Interlocked.Increment(ref _updateCount);
            return _inner.UpdateResponseAsync(response, context, cancellationToken);
        }

        public override Task<ResponseObject> GetResponseAsync(
            string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetResponseAsync(responseId, context, cancellationToken);

        public override Task DeleteResponseAsync(
            string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.DeleteResponseAsync(responseId, context, cancellationToken);

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
            string responseId, PlatformContext context, int limit = 20, bool ascending = false,
            string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => _inner.GetInputItemsAsync(responseId, context, limit, ascending, after, before, cancellationToken);

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(
            IEnumerable<string> itemIds, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetItemsAsync(itemIds, context, cancellationToken);

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(
            string? previousResponseId, string? conversationId, int limit, PlatformContext context,
            CancellationToken cancellationToken = default)
            => _inner.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, context, cancellationToken);
    }

    /// <summary>Minimal <see cref="ResponseContext"/> stub for the pure-unit Checkpoint() test.</summary>
    private sealed class StubContext : ResponseContext
    {
        public StubContext(string responseId)
            : base(responseId)
        {
        }

        public override Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<Item>>(Array.Empty<Item>());

        public override Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());
    }
}
