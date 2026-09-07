// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Storage;

internal sealed class LocalStateStoreBackend
{
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> Locks =
        new(StringComparer.OrdinalIgnoreCase);

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        WriteIndented = true,
    };

    private readonly string _path;
    private readonly string _lockPath;
    private readonly string _name;
    private bool _userIsolation;
    private int _itemTtlSeconds;
    private string? _description;
    private IReadOnlyDictionary<string, string> _tags;
    private readonly Func<long> _clock;
    private readonly SemaphoreSlim _lock;

    public LocalStateStoreBackend(
        string path,
        string name,
        bool userIsolation,
        int itemTtlSeconds,
        string? description,
        IReadOnlyDictionary<string, string>? tags,
        Func<long>? clock = null)
    {
        _path = path;
        _lockPath = path + ".lock";
        _name = name;
        _userIsolation = userIsolation;
        _itemTtlSeconds = itemTtlSeconds;
        _description = description;
        _tags = tags ?? new Dictionary<string, string>();
        _clock = clock ?? (() => DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        _lock = Locks.GetOrAdd(Path.GetFullPath(path), _ => new SemaphoreSlim(1, 1));
    }

    public async Task<StateStore> EnsureStoreAsync(CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument? document = await ReadAsync(cancellationToken).ConfigureAwait(false);
            if (document is null)
            {
                long now = _clock();
                document = new LocalStateStoreDocument
                {
                    Store = new LocalStateStoreRecord
                    {
                        Id = ResourceId("ss", _name),
                        Name = _name,
                        UserIsolation = _userIsolation,
                        ItemTtlSeconds = _itemTtlSeconds,
                        Description = _description,
                        Tags = new Dictionary<string, string>(_tags),
                        CreatedAt = now,
                        UpdatedAt = now,
                    },
                };
                await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                SyncStoreConfig(document.Store);
            }

            return ToModel(document.Store);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStore> GetStoreAsync(CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            return ToModel((await RequireDocumentAsync(cancellationToken).ConfigureAwait(false)).Store);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStore> UpdateStoreAsync(StateStoreUpdateOptions update, CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            if (update.IsDescriptionSet)
            {
                document.Store.Description = update.Description;
            }

            if (update.IsTagsSet)
            {
                document.Store.Tags = update.Tags is null
                    ? new Dictionary<string, string>()
                    : new Dictionary<string, string>(update.Tags);
            }

            document.Store.UpdatedAt = _clock();
            await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            return ToModel(document.Store);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<DeletedStateStore> DeleteStoreAsync(CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument? document = await ReadAsync(cancellationToken).ConfigureAwait(false);
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            return AzureAIAgentServerCoreStorageModelFactory.DeletedStateStore(
                document?.Store.Id,
                _name,
                deleted: true);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStoreItemRef> CreateItemAsync(
        string key,
        IDictionary<string, BinaryData> value,
        IReadOnlyDictionary<string, string>? tags,
        CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            RemoveExpired(document);
            if (document.Items.ContainsKey(key))
            {
                throw new FoundryStorageConflictException($"State store item '{key}' already exists.");
            }

            LocalStateStoreItemRecord item = NewItem(key, value, tags);
            document.Items[key] = item;
            await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            return ToItemRef(item);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStoreItemRef> SetItemAsync(
        string key,
        IDictionary<string, BinaryData> value,
        IReadOnlyDictionary<string, string>? tags,
        string? ifMatch,
        CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            RemoveExpired(document);
            document.Items.TryGetValue(key, out LocalStateStoreItemRecord? current);
            CheckPrecondition(key, current, ifMatch);

            long now = _clock();
            var item = new LocalStateStoreItemRecord
            {
                Id = current?.Id ?? ResourceId("it", $"{_name}/{key}"),
                Key = key,
                Value = ToJsonValue(value),
                Tags = tags is null ? null : new Dictionary<string, string>(tags),
                Etag = NewEtag(),
                CreatedAt = current?.CreatedAt ?? now,
                UpdatedAt = now,
                ExpiresAt = ExpiresAt(now),
            };
            document.Items[key] = item;
            await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            return ToItemRef(item);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            bool changed = RemoveExpired(document);
            document.Items.TryGetValue(key, out LocalStateStoreItemRecord? item);
            if (changed)
            {
                await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            }

            return item is null ? null : ToItem(item);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<DeletedStateStoreItem> DeleteItemAsync(
        string key,
        string? ifMatch,
        CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            RemoveExpired(document);
            document.Items.TryGetValue(key, out LocalStateStoreItemRecord? current);
            CheckPrecondition(key, current, ifMatch);
            if (current is not null)
            {
                document.Items.Remove(key);
                await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            }

            return AzureAIAgentServerCoreStorageModelFactory.DeletedStateStoreItem(
                current?.Id,
                key,
                deleted: true);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<StateStoreItemKeyPage> ListKeysAsync(
        IReadOnlyDictionary<string, string>? tags,
        int? limit,
        string? after,
        string? before,
        ListRequestOrder order,
        CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await using FileStream transactionLock = await AcquireProcessLockAsync(cancellationToken).ConfigureAwait(false);
            LocalStateStoreDocument document = await RequireDocumentAsync(cancellationToken).ConfigureAwait(false);
            bool changed = RemoveExpired(document);
            IEnumerable<LocalStateStoreItemRecord> query = document.Items.Values;
            if (tags is not null)
            {
                query = query.Where(item =>
                    tags.All(pair => item.Tags is not null
                        && item.Tags.TryGetValue(pair.Key, out string? value)
                        && value == pair.Value));
            }

            query = order == ListRequestOrder.Asc
                ? query.OrderBy(item => item.CreatedAt).ThenBy(item => item.Id, StringComparer.Ordinal)
                : query.OrderByDescending(item => item.CreatedAt).ThenByDescending(item => item.Id, StringComparer.Ordinal);

            List<LocalStateStoreItemRecord> items = query.ToList();
            if (after is not null)
            {
                items = AfterCursor(items, after);
            }
            else if (before is not null)
            {
                items = BeforeCursor(items, before);
            }

            int pageSize = limit ?? 20;
            List<LocalStateStoreItemRecord> pageItems = items.Take(pageSize).ToList();
            if (changed)
            {
                await WriteAsync(document, cancellationToken).ConfigureAwait(false);
            }

            List<StateStoreItemKey> keys = pageItems.Select(ToItemKey).ToList();
            string firstId = keys.Count == 0 ? null! : keys[0].Id;
            string lastId = keys.Count == 0 ? null! : keys[^1].Id;
            ListResponseStateStoreItemKey envelope =
                AzureAIAgentServerCoreStorageModelFactory.ListResponseStateStoreItemKey(
                    keys,
                    firstId,
                    lastId,
                    items.Count > pageItems.Count);
            return new StateStoreItemKeyPage(envelope);
        }
        finally
        {
            _lock.Release();
        }
    }

    private async Task<LocalStateStoreDocument> RequireDocumentAsync(CancellationToken cancellationToken)
    {
        LocalStateStoreDocument document = await ReadAsync(cancellationToken).ConfigureAwait(false)
            ?? throw new FoundryStorageNotFoundException($"State store '{_name}' does not exist.");
        SyncStoreConfig(document.Store);
        return document;
    }

    private async Task<FileStream> AcquireProcessLockAsync(CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_lockPath)!);
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                return new FileStream(
                    _lockPath,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.None,
                    bufferSize: 1,
                    useAsync: true);
            }
            catch (IOException)
            {
                await Task.Delay(50, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private void SyncStoreConfig(LocalStateStoreRecord store)
    {
        _userIsolation = store.UserIsolation;
        _itemTtlSeconds = store.ItemTtlSeconds;
        _description = store.Description;
        _tags = new Dictionary<string, string>(store.Tags);
    }

    private async Task<LocalStateStoreDocument?> ReadAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_path))
        {
            return null;
        }

        await using FileStream stream = new(
            _path,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            bufferSize: 4096,
            useAsync: true);
        return await JsonSerializer.DeserializeAsync<LocalStateStoreDocument>(
            stream,
            SerializerOptions,
            cancellationToken).ConfigureAwait(false);
    }

    private async Task WriteAsync(LocalStateStoreDocument document, CancellationToken cancellationToken)
    {
        string directory = Path.GetDirectoryName(_path)!;
        Directory.CreateDirectory(directory);
        string temporary = Path.Combine(directory, $".{Path.GetFileName(_path)}.{Guid.NewGuid():N}.tmp");
        try
        {
            await using (FileStream stream = new(
                temporary,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 4096,
                useAsync: true))
            {
                await JsonSerializer.SerializeAsync(
                    stream,
                    document,
                    SerializerOptions,
                    cancellationToken).ConfigureAwait(false);
                await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }

            File.Move(temporary, _path, overwrite: true);
        }
        finally
        {
            if (File.Exists(temporary))
            {
                File.Delete(temporary);
            }
        }
    }

    private LocalStateStoreItemRecord NewItem(
        string key,
        IDictionary<string, BinaryData> value,
        IReadOnlyDictionary<string, string>? tags)
    {
        long now = _clock();
        return new LocalStateStoreItemRecord
        {
            Id = ResourceId("it", $"{_name}/{key}"),
            Key = key,
            Value = ToJsonValue(value),
            Tags = tags is null ? null : new Dictionary<string, string>(tags),
            Etag = NewEtag(),
            CreatedAt = now,
            UpdatedAt = now,
            ExpiresAt = ExpiresAt(now),
        };
    }

    private long? ExpiresAt(long now) => _itemTtlSeconds == -1 ? null : now + _itemTtlSeconds;

    private bool RemoveExpired(LocalStateStoreDocument document)
    {
        long now = _clock();
        string[] expired = document.Items
            .Where(pair => pair.Value.ExpiresAt is not null && pair.Value.ExpiresAt <= now)
            .Select(pair => pair.Key)
            .ToArray();
        foreach (string key in expired)
        {
            document.Items.Remove(key);
        }

        return expired.Length > 0;
    }

    private static void CheckPrecondition(string key, LocalStateStoreItemRecord? current, string? ifMatch)
    {
        if (ifMatch is null)
        {
            return;
        }

        if (current is null || (ifMatch != "*" && ifMatch != current.Etag))
        {
            throw new FoundryStoragePreconditionException(
                $"ETag precondition failed for state store item '{key}'.",
                current?.Etag);
        }
    }

    private static List<LocalStateStoreItemRecord> AfterCursor(
        List<LocalStateStoreItemRecord> items,
        string cursor)
    {
        int index = items.FindIndex(item => item.Id == cursor);
        return index < 0 ? new List<LocalStateStoreItemRecord>() : items.Skip(index + 1).ToList();
    }

    private static List<LocalStateStoreItemRecord> BeforeCursor(
        List<LocalStateStoreItemRecord> items,
        string cursor)
    {
        int index = items.FindIndex(item => item.Id == cursor);
        return index < 0 ? new List<LocalStateStoreItemRecord>() : items.Take(index).ToList();
    }

    private static Dictionary<string, JsonElement> ToJsonValue(IDictionary<string, BinaryData> value)
    {
        var result = new Dictionary<string, JsonElement>(StringComparer.Ordinal);
        foreach (KeyValuePair<string, BinaryData> pair in value)
        {
            using JsonDocument document = JsonDocument.Parse(pair.Value);
            result[pair.Key] = document.RootElement.Clone();
        }

        return result;
    }

    private static Dictionary<string, BinaryData> ToBinaryValue(IReadOnlyDictionary<string, JsonElement> value)
        => value.ToDictionary(
            pair => pair.Key,
            pair => BinaryData.FromString(pair.Value.GetRawText()),
            StringComparer.Ordinal);

    private static StateStore ToModel(LocalStateStoreRecord store)
        => AzureAIAgentServerCoreStorageModelFactory.StateStore(
            store.Id,
            store.Name,
            store.UserIsolation,
            store.ItemTtlSeconds,
            store.Description,
            store.Tags,
            store.CreatedAt,
            store.UpdatedAt);

    private static StateStoreItem ToItem(LocalStateStoreItemRecord item)
        => AzureAIAgentServerCoreStorageModelFactory.StateStoreItem(
            item.Id,
            item.Key,
            ToBinaryValue(item.Value),
            item.Tags ?? new Dictionary<string, string>(),
            item.Etag,
            item.CreatedAt,
            item.UpdatedAt);

    private static StateStoreItemRef ToItemRef(LocalStateStoreItemRecord item)
        => AzureAIAgentServerCoreStorageModelFactory.StateStoreItemRef(
            item.Id,
            item.Key,
            item.Etag,
            item.CreatedAt,
            item.UpdatedAt);

    private static StateStoreItemKey ToItemKey(LocalStateStoreItemRecord item)
        => AzureAIAgentServerCoreStorageModelFactory.StateStoreItemKey(
            item.Id,
            item.Key,
            item.Tags ?? new Dictionary<string, string>(),
            item.Etag,
            item.CreatedAt,
            item.UpdatedAt);

    private static string ResourceId(string prefix, string value)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(value));
        return $"{prefix}_{Convert.ToHexString(hash).ToLowerInvariant()[..24]}";
    }

    private static string NewEtag() => $"\"local-{Guid.NewGuid():N}\"";

    private sealed class LocalStateStoreDocument
    {
        [JsonPropertyName("store")]
        public LocalStateStoreRecord Store { get; set; } = new();

        [JsonPropertyName("items")]
        public Dictionary<string, LocalStateStoreItemRecord> Items { get; set; } =
            new(StringComparer.Ordinal);
    }

    private sealed class LocalStateStoreRecord
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("object")]
        public string Object { get; set; } = "state_store";

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("user_isolation")]
        public bool UserIsolation { get; set; }

        [JsonPropertyName("item_ttl_seconds")]
        public int ItemTtlSeconds { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("tags")]
        public Dictionary<string, string> Tags { get; set; } = new();

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }
    }

    private sealed class LocalStateStoreItemRecord
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("object")]
        public string Object { get; set; } = "state_store.item";

        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public Dictionary<string, JsonElement> Value { get; set; } = new(StringComparer.Ordinal);

        [JsonPropertyName("tags")]
        public Dictionary<string, string>? Tags { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("expires_at")]
        public long? ExpiresAt { get; set; }
    }
}
