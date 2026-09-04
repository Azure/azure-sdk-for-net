// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Durable filesystem-backed implementation of <see cref="ResponsesProvider"/> for local
/// (non-hosted) resilient operation. Persists each response envelope, its ordered input/output/
/// history item id lists, and the shared item store to disk under
/// <c>{AGENTSERVER_STATE_ROOT:-~/.agentserver}/responses/</c> so that a background response
/// interrupted by a process crash or graceful shutdown can be recovered and re-invoked after the
/// single sandbox restarts. Semantics mirror <see cref="InMemoryResponsesProvider"/> exactly
/// (user isolation, deletion tracking, history/conversation resolution); the difference is that
/// state survives process restart.
/// </summary>
/// <remarks>
/// On construction the provider rehydrates its in-memory indexes by scanning the on-disk state so
/// reads are fast and post-restart recovery sees the pre-crash envelopes. Writes are write-through
/// and use an atomic temp-file + rename so a crash mid-write never corrupts a committed record.
/// </remarks>
internal sealed class FileResponsesProvider : ResponsesProvider
{
    private const string EnvelopesDirName = "envelopes";
    private const string ItemsDirName = "items";

    private static readonly JsonSerializerOptions s_indented = new() { WriteIndented = true };

    private readonly string _envelopesDir;
    private readonly string _itemsDir;
    private readonly object _diskGate = new();

    // In-memory indexes rehydrated from disk.
    private readonly ConcurrentDictionary<string, ResponseRecord> _records = new();
    private readonly ConcurrentDictionary<string, OutputItem> _itemStore = new();
    private readonly ConcurrentDictionary<string, List<string>> _conversationResponses = new();

    /// <summary>Initializes a new instance of <see cref="FileResponsesProvider"/>.</summary>
    /// <param name="baseDir">Override for the <c>responses</c> root directory; resolved from config when null.</param>
    public FileResponsesProvider(string? baseDir = null)
    {
        var root = baseDir ?? ResponsesStatePaths.ResponsesRoot();
        _envelopesDir = Path.Combine(root, EnvelopesDirName);
        _itemsDir = Path.Combine(root, ItemsDirName);
        Directory.CreateDirectory(_envelopesDir);
        Directory.CreateDirectory(_itemsDir);
        CleanupStaleTempFiles(_envelopesDir);
        CleanupStaleTempFiles(_itemsDir);
        Rehydrate();
    }

    /// <inheritdoc/>
    public override Task CreateResponseAsync(
        CreateResponseRequest request,
        PlatformContext context,
        CancellationToken cancellationToken = default)
    {
        var response = request.Response;

        var record = new ResponseRecord { Envelope = response };
        if (!_records.TryAdd(response.Id, record))
        {
            throw new InvalidOperationException($"Response '{response.Id}' already exists.");
        }

        if (context.UserIdKey is not null)
        {
            record.UserIdKey = context.UserIdKey;
        }

        foreach (var item in request.InputItems)
        {
            var id = GetItemId(item);
            if (id is not null)
            {
                _itemStore[id] = item;
                record.InputItemIds.Add(id);
                WriteItem(id, item);
            }
        }

        record.HistoryItemIds.AddRange(request.HistoryItemIds);

        StoreOutputItems(record, response);
        AddToConversation(response);
        record.ConversationId = response.Conversation?.Id;

        WriteRecord(record);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default)
    {
        if (!_records.TryGetValue(responseId, out var record) || record.Deleted || record.Envelope is null)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceUserIsolation(record, context);
        return Task.FromResult(record.Envelope);
    }

    /// <inheritdoc/>
    public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default)
    {
        var record = _records.AddOrUpdate(
            response.Id,
            _ => new ResponseRecord { Envelope = response },
            (_, existing) =>
            {
                existing.Envelope = response;
                return existing;
            });

        StoreOutputItems(record, response);
        AddToConversation(response);
        record.ConversationId ??= response.Conversation?.Id;

        WriteRecord(record);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override Task DeleteResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default)
    {
        if (!_records.TryGetValue(responseId, out var record) || record.Deleted)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceUserIsolation(record, context);

        // Tombstone: retain items/history/conversation membership (mirrors InMemory), mark deleted.
        record.Deleted = true;
        record.Envelope = null;
        record.UserIdKey = null;
        WriteRecord(record);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        PlatformContext context,
        int limit = 20,
        bool ascending = false,
        string? after = null,
        string? before = null,
        CancellationToken cancellationToken = default)
    {
        if (!_records.TryGetValue(responseId, out var record) || record.Deleted)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceUserIsolation(record, context);

        var allItems = new List<OutputItem>();
        foreach (var id in record.HistoryItemIds)
        {
            if (_itemStore.TryGetValue(id, out var item))
            {
                allItems.Add(item);
            }
        }

        foreach (var id in record.InputItemIds)
        {
            if (_itemStore.TryGetValue(id, out var item))
            {
                allItems.Add(item);
            }
        }

        var list = ascending ? allItems.ToList() : Enumerable.Reverse(allItems).ToList();

        if (after is not null)
        {
            var idx = list.FindIndex(i => GetItemId(i) == after);
            if (idx >= 0)
            {
                list = list.Skip(idx + 1).ToList();
            }
        }

        if (before is not null)
        {
            var idx = list.FindIndex(i => GetItemId(i) == before);
            if (idx >= 0)
            {
                list = list.Take(idx).ToList();
            }
        }

        var hasMore = list.Count > limit;
        var page = list.Take(limit).ToList();
        var firstId = page.Count > 0 ? GetItemId(page[0]) : null;
        var lastId = page.Count > 0 ? GetItemId(page[^1]) : null;

        var result = ResponsesModelFactory.AgentsPagedResultOutputItem(
            data: page,
            firstId: firstId!,
            lastId: lastId!,
            hasMore: hasMore);
        return Task.FromResult(result);
    }

    /// <inheritdoc/>
    public override Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        PlatformContext context,
        CancellationToken cancellationToken = default)
    {
        var results = itemIds.Select(id => _itemStore.TryGetValue(id, out var item) ? item : null);
        return Task.FromResult(results);
    }

    /// <inheritdoc/>
    public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        PlatformContext context,
        CancellationToken cancellationToken = default)
    {
        if (previousResponseId is not null && _records.TryGetValue(previousResponseId, out var prev))
        {
            var allIds = new List<string>();
            allIds.AddRange(prev.HistoryItemIds);
            allIds.AddRange(prev.InputItemIds);
            allIds.AddRange(prev.OutputItemIds);
            return Task.FromResult(allIds.Take(limit).AsEnumerable());
        }

        if (conversationId is not null && _conversationResponses.TryGetValue(conversationId, out var responseIds))
        {
            var allIds = new List<string>();
            lock (responseIds)
            {
                foreach (var respId in responseIds)
                {
                    if (_records.TryGetValue(respId, out var r))
                    {
                        allIds.AddRange(r.InputItemIds);
                        allIds.AddRange(r.OutputItemIds);
                    }
                }
            }

            return Task.FromResult(allIds.Take(limit).AsEnumerable());
        }

        return Task.FromResult(Enumerable.Empty<string>());
    }

    /// <summary>
    /// Returns the identifiers of every non-deleted response envelope currently persisted.
    /// Test-only introspection helper: crash recovery is owned by the Core task-durability scan
    /// (composed via <c>AddResilientTasks</c>), not by a Responses-side recovery scan, so this has
    /// no production caller — it exists solely to let tests assert the persisted-envelope set.
    /// </summary>
    internal IReadOnlyCollection<string> ListResponseIds()
        => _records.Where(kvp => !kvp.Value.Deleted && kvp.Value.Envelope is not null)
            .Select(kvp => kvp.Key)
            .ToList();

    private void EnforceUserIsolation(ResponseRecord record, PlatformContext context)
    {
        if (record.UserIdKey is not null
            && !string.Equals(record.UserIdKey, context.UserIdKey, StringComparison.Ordinal))
        {
            throw new ResourceNotFoundException($"Response '{record.Id}' not found.");
        }
    }

    private void StoreOutputItems(ResponseRecord record, Models.ResponseObject response)
    {
        if (response.Output.Count == 0)
        {
            return;
        }

        var outputIds = new List<string>();
        foreach (var item in response.Output)
        {
            var id = GetItemId(item);
            if (id is not null)
            {
                _itemStore[id] = item;
                outputIds.Add(id);
                WriteItem(id, item);
            }
        }

        if (outputIds.Count > 0)
        {
            record.OutputItemIds = outputIds;
        }
    }

    private void AddToConversation(Models.ResponseObject response)
    {
        var conversationId = response.Conversation?.Id;
        if (conversationId is null)
        {
            return;
        }

        var responseList = _conversationResponses.GetOrAdd(conversationId, _ => new List<string>());
        lock (responseList)
        {
            if (!responseList.Contains(response.Id))
            {
                responseList.Add(response.Id);
            }
        }
    }

    private static string? GetItemId(OutputItem item)
    {
        try
        {
            return item.GetId();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    // ── Persistence ─────────────────────────────────────────────────────

    private void WriteRecord(ResponseRecord record)
    {
        var node = record.ToJson();
        AtomicWrite(Path.Combine(_envelopesDir, record.Id + ".json"), node);
    }

    private void WriteItem(string itemId, OutputItem item)
    {
        var json = ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
        var node = JsonNode.Parse(json.ToString());
        if (node is not null)
        {
            AtomicWrite(Path.Combine(_itemsDir, SanitizeFileName(itemId) + ".json"), node);
        }
    }

    private void AtomicWrite(string path, JsonNode node)
    {
        lock (_diskGate)
        {
            var tempPath = path + ".tmp";
            var bytes = Encoding.UTF8.GetBytes(node.ToJsonString(s_indented));
            using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush(flushToDisk: true);
            }

            File.Move(tempPath, path, overwrite: true);
        }
    }

    private void Rehydrate()
    {
        // Items first so envelopes can resolve their referenced items.
        foreach (var itemFile in Directory.EnumerateFiles(_itemsDir, "*.json"))
        {
            var item = ReadItem(itemFile);
            if (item is not null)
            {
                var id = GetItemId(item);
                if (id is not null)
                {
                    _itemStore[id] = item;
                }
            }
        }

        foreach (var recordFile in Directory.EnumerateFiles(_envelopesDir, "*.json"))
        {
            var record = ReadRecord(recordFile);
            if (record is null)
            {
                continue;
            }

            _records[record.Id] = record;

            if (!record.Deleted && record.ConversationId is { Length: > 0 } convId)
            {
                var list = _conversationResponses.GetOrAdd(convId, _ => new List<string>());
                lock (list)
                {
                    if (!list.Contains(record.Id))
                    {
                        list.Add(record.Id);
                    }
                }
            }
        }
    }

    private static ResponseRecord? ReadRecord(string path)
    {
        try
        {
            var text = File.ReadAllText(path, Encoding.UTF8);
            var node = JsonNode.Parse(text);
            return node is JsonObject obj ? ResponseRecord.FromJson(obj) : null;
        }
        catch (JsonException)
        {
            return null;
        }
        catch (IOException)
        {
            return null;
        }
    }

    private static OutputItem? ReadItem(string path)
    {
        try
        {
            var text = File.ReadAllText(path, Encoding.UTF8);
            return ModelReaderWriter.Read<OutputItem>(
                BinaryData.FromString(text),
                ModelReaderWriterOptions.Json,
                AzureAIAgentServerResponsesContext.Default);
        }
        catch (JsonException)
        {
            return null;
        }
        catch (FormatException)
        {
            return null;
        }
        catch (IOException)
        {
            return null;
        }
    }

    private static void CleanupStaleTempFiles(string dir)
    {
        if (!Directory.Exists(dir))
        {
            return;
        }

        foreach (var tempFile in Directory.EnumerateFiles(dir, "*.tmp"))
        {
            try
            {
                File.Delete(tempFile);
            }
            catch (IOException)
            {
                // Best-effort.
            }
        }
    }

    private static string SanitizeFileName(string id)
    {
        foreach (var invalid in Path.GetInvalidFileNameChars())
        {
            id = id.Replace(invalid, '_');
        }

        return id;
    }

    /// <summary>
    /// On-disk record for a single response: the serialized envelope plus the ordered item id
    /// lists and identity/lifecycle metadata needed to reconstruct provider state after restart.
    /// </summary>
    private sealed class ResponseRecord
    {
        private Models.ResponseObject? _envelope;

        public string Id { get; private set; } = string.Empty;

        public Models.ResponseObject? Envelope
        {
            get => _envelope;
            set
            {
                _envelope = value;
                if (value is not null)
                {
                    Id = value.Id;
                }
            }
        }

        public List<string> InputItemIds { get; } = new();

        public List<string> OutputItemIds { get; set; } = new();

        public List<string> HistoryItemIds { get; } = new();

        public string? UserIdKey { get; set; }

        public string? ConversationId { get; set; }

        public bool Deleted { get; set; }

        public JsonObject ToJson()
        {
            var obj = new JsonObject
            {
                ["id"] = Id,
                ["deleted"] = Deleted,
            };

            if (_envelope is not null)
            {
                var envJson = ModelReaderWriter.Write(_envelope, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
                obj["envelope"] = JsonNode.Parse(envJson.ToString());
            }

            obj["input_item_ids"] = ToJsonArray(InputItemIds);
            obj["output_item_ids"] = ToJsonArray(OutputItemIds);
            obj["history_item_ids"] = ToJsonArray(HistoryItemIds);

            if (UserIdKey is not null)
            {
                obj["user_id_key"] = UserIdKey;
            }

            if (ConversationId is not null)
            {
                obj["conversation_id"] = ConversationId;
            }

            return obj;
        }

        public static ResponseRecord FromJson(JsonObject obj)
        {
            var record = new ResponseRecord
            {
                Id = obj["id"]?.GetValue<string>() ?? string.Empty,
                Deleted = obj["deleted"]?.GetValue<bool>() ?? false,
                UserIdKey = obj["user_id_key"]?.GetValue<string>(),
                ConversationId = obj["conversation_id"]?.GetValue<string>(),
            };

            if (obj["envelope"] is JsonObject env)
            {
                record._envelope = ModelReaderWriter.Read<Models.ResponseObject>(
                    BinaryData.FromString(env.ToJsonString()),
                    ModelReaderWriterOptions.Json,
                    AzureAIAgentServerResponsesContext.Default);
            }

            ReadInto(record.InputItemIds, obj["input_item_ids"]);
            ReadInto(record.OutputItemIds, obj["output_item_ids"]);
            ReadInto(record.HistoryItemIds, obj["history_item_ids"]);
            return record;
        }

        private static JsonArray ToJsonArray(IEnumerable<string> ids)
        {
            var array = new JsonArray();
            foreach (var id in ids)
            {
                array.Add(id);
            }

            return array;
        }

        private static void ReadInto(List<string> target, JsonNode? node)
        {
            if (node is JsonArray array)
            {
                foreach (var element in array)
                {
                    if (element is not null)
                    {
                        target.Add(element.GetValue<string>());
                    }
                }
            }
        }
    }
}
