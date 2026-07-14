// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net;
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
/// Protocol tests for the uniform graceful-deferral primitive
/// <see cref="ResponseContext.ExitForRecoveryAsync"/> (FR-024). The deferral has an effect only for a
/// resilient background response (<c>ResilientBackground=true</c> + <c>background=true</c> +
/// <c>store!=false</c>); for every other configuration it completes as a silent no-op so the handler
/// runs on to its natural terminal. This is the protocol counterpart to the e2e crash-recovery
/// coverage in <c>ExitForRecoveryDeferralTests</c>.
/// </summary>
[NonParallelizable]
public sealed class ExitForRecoveryProtocolTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;
    private readonly string _tasksDir;

    public ExitForRecoveryProtocolTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "efr-proto-" + Guid.NewGuid().ToString("N"));
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

    [Test]
    public async Task ExitForRecovery_ResilientBackground_LeavesResponseInProgress()
    {
        var reached = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => DeferAfterCheckpointLifecycle(ctx, reached, ct),
        };

        using var factory = NewHost(handler, resilient: true);
        using var client = factory.CreateClient();

        var responseId = await CreateBackgroundAsync(client);
        await reached.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // The handler deferred via ExitForRecoveryAsync(); the response must stay in_progress (the
        // control signal is not a terminal state) with the Core task record retained.
        for (var i = 0; i < 20; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"),
                "a resilient background deferral must remain in_progress");
            await Task.Delay(15);
        }

        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "a resilient background deferral must retain the Core task record");
    }

    [Test]
    public async Task ExitForRecovery_NonResilientBackground_IsNoOp_Completes()
    {
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => DeferThenCompleteLifecycle(ctx, ct),
        };

        using var factory = NewHost(handler, resilient: false);
        using var client = factory.CreateClient();

        var responseId = await CreateBackgroundAsync(client);

        // ExitForRecoveryAsync is a no-op here, so the handler runs on to completed.
        await WaitForStatusAsync(client, responseId, "completed");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0),
            "a non-resilient response must not create a Core task record");
    }

    [Test]
    public async Task ExitForRecovery_Foreground_IsNoOp_Completes()
    {
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => DeferThenCompleteLifecycle(ctx, ct),
        };

        // Resilient host, but a foreground (background=false) request is not a resilient row, so the
        // deferral is a no-op and the synchronous POST returns the completed terminal response.
        using var factory = NewHost(handler, resilient: true);
        using var client = factory.CreateClient();

        var post = await client.PostAsync("/responses",
            new StringContent(JsonSerializer.Serialize(new { model = "test-model" }),
                Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"),
            "ExitForRecoveryAsync must be a no-op for a foreground response");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0));
    }

    private TestWebApplicationFactory NewHost(TestHandler handler, bool resilient)
        => new(
            handler,
            configureOptions: resilient ? (o => o.ResilientBackground = true) : null,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(new FileResponsesProvider(_responsesDir));
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(_tasksDir));
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });

    private int RecoveryEntryCount()
        => CoreTaskRecoveryTestHelpers.TaskRecordCount(_tasksDir);

    private static async Task<string> CreateBackgroundAsync(HttpClient client)
    {
        var post = await client.PostAsync("/responses",
            new StringContent(JsonSerializer.Serialize(new { model = "test-model", background = true }),
                Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    private static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected)
    {
        for (var i = 0; i < 200; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
                if (doc.RootElement.GetProperty("status").GetString() == expected)
                {
                    return;
                }
            }

            await Task.Delay(25);
        }

        Assert.Fail($"Response {responseId} did not reach status '{expected}' in time.");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DeferAfterCheckpointLifecycle(
        ResponseContext ctx,
        TaskCompletionSource reached,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();
        yield return stream.Checkpoint();

        reached.TrySetResult();
        await ctx.ExitForRecoveryAsync(ct);

        // Unreachable on the resilient path (ExitForRecoveryAsync throws the control signal).
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DeferThenCompleteLifecycle(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();

        // No-op on the non-resilient path — must not throw; the handler continues to terminal.
        await ctx.ExitForRecoveryAsync(ct);

        yield return stream.EmitCompleted();
    }
}
