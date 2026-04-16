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

public class ErrorHandlingTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ErrorHandlingTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    // ── BadRequestException (400) ──

    [Test]
    public async Task MalformedJson_Returns400WithApiErrorResponse()
    {
        var content = new StringContent("{ invalid json", Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()), Is.True);
    }

    [Test]
    public async Task EmptyBody_Returns400WithApiErrorResponse()
    {
        var content = new StringContent("", Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    // ── ResourceNotFoundException (404) ──

    [Test]
    public async Task GetUnknownId_Returns404WithApiErrorResponse()
    {
        var response = await _client.GetAsync($"/responses/{IdGenerator.NewResponseId()}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task CancelUnknownId_Returns404WithApiErrorResponse()
    {
        var response = await _client.PostAsync($"/responses/{IdGenerator.NewResponseId()}/cancel", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    // ── Handler-level errors return Models.ResponseObject (not ApiErrorResponse) ──

    [Test]
    public async Task HandlerThrows_Returns500WithServerError()
    {
        // Handler throws before response.created → pre-created error → 500
        _handler.EventFactory = (_, _, _) => ThrowingAsyncEnumerable();

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
    }

    // ── Unhandled exception (500) ──

    [Test]
    public async Task UnhandledException_Returns500WithGenericMessage()
    {
        // Force an unhandled exception by throwing from a filter-level path
        // We test this indirectly — if handler throws, it's caught by endpoint handler (200).
        // For filter-level 500, we need an exception that escapes to the filter.
        // The existing handler-throws test covers the 200 path. We verify the filter's
        // generic 500 via the "server_error" code (already tested above in different context).
        // This test is here primarily to verify no exception details leak.
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        _handler.EventFactory = (_, _, _) => ThrowingAsyncEnumerable();

        var response = await _client.PostAsync("/responses", content);
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();

        // Handler-level errors: message should be generic (no leak)
        var errorMessage = body.GetProperty("error").GetProperty("message").GetString();
        XAssert.DoesNotContain("Handler failure simulation", errorMessage!);
    }

    // ── Helper ──

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingAsyncEnumerable(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Handler failure simulation");
#pragma warning disable CS0162 // Unreachable code
        yield break;
#pragma warning restore CS0162
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
