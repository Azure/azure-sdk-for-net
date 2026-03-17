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
            a.GetTagItem("gen_ai.request.model") as string == "obs-test-emit");

        Assert.IsNotNull(activity);

        var responseId = activity.GetTagItem("gen_ai.response.id") as string;
        Assert.IsNotNull(responseId);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task CreateResponse_DefaultMode_TagsModeAndStatus()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-default" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-default" &&
            a.GetTagItem("gen_ai.request.model") as string == "obs-test-default");

        Assert.IsNotNull(activity);
        Assert.AreEqual("default", activity.GetTagItem("response.mode"));
        Assert.AreEqual("completed", activity.GetTagItem("response.status"));
    }

    [Test]
    public async Task CreateResponse_StreamingMode_TagsMode()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-stream", stream = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-stream" &&
            a.GetTagItem("gen_ai.request.model") as string == "obs-test-stream");

        Assert.IsNotNull(activity);
        Assert.AreEqual("streaming", activity.GetTagItem("response.mode"));
    }

    [Test]
    public async Task CreateResponse_BackgroundMode_TagsMode()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-background", background = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "create_response obs-test-background" &&
            a.GetTagItem("gen_ai.request.model") as string == "obs-test-background");

        Assert.IsNotNull(activity);
        Assert.AreEqual("background", activity.GetTagItem("response.mode"));
    }

    public void Dispose()
    {
        _listener.Dispose();
        _client.Dispose();
        _factory.Dispose();
    }
}
