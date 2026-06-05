// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

public class CancellationTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CancellationTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task DefaultMode_HandlerCancelled_ReturnsFailed()
    {
        _handler.EventFactory = (_, ctx, ct) => CancellingEventStream(ctx, ct);

        var requestBody = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("failed"));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CancellingEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);

        // Simulate handler throwing OperationCanceledException
        throw new OperationCanceledException();
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
