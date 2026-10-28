// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Invocations;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class MultiProtocolCompositionTests
{
    [Test]
    public async Task InvocationsEndpoint_AndHealthEndpoint_BothReachable()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations<TestInvocationHandler>();

        var app = builder.Build();
        await app.App.StartAsync();

        var client = app.App.GetTestClient();

        // POST /invocations works
        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // GET /readiness works
        var healthResponse = await client.GetAsync("/readiness");
        Assert.That(healthResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.App.StopAsync();
    }

    [Test]
    public void DuplicateProtocol_ThrowsInvalidOperationException()
    {
        var builder = AgentHost.CreateBuilder();
        builder.AddInvocations<TestInvocationHandler>();

        Assert.Throws<InvalidOperationException>(() =>
        {
            builder.AddInvocations<TestInvocationHandler>();
        });
    }

    [TestCase(false, "disabled")]
    [TestCase(true, "enabled")]
    public async Task ResponsesEnablement_DoesNotChangeInvocationsTaskOptIn(
        bool invocationsEnabled, string expected)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-mixed-task-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(directory));
            builder.Services.AddResilientTask<string, string>(
                "mixed-probe", (ctx, ct) => Task.FromResult(ctx.Input));
            if (invocationsEnabled)
            {
                builder.SetResilientTasksEnabled();
            }

            builder.AddInvocations<TaskProbeInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                using var response = await app.App.GetTestClient().PostAsync(
                    "/invocations", new StringContent("test"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo(expected));
            }
            finally
            {
                await app.App.StopAsync();
            }
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [TestCase(true, false, "disabled")]
    [TestCase(false, true, "enabled")]
    public async Task InvocationsEnablement_DoesNotChangeStreamingResponsesTaskAccess(
        bool invocationsEnabled, bool responsesEnabled, string expected)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-response-scope-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(directory));
            builder.Services.AddResilientTask<string, string>(
                "response-scope-probe", (ctx, ct) => Task.FromResult(ctx.Input));
            if (invocationsEnabled)
            {
                builder.SetResilientTasksEnabled();
            }

            var observed = new TaskCompletionSource<string>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            builder.Services.AddSingleton(observed);
            builder.AddInvocations<TestInvocationHandler>();
            builder.AddResponses<TaskProbeResponseHandler>(
                options => options.SteerableConversations = responsesEnabled);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                using var response = await app.App.GetTestClient().PostAsync(
                    "/responses",
                    new StringContent(
                        "{\"model\":\"test\",\"store\":false,\"stream\":true}",
                        Encoding.UTF8, "application/json"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                await response.Content.ReadAsStringAsync();
                Assert.That(
                    await observed.Task.WaitAsync(TimeSpan.FromSeconds(10)),
                    Is.EqualTo(expected));
            }
            finally
            {
                await app.App.StopAsync();
            }
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [TestCase(false, "disabled")]
    [TestCase(true, "enabled")]
    public async Task ResponsesEnablement_DoesNotChangeInvocationsWebSocketTaskAccess(
        bool invocationsEnabled, string expected)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-ws-scope-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(directory));
            builder.Services.AddResilientTask<string, string>(
                "ws-probe", (ctx, ct) => Task.FromResult(ctx.Input));
            if (invocationsEnabled)
            {
                builder.SetResilientTasksEnabled();
            }

            builder.AddInvocations<WebSocketProbeHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                var server = app.App.GetTestServer();
                using WebSocket socket = await server.CreateWebSocketClient().ConnectAsync(
                    new Uri(server.BaseAddress, "invocations_ws"), CancellationToken.None);
                var buffer = new byte[128];
                var result = await socket.ReceiveAsync(
                    buffer, CancellationToken.None);
                Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Text));
                Assert.That(Encoding.UTF8.GetString(buffer, 0, result.Count), Is.EqualTo(expected));
            }
            finally
            {
                await app.App.StopAsync();
            }
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    private sealed class WebSocketProbeHandler(IServiceProvider services) : InvocationWebSocketHandler
    {
        public override async Task HandleWebSocketAsync(
            WebSocket socket, InvocationContext context, CancellationToken cancellationToken)
        {
            TaskDefinition<string, string> task = services.GetResilientTask<string, string>("ws-probe");
            string result;
            try
            {
                result = await task.RunAsync("enabled", cancellationToken: cancellationToken);
            }
            catch (ResilientTaskException ex) when (ex.ErrorCode == ResilientTaskErrorCode.NotEnabled)
            {
                result = "disabled";
            }

            await socket.SendAsync(
                Encoding.UTF8.GetBytes(result), WebSocketMessageType.Text,
                endOfMessage: true, cancellationToken);
        }
    }

    private sealed class TaskProbeInvocationHandler(IServiceProvider services) : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            TaskDefinition<string, string> task = services.GetResilientTask<string, string>("mixed-probe");
            try
            {
                await task.RunAsync("enabled", cancellationToken: cancellationToken);
                await response.WriteAsync("enabled", cancellationToken);
            }
            catch (ResilientTaskException ex) when (ex.ErrorCode == ResilientTaskErrorCode.NotEnabled)
            {
                await response.WriteAsync("disabled", cancellationToken);
            }
        }
    }

    private sealed class TestResponseHandler : ResponseHandler
    {
        public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
            CreateResponse request,
            ResponseContext context,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var response = new ResponseObject(context.ResponseId, request.Model ?? "test");
            yield return new ResponseCreatedEvent(0, response);
            await Task.Yield();
            response.Status = ResponseStatus.Completed;
            yield return new ResponseCompletedEvent(1, response);
        }
    }

    private sealed class TaskProbeResponseHandler(
        IServiceProvider services, TaskCompletionSource<string> observed) : ResponseHandler
    {
        public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
            CreateResponse request,
            ResponseContext context,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
        {
            TaskDefinition<string, string> task = services.GetResilientTask<string, string>(
                "response-scope-probe");
            try
            {
                observed.TrySetResult(await task.RunAsync("enabled", cancellationToken: cancellationToken));
            }
            catch (ResilientTaskException ex) when (ex.ErrorCode == ResilientTaskErrorCode.NotEnabled)
            {
                observed.TrySetResult("disabled");
            }

            var response = new ResponseObject(context.ResponseId, request.Model ?? "test");
            yield return new ResponseCreatedEvent(0, response);
            await Task.Yield();
            response.Status = ResponseStatus.Completed;
            yield return new ResponseCompletedEvent(1, response);
        }
    }

    private sealed class TestInvocationHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("ok", cancellationToken);
        }
    }
}
