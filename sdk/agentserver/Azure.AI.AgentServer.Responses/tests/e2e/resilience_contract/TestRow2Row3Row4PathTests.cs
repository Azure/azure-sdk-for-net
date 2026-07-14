// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Non-recovery termination paths for the non-resilient rows (US4). These rows do NOT hand off to
/// next-lifetime recovery:
/// <list type="bullet">
/// <item><b>Row 2</b> (<c>store=true, background=true, ResilientBackground=false</c>) — on a graceful
/// shutdown that cancels the in-flight handler (Path B), the in-process shutdown loop marks the
/// response <c>failed</c> (<c>code=server_error</c>) and does NOT create a recovery entry. Path C
/// (crash → mark-failed) is covered by <c>TestRow2PathCCrashFailedTests</c>.</item>
/// <item><b>Row 3</b> (<c>background=false</c>, foreground) — the stored response is tracked by a Core
/// one-shot task while in-flight; on any termination the response is marked <c>failed</c>
/// (<c>code=server_error</c>) and the handler is never re-invoked (the client connection is already
/// gone). On graceful shutdown the task finalizes and leaves no recovery entry.</item>
/// <item><b>Row 4</b> (<c>store=false</c>) — ephemeral: nothing is persisted, GET returns 404, and no
/// recovery entry is ever written, so no next-lifetime action applies.</item>
/// </list>
/// A graceful shutdown is driven by <see cref="TestWebApplicationFactory.StopAsync"/> (the SIGTERM
/// analog for the single-process recovery model).
/// </summary>
[NonParallelizable]
public sealed class TestRow2Row3Row4PathTests : CrashRecoveryE2ETestBase
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task Row2PathB_NonResilientBackground_MarksFailed_NoRecoveryEntry(bool stream)
    {
        var started = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => BlockUntilShutdownLifecycle(ctx, started, ct),
        };

        using var factory = NewNonResilientHost(handler);
        using var client = factory.CreateClient();

        var responseId = await CreateBackgroundAsync(client, stream);
        await started.Task.WaitAsync(TimeSpan.FromSeconds(10));

        await factory.StopAsync();

        await WaitForStatusAsync(client, responseId, "failed");
        var get = await client.GetAsync($"/responses/{responseId}");
        using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("code").GetString(),
            Is.EqualTo("server_error"), "Row 2 Path B must fail with server_error");
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("shutdown_reason").GetString(),
            Is.EqualTo("grace_exhausted"),
            "Row 2 Path B (in-process graceful shutdown) mark-failed must carry shutdown_reason=grace_exhausted");
        // Row 2 is now tracked by a Core one-shot task while in-flight (so a crash — Path C — can
        // mark it failed in the next lifetime). On this graceful shutdown (Path B) the engine removes
        // the record as the task finalizes; assert the terminal steady state: no lingering entry.
        await WaitForRecoveryEntryCountAsync(0,
            "a non-resilient background row must not leave a recovery entry after graceful shutdown");
    }

    [Test]
    public async Task Row3Foreground_ShutdownDuringHandler_MarksFailed_NoRecoveryEntry()
    {
        var started = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => BlockUntilShutdownLifecycle(ctx, started, ct),
        };

        using var factory = NewNonResilientHost(handler);
        using var client = factory.CreateClient();

        // Foreground (non-background) request: the POST completes only when the handler reaches a
        // terminal state, so drive it on a background task and cancel it via shutdown.
        var postTask = client.PostAsync("/responses",
            new StringContent(JsonSerializer.Serialize(new { model = "test-model" }),
                Encoding.UTF8, "application/json"));

        await started.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // G1 / Row 3 §6: a foreground stored response now runs inside a Core one-shot task, so a
        // recovery entry exists while the handler is in-flight (previously the foreground path ran
        // inline and left no task entry, so a true crash could not be recovered). This is what makes
        // Path C (mark-failed next lifetime) possible for foreground.
        await WaitForRecoveryEntryCountAsync(1,
            "a foreground stored response must be task-tracked while the handler is in-flight");

        await factory.StopAsync();

        var post = await postTask.WaitAsync(TimeSpan.FromSeconds(10));
        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"),
            "a foreground response terminated by shutdown must be marked failed");
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("code").GetString(),
            Is.EqualTo("server_error"));
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("shutdown_reason").GetString(),
            Is.EqualTo("grace_exhausted"),
            "Row 3 foreground shutdown mark-failed must carry shutdown_reason=grace_exhausted");
        // Row 3 foreground stored responses are now tracked by a Core one-shot task while in-flight
        // (so a crash — Path C — can mark them failed in the next lifetime, parity with Python
        // responses-resilience-spec §6). On this graceful shutdown (Path B) the engine removes the
        // record as the task finalizes; assert the terminal steady state: no lingering entry.
        await WaitForRecoveryEntryCountAsync(0,
            "a foreground row must not leave a recovery entry after graceful shutdown");
    }

    [Test]
    public async Task Row2PathA_BackgroundCompletesNaturally_Completed_NoRecoveryEntry()
    {
        // Row 2 Path A: a non-resilient background stored response whose handler reaches a natural
        // terminal within grace. It must end `completed` and, because the Core one-shot task
        // finalizes, leave no lingering recovery entry (no next-lifetime action).
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => FastCompletingLifecycle(ctx, ct),
        };

        using var factory = NewNonResilientHost(handler);
        using var client = factory.CreateClient();

        var responseId = await CreateBackgroundAsync(client, stream: false);
        await WaitForStatusAsync(client, responseId, "completed");

        var get = await client.GetAsync($"/responses/{responseId}");
        using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"),
            "Row 2 Path A (natural terminal) must complete successfully");
        Assert.That(doc.RootElement.TryGetProperty("error", out var err) && err.ValueKind != JsonValueKind.Null,
            Is.False, "a naturally completed response must carry no error");
        await WaitForRecoveryEntryCountAsync(0,
            "a naturally completed background row must not leave a recovery entry");
    }

    [Test]
    public async Task Row3PathA_ForegroundCompletesNaturally_Completed_NoRecoveryEntry()
    {
        // Row 3 Path A: a foreground stored response whose handler reaches a natural terminal. The
        // POST returns the FINAL `completed` response inline and the task-tracked entry is cleared.
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => FastCompletingLifecycle(ctx, ct),
        };

        using var factory = NewNonResilientHost(handler);
        using var client = factory.CreateClient();

        var post = await client.PostAsync("/responses",
            new StringContent(JsonSerializer.Serialize(new { model = "test-model" }),
                Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var responseId = doc.RootElement.GetProperty("id").GetString()!;
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"),
            "Row 3 Path A (natural terminal) must return the final completed response inline");

        // The stored response remains retrievable and the task-tracked recovery entry is cleared.
        var get = await client.GetAsync($"/responses/{responseId}");
        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "a foreground stored response must remain retrievable after completion");
        await WaitForRecoveryEntryCountAsync(0,
            "a naturally completed foreground row must not leave a recovery entry");
    }

    [Test]
    public async Task Row4StoreFalse_Ephemeral_Get404_NoRecoveryEntry()
    {
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => FastCompletingLifecycle(ctx, ct),
        };

        using var factory = NewNonResilientHost(handler);
        using var client = factory.CreateClient();

        var post = await client.PostAsync("/responses",
            new StringContent(JsonSerializer.Serialize(new { model = "test-model", store = false }),
                Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var responseId = doc.RootElement.GetProperty("id").GetString()!;
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));

        // store=false → nothing durable: GET is a definitive not-found and no recovery entry exists.
        var get = await client.GetAsync($"/responses/{responseId}");
        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
            "an unstored (store=false) response must not be retrievable");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0),
            "an unstored response must never write a recovery entry (no next-lifetime action)");
    }

    private TestWebApplicationFactory NewNonResilientHost(TestHandler handler)
        => new(
            handler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(new FileResponsesProvider(ResponsesDir));
                TestEventStreams.UseFileBacked(services, ResponsesDir);
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(TasksDir));
            });

    private static async Task<string> CreateBackgroundAsync(HttpClient client, bool stream)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test-model", background = true, stream }),
                Encoding.UTF8, "application/json"),
        };

        if (!stream)
        {
            var post = await client.SendAsync(request);
            Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
            return doc.RootElement.GetProperty("id").GetString()!;
        }

        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        await using var body = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(body);
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

    private static async IAsyncEnumerable<ResponseStreamEvent> FastCompletingLifecycle(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();
        await Task.Yield();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockUntilShutdownLifecycle(
        ResponseContext ctx,
        TaskCompletionSource started,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();
        started.TrySetResult();

        var tcs = new TaskCompletionSource();
        using (ct.Register(() => tcs.TrySetResult()))
        {
            await tcs.Task;
        }

        // Non-cooperative on the terminal boundary: throw on cancellation so the framework applies the
        // row's fail semantics (Row 2/3 → failed).
        ct.ThrowIfCancellationRequested();
        yield return stream.EmitCompleted();
    }
}
