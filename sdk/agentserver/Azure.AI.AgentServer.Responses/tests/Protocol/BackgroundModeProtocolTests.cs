// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for background mode (stream=false, background=true).
/// All assertions use HttpClient + JsonDocument only — no SDK model types in assertions.
/// </summary>
public class BackgroundModeProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_Background_Returns200_Immediately()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var response = await PostResponsesAsync(new { model = "test", background = true });

        // Should return immediately even though handler hasn't finished
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        // Clean up — let handler finish
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(
            (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetString()!);
    }

    [Test]
    public async Task POST_Responses_Background_Returns_InProgressStatus()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var response = await PostResponsesAsync(new { model = "test", background = true });

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(
            doc.RootElement.GetProperty("id").GetString()!);
    }

    [Test]
    public async Task POST_Responses_Background_GET_ReturnsCompletedAfterWait()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Let the handler finish
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);

        // GET should now return completed
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStream(
        ResponseContext ctx,
        Task waitTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        await waitTask.WaitAsync(ct);

        yield return stream.EmitCompleted();
    }
}
