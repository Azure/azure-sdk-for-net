// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for the non-resilient checkpoint no-op contract (FR-030). When
/// <see cref="ResponsesServerOptions.ResilientBackground"/> is <c>false</c>, a
/// <c>yield stream.Checkpoint()</c> is a no-op — it neither persists an extra snapshot nor alters
/// the emitted event sequence — so handlers can checkpoint unconditionally and the framework only
/// pays the persistence cost when resilient background is enabled.
/// </summary>
public class CheckpointNoOpProtocolTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;

    public CheckpointNoOpProtocolTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "ckptnoop-" + Guid.NewGuid().ToString("N"));
        _responsesDir = Path.Combine(_root, "responses");
        Directory.CreateDirectory(_responsesDir);
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
    public async Task Checkpoint_NonResilient_DoesNotPersistExtraSnapshot()
    {
        var counter = new UpdateCountingProvider(new FileResponsesProvider(_responsesDir));

        // ResilientBackground is NOT set → the checkpoint gate is closed and Checkpoint() is a no-op.
        using var factory = new TestWebApplicationFactory(
            new TestHandler { EventFactory = CheckpointLifecycle },
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(counter);
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });
        using var client = factory.CreateClient();

        var events = await DrainBackgroundStreamAsync(client);

        // The response still completes normally...
        Assert.That(events, Does.Contain("response.completed"));
        // ...but the checkpoint added no extra write: created → CreateResponseAsync (1 Create),
        // terminal → UpdateResponseAsync (1 Update). A resilient host would show 2 Updates.
        Assert.That(counter.CreateCount, Is.EqualTo(1));
        Assert.That(counter.UpdateCount, Is.EqualTo(1));
    }

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
        CreateResponse request,
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("hello");
        yield return text.EmitTextDone("hello");
        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.Checkpoint();

        await Task.Yield();
        yield return stream.EmitCompleted();
    }

    /// <summary>A <see cref="ResponsesProvider"/> wrapper counting Create/Update writes.</summary>
    private sealed class UpdateCountingProvider : ResponsesProvider
    {
        private readonly ResponsesProvider _inner;
        private int _createCount;
        private int _updateCount;

        public UpdateCountingProvider(ResponsesProvider inner) => _inner = inner;

        public int CreateCount => Volatile.Read(ref _createCount);

        public int UpdateCount => Volatile.Read(ref _updateCount);

        public override Task CreateResponseAsync(
            CreateResponseRequest request, PlatformContext context, CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _createCount);
            return _inner.CreateResponseAsync(request, context, cancellationToken);
        }

        public override Task UpdateResponseAsync(
            ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default)
        {
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
}
