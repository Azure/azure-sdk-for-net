// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for distributed tracing: GenAI tags, baggage, and X-Request-Id
/// (protocol-spec §7).
/// Captures Activity.Current inside the handler for deterministic assertions —
/// avoids race conditions with ActivityListener.ActivityStopped.
/// </summary>
public sealed class DistributedTracingProtocolTests : IDisposable
{
    private readonly ActivityListener _listener;
    private readonly TestHandler _handler;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    // Captured inside the handler (works for non-streaming only)
    private readonly Dictionary<string, string?> _capturedBaggage = new();
    private readonly Dictionary<string, object?> _capturedTags = new();
    private string? _capturedDisplayName;

    // Captured via ActivityStopped (works for all modes including streaming)
    private readonly List<Activity> _stoppedActivities = new();

    public DistributedTracingProtocolTests()
    {
        // Use a unique source name to isolate from parallel test classes
        var sourceName = $"Test.Tracing.{Guid.NewGuid():N}";

        // ActivityListener is required so StartActivity() returns non-null
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _stoppedActivities.Add(activity)
        };
        ActivitySource.AddActivityListener(_listener);

        _handler = new TestHandler();
        _handler.EventFactory = (request, context, ct) => CaptureAndYieldDefault(request, context, ct);
        _factory = new TestWebApplicationFactory(_handler,
            configureTestServices: services =>
                services.AddSingleton<ResponsesActivitySource>(
                    new TestableActivitySource(sourceName)));
        _client = _factory.CreateClient();
    }

    /// <summary>
    /// Test-visible subclass so we can call the protected constructor.
    /// </summary>
    private sealed class TestableActivitySource : ResponsesActivitySource
    {
        public TestableActivitySource(string? name) : base(name) { }
    }

    private async IAsyncEnumerable<Azure.AI.AgentServer.Responses.Models.ResponseStreamEvent> CaptureAndYieldDefault(
        Azure.AI.AgentServer.Responses.Models.CreateResponse request,
        ResponseContext context,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        // Capture Activity.Current — tags and baggage are set BEFORE handler invocation
        var activity = Activity.Current;
        if (activity is not null)
        {
            _capturedDisplayName = activity.DisplayName;
            foreach (var tag in activity.TagObjects)
            {
                _capturedTags[tag.Key] = tag.Value;
            }
            foreach (var baggage in activity.Baggage)
            {
                _capturedBaggage[baggage.Key] = baggage.Value;
            }
        }

        // Yield default lifecycle
        var response = new Azure.AI.AgentServer.Responses.Models.ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCompletedEvent(0, response);
    }

    // --- US2: GenAI Tags (T012-T017) ---

    [Test]
    public async Task Activity_HasResponseIdTag()
    {
        // T012 / §7.2: gen_ai.response.id tag
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.ResponseId), Is.True, "Should have gen_ai.response.id tag");
        XAssert.StartsWith("caresp_", _capturedTags[ResponsesTracingConstants.Tags.ResponseId]?.ToString());
    }

    [Test]
    public async Task Activity_HasAgentTags_WhenAgentProvided()
    {
        // T013 / §7.2: agent tags with name+version
        await PostDefaultAsync(new
        {
            model = "gpt-4",
            agent_reference = new { type = "agent_reference", name = "my-agent", version = "1.0" }
        });

        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.AgentName], Is.EqualTo("my-agent"));
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.AgentId], Is.EqualTo("my-agent:1.0"));
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.AgentVersion], Is.EqualTo("1.0"));
    }

    [Test]
    public async Task Activity_HasAgentId_WithoutVersion()
    {
        // T014 / §7.2: gen_ai.agent.id = {name} when no version
        await PostDefaultAsync(new
        {
            model = "gpt-4",
            agent_reference = new { type = "agent_reference", name = "my-agent" }
        });

        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.AgentId], Is.EqualTo("my-agent"));
        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentVersion), Is.False, "agent.version should not be set when version not provided");
    }

    [Test]
    public async Task Activity_HasAlwaysOnTags()
    {
        // T015 / §7.2: always-on tags
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo(ResponsesTracingConstants.ProviderName));
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.OperationName], Is.EqualTo(ResponsesTracingConstants.OperationName));
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.ServiceName], Is.EqualTo(ResponsesTracingConstants.ServiceName));
    }

    [Test]
    public async Task Activity_HasModelAndConversationTags()
    {
        // T016 / §7.2: model and conversation tags
        var conversationId = "conv_abc123";
        await PostDefaultAsync(new
        {
            model = "gpt-4o",
            conversation = conversationId
        });

        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.RequestModel], Is.EqualTo("gpt-4o"));
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.ConversationId], Is.EqualTo(conversationId));
    }

    [Test]
    public async Task Activity_OmitsMissingFields()
    {
        // T017 / §7.2: missing fields produce no tags (except gen_ai.agent.id which is always set)
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentName), Is.False);
        // gen_ai.agent.id is always set ("" when no agent) for Core parity
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.AgentId], Is.EqualTo(string.Empty));
        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentVersion), Is.False);
        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.ConversationId), Is.False);
    }

    [Test]
    public async Task Activity_HasCorrectDisplayName_WithModel()
    {
        // R8: activity display name follows OTEL convention
        await PostDefaultAsync(new { model = "gpt-4o" });

        Assert.That(_capturedDisplayName, Is.EqualTo("invoke_agent gpt-4o"));
    }

    [Test]
    public async Task Activity_HasCorrectDisplayName_WithoutModel()
    {
        // R8: activity display name without model
        await PostDefaultAsync(new { model = "" });

        Assert.That(_capturedDisplayName, Is.EqualTo("invoke_agent"));
    }

    [Test]
    public async Task Activity_HasNamespacedParityTags()
    {
        // Parity: azure.ai.agentserver.responses.* tags
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedResponseId), Is.True);
        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedConversationId), Is.True);
        Assert.That(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.True);
        Assert.That(_capturedTags[ResponsesTracingConstants.Tags.NamespacedStreaming], Is.EqualTo(false));
    }

    [Test]
    public async Task Activity_RemovedTags_NotPresent()
    {
        // response.mode and request.id tags were removed for parity
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags.ContainsKey("response.mode"), Is.False);
        Assert.That(_capturedTags.ContainsKey("request.id"), Is.False);
    }

    // --- US3: Baggage (T018-T020) ---

    [Test]
    public async Task Baggage_HasCoreItems()
    {
        // T018 / §7.3: core baggage items (namespaced)
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True, "Baggage should contain namespaced response_id");
        XAssert.StartsWith("caresp_", _capturedBaggage[ResponsesTracingConstants.Baggage.ResponseId]);
        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("False"));
        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ConversationId), Is.True);
    }

    [Test]
    public async Task Baggage_HasAgentAndConversation_WhenPresent()
    {
        // T019 / §7.3: conversation baggage (namespaced)
        await PostDefaultAsync(new
        {
            model = "test",
            conversation = "conv_xyz",
            agent_reference = new { type = "agent_reference", name = "test-agent", version = "2.0" }
        });

        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.ConversationId], Is.EqualTo("conv_xyz"));
        // Agent baggage no longer set (short-key baggage removed)
    }

    [Test]
    public async Task Baggage_IsSetBeforeHandlerInvocation()
    {
        // T020 / S-044: baggage set before handler runs
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedBaggage.Count > 0, Is.True, "Baggage should be set before handler invocation");
        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True);
    }

    [Test]
    public async Task Baggage_Streaming_HasCorrectValue()
    {
        // Streaming baggage item: verify via stopped activity since handler runs
        // lazily outside the activity scope for streaming responses
        var content = new StringContent(
            JsonSerializer.Serialize(new { model = "test", stream = true }),
            System.Text.Encoding.UTF8, "application/json");
        await _client.PostAsync("/responses", content);

        Assert.That(_stoppedActivities, Is.Not.Empty);
        var activity = _stoppedActivities[^1];
        var streamingBaggage = activity.Baggage.FirstOrDefault(b => b.Key == ResponsesTracingConstants.Baggage.Streaming);
        Assert.That(streamingBaggage.Value, Is.EqualTo("True"));
    }

    // --- US4: X-Request-Id (T021-T023) ---

    [Test]
    public async Task XRequestId_SetsBaggage()
    {
        // T021 / §7.3: X-Request-Id propagated to namespaced baggage
        var requestId = "req-12345-abc";
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test" }),
                System.Text.Encoding.UTF8, "application/json")
        };
        request.Headers.Add("X-Request-Id", requestId);
        await _client.SendAsync(request);

        // X-Request-Id is no longer a span tag — only namespaced baggage
        Assert.That(_capturedTags.ContainsKey("request.id"), Is.False);
        Assert.That(_capturedBaggage[ResponsesTracingConstants.Baggage.RequestId], Is.EqualTo(requestId));
    }

    [Test]
    public async Task XRequestId_MissingHeader_NoBaggage()
    {
        // T022 / §7.3: no X-Request-Id → no baggage
        await PostDefaultAsync(new { model = "test" });

        Assert.That(_capturedTags.ContainsKey("request.id"), Is.False);
        Assert.That(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.RequestId), Is.False);
    }

    [Test]
    public async Task XRequestId_LongValue_TruncatedTo256()
    {
        // T023: long X-Request-Id truncated in baggage
        var longId = new string('x', 512);
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test" }),
                System.Text.Encoding.UTF8, "application/json")
        };
        request.Headers.Add("X-Request-Id", longId);
        await _client.SendAsync(request);

        var baggageValue = _capturedBaggage[ResponsesTracingConstants.Baggage.RequestId];
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
    }

    // --- Helpers ---

    private async Task PostDefaultAsync(object payload)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);
        Assert.That(response.IsSuccessStatusCode, Is.True, $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        _listener.Dispose();
    }
}
