// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER

using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

/// <summary>
/// Validates that W3C trace baggage and x-request-id are propagated
/// through the AgentServer middleware pipeline into the handler's Activity.
/// </summary>
[TestFixture]
[NonParallelizable]
public class BaggagePropagationTests
{
    // Fake connection string to activate the full OTel pipeline (including W3C
    // BaggagePropagator) on all TFMs. Without this, net8.0 doesn't extract the
    // baggage header into Activity.Baggage.
    private const string FakeConnectionString =
        "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://localhost";

    [SetUp]
    public void SetUp()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", FakeConnectionString);
        FoundryEnvironment.Reload();
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public async Task W3CBaggage_PropagatedToHandlerActivity()
    {
        // Arrange
        BaggageCaptureHandler.CapturedBaggage = null;

        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<BaggageCaptureHandler>();

        var app = builder.Build();
        await app.App.StartAsync();
        var client = app.App.GetTestClient();

        // Act — send request with W3C baggage header
        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { message = "test" }),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add("baggage", "userId=user-123,requestSource=orchestrator,env=staging");

        var response = await client.SendAsync(request);

        // Assert
        Assert.That((int)response.StatusCode, Is.LessThan(500));
        Assert.That(BaggageCaptureHandler.CapturedBaggage, Is.Not.Null,
            "Handler's Activity.Current should have baggage");

        var baggage = BaggageCaptureHandler.CapturedBaggage!;
        Assert.That(baggage.ContainsKey("userId"), Is.True,
            $"Baggage should contain 'userId'. Got: {string.Join(", ", baggage.Keys)}");
        Assert.That(baggage["userId"], Is.EqualTo("user-123"));
        Assert.That(baggage["requestSource"], Is.EqualTo("orchestrator"));
        Assert.That(baggage["env"], Is.EqualTo("staging"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task XRequestId_PropagatedToBaggage()
    {
        // Arrange
        BaggageCaptureHandler.CapturedBaggage = null;

        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<BaggageCaptureHandler>();

        var app = builder.Build();
        await app.App.StartAsync();
        var client = app.App.GetTestClient();

        // Act — send request with x-request-id header
        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { message = "test" }),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add("x-request-id", "req-abc-123");

        var response = await client.SendAsync(request);

        // Assert
        Assert.That((int)response.StatusCode, Is.LessThan(500));
        Assert.That(BaggageCaptureHandler.CapturedBaggage, Is.Not.Null,
            "Handler's Activity.Current should have baggage");
        Assert.That(BaggageCaptureHandler.CapturedBaggage!.ContainsKey("x-request-id"), Is.True,
            "Baggage should contain 'x-request-id' from RequestIdBaggagePropagator. " +
            $"Got: {string.Join(", ", BaggageCaptureHandler.CapturedBaggage.Keys)}");
        Assert.That(BaggageCaptureHandler.CapturedBaggage["x-request-id"], Is.EqualTo("req-abc-123"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task W3CBaggageAndXRequestId_BothPropagated()
    {
        // Arrange
        BaggageCaptureHandler.CapturedBaggage = null;

        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<BaggageCaptureHandler>();

        var app = builder.Build();
        await app.App.StartAsync();
        var client = app.App.GetTestClient();

        // Act — send request with both baggage and x-request-id headers
        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { message = "test" }),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add("baggage", "sessionId=sess-456,traceSource=gateway");
        request.Headers.Add("x-request-id", "req-xyz-789");

        var response = await client.SendAsync(request);

        // Assert
        Assert.That((int)response.StatusCode, Is.LessThan(500));
        Assert.That(BaggageCaptureHandler.CapturedBaggage, Is.Not.Null,
            "Handler's Activity.Current should have baggage");

        var baggage = BaggageCaptureHandler.CapturedBaggage!;

        // W3C baggage items
        Assert.That(baggage.ContainsKey("sessionId"), Is.True,
            $"Baggage should contain 'sessionId'. Got: {string.Join(", ", baggage.Keys)}");
        Assert.That(baggage["sessionId"], Is.EqualTo("sess-456"));
        Assert.That(baggage["traceSource"], Is.EqualTo("gateway"));

        // x-request-id → baggage (added by RequestIdBaggagePropagator middleware)
        Assert.That(baggage.ContainsKey("x-request-id"), Is.True,
            $"Baggage should contain 'x-request-id'. Got: {string.Join(", ", baggage.Keys)}");
        Assert.That(baggage["x-request-id"], Is.EqualTo("req-xyz-789"));

        await app.App.StopAsync();
    }

    [Test]
    public async Task W3CBaggage_PropagatedThroughStreamingPipeline()
    {
        // Arrange — use the Responses protocol (streaming SSE)
        StreamingBaggageCaptureHandler.CapturedBaggage = null;

        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddResponses<StreamingBaggageCaptureHandler>();

        var app = builder.Build();
        await app.App.StartAsync();
        var client = app.App.GetTestClient();

        // Act — send streaming request with baggage
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true }),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add("baggage", "conversationId=conv-001,agentId=agent-42");
        request.Headers.Add("x-request-id", "req-stream-555");

        var response = await client.SendAsync(request);
        // Read SSE stream to completion to ensure handler ran
        await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That((int)response.StatusCode, Is.LessThan(500));
        Assert.That(StreamingBaggageCaptureHandler.CapturedBaggage, Is.Not.Null,
            "Streaming handler's Activity.Current should have baggage");

        var baggage = StreamingBaggageCaptureHandler.CapturedBaggage!;

        // W3C baggage items
        Assert.That(baggage.ContainsKey("conversationId"), Is.True,
            $"Baggage should contain 'conversationId'. Got: {string.Join(", ", baggage.Keys)}");
        Assert.That(baggage["conversationId"], Is.EqualTo("conv-001"));
        Assert.That(baggage["agentId"], Is.EqualTo("agent-42"));

        // x-request-id → baggage
        Assert.That(baggage.ContainsKey("x-request-id"), Is.True,
            $"Baggage should contain 'x-request-id'. Got: {string.Join(", ", baggage.Keys)}");
        Assert.That(baggage["x-request-id"], Is.EqualTo("req-stream-555"));

        await app.App.StopAsync();
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Test handlers — capture baggage from Activity.Current
    // ═══════════════════════════════════════════════════════════════════════

    private sealed class BaggageCaptureHandler : InvocationHandler
    {
        internal static Dictionary<string, string?>? CapturedBaggage { get; set; }

        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            // Use GroupBy to handle duplicate baggage keys (e.g., x-request-id may
            // be set by multiple middleware). Take the last value for each key.
            CapturedBaggage = Activity.Current?.Baggage
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(g => g.Key, g => g.Last().Value);

            response.ContentType = "text/event-stream";
            var doneEvent = JsonSerializer.Serialize(new
            {
                type = "done",
                invocation_id = context.InvocationId,
                session_id = context.SessionId,
                full_text = "baggage test",
            });
            await response.WriteAsync($"data: {doneEvent}\n\n", cancellationToken);
            await response.Body.FlushAsync(cancellationToken);
        }
    }

    private sealed class StreamingBaggageCaptureHandler : ResponseHandler
    {
        internal static Dictionary<string, string?>? CapturedBaggage { get; set; }

        public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
            CreateResponse request,
            ResponseContext context,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
        {
            CapturedBaggage = Activity.Current?.Baggage
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(g => g.Key, g => g.Last().Value);

            var responseObj = new ResponseObject(context.ResponseId, request.Model ?? "test");
            yield return new ResponseCreatedEvent(0, responseObj);

            await Task.Yield();

            responseObj.Status = ResponseStatus.Completed;
            yield return new ResponseCompletedEvent(1, responseObj);
        }
    }
}

#endif
