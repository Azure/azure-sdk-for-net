// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceRegistrationTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [Test]
    public void AddVoiceRegistersExactlyOneInvocationHandler()
    {
        var services = new ServiceCollection();

        services.AddVoice<TestVoiceHandler>();

        Assert.That(
            services.Count(descriptor => descriptor.ServiceType == typeof(InvocationHandler)),
            Is.EqualTo(1));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void AddVoiceScopedAliasesShareSingleDisposalOwner(bool resolveVoiceFirst)
    {
        DisposableScopedVoiceHandler.Reset();
        var services = new ServiceCollection();
        services.AddVoice<DisposableScopedVoiceHandler>();
        using var provider = services.BuildServiceProvider();
        VoiceHandler voiceHandler;
        InvocationHandler invocationHandler;

        using (var scope = provider.CreateScope())
        {
            if (resolveVoiceFirst)
            {
                voiceHandler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();
                invocationHandler = scope.ServiceProvider.GetRequiredService<InvocationHandler>();
            }
            else
            {
                invocationHandler = scope.ServiceProvider.GetRequiredService<InvocationHandler>();
                voiceHandler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();
            }

            Assert.That(invocationHandler, Is.SameAs(voiceHandler));
            Assert.That(
                scope.ServiceProvider.GetService<DisposableScopedVoiceHandler>(),
                Is.Null);
        }

        Assert.Multiple(() =>
        {
            Assert.That(DisposableScopedVoiceHandler.ConstructorCount, Is.EqualTo(1));
            Assert.That(DisposableScopedVoiceHandler.DisposeCount, Is.EqualTo(1));
        });
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task AddVoiceScopedAliasesShareSingleAsyncDisposalOwner(bool resolveVoiceFirst)
    {
        AsyncDisposableScopedVoiceHandler.Reset();
        var services = new ServiceCollection();
        services.AddVoice<AsyncDisposableScopedVoiceHandler>();
        await using var provider = services.BuildServiceProvider();
        VoiceHandler voiceHandler;
        InvocationHandler invocationHandler;

        await using (var scope = provider.CreateAsyncScope())
        {
            if (resolveVoiceFirst)
            {
                voiceHandler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();
                invocationHandler = scope.ServiceProvider.GetRequiredService<InvocationHandler>();
            }
            else
            {
                invocationHandler = scope.ServiceProvider.GetRequiredService<InvocationHandler>();
                voiceHandler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();
            }

            Assert.That(invocationHandler, Is.SameAs(voiceHandler));
        }

        Assert.Multiple(() =>
        {
            Assert.That(AsyncDisposableScopedVoiceHandler.ConstructorCount, Is.EqualTo(1));
            Assert.That(AsyncDisposableScopedVoiceHandler.DisposeCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void AddVoicePreservesUnkeyedHandlerActivationSemantics()
    {
        KeyAwareVoiceHandler.Reset();
        var services = new ServiceCollection();
        services.AddVoice<KeyAwareVoiceHandler>();
        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        _ = scope.ServiceProvider.GetRequiredService<VoiceHandler>();

        Assert.That(KeyAwareVoiceHandler.ServiceKey, Is.Null);
    }

    [Test]
    public void AddVoicePrivateOwnerIsNotReplacedByLaterUnkeyedHandlerRegistration()
    {
        var services = new ServiceCollection();
        services.AddVoice<DisposableScopedVoiceHandler>();
        services.AddScoped<DisposableScopedVoiceHandler>();
        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        var voiceHandler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();
        var unkeyedHandler = scope.ServiceProvider.GetRequiredService<DisposableScopedVoiceHandler>();

        Assert.That(voiceHandler.ApplicationHandler, Is.Not.SameAs(unkeyedHandler));
    }

    [Test]
    public void AddVoicePreservesValidateOnBuildConstructorValidation()
    {
        var services = new ServiceCollection();
        services.AddVoice<MissingDependencyVoiceHandler>();

        var exception = Assert.Throws<AggregateException>(() =>
            services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true,
            }));

        Assert.That(exception?.ToString(), Does.Contain(nameof(IMissingVoiceDependency)));
    }

    [Test]
    public void AddVoicePreservesImplementationTypeConstructorSelection()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ConstructorDependency>();
        services.AddVoice<ConstructorSelectionVoiceHandler>();
        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        var handler = scope.ServiceProvider.GetRequiredService<VoiceHandler>();

        Assert.That(
            ((ConstructorSelectionVoiceHandler)handler.ApplicationHandler).SelectedConstructor,
            Is.EqualTo("dependency"));
    }

    [Test]
    public void AddVoiceRejectsExistingInvocationHandler()
    {
        var services = new ServiceCollection();
        services.AddSingleton<InvocationHandler, RawHandler>();

        Assert.That(
            () => services.AddVoice<TestVoiceHandler>(),
            Throws.TypeOf<InvalidOperationException>());
    }

    [TestCase(InvocationsRegistration.Generic)]
    [TestCase(InvocationsRegistration.Instance)]
    [TestCase(InvocationsRegistration.Factory)]
    public void AddVoiceThenAddInvocationsRejectsBeforeMutatingServices(
        InvocationsRegistration registration)
    {
        var builder = AgentHost.CreateBuilder();
        builder.AddVoice<TestVoiceHandler>();
        var servicesBeforeConflict = builder.Services.ToArray();

        Assert.That(
            () => RegisterInvocations(builder, registration),
            Throws.TypeOf<InvalidOperationException>());
        Assert.That(
            builder.Services.ToArray(),
            Is.EqualTo(servicesBeforeConflict),
            "Rejected protocol composition must not leave partial service registrations.");
    }

    [TestCase(InvocationsRegistration.Generic)]
    [TestCase(InvocationsRegistration.Instance)]
    [TestCase(InvocationsRegistration.Factory)]
    public void AddInvocationsThenAddVoiceRejectsBeforeMutatingServices(
        InvocationsRegistration registration)
    {
        var builder = AgentHost.CreateBuilder();
        RegisterInvocations(builder, registration);
        var servicesBeforeConflict = builder.Services.ToArray();

        Assert.That(
            () => builder.AddVoice<TestVoiceHandler>(),
            Throws.TypeOf<InvalidOperationException>());
        Assert.That(
            builder.Services.ToArray(),
            Is.EqualTo(servicesBeforeConflict),
            "Rejected protocol composition must not leave partial service registrations.");
    }

    [Test]
    public void AddInvocationsDoesNotRejectNonVoiceHandlerRegistration()
    {
        var builder = AgentHost.CreateBuilder();
        builder.Services.AddScoped<InvocationHandler, RawHandler>();

        Assert.That(
            () => builder.AddInvocations<RawHandler>(),
            Throws.Nothing);
    }

    [TestCase(InvocationsRegistration.Generic)]
    [TestCase(InvocationsRegistration.Instance)]
    [TestCase(InvocationsRegistration.Factory)]
    public void AddInvocationsAcceptsNonVoiceHandlerRegistration(
        InvocationsRegistration registration)
    {
        var builder = AgentHost.CreateBuilder();

        Assert.That(
            () => RegisterInvocations(builder, registration),
            Throws.Nothing);
        using var provider = builder.Services.BuildServiceProvider();
        using var scope = provider.CreateScope();
        Assert.Multiple(() =>
        {
            Assert.That(
                builder.Services.Count(descriptor => descriptor.ServiceType == typeof(InvocationHandler)),
                Is.EqualTo(1));
            Assert.That(
                scope.ServiceProvider.GetRequiredService<InvocationHandler>(),
                Is.TypeOf<RawHandler>());
        });
    }

    [TestCase(InvocationsRegistration.Generic)]
    [TestCase(InvocationsRegistration.Instance)]
    public void AddInvocationsRejectsVoiceHandlerBeforeMutatingServices(
        InvocationsRegistration registration)
    {
        var builder = AgentHost.CreateBuilder();
        var servicesBeforeRegistration = builder.Services.ToArray();

        Assert.That(
            () => RegisterVoiceInvocations(builder, registration),
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.Contains("AddVoice"));
        Assert.That(
            builder.Services.ToArray(),
            Is.EqualTo(servicesBeforeRegistration),
            "Rejected Voice registration must not leave partial service registrations.");
    }

    [Test]
    public async Task AddInvocationsFactoryRejectsVoiceHandlerAndNextRequestSucceeds()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var factoryCalls = 0;
        DisposableVoiceHandler? rejectedHandler = null;
        builder.AddInvocations(_ => Interlocked.Increment(ref factoryCalls) == 1
            ? rejectedHandler = new DisposableVoiceHandler()
            : new RawHandler());
        await using var app = builder.Build().App;
        Exception? rejectedException = null;
        app.UseExceptionHandler(error => error.Run(context =>
        {
            rejectedException = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return Task.CompletedTask;
        }));
        await app.StartAsync();
        using var client = app.GetTestClient();

        using var rejectedResponse = await client.PostAsync("/invocations", new StringContent("{}"));
        await rejectedHandler!.Disposed.Task.WaitAsync(TestTimeout);
        using var retryResponse = await client.PostAsync("/invocations", new StringContent("{}"));

        Assert.Multiple(() =>
        {
            Assert.That(
                rejectedResponse.StatusCode,
                Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
            Assert.That(
                rejectedResponse.Headers.GetValues(PlatformHeaders.ErrorSource),
                Is.EqualTo(new[] { PlatformHeaders.ErrorSourcePlatform }));
            Assert.That(rejectedException, Is.TypeOf<InvalidOperationException>());
            Assert.That(rejectedException?.Message, Does.Contain("AddVoice"));
            Assert.That(rejectedHandler, Is.Not.Null);
            Assert.That(rejectedHandler?.DisposeCount, Is.EqualTo(1));
            Assert.That(retryResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(factoryCalls, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task AddInvocationsFactoryManualVoiceOverrideIsRejected()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var factoryCalls = 0;
        builder.AddInvocations(_ =>
        {
            factoryCalls++;
            return new RawHandler();
        });
        builder.Services.AddScoped<InvocationHandler, TestVoiceHandler>();
        await using var app = builder.Build().App;
        Exception? rejectedException = null;
        app.UseExceptionHandler(error => error.Run(context =>
        {
            rejectedException = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return Task.CompletedTask;
        }));
        await app.StartAsync();

        using var response = await app.GetTestClient().PostAsync(
            "/invocations",
            new StringContent("{}"));

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
            Assert.That(rejectedException, Is.TypeOf<InvalidOperationException>());
            Assert.That(rejectedException?.Message, Does.Contain("AddVoice"));
            Assert.That(
                response.Headers.GetValues(PlatformHeaders.ErrorSource),
                Is.EqualTo(new[] { PlatformHeaders.ErrorSourcePlatform }));
            Assert.That(factoryCalls, Is.Zero);
        });
    }

    [Test]
    public async Task PreRegisteredVoiceHandlerCannotBypassAddInvocationsGuard()
    {
        RouteSelectedVoiceHandler.Reset();
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.Services.AddScoped<InvocationHandler, RouteSelectedVoiceHandler>();
        builder.AddInvocations<RawHandler>();
        await using var app = builder.Build().App;
        await app.StartAsync();

        Assert.That(
            async () => await ConnectAsync(app),
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.Contains("AddVoice"));
        Assert.That(RouteSelectedVoiceHandler.Selected.Task.IsCompleted, Is.False);
    }

    [Test]
    public async Task AddInvocationsFactoryDisposesRejectedAsyncVoiceHandler()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var handler = new AsyncDisposableVoiceHandler();
        builder.AddInvocations(_ => handler);
        await using var app = builder.Build().App;
        app.UseExceptionHandler(error => error.Run(context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return Task.CompletedTask;
        }));
        await app.StartAsync();

        using var response = await app.GetTestClient().PostAsync(
            "/invocations",
            new StringContent("{}"));
        await handler.Disposed.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
            Assert.That(handler.DisposeCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task RejectedInvocationsCompositionLeavesVoiceEndpointRunnable()
    {
        RouteSelectedVoiceHandler.Reset();
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddVoice<RouteSelectedVoiceHandler>();
        Assert.That(
            () => builder.AddInvocations<RawHandler>(),
            Throws.TypeOf<InvalidOperationException>());

        await using var app = builder.Build().App;
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);
        await SendSessionStartAsync(webSocket);
        await RouteSelectedVoiceHandler.Selected.Task.WaitAsync(TestTimeout);
        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [Test]
    public async Task RejectedVoiceCompositionLeavesInvocationsEndpointRunnable()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations(new RawHandler());
        Assert.That(
            () => builder.AddVoice<TestVoiceHandler>(),
            Throws.TypeOf<InvalidOperationException>());

        await using var app = builder.Build().App;
        await app.StartAsync();
        using var response = await app.GetTestClient().PostAsync(
            "/invocations",
            new StringContent("{}"));

        Assert.That(
            response.StatusCode,
            Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task AddVoiceRunsTypedRelayOnExistingRoute()
    {
        RouteSelectedVoiceHandler.Reset();
        await using var app = BuildApp<RouteSelectedVoiceHandler>();
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendSessionStartAsync(webSocket);

        await RouteSelectedVoiceHandler.Selected.Task.WaitAsync(TestTimeout);
        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [TestCase("POST", "/invocations", "handle")]
    [TestCase("GET", "/invocations/test-id", "get")]
    [TestCase("POST", "/invocations/test-id/cancel", "cancel")]
    [TestCase("GET", "/invocations/docs/openapi.json", "openapi")]
    [TestCase("GET", "/invocations/docs/asyncapi.json", "asyncapi-json")]
    [TestCase("GET", "/invocations/docs/asyncapi.yaml", "asyncapi-yaml")]
    public async Task AddVoiceForwardsInvocationHandlerEndpointOverrides(
        string method,
        string path,
        string expectedOperation)
    {
        FullSurfaceVoiceHandler.Reset();
        await using var app = BuildApp<FullSurfaceVoiceHandler>();
        await app.StartAsync();
        using var request = new HttpRequestMessage(new HttpMethod(method), path);
        using var response = await app.GetTestClient().SendAsync(request);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
            Assert.That(FullSurfaceVoiceHandler.Operation, Is.EqualTo(expectedOperation));
        });
    }

    [Test]
    public async Task AddVoiceThenManualInvocationHandlerOverrideFailsExplicitly()
    {
        RouteSelectedVoiceHandler.Reset();
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<RouteSelectedVoiceHandler>();
        builder.Services.AddScoped<InvocationHandler, RawHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        await app.StartAsync();

        Assert.That(
            async () => await ConnectAsync(app),
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.Contains("overridden"));
        Assert.That(RouteSelectedVoiceHandler.Selected.Task.IsCompleted, Is.False);
    }

    [Test]
    public async Task AddVoiceAllowsCustomEndpointOnReturnedRouteGroup()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<TestVoiceHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        var group = app.MapInvocationsServer("/voice");
        group.MapGet("/health", () => Results.Ok());
        await app.StartAsync();

        using var response = await app.GetTestClient().GetAsync("/voice/health");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Test]
    public async Task ConflictingLiteralRouteAtSameOrderFailsClosed()
    {
        await using var app = BuildApp<TestVoiceHandler>(application =>
            application.MapGet("/invocations_ws", () => Results.Ok()).WithOrder(int.MinValue));
        await app.StartAsync();
        var client = app.GetTestServer().CreateWebSocketClient();

        Assert.That(
            async () => await client.ConnectAsync(
                new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
                CancellationToken.None),
            Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public async Task UpgradeIncludesServerIdentityAndSessionHeader()
    {
        SessionCapturingVoiceHandler.Reset();
        var headers = new TaskCompletionSource<IReadOnlyDictionary<string, string>>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp<SessionCapturingVoiceHandler>(application =>
        {
            application.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    headers.TrySetResult(context.Response.Headers.ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value.ToString(),
                        StringComparer.OrdinalIgnoreCase));
                    return Task.CompletedTask;
                });
                await next();
            });
        }, configureBeforeCore: true);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);
        var captured = await headers.Task.WaitAsync(TestTimeout);
        await SendSessionStartAsync(webSocket);
        var resolvedSessionId = await SessionCapturingVoiceHandler.SessionId.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(captured, Does.ContainKey(PlatformHeaders.ServerVersion));
            Assert.That(captured, Does.ContainKey(PlatformHeaders.SessionId));
            Assert.That(captured[PlatformHeaders.SessionId], Is.EqualTo(resolvedSessionId));
        });
        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [Test]
    public async Task StartupDoesNotInstantiateScopedVoiceHandler()
    {
        ConstructorCountingVoiceHandler.Reset();
        await using var app = BuildApp<ConstructorCountingVoiceHandler>();

        await app.StartAsync();

        Assert.That(ConstructorCountingVoiceHandler.ConstructorCount, Is.Zero);
    }

    private static WebApplication BuildApp<THandler>(
        Action<WebApplication>? configure = null,
        bool configureBeforeCore = false)
        where THandler : VoiceHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<THandler>();
        var app = builder.Build();
        if (configureBeforeCore)
        {
            configure?.Invoke(app);
        }
        app.UseAgentServerCore();
        if (!configureBeforeCore)
        {
            configure?.Invoke(app);
        }
        app.MapInvocationsServer();
        return app;
    }

    private static void RegisterInvocations(
        AgentHostBuilder builder,
        InvocationsRegistration registration)
    {
        switch (registration)
        {
            case InvocationsRegistration.Generic:
                builder.AddInvocations<RawHandler>();
                break;
            case InvocationsRegistration.Instance:
                builder.AddInvocations(new RawHandler());
                break;
            case InvocationsRegistration.Factory:
                builder.AddInvocations(_ => new RawHandler());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(registration));
        }
    }

    private static void RegisterVoiceInvocations(
        AgentHostBuilder builder,
        InvocationsRegistration registration)
    {
        switch (registration)
        {
            case InvocationsRegistration.Generic:
                builder.AddInvocations<TestVoiceHandler>();
                break;
            case InvocationsRegistration.Instance:
                builder.AddInvocations(new TestVoiceHandler());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(registration));
        }
    }

    public enum InvocationsRegistration
    {
        Generic,
        Instance,
        Factory,
    }

    private static async Task<WebSocket> ConnectAsync(
        WebApplication app,
        string path = "invocations_ws")
    {
        var client = app.GetTestServer().CreateWebSocketClient();
        return await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, path),
            CancellationToken.None);
    }

    private static Task SendSessionStartAsync(WebSocket webSocket) =>
        webSocket.SendAsync(
            Encoding.UTF8.GetBytes("""
                {"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
                """),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

    private sealed class TestVoiceHandler : VoiceHandler;

    private sealed class DisposableScopedVoiceHandler : VoiceHandler, IDisposable
    {
        public DisposableScopedVoiceHandler() => ConstructorCount++;

        public static int ConstructorCount { get; private set; }

        public static int DisposeCount { get; private set; }

        public static void Reset()
        {
            ConstructorCount = 0;
            DisposeCount = 0;
        }

        public void Dispose() => DisposeCount++;
    }

    private sealed class AsyncDisposableScopedVoiceHandler : VoiceHandler, IAsyncDisposable
    {
        public AsyncDisposableScopedVoiceHandler() => ConstructorCount++;

        public static int ConstructorCount { get; private set; }

        public static int DisposeCount { get; private set; }

        public static void Reset()
        {
            ConstructorCount = 0;
            DisposeCount = 0;
        }

        public ValueTask DisposeAsync()
        {
            DisposeCount++;
            return ValueTask.CompletedTask;
        }
    }

    private sealed class KeyAwareVoiceHandler : VoiceHandler
    {
        public KeyAwareVoiceHandler([ServiceKey] object? serviceKey = null) => ServiceKey = serviceKey;

        public static object? ServiceKey { get; private set; }

        public static void Reset() => ServiceKey = new object();
    }

    private interface IMissingVoiceDependency;

    private sealed class MissingDependencyVoiceHandler : VoiceHandler
    {
        public MissingDependencyVoiceHandler(IMissingVoiceDependency dependency)
        {
        }
    }

    private sealed class ConstructorDependency;

    private sealed class ConstructorSelectionVoiceHandler : VoiceHandler
    {
        [ActivatorUtilitiesConstructor]
        public ConstructorSelectionVoiceHandler() => SelectedConstructor = "attributed";

        public ConstructorSelectionVoiceHandler(ConstructorDependency dependency) =>
            SelectedConstructor = "dependency";

        public string SelectedConstructor { get; }
    }

    private sealed class DisposableVoiceHandler : VoiceHandler, IDisposable
    {
        public TaskCompletionSource Disposed { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int DisposeCount { get; private set; }

        public void Dispose()
        {
            DisposeCount++;
            Disposed.TrySetResult();
        }
    }

    private sealed class AsyncDisposableVoiceHandler : VoiceHandler, IAsyncDisposable
    {
        public TaskCompletionSource Disposed { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int DisposeCount { get; private set; }

        public ValueTask DisposeAsync()
        {
            DisposeCount++;
            Disposed.TrySetResult();
            return ValueTask.CompletedTask;
        }
    }

    private sealed class SessionCapturingVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource<string> SessionId { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            SessionId = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            SessionId.TrySetResult(session.InvocationContext.SessionId);
            return Task.CompletedTask;
        }
    }

    private sealed class FullSurfaceVoiceHandler : VoiceHandler
    {
        private static string? s_operation;

        public static string? Operation => Volatile.Read(ref s_operation);

        public static void Reset() => Interlocked.Exchange(ref s_operation, null);

        public override Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Complete(response, "handle");

        public override Task GetAsync(
            string invocationId,
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Complete(response, "get");

        public override Task CancelAsync(
            string invocationId,
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Complete(response, "cancel");

        public override Task GetOpenApiAsync(
            HttpRequest request,
            HttpResponse response,
            CancellationToken cancellationToken) => Complete(response, "openapi");

        public override Task GetAsyncApiJsonAsync(
            HttpRequest request,
            HttpResponse response,
            CancellationToken cancellationToken) => Complete(response, "asyncapi-json");

        public override Task GetAsyncApiYamlAsync(
            HttpRequest request,
            HttpResponse response,
            CancellationToken cancellationToken) => Complete(response, "asyncapi-yaml");

        private static Task Complete(HttpResponse response, string operation)
        {
            Interlocked.Exchange(ref s_operation, operation);
            response.StatusCode = StatusCodes.Status204NoContent;
            return Task.CompletedTask;
        }
    }

    private sealed class RawHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class RouteSelectedVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource Selected { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            Selected = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Selected.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class ConstructorCountingVoiceHandler : VoiceHandler
    {
        private static int _constructorCount;

        public ConstructorCountingVoiceHandler() => Interlocked.Increment(ref _constructorCount);

        public static int ConstructorCount => Volatile.Read(ref _constructorCount);

        public static void Reset() => Volatile.Write(ref _constructorCount, 0);
    }
}
