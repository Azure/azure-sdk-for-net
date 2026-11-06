// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text;
using global::A2A;
using Azure.AI.AgentServer.A2A.Internal;
using Azure.AI.AgentServer.A2A.Tests.Snippets;
using Azure.AI.AgentServer.Core.Storage;
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
            using var store = new FoundryTaskStore(backing);
            await store.SaveTaskAsync("t1", CreateTask("t1"));
            await store.SaveTaskAsync("t2", CreateTask("t2"));
            using var reconstructed = new FoundryTaskStore(backing);
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
            using var store = new FoundryTaskStore(backing);
            Assert.ThrowsAsync<ArgumentException>(async () => await store.SaveTaskAsync("other", CreateTask("t1")));
        }
        finally
        {
            await backing.DeleteAsync();
        }
    }

        [Test]
        public async Task SmallPagesReadOnlySelectedSnapshotsAndPreserveNativeProjection()
        {
            var backing = await FoundryStateStore.GetOrCreateAsync("paging");
            var tracking = new TrackingStateStore(backing);
            using var store = new FoundryTaskStore(tracking);
            var native = new InMemoryTaskStore();
            for (int index = 0; index < 105; index++)
            {
                var task = CreateTask($"t{index:D3}");
                task.ContextId = index % 2 == 0 ? "even" : "odd";
                task.Status.Timestamp = DateTimeOffset.UnixEpoch.AddSeconds(index);
                task.Status.State = index % 3 == 0 ? TaskState.Working : TaskState.Completed;
                task.Artifacts = [new Artifact { ArtifactId = $"a{index}", Parts = [Part.FromText(new string('x', 10000))] }];
                task.History =
                [
                    new Message { MessageId = $"m{index}-1", Role = Role.User, Parts = [Part.FromText("first")] },
                    new Message { MessageId = $"m{index}-2", Role = Role.Agent, Parts = [Part.FromText("second")] },
                ];
                await store.SaveTaskAsync(task.Id, task);
                await native.SaveTaskAsync(task.Id, task);
            }

            foreach (var projection in new[]
            {
                new ListTasksRequest { ContextId = "even", Status = TaskState.Completed, PageSize = 1, IncludeArtifacts = true, HistoryLength = 1 },
                new ListTasksRequest { PageSize = 1, IncludeArtifacts = false, HistoryLength = 0 },
                new ListTasksRequest { PageSize = 1, IncludeArtifacts = true },
            })
            {
                var request = projection;
                request.StatusTimestampAfter = DateTimeOffset.UnixEpoch.AddSeconds(10);
                for (int page = 0; page < 2; page++)
                {
                    tracking.Reads = 0;
                    var actual = await store.ListTasksAsync(request);
                    var expected = await native.ListTasksAsync(request);
                    Assert.That(JsonSerializer.Serialize(actual, A2AJsonUtilities.DefaultOptions),
                        Is.EqualTo(JsonSerializer.Serialize(expected, A2AJsonUtilities.DefaultOptions)));
                    Assert.That(tracking.Reads, Is.EqualTo(1));
                    request.PageToken = actual.NextPageToken;
                }
            }

            tracking.Reads = 0;
            var empty = await store.ListTasksAsync(new() { ContextId = "absent" });
            Assert.That(empty.Tasks, Is.Empty);
            Assert.That(tracking.Reads, Is.Zero);
        }

        [Test]
        public async Task ListingFallsBackForLegacySnapshotsWithoutSummaryTags()
        {
            var backing = await FoundryStateStore.GetOrCreateAsync("legacy");
            var tracking = new TrackingStateStore(backing);
            using var store = new FoundryTaskStore(tracking);
            await store.SaveTaskAsync("t1", CreateTask("t1"));
            string key = tracking.LastKey!;
            var item = await backing.GetItemAsync(key);
            await backing.SetItemAsync(key, item!.Value,
                tags: new Dictionary<string, string> { ["a2a-owner"] = item.Tags["a2a-owner"] });
            tracking.Reads = 0;
            var page = await store.ListTasksAsync(new() { PageSize = 1 });
            Assert.That(page.Tasks.Single().Id, Is.EqualTo("t1"));
            Assert.That(tracking.Reads, Is.EqualTo(1));
        }

    [Test]
    public async Task ListingSummariesTrackUpdatesAndValidateTaskIdentity()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("updated-summary");
        var tracking = new TrackingStateStore(backing);
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask("t1");
        await store.SaveTaskAsync(task.Id, task);
        task.ContextId = "changed";
        task.Status.State = TaskState.Working;
        task.Status.Timestamp = null;
        await store.SaveTaskAsync(task.Id, task);
        tracking.Reads = 0;
        Assert.That((await store.ListTasksAsync(new() { Status = TaskState.Completed })).Tasks, Is.Empty);
        Assert.That(tracking.Reads, Is.Zero);
        Assert.That((await store.ListTasksAsync(new() { ContextId = "changed", Status = TaskState.Working })).Tasks.Single().Id, Is.EqualTo("t1"));
        Assert.That((await store.ListTasksAsync(new() { StatusTimestampAfter = DateTimeOffset.UnixEpoch })).Tasks, Is.Empty);

        var item = await backing.GetItemAsync(tracking.LastKey!);
        var tags = new Dictionary<string, string>(item!.Tags)
        {
            ["a2a-list"] = Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(CreateTask("wrong-id"), A2AJsonUtilities.DefaultOptions)),
        };
        await backing.SetItemAsync(item.Key, item.Value, tags);
        tracking.Reads = 0;
        Assert.ThrowsAsync<InvalidDataException>(async () => await store.ListTasksAsync(new()));
        Assert.That(tracking.Reads, Is.Zero);
    }

    [Test]
    public async Task OversizedListingSummaryFallsBackWithoutLosingOpaqueIdentifiers()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("summary-limits");
        var tracking = new TrackingStateStore(backing) { EnforceHostedLimits = true };
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask("task-1");
        task.ContextId = new string('c', 1024);
        await store.SaveTaskAsync(task.Id, task);
        var item = await backing.GetItemAsync(tracking.LastKey!);
        Assert.That(item!.Tags.ContainsKey("a2a-list"), Is.False);
        var page = await store.ListTasksAsync(new() { ContextId = task.ContextId });
        Assert.That(page.Tasks.Single().ContextId, Is.EqualTo(task.ContextId));
        Assert.That((await store.GetTaskAsync(task.Id))!.ContextId, Is.EqualTo(task.ContextId));
    }

    [TestCase(47)]
    [TestCase(48)]
    [TestCase(128)]
    [TestCase(1024)]
    public async Task OpaqueTaskIdsUseBoundedKeysWithoutColliding(int length)
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("key-limits");
        var tracking = new TrackingStateStore(backing) { EnforceHostedLimits = true };
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask(new string('t', length));
        await store.SaveTaskAsync(task.Id, task);
        string firstKey = tracking.LastKey!;
        Assert.That(firstKey.Length, Is.LessThanOrEqualTo(128));
        Assert.That((await store.GetTaskAsync(task.Id))!.Id, Is.EqualTo(task.Id));
        var other = CreateTask(task.Id[..^1] + "u");
        await store.SaveTaskAsync(other.Id, other);
        Assert.That(tracking.LastKey, Is.Not.EqualTo(firstKey));
        Assert.That((await store.ListTasksAsync(new() { PageSize = 10 })).Tasks.Select(t => t.Id),
            Is.EquivalentTo(new[] { task.Id, other.Id }));
        await store.DeleteTaskAsync(task.Id);
        Assert.That(await backing.GetItemAsync(firstKey), Is.Null);
        Assert.That((await store.GetTaskAsync(other.Id))!.Id, Is.EqualTo(other.Id));
    }

    [TestCase(256, true)]
    [TestCase(260, false)]
    public async Task ListingSummaryUsesTheExactEncodedTagLimit(int encodedLength, bool included)
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("summary-boundary");
        var tracking = new TrackingStateStore(backing) { EnforceHostedLimits = true };
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask("task-1");
        string? contextId = Enumerable.Range(0, 512).Select(length => new string('c', length))
            .FirstOrDefault(candidate => Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(
                new AgentTask { Id = task.Id, ContextId = candidate, Status = task.Status },
                A2AJsonUtilities.DefaultOptions)).Length == encodedLength);
        Assert.That(contextId, Is.Not.Null);
        task.ContextId = contextId!;
        await store.SaveTaskAsync(task.Id, task);
        var item = await backing.GetItemAsync(tracking.LastKey!);
        Assert.That(item!.Tags.ContainsKey("a2a-list"), Is.EqualTo(included));
        if (included)
        {
            Assert.That(item.Tags["a2a-list"].Length, Is.EqualTo(encodedLength));
        }
        Assert.That((await store.ListTasksAsync(new() { ContextId = contextId })).Tasks.Single().Id, Is.EqualTo(task.Id));
    }

    [Test]
    public async Task MultibyteTaskIdentifiersArePreservedInBoundedKeys()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("unicode-key");
        var tracking = new TrackingStateStore(backing) { EnforceHostedLimits = true };
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask(new string('\u00e9', 64));
        await store.SaveTaskAsync(task.Id, task);
        Assert.That(tracking.LastKey!.Length, Is.LessThanOrEqualTo(128));
        Assert.That((await store.GetTaskAsync(task.Id))!.Id, Is.EqualTo(task.Id));
        Assert.That((await store.ListTasksAsync(new())).Tasks.Single().Id, Is.EqualTo(task.Id));
    }

    [TestCase(32)]
    [TestCase(128)]
    public async Task ExistingTaskKeysRemainReadableAndCanBeUpdatedAndDeleted(int length)
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("legacy-keys");
        var tracking = new TrackingStateStore(backing);
        using var store = new FoundryTaskStore(tracking);
        var task = CreateTask(new string('t', length));
        await store.SaveTaskAsync(task.Id, task);
        var item = await backing.GetItemAsync(tracking.LastKey!);
        string legacyKey = item!.Tags["a2a-owner"] + ":" +
            Convert.ToBase64String(Encoding.UTF8.GetBytes(task.Id)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        await backing.DeleteItemAsync(item.Key);
        await backing.SetItemAsync(legacyKey, item.Value, new Dictionary<string, string>(item.Tags));
        Assert.That((await store.GetTaskAsync(task.Id))!.Id, Is.EqualTo(task.Id));
        Assert.That((await store.ListTasksAsync(new() { PageSize = 1 })).Tasks.Single().Id, Is.EqualTo(task.Id));
        task.ContextId = "updated";
        await store.SaveTaskAsync(task.Id, task);
        Assert.That((await store.ListTasksAsync(new() { ContextId = "updated" })).Tasks.Single().Id, Is.EqualTo(task.Id));
        await store.DeleteTaskAsync(task.Id);
        Assert.That(await store.GetTaskAsync(task.Id), Is.Null);
        Assert.That(await backing.GetItemAsync(legacyKey), Is.Null);
    }

    [Test]
    public async Task SnapshotDisappearingDuringHydrationIsSkippedWithoutRefillingThePage()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("disappearing");
        var tracking = new TrackingStateStore(backing);
        using var store = new FoundryTaskStore(tracking);
        await store.SaveTaskAsync("t1", CreateTask("t1"));
        tracking.MissingKey = tracking.LastKey;
        var result = await store.ListTasksAsync(new() { PageSize = 1 });
        Assert.That(result.Tasks, Is.Empty);
        Assert.That(result.PageSize, Is.Zero);
        Assert.That(result.TotalSize, Is.EqualTo(1));
        Assert.That(tracking.Reads, Is.EqualTo(1));
    }

        private sealed class TrackingStateStore(FoundryStateStore inner) : FoundryStateStore
        {
            public int Reads { get; set; }
            public string? LastKey { get; private set; }
            public string? MissingKey { get; set; }
            public bool EnforceHostedLimits { get; set; }
            public override Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken = default)
            {
                Reads++;
                return key == MissingKey ? Task.FromResult<StateStoreItem?>(null) : inner.GetItemAsync(key, cancellationToken);
            }

            public override Task<StateStoreItemRef> SetItemAsync(
                string key, IDictionary<string, BinaryData> value, IReadOnlyDictionary<string, string>? tags = null,
                ETag ifMatch = default, bool requireExists = false, CancellationToken cancellationToken = default)
            {
                LastKey = key;
                if (EnforceHostedLimits)
                {
                    Assert.That(key.Length, Is.LessThanOrEqualTo(128), "Hosted item key limit");
                    Assert.That(tags?.Values.All(value => value.Length <= 256), Is.True, "Hosted tag-value limit");
                }
                return inner.SetItemAsync(key, value, tags, ifMatch, requireExists, cancellationToken);
            }

            public bool RejectTagQueries { get; set; }

            public override Task<DeletedStateStoreItem> DeleteItemAsync(
                string key, ETag ifMatch = default, CancellationToken cancellationToken = default) =>
                inner.DeleteItemAsync(key, ifMatch, cancellationToken);

            public override Task<StateStoreItemKeyPage> ListKeysAsync(
                IReadOnlyDictionary<string, string>? tags = null, int? limit = null, string? after = null,
                string? before = null, ListRequestOrder order = ListRequestOrder.Desc, CancellationToken cancellationToken = default)
            {
                if (RejectTagQueries && tags is not null) { throw new InvalidOperationException("Tag queries are not supported."); }
                return inner.ListKeysAsync(tags, limit, after, before, order, cancellationToken);
            }
        }

    [Test]
    public async Task ListingFiltersCallerSummariesBeforeHydratingWithoutTagQueries()
    {
        var backing = await FoundryStateStore.GetOrCreateAsync("owner-listing");
        var tracking = new TrackingStateStore(backing) { RejectTagQueries = true };
        using var store = new FoundryTaskStore(tracking);
        var previous = A2ATaskScope.Current;
        try
        {
            A2ATaskScope.Current = new("tenant", "alice");
            await store.SaveTaskAsync("alice-task", CreateTask("alice-task"));
            A2ATaskScope.Current = new("tenant", "bob");
            await store.SaveTaskAsync("bob-task", CreateTask("bob-task"));
            var other = await backing.GetItemAsync(tracking.LastKey!);
            await backing.SetItemAsync(other!.Key, other.Value,
                new Dictionary<string, string>(other.Tags) { ["a2a-list"] = "not-base64" });
            A2ATaskScope.Current = new("tenant", "alice");
            tracking.Reads = 0;
            var listed = await store.ListTasksAsync(new() { PageSize = 1 });
            Assert.That(listed.Tasks.Single().Id, Is.EqualTo("alice-task"));
            Assert.That(tracking.Reads, Is.EqualTo(1));
        }
        finally
        {
            A2ATaskScope.Current = previous;
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
        var backing = await FoundryStateStore.GetOrCreateAsync($"a2a-test-{Guid.NewGuid():N}");
        using var store = new FoundryTaskStore(backing);
        store.Dispose();
        Assert.ThrowsAsync<ObjectDisposedException>(async () => await store.GetTaskAsync("t1"));
        await backing.DeleteAsync();
    }

    [TestCase("")]
    [TestCase(" ")]
    public void InvalidStoreNameIsRejected(string name) =>
        Assert.Throws<ArgumentException>(() => new FoundryTaskStore(name));

    [Test]
    public void NullStoreArgumentsAreRejected()
    {
        Assert.Throws<ArgumentNullException>(() => new FoundryTaskStore((string)null!));
        Assert.Throws<ArgumentNullException>(() => new FoundryTaskStore((FoundryStateStore)null!));
    }

    [TestCase(0)]
    [TestCase(-2)]
    public void InvalidRetentionIsRejected(int retention) =>
        Assert.Throws<ArgumentOutOfRangeException>(() => new FoundryTaskStore("test", itemTtlSeconds: retention));

    [TestCase(-1)]
    [TestCase(1)]
    public void ValidRetentionDoesNotInitializeStorage(int retention)
    {
        using var store = new FoundryTaskStore("test", itemTtlSeconds: retention);
        Assert.That(store, Is.InstanceOf<ITaskStore>());
    }

    [Test]
    public void NullTaskAndListRequestsAreRejected()
    {
        using var store = new FoundryTaskStore(new CorruptStore());
        Assert.ThrowsAsync<ArgumentNullException>(async () => await store.SaveTaskAsync("t1", null!));
        Assert.ThrowsAsync<ArgumentNullException>(async () => await store.ListTasksAsync(null!));
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
