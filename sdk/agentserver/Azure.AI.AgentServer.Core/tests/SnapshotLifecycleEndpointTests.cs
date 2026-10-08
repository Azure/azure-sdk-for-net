// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
[NonParallelizable]
public class SnapshotLifecycleEndpointTests
{
    private const string SessionIdEnvironmentVariable = "FOUNDRY_AGENT_SESSION_ID";

    private readonly Dictionary<string, string?> _originalEnvironment = new(StringComparer.Ordinal);

    [SetUp]
    public void SetUp()
    {
        RememberEnvironment(SessionIdEnvironmentVariable);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var pair in _originalEnvironment)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        _originalEnvironment.Clear();
        FoundryEnvironment.Reload();
    }

    [Test]
    public async Task DefaultHooks_ReturnSuccess()
    {
        await using var app = await StartAppAsync();
        using var client = app.GetTestClient();

        using var beforeResponse = await PostJsonAsync(client, "/_agent/before-snapshot", "{}");
        using var afterResponse = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            """
            {
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-1"
              }
            }
            """);

        Assert.That(beforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(beforeResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        Assert.That(await beforeResponse.Content.ReadAsStringAsync(), Is.EqualTo("""{"status":"ok"}"""));
        Assert.That(afterResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(afterResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        Assert.That(await afterResponse.Content.ReadAsStringAsync(), Is.EqualTo("""{"status":"ok"}"""));
    }

    [Test]
    public async Task Hooks_IgnoreUnknownRequestFields()
    {
        await using var app = await StartAppAsync();
        using var client = app.GetTestClient();

        using var beforeResponse = await PostJsonAsync(
            client,
            "/_agent/before-snapshot",
            """{"future_context":{"enabled":true}}""");
        using var afterResponse = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            """
            {
              "future_top_level": true,
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-1",
                "future_nested": 42
              }
            }
            """);

        Assert.That(beforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(afterResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task AfterRestore_AppliesEnvironmentBeforeCallback()
    {
        const string customVariable = "AGENTSERVER_TEST_SESSION_VALUE";
        RememberEnvironment(customVariable);

        AgentRestoreContext? observedContext = null;
        string? observedEnvironment = null;
        string? observedCachedSessionId = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (context, _) =>
            {
                observedContext = context;
                observedEnvironment = Environment.GetEnvironmentVariable(customVariable);
                observedCachedSessionId = FoundryEnvironment.SessionId;
                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();

        using var response = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-1",
                "session_env_overrides": {
                  "FOUNDRY_AGENT_SESSION_ID": "session-1",
                  "{{customVariable}}": "custom-value"
                }
              }
            }
            """);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(observedEnvironment, Is.EqualTo("custom-value"));
        Assert.That(observedCachedSessionId, Is.EqualTo("session-1"));
        Assert.That(observedContext, Is.Not.Null);
        Assert.That(observedContext!.SessionId, Is.EqualTo("session-1"));
        Assert.That(observedContext.RestoreId, Is.EqualTo("restore-1"));
        Assert.That(
            observedContext.SessionEnvironmentOverrides[customVariable],
            Is.EqualTo("custom-value"));
    }

    [Test]
    public async Task AfterRestore_AppliesSessionIdWhenOverridesAreOmitted()
    {
        Environment.SetEnvironmentVariable(SessionIdEnvironmentVariable, "captured-session");
        FoundryEnvironment.Reload();

        string? observedEnvironment = null;
        string? observedCachedSessionId = null;
        string? observedRequestContextSessionId = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                observedEnvironment = Environment.GetEnvironmentVariable(SessionIdEnvironmentVariable);
                observedCachedSessionId = FoundryEnvironment.SessionId;
                observedRequestContextSessionId = FoundryAgentRequestContext.Current.SessionId;
                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();
        using var response = await PostAfterRestoreAsync(client, "session-1", "restore-1");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(observedEnvironment, Is.EqualTo("session-1"));
        Assert.That(observedCachedSessionId, Is.EqualTo("session-1"));
        Assert.That(observedRequestContextSessionId, Is.EqualTo("session-1"));
    }

    [Test]
    public async Task AfterRestore_RemovesOverridesOmittedByLaterRestore()
    {
        const string customVariable = "AGENTSERVER_TEST_SPARSE_OVERRIDE";
        RememberEnvironment(customVariable);
        Environment.SetEnvironmentVariable(customVariable, "captured-value");

        var observedValues = new List<string?>();
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                observedValues.Add(Environment.GetEnvironmentVariable(customVariable));
                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();
        using var firstResponse = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-1",
                "session_env_overrides": {
                  "{{customVariable}}": "restored-value"
                }
              }
            }
            """);
        using var secondResponse = await PostAfterRestoreAsync(client, "session-1", "restore-2");

        Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(observedValues, Is.EqualTo(new[] { "restored-value", "captured-value" }));
    }

    [Test]
    public async Task AfterRestore_RestoresBaselineWhenVariableIsFirstOverriddenByLaterRestore()
    {
        const string customVariable = "AGENTSERVER_TEST_LATE_OVERRIDE";
        RememberEnvironment(customVariable);
        Environment.SetEnvironmentVariable(customVariable, "captured-value");

        var callbackCount = 0;
        var observedValues = new List<string?>();
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                observedValues.Add(Environment.GetEnvironmentVariable(customVariable));
                if (Interlocked.Increment(ref callbackCount) == 1)
                {
                    Environment.SetEnvironmentVariable(customVariable, "callback-value");
                }

                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();
        using var firstResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var secondResponse = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-2",
                "session_env_overrides": {
                  "{{customVariable}}": "restored-value"
                }
              }
            }
            """);
        using var thirdResponse = await PostAfterRestoreAsync(client, "session-1", "restore-3");

        Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(thirdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(
            observedValues,
            Is.EqualTo(new[] { "captured-value", "restored-value", "captured-value" }));
    }

    [Test]
    public async Task BeforeSnapshot_ConcurrentRetriesAreSerializedAndRunOnce()
    {
        var callbackEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseCallback = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var bothRequestsArrived = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var requestCount = 0;
        var callbackCount = 0;
        var activeCallbacks = 0;
        var maximumActiveCallbacks = 0;

        var lifecycle = new TestSnapshotLifecycle
        {
            BeforeSnapshot = async _ =>
            {
                Interlocked.Increment(ref callbackCount);
                var active = Interlocked.Increment(ref activeCallbacks);
                InterlockedExtensions.Max(ref maximumActiveCallbacks, active);
                callbackEntered.TrySetResult();
                await releaseCallback.Task;
                Interlocked.Decrement(ref activeCallbacks);
            },
        };

        await using var app = await StartAppAsync(
            lifecycle,
            webApp =>
            {
                webApp.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/_agent/before-snapshot"
                        && Interlocked.Increment(ref requestCount) == 2)
                    {
                        bothRequestsArrived.TrySetResult();
                    }

                    await next();
                });
            });
        using var client = app.GetTestClient();

        var firstRequest = PostJsonAsync(client, "/_agent/before-snapshot", "{}");
        await callbackEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var secondRequest = PostJsonAsync(client, "/_agent/before-snapshot", "{}");
        await bothRequestsArrived.Task.WaitAsync(TimeSpan.FromSeconds(5));

        releaseCallback.TrySetResult();
        using var firstResponse = await firstRequest;
        using var secondResponse = await secondRequest;

        Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(callbackCount, Is.EqualTo(1));
        Assert.That(maximumActiveCallbacks, Is.EqualTo(1));
    }

    [Test]
    public async Task AfterRestore_UsesRestoreIdForIdempotency()
    {
        var contexts = new List<AgentRestoreContext>();
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (context, _) =>
            {
                contexts.Add(context);
                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();

        using var firstResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var retryResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var laterRestoreResponse = await PostAfterRestoreAsync(client, "session-1", "restore-2");
        using var delayedRetryResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");

        Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(retryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(laterRestoreResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(delayedRetryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(contexts.Select(context => context.RestoreId), Is.EqualTo(new[] { "restore-1", "restore-2" }));
    }

    [Test]
    public async Task AfterRestore_DifferentSessionFailsBeforeApplyingOverrides()
    {
        const string customVariable = "AGENTSERVER_TEST_SESSION_MISMATCH";
        RememberEnvironment(customVariable);
        Environment.SetEnvironmentVariable(customVariable, "original");

        var callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                Interlocked.Increment(ref callbackCount);
                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();
        using var firstResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var mismatchResponse = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "session-2",
                "restore_id": "restore-2",
                "session_env_overrides": {
                  "{{customVariable}}": "changed"
                }
              }
            }
            """);

        Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(mismatchResponse.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        Assert.That(
            await mismatchResponse.Content.ReadAsStringAsync(),
            Is.EqualTo("""{"error":{"code":"session_mismatch","message":"The restored process is already assigned to another session."}}"""));
        Assert.That(callbackCount, Is.EqualTo(1));
        Assert.That(Environment.GetEnvironmentVariable(customVariable), Is.EqualTo("original"));
    }

    [Test]
    public async Task FailedHook_ReturnsSanitizedErrorAndCanBeRetried()
    {
        var callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                if (Interlocked.Increment(ref callbackCount) == 1)
                {
                    throw new InvalidOperationException("secret connection string");
                }

                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();

        using var failedResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var retryResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        var failedBody = await failedResponse.Content.ReadAsStringAsync();

        Assert.That(failedResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(
            failedBody,
            Is.EqualTo("""{"error":{"code":"after_restore_failed","message":"The after-restore hook failed."}}"""));
        Assert.That(failedBody, Does.Not.Contain("secret connection string"));
        Assert.That(retryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(callbackCount, Is.EqualTo(2));
    }

    [Test]
    public async Task FailedHook_PinsProcessToOriginalSession()
    {
        var callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                if (Interlocked.Increment(ref callbackCount) == 1)
                {
                    throw new InvalidOperationException("restore failed");
                }

                return Task.CompletedTask;
            },
        };

        await using var app = await StartAppAsync(lifecycle);
        using var client = app.GetTestClient();

        using var failedResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");
        using var mismatchResponse = await PostAfterRestoreAsync(client, "session-2", "restore-2");
        using var retryResponse = await PostAfterRestoreAsync(client, "session-1", "restore-1");

        Assert.That(failedResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(mismatchResponse.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        Assert.That(
            await mismatchResponse.Content.ReadAsStringAsync(),
            Is.EqualTo("""{"error":{"code":"session_mismatch","message":"The restored process is already assigned to another session."}}"""));
        Assert.That(retryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(callbackCount, Is.EqualTo(2));
    }

    [Test]
    public async Task InvalidEnvironmentOverride_DoesNotApplyEarlierValues()
    {
        const string validVariable = "AGENTSERVER_TEST_VALID_OVERRIDE";
        RememberEnvironment(validVariable);
        Environment.SetEnvironmentVariable(validVariable, "original");

        await using var app = await StartAppAsync();
        using var client = app.GetTestClient();
        using var response = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "session-1",
                "restore_id": "restore-1",
                "session_env_overrides": {
                  "{{validVariable}}": "changed",
                  "INVALID=NAME": "value"
                }
              }
            }
            """);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(Environment.GetEnvironmentVariable(validVariable), Is.EqualTo("original"));
    }

    [TestCase(null, "{}", HttpStatusCode.UnsupportedMediaType)]
    [TestCase("application/json", "", HttpStatusCode.BadRequest)]
    [TestCase("application/json", "[]", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":null}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":" ","restore_id":"restore-1"}}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":"session-\u0000x","restore_id":"restore-1"}}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":"session-1","restore_id":"restore-1","session_env_overrides":{"INVALID=NAME":"value"}}}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":"session-1","restore_id":"restore-1","session_env_overrides":{"EMPTY_VALUE":""}}}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":"session-1","restore_id":"restore-1","session_env_overrides":{"INVALID_VALUE":"value\u0000suffix"}}}""", HttpStatusCode.BadRequest)]
    [TestCase("application/json", """{"session_context":{"session_id":"session-1","restore_id":"restore-1","session_env_overrides":{"FOUNDRY_AGENT_SESSION_ID":"session-2"}}}""", HttpStatusCode.BadRequest)]
    public async Task AfterRestore_InvalidRequestReturnsStableError(
        string? contentType,
        string body,
        HttpStatusCode expectedStatus)
    {
        await using var app = await StartAppAsync();
        using var client = app.GetTestClient();
        using var content = new StringContent(body, Encoding.UTF8);
        if (contentType is not null)
        {
            content.Headers.ContentType = new(contentType);
        }

        using var response = await client.PostAsync("/_agent/after-restore", content);

        Assert.That(response.StatusCode, Is.EqualTo(expectedStatus));
        Assert.That(
            await response.Content.ReadAsStringAsync(),
            Is.EqualTo("""{"error":{"code":"invalid_request","message":"Invalid lifecycle request."}}"""));
    }

    [Test]
    public async Task UseAgentServerCore_CanOnlyRegisterLifecycleRoutesOnce()
    {
        await using var app = await StartAppAsync(
            configureApplication: webApp => webApp.UseAgentServerCore());
        using var client = app.GetTestClient();

        using var response = await PostJsonAsync(client, "/_agent/before-snapshot", "{}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task AgentHostBuilder_RegistersLifecycleRoutes()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        var app = builder.Build();
        await app.App.StartAsync();

        try
        {
            using var client = app.App.GetTestClient();
            using var response = await PostJsonAsync(client, "/_agent/before-snapshot", "{}");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        finally
        {
            await app.App.StopAsync();
            await app.App.DisposeAsync();
        }
    }

    [Test]
    public async Task ClassicHostBuilder_RegistersLifecycleRoutes()
    {
        using var host = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services => services.AddAgentServerCore());
                webHost.Configure(app => app.UseAgentServerCore());
            })
            .Build();
        await host.StartAsync();

        using var client = host.GetTestClient();
        using var response = await PostJsonAsync(client, "/_agent/before-snapshot", "{}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    private static async Task<WebApplication> StartAppAsync(
        IAgentSnapshotLifecycle? lifecycle = null,
        Action<WebApplication>? configureApplication = null)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        if (lifecycle is not null)
        {
            builder.Services.AddSingleton(lifecycle);
        }

        var app = builder.Build();
        configureApplication?.Invoke(app);
        app.UseAgentServerCore();
        await app.StartAsync();
        return app;
    }

    private static Task<HttpResponseMessage> PostAfterRestoreAsync(
        HttpClient client,
        string sessionId,
        string restoreId) =>
        PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "{{sessionId}}",
                "restore_id": "{{restoreId}}"
              }
            }
            """);

    private static Task<HttpResponseMessage> PostJsonAsync(HttpClient client, string path, string body) =>
        client.PostAsync(path, new StringContent(body, Encoding.UTF8, "application/json"));

    private void RememberEnvironment(string name)
    {
        if (!_originalEnvironment.ContainsKey(name))
        {
            _originalEnvironment.Add(name, Environment.GetEnvironmentVariable(name));
        }
    }

    private sealed class TestSnapshotLifecycle : IAgentSnapshotLifecycle
    {
        public Func<CancellationToken, Task>? BeforeSnapshot { get; init; }

        public Func<AgentRestoreContext, CancellationToken, Task>? AfterRestore { get; init; }

        public Task BeforeSnapshotAsync(CancellationToken cancellationToken = default) =>
            BeforeSnapshot?.Invoke(cancellationToken) ?? Task.CompletedTask;

        public Task AfterRestoreAsync(
            AgentRestoreContext context,
            CancellationToken cancellationToken = default) =>
            AfterRestore?.Invoke(context, cancellationToken) ?? Task.CompletedTask;
    }

    private static class InterlockedExtensions
    {
        public static void Max(ref int location, int value)
        {
            int current;
            do
            {
                current = Volatile.Read(ref location);
                if (current >= value)
                {
                    return;
                }
            }
            while (Interlocked.CompareExchange(ref location, value, current) != current);
        }
    }
}
