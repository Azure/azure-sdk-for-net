// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 1 graceful-shutdown termination paths (US4). Row 1 = <c>store=true</c>, <c>background=true</c>
/// with <c>ResilientBackground=true</c>. The two in-grace paths are exercised with a real host
/// shutdown (<see cref="TestWebApplicationFactory.StopAsync"/> = SIGTERM analog):
/// <list type="bullet">
/// <item><b>Path A</b> (SIGTERM, long grace) — the handler reaches a natural terminal within the
/// grace window; the response is <c>completed</c> and the acceptance-time recovery entry is cleared.</item>
/// <item><b>Path B</b> (SIGTERM, short grace) — grace expires with the handler still running; the
/// framework hands the in-flight Row 1 handler to next-lifetime recovery (FR-014): the response stays
/// <c>in_progress</c> (NOT <c>failed</c>) and the recovery entry is retained so a restarted sandbox
/// re-invokes it.</item>
/// </list>
/// Parameterized over non-streaming and streaming acceptance. Real OS signals are not used because
/// recovery is a single-process / single-sandbox concern; <c>StopAsync</c> drives the same
/// <see cref="Microsoft.Extensions.Hosting.IHostedService.StopAsync"/> graceful-shutdown loop that a
/// SIGTERM triggers in production.
/// </summary>
[NonParallelizable]
public sealed class TestRow1PathABSignalTests : CrashRecoveryE2ETestBase
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task Row1PathA_HandlerReachesTerminalWithinGrace_Completes(bool stream)
    {
        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => FastCompletingLifecycle(ctx, completed, ct),
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        var responseId = await CreateRow1BackgroundAsync(client, stream);

        // The handler completes on its own well within grace; a subsequent SIGTERM (StopAsync) is a
        // no-op for this already-terminal response.
        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");
        await factory.StopAsync();

        await WaitForStatusAsync(client, responseId, "completed");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0),
            "a naturally-terminal Row 1 response must clear its recovery entry");
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task Row1PathB_GraceExhausted_HandsOffToRecovery_StaysInProgress(bool stream)
    {
        var started = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => BlockUntilShutdownLifecycle(ctx, started, ct),
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        var responseId = await CreateRow1BackgroundAsync(client, stream);
        await started.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // SIGTERM with the handler still running: grace expires (the handler cooperatively unwinds on
        // cancellation but never reaches a terminal event). Row 1 must hand off to recovery.
        await factory.StopAsync();

        // The response must remain in_progress (NOT failed) so the next lifetime re-invokes it, and
        // the acceptance-time recovery entry must be retained.
        await WaitForStatusAsync(client, responseId, "in_progress");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Row 1 Path B must retain the recovery entry for next-lifetime re-invocation");

        // The durable record must not carry an error (a deferral is not a failure).
        var get = await client.GetAsync($"/responses/{responseId}");
        using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("error").ValueKind, Is.EqualTo(JsonValueKind.Null),
            "a Row 1 Path B deferral must not populate response.error");
    }

    private static async Task<string> CreateRow1BackgroundAsync(HttpClient client, bool stream)
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

        // Background streaming keeps the POST SSE stream open until the handler completes; read only
        // headers + the first data line carrying the response id to avoid deadlocking on the body.
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
        TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();
        await Task.Yield();
        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockUntilShutdownLifecycle(
        ResponseContext ctx,
        TaskCompletionSource started,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test-model" });
        yield return stream.EmitCreated();
        started.TrySetResult();

        // Park at a safe boundary until shutdown cancels the token, then unwind cooperatively without
        // emitting a terminal event — the framework's Row 1 Path B dispatch leaves the response
        // in_progress for next-lifetime recovery.
        var tcs = new TaskCompletionSource();
        using (ct.Register(() => tcs.TrySetResult()))
        {
            await tcs.Task;
        }

        ct.ThrowIfCancellationRequested();
        yield return stream.EmitCompleted();
    }
}
