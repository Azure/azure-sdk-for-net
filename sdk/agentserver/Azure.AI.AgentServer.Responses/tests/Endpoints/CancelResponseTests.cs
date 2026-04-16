// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Endpoints;

public class CancelResponseTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CancelResponseTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Cancel_UnknownId_Returns404()
    {
        var response = await _client.PostAsync($"/responses/{IdGenerator.NewResponseId()}/cancel", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(body.GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task Cancel_CompletedNonBgResponse_Returns400()
    {
        // Create a response first (default mode — completes immediately, non-background)
        var createBody = JsonSerializer.Serialize(new { model = "test" });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Cancel a non-background response → 400 (per B1: non-bg cannot be cancelled)
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var cancelBody = await cancelResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(cancelBody.GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("synchronous", cancelBody.GetProperty("error").GetProperty("message").GetString());
    }

    [Test]
    public async Task Cancel_BackgroundInFlight_ReturnsCancelledResponse()
    {
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => InfiniteEventStream(ctx, tcs, ct);

        // Create background response
        var createBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Cancel it
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Let the handler observe cancellation
        tcs.SetResult();
        await Task.Delay(100);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> InfiniteEventStream(
        ResponseContext ctx,
        TaskCompletionSource tcs,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);

        var cancelled = false;
        try
        {
            await tcs.Task.WaitAsync(ct);
        }
        catch (OperationCanceledException)
        {
            cancelled = true;
        }

        if (cancelled)
        {
            response.SetIncomplete();
            yield return new ResponseIncompleteEvent(0, response);
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
