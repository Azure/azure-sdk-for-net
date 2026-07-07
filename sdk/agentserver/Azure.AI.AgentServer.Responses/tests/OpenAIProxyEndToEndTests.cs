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

using AzureMessageRole = Azure.AI.AgentServer.Responses.Models.MessageRole;
using SdkResponseStatus = OpenAI.Responses.ResponseStatus;

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
///
/// The <see cref="UpstreamIntegration_MultiOutputItem_AllRoundTrip"/> and related
/// tests validate the upstream-integration pattern (Sample 10) where:
///
///   OpenAI SDK client ──▶ Server A (handler) ──▶ Server B (rich backend)
///
/// Server B emits a multi-output stream (function call + text message).
/// Server A uses the builder API to construct output items from the upstream
/// streaming deltas — the same pattern shown in Sample 10.
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
            yield return text.EmitTextDone(resultText);
            yield return text.EmitDone();
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
            yield return text.EmitTextDone(outputText ?? string.Empty);
            yield return text.EmitDone();
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

    // ═══════════════════════════════════════════════════════════════════
    //  Upstream integration: Server A ──▶ Server B (real TestServer)
    //  Same pattern as Sample 10 — translate events, stamp response ID.
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Full end-to-end: OpenAI SDK → Server A (upstream handler) → Server B (multi-output backend).
    /// Verifies that all three output items (reasoning + function call + message)
    /// arrive at the client with correct types and content.
    /// </summary>
    [Test]
    public async Task UpstreamIntegration_MultiOutputItem_AllRoundTrip()
    {
        using var serverB = CreateServerB(EmitMultiOutput);
        var serverBClient = serverB.CreateClient();

        using var serverA = CreateServerAUpstream(serverBClient);
        var sdkClient = CreateSdkClient(serverA);

        var opts = new CreateResponseOptions { Model = "test-model" };
        opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
            [ResponseContentPart.CreateInputTextPart("What's the weather?")]));

        var result = await sdkClient.CreateResponseAsync(opts);

        // 3 output items: reasoning, function call, message
        Assert.That(result.Value.OutputItems, Has.Count.EqualTo(3));
        XAssert.IsAssignableFrom<ReasoningResponseItem>(result.Value.OutputItems[0]);

        var fc = XAssert.IsAssignableFrom<FunctionCallResponseItem>(result.Value.OutputItems[1]);
        Assert.That(fc.FunctionName, Is.EqualTo("get_weather"));
        Assert.That(fc.CallId, Is.EqualTo("call_proxy_001"));
        Assert.That(fc.FunctionArguments.ToString(), Is.EqualTo("""{"city":"Seattle"}"""));

        var msg = XAssert.IsAssignableFrom<MessageResponseItem>(result.Value.OutputItems[2]);
        Assert.That(msg.Content[0].Text, Is.EqualTo("The answer is 42."));

        Assert.That(result.Value.Status, Is.EqualTo(SdkResponseStatus.Completed));
    }

    /// <summary>
    /// Streaming variant: verifies that all streaming updates (deltas, added/done)
    /// from multiple output types arrive through the upstream integration chain.
    /// </summary>
    [Test]
    public async Task UpstreamIntegration_MultiOutputItem_Streaming_AllRoundTrip()
    {
        using var serverB = CreateServerB(EmitMultiOutput);
        var serverBClient = serverB.CreateClient();

        using var serverA = CreateServerAUpstream(serverBClient);
        var sdkClient = CreateSdkClient(serverA);

        var opts = new CreateResponseOptions { Model = "test-model", StreamingEnabled = true };
        opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
            [ResponseContentPart.CreateInputTextPart("What's the weather?")]));

        var updates = new List<StreamingResponseUpdate>();
        await foreach (var update in sdkClient.CreateResponseStreamingAsync(opts))
        {
            updates.Add(update);
        }

        // output_item.added for reasoning, function_call, message
        var addedUpdates = updates.OfType<StreamingResponseOutputItemAddedUpdate>().ToList();
        Assert.That(addedUpdates, Has.Count.EqualTo(3));

        // output_item.done for all three
        var doneUpdates = updates.OfType<StreamingResponseOutputItemDoneUpdate>().ToList();
        Assert.That(doneUpdates, Has.Count.EqualTo(3));

        // Reasoning summary deltas
        var reasoningDeltas = updates.OfType<StreamingResponseReasoningSummaryTextDeltaUpdate>().ToList();
        Assert.That(reasoningDeltas, Has.Count.GreaterThan(0));

        // Function call argument deltas
        var argDeltas = updates.OfType<StreamingResponseFunctionCallArgumentsDeltaUpdate>().ToList();
        Assert.That(argDeltas, Has.Count.GreaterThan(0));

        // Text deltas
        var textDeltas = updates.OfType<StreamingResponseOutputTextDeltaUpdate>().ToList();
        var fullText = string.Join("", textDeltas.Select(d => d.Delta));
        Assert.That(fullText, Is.EqualTo("The answer is 42."));

        // Terminal
        var completed = updates.OfType<StreamingResponseCompletedUpdate>().ToList();
        Assert.That(completed, Has.Count.EqualTo(1));
    }

    /// <summary>
    /// Verifies that input items from the client are forwarded correctly
    /// through the upstream handler to the backend. Server B captures the
    /// request and asserts on it.
    /// </summary>
    [Test]
    public async Task UpstreamIntegration_InputItems_ForwardedToBackend()
    {
        CreateResponse? capturedRequest = null;
        var backendHandler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                capturedRequest = req;
                return EmitTextOnly("ok")(req, ctx, ct);
            }
        };

        using var serverB = new TestWebApplicationFactory(backendHandler);
        var serverBClient = serverB.CreateClient();

        using var serverA = CreateServerAUpstream(serverBClient);
        var sdkClient = CreateSdkClient(serverA);

        var opts = new CreateResponseOptions
        {
            Model = "gpt-4o",
            Instructions = "Be helpful",
        };
        opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
            [ResponseContentPart.CreateInputTextPart("Hello from the proxy test")]));
        opts.InputItems.Add(ResponseItem.CreateFunctionCallItem("call_input_001", "get_data",
            BinaryData.FromString("""{"query":"test"}""")));
        opts.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem("call_input_001", "result: 42"));

        await sdkClient.CreateResponseAsync(opts);

        Assert.That(capturedRequest, Is.Not.Null);
        var items = capturedRequest!.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(3));

        // Verify the message came through
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(AzureMessageRole.User));

        // Verify function call came through
        var fc = XAssert.IsType<ItemFunctionToolCall>(items[1]);
        Assert.That(fc.Name, Is.EqualTo("get_data"));
        Assert.That(fc.CallId, Is.EqualTo("call_input_001"));

        // Verify function call output came through
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[2]);
        Assert.That(fco.CallId, Is.EqualTo("call_input_001"));
        Assert.That(fco.Output.ToString(), Is.EqualTo("\"result: 42\""));
    }

    /// <summary>
    /// Verifies that when the upstream (Server B) fails, the handler
    /// propagates the failure to the client.
    /// </summary>
    [Test]
    public async Task UpstreamIntegration_UpstreamFailed_PropagatesFailure()
    {
        using var serverB = CreateServerB(EmitFailed);
        var serverBClient = serverB.CreateClient();

        using var serverA = CreateServerAUpstream(serverBClient);
        var client = serverA.CreateClient();

        var json = """
            {
                "model": "test-model",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "trigger failure" }]
                    }
                ],
                "stream": true
            }
            """;
        var response = await client.PostAsync("/responses", new StringContent(json, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var events = SseParser.Parse(body);

        var failedEvent = events.FirstOrDefault(e => e.EventType == "response.failed");
        Assert.That(failedEvent, Is.Not.Null, "Expected a response.failed event");

        using var doc = JsonDocument.Parse(failedEvent!.Data);
        var responseObj = doc.RootElement.GetProperty("response");
        Assert.That(responseObj.GetProperty("status").GetString(), Is.EqualTo("failed"));

        var completedEvent = events.FirstOrDefault(e => e.EventType == "response.completed");
        Assert.That(completedEvent, Is.Null, "Should not have response.completed when upstream failed");
    }

    /// <summary>
    /// Verifies that Server A stamps its own response ID on all events.
    /// The upstream's response ID must not leak through.
    /// </summary>
    [Test]
    public async Task UpstreamIntegration_ResponseIds_AreIndependent()
    {
        using var serverB = CreateServerB(EmitMultiOutput);
        var serverBClient = serverB.CreateClient();

        using var serverA = CreateServerAUpstream(serverBClient);
        var client = serverA.CreateClient();

        var json = """
            {
                "model": "test-model",
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

        // response.created carries Server A's response ID (caresp_ prefix)
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(createdEvent.Data);
        var serverAId = createdDoc.RootElement.GetProperty("response").GetProperty("id").GetString();

        Assert.That(serverAId, Is.Not.Null.And.Not.Empty);
        Assert.That(serverAId, Does.StartWith("caresp_"));

        // response.completed should carry the same ID
        var completedEvent = events.First(e => e.EventType == "response.completed");
        using var completedDoc = JsonDocument.Parse(completedEvent.Data);
        var completedId = completedDoc.RootElement.GetProperty("response").GetProperty("id").GetString();
        Assert.That(completedId, Is.EqualTo(serverAId));

        // output_item.added events should carry Server A's response ID (auto-stamped)
        var itemAddedEvents = events.Where(e => e.EventType == "response.output_item.added").ToList();
        foreach (var evt in itemAddedEvents)
        {
            using var itemDoc = JsonDocument.Parse(evt.Data);
            if (itemDoc.RootElement.TryGetProperty("item", out var item) &&
                item.TryGetProperty("response_id", out var rid))
            {
                Assert.That(rid.GetString(), Is.EqualTo(serverAId),
                    "Output item response_id should match Server A's ID, not Server B's");
            }
        }
    }

    // ── Upstream integration infrastructure ──

    private static TestWebApplicationFactory CreateServerB(
        Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>> eventFactory)
    {
        return new TestWebApplicationFactory(new TestHandler { EventFactory = eventFactory });
    }

    /// <summary>
    /// Creates Server A — uses the <see cref="UpstreamIntegrationHandler"/>
    /// (same pattern as Sample 10) to forward requests to Server B.
    /// </summary>
    private static TestWebApplicationFactory CreateServerAUpstream(HttpClient serverBClient)
    {
        return new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                var upstream = new ResponsesClient(
                    new ApiKeyCredential("unused-key"),
                    new OpenAIClientOptions
                    {
                        Endpoint = new Uri("http://server-b"),
                        Transport = new HttpClientPipelineTransport(serverBClient),
                    });
                services.AddSingleton(upstream);
                services.AddSingleton<ResponseHandler, UpstreamIntegrationHandler>();
            });
    }

    private static ResponsesClient CreateSdkClient(TestWebApplicationFactory factory)
    {
        var httpClient = factory.CreateClient();
        return new ResponsesClient(
            new ApiKeyCredential("test-key"),
            new OpenAIClientOptions
            {
                Endpoint = new Uri("http://localhost"),
                Transport = new HttpClientPipelineTransport(httpClient),
            });
    }

    // ── Upstream integration handler (mirrors Sample 10) ──

    /// <summary>
    /// Translates upstream content events via ser/deser while owning the
    /// response lifecycle. Same pattern as Sample 10.
    /// </summary>
    private sealed class UpstreamIntegrationHandler : ResponseHandler
    {
        private readonly ResponsesClient _upstream;
        public UpstreamIntegrationHandler(ResponsesClient upstream) => _upstream = upstream;

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

            // Own the lifecycle — construct events directly.
            int seq = 0;
            var conversationId = request.GetConversationId();
            var response = new Models.ResponseObject(context.ResponseId, request.Model ?? "")
            {
                Status = Models.ResponseStatus.InProgress,
                Metadata = request.Metadata!,
                AgentReference = request.AgentReference,
                Background = request.Background,
                Conversation = conversationId != null
                    ? new Models.ConversationReference(conversationId) : null,
                PreviousResponseId = request.PreviousResponseId,
            };
            yield return new ResponseCreatedEvent(seq++, response);
            yield return new ResponseInProgressEvent(seq++, response);

            // Translate content events from upstream, skip lifecycle events.
            var outputItems = new List<Models.OutputItem>();
            bool upstreamFailed = false;

            await foreach (StreamingResponseUpdate update in
                _upstream.CreateResponseStreamingAsync(options, cancellationToken))
            {
                if (update is StreamingResponseCreatedUpdate
                    or StreamingResponseInProgressUpdate)
                    continue;

                if (update is StreamingResponseCompletedUpdate)
                    break;

                if (update is StreamingResponseFailedUpdate)
                {
                    upstreamFailed = true;
                    break;
                }

                ResponseStreamEvent evt = update.Translate().To<ResponseStreamEvent>();

                // Clear upstream response_id so auto-stamp fills ours.
                if (evt is ResponseOutputItemAddedEvent added)
                    added.Item.ResponseId = null;
                else if (evt is ResponseOutputItemDoneEvent done)
                {
                    done.Item.ResponseId = null;
                    outputItems.Add(done.Item);
                }

                yield return evt;
            }

            if (upstreamFailed)
            {
                response.Status = Models.ResponseStatus.Failed;
                response.Error = new Models.ResponseErrorInfo(
                    Models.ResponseErrorCode.ServerError, "Upstream request failed");
                yield return new ResponseFailedEvent(seq++, response);
            }
            else
            {
                response.Status = Models.ResponseStatus.Completed;
                foreach (var item in outputItems)
                    response.Output.Add(item);
                yield return new ResponseCompletedEvent(seq++, response);
            }
        }
    }

    // ── Backend event factories ──

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitMultiOutput(
        CreateResponse req, ResponseContext ctx, [EnumeratorCancellation] CancellationToken ct)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // 1. Reasoning
        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();
        var sp = reasoning.AddSummaryPart();
        yield return sp.EmitAdded();
        yield return sp.EmitTextDelta("Thinking about");
        yield return sp.EmitTextDelta(" the answer...");
        yield return sp.EmitTextDone("Thinking about the answer...");
        yield return sp.EmitDone();
        yield return reasoning.EmitDone();

        // 2. Function call
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_proxy_001");
        yield return fc.EmitAdded();
        yield return fc.EmitArgumentsDelta("{\"city\":");
        yield return fc.EmitArgumentsDelta("\"Seattle\"}");
        yield return fc.EmitArgumentsDone("{\"city\":\"Seattle\"}");
        yield return fc.EmitDone();

        // 3. Text message
        var msg = stream.AddOutputItemMessage();
        yield return msg.EmitAdded();
        var tc = msg.AddTextContent();
        yield return tc.EmitAdded();
        yield return tc.EmitDelta("The answer");
        yield return tc.EmitDelta(" is 42.");
        yield return tc.EmitTextDone("The answer is 42.");
        yield return tc.EmitDone();
        yield return msg.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitFailed(
        CreateResponse req, ResponseContext ctx, [EnumeratorCancellation] CancellationToken ct)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();
        yield return stream.EmitFailed(
            Models.ResponseErrorCode.ServerError,
            "Backend processing error");
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitTextOnly(string text) => (req, ctx, ct) => EmitTextOnlyCore(req, ctx, text);

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitTextOnlyCore(
        CreateResponse req, ResponseContext ctx, string text)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();
        var msg = stream.AddOutputItemMessage();
        yield return msg.EmitAdded();
        var tc = msg.AddTextContent();
        yield return tc.EmitAdded();
        yield return tc.EmitTextDone(text);
        yield return tc.EmitDone();
        yield return msg.EmitDone();
        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }
}
