// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture]
[NonParallelizable]
public sealed class SessionInstanceIdTaskIdProtocolTests
{
    private const string PublicSessionId = "same-public-name";
    private const string ConversationId = "conv-session-guid";
    private const string AgentName = "server-default-agent";

    [Test]
    public async Task HostedSessionInstanceIdScopesMultiTurnPhysicalTaskId()
    {
        string root = CreateRoot();
        string? previousHosted = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        string? previousGuid = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_GUID");
        try
        {
            const string sessionGuid = "11111111111111111111111111111111";
            SetHostedSessionGuid(sessionGuid);

            var store = new SpyTaskStore(new LocalTaskStore(Path.Combine(root, "tasks")));
            using var factory = CreateFactory(root, store);
            using HttpClient client = factory.CreateClient();

            using HttpResponseMessage response = await PostConversationAsync(client);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string responseId = await ReadResponseIdAsync(response);

            string legacyTaskId = ConversationChainIdDerivation.Derive(
                ConversationId,
                previousResponseId: null,
                responseId,
                AgentName,
                PublicSessionId,
                steerable: false);
            string taskScope = TaskIdDerivation.DeriveSessionScope(
                PublicSessionId,
                Guid.ParseExact(sessionGuid, "N"));
            string physicalTaskId = TaskIdDerivation.Derive(
                ConversationId,
                previousResponseId: null,
                responseId,
                AgentName,
                PublicSessionId,
                taskScope,
                steerable: false);

            Assert.Multiple(() =>
            {
                Assert.That(store.LastCreateRequest?.Id, Is.EqualTo(physicalTaskId));
                Assert.That(store.LastCreateRequest?.Id, Is.Not.EqualTo(legacyTaskId));
            });
        }
        finally
        {
            RestoreEnvironment(previousHosted, previousGuid);
            DeleteRoot(root);
        }
    }

    [Test]
    public async Task HostedSessionInstanceIdReusesSuspendedLegacyTask()
    {
        string root = CreateRoot();
        string tasksDirectory = Path.Combine(root, "tasks");
        string? previousHosted = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        string? previousGuid = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_GUID");
        try
        {
            SetHostedSessionGuid(null);
            string firstResponseId;
            string legacyTaskId;
            var firstStore = new SpyTaskStore(new LocalTaskStore(tasksDirectory));
            using (var firstFactory = CreateFactory(root, firstStore))
            using (HttpClient firstClient = firstFactory.CreateClient())
            {
                using HttpResponseMessage firstResponse = await PostConversationAsync(firstClient);
                Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                firstResponseId = await ReadResponseIdAsync(firstResponse);
                legacyTaskId = firstStore.LastCreateRequest!.Id!;
                await WaitForStatusAsync(firstStore, legacyTaskId, TaskWireKeys.StatusSuspended);
                await firstFactory.StopAsync();
            }

            SetHostedSessionGuid("22222222222222222222222222222222");
            var secondStore = new SpyTaskStore(new LocalTaskStore(tasksDirectory));
            using var secondFactory = CreateFactory(root, secondStore);
            using HttpClient secondClient = secondFactory.CreateClient();

            using HttpResponseMessage secondResponse = await PostConversationAsync(
                secondClient,
                previousResponseId: firstResponseId);
            Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(
                secondStore.CreateCallCount,
                Is.Zero,
                "an active pre-rollout suspended chain must continue under its legacy task ID");
            await WaitForStatusAsync(secondStore, legacyTaskId, TaskWireKeys.StatusSuspended);
        }
        finally
        {
            RestoreEnvironment(previousHosted, previousGuid);
            DeleteRoot(root);
        }
    }

    private static TestWebApplicationFactory CreateFactory(string root, ITaskStore store)
        => new(
            configureOptions: options => options.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton(store);
                services.AddSingleton<ITaskStore>(store);
                services.AddSingleton<ResponsesProvider>(
                    _ => new FileResponsesProvider(Path.Combine(root, "responses")));
            },
            hosted: true);

    private static async Task<HttpResponseMessage> PostConversationAsync(
        HttpClient client,
        string? previousResponseId = null)
    {
        var body = new
        {
            model = "test",
            background = true,
            conversation = ConversationId,
            previous_response_id = previousResponseId,
            agent_session_id = PublicSessionId,
        };
        return await client.PostAsync(
            "/responses",
            new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));
    }

    private static async Task<string> ReadResponseIdAsync(HttpResponseMessage response)
    {
        using JsonDocument document =
            JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        return document.RootElement.GetProperty("id").GetString()!;
    }

    private static async Task WaitForStatusAsync(
        ITaskStore store,
        string taskId,
        string expectedStatus)
    {
        DateTimeOffset deadline = DateTimeOffset.UtcNow.AddSeconds(10);
        while (DateTimeOffset.UtcNow < deadline)
        {
            TaskRecord? record = await store.GetAsync(taskId);
            if (record?.Status == expectedStatus)
            {
                return;
            }

            await Task.Delay(20);
        }

        Assert.Fail($"Task '{taskId}' did not reach status '{expectedStatus}'.");
    }

    private static void SetHostedSessionGuid(string? sessionGuid)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_GUID", sessionGuid);
        FoundryEnvironment.Reload();
    }

    private static void RestoreEnvironment(string? hosted, string? sessionGuid)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", hosted);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_GUID", sessionGuid);
        FoundryEnvironment.Reload();
    }

    private static string CreateRoot()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-session-guid-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        return root;
    }

    private static void DeleteRoot(string root)
    {
        try
        {
            Directory.Delete(root, recursive: true);
        }
        catch (IOException)
        {
        }
    }
}
