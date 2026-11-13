// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for streaming+background mode (stream=true, background=true).
/// All assertions use HttpClient + JsonDocument + SseParser only.
/// </summary>
public class StreamingBackgroundModeProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_StreamBackground_Returns_SseStream()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true, background = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var events = await ParseSseAsync(response);
        Assert.That(events.Count >= 2, Is.True, "Expected at least 2 SSE events");
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task POST_Responses_StreamBackground_HandlerContinuesAfterDisconnect()
    {
        var tcs = new TaskCompletionSource();
        var handlerStarted = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => BackgroundContinuationStream(ctx, tcs, handlerStarted, ct);

        // Use ResponseHeadersRead so we don't wait for the full body
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true, background = true }),
                Encoding.UTF8, "application/json")
        };

        using var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        // Wait for the handler to start
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Read the first SSE event to get the response ID
        await using var bodyStream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(bodyStream);

        string? responseId = null;
        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            if (line.StartsWith("data: "))
            {
                using var doc = JsonDocument.Parse(line["data: ".Length..]);
                if (doc.RootElement.TryGetProperty("response", out var respProp))
                {
                    responseId = respProp.GetProperty("id").GetString();
                    break;
                }
            }
        }

        Assert.That(responseId, Is.Not.Null);

        // Let the handler finish in background
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId!);

        // GET should show completed — handler continued after streaming
        var getResponse = await GetResponseAsync(responseId!);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BackgroundContinuationStream(
        ResponseContext ctx,
        TaskCompletionSource tcs,
        TaskCompletionSource handlerStarted,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        handlerStarted.TrySetResult();

        // Wait for signal — in background mode, cancellation token is NOT linked
        // to client disconnect, so handler continues running
        await tcs.Task;

        yield return stream.EmitCompleted();
    }
}
