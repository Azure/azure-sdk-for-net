// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable OPENAI001 // Responses API is experimental in the OpenAI SDK

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// End-to-end tests that validate the streaming and non-streaming proxy patterns.
///
///   Test (raw HTTP) ──▶ Server A (proxy handler via OpenAI SDK) ──▶ Mock backend
///
/// The mock backend returns a hard-coded "Hello, World!" SSE stream (streaming)
/// or JSON response (non-streaming). Server A's handler calls the mock via the
/// OpenAI .NET SDK <see cref="ResponsesClient"/>, translates the models using
/// <see cref="WireFormatExtensions.Translate{T}"/>, and streams back to the test.
/// Tests use properly-structured input items (type=message with role/content) to
/// exercise the full validation pipeline, including the ItemMessageValidator.
/// </summary>
[TestFixture]
public class OpenAIProxyEndToEndTests
{
    [Test]
    public async Task StreamingProxy_FullRoundTrip_ReturnsHelloWorld()
    {
        using var mockBackend = new HttpClient(new MockStreamingBackendHandler());
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                var upstream = new ResponsesClient(
                    new ApiKeyCredential("unused-key"),
                    new OpenAIClientOptions
                    {
                        Endpoint = new Uri("http://mock-backend"),
                        Transport = new HttpClientPipelineTransport(mockBackend),
                    });
                services.AddSingleton(upstream);
                services.AddSingleton<ResponseHandler, StreamingProxyHandler>();
            });
        using var client = factory.CreateClient();

        // Structured input items (type=message) — exercises full ItemMessageValidator
        var json = """
            {
                "model": "test-model",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "Say hello" }]
                    }
                ],
                "stream": true
            }
            """;
        var response = await client.PostAsync("/responses", new StringContent(json, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var events = SseParser.Parse(body);

        // Look for the text delta event containing our message
        var deltaEvents = events
            .Where(e => e.EventType == "response.output_text.delta")
            .ToList();

        var fullText = string.Join("", deltaEvents.Select(e =>
        {
            using var doc = JsonDocument.Parse(e.Data);
            return doc.RootElement.GetProperty("delta").GetString();
        }));

        Assert.That(fullText, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public async Task NonStreamingProxy_FullRoundTrip_ReturnsHelloWorld()
    {
        using var mockBackend = new HttpClient(new MockNonStreamingBackendHandler());
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                var upstream = new ResponsesClient(
                    new ApiKeyCredential("unused-key"),
                    new OpenAIClientOptions
                    {
                        Endpoint = new Uri("http://mock-backend"),
                        Transport = new HttpClientPipelineTransport(mockBackend),
                    });
                services.AddSingleton(upstream);
                services.AddSingleton<ResponseHandler, NonStreamingProxyHandler>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test-model",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "Say hello" }]
                    }
                ]
            }
            """;
        var response = await client.PostAsync("/responses", new StringContent(json, Encoding.UTF8, "application/json"));

        // Default mode returns JSON (the SDK streams under the hood, then produces JSON)
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        // The response is JSON containing the completed response object
        using var doc = JsonDocument.Parse(body);
        var root = doc.RootElement;

        // Verify the model and output
        Assert.That(root.GetProperty("model").GetString(), Is.EqualTo("test-model"));
        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));

        var outputItems = root.GetProperty("output");
        Assert.That(outputItems.GetArrayLength(), Is.GreaterThan(0));
    }

    [Test]
    public async Task StreamingProxy_PreservesModel()
    {
        using var mockBackend = new HttpClient(new MockStreamingBackendHandler());
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                var upstream = new ResponsesClient(
                    new ApiKeyCredential("unused-key"),
                    new OpenAIClientOptions
                    {
                        Endpoint = new Uri("http://mock-backend"),
                        Transport = new HttpClientPipelineTransport(mockBackend),
                    });
                services.AddSingleton(upstream);
                services.AddSingleton<ResponseHandler, StreamingProxyHandler>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "my-custom-model",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "test" }]
                    }
                ],
                "stream": true
            }
            """;
        var response = await client.PostAsync("/responses", new StringContent(json, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var events = SseParser.Parse(body);

        // The response.completed event should carry the model
        var completedEvent = events.FirstOrDefault(e => e.EventType == "response.completed");
        Assert.That(completedEvent, Is.Not.Null);

        using var doc = JsonDocument.Parse(completedEvent!.Data);
        var responseObj = doc.RootElement.GetProperty("response");
        Assert.That(responseObj.GetProperty("model").GetString(), Is.EqualTo("my-custom-model"));
    }

    // ── Handlers ──

    /// <summary>
    /// Streaming proxy handler: forwards to upstream using OpenAI SDK with streaming,
    /// translating events both ways via <see cref="WireFormatExtensions.Translate{T}"/>.
    /// </summary>
    private sealed class StreamingProxyHandler : ResponseHandler
    {
        private readonly ResponsesClient _upstream;
        public StreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

        public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
            CreateResponse request,
            ResponseContext context,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var options = new CreateResponseOptions
            {
                Model = request.Model,
                Instructions = request.Instructions,
                StreamingEnabled = true,
            };

            foreach (Item item in request.GetInputExpanded())
            {
                options.InputItems.Add(item.Translate().To<ResponseItem>());
            }

            var stream = new ResponseEventStream(context, request);
            yield return stream.EmitCreated();
            yield return stream.EmitInProgress();

            var message = stream.AddOutputItemMessage();
            yield return message.EmitAdded();

            var text = message.AddTextContent();
            yield return text.EmitAdded();

            // Collect all text from upstream streaming updates
            var fullText = new StringBuilder();
            await foreach (StreamingResponseUpdate update in
                _upstream.CreateResponseStreamingAsync(options, cancellationToken))
            {
                if (update is StreamingResponseOutputTextDeltaUpdate delta)
                {
                    fullText.Append(delta.Delta);
                    yield return text.EmitDelta(delta.Delta);
                }
            }

            var resultText = fullText.ToString();
            yield return text.EmitDone(resultText);
            yield return message.EmitContentDone(text);
            yield return message.EmitDone();
            yield return stream.EmitCompleted();
        }
    }

    /// <summary>
    /// Non-streaming proxy handler: calls upstream without streaming, then builds
    /// a standard SSE event stream from the completed output items.
    /// </summary>
    private sealed class NonStreamingProxyHandler : ResponseHandler
    {
        private readonly ResponsesClient _upstream;
        public NonStreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

        public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
            CreateResponse request,
            ResponseContext context,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var options = new CreateResponseOptions
            {
                Model = request.Model,
                Instructions = request.Instructions,
            };

            foreach (Item item in request.GetInputExpanded())
            {
                options.InputItems.Add(item.Translate().To<ResponseItem>());
            }

            var result = await _upstream.CreateResponseAsync(options, cancellationToken);

            // Build our response event stream from the upstream result
            var stream = new ResponseEventStream(context, request);
            yield return stream.EmitCreated();
            yield return stream.EmitInProgress();

            // Extract text content from the upstream response
            var outputText = result.Value.GetOutputText();

            var message = stream.AddOutputItemMessage();
            yield return message.EmitAdded();

            var text = message.AddTextContent();
            yield return text.EmitAdded();
            yield return text.EmitDone(outputText ?? string.Empty);
            yield return message.EmitContentDone(text);
            yield return message.EmitDone();

            yield return stream.EmitCompleted();
        }
    }

    // ── Mock backend handlers ──

    /// <summary>
    /// Mock HTTP handler that returns a canned SSE stream matching
    /// the OpenAI Responses streaming format with a "Hello, World!" message.
    /// </summary>
    private sealed class MockStreamingBackendHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Build SSE events matching the OpenAI Responses streaming protocol
            var sb = new StringBuilder();

            AppendSseEvent(sb, "response.created",
                """{"type":"response.created","response":{"id":"resp_mock_001","object":"response","status":"in_progress","model":"test-model","output":[]}}""");

            AppendSseEvent(sb, "response.in_progress",
                """{"type":"response.in_progress","response":{"id":"resp_mock_001","object":"response","status":"in_progress","model":"test-model","output":[]}}""");

            AppendSseEvent(sb, "response.output_item.added",
                """{"type":"response.output_item.added","output_index":0,"item":{"id":"msg_mock_001","type":"message","role":"assistant","status":"in_progress","content":[]}}""");

            AppendSseEvent(sb, "response.content_part.added",
                """{"type":"response.content_part.added","item_id":"msg_mock_001","output_index":0,"content_index":0,"part":{"type":"output_text","text":""}}""");

            AppendSseEvent(sb, "response.output_text.delta",
                """{"type":"response.output_text.delta","item_id":"msg_mock_001","output_index":0,"content_index":0,"delta":"Hello, World!"}""");

            AppendSseEvent(sb, "response.output_text.done",
                """{"type":"response.output_text.done","item_id":"msg_mock_001","output_index":0,"content_index":0,"text":"Hello, World!"}""");

            AppendSseEvent(sb, "response.content_part.done",
                """{"type":"response.content_part.done","item_id":"msg_mock_001","output_index":0,"content_index":0,"part":{"type":"output_text","text":"Hello, World!"}}""");

            AppendSseEvent(sb, "response.output_item.done",
                """{"type":"response.output_item.done","output_index":0,"item":{"id":"msg_mock_001","type":"message","role":"assistant","status":"completed","content":[{"type":"output_text","text":"Hello, World!"}]}}""");

            AppendSseEvent(sb, "response.completed",
                """{"type":"response.completed","response":{"id":"resp_mock_001","object":"response","status":"completed","model":"test-model","output":[{"id":"msg_mock_001","type":"message","role":"assistant","status":"completed","content":[{"type":"output_text","text":"Hello, World!"}]}]}}""");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(sb.ToString(), Encoding.UTF8, "text/event-stream")
            };

            return Task.FromResult(httpResponse);
        }

        private static void AppendSseEvent(StringBuilder sb, string eventType, string data)
        {
            sb.Append("event: ").AppendLine(eventType);
            sb.Append("data: ").AppendLine(data.Trim());
            sb.AppendLine();
        }
    }

    /// <summary>
    /// Mock HTTP handler that returns a canned JSON response matching
    /// the OpenAI Responses non-streaming format with a "Hello, World!" message.
    /// </summary>
    private sealed class MockNonStreamingBackendHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            const string responseJson = """
                {
                    "id": "resp_mock_002",
                    "object": "response",
                    "status": "completed",
                    "model": "test-model",
                    "output": [
                        {
                            "id": "msg_mock_002",
                            "type": "message",
                            "role": "assistant",
                            "status": "completed",
                            "content": [
                                {
                                    "type": "output_text",
                                    "text": "Hello, World!"
                                }
                            ]
                        }
                    ],
                    "usage": {
                        "input_tokens": 10,
                        "output_tokens": 5,
                        "total_tokens": 15
                    }
                }
                """;

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(httpResponse);
        }
    }
}
