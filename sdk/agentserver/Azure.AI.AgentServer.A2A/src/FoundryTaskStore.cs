// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using global::A2A;
using Azure.AI.AgentServer.A2A.Internal;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Storage;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.AgentServer.A2A;

/// <summary>Persists native A2A task snapshots in a caller-isolated Foundry state store.</summary>
/// <remarks>Task persistence does not restart executors or make in-flight work resilient.</remarks>
public class FoundryTaskStore : ITaskStore, IDisposable
{
    private readonly SemaphoreSlim _initialization = new(1, 1);
    private readonly string? _name;
    private readonly TokenCredential? _credential;
    private readonly Uri? _endpoint;
    private readonly int _itemTtlSeconds;
    private FoundryStateStore? _store;
    private bool _disposed;

    /// <summary>Initializes an instance for mocking.</summary>
    protected FoundryTaskStore()
    {
    }

    /// <summary>Creates a lazily initialized store using Core's storage client.</summary>
    /// <param name="name">A stable store name scoped to the owning agent.</param>
    /// <param name="credential">An optional credential; defaults to managed identity when hosted.</param>
    /// <param name="endpoint">An optional Foundry project or storage endpoint.</param>
    /// <param name="itemTtlSeconds">Retention for items in a newly created store.</param>
    public FoundryTaskStore(
        string name,
        TokenCredential? credential = null,
        Uri? endpoint = null,
        int itemTtlSeconds = FoundryStateStore.DefaultItemTtlSeconds)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (itemTtlSeconds == 0 || itemTtlSeconds < -1)
        {
            throw new ArgumentOutOfRangeException(nameof(itemTtlSeconds));
        }

        _name = name;
        _credential = credential;
        _endpoint = endpoint;
        _itemTtlSeconds = itemTtlSeconds;
    }

    /// <summary>Wraps an existing state store without taking ownership of it.</summary>
    /// <param name="store">The backing state store. Hosted stores must enable user isolation.</param>
    public FoundryTaskStore(FoundryStateStore store)
    {
        ArgumentNullException.ThrowIfNull(store);
        _store = store;
    }

    /// <inheritdoc/>
    public virtual async Task<AgentTask?> GetTaskAsync(string taskId, CancellationToken cancellationToken = default)
    {
        var owner = Owner();
        var key = Key(taskId, owner);
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        var item = await store.GetItemAsync(key, cancellationToken).ConfigureAwait(false);
        return item is null ? null : Deserialize(item, owner);
    }

    /// <inheritdoc/>
    public virtual async Task SaveTaskAsync(string taskId, AgentTask task, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(task);
        if (!string.Equals(taskId, task.Id, StringComparison.Ordinal))
        {
            throw new ArgumentException("The task ID must match the snapshot ID.", nameof(taskId));
        }

        var owner = Owner();
        var key = Key(taskId, owner);
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        var payload = JsonSerializer.SerializeToUtf8Bytes(task, A2AJsonUtilities.DefaultOptions);
        await store.SetItemAsync(key,
            new Dictionary<string, BinaryData> { ["task"] = BinaryData.FromBytes(payload) },
            tags: new Dictionary<string, string> { ["a2a-owner"] = owner },
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public virtual async Task DeleteTaskAsync(string taskId, CancellationToken cancellationToken = default)
    {
        var key = Key(taskId, Owner());
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await store.DeleteItemAsync(key, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        catch (FoundryStorageNotFoundException)
        {
            // Native task deletion is idempotent.
        }
    }

    /// <inheritdoc/>
    public virtual async Task<ListTasksResponse> ListTasksAsync(
        ListTasksRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var owner = Owner();
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        var view = new InMemoryTaskStore();
        string? cursor = null;
        do
        {
            var page = await store.ListKeysAsync(
                tags: new Dictionary<string, string> { ["a2a-owner"] = owner },
                limit: 100, after: cursor, cancellationToken: cancellationToken).ConfigureAwait(false);
            foreach (var key in page.Keys)
            {
                var item = await store.GetItemAsync(key.Key, cancellationToken).ConfigureAwait(false);
                if (item is not null)
                {
                    var task = Deserialize(item, owner);
                    await view.SaveTaskAsync(task.Id, task, cancellationToken).ConfigureAwait(false);
                }
            }

            if (!page.HasMore)
            {
                break;
            }

            if (string.IsNullOrEmpty(page.LastId) || page.LastId == cursor)
            {
                throw new InvalidDataException("Foundry task storage returned a non-advancing cursor.");
            }

            cursor = page.LastId;
        }
        while (true);

        return await view.ListTasksAsync(request, cancellationToken).ConfigureAwait(false);
    }

    private async Task<FoundryStateStore> GetStoreAsync(CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        await _initialization.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _store ??= await FoundryStateStore.GetOrCreateAsync(
                _name!,
                _credential ?? (FoundryEnvironment.IsHosted ? new ManagedIdentityCredential(ManagedIdentityId.SystemAssigned) : null),
                _endpoint, userIsolation: FoundryEnvironment.IsHosted,
                itemTtlSeconds: _itemTtlSeconds, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _initialization.Release();
        }

        if (FoundryEnvironment.IsHosted)
        {
            var descriptor = await _store.GetAsync(cancellationToken).ConfigureAwait(false);
            if (descriptor?.UserIsolation != true)
            {
                throw new UnauthorizedAccessException("Hosted A2A task storage requires a user-isolated backing store.");
            }
        }

        return _store;
    }

    private static string Owner()
    {
        var platform = FoundryAgentRequestContext.Current;
        var scope = A2ATaskScope.Current;
        if (FoundryEnvironment.IsHosted
            && string.IsNullOrEmpty(platform.CallId)
            && string.IsNullOrEmpty(platform.UserId)
            && string.IsNullOrEmpty(scope?.UserId))
        {
            throw new UnauthorizedAccessException("Hosted A2A task persistence requires caller identity or brokered context.");
        }

        // Length-prefixed fields distinguish missing identities and prevent delimiter collisions.
        var identity = string.Concat(new[] { platform.UserId, scope?.Tenant, scope?.UserId }
            .Select(value => value is null ? "-1:" : $"{Encoding.UTF8.GetByteCount(value)}:{value}"));
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(identity))).ToLowerInvariant();
    }

    private static string Key(string taskId, string owner)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(taskId);
        var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(taskId)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        return $"{owner}:{encoded}";
    }

    private static AgentTask Deserialize(StateStoreItem item, string owner)
    {
        if (!item.Value.TryGetValue("task", out var payload))
        {
            throw new InvalidDataException("The stored A2A task snapshot is missing.");
        }

        var task = JsonSerializer.Deserialize<AgentTask>(payload.ToMemory().Span, A2AJsonUtilities.DefaultOptions)
            ?? throw new InvalidDataException("The stored A2A task snapshot is null.");
        if (item.Key != Key(task.Id, owner))
        {
            throw new InvalidDataException("The stored A2A task identity does not match its storage key.");
        }

        return task;
    }

    /// <summary>Releases initialization resources. The backing state store is not deleted.</summary>
    public virtual void Dispose()
    {
        _disposed = true;
        _initialization.Dispose();
        GC.SuppressFinalize(this);
    }
}
