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

        Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.AreEqual("application/json", httpResponse.Content.Headers.ContentType?.MediaType);

        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.IsTrue(body.TryGetProperty("id", out var id));
        XAssert.StartsWith("caresp_", id.GetString());
        Assert.AreEqual("test-model", body.GetProperty("model").GetString());
    }

    [Test]
    public async Task DefaultMode_StreamAndBackgroundFlagsPreserved()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model", stream = false, background = false });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.IsNotNull(_handler.LastRequest);
        Assert.IsFalse(_handler.LastRequest.Stream);
        Assert.IsFalse(_handler.LastRequest.Background);
    }

    [Test]
    public async Task DefaultMode_ResponseHasCorrectStatus()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        var status = body.GetProperty("status").GetString();
        Assert.AreEqual("completed", status);
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

        Assert.AreEqual(5, ids.Count);
    }

    [Test]
    public async Task DefaultMode_HandlerThrows_Returns200WithFailedStatus()
    {
        _handler.EventFactory = (_, ctx, _) => ThrowAfterFirstEvent(ctx.ResponseId);

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        // Handler exceptions during processing are caught and set response status to failed
        Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        var body = await httpResponse.Content.ReadFromJsonAsync<JsonElement>();
        Assert.AreEqual("failed", body.GetProperty("status").GetString());
        Assert.AreEqual("server_error", body.GetProperty("error").GetProperty("code").GetString());
    }

    [Test]
    public async Task DefaultMode_HandlerReceivesContext()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.IsNotNull(_handler.LastContext);
        XAssert.StartsWith("caresp_", _handler.LastContext.ResponseId);
    }

    [Test]
    public async Task DefaultMode_ModelPassedThrough()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "gpt-4.1" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.AreEqual("gpt-4.1", _handler.LastRequest?.Model);
    }

    [Test]
    public async Task EmptyBody_Returns400()
    {
        var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        var httpResponse = await _client.PostAsync("/responses", content);

        Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
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

        Assert.AreEqual(expectedPk, actualPk);
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

        Assert.AreEqual(expectedPk, actualPk);
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

        Assert.AreNotEqual(pk1, pk2);
        XAssert.StartsWith("caresp_", responseId1);
        XAssert.StartsWith("caresp_", responseId2);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterFirstEvent(
        string responseId,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new ResponseCreatedEvent(0, new Models.Response(responseId, "test-model"));
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
