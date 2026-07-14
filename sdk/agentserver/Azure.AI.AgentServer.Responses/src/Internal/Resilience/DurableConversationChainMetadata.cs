// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Durable <see cref="ConversationChainMetadata"/> backed by the Core <see cref="TaskMetadata"/>
/// checkpoint store of the running resilient task. Values written here are buffered in the Core
/// metadata store; <see cref="FlushNamespaceAsync"/> persists them into the durable task record so they
/// survive process crash and recovery — mirroring Python's <c>_DeveloperMetadataFacade</c> when it
/// wraps a <c>TaskMetadata</c> backing (as opposed to the plain in-memory dictionary used by
/// non-resilient contexts).
/// </summary>
/// <remarks>
/// The default namespace (<see cref="ConversationChainMetadata.DefaultNamespaceName"/>) maps to the
/// Core metadata root; every other namespace maps to a Core sibling namespace of the same name.
/// String values are stored as JSON strings so they round-trip byte-for-byte with Python's
/// JSON-serializable metadata values.
/// </remarks>
internal sealed class DurableConversationChainMetadata : ConversationChainMetadata
{
    private readonly TaskMetadata _root;

    public DurableConversationChainMetadata(TaskMetadata root)
    {
        _root = root ?? throw new ArgumentNullException(nameof(root));
    }

    private TaskMetadata Target(string namespaceName)
        => string.Equals(namespaceName, DefaultNamespaceName, StringComparison.Ordinal)
            ? _root
            : _root.Namespace(namespaceName);

    public override void Set(string namespaceName, string key, string value)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        Argument.AssertNotNullOrEmpty(key, nameof(key));
        Argument.AssertNotNull(value, nameof(value));
        RejectReserved(namespaceName, nameof(namespaceName));
        RejectReserved(key, nameof(key));

        Target(namespaceName)[key] = BinaryData.FromObjectAsJson(value);
    }

    public override bool TryGet(string namespaceName, string key, out string? value)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        Argument.AssertNotNullOrEmpty(key, nameof(key));

        value = null;
        if (Target(namespaceName).TryGetValue(key, out BinaryData? raw) && raw is not null)
        {
            value = Decode(raw);
            return true;
        }

        return false;
    }

    public override IReadOnlyDictionary<string, string> GetNamespace(string namespaceName)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));

        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (KeyValuePair<string, BinaryData> pair in Target(namespaceName).ToDictionary())
        {
            var decoded = Decode(pair.Value);
            if (decoded is not null)
            {
                result[pair.Key] = decoded;
            }
        }

        return result;
    }

    internal override Task FlushNamespaceAsync(string namespaceName, CancellationToken cancellationToken = default)
    {
        // Per-namespace isolation: flush ONLY the requested namespace's payload key (Core flushes
        // are per-namespace — each flush PATCHes only its own payload). Mirrors Python's
        // per-namespace flush() which delegates to that namespace's TaskMetadata.flush().
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        return Target(namespaceName).FlushAsync(cancellationToken);
    }

    private static string? Decode(BinaryData raw)
    {
        try
        {
            return JsonSerializer.Deserialize<string>(raw.ToMemory().Span);
        }
        catch (JsonException)
        {
            // A value written directly through the Core metadata store (not as a JSON string) is
            // surfaced verbatim rather than throwing.
            return raw.ToString();
        }
    }
}
