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

public class CreateResponseTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CreateResponseTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task DefaultMode_ValidRequest_ReturnsResponseJson()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(httpResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.TryGetProperty("id", out var id), Is.True);
        XAssert.StartsWith("caresp_", id.GetString());
        Assert.That(body.GetProperty("model").GetString(), Is.EqualTo("test-model"));
        Assert.That(body.GetProperty("object").GetString(), Is.EqualTo("response"),
            "POST /responses must return 'object': 'response'");
    }

    [Test]
    public async Task DefaultMode_StreamAndBackgroundFlagsPreserved()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model", stream = false, background = false });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.That(_handler.LastRequest, Is.Not.Null);
        Assert.That(_handler.LastRequest.Stream, Is.False);
        Assert.That(_handler.LastRequest.Background, Is.False);
    }

    [Test]
    public async Task DefaultMode_ResponseHasCorrectStatus()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        var status = body.GetProperty("status").GetString();
        Assert.That(status, Is.EqualTo("completed"));
    }

    [Test]
    public async Task DefaultMode_ResponseIdIsUnique()
    {
        var ids = new HashSet<string>();
        for (int i = 0; i < 5; i++)
        {
            var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync("/responses", content);
            var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
            ids.Add(body.GetProperty("id").GetString()!);
        }

        Assert.That(ids.Count, Is.EqualTo(5));
    }

    [Test]
    public async Task DefaultMode_HandlerThrows_Returns200WithFailedStatus()
    {
        _handler.EventFactory = (_, ctx, _) => ThrowAfterFirstEvent(ctx.ResponseId);

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        // Handler exceptions during processing are caught and set response status to failed
        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(body.GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("server_error"));
    }

    [Test]
    public async Task DefaultMode_HandlerReceivesContext()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.That(_handler.LastContext, Is.Not.Null);
        XAssert.StartsWith("caresp_", _handler.LastContext.ResponseId);
    }

    [Test]
    public async Task DefaultMode_ModelPassedThrough()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "gpt-4.1" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.That(_handler.LastRequest?.Model, Is.EqualTo("gpt-4.1"));
    }

    [Test]
    public async Task EmptyBody_Returns400()
    {
        var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ── T022: Partition key from previous_response_id propagates ──

    [Test]
    public async Task DefaultMode_PreviousResponseId_PropagatesPartitionKey()
    {
        // Generate a response ID to use as previous_response_id
        var previousId = IdGenerator.NewResponseId();
        var expectedPk = IdGenerator.ExtractPartitionKey(previousId);

        var requestBody = JsonSerializer.Serialize(new { model = "test-model", previous_response_id = previousId });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        var responseId = _handler.LastContext!.ResponseId;
        var actualPk = IdGenerator.ExtractPartitionKey(responseId);

        Assert.That(actualPk, Is.EqualTo(expectedPk));
        XAssert.StartsWith("caresp_", responseId);
    }

    // ── T023: Partition key from conversation string propagates ──

    [Test]
    public async Task DefaultMode_ConversationString_PropagatesPartitionKey()
    {
        var conversationId = IdGenerator.NewId("conv");
        var expectedPk = IdGenerator.ExtractPartitionKey(conversationId);

        var requestBody = JsonSerializer.Serialize(new { model = "test-model", conversation = conversationId });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        var responseId = _handler.LastContext!.ResponseId;
        var actualPk = IdGenerator.ExtractPartitionKey(responseId);

        Assert.That(actualPk, Is.EqualTo(expectedPk));
    }

    // ── T024: No hint → fresh partition key ──

    [Test]
    public async Task DefaultMode_NoHints_AutoGeneratesPartitionKey()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);
        var responseId1 = _handler.LastContext!.ResponseId;

        await _client.PostAsync("/responses", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        var responseId2 = _handler.LastContext!.ResponseId;

        // Two requests without hints should have different partition keys
        var pk1 = IdGenerator.ExtractPartitionKey(responseId1);
        var pk2 = IdGenerator.ExtractPartitionKey(responseId2);

        Assert.That(pk2, Is.Not.EqualTo(pk1));
        XAssert.StartsWith("caresp_", responseId1);
        XAssert.StartsWith("caresp_", responseId2);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterFirstEvent(
        string responseId,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new ResponseCreatedEvent(0, new Models.ResponseObject(responseId, "test-model"));
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
