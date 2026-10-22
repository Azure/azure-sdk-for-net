// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture]
[NonParallelizable]
public sealed class ResilientTaskOptInProtocolTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task StoredResponse_DefaultDisabled_RunsInProcessWithoutResolvingTaskStore(
        bool stream)
    {
        int storeResolutions = 0;
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
                services.AddSingleton<ITaskStore>(_ =>
                {
                    Interlocked.Increment(ref storeResolutions);
                    throw new InvalidOperationException("Disabled task storage must not resolve.");
                }));
        using HttpClient client = factory.CreateClient();

        using HttpResponseMessage response = await client.PostAsync(
            "/responses",
            Json(new { model = "test", store = true, stream }));
        string body = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
            Assert.That(storeResolutions, Is.Zero);
            Assert.That(
                factory.Services.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.False);
        });
        if (stream)
        {
            Assert.That(body, Does.Contain("event: response.created"));
            Assert.That(body, Does.Contain("event: response.completed"));
        }
    }

    [Test]
    public async Task ResilientBackground_AutomaticallyEnablesTaskRuntime()
    {
        await AssertTaskRuntimeUsedAsync(
            configureOptions: options => options.ResilientBackground = true,
            configureServices: null);
    }

    [Test]
    public async Task ResilientBackground_CannotBeSilentlyDisabledByLaterConfiguration()
    {
        await AssertTaskRuntimeUsedAsync(
            configureOptions: options => options.ResilientBackground = true,
            configureServices: services => services.SetResilientTasksEnabled(false));
    }

    [Test]
    public async Task ExplicitCoreOptIn_EnablesTasksWithoutResilientBackground()
    {
        await AssertTaskRuntimeUsedAsync(
            configureOptions: null,
            configureServices: services => services.SetResilientTasksEnabled());
    }

    [Test]
    public void SteerableConversations_WithoutTaskOptIn_FailsStartup()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => new TestWebApplicationFactory(
                configureOptions: options => options.SteerableConversations = true))!;

        Assert.That(exception.Message, Does.Contain(nameof(ResponsesServerOptions.SteerableConversations)));
        Assert.That(exception.Message, Does.Contain(nameof(ResilientTaskEnablementExtensions.SetResilientTasksEnabled)));
    }

    private static async Task AssertTaskRuntimeUsedAsync(
        Action<ResponsesServerOptions>? configureOptions,
        Action<IServiceCollection>? configureServices)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-responses-optin-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        string? previousStateRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);
        try
        {
            var store = new SpyTaskStore(new LocalTaskStore(Path.Combine(root, "tasks")));
            using var factory = new TestWebApplicationFactory(
                configureOptions: configureOptions,
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(store);
                    configureServices?.Invoke(services);
                });
            using HttpClient client = factory.CreateClient();

            using HttpResponseMessage response = await client.PostAsync(
                "/responses",
                Json(new { model = "test", store = true, background = true }));
            string body = await response.Content.ReadAsStringAsync();

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), body);
                Assert.That(store.CreateCallCount, Is.GreaterThan(0));
                Assert.That(
                    factory.Services.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                    Is.True);
            });
        }
        finally
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previousStateRoot);
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
}
