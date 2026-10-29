// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Diagnostics;
using System.Text;
using System.Net;
using global::A2A;
using global::A2A.AspNetCore;
using Azure.AI.AgentServer.A2A.Tests.Snippets;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Azure.AI.AgentServer.Core.Storage;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
public class SampleEndToEndTests
{
    [Test]
    public async Task StreamingSampleDeliversIncrementalArtifactUpdates()
    {
        await using var app = await HostingTests.CreateAppAsync(services =>
            services.AddSingleton<IAgentHandler, EventTransportTestHelpers.StreamingAgent>());
        using var client = app.GetTestClient();
        using var content = HostingTests.Rpc("SendStreamingMessage", MessageParameters("first\nsecond\nthird"));
        string requestJson = await content.ReadAsStringAsync();
        var chunks = new List<string>();
        var artifactIds = new HashSet<string>();
        var arrivals = new List<double>();
        var clock = Stopwatch.StartNew();
        string? state = null;
        bool lastChunk = false;
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        await foreach (var result in EventTransportTestHelpers.ReadEventsAsync(client, requestJson, timeout.Token))
        {
            if (result.TryGetProperty("artifactUpdate", out var update))
            {
                Assert.That(lastChunk, Is.False);
                Assert.That(update.GetProperty("append").GetBoolean(), Is.EqualTo(chunks.Count > 0));
                artifactIds.Add(update.GetProperty("artifact").GetProperty("artifactId").GetString()!);
                chunks.Add(update.GetProperty("artifact").GetProperty("parts")[0].GetProperty("text").GetString()!);
                arrivals.Add(clock.Elapsed.TotalMilliseconds);
                lastChunk = update.GetProperty("lastChunk").GetBoolean();
            }
            else if (result.TryGetProperty("statusUpdate", out var status))
            {
                state = status.GetProperty("status").GetProperty("state").GetString();
            }
        }

        Assert.That(artifactIds, Has.Count.EqualTo(1));
        Assert.That(chunks, Has.Count.EqualTo(3));
        Assert.That(string.Concat(chunks), Is.EqualTo("Echo: first\nsecond\nthird"));
        Assert.That(lastChunk, Is.True);
        Assert.That(state, Is.EqualTo("TASK_STATE_COMPLETED"));
        Assert.That(arrivals[^1] - arrivals[0], Is.GreaterThanOrEqualTo(300));
    }

    [Test]
    public async Task MultiTurnSampleContinuesTheSameTask()
    {
        await using var app = await HostingTests.CreateAppAsync(services =>
            services.AddSingleton<IAgentHandler, Sample3Snippets.ClarificationAgent>());
        using var client = app.GetTestClient();
        using var first = await SendRpcAsync(client, "SendMessage", MessageParameters("Prepare a greeting"));
        var task = first.RootElement.GetProperty("result").GetProperty("task");
        string taskId = task.GetProperty("id").GetString()!;
        string contextId = task.GetProperty("contextId").GetString()!;
        Assert.That(task.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_INPUT_REQUIRED"));

        using var another = await SendRpcAsync(client, "SendMessage", MessageParameters("Another greeting", contextId: contextId));
        var anotherTask = another.RootElement.GetProperty("result").GetProperty("task");
        Assert.That(anotherTask.GetProperty("id").GetString(), Is.Not.EqualTo(taskId));
        Assert.That(anotherTask.GetProperty("contextId").GetString(), Is.EqualTo(contextId));
        Assert.That(anotherTask.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_INPUT_REQUIRED"));

        using var second = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada", taskId, contextId));
        var completed = second.RootElement.GetProperty("result").GetProperty("task");
        Assert.That(completed.GetProperty("id").GetString(), Is.EqualTo(taskId));
        Assert.That(completed.GetProperty("contextId").GetString(), Is.EqualTo(contextId));
        Assert.That(completed.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_COMPLETED"));
        Assert.That(ArtifactText(completed), Is.EqualTo("Hello, Ada!"));
    }

    [TestCase("application/json", """{"jsonrpc":"2.0","result":{}}""")]
    [TestCase("text/event-stream", "data: {\"jsonrpc\":\"2.0\",\"result\":{}}\n")]
    [TestCase("text/event-stream", "data: {\"jsonrpc\":\"2.0\",\"error\":{\"code\":-32603}}\n\n")]
    public void StreamingClientRejectsInvalidResponses(string contentType, string body)
    {
        using var client = new HttpClient(new FixedResponseHandler(contentType, body))
        {
            BaseAddress = new Uri("http://localhost"),
        };
        Assert.ThrowsAsync<InvalidDataException>(async () =>
        {
            await foreach (var _ in EventTransportTestHelpers.ReadEventsAsync(client, "{}")) { }
        });
    }

    [Test]
    public async Task StreamingClientAcceptsMultilineSseEvents()
    {
        using var client = new HttpClient(new FixedResponseHandler("text/event-stream",
            ": heartbeat\n\ndata: {\"jsonrpc\":\"2.0\",\ndata: \"result\":{\"value\":\"ok\"}}\n\n"))
        {
            BaseAddress = new Uri("http://localhost"),
        };
        var events = new List<JsonElement>();
        await foreach (var result in EventTransportTestHelpers.ReadEventsAsync(client, "{}"))
        {
            events.Add(result);
        }

        Assert.That(events, Has.Count.EqualTo(1));
        Assert.That(events[0].GetProperty("value").GetString(), Is.EqualTo("ok"));
    }

    [Test]
    public async Task LongRunningSampleReturnsBeforeWorkCompletes()
    {
        var writer = new ControlledReportWriter();
        var store = new CompletionTrackingStore();
        await using var app = await HostingTests.CreateAppAsync(services =>
        {
            services.AddSingleton<Sample4Snippets.IReportWriter>(writer);
            services.AddSingleton<ITaskStore>(store);
            services.AddSingleton<IAgentHandler, Sample4Snippets.ReportAgent>();
        });
        using var client = app.GetTestClient();
        try
        {
            using var initial = await SendRpcAsync(client, "SendMessage",
                """{"configuration":{"returnImmediately":true},"message":{"messageId":"report-1","role":"ROLE_USER","parts":[{"text":"quarterly results"}]}}""");
            string taskId = initial.RootElement.GetProperty("result").GetProperty("task").GetProperty("id").GetString()!;
            await writer.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(store.Completed.Task.IsCompleted, Is.False);
            using var running = await SendRpcAsync(client, "GetTask", JsonSerializer.Serialize(new { id = taskId }));
            Assert.That(running.RootElement.GetProperty("result").GetProperty("status").GetProperty("state").GetString(),
                Is.AnyOf("TASK_STATE_SUBMITTED", "TASK_STATE_WORKING"));

            writer.Release.TrySetResult("Report: quarterly results");
            await store.Completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
            using var finished = await SendRpcAsync(client, "GetTask", JsonSerializer.Serialize(new { id = taskId }));
            Assert.That(finished.RootElement.GetProperty("result").GetProperty("status").GetProperty("state").GetString(),
                Is.EqualTo("TASK_STATE_COMPLETED"));
            Assert.That(ArtifactText(finished.RootElement.GetProperty("result")), Is.EqualTo("Report: quarterly results"));
        }
        finally
        {
            writer.Release.TrySetResult("Report: quarterly results");
        }
    }

    [Test]
    public async Task CustomBuildUsesConfiguredDependencyStoreAndNativeOptions()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        Sample5Snippets.ConfigureServices(builder.Services);
        builder.AddA2A<Sample5Snippets.GreetingAgent>(ReadMeSnippets.CreateCard(), options => options.AutoAppendHistory = false);
        await using var app = builder.Build().App;
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        Assert.That(MessageText(result.RootElement.GetProperty("result")), Is.EqualTo("Welcome: Ada"));
        Assert.That(app.Services.GetRequiredService<ITaskStore>(), Is.TypeOf<InMemoryTaskStore>());
        Assert.That(app.Services.GetRequiredService<A2AServerOptions>().AutoAppendHistory, Is.False);
    }

    [Test]
    public async Task ExistingRequestHandlerPreservesItsTaskStore()
    {
        var card = ReadMeSnippets.CreateCard();
        var store = new InMemoryTaskStore();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<ITaskStore>(store);
        services.AddA2AAgent<ReadMeSnippets.TaskAgent>(card);
        await using var nativeServices = services.BuildServiceProvider();
        var handler = nativeServices.GetRequiredService<IA2ARequestHandler>();
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddA2A(card, handler);
        await using var app = builder.Build().App;
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        var task = result.RootElement.GetProperty("result").GetProperty("task");
        string taskId = task.GetProperty("id").GetString()!;
        Assert.That(ArtifactText(task), Is.EqualTo("Echo: Ada"));
        Assert.That(await store.GetTaskAsync(taskId), Is.Not.Null);
        Assert.That(app.Services.GetRequiredService<IA2ARequestHandler>(), Is.SameAs(handler));
        Assert.That(app.Services.GetService<ITaskStore>(), Is.Null);
    }

    [Test]
    public async Task NativeApplicationRetainsItsRegistrations()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        Sample7Snippets.RegisterNativeAgent(builder.Services, ReadMeSnippets.CreateCard());
        var nativeRegistration = builder.Services.Single(service => service.ServiceType == typeof(IA2ARequestHandler));
        builder.Services.AddFoundryA2A();
        Assert.That(builder.Services.Single(service => service.ServiceType == typeof(IA2ARequestHandler)),
            Is.SameAs(nativeRegistration));
        await using var app = builder.Build();
        app.MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        Assert.That(MessageText(result.RootElement.GetProperty("result")), Is.EqualTo("Echo: Ada"));
    }

    [Test]
    public async Task Tier1ConfigurationAddsApplicationServicesAndHealthCheck()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddA2A<Sample5Snippets.GreetingAgent>(ReadMeSnippets.CreateCard());
        Sample8Snippets.ConfigureHost(builder);
        await using var app = builder.Build().App;
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        Assert.That(MessageText(result.RootElement.GetProperty("result")), Is.EqualTo("Configured: Ada"));
        Assert.That(app.Services.GetRequiredService<IOptions<AgentHostOptions>>().Value.ShutdownTimeout,
            Is.EqualTo(TimeSpan.FromSeconds(15)));
        var health = await app.Services.GetRequiredService<HealthCheckService>().CheckHealthAsync();
        Assert.That(health.Entries["application"].Status, Is.EqualTo(HealthStatus.Healthy));
    }

    [Test]
    public async Task Tier2CompositionServesBothProtocols()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        Sample9Snippets.ConfigureHost(builder);
        await using var app = builder.Build().App;
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        Assert.That(MessageText(result.RootElement.GetProperty("result")), Is.EqualTo("Composed: Ada"));
        using var invocation = await client.PostAsync("/invocations", new StringContent("status", Encoding.UTF8, "text/plain"));
        Assert.That(invocation.IsSuccessStatusCode, Is.True);
        Assert.That(await invocation.Content.ReadAsStringAsync(), Is.EqualTo("Agent is ready"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task Tier3HostingCoexistsWithApplicationRoutes(bool mapRoutesOnly)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<ReadMeSnippets.EchoAgent>(ReadMeSnippets.CreateCard());
        await using var app = builder.Build();
        app.MapGet("/", () => "My application");
        if (mapRoutesOnly)
        {
            app.UseAgentServerCore();
            app.MapHealthChecks("/readiness");
            ((Microsoft.AspNetCore.Routing.IEndpointRouteBuilder)app).MapFoundryA2A();
        }
        else
        {
            app.MapFoundryA2A();
        }

        await app.StartAsync();
        using var client = app.GetTestClient();
        Assert.That(await client.GetStringAsync("/"), Is.EqualTo("My application"));
        using var readiness = await client.GetAsync("/readiness");
        Assert.That(readiness.IsSuccessStatusCode, Is.True);
        using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("Ada"));
        Assert.That(MessageText(result.RootElement.GetProperty("result")), Is.EqualTo("Echo: Ada"));
    }

    [Test]
    [NonParallelizable]
    public async Task PersistenceSampleRetrievesSnapshotAfterHostReconstruction()
    {
        string? previous = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        string root = Path.Combine(Path.GetTempPath(), $"a2a-sample-{Guid.NewGuid():N}");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);
        const string name = "sample/tasks";
        try
        {
            string taskId;
            using (var store = await Sample11Snippets.CreateLocalStoreAsync(name))
            {
                await using var app = await HostingTests.CreateAppAsync(services =>
                {
                    services.AddSingleton<ITaskStore>(store);
                    services.AddSingleton<IAgentHandler, ReadMeSnippets.TaskAgent>();
                });
                using var client = app.GetTestClient();
                using var result = await SendRpcAsync(client, "SendMessage", MessageParameters("persisted"));
                taskId = result.RootElement.GetProperty("result").GetProperty("task").GetProperty("id").GetString()!;
            }

            using var restoredStore = await Sample11Snippets.CreateLocalStoreAsync(name);
            await using var restoredApp = await HostingTests.CreateAppAsync(services =>
                services.AddSingleton<ITaskStore>(restoredStore));
            using var restoredClient = restoredApp.GetTestClient();
            using var restored = await SendRpcAsync(restoredClient, "GetTask", JsonSerializer.Serialize(new { id = taskId }));
            var task = restored.RootElement.GetProperty("result");
            Assert.That(task.GetProperty("id").GetString(), Is.EqualTo(taskId));
            Assert.That(task.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_COMPLETED"));
            Assert.That(ArtifactText(task), Is.EqualTo("Echo: persisted"));
            var backing = await FoundryStateStore.GetOrCreateAsync(name);
            Assert.That((await backing.GetAsync())!.ItemTtlSeconds, Is.EqualTo(3600));
            await backing.DeleteAsync();
        }
        finally
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previous);
            if (Directory.Exists(root))
            {
                Directory.Delete(root, recursive: true);
            }
        }
    }

    private static string MessageText(JsonElement result) =>
        result.GetProperty("message").GetProperty("parts")[0].GetProperty("text").GetString()!;

    private sealed class ControlledReportWriter : Sample4Snippets.IReportWriter
    {
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource<string> Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task<string> WriteAsync(string input, CancellationToken cancellationToken)
        {
            Started.TrySetResult();
            return await Release.Task.WaitAsync(cancellationToken);
        }
    }

    private sealed class FixedResponseHandler(string contentType, string body) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, contentType),
            });
    }

    private sealed class CompletionTrackingStore : ITaskStore
    {
        private readonly InMemoryTaskStore _inner = new();
        public TaskCompletionSource Completed { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public Task<AgentTask?> GetTaskAsync(string taskId, CancellationToken cancellationToken = default) =>
            _inner.GetTaskAsync(taskId, cancellationToken);

        public async Task SaveTaskAsync(string taskId, AgentTask task, CancellationToken cancellationToken = default)
        {
            await _inner.SaveTaskAsync(taskId, task, cancellationToken);
            if (task.Status.State == TaskState.Completed)
            {
                Completed.TrySetResult();
            }
        }

        public Task DeleteTaskAsync(string taskId, CancellationToken cancellationToken = default) =>
            _inner.DeleteTaskAsync(taskId, cancellationToken);

        public Task<ListTasksResponse> ListTasksAsync(ListTasksRequest request, CancellationToken cancellationToken = default) =>
            _inner.ListTasksAsync(request, cancellationToken);
    }

    private static string MessageParameters(string text, string? taskId = null, string? contextId = null) =>
        JsonSerializer.Serialize(new
        {
            message = new
            {
                messageId = Guid.NewGuid().ToString("N"),
                role = "ROLE_USER",
                parts = new[] { new { text } },
                taskId,
                contextId,
            },
        }, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });

    private static async Task<JsonDocument> SendRpcAsync(HttpClient client, string method, string parameters)
    {
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc(method, parameters))
            .WaitAsync(TimeSpan.FromSeconds(10));
        string body = await response.Content.ReadAsStringAsync();
        Assert.That(response.IsSuccessStatusCode, Is.True, body);
        var json = JsonDocument.Parse(body);
        if (json.RootElement.TryGetProperty("error", out _))
        {
            json.Dispose();
            Assert.Fail(body);
        }

        return json;
    }

    private static string ArtifactText(JsonElement task) =>
        task.GetProperty("artifacts")[0].GetProperty("parts")[0].GetProperty("text").GetString()!;

    [TestCase(false)]
    [TestCase(true)]
    public async Task EchoSampleWorksThroughBothHostingEntryPoints(bool sharedHost)
    {
        WebApplication app;
        if (sharedHost)
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.AddA2A<ReadMeSnippets.EchoAgent>(ReadMeSnippets.CreateCard());
            app = builder.Build().App;
        }
        else
        {
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseTestServer();
            builder.Services.AddFoundryA2A<ReadMeSnippets.EchoAgent>(ReadMeSnippets.CreateCard());
            app = builder.Build();
            app.MapFoundryA2A();
        }

        await using (app)
        {
            await app.StartAsync();
            using var client = app.GetTestClient();
            using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
            var text = await response.Content.ReadAsStringAsync();
            using var json = JsonDocument.Parse(text);
            Assert.That(json.RootElement.GetProperty("result").GetProperty("message").GetProperty("parts")[0]
                .GetProperty("text").GetString(), Is.EqualTo("Echo: hello"));
        }
    }

    [Test]
    public async Task NativeTaskSampleEmitsCompletedTaskAndArtifact()
    {
        await using var app = await HostingTests.CreateAppAsync(services =>
            services.AddSingleton<IAgentHandler, ReadMeSnippets.TaskAgent>());
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
        using var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var task = json.RootElement.GetProperty("result").GetProperty("task");
        Assert.That(task.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_COMPLETED"));
        Assert.That(task.GetProperty("artifacts")[0].GetProperty("parts")[0].GetProperty("text").GetString(),
            Is.EqualTo("Echo: hello"));

        string taskId = task.GetProperty("id").GetString()!;
        using var lookup = await client.PostAsync("/a2a", HostingTests.Rpc("GetTask", $$"""{"id":"{{taskId}}"}"""));
        using var stored = JsonDocument.Parse(await lookup.Content.ReadAsStringAsync());
        var storedTask = stored.RootElement.GetProperty("result");
        Assert.That(storedTask.GetProperty("id").GetString(), Is.EqualTo(taskId));
        Assert.That(storedTask.GetProperty("status").GetProperty("state").GetString(), Is.EqualTo("TASK_STATE_COMPLETED"));
        Assert.That(storedTask.GetProperty("artifacts")[0].GetProperty("parts")[0].GetProperty("text").GetString(),
            Is.EqualTo("Echo: hello"));
    }
}
