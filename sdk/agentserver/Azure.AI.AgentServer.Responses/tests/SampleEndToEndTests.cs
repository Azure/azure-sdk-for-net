// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Azure.AI.AgentServer.Responses.Tests.Snippets;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// End-to-end tests that validate every sample handler (Samples 1–11) works
/// correctly when wired into a real ASP.NET Core test server. Each test
/// registers the actual handler class from the sample snippets, sends an
/// HTTP request, and asserts on the response content.
///
/// Samples 10–11 (upstream OpenAI integration) require a live API key and
/// are covered by compilation-only snippet tests instead.
///
/// For samples that show both a convenience handler and a full-control builder
/// handler (Samples 3, 4, 6), both variants are tested to ensure equivalent
/// functional behaviour.
///
/// These tests complement the compilation-only snippet tests by verifying
/// that sample code is functionally correct — not just syntactically valid.
/// </summary>
[TestFixture]
public class SampleEndToEndTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  Sample 1: Echo Handler — TextResponse with createText
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample1_EchoHandler_EchoesInputText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample1Snippets.EchoHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client, """{"model":"test","input":"Hello there"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Is.EqualTo("Echo: Hello there"));
    }

    [Test]
    public async Task Sample1_EchoHandler_StructuredInput_EchoesText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample1Snippets.EchoHandler>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "Structured hello" }]
                    }
                ]
            }
            """;
        var body = await PostJsonAsync(client, json);

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Is.EqualTo("Echo: Structured hello"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 2: Streaming Handler — TextResponse with createTextStream
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample2_StreamingHandler_StreamsTokenDeltas()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample2Snippets.StreamingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"test","stream":true}""");
        var events = SseParser.Parse(body);

        var deltas = events
            .Where(e => e.EventType == "response.output_text.delta")
            .Select(e =>
            {
                using var doc = JsonDocument.Parse(e.Data);
                return doc.RootElement.GetProperty("delta").GetString();
            })
            .ToList();

        Assert.That(deltas, Has.Count.EqualTo(4));
        Assert.That(string.Join("", deltas), Is.EqualTo("Hello, world!"));
    }

    [Test]
    public async Task Sample2_StreamingHandler_NonStreaming_ReturnsFullText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample2Snippets.StreamingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client, """{"model":"test","input":"test"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Is.EqualTo("Hello, world!"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 3: Greeting Handler — Full Control via ResponseEventStream
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample3_GreetingHandler_FullLifecycleEvents()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.GreetingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"test input","stream":true}""");
        var events = SseParser.Parse(body);

        var eventTypes = events.Select(e => e.EventType).ToList();

        // Verify complete lifecycle event sequence
        Assert.That(eventTypes, Does.Contain("response.created"));
        Assert.That(eventTypes, Does.Contain("response.output_item.added"));
        Assert.That(eventTypes, Does.Contain("response.content_part.added"));
        Assert.That(eventTypes, Does.Contain("response.output_text.delta"));
        Assert.That(eventTypes, Does.Contain("response.output_text.done"));
        Assert.That(eventTypes, Does.Contain("response.content_part.done"));
        Assert.That(eventTypes, Does.Contain("response.output_item.done"));
        Assert.That(eventTypes, Does.Contain("response.completed"));
    }

    [Test]
    public async Task Sample3_GreetingHandler_ReturnsGreetingWithInput()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.GreetingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"test input","stream":true}""");
        var events = SseParser.Parse(body);

        var textDone = events.First(e => e.EventType == "response.output_text.done");
        using var doc = JsonDocument.Parse(textDone.Data);
        Assert.That(doc.RootElement.GetProperty("text").GetString(),
            Is.EqualTo("Hello! You said: \"test input\""));
    }

    [Test]
    public async Task Sample3_GreetingHandler_SetsResponseProperties()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.GreetingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"test","stream":true}""");
        var events = SseParser.Parse(body);

        var created = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(created.Data);
        var resp = doc.RootElement.GetProperty("response");
        Assert.That(resp.GetProperty("temperature").GetDouble(), Is.EqualTo(0.7));
        Assert.That(resp.GetProperty("max_output_tokens").GetInt32(), Is.EqualTo(1024));
    }

    [Test]
    public async Task Sample3_StreamingGreetingHandler_StreamsTokenDeltas()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.StreamingGreetingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"Hi","stream":true}""");
        var events = SseParser.Parse(body);

        // Verify streaming deltas arrive
        var deltas = events
            .Where(e => e.EventType == "response.output_text.delta")
            .Select(e =>
            {
                using var doc = JsonDocument.Parse(e.Data);
                return doc.RootElement.GetProperty("delta").GetString();
            })
            .ToList();

        Assert.That(deltas, Has.Count.EqualTo(4));
        Assert.That(string.Join("", deltas), Is.EqualTo("Hello! You said: \"Hi\""));
    }

    [Test]
    public async Task Sample3_StreamingGreetingHandler_NonStreaming_ReturnsFullText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.StreamingGreetingHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"Hi"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Is.EqualTo("Hello! You said: \"Hi\""));
    }

    [Test]
    public async Task Sample3_GreetingHandlerFullControl_ReturnsGreetingWithInput()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample3Snippets.GreetingHandlerFullControl>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"test input","stream":true}""");
        var events = SseParser.Parse(body);

        var textDone = events.First(e => e.EventType == "response.output_text.done");
        using var doc = JsonDocument.Parse(textDone.Data);
        Assert.That(doc.RootElement.GetProperty("text").GetString(),
            Is.EqualTo("Hello! You said: \"test input\""));

        // Verify properties
        var created = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(created.Data);
        var resp = createdDoc.RootElement.GetProperty("response");
        Assert.That(resp.GetProperty("temperature").GetDouble(), Is.EqualTo(0.7));
        Assert.That(resp.GetProperty("max_output_tokens").GetInt32(), Is.EqualTo(1024));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 4: Weather Handler — Two-Turn Function Calling
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample4_WeatherHandler_Turn1_EmitsFunctionCall()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample4Snippets.WeatherHandler>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "What's the weather?" }]
                    }
                ],
                "stream": true
            }
            """;
        var body = await PostJsonAsync(client, json);
        var events = SseParser.Parse(body);

        // Function call output item
        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var addedDoc = JsonDocument.Parse(itemAdded.Data);
        var item = addedDoc.RootElement.GetProperty("item");
        Assert.That(item.GetProperty("type").GetString(), Is.EqualTo("function_call"));
        Assert.That(item.GetProperty("name").GetString(), Is.EqualTo("get_weather"));
        Assert.That(item.GetProperty("call_id").GetString(), Is.EqualTo("call_weather_1"));

        // Arguments
        var argsDone = events.First(e => e.EventType == "response.function_call_arguments.done");
        using var argsDoc = JsonDocument.Parse(argsDone.Data);
        var args = argsDoc.RootElement.GetProperty("arguments").GetString();
        Assert.That(args, Does.Contain("Seattle"));
        Assert.That(args, Does.Contain("fahrenheit"));
    }

    [Test]
    public async Task Sample4_WeatherHandler_Turn2_ReturnsWeatherText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample4Snippets.WeatherHandler>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test",
                "input": [
                    {
                        "type": "function_call_output",
                        "call_id": "call_weather_1",
                        "output": "72°F and sunny"
                    }
                ]
            }
            """;
        var body = await PostJsonAsync(client, json);

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.Contain("weather"));
        Assert.That(text, Does.Contain("72"));
    }

    [Test]
    public async Task Sample4_WeatherHandlerFullControl_Turn1_EmitsFunctionCall()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample4Snippets.WeatherHandlerFullControl>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test",
                "input": [
                    {
                        "type": "message",
                        "role": "user",
                        "content": [{ "type": "input_text", "text": "What's the weather?" }]
                    }
                ],
                "stream": true
            }
            """;
        var body = await PostJsonAsync(client, json);
        var events = SseParser.Parse(body);

        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var addedDoc = JsonDocument.Parse(itemAdded.Data);
        var item = addedDoc.RootElement.GetProperty("item");
        Assert.That(item.GetProperty("type").GetString(), Is.EqualTo("function_call"));
        Assert.That(item.GetProperty("name").GetString(), Is.EqualTo("get_weather"));

        var argsDone = events.First(e => e.EventType == "response.function_call_arguments.done");
        using var argsDoc = JsonDocument.Parse(argsDone.Data);
        var args = argsDoc.RootElement.GetProperty("arguments").GetString();
        Assert.That(args, Does.Contain("Seattle"));
    }

    [Test]
    public async Task Sample4_WeatherHandlerFullControl_Turn2_ReturnsWeatherText()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample4Snippets.WeatherHandlerFullControl>();
            });
        using var client = factory.CreateClient();

        var json = """
            {
                "model": "test",
                "input": [
                    {
                        "type": "function_call_output",
                        "call_id": "call_weather_1",
                        "output": "72°F and sunny"
                    }
                ]
            }
            """;
        var body = await PostJsonAsync(client, json);

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.Contain("weather"));
        Assert.That(text, Does.Contain("72"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 5: Study Tutor — Conversation History
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample5_StudyTutorHandler_FirstTurn_WelcomeMessage()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample5Snippets.StudyTutorHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"What is photosynthesis?"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.StartWith("Welcome! I'm your study tutor."));
        Assert.That(text, Does.Contain("What is photosynthesis?"));
    }

    [Test]
    public async Task Sample5_StudyTutorHandler_SecondTurn_ReferencesHistory()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample5Snippets.StudyTutorHandler>();
            });
        using var client = factory.CreateClient();

        // Turn 1
        var body1 = await PostJsonAsync(client,
            """{"model":"test","input":"What is photosynthesis?"}""");
        using var doc1 = JsonDocument.Parse(body1);
        var responseId = doc1.RootElement.GetProperty("id").GetString();

        // Turn 2 — chain via previous_response_id
        var body2 = await PostJsonAsync(client,
            $$"""{"model":"test","input":"Tell me more","previous_response_id":"{{responseId}}"}""");
        using var doc2 = JsonDocument.Parse(body2);
        var text = GetOutputText(doc2.RootElement);

        // History was resolved (handler took the non-empty-history branch).
        // Turn number depends on how many OutputItemMessage items the history
        // resolver returns (input + output items from the chain), so we assert
        // the pattern rather than a specific number.
        Assert.That(text, Does.Match(@"^\[Turn \d+\]"));
        Assert.That(text, Does.Contain("previous discussion"));
        Assert.That(text, Does.Contain("Tell me more"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 6: Math Solver — Multi-Output (Reasoning + Message)
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample6_MathSolverHandler_EmitsReasoningAndMessage()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample6Snippets.MathSolverHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"What is 6 times 7?","stream":true}""");
        var events = SseParser.Parse(body);

        // Two output items: reasoning + message
        var itemAddedEvents = events
            .Where(e => e.EventType == "response.output_item.added")
            .ToList();
        Assert.That(itemAddedEvents, Has.Count.EqualTo(2));

        using var reasoningDoc = JsonDocument.Parse(itemAddedEvents[0].Data);
        Assert.That(
            reasoningDoc.RootElement.GetProperty("item").GetProperty("type").GetString(),
            Is.EqualTo("reasoning"));

        using var messageDoc = JsonDocument.Parse(itemAddedEvents[1].Data);
        Assert.That(
            messageDoc.RootElement.GetProperty("item").GetProperty("type").GetString(),
            Is.EqualTo("message"));

        // Reasoning summary events are present
        Assert.That(events.Any(e => e.EventType.Contains("reasoning")), Is.True);

        // Answer text contains "42"
        var textDone = events.First(e => e.EventType == "response.output_text.done");
        using var textDoc = JsonDocument.Parse(textDone.Data);
        Assert.That(textDoc.RootElement.GetProperty("text").GetString(), Does.Contain("42"));
    }

    [Test]
    public async Task Sample6_MathSolverHandler_NonStreaming_BothOutputItems()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample6Snippets.MathSolverHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"What is 6 times 7?"}""");

        using var doc = JsonDocument.Parse(body);
        var output = doc.RootElement.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(2));

        // First item: reasoning
        Assert.That(output[0].GetProperty("type").GetString(), Is.EqualTo("reasoning"));

        // Second item: message with text containing "42"
        Assert.That(output[1].GetProperty("type").GetString(), Is.EqualTo("message"));
        var text = GetOutputTextFromItem(output[1]);
        Assert.That(text, Does.Contain("42"));
    }

    [Test]
    public async Task Sample6_MathSolverHandlerFullControl_EmitsReasoningAndMessage()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample6Snippets.MathSolverHandlerFullControl>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"What is 6 times 7?","stream":true}""");
        var events = SseParser.Parse(body);

        // Two output items: reasoning + message
        var itemAddedEvents = events
            .Where(e => e.EventType == "response.output_item.added")
            .ToList();
        Assert.That(itemAddedEvents, Has.Count.EqualTo(2));

        using var reasoningDoc = JsonDocument.Parse(itemAddedEvents[0].Data);
        Assert.That(
            reasoningDoc.RootElement.GetProperty("item").GetProperty("type").GetString(),
            Is.EqualTo("reasoning"));

        using var messageDoc = JsonDocument.Parse(itemAddedEvents[1].Data);
        Assert.That(
            messageDoc.RootElement.GetProperty("item").GetProperty("type").GetString(),
            Is.EqualTo("message"));

        var textDone = events.First(e => e.EventType == "response.output_text.done");
        using var textDoc = JsonDocument.Parse(textDone.Data);
        Assert.That(textDoc.RootElement.GetProperty("text").GetString(), Does.Contain("42"));
    }

    [Test]
    public async Task Sample6_MathSolverHandlerFullControl_NonStreaming_BothOutputItems()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponseHandler, Sample6Snippets.MathSolverHandlerFullControl>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"What is 6 times 7?"}""");

        using var doc = JsonDocument.Parse(body);
        var output = doc.RootElement.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(2));

        Assert.That(output[0].GetProperty("type").GetString(), Is.EqualTo("reasoning"));
        Assert.That(output[1].GetProperty("type").GetString(), Is.EqualTo("message"));
        var text = GetOutputTextFromItem(output[1]);
        Assert.That(text, Does.Contain("42"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 7: Knowledge Handler — Tier 1 Hosting with DI
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample7_KnowledgeHandler_ReturnsKnowledgeBaseResult()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<Sample7Snippets.IKnowledgeBase, Sample7Snippets.WikiKnowledgeBase>();
                services.AddSingleton<ResponseHandler, Sample7Snippets.KnowledgeHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"Azure Functions"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.Contain("Azure Functions"));
        Assert.That(text, Does.Contain("mock knowledge base result"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 8: Knowledge Handler — Tier 2 Builder
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample8_KnowledgeHandler_ReturnsKnowledgeBaseResult()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<Sample8Snippets.IKnowledgeBase, Sample8Snippets.WikiKnowledgeBase>();
                services.AddSingleton<ResponseHandler, Sample8Snippets.KnowledgeHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"Azure Functions"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.Contain("Azure Functions"));
        Assert.That(text, Does.Contain("mock knowledge base result"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 9: Knowledge Handler — Tier 3 Self-Hosting
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample9_KnowledgeHandler_ReturnsKnowledgeBaseResult()
    {
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<Sample9Snippets.IKnowledgeBase, Sample9Snippets.WikiKnowledgeBase>();
                services.AddSingleton<ResponseHandler, Sample9Snippets.KnowledgeHandler>();
            });
        using var client = factory.CreateClient();

        var body = await PostJsonAsync(client,
            """{"model":"test","input":"Azure Functions"}""");

        using var doc = JsonDocument.Parse(body);
        var text = GetOutputText(doc.RootElement);
        Assert.That(text, Does.Contain("Azure Functions"));
        Assert.That(text, Does.Contain("mock knowledge base result"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Helpers
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Posts JSON to /responses and returns the response body as a string.
    /// </summary>
    private static async Task<string> PostJsonAsync(HttpClient client, string json)
    {
        var response = await client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Extracts the text from the first message output item in a JSON response.
    /// </summary>
    private static string GetOutputText(JsonElement root)
    {
        foreach (var item in root.GetProperty("output").EnumerateArray())
        {
            if (item.GetProperty("type").GetString() != "message")
                continue;

            return GetOutputTextFromItem(item);
        }

        throw new InvalidOperationException("No message output item found in response.");
    }

    /// <summary>
    /// Extracts the text from a single message output item element.
    /// </summary>
    private static string GetOutputTextFromItem(JsonElement item)
    {
        foreach (var content in item.GetProperty("content").EnumerateArray())
        {
            if (content.GetProperty("type").GetString() == "output_text" &&
                content.TryGetProperty("text", out var textProp))
            {
                return textProp.GetString()!;
            }
        }

        throw new InvalidOperationException("No output_text content found in message item.");
    }
}
