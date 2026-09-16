// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// A durable, file-backed record of the streams a task deletion must close. A hard task deletion
/// removes the task record, so its in-memory close coordination cannot survive a crash. This
/// journal is written (before the provider delete) to a location that outlives the record and is
/// drained on restart: an entry whose task record is confirmed gone has its streams brought to EOF;
/// an entry whose record still exists is discarded without closing (the delete did not commit, so
/// the streams remain recoverable — never sealed on an uncommitted or reused-id delete).
///
/// Entries are keyed by a hash of the raw task id so any task id shape maps to a safe file name; the
/// raw task id and input ids are stored in the entry body.
/// </summary>
internal static class TaskStreamDeletionJournal
{
    private const string JournalDirectoryName = ".pending-deletes";

    public static void Record(string storageDirectory, string taskId, IReadOnlyCollection<string> inputIds)
    {
        if (inputIds.Count == 0)
        {
            return;
        }

        // Only tasks that materialized a file backing can have a stream owing EOF. If the storage
        // directory does not yet exist, nothing was persisted, so recording (and thereby creating
        // the directory) would fabricate a backing for a task that never had one.
        if (!Directory.Exists(storageDirectory))
        {
            return;
        }

        string journalDirectory = Path.Combine(storageDirectory, JournalDirectoryName);
        Directory.CreateDirectory(journalDirectory);

        var entry = new JournalEntry { TaskId = taskId, InputIds = new List<string>(inputIds) };
        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(entry, JournalContext.Default.JournalEntry);

        string path = EntryPath(journalDirectory, taskId);
        string temp = path + ".tmp";
        File.WriteAllBytes(temp, bytes);
        File.Move(temp, path, overwrite: true);
    }

    public static void Remove(string storageDirectory, string taskId)
    {
        string path = EntryPath(Path.Combine(storageDirectory, JournalDirectoryName), taskId);
        try
        {
            File.Delete(path);
        }
        catch (DirectoryNotFoundException)
        {
            // No journal directory means nothing to remove.
        }
    }

    public static IReadOnlyList<PendingStreamDeletion> List(string storageDirectory)
    {
        string journalDirectory = Path.Combine(storageDirectory, JournalDirectoryName);
        if (!Directory.Exists(journalDirectory))
        {
            return Array.Empty<PendingStreamDeletion>();
        }

        var pending = new List<PendingStreamDeletion>();
        foreach (string path in Directory.EnumerateFiles(journalDirectory, "*.json"))
        {
            JournalEntry? entry;
            try
            {
                entry = JsonSerializer.Deserialize(File.ReadAllBytes(path), JournalContext.Default.JournalEntry);
            }
            catch (Exception exception) when (exception is IOException or JsonException or UnauthorizedAccessException)
            {
                // A torn or unreadable entry is skipped; a later scan retries. Never fabricate absence.
                continue;
            }

            if (entry is null || string.IsNullOrEmpty(entry.TaskId) || entry.InputIds is not { Count: > 0 })
            {
                continue;
            }

            pending.Add(new PendingStreamDeletion(entry.TaskId, entry.InputIds));
        }

        return pending;
    }

    private static string EntryPath(string journalDirectory, string taskId)
        => Path.Combine(journalDirectory, HashKey(taskId) + ".json");

    private static string HashKey(string taskId)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(taskId));
        var builder = new StringBuilder(hash.Length * 2);
        foreach (byte value in hash)
        {
            builder.Append(value.ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
        }

        return builder.ToString();
    }

    internal sealed class JournalEntry
    {
        public string TaskId { get; set; } = string.Empty;
        public List<string> InputIds { get; set; } = new();
    }
}

/// <summary>A task deletion's still-owed stream closures, discovered on restart.</summary>
internal readonly record struct PendingStreamDeletion(string TaskId, IReadOnlyList<string> InputIds);

[System.Text.Json.Serialization.JsonSerializable(typeof(TaskStreamDeletionJournal.JournalEntry))]
[System.Text.Json.Serialization.JsonSourceGenerationOptions(PropertyNamingPolicy = System.Text.Json.Serialization.JsonKnownNamingPolicy.CamelCase)]
internal sealed partial class JournalContext : System.Text.Json.Serialization.JsonSerializerContext
{
}
