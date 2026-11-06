// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using global::A2A;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
[NonParallelizable]
public class BehaviorParityTests
{
    [TestCase("/a2a", "GET", false)]
    [TestCase("/a2a/.well-known/agent-card.json", "POST", false)]
    [TestCase("/a2a", "GET", true)]
    [TestCase("/a2a/.well-known/agent-card.json", "POST", true)]
    [TestCase("/a2a/", "GET", false)]
    public async Task MethodErrorsAreClassifiedThroughTheWholePipeline(string path, string method, bool coreHost)
    {
        await using var app = await CreateAppAsync(coreHost);
        using var client = app.GetTestClient();
        using var request = new HttpRequestMessage(new HttpMethod(method), path);
        using var response = await client.SendAsync(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
        Assert.That(response.Headers.GetValues(PlatformHeaders.ErrorSource).Single(), Is.EqualTo(PlatformHeaders.ErrorSourceUser));
    }

    [Test]
    public async Task RouteOnlyMappingClassifiesMethodErrors()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
        await using var app = builder.Build();
        app.UseAgentServerCore();
        ((IEndpointRouteBuilder)app).MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var response = await client.GetAsync("/a2a");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
        Assert.That(response.Headers.GetValues(PlatformHeaders.ErrorSource).Single(), Is.EqualTo("user"));
    }

    [Test]
    public async Task UnrelatedRoutesAreNotClassified()
    {
        await using var app = await CreateAppAsync(false);
        using var client = app.GetTestClient();
        using var response = await client.GetAsync("/not-an-a2a-route");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.False);
    }

    [Test]
    public async Task ErrorClassificationPreservesAnExplicitSourceAndSuccessfulResponses()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
        builder.Services.AddFoundryA2A();
        await using var app = builder.Build();
        app.Use(async (context, next) =>
        {
            if (context.Request.Method == "GET" && context.Request.Path == "/a2a")
            {
                context.Response.Headers[PlatformHeaders.ErrorSource] = "platform";
            }

            await next(context);
        });
        app.MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var error = await client.GetAsync("/a2a");
        Assert.That(error.Headers.GetValues(PlatformHeaders.ErrorSource), Is.EqualTo(new[] { "platform" }));
        using var success = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
        Assert.That(success.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(success.Headers.Contains(PlatformHeaders.ErrorSource), Is.False);
    }

    [TestCase("GetTask", """{"id":"task-1"}""")]
    [TestCase("ListTasks", "{}")]
    [TestCase("CancelTask", """{"id":"task-1"}""")]
    [TestCase("SubscribeToTask", """{"id":"task-1"}""")]
    public async Task BackingStoreFailuresAreConvertedByNativeTransport(string method, string parameters)
    {
        var failure = new IOException("Storage unavailable for transport test");
        await using var app = await CreateAppAsync(false, services =>
        {
            services.AddSingleton<ITaskStore>(new FoundryTaskStore(new FailingStateStore(failure)));
        });
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc(method, parameters));
        string body = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
        Assert.That(body, Does.Contain("\"error\""));
        Assert.That(body, Does.Not.Contain(failure.Message));
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.False);
    }

    [TestCase("read", false)]
    [TestCase("save", false)]
    [TestCase("delete", false)]
    [TestCase("list", false)]
    [TestCase("read", true)]
    [TestCase("save", true)]
    [TestCase("delete", true)]
    [TestCase("list", true)]
    public void StorageFailuresAndCancellationPropagateToTheCaller(string operation, bool cancelled)
    {
        using var cancellation = new CancellationTokenSource();
        if (cancelled)
        {
            cancellation.Cancel();
        }

        Exception failure = cancelled
            ? new OperationCanceledException(cancellation.Token)
            : new IOException("Backing store unavailable");
        using var store = new FoundryTaskStore(new FailingStateStore(failure));
        Func<Task> action = operation switch
        {
            "read" => () => store.GetTaskAsync("task-1", cancellation.Token),
            "save" => () => store.SaveTaskAsync("task-1", FoundryTaskStoreTests.CreateTask("task-1"), cancellation.Token),
            "delete" => () => store.DeleteTaskAsync("task-1", cancellation.Token),
            "list" => () => store.ListTasksAsync(new(), cancellation.Token),
            _ => throw new ArgumentOutOfRangeException(nameof(operation)),
        };
        var actual = Assert.CatchAsync(async () => await action());
        if (cancelled)
        {
            Assert.That(actual, Is.InstanceOf<OperationCanceledException>());
            Assert.That(((OperationCanceledException)actual!).CancellationToken, Is.EqualTo(cancellation.Token));
        }
        else
        {
            Assert.That(actual, Is.SameAs(failure));
        }
    }

    [Test]
    public async Task MissingTaskReturnsNativeTaskNotFoundError()
    {
        await using var app = await CreateAppAsync(false);
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("GetTask", """{"id":"missing"}"""));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.That(body.RootElement.GetProperty("error").GetProperty("code").GetInt32(),
            Is.EqualTo((int)A2AErrorCode.TaskNotFound));
    }

    [Test]
    public async Task LargeRequestDoesNotRequireTemporaryFilesOrLoseItsBody()
    {
        string? previous = Environment.GetEnvironmentVariable("ASPNETCORE_TEMP");
        Environment.SetEnvironmentVariable("ASPNETCORE_TEMP", Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"), "absent"));
        try
        {
            await using var app = await CreateAppAsync(false, services =>
            {
                services.AddHttpContextAccessor();
                services.AddSingleton<IAgentHandler, BodyInspectingAgent>();
            });
            using var client = app.GetTestClient();
            string input = new('x', 128 * 1024);
            string parameters = JsonSerializer.Serialize(new
            {
                message = new { messageId = "large", role = "ROLE_USER", parts = new[] { new { text = input } } },
            });
            using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", parameters));
            string body = await response.Content.ReadAsStringAsync();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
            Assert.That(body, Does.Contain("memory:131072"), body);
        }
        finally
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_TEMP", previous);
        }
    }

    private static async Task<WebApplication> CreateAppAsync(bool coreHost, Action<IServiceCollection>? configure = null)
    {
        WebApplication app;
        if (coreHost)
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.AddA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
            configure?.Invoke(builder.Services);
            app = builder.Build().App;
        }
        else
        {
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseTestServer();
            builder.Services.AddFoundryA2A<HostingTests.EchoHandler>(HostingTests.CreateCard());
            configure?.Invoke(builder.Services);
            app = builder.Build();
            app.MapFoundryA2A();
        }

        await app.StartAsync();
        return app;
    }

    private sealed class BodyInspectingAgent(IHttpContextAccessor accessor) : IAgentHandler
    {
        public async Task ExecuteAsync(global::A2A.RequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
        {
            string reply = accessor.HttpContext!.Request.Body is MemoryStream
                ? $"memory:{context.UserText!.Length}" : "not-memory";
            await new MessageResponder(eventQueue, context.ContextId).ReplyAsync(reply, cancellationToken: cancellationToken);
        }
    }

    private sealed class FailingStateStore(Exception failure) : FoundryStateStore
    {
        public override Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken = default) =>
            Task.FromException<StateStoreItem?>(failure);
        public override Task<StateStoreItemRef> SetItemAsync(
            string key, IDictionary<string, BinaryData> value, IReadOnlyDictionary<string, string>? tags = null,
            ETag ifMatch = default, bool requireExists = false, CancellationToken cancellationToken = default) =>
            Task.FromException<StateStoreItemRef>(failure);
        public override Task<DeletedStateStoreItem> DeleteItemAsync(
            string key, ETag ifMatch = default, CancellationToken cancellationToken = default) =>
            Task.FromException<DeletedStateStoreItem>(failure);
        public override Task<StateStoreItemKeyPage> ListKeysAsync(
            IReadOnlyDictionary<string, string>? tags = null, int? limit = null, string? after = null,
            string? before = null, ListRequestOrder order = ListRequestOrder.Desc, CancellationToken cancellationToken = default) =>
            Task.FromException<StateStoreItemKeyPage>(failure);
    }
}
