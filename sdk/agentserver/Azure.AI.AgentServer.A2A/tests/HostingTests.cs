// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using global::A2A;
using global::A2A.AspNetCore;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using A2ARequestContext = global::A2A.RequestContext;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
public class HostingTests
{
    internal static AgentCard CreateCard() => new()
    {
        Name = "native-echo",
        Description = "Native echo agent",
        Version = "1.0",
        Capabilities = new() { Streaming = true },
        SupportedInterfaces =
        [
            new() { Url = "http://localhost/a2a", ProtocolBinding = "JSONRPC", ProtocolVersion = "1.0" },
        ],
        Skills = [new() { Id = "echo", Name = "Echo", Description = "Echoes input", Tags = ["echo"] }],
        DefaultInputModes = ["text/plain"],
        DefaultOutputModes = ["text/plain"],
    };

    internal static async Task<WebApplication> CreateAppAsync(Action<IServiceCollection>? configure = null)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<EchoHandler>(CreateCard());
        configure?.Invoke(builder.Services);
        var app = builder.Build();
        app.MapFoundryA2A();
        await app.StartAsync();
        return app;
    }

    internal static StringContent Rpc(string method, string parameters = "{}") =>
        new($$"""{"jsonrpc":"2.0","id":"rpc-1","method":"{{method}}","params":{{parameters}}}""",
            Encoding.UTF8, "application/json");

    internal const string MessageParams =
        """{"message":{"messageId":"message-1","role":"ROLE_USER","contextId":"conversation-1","parts":[{"text":"hello"}]}}""";

    [TestCase("/a2a")]
    [TestCase("/invocations/a2a")]
    public async Task NativeMessageAndPlatformHeaders(string path)
    {
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        client.DefaultRequestHeaders.Add("x-agent-foundry-call-id", "call-1");
        client.DefaultRequestHeaders.Add("x-agent-user-id", "user-1");
        using var response = await client.PostAsync(path, Rpc("SendMessage", MessageParams));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
        using var json = JsonDocument.Parse(body);
        Assert.That(json.RootElement.GetProperty("id").GetString(), Is.EqualTo("rpc-1"));
        Assert.That(json.RootElement.TryGetProperty("error", out _), Is.False, body);
        Assert.That(body, Does.Contain("hello|call-1|user-1"));
        Assert.That(response.Headers.GetValues("x-platform-server").Single(), Does.Contain("azure-ai-agentserver-a2a"));
        Assert.That(response.Headers.Contains("x-agent-user-id"), Is.False);
        Assert.That(FoundryAgentRequestContext.Current.UserId, Is.Null);
    }

    [Test]
    public async Task CardsAndReadiness()
    {
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        var canonical = await client.GetStringAsync("/a2a/.well-known/agent-card.json");
        var alias = await client.GetStringAsync("/invocations/a2a/.well-known/agent-card.json");
        Assert.That(alias, Is.EqualTo(canonical));
        Assert.That(canonical, Does.Contain("native-echo"));
        using var ready = await client.GetAsync("/readiness");
        Assert.That(ready.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var rest = await client.GetAsync("/a2a/tasks");
        Assert.That(rest.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task NativeSseAndSemanticSpan()
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.A2A",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc("SendStreamingMessage", MessageParams));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(response.Content.Headers.ContentType!.MediaType, Is.EqualTo("text/event-stream"), body);
        Assert.That(body, Does.Contain("data:"));
        Assert.That(body, Does.Contain("hello"));
        var span = stopped.Single(a => a.OperationName == "SendStreamingMessage");
        Assert.That(span.Kind, Is.EqualTo(ActivityKind.Server));
        Assert.That(span.GetTagItem("gen_ai.agent.name"), Is.EqualTo("native-echo"));
        Assert.That(span.GetTagItem("gen_ai.conversation.id"), Is.EqualTo("conversation-1"));
    }

    [TestCase("UnknownMethod")]
    [TestCase("GetTask")]
    public async Task JsonRpcErrorsStayHttp200AndMarkSpan(string method)
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.A2A",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc(method, """{"id":"missing"}"""));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
        Assert.That(body, Does.Contain("\"error\""));
        Assert.That(response.Headers.Contains("x-platform-error-source"), Is.False);
        Assert.That(stopped.Single(a => a.OperationName == method).Status, Is.EqualTo(ActivityStatusCode.Error));
    }

    [Test]
    public async Task CustomTaskStoreIsPreserved()
    {
        var store = new InMemoryTaskStore();
        await using var app = await CreateAppAsync(services => services.AddSingleton<ITaskStore>(store));
        Assert.That(app.Services.GetRequiredService<ITaskStore>(), Is.SameAs(store));
    }

    [Test]
    public void DuplicateProtocolIsRejected()
    {
        var builder = AgentHost.CreateBuilder();
        builder.AddA2A<EchoHandler>(CreateCard());
        Assert.Throws<InvalidOperationException>(() => builder.AddA2A<EchoHandler>(CreateCard()));
    }

    [Test]
    public void NullServiceCollectionIsRejected()
    {
        IServiceCollection services = null!;
        Assert.Throws<ArgumentNullException>(() => services.AddFoundryA2A());
        Assert.Throws<ArgumentNullException>(() => services.AddFoundryA2A<EchoHandler>(CreateCard()));
        Assert.Throws<ArgumentNullException>(() => services.AddFoundryA2A(CreateCard(), null!));
    }

    [Test]
    public void NullCardAndRequestHandlerAreRejected()
    {
        var services = new ServiceCollection();
        Assert.Throws<ArgumentNullException>(() => services.AddFoundryA2A<EchoHandler>(null!));
        Assert.Throws<ArgumentNullException>(() => services.AddFoundryA2A(CreateCard(), null!));

        var builder = AgentHost.CreateBuilder();
        Assert.Throws<ArgumentNullException>(() => builder.AddA2A<EchoHandler>(null!));
        Assert.Throws<ArgumentNullException>(() => builder.AddA2A(CreateCard(), null!));
        Assert.Throws<ArgumentNullException>(() => A2AAgentServer.Run<EchoHandler>(null!));
        Assert.Throws<ArgumentNullException>(() => A2AAgentServer.Run(CreateCard(), null!));
    }

    [Test]
    public void NullHostAndEndpointBuildersAreRejected()
    {
        AgentHostBuilder builder = null!;
        WebApplication app = null!;
        IEndpointRouteBuilder endpoints = null!;
        Assert.Throws<ArgumentNullException>(() => builder.AddA2A<EchoHandler>(CreateCard()));
        Assert.Throws<ArgumentNullException>(() => builder.AddA2A(CreateCard(), null!));
        Assert.Throws<ArgumentNullException>(() => app.MapFoundryA2A());
        Assert.Throws<ArgumentNullException>(() => endpoints.MapFoundryA2A());
    }

    [Test]
    public async Task NativeOptionsCallbackIsAppliedOnce()
    {
        int configured = 0;
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<EchoHandler>(CreateCard(), options =>
        {
            configured++;
            options.AutoAppendHistory = false;
        });
        await using var app = builder.Build();
        app.MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc("SendMessage", MessageParams));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(configured, Is.EqualTo(1));
        Assert.That(app.Services.GetRequiredService<A2AServerOptions>().AutoAppendHistory, Is.False);
    }

    [Test]
    public async Task ExistingNativeHandlerAndItsStorageArePreserved()
    {
        await using var original = await CreateAppAsync();
        var native = original.Services.GetRequiredService<IA2ARequestHandler>();
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A(CreateCard(), native);
        await using var app = builder.Build();
        app.MapFoundryA2A();
        await app.StartAsync();
        Assert.That(app.Services.GetRequiredService<IA2ARequestHandler>(), Is.SameAs(native));
        Assert.That(app.Services.GetService<ITaskStore>(), Is.Null);
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc("SendMessage", MessageParams));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("hello"));
    }

    [Test]
    public async Task ExistingNativeRegistrationCanOptIntoFoundryHosting()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddA2AAgent<EchoHandler>(CreateCard());
        builder.Services.AddFoundryA2A();
        await using var app = builder.Build();
        app.MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc("SendMessage", MessageParams));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("hello"));
    }

    [TestCase("CreateTaskPushNotificationConfig")]
    [TestCase("GetExtendedAgentCard")]
    public async Task UnsupportedSurfacesReturnNativeErrors(string method)
    {
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", Rpc(method));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("\"error\""));
    }

    [Test]
    public async Task MalformedJsonIsValidatedByNativeTransport()
    {
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", new StringContent("{", Encoding.UTF8, "application/json"));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("-32700"));
    }

    [Test]
    public async Task StreamingIsIncrementalAndSpanCoversTransmission()
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "Azure.AI.AgentServer.A2A",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);
        var gate = new GatedTaskHandler();
        await using var app = await CreateAppAsync(services => services.AddSingleton<IAgentHandler>(gate));
        using var client = app.GetTestClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a")
        {
            Content = Rpc("SendStreamingMessage", MessageParams),
        };
        try
        {
            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .WaitAsync(TimeSpan.FromSeconds(10));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            string first = await ReadDataAsync(reader);
            Assert.That(first, Does.Contain("\"task\""));
            Assert.That(stopped.Any(a => a.OperationName == "SendStreamingMessage"), Is.False);
            gate.Release.TrySetResult();
            await reader.ReadToEndAsync().WaitAsync(TimeSpan.FromSeconds(10));
            await gate.Completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        }
        finally
        {
            gate.Release.TrySetResult();
        }
    }

    internal static async Task<string> ReadDataAsync(StreamReader reader)
    {
        while (await reader.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(10)) is { } line)
        {
            if (line.StartsWith("data:", StringComparison.Ordinal))
            {
                return line[5..].TrimStart();
            }
        }

        throw new AssertionException("The native SSE response did not contain a data event.");
    }

    internal sealed class GatedTaskHandler : IAgentHandler
    {
        public TaskCompletionSource Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource Completed { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task ExecuteAsync(A2ARequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
        {
            try
            {
                var updater = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
                await updater.SubmitAsync(cancellationToken: cancellationToken);
                await Release.Task.WaitAsync(cancellationToken);
                await updater.CompleteAsync(cancellationToken: cancellationToken);
            }
            finally
            {
                Completed.TrySetResult();
            }
        }
    }

    public sealed class EchoHandler : IAgentHandler
    {
        public async Task ExecuteAsync(A2ARequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
        {
            var platform = FoundryAgentRequestContext.Current;
            await new MessageResponder(eventQueue, context.ContextId).ReplyAsync(
                $"{context.UserText}|{platform.CallId}|{platform.UserId}", cancellationToken: cancellationToken);
        }
    }
}
