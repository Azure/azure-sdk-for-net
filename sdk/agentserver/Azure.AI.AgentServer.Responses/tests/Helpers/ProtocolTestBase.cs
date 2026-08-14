// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Base class for protocol conformance tests. Provides a TestServer, HttpClient,
/// and configurable TestHandler, plus helper methods that send raw HTTP requests
/// and parse responses using only System.Text.Json (black-box assertions).
/// </summary>
public abstract class ProtocolTestBase : IDisposable
{
    protected readonly TestHandler Handler;
    protected readonly TestWebApplicationFactory Factory;
    protected readonly HttpClient Client;

    protected ProtocolTestBase(Action<ResponsesServerOptions>? configureOptions = null)
    {
        Handler = new TestHandler();
        Factory = new TestWebApplicationFactory(Handler, configureOptions);
        Client = Factory.CreateClient();
    }

    /// <summary>
    /// Sends a POST /responses with the given JSON body string
    /// and returns the raw HttpResponseMessage.
    /// </summary>
    protected Task<HttpResponseMessage> PostResponsesAsync(string jsonBody)
    {
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        return Client.PostAsync("/responses", content);
    }

    /// <summary>
    /// Sends a POST /responses with an anonymous object serialized to JSON.
    /// </summary>
    protected Task<HttpResponseMessage> PostResponsesAsync(object requestObj)
    {
        var json = JsonSerializer.Serialize(requestObj);
        return PostResponsesAsync(json);
    }

    /// <summary>
    /// Sends a GET /responses/{id} and returns the raw HttpResponseMessage.
    /// Optionally sets the Accept header.
    /// </summary>
    protected Task<HttpResponseMessage> GetResponseAsync(string responseId, string? accept = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/responses/{responseId}");
        if (accept is not null)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
        }

        return Client.SendAsync(request);
    }

    /// <summary>
    /// Sends a GET /responses/{id}?stream=true and returns the raw HttpResponseMessage.
    /// Uses the <c>stream</c> query parameter (not the Accept header) to trigger SSE replay.
    /// </summary>
    protected Task<HttpResponseMessage> GetResponseStreamAsync(string responseId)
    {
        return Client.GetAsync($"/responses/{responseId}?stream=true");
    }

    /// <summary>
    /// Sends a POST /responses/{id}/cancel and returns the raw HttpResponseMessage.
    /// </summary>
    protected Task<HttpResponseMessage> CancelResponseAsync(string responseId)
    {
        return Client.PostAsync($"/responses/{responseId}/cancel", null);
    }

    /// <summary>
    /// Reads the response body as a JsonDocument for assertion.
    /// </summary>
#pragma warning disable AZC0014 // JsonDocument is appropriate for test assertion helpers
    protected static async Task<JsonDocument> ParseJsonAsync(HttpResponseMessage response)
#pragma warning restore AZC0014
    {
        var body = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(body);
    }

    /// <summary>
    /// Reads the response body as raw string and parses SSE events.
    /// </summary>
    protected static async Task<List<SseEvent>> ParseSseAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        return SseParser.Parse(body);
    }

    /// <summary>
    /// Creates a default (non-streaming, non-background) response and returns the response ID.
    /// </summary>
    protected async Task<string> CreateDefaultResponseAsync(string model = "test")
    {
        var httpResponse = await PostResponsesAsync(new { model });
        using var doc = await ParseJsonAsync(httpResponse);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Creates a streaming response and returns the response ID
    /// extracted from the first SSE event.
    /// </summary>
    protected async Task<string> CreateStreamingResponseAsync(string model = "test")
    {
        var httpResponse = await PostResponsesAsync(new { model, stream = true });
        var events = await ParseSseAsync(httpResponse);
        using var doc = JsonDocument.Parse(events[0].Data);
        return doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Creates a background response and returns the response ID.
    /// </summary>
    protected async Task<string> CreateBackgroundResponseAsync(string model = "test")
    {
        var httpResponse = await PostResponsesAsync(new { model, background = true });
        using var doc = await ParseJsonAsync(httpResponse);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Creates a background streaming response and returns the response ID
    /// extracted from the first SSE event.
    /// </summary>
    protected async Task<string> CreateBackgroundStreamingResponseAsync(string model = "test")
    {
        var httpResponse = await PostResponsesAsync(new { model, stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var doc = JsonDocument.Parse(events[0].Data);
        return doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Polls GET /responses/{id} until the response reaches a terminal status or timeout.
    /// Handles 404 responses gracefully (response not yet created by handler).
    /// </summary>
    protected async Task WaitForBackgroundCompletionAsync(string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await GetResponseAsync(responseId);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Models.ResponseObject not yet created (handler hasn't yielded response.created yet)
                await Task.Delay(50);
                continue;
            }
            using var doc = await ParseJsonAsync(response);
            if (!doc.RootElement.TryGetProperty("status", out var statusProp))
            {
                await Task.Delay(50);
                continue;
            }
            var status = statusProp.GetString();
            if (status is "completed" or "failed" or "incomplete" or "cancelled")
            {
                return;
            }
            await Task.Delay(50);
        }
    }

    /// <summary>
    /// Polls an async factory until the predicate is satisfied or timeout (default 5s).
    /// Returns the last result. Useful for waiting on eventual state changes (e.g., 404 after cleanup).
    /// </summary>
    protected async Task<T> PollUntilAsync<T>(
        Func<Task<T>> factory,
        Func<T, bool> predicate,
        TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));
        T result = default!;
        while (DateTimeOffset.UtcNow < deadline)
        {
            result = await factory();
            if (predicate(result))
                return result;
            await Task.Delay(50);
        }
        return result;
    }

    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}
