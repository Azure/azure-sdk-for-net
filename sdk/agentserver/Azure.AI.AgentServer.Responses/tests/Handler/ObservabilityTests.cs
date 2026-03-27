// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-emit" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-emit");

        Assert.That(activity, Is.Not.Null);

        var responseId = activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId) as string;
        Assert.That(responseId, Is.Not.Null);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task CreateResponse_DefaultMode_SetsParityTags()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-default" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-default" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-default");

        Assert.That(activity, Is.Not.Null);

        // Core-parity tags
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName), Is.EqualTo(ResponsesTracingConstants.ServiceName));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.EqualTo(ResponsesTracingConstants.ProviderName));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.EqualTo(false));

        // Removed tags should not be present
        Assert.That(activity.GetTagItem("response.mode"), Is.Null);
        Assert.That(activity.GetTagItem("response.status"), Is.Null);
    }

    [Test]
    public async Task CreateResponse_StreamingMode_SetsStreamingTrue()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-stream", stream = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-stream" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-stream");

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.EqualTo(true));
    }

    [Test]
    public async Task CreateResponse_BackgroundMode_SetsStreamingFalse()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-background", background = true });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-background" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-background");

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.EqualTo(false));
    }

    [Test]
    public async Task CreateResponse_SetsNamespacedResponseId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-nsid" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-nsid" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-nsid");

        Assert.That(activity, Is.Not.Null);

        // gen_ai.response.id and azure.ai.agentserver.responses.response_id should match
        var genAiId = activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId) as string;
        var namespacedId = activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedResponseId) as string;
        Assert.That(genAiId, Is.Not.Null);
        Assert.That(namespacedId, Is.EqualTo(genAiId));
    }

    [Test]
    public async Task CreateResponse_NoAgent_SetsEmptyAgentId()
    {
        var body = JsonSerializer.Serialize(new { model = "obs-test-no-agent" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var activity = _activities.FirstOrDefault(a =>
            a.OperationName == "invoke_agent obs-test-no-agent" &&
            a.GetTagItem(ResponsesTracingConstants.Tags.RequestModel) as string == "obs-test-no-agent");

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId), Is.EqualTo(string.Empty));
    }

    public void Dispose()
    {
        _listener.Dispose();
        _client.Dispose();
        _factory.Dispose();
    }
}
