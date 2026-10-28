// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using global::A2A;
using Azure.AI.AgentServer.Core.Storage;
using Azure.AI.AgentServer.A2A.Tests.Snippets;
using Azure.AI.AgentServer.A2A.Internal;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
[NonParallelizable]
public class FoundryTaskStoreTests
{
    private string? _previousRoot;
    private string _testRoot = null!;

    [SetUp]
    public void SetUp()
    {
        _previousRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        _testRoot = Path.Combine(Path.GetTempPath(), $"a2a-dotnet-tests-{Guid.NewGuid():N}");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", _testRoot);
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", _previousRoot);
        if (Directory.Exists(_testRoot))
        {
            Directory.Delete(_testRoot, recursive: true);
        }
    }

    [Test]
    public async Task NativeTasksSurviveReconstructionAndUseNativePaging()
    {
        string name = $"a2a-test-{Guid.NewGuid():N}";
        var backing = await FoundryStateStore.GetOrCreateAsync(name);
        try
        {
            var store = new FoundryTaskStore(backing);
            await store.SaveTaskAsync("t1", CreateTask("t1"));
            await store.SaveTaskAsync("t2", CreateTask("t2"));
            var reconstructed = new FoundryTaskStore(backing);
            var loaded = await reconstructed.GetTaskAsync("t1");
            Assert.That(loaded, Is.Not.Null);
            Assert.That(loaded!.Metadata!["custom"].GetProperty("nested").GetInt32(), Is.EqualTo(42));
            var page = await reconstructed.ListTasksAsync(new() { ContextId = "c1", PageSize = 1 });
            Assert.That(page.Tasks, Has.Count.EqualTo(1));
            Assert.That(page.NextPageToken, Is.Not.Null.And.Not.Empty);
            var next = await reconstructed.ListTasksAsync(new() { ContextId = "c1", PageSize = 1, PageToken = page.NextPageToken });
            Assert.That(next.Tasks, Has.Count.EqualTo(1));
            Assert.That(next.Tasks[0].Id, Is.Not.EqualTo(page.Tasks[0].Id));
            await reconstructed.DeleteTaskAsync("t1");
            Assert.That(await reconstructed.GetTaskAsync("t1"), Is.Null);
            await reconstructed.DeleteTaskAsync("t1");
        }
        finally
        {
            await backing.DeleteAsync();
        }
    }

    [Test]
    public async Task MismatchedTaskIdentityIsRejected()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        try
        {
            var store = new FoundryTaskStore(backing);
            Assert.ThrowsAsync<ArgumentException>(async () => await store.SaveTaskAsync("other", CreateTask("t1")));
        }
        finally
        {
            await backing.DeleteAsync();
        }
    }

    internal static AgentTask CreateTask(string id) => new()
    {
        Id = id,
        ContextId = "c1",
        Status = new() { State = TaskState.Completed, Timestamp = DateTimeOffset.UtcNow },
        Metadata = new() { ["custom"] = JsonSerializer.SerializeToElement(new { nested = 42 }) },
    };

    [Test]
    public async Task HttpTasksAreCallerScopedAndSurviveHostReconstruction()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        try
        {
            string taskId;
            await using (var app = await HostingTests.CreateAppAsync(services =>
            {
                services.AddSingleton<ITaskStore>(_ => new FoundryTaskStore(backing));
                services.AddSingleton<IAgentHandler, ReadMeSnippets.TaskAgent>();
            }))
            {
                using var client = app.GetTestClient();
                client.DefaultRequestHeaders.Add("x-agent-user-id", "alice");
                using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
                var text = await response.Content.ReadAsStringAsync();
                using var json = JsonDocument.Parse(text);
                Assert.That(json.RootElement.TryGetProperty("error", out _), Is.False, text);
                taskId = json.RootElement.GetProperty("result").GetProperty("task").GetProperty("id").GetString()!;
            }

            await using var restored = await HostingTests.CreateAppAsync(services =>
                services.AddSingleton<ITaskStore>(_ => new FoundryTaskStore(backing)));
            using var alice = restored.GetTestClient();
            alice.DefaultRequestHeaders.Add("x-agent-user-id", "alice");
            using var lookup = await alice.PostAsync("/a2a", HostingTests.Rpc("GetTask", $$"""{"id":"{{taskId}}"}"""));
            Assert.That(await lookup.Content.ReadAsStringAsync(), Does.Contain("TASK_STATE_COMPLETED"));

            using var bob = restored.GetTestClient();
            bob.DefaultRequestHeaders.Add("x-agent-user-id", "bob");
            foreach (var method in new[] { "GetTask", "CancelTask" })
            {
                using var denied = await bob.PostAsync("/a2a", HostingTests.Rpc(method, $$"""{"id":"{{taskId}}"}"""));
                Assert.That(await denied.Content.ReadAsStringAsync(), Does.Contain("\"error\""));
            }

            using var list = await bob.PostAsync("/a2a", HostingTests.Rpc("ListTasks"));
            using var listed = JsonDocument.Parse(await list.Content.ReadAsStringAsync());
            Assert.That(listed.RootElement.GetProperty("result").GetProperty("tasks").GetArrayLength(), Is.Zero);
        }
        finally
        {
            await backing.DeleteAsync();
        }
    }

    [Test]
    public async Task NativeIdentityAndTenantScopesDoNotCollide()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        using var store = new FoundryTaskStore(backing);
        var previous = A2ATaskScope.Current;
        try
        {
            A2ATaskScope.Current = new("tenant-a", "user-a");
            await store.SaveTaskAsync("t1", CreateTask("t1"));
            A2ATaskScope.Current = new("tenant-b", "user-a");
            Assert.That(await store.GetTaskAsync("t1"), Is.Null);
            A2ATaskScope.Current = new("tenant-a", "user-b");
            Assert.That(await store.GetTaskAsync("t1"), Is.Null);
            A2ATaskScope.Current = new("tenant-a", "user-a");
            Assert.That(await store.GetTaskAsync("t1"), Is.Not.Null);
        }
        finally
        {
            A2ATaskScope.Current = previous;
            await backing.DeleteAsync();
        }
    }

    [Test]
    public async Task ActiveTasksCannotBeSubscribedOrCanceledByAnotherCaller()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        var gate = new HostingTests.GatedTaskHandler();
        try
        {
            await using var app = await HostingTests.CreateAppAsync(services =>
            {
                services.AddSingleton<ITaskStore>(_ => new FoundryTaskStore(backing));
                services.AddSingleton<IAgentHandler>(gate);
            });
            using var alice = app.GetTestClient();
            alice.DefaultRequestHeaders.Add("x-agent-user-id", "alice");
            using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a")
            {
                Content = HostingTests.Rpc("SendStreamingMessage", HostingTests.MessageParams),
            };
            using var response = await alice.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .WaitAsync(TimeSpan.FromSeconds(10));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var first = await HostingTests.ReadDataAsync(reader);
            using var json = JsonDocument.Parse(first);
            var taskId = json.RootElement.GetProperty("result").GetProperty("task").GetProperty("id").GetString();
            using var bob = app.GetTestClient();
            bob.DefaultRequestHeaders.Add("x-agent-user-id", "bob");
            foreach (var method in new[] { "CancelTask", "SubscribeToTask" })
            {
                using var denied = await bob.PostAsync("/a2a", HostingTests.Rpc(method, $$"""{"id":"{{taskId}}"}"""))
                    .WaitAsync(TimeSpan.FromSeconds(10));
                Assert.That(await denied.Content.ReadAsStringAsync(), Does.Contain("\"error\""));
            }

            gate.Release.TrySetResult();
            await reader.ReadToEndAsync().WaitAsync(TimeSpan.FromSeconds(10));
        }
        finally
        {
            gate.Release.TrySetResult();
            await backing.DeleteAsync();
        }
    }

    [Test]
    public void CorruptSnapshotIsNotReturnedAsMissing()
    {
        using var store = new FoundryTaskStore(new CorruptStore());
        Assert.ThrowsAsync<InvalidDataException>(async () => await store.GetTaskAsync("t1"));
    }

    [Test]
    public async Task DisposedStoreAndInvalidConfigurationFailExplicitly()
    {
        Assert.Throws<ArgumentException>(() => new FoundryTaskStore(""));
        Assert.Throws<ArgumentOutOfRangeException>(() => new FoundryTaskStore("test", itemTtlSeconds: 0));
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        var store = new FoundryTaskStore(backing);
        store.Dispose();
        Assert.ThrowsAsync<ObjectDisposedException>(async () => await store.GetTaskAsync("t1"));
        await backing.DeleteAsync();
    }

    private sealed class CorruptStore : FoundryStateStore
    {
        public override Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken = default) =>
            Task.FromResult<StateStoreItem?>(AzureAIAgentServerCoreStorageModelFactory.StateStoreItem(
                key: "wrong-key",
                value: new Dictionary<string, BinaryData>
                {
                    ["task"] = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(CreateTask("t1"), A2AJsonUtilities.DefaultOptions)),
                }));
    }
}
