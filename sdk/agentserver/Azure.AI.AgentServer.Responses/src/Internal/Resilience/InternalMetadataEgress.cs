// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Strips framework-reserved internal metadata from a response/item payload immediately before
/// it reaches the client wire. Implements <c>strip_internal_metadata</c>.
/// <para>
/// Two reserved keys are persisted to the store (so they survive crashes and are available on
/// recovery) but MUST NEVER reach the client:
/// </para>
/// <list type="number">
/// <item><description>
/// <c>internal_metadata</c> — an item-level bag present on any object in the payload tree. It is
/// removed from every object recursively.
/// </description></item>
/// <item><description>
/// <c>_internal_metadata</c> — a response-level entry inside the <c>metadata</c> map. It is
/// removed from <c>metadata</c>; if that leaves <c>metadata</c> empty, <c>metadata</c> is
/// normalized to JSON <c>null</c>.
/// </description></item>
/// </list>
/// <para>
/// The operation is fail-closed and mutates the provided node in place: the caller passes a
/// safe-to-mutate copy (e.g., from a model's serialized form). A <see langword="null"/> or
/// non-object node is returned unchanged.
/// </para>
/// </summary>
internal static class InternalMetadataEgress
{
    /// <summary>The item-level reserved bag key (stripped from every object in the tree).</summary>
    public const string ItemInternalMetadataKey = "internal_metadata";

    /// <summary>The response-level reserved key inside the <c>metadata</c> map.</summary>
    public const string ResponseInternalMetadataKey = "_internal_metadata";

    /// <summary>The response-level metadata map property name.</summary>
    public const string MetadataKey = "metadata";

    /// <summary>
    /// Strips reserved internal-metadata keys from the payload in place and returns it. Safe to
    /// call on any node; non-object roots are returned unchanged.
    /// </summary>
    /// <param name="payload">The payload node to sanitize (mutated in place).</param>
    /// <returns>The same node, sanitized.</returns>
    public static JsonNode? Strip(JsonNode? payload)
    {
        if (payload is not JsonObject root)
        {
            return payload;
        }

        // 1) Recursively strip item-level `internal_metadata` from every object in the tree.
        StripItemInternalMetadataRecursive(root);

        // 2) Strip response-level `_internal_metadata` from the top-level `metadata` map and
        //    normalize an emptied map to null.
        if (root[MetadataKey] is JsonObject metadata)
        {
            metadata.Remove(ResponseInternalMetadataKey);
            if (metadata.Count == 0)
            {
                root[MetadataKey] = null;
            }
        }

        return root;
    }

    private static void StripItemInternalMetadataRecursive(JsonNode? node)
    {
        switch (node)
        {
            case JsonObject obj:
                obj.Remove(ItemInternalMetadataKey);

                // Snapshot values first: removing keys while enumerating is unsafe.
                foreach (var child in obj.Select(kvp => kvp.Value).ToArray())
                {
                    StripItemInternalMetadataRecursive(child);
                }

                break;

            case JsonArray array:
                foreach (var element in array)
                {
                    StripItemInternalMetadataRecursive(element);
                }

                break;
        }
    }
}
