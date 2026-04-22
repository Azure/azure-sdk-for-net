// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Cache;

public class CacheIntegrationTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CacheIntegrationTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Create_ThenGet_WithinTtl_ReturnsResponse()
    {
        // Create a response
        var createBody = JsonSerializer.Serialize(new { model = "test" });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // GET the response within TTL
        var getResponse = await _client.GetAsync($"/responses/{responseId}");

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await getResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public async Task BackgroundCreate_ThenGet_ShowsInProgress()
    {
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => WaitingEventStream(ctx, tcs.Task, ct);

        // Create a background response
        var createBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // GET should show in_progress
        var getResponse = await _client.GetAsync($"/responses/{responseId}");
        var body = await getResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

        // Let the handler complete
        tcs.SetResult();

        // Poll until status reaches completed
        JsonElement body2 = default;
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline)
        {
            var getResponse2 = await _client.GetAsync($"/responses/{responseId}");
            body2 = await getResponse2.Content.ReadFromJsonAsync<JsonElement>();
            if (body2.GetProperty("status").GetString() is "completed" or "failed" or "incomplete" or "cancelled")
                break;
            await Task.Delay(50);
        }
        Assert.That(body2.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public async Task Get_UnknownId_Returns404()
    {
        var response = await _client.GetAsync($"/responses/{IdGenerator.NewResponseId()}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
