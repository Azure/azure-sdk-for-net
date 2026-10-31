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
/// <remarks>
/// Stores complete native task snapshots and uses native filtering and projection for task lists.
/// Hosted operations require caller context and a backing store with user isolation enabled.
/// Task persistence does not restart executors or make in-flight work resilient.
/// </remarks>
public class FoundryTaskStore : ITaskStore, IDisposable
{
    private readonly SemaphoreSlim _initialization = new(1, 1);
    private readonly string? _name;
    private readonly TokenCredential? _credential;
    private readonly Lazy<TokenCredential> _defaultCredential = new(
        static () => new DefaultAzureCredential(CreateDefaultCredentialOptions()));
    private const string ListSummaryTag = "a2a-list";
    private readonly Uri? _endpoint;
    private readonly int _itemTtlSeconds;
    private FoundryStateStore? _store;
    private bool _disposed;

    /// <summary>Initializes a new instance of the <see cref="FoundryTaskStore"/> class for mocking.</summary>
    protected FoundryTaskStore()
    {
    }

    /// <summary>Initializes a named task store that resolves its backing state store on first use.</summary>
    /// <param name="name">A stable store name scoped to the owning agent.</param>
    /// <param name="credential">
    /// The storage credential. When omitted in hosted execution, uses <see cref="DefaultAzureCredential"/>
    /// restricted to production credentials unless <c>AZURE_TOKEN_CREDENTIALS</c> explicitly selects a source.
    /// </param>
    /// <param name="endpoint">
    /// An optional Foundry project or storage endpoint. Defaults to the platform project endpoint when hosted.
    /// </param>
    /// <param name="itemTtlSeconds">
    /// Retention in seconds for items in a newly created store. Use <c>-1</c> for no expiration;
    /// otherwise the value must be positive. The default is 30 days.
    /// </param>
    /// <remarks>
    /// Non-hosted execution uses Core's local file-backed state store. The local backend does not
    /// authenticate callers; request identity scopes are a development partitioning convenience.
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="name"/> is empty or whitespace.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="itemTtlSeconds"/> is zero or less than <c>-1</c>.</exception>
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

    /// <summary>Initializes a task store using an existing backing state store.</summary>
    /// <param name="store">The backing state store. Hosted stores must enable user isolation.</param>
    /// <remarks>Disposing this adapter does not dispose or delete the supplied state store.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="store"/> is <see langword="null"/>.</exception>
    public FoundryTaskStore(FoundryStateStore store)
    {
        ArgumentNullException.ThrowIfNull(store);
        _store = store;
    }

    /// <summary>Gets a task snapshot in the current caller's scope.</summary>
    /// <param name="taskId">The native task identifier.</param>
    /// <param name="cancellationToken">A token to cancel the storage operation.</param>
    /// <returns>The native task snapshot, or <see langword="null"/> when the task does not exist in this scope.</returns>
    public virtual async Task<AgentTask?> GetTaskAsync(string taskId, CancellationToken cancellationToken = default)
    {
        var owner = Owner();
        var key = Key(taskId, owner);
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        var item = await store.GetItemAsync(key, cancellationToken).ConfigureAwait(false);
        if (item is null && !FoundryEnvironment.IsHosted && key != LegacyKey(taskId, owner))
        {
            item = await store.GetItemAsync(LegacyKey(taskId, owner), cancellationToken).ConfigureAwait(false);
        }
        return item is null ? null : Deserialize(item, owner);
    }

    /// <summary>Creates or replaces a complete task snapshot in the current caller's scope.</summary>
    /// <param name="taskId">The native task identifier, which must match <paramref name="task"/>.</param>
    /// <param name="task">The complete native task snapshot to store.</param>
    /// <param name="cancellationToken">A token to cancel the storage operation.</param>
    /// <returns>A task that completes when the snapshot has been stored.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="task"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The supplied identifier does not match the snapshot identifier.</exception>
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
        var summary = new AgentTask
        {
            Id = task.Id,
            ContextId = task.ContextId,
            Status = new global::A2A.TaskStatus { State = task.Status.State, Timestamp = task.Status.Timestamp },
        };
        var tags = new Dictionary<string, string> { ["a2a-owner"] = owner };
        string encodedSummary = Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(summary, A2AJsonUtilities.DefaultOptions));
        if (encodedSummary.Length <= 256)
        {
            tags[ListSummaryTag] = encodedSummary;
        }

        await store.SetItemAsync(key,
            new Dictionary<string, BinaryData> { ["task"] = BinaryData.FromBytes(payload) },
            tags: tags,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        if (!FoundryEnvironment.IsHosted && key != LegacyKey(taskId, owner))
        {
            await DeleteItemIfExistsAsync(store, LegacyKey(taskId, owner), cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>Deletes a task snapshot in the current caller's scope.</summary>
    /// <param name="taskId">The native task identifier.</param>
    /// <param name="cancellationToken">A token to cancel the storage operation.</param>
    /// <returns>A task that completes when deletion has finished. Missing snapshots are ignored.</returns>
    public virtual async Task DeleteTaskAsync(string taskId, CancellationToken cancellationToken = default)
    {
        var owner = Owner();
        var key = Key(taskId, owner);
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        await DeleteItemIfExistsAsync(store, key, cancellationToken).ConfigureAwait(false);
        if (!FoundryEnvironment.IsHosted && key != LegacyKey(taskId, owner))
        {
            await DeleteItemIfExistsAsync(store, LegacyKey(taskId, owner), cancellationToken).ConfigureAwait(false);
        }
    }

    private static async Task DeleteItemIfExistsAsync(
        FoundryStateStore store, string key, CancellationToken cancellationToken)
    {
        try
        {
            await store.DeleteItemAsync(key, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        catch (FoundryStorageNotFoundException)
        {
            // Native task deletion is idempotent.
        }
    }

    /// <summary>Lists task snapshots in the current caller's scope using native A2A filters and pagination.</summary>
    /// <param name="request">The native task-list filters, projection, and pagination options.</param>
    /// <param name="cancellationToken">A token to cancel the storage operation.</param>
    /// <returns>A native response containing the selected task snapshots and pagination information.</returns>
    /// <remarks>
    /// Scans listing summaries before applying native filtering and pagination, then reads the
    /// selected full snapshots. Records without summary metadata require a full read during the scan.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <see langword="null"/>.</exception>
    public virtual async Task<ListTasksResponse> ListTasksAsync(
        ListTasksRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var owner = Owner();
        var store = await GetStoreAsync(cancellationToken).ConfigureAwait(false);
        var view = new InMemoryTaskStore();
        var legacyTasks = new Dictionary<string, AgentTask>(StringComparer.Ordinal);
        string? cursor = null;
        do
        {
            var page = await store.ListKeysAsync(
                limit: 100, after: cursor, cancellationToken: cancellationToken).ConfigureAwait(false);
            foreach (var key in page.Keys)
            {
                // Existing owner tags contain a hyphen, which hosted tag queries do not support.
                if (!key.Tags.TryGetValue("a2a-owner", out string? storedOwner) || storedOwner != owner)
                {
                    continue;
                }

                AgentTask summary;
                if (key.Tags.TryGetValue(ListSummaryTag, out string? encoded))
                {
                    summary = Deserialize(BinaryData.FromBytes(Convert.FromBase64String(encoded)), key.Key, owner);
                }
                else
                {
                    var item = await store.GetItemAsync(key.Key, cancellationToken).ConfigureAwait(false);
                    if (item is null)
                    {
                        continue;
                    }

                    summary = Deserialize(item, owner);
                    legacyTasks[summary.Id] = summary;
                }

                await view.SaveTaskAsync(summary.Id, summary, cancellationToken).ConfigureAwait(false);
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

        var result = await view.ListTasksAsync(request, cancellationToken).ConfigureAwait(false);
        var selected = new InMemoryTaskStore();
        foreach (var summary in result.Tasks)
        {
            if (!legacyTasks.TryGetValue(summary.Id, out var task))
            {
                task = await GetTaskAsync(summary.Id, cancellationToken).ConfigureAwait(false);
                if (task is null)
                {
                    continue;
                }
            }

            await selected.SaveTaskAsync(task.Id, task, cancellationToken).ConfigureAwait(false);
        }

        var projected = await selected.ListTasksAsync(new ListTasksRequest
        {
            PageSize = result.Tasks.Count,
            HistoryLength = request.HistoryLength,
            IncludeArtifacts = request.IncludeArtifacts,
        }, cancellationToken).ConfigureAwait(false);
        var snapshots = projected.Tasks.ToDictionary(task => task.Id, StringComparer.Ordinal);
        result.Tasks = result.Tasks.Where(summary => snapshots.ContainsKey(summary.Id)).Select(summary => snapshots[summary.Id]).ToList();
        result.PageSize = result.Tasks.Count;
        return result;
    }

    private async Task<FoundryStateStore> GetStoreAsync(CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        await _initialization.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _store ??= await FoundryStateStore.GetOrCreateAsync(
                _name!,
                ResolveCredential(),
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

    internal TokenCredential? ResolveCredential() =>
        _credential ?? (FoundryEnvironment.IsHosted ? _defaultCredential.Value : null);

    internal static DefaultAzureCredentialOptions CreateDefaultCredentialOptions()
    {
        bool excludeDeveloperCredentials = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS"));
        return new DefaultAzureCredentialOptions
        {
            ExcludeVisualStudioCredential = excludeDeveloperCredentials,
            ExcludeVisualStudioCodeCredential = excludeDeveloperCredentials,
            ExcludeAzureCliCredential = excludeDeveloperCredentials,
            ExcludeAzurePowerShellCredential = excludeDeveloperCredentials,
            ExcludeAzureDeveloperCliCredential = excludeDeveloperCredentials,
            ExcludeBrokerCredential = excludeDeveloperCredentials,
        };
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
        string legacy = LegacyKey(taskId, owner);
        if (legacy.Length <= 128)
        {
            return legacy;
        }

        string digest = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(taskId)))
            .TrimEnd('=').Replace('+', '-').Replace('/', '_');
        return $"{owner}:sha256:{digest}";
    }

    private static string LegacyKey(string taskId, string owner) =>
        $"{owner}:{Convert.ToBase64String(Encoding.UTF8.GetBytes(taskId)).TrimEnd('=').Replace('+', '-').Replace('/', '_')}";

    private static AgentTask Deserialize(StateStoreItem item, string owner)
    {
        if (!item.Value.TryGetValue("task", out var payload))
        {
            throw new InvalidDataException("The stored A2A task snapshot is missing.");
        }

        return Deserialize(payload, item.Key, owner);
    }

    private static AgentTask Deserialize(BinaryData payload, string key, string owner)
    {
        var task = JsonSerializer.Deserialize<AgentTask>(payload.ToMemory().Span, A2AJsonUtilities.DefaultOptions)
            ?? throw new InvalidDataException("The stored A2A task snapshot is null.");
        if (key != Key(task.Id, owner) && key != LegacyKey(task.Id, owner))
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
