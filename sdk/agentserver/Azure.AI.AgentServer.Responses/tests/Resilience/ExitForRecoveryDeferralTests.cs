// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Resilience;

/// <summary>
/// FR-036 graceful-deferral coverage: a resilient background handler that calls
/// <see cref="ResponseContext.ExitForRecoveryAsync"/> mid-flight must defer to the next lifetime
/// instead of failing. The response must (1) never reach a terminal state, (2) not overwrite the
/// last checkpoint with a pre-terminal record (no extra durable write after the checkpoint), and
/// (3) keep its recovery entry registered so a restarted sandbox re-invokes it. The no-op case —
/// <c>ExitForRecoveryAsync()</c> on a non-resilient/non-background response — must simply complete
/// without throwing.
/// </summary>
[NonParallelizable]
public sealed class ExitForRecoveryDeferralTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;
    private readonly string _tasksDir;

    public ExitForRecoveryDeferralTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "defer-" + Guid.NewGuid().ToString("N"));
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
        catch (IOException) { }
    }

    private TestWebApplicationFactory NewResilientFactory(TestHandler handler, CountingResponsesProvider provider)
        => new(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(provider);
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(_tasksDir));
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });

    private int RecoveryEntryCount()
        => CoreTaskRecoveryTestHelpers.TaskRecordCount(_tasksDir);

    [Test]
    public async Task ExitForRecovery_ResilientBackground_DefersWithoutTerminalOrOverwrite()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var deferred = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) => CheckpointThenDeferLifecycle(ctx, req, deferred, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        var body = JsonSerializer.Serialize(new { model = "test-model", background = true });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var created = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var responseId = created.RootElement.GetProperty("id").GetString()!;

        // Wait for the handler to reach the deferral point.
        await deferred.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // Give finalization a moment to run (it must NOT drive a terminal write or overwrite the
        // checkpoint). Poll a few times so any errant terminal write would surface.
        for (var i = 0; i < 20; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
            var status = doc.RootElement.GetProperty("status").GetString();
            Assert.That(status, Is.EqualTo("in_progress"),
                "a deferred response must remain in_progress (never terminal) so recovery re-invokes it");
            await Task.Delay(15);
        }

        // Exactly one create (response.created) + one update (the checkpoint). No extra pre-terminal
        // update from finalization (FR-036: don't overwrite the last checkpoint).
        Assert.That(provider.CreateCount, Is.EqualTo(1), "exactly one created write");
        Assert.That(provider.UpdateCount, Is.EqualTo(1),
            "only the checkpoint write; finalization must not overwrite it with a pre-terminal record");

        // The Core task record must remain so a restarted sandbox re-invokes the deferred work.
        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Core task record must be retained across deferral (status is non-terminal)");
    }

    [Test]
    public async Task ExitForRecovery_NonBackground_IsNoOp_AndCompletes()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var handler = new TestHandler
        {
            // Non-background, non-resilient path: ExitForRecoveryAsync must be a silent no-op.
            EventFactory = (req, ctx, ct) => NoOpDeferLifecycle(ctx, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        // No background flag → synchronous, non-resilient response.
        var body = JsonSerializer.Serialize(new { model = "test-model" });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"),
            "ExitForRecoveryAsync must be a no-op for non-resilient/non-background responses");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0));
    }

    [Test]
    public async Task ExitForRecovery_ResilientBackgroundStreaming_LeavesDurableStreamOpen()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var deferred = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) => CheckpointThenDeferLifecycle(ctx, req, deferred, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        var responseId = await CreateBgStreamingResponseAsync(client);

        // Wait for the streaming handler to reach the deferral point.
        await deferred.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // Give finalization a moment to run.
        for (var i = 0; i < 20; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"),
                "a deferred streaming response must remain in_progress");
            await Task.Delay(15);
        }

        // The durable SSE stream file must NOT carry a terminal sentinel: a deferred stream is
        // handed to the next lifetime to resume, and a sentinel would make a post-restart reconnect
        // close prematurely and miss the live tail (FR-041). The Core file-backed stream writes a
        // "__terminal__":true line only when the stream is closed on completion.
        var streamFiles = Directory.GetFiles(Path.Combine(_responsesDir, "streams"), "*.jsonl");
        Assert.That(streamFiles, Has.Length.EqualTo(1), "the durable stream file should exist");
        var contents = await File.ReadAllTextAsync(streamFiles[0]);
        Assert.That(contents, Does.Not.Contain("\"__terminal__\":true"),
            "a deferred (not crashed) streaming response must not write a terminal sentinel");
        Assert.That(contents, Does.Not.Contain("\"__terminal__\": true"));

        // Core task record retained so a restarted sandbox re-invokes the deferred work.
        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Core task record must be retained across streaming deferral");
    }

    [Test]
    public async Task ExitForRecovery_StoreFalse_Throws()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) => CreatedThenDeferLifecycle(ctx, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        // store=false, foreground: background+store=false is rejected by B13, so a store=false
        // response is necessarily foreground. ExitForRecoveryAsync must throw because there is no
        // durable state to recover — the orchestrator surfaces it as a failure (NOT completed,
        // NOT deferred/in_progress).
        var body = JsonSerializer.Serialize(new { model = "test-model", store = false });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var status = doc.RootElement.GetProperty("status").GetString();
        Assert.That(status, Is.EqualTo("failed"),
            "ExitForRecoveryAsync on a store=false response must surface as a failure, not complete or defer");

        // The internal detail (store=false) is sanitized to a generic server_error on the wire
        // — the .NET failure taxonomy never leaks handler exception detail to the client.
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));

        // store=false responses are never task-tracked, so no recovery entry is registered.
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0));
    }

    [Test]
    public async Task ExitForRecovery_ResilientBackground_HandlerSwallowsSignal_StillDefers()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var deferred = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) => CheckpointThenSwallowedDeferLifecycle(ctx, req, deferred, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        var body = JsonSerializer.Serialize(new { model = "test-model", background = true });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var created = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var responseId = created.RootElement.GetProperty("id").GetString()!;

        // Wait for the handler to swallow the deferral signal and return normally.
        await deferred.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // Even though the handler wrapped ExitForRecoveryAsync() in catch (Exception) {}, the
        // FINAL durable outcome must still be deferred: in_progress (never terminal), no
        // finalization overwrite of the checkpoint, recovery entry retained.
        for (var i = 0; i < 20; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var docGet = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
            var status = docGet.RootElement.GetProperty("status").GetString();
            Assert.That(status, Is.EqualTo("in_progress"),
                "a swallowed deferral signal must still leave the response in_progress (never terminal)");
            await Task.Delay(15);
        }

        Assert.That(provider.CreateCount, Is.EqualTo(1), "exactly one created write");
        Assert.That(provider.UpdateCount, Is.EqualTo(1),
            "only the checkpoint write; finalization must not overwrite it even when the signal was swallowed");

        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Core task record must be retained across a swallowed deferral");
    }

    [Test]
    public async Task ExitForRecovery_ResilientBackgroundStreaming_HandlerSwallowsSignalThenEmitsTerminal_StillDefers()
    {
        var provider = new CountingResponsesProvider(new FileResponsesProvider(_responsesDir));
        var deferred = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) => CheckpointThenSwallowedDeferThenTerminalLifecycle(ctx, req, deferred, ct),
        };

        using var factory = NewResilientFactory(handler, provider);
        using var client = factory.CreateClient();

        var responseId = await CreateBgStreamingResponseAsync(client);

        // Wait for the handler to swallow the deferral and attempt the terminal emission.
        await deferred.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // Even though the handler swallowed ExitForRecoveryAsync() via catch (Exception) {} and then
        // yielded a completed terminal, the framework must ignore that terminal: the durable response
        // stays in_progress (never completed/terminal) for the whole observation window.
        for (var i = 0; i < 20; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"),
                "a swallowed deferral must defeat a subsequent handler terminal — the response must never complete");
            await Task.Delay(15);
        }

        // No terminal SSE sentinel may be persisted — the deferred stream is handed to the next
        // lifetime, and a "__terminal__":true line would close a reconnect prematurely (FR-041).
        var streamFiles = Directory.GetFiles(Path.Combine(_responsesDir, "streams"), "*.jsonl");
        Assert.That(streamFiles, Has.Length.EqualTo(1), "the durable stream file should exist");
        var contents = await File.ReadAllTextAsync(streamFiles[0]);
        Assert.That(contents, Does.Not.Contain("\"__terminal__\":true"),
            "a swallowed-deferral streaming response must not persist a terminal sentinel");
        Assert.That(contents, Does.Not.Contain("\"__terminal__\": true"));
        // The swallowed response.completed must never be persisted to the durable stream.
        Assert.That(contents, Does.Not.Contain("response.completed"),
            "the terminal event emitted after a swallowed deferral must not be persisted");

        // Only the single checkpoint write; finalization must not overwrite it with a terminal.
        Assert.That(provider.UpdateCount, Is.EqualTo(1),
            "finalization must not overwrite the checkpoint even when a terminal follows a swallowed deferral");

        // Core task record retained so a restarted sandbox re-invokes the deferred work.
        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Core task record must be retained across a swallowed-then-terminal deferral");
    }

    private static async Task<string> CreateBgStreamingResponseAsync(HttpClient client)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test-model", stream = true, background = true }),
                Encoding.UTF8, "application/json"),
        };

        // A gated/deferring background handler keeps the primary POST SSE stream open, so read only
        // headers + the first data line carrying the response id (buffering the whole body deadlocks).
        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        await using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);
        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            if (!line.StartsWith("data: ", StringComparison.Ordinal))
            {
                continue;
            }

            using var doc = JsonDocument.Parse(line["data: ".Length..]);
            if (doc.RootElement.TryGetProperty("response", out var resp)
                && resp.TryGetProperty("id", out var idProp))
            {
                return idProp.GetString()!;
            }
        }

        throw new InvalidOperationException("No response id in POST SSE stream");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CheckpointThenDeferLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        TaskCompletionSource deferred,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, request);
        yield return stream.EmitCreated();

        // Emit one output item so the checkpoint snapshot differs from the created snapshot.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("phase-1");
        yield return text.EmitTextDone("phase-1");
        yield return text.EmitDone();
        yield return message.EmitDone();

        // Checkpoint the phase (durable write #1).
        yield return stream.Checkpoint();

        // Defer to the next lifetime. On a resilient background response this throws
        // ResponseExitForRecovery, which the orchestrator catches without failing the response.
        deferred.TrySetResult();
        await ctx.ExitForRecoveryAsync(ct);

        // Unreachable on the resilient path (the throw unwinds the iterator).
        yield break;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> NoOpDeferLifecycle(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);

        // No-op on the non-resilient path — must not throw, handler continues to terminal.
        await ctx.ExitForRecoveryAsync(ct);

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CreatedThenDeferLifecycle(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);

        // On a store=false response ExitForRecoveryAsync throws InvalidOperationException (there is
        // no durable state to recover). The orchestrator catches it and marks the response failed.
        await ctx.ExitForRecoveryAsync(ct);

        // Unreachable on the store=false path (the throw unwinds the iterator).
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CheckpointThenSwallowedDeferLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        TaskCompletionSource deferred,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, request);
        yield return stream.EmitCreated();

        // Emit one output item so the checkpoint snapshot differs from the created snapshot.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("phase-1");
        yield return text.EmitTextDone("phase-1");
        yield return text.EmitDone();
        yield return message.EmitDone();

        // Checkpoint the phase (durable write #1).
        yield return stream.Checkpoint();

        // Adversarial handler: swallow the deferral signal with a broad catch. The framework must
        // STILL defer — a broad catch must not be able to convert a deferral into a bad-handler
        // failure or a checkpoint overwrite.
        try
        {
            await ctx.ExitForRecoveryAsync(ct);
        }
        catch (Exception)
        {
            // Deliberately swallowed.
        }

        deferred.TrySetResult();

        // Return normally WITHOUT emitting a terminal event.
        yield break;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CheckpointThenSwallowedDeferThenTerminalLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        TaskCompletionSource deferred,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, request);
        yield return stream.EmitCreated();

        // Emit one output item so the checkpoint snapshot differs from the created snapshot.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("phase-1");
        yield return text.EmitTextDone("phase-1");
        yield return text.EmitDone();
        yield return message.EmitDone();

        // Checkpoint the phase (durable write #1).
        yield return stream.Checkpoint();

        // Adversarial handler: swallow the deferral signal with a broad catch AND THEN emit a
        // terminal event. The framework must STILL defer — once ExitForRecoveryAsync() has been
        // called, no subsequent handler-emitted terminal may drive the durable response terminal
        // (the signal cannot be effectively swallowed).
        try
        {
            await ctx.ExitForRecoveryAsync(ct);
        }
        catch (Exception)
        {
            // Deliberately swallowed.
        }

        deferred.TrySetResult();

        // Attempt to complete the response after swallowing the deferral. This terminal MUST be
        // ignored by the framework.
        yield return stream.EmitCompleted();
    }

    /// <summary>Delegating provider that counts create/update writes so a spurious pre-terminal
    /// overwrite after a checkpoint is observable.</summary>
    private sealed class CountingResponsesProvider : ResponsesProvider
    {
        private readonly ResponsesProvider _inner;
        private int _createCount;
        private int _updateCount;

        public CountingResponsesProvider(ResponsesProvider inner) => _inner = inner;

        public int CreateCount => Volatile.Read(ref _createCount);
        public int UpdateCount => Volatile.Read(ref _updateCount);

        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext context, CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _createCount);
            return _inner.CreateResponseAsync(request, context, cancellationToken);
        }

        public override Task UpdateResponseAsync(ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _updateCount);
            return _inner.UpdateResponseAsync(response, context, cancellationToken);
        }

        public override Task<ResponseObject> GetResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetResponseAsync(responseId, context, cancellationToken);

        public override Task DeleteResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.DeleteResponseAsync(responseId, context, cancellationToken);

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext context, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => _inner.GetInputItemsAsync(responseId, context, limit, ascending, after, before, cancellationToken);

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetItemsAsync(itemIds, context, cancellationToken);

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, context, cancellationToken);
    }
}
