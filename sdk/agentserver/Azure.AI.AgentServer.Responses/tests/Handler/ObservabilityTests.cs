// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

/// <summary>
/// Observability tests verifying that <see cref="ResponsesActivitySource"/> correctly
/// propagates baggage onto the ASP.NET Core request activity.
/// <para>
/// The <c>invoke_agent</c> span has been removed. These tests now verify baggage
/// propagation rather than span tags.
/// </para>
/// </summary>
public class ObservabilityTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private readonly ActivityListener _listener;

    // Captured inside the handler
    private readonly Dictionary<string, string?> _capturedBaggage = new();

    public ObservabilityTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();

        // Listen to all sources so ASP.NET Core's request activity is recorded
        _listener = new ActivityListener
        {
            ShouldListenTo = _ => true,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(_listener);

        // Capture baggage inside the handler
        _handler.EventFactory = (request, context, ct) => CaptureAndYieldDefault(request, context, ct);
    }

    private async IAsyncEnumerable<ResponseStreamEvent> CaptureAndYieldDefault(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var activity = Activity.Current;
        if (activity is not null)
        {
            foreach (var baggage in activity.Baggage)
            {
                _capturedBaggage[baggage.Key] = baggage.Value;
            }
        }

        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    [Test]
    public async Task CreateResponse_PropagatesBaggage_WithResponseId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-emit" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True,
            "Baggage should contain response_id");
        XAssert.StartsWith("caresp_", _capturedBaggage[ResponsesTracingConstants.Baggage.ResponseId]);
    }

    [Test]
    public async Task CreateResponse_DefaultMode_SetsBaggageStreamingFalse()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-default" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("False"));
        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ConversationId), Is.True);
    }

    [Test]
    public async Task CreateResponse_StreamingMode_SetsBaggageStreamingTrue()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-stream", stream = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("True"));
    }

    [Test]
    public async Task CreateResponse_BackgroundMode_SetsBaggageStreamingFalse()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-background", background = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("False"));
    }

    [Test]
    public async Task CreateResponse_SetsBaggageResponseId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-nsid" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var responseId = _capturedBaggage[ResponsesTracingConstants.Baggage.ResponseId];
        Assert.That(responseId, Is.Not.Null);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task CreateResponse_WithConversation_SetsBaggageConversationId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-conv", conversation = "conv_abc123" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.ConversationId], Is.EqualTo("conv_abc123"));
    }

    public void Dispose()
    {
        _listener.Dispose();
        _client.Dispose();
        _factory.Dispose();
    }
}
