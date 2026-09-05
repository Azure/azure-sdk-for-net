// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// US6 / FR-004 request-time resilient-start failure contract: when the Core task subsystem fails
/// during resilient dispatch (e.g. a task-store write failure), the resilient background dispatch
/// in <c>ResponseEndpointHandler.StartResilientTurnAsync</c> tags the exception as platform-sourced
/// and rethrows. The exception filter must then surface it as a 500 with
/// <c>x-platform-error-source: platform</c> — never silently downgraded to <c>upstream</c>.
///
/// The failure is injected with a <see cref="SpyTaskStore"/> decorator whose <c>CreateAsync</c>
/// throws a generic <see cref="InvalidOperationException"/>, standing in for a task-store infra
/// failure at the exact boundary the Core resilient-task engine writes through when
/// <see cref="Azure.AI.AgentServer.Core.Tasks.TaskDefinition{TInput,TOutput}.StartAsync"/> is
/// invoked. Every other <c>ITaskStore</c> operation delegates to a real <see cref="LocalTaskStore"/>,
/// so the endpoint's platform-tagging catch-all runs the real engine → real store call chain.
/// </summary>
public class ResilientStartFailureProtocolTests
{
    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

    [Test]
    public async Task NonStreamBackground_StartFailure_Returns500_WithPlatformErrorSource()
    {
        var root = NewIsolatedRoot(out var tasksDir, out var responsesDir);
        try
        {
            using var factory = NewFailingStartFactory(tasksDir, responsesDir, out _);
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            AssertPlatformErrorSource(response);
            AssertPlatformErrorDetail(response);
        }
        finally
        {
            CleanupRoot(root);
        }
    }

    [Test]
    public async Task StreamBackground_StartFailure_Returns500_WithPlatformErrorSource()
    {
        // Observed behavior: for a streaming background resilient request, StartResilientTurnAsync
        // is invoked BEFORE the SSE stream is built. A start-time failure therefore propagates
        // (through the streaming path's `catch { linkedCts?.Dispose(); throw; }`) to the exception
        // filter, which returns a plain 500 + x-platform-error-source: platform — the failure never
        // reaches the SSE channel, so there is no standalone SSE error event. The key contract is
        // that the failure is platform-sourced and NOT silently downgraded to upstream.
        var root = NewIsolatedRoot(out var tasksDir, out var responsesDir);
        try
        {
            using var factory = NewFailingStartFactory(tasksDir, responsesDir, out _);
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, stream = true }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                "A pre-stream resilient-start failure surfaces as a 500 before the SSE stream begins.");
            AssertPlatformErrorSource(response);
            AssertPlatformErrorDetail(response);
        }
        finally
        {
            CleanupRoot(root);
        }
    }

    [Test]
    public async Task HostedBackground_StartFailure_UsesTaskStorePath()
    {
        var root = NewIsolatedRoot(out var tasksDir, out var responsesDir);
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "Production");
            Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com/api/projects/proj");
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
            FoundryEnvironment.Reload();

            using var factory = NewFailingStartFactory(tasksDir, responsesDir, out var spy);
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", background = true, store = true }));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            AssertPlatformErrorSource(response);
            AssertPlatformErrorDetail(response);
            Assert.That(spy.CreateCallCount, Is.GreaterThan(0),
                "Hosted resilient background must route through the Core resilient-task engine, which "
                + "issues an ITaskStore.CreateAsync as its first persistence call.");
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
            Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
            FoundryEnvironment.Reload();
            CleanupRoot(root);
        }
    }

    private static TestWebApplicationFactory NewFailingStartFactory(string tasksDir, string responsesDir, out SpyTaskStore spy)
    {
        // The spy wraps a real LocalTaskStore, so all non-Create operations delegate transparently
        // and the fail-loud composition validation is satisfied. The injected InvalidOperationException
        // stands in for a task-store write failure. The platform-error-detail assertion verifies the
        // exception type without relying on hand-written exception text.
        var spyStore = new SpyTaskStore(new LocalTaskStore(tasksDir))
        {
            ThrowOnCreate = new InvalidOperationException("Simulated task-store write failure."),
        };
        spy = spyStore;

        return new TestWebApplicationFactory(
            configureOptions: o =>
            {
                // ResilientBackground engages the local Core task subsystem for background responses,
                // routing through StartResilientTurnAsync where the injected create-time failure occurs.
                o.ResilientBackground = true;
            },
            configureTestServices: services =>
            {
                // Pre-registration WINS: AddResponsesServer uses TryAdd, so this fake overrides the
                // default LocalTaskStore. The spy still satisfies the fail-loud composition
                // validation because it IS an ITaskStore backed by a durable local store.
                services.AddSingleton<ITaskStore>(spyStore);
                services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
            });
    }

    private static void AssertPlatformErrorSource(HttpResponseMessage response)
    {
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.True,
            $"Expected {PlatformHeaders.ErrorSource} header to be present.");
        var value = response.Headers.GetValues(PlatformHeaders.ErrorSource).First();
        Assert.That(value, Is.EqualTo(PlatformHeaders.ErrorSourcePlatform),
            "A resilient-start infra failure must be classified as platform-sourced, not upstream.");
    }

    private static void AssertPlatformErrorDetail(HttpResponseMessage response)
    {
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.True,
            $"Expected {PlatformHeaders.ErrorDetail} header to be present.");
        var value = response.Headers.GetValues(PlatformHeaders.ErrorDetail).First();
        Assert.That(value, Does.Contain(nameof(InvalidOperationException)));
    }

    private static string NewIsolatedRoot(out string tasksDir, out string responsesDir)
    {
        var root = Path.Combine(Path.GetTempPath(), "resilient-start-fail-" + Guid.NewGuid().ToString("N"));
        tasksDir = Path.Combine(root, "tasks");
        responsesDir = Path.Combine(root, "responses");
        Directory.CreateDirectory(tasksDir);
        Directory.CreateDirectory(responsesDir);
        return root;
    }

    private static void CleanupRoot(string root)
    {
        try
        {
            if (Directory.Exists(root))
            {
                Directory.Delete(root, recursive: true);
            }
        }
        catch (IOException)
        {
            // Best-effort cleanup; leftover temp files are isolated per-test by a fresh GUID root.
        }
    }
}
