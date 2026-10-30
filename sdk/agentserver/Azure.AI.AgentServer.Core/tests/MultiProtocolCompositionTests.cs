// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AAAS003 // Verify experimental protocol task scopes end to end.

using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Core.Tests.Tasks;
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
    [TestCase(true, true, "enabled")]
    public async Task ResponsesScopedCustomTask_FollowsProtocolEnablement(
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

    [Test]
    public async Task ResponsesEnablement_DoesNotActivateUnscopedCoreTasks()
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-unscoped-task-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(directory));
            builder.Services.AddResilientTask<string, string>(
                "unscoped-probe", (ctx, ct) => Task.FromResult(ctx.Input));
            builder.AddInvocations<TestInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                TaskDefinition<string, string> task = app.App.Services.GetResilientTask<string, string>(
                    "unscoped-probe");
                ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
                    () => task.RunAsync("must-not-run"))!;
                Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
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

    [TestCase(false)]
    [TestCase(true)]
    public async Task ResponsesEnablement_RecoversOnlyResponseOwnedCustomTasks(bool responseOwned)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-disabled-recovery-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            using var previous = TaskTestHost.Create(
                directory,
                agentName: TaskEngineConstants.DefaultAgentName,
                sessionId: TaskEngineConstants.DefaultSessionId);
            TaskDefinition<string, string> task = previous.Builder.AddTask<string, string>(
                "invocations-recovery-probe",
                async (ctx, ct) =>
                {
                    await ctx.ExitForRecoveryAsync(ct);
                    return ctx.Input;
                });
            previous.SignalShutdown();
            TaskRun<string> run = await task.StartAsync(
                "pending", new RunOptions { TaskId = "invocations-recovery-1" });
            await previous.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));

            var store = new LocalTaskStore(directory);
            if (responseOwned)
            {
                var existing = await store.GetAsync(run.TaskId)
                    ?? throw new InvalidOperationException("The first lifetime did not persist its task.");
                await store.PatchAsync(
                    run.TaskId,
                    new TaskPatchRequest
                    {
                        Payload = new JsonObject { [TaskWireKeys.PayloadProtocolScope] = TaskWireKeys.ProtocolResponses },
                        PayloadSupplied = true,
                    },
                    existing.Etag);
            }

            string original = (await store.GetAsync(run.TaskId))?.ToJson().ToJsonString()
                ?? throw new InvalidOperationException("The first lifetime did not persist its task.");
            int recovered = 0;
            var recoverySignal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var nestedResult = new TaskCompletionSource<string>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(store);
            TaskDefinition<string, string> child = builder.Services.AddResilientTask<string, string>(
                "response-recovery-child", (ctx, ct) => Task.FromResult("child:" + ctx.Input));
            builder.Services.AddResilientTask<string, string>(
                "invocations-recovery-probe",
                async (ctx, ct) =>
                {
                    Interlocked.Increment(ref recovered);
                    if (responseOwned)
                    {
                        nestedResult.TrySetResult(await child.RunAsync("payload", cancellationToken: ct));
                    }

                    recoverySignal.TrySetResult();
                    return ctx.Input;
                });
            builder.AddInvocations<TestInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                await app.App.Services.GetRequiredService<RecoveryScanner>().ScanAsync();
                if (responseOwned)
                {
                    await recoverySignal.Task.WaitAsync(TimeSpan.FromSeconds(5));
                    Assert.That(recovered, Is.EqualTo(1));
                    Assert.That(
                        await nestedResult.Task.WaitAsync(TimeSpan.FromSeconds(5)),
                        Is.EqualTo("child:payload"));
                    await previous.WaitUntilDeletedAsync(run.TaskId, TimeSpan.FromSeconds(5));
                }
                else
                {
                    Assert.That(recovered, Is.Zero);
                    Assert.That(
                        (await store.GetAsync(run.TaskId))?.ToJson().ToJsonString(),
                        Is.EqualTo(original),
                        "Responses enablement must not reclaim a Core-owned task from another lifetime");
                }
            }
            finally
            {
                await app.App.StopAsync();
            }
        }
        finally
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ResponsesScopedTask_PersistsOwnerForOneShotAndMultiTurn(bool multiTurn)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-task-owner-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            var store = new LocalTaskStore(directory);
            builder.Services.AddSingleton<ITaskStore>(store);
            var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            Task<string> Handler(TaskContext<string> context, CancellationToken cancellationToken)
                => RunAsync(context, cancellationToken);
            async Task<string> RunAsync(TaskContext<string> context, CancellationToken cancellationToken)
            {
                entered.TrySetResult();
                await release.Task.WaitAsync(cancellationToken);
                return context.Input;
            }

            TaskDefinition<string, string> task = multiTurn
                ? builder.Services.AddResilientMultiTurnTask<string, string>(
                    "response-owned", Handler)
                : builder.Services.AddResilientTask<string, string>(
                    "response-owned", Handler);
            builder.AddInvocations<TestInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                using (app.App.Services.EnterResilientTaskScope("responses", enabled: true))
                {
                    TaskRun<string> run = await task.StartAsync(
                        "payload", new RunOptions { TaskId = "response-owned-1" });
                    await entered.Task.WaitAsync(TimeSpan.FromSeconds(5));
                    var record = await store.GetAsync(run.TaskId);
                    Assert.That(
                        record?.Payload[TaskWireKeys.PayloadProtocolScope]?.GetValue<string>(),
                        Is.EqualTo(TaskWireKeys.ProtocolResponses));
                    release.TrySetResult();
                    Assert.That(await run.Completion, Is.EqualTo("payload"));
                }
            }
            finally
            {
                release.TrySetResult();
                await app.App.StopAsync();
            }
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [Test]
    public async Task ResponsesOwnedChain_RejectsInvocationsTurnWhenBothProtocolsEnabled()
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-task-owner-conflict-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            var store = new LocalTaskStore(directory);
            builder.Services.AddSingleton<ITaskStore>(store);
            builder.SetResilientTasksEnabled();
            TaskDefinition<string, string> task = builder.Services.AddResilientMultiTurnTask<string, string>(
                "shared-chain", (ctx, ct) => Task.FromResult(ctx.Input));
            builder.AddInvocations<TestInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                using (app.App.Services.EnterResilientTaskScope("responses", enabled: true))
                {
                    TaskRun<string> first = await task.StartAsync(
                        "first", new RunOptions { TaskId = "shared-chain-1" });
                    Assert.That(await first.Completion, Is.EqualTo("first"));
                }

                string original = (await store.GetAsync("shared-chain-1"))?.ToJson().ToJsonString()
                    ?? throw new InvalidOperationException("The first turn did not suspend its chain.");
                ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
                    () => task.StartAsync("second", new RunOptions { TaskId = "shared-chain-1" }))!;
                Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));

                Assert.That(
                    (await store.GetAsync("shared-chain-1"))?.ToJson().ToJsonString(),
                    Is.EqualTo(original),
                    "a different protocol must not advance the Responses-owned task chain");
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

    [TestCase(false)]
    [TestCase(true)]
    public async Task LegacyInvocationsChain_ContinuesAfterComposedHostRestart(bool interrupted)
    {
        string directory = Path.Combine(
            Path.GetTempPath(), "agentserver-legacy-invocations-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            using var previous = TaskTestHost.Create(
                directory,
                agentName: TaskEngineConstants.DefaultAgentName,
                sessionId: TaskEngineConstants.DefaultSessionId);
            TaskDefinition<string, string> firstTask = previous.Builder.AddMultiTurnTask<string, string>(
                "legacy-chain",
                async (ctx, ct) =>
                {
                    if (interrupted)
                    {
                        await ctx.ExitForRecoveryAsync(ct);
                    }

                    return ctx.Input;
                });
            if (interrupted)
            {
                previous.SignalShutdown();
            }

            TaskRun<string> first = await firstTask.StartAsync(
                "first", new RunOptions { TaskId = "legacy-chain-1" });
            if (interrupted)
            {
                await previous.WaitUntilInactiveAsync(first.TaskId, TimeSpan.FromSeconds(5));
            }
            else
            {
                Assert.That(await first.Completion, Is.EqualTo("first"));
                await WaitForSuspendedChainAsync(previous.Store, first.TaskId);
            }

            var store = new LocalTaskStore(directory);
            Assert.That(
                (await store.GetAsync(first.TaskId))?.Payload[TaskWireKeys.PayloadProtocolScope],
                Is.Null,
                "a pre-upgrade chain has no persisted protocol owner");
            var recoverySignal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton<ITaskStore>(store);
            builder.SetResilientTasksEnabled();
            builder.Services.AddResilientMultiTurnTask<string, string>(
                "legacy-chain",
                (ctx, ct) =>
                {
                    if (ctx.EntryMode == EntryMode.Recovered)
                    {
                        recoverySignal.TrySetResult();
                    }

                    return Task.FromResult(ctx.Input);
                });
            builder.AddInvocations<LegacyChainInvocationHandler>();
            builder.AddResponses<TestResponseHandler>(
                options => options.SteerableConversations = true);

            var app = builder.Build();
            await app.App.StartAsync();
            try
            {
                if (interrupted)
                {
                    await recoverySignal.Task.WaitAsync(TimeSpan.FromSeconds(5));
                    await WaitForSuspendedChainAsync(store, first.TaskId);
                }

                using var response = await app.App.GetTestClient().PostAsync(
                    "/invocations", new StringContent("second"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo("second"));
            }
            finally
            {
                await app.App.StopAsync();
            }
        }
        finally
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }

    private static async Task WaitForSuspendedChainAsync(LocalTaskStore store, string taskId)
    {
        for (int attempt = 0; attempt < 200; attempt++)
        {
            if ((await store.GetAsync(taskId))?.Status == TaskWireKeys.StatusSuspended)
            {
                return;
            }

            await Task.Delay(25);
        }

        Assert.Fail($"Task '{taskId}' did not become suspended before the next turn.");
    }

    private sealed class LegacyChainInvocationHandler(IServiceProvider services) : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            TaskDefinition<string, string> task = services.GetResilientTask<string, string>("legacy-chain");
            string result = await task.RunAsync(
                "second", new RunOptions { TaskId = "legacy-chain-1" }, cancellationToken);
            await response.WriteAsync(result, cancellationToken);
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
