using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for distributed tracing: GenAI tags, baggage, and X-Request-Id
/// (US2/US3/US4 / FR-004..015).
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
        IResponseContext context,
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
        var response = new Azure.AI.AgentServer.Responses.Models.Response(context.ResponseId, request.Model ?? "test-model");
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCompletedEvent(0, response);
    }

    // --- US2: GenAI Tags (T012-T017) ---

    [Test]
    public async Task Activity_HasResponseIdTag()
    {
        // T012 / FR-004: gen_ai.response.id tag
        await PostDefaultAsync(new { model = "test" });

        Assert.IsTrue(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.ResponseId), "Should have gen_ai.response.id tag");
        XAssert.StartsWith("caresp_", _capturedTags[ResponsesTracingConstants.Tags.ResponseId]?.ToString());
    }

    [Test]
    public async Task Activity_HasAgentTags_WhenAgentProvided()
    {
        // T013 / FR-005, FR-006, FR-009e: agent tags with name+version
        await PostDefaultAsync(new
        {
            model = "gpt-4",
            agent_reference = new { type = "agent_reference", name = "my-agent", version = "1.0" }
        });

        Assert.AreEqual("my-agent", _capturedTags[ResponsesTracingConstants.Tags.AgentName]);
        Assert.AreEqual("my-agent:1.0", _capturedTags[ResponsesTracingConstants.Tags.AgentId]);
        Assert.AreEqual("1.0", _capturedTags[ResponsesTracingConstants.Tags.AgentVersion]);
    }

    [Test]
    public async Task Activity_HasAgentId_WithoutVersion()
    {
        // T014 / FR-007: gen_ai.agent.id = {name} when no version
        await PostDefaultAsync(new
        {
            model = "gpt-4",
            agent_reference = new { type = "agent_reference", name = "my-agent" }
        });

        Assert.AreEqual("my-agent", _capturedTags[ResponsesTracingConstants.Tags.AgentId]);
        Assert.IsFalse(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentVersion),
            "agent.version should not be set when version not provided");
    }

    [Test]
    public async Task Activity_HasAlwaysOnTags()
    {
        // T015 / FR-008a, FR-008b, FR-009a, FR-009b: always-on tags
        await PostDefaultAsync(new { model = "test" });

        Assert.AreEqual(ResponsesTracingConstants.ProviderName, _capturedTags[ResponsesTracingConstants.Tags.ProviderName]);
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, _capturedTags[ResponsesTracingConstants.Tags.System]);
        Assert.AreEqual(ResponsesTracingConstants.OperationName, _capturedTags[ResponsesTracingConstants.Tags.OperationName]);
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, _capturedTags[ResponsesTracingConstants.Tags.ServiceName]);
    }

    [Test]
    public async Task Activity_HasModelAndConversationTags()
    {
        // T016 / FR-009c, FR-009d: model and conversation tags
        var conversationId = "conv_abc123";
        await PostDefaultAsync(new
        {
            model = "gpt-4o",
            conversation = conversationId
        });

        Assert.AreEqual("gpt-4o", _capturedTags[ResponsesTracingConstants.Tags.RequestModel]);
        Assert.AreEqual(conversationId, _capturedTags[ResponsesTracingConstants.Tags.ConversationId]);
    }

    [Test]
    public async Task Activity_OmitsMissingFields()
    {
        // T017 / FR-009: missing fields produce no tags (except gen_ai.agent.id which is always set)
        await PostDefaultAsync(new { model = "test" });

        Assert.IsFalse(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentName));
        // gen_ai.agent.id is always set ("" when no agent) for Core parity
        Assert.AreEqual(string.Empty, _capturedTags[ResponsesTracingConstants.Tags.AgentId]);
        Assert.IsFalse(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.AgentVersion));
        Assert.IsFalse(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.ConversationId));
    }

    [Test]
    public async Task Activity_HasCorrectDisplayName_WithModel()
    {
        // R8: activity display name follows OTEL convention
        await PostDefaultAsync(new { model = "gpt-4o" });

        Assert.AreEqual("create_response gpt-4o", _capturedDisplayName);
    }

    [Test]
    public async Task Activity_HasCorrectDisplayName_WithoutModel()
    {
        // R8: activity display name without model
        await PostDefaultAsync(new { model = "" });

        Assert.AreEqual("create_response", _capturedDisplayName);
    }

    [Test]
    public async Task Activity_HasNamespacedParityTags()
    {
        // Parity: azure.ai.agentserver.responses.* tags
        await PostDefaultAsync(new { model = "test" });

        Assert.IsTrue(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedResponseId));
        Assert.IsTrue(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedConversationId));
        Assert.IsTrue(_capturedTags.ContainsKey(ResponsesTracingConstants.Tags.NamespacedStreaming));
        Assert.AreEqual(false, _capturedTags[ResponsesTracingConstants.Tags.NamespacedStreaming]);
    }

    [Test]
    public async Task Activity_RemovedTags_NotPresent()
    {
        // response.mode and request.id tags were removed for parity
        await PostDefaultAsync(new { model = "test" });

        Assert.IsFalse(_capturedTags.ContainsKey("response.mode"));
        Assert.IsFalse(_capturedTags.ContainsKey("request.id"));
    }

    // --- US3: Baggage (T018-T020) ---

    [Test]
    public async Task Baggage_HasCoreItems()
    {
        // T018 / FR-010, FR-011a, FR-011d: core baggage items (namespaced)
        await PostDefaultAsync(new { model = "test" });

        Assert.IsTrue(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), "Baggage should contain namespaced response_id");
        XAssert.StartsWith("caresp_", _capturedBaggage[ResponsesTracingConstants.Baggage.ResponseId]);
        Assert.AreEqual("False", _capturedBaggage[ResponsesTracingConstants.Baggage.Streaming]);
        Assert.IsTrue(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ConversationId));
    }

    [Test]
    public async Task Baggage_HasAgentAndConversation_WhenPresent()
    {
        // T019 / FR-011, FR-011b, FR-011c: conversation baggage (namespaced)
        await PostDefaultAsync(new
        {
            model = "test",
            conversation = "conv_xyz",
            agent_reference = new { type = "agent_reference", name = "test-agent", version = "2.0" }
        });

        Assert.AreEqual("conv_xyz", _capturedBaggage[ResponsesTracingConstants.Baggage.ConversationId]);
        // Agent baggage no longer set (short-key baggage removed)
    }

    [Test]
    public async Task Baggage_IsSetBeforeHandlerInvocation()
    {
        // T020 / FR-012: baggage set before handler runs
        await PostDefaultAsync(new { model = "test" });

        Assert.IsTrue(_capturedBaggage.Count > 0, "Baggage should be set before handler invocation");
        Assert.IsTrue(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId));
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

        Assert.IsNotEmpty(_stoppedActivities);
        var activity = _stoppedActivities[^1];
        var streamingBaggage = activity.Baggage.FirstOrDefault(b => b.Key == ResponsesTracingConstants.Baggage.Streaming);
        Assert.AreEqual("True", streamingBaggage.Value);
    }

    // --- US4: X-Request-Id (T021-T023) ---

    [Test]
    public async Task XRequestId_SetsBaggage()
    {
        // T021 / FR-013, FR-014: X-Request-Id propagated to namespaced baggage
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
        Assert.IsFalse(_capturedTags.ContainsKey("request.id"));
        Assert.AreEqual(requestId, _capturedBaggage[ResponsesTracingConstants.Baggage.RequestId]);
    }

    [Test]
    public async Task XRequestId_MissingHeader_NoBaggage()
    {
        // T022 / FR-015: no X-Request-Id → no baggage
        await PostDefaultAsync(new { model = "test" });

        Assert.IsFalse(_capturedTags.ContainsKey("request.id"));
        Assert.IsFalse(_capturedBaggage.ContainsKey(ResponsesTracingConstants.Baggage.RequestId));
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
        Assert.IsNotNull(baggageValue);
        Assert.AreEqual(256, baggageValue!.Length);
    }

    // --- Helpers ---

    private async Task PostDefaultAsync(object payload)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);
        Assert.IsTrue(response.IsSuccessStatusCode,
            $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        _listener.Dispose();
    }
}
