using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

public class ObservabilityTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private readonly ActivityListener _listener;
    private readonly ConcurrentBag<Activity> _activities = new();

    public ObservabilityTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();

        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.Responses",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = activity => _activities.Add(activity),
        };
        ActivitySource.AddActivityListener(_listener);
    }

    [Test]
    public async Task CreateResponse_EmitsActivity_WithResponseId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-emit" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-emit" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-emit");

        Assert.IsNotNull(activity);

        var responseId = activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId) as string;
        Assert.IsNotNull(responseId);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task CreateResponse_DefaultMode_SetsParityTags()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-default" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-default" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-default");

        Assert.IsNotNull(activity);

        // Core-parity tags
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName));
        Assert.AreEqual(ResponsesTracingConstants.ProviderName, activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName));
        Assert.AreEqual(false, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming));

        // Removed tags should not be present
        Assert.IsNull(activity.GetTagItem("response.mode"));
        Assert.IsNull(activity.GetTagItem("response.status"));
    }

    [Test]
    public async Task CreateResponse_StreamingMode_SetsStreamingTrue()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-stream", stream = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-stream" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-stream");

        Assert.IsNotNull(activity);
        Assert.AreEqual(true, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming));
    }

    [Test]
    public async Task CreateResponse_BackgroundMode_SetsStreamingFalse()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-background", background = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-background" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-background");

        Assert.IsNotNull(activity);
        Assert.AreEqual(false, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming));
    }

    [Test]
    public async Task CreateResponse_SetsNamespacedResponseId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-nsid" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-nsid" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-nsid");

        Assert.IsNotNull(activity);

        // gen_ai.response.id and azure.ai.agentserver.responses.response_id should match
        var genAiId = activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId) as string;
        var namespacedId = activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedResponseId) as string;
        Assert.IsNotNull(genAiId);
        Assert.AreEqual(genAiId, namespacedId);
    }

    [Test]
    public async Task CreateResponse_NoAgent_SetsEmptyAgentId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-no-agent" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-no-agent" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-no-agent");

        Assert.IsNotNull(activity);
        Assert.AreEqual(string.Empty, activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId));
    }

    public void Dispose()
    {
        _listener.Dispose();
        _client.Dispose();
        _factory.Dispose();
    }
}
