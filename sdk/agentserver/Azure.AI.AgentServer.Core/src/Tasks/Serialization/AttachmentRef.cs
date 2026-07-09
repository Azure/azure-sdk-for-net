// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// A reference that replaces an oversized inline value in a task payload slot.
/// On the wire it is a single-magic-key object:
/// <c>{ "__attachment_ref__": { "key": "&lt;k&gt;", "hash": "sha256:&lt;64 hex&gt;" } }</c>.
/// </summary>
internal sealed class AttachmentRef
{
    /// <summary>The attachment key the ref points at.</summary>
    public string Key { get; }

    /// <summary>The content hash, formatted <c>sha256:&lt;64 lower-case hex&gt;</c>.</summary>
    public string Hash { get; }

    /// <summary>Initializes a new instance of the <see cref="AttachmentRef"/> class.</summary>
    /// <param name="key">The attachment key.</param>
    /// <param name="hash">The content hash, including the <c>sha256:</c> prefix.</param>
    public AttachmentRef(string key, string hash)
    {
        Key = key;
        Hash = hash;
    }

    /// <summary>
    /// Determines whether the supplied node is an attachment ref, per the
    /// protocol's 4-step detection rule (object, exactly one key
    /// <c>__attachment_ref__</c>, value object with both <c>key</c> and <c>hash</c>).
    /// </summary>
    /// <param name="node">The candidate slot value.</param>
    /// <param name="attachmentRef">The parsed ref when detected.</param>
    /// <returns><see langword="true"/> if the node is an attachment ref.</returns>
    public static bool TryParse(JsonNode? node, out AttachmentRef? attachmentRef)
    {
        attachmentRef = null;
        if (node is not JsonObject obj || obj.Count != 1)
        {
            return false;
        }

        if (obj[TaskWireKeys.AttachmentRefMagic] is not JsonObject inner)
        {
            return false;
        }

        var key = (string?)inner[TaskWireKeys.AttachmentRefKey];
        var hash = (string?)inner[TaskWireKeys.AttachmentRefHash];
        if (key is null || hash is null)
        {
            return false;
        }

        attachmentRef = new AttachmentRef(key, hash);
        return true;
    }

    /// <summary>Returns whether the node is an attachment ref.</summary>
    /// <param name="node">The candidate slot value.</param>
    /// <returns><see langword="true"/> if it matches the ref shape.</returns>
    public static bool IsRef(JsonNode? node) => TryParse(node, out _);

    /// <summary>Projects this ref to its JSON object form.</summary>
    /// <returns>A <see cref="JsonObject"/> for the ref.</returns>
    public JsonObject ToJson() => new()
    {
        [TaskWireKeys.AttachmentRefMagic] = new JsonObject
        {
            [TaskWireKeys.AttachmentRefKey] = Key,
            [TaskWireKeys.AttachmentRefHash] = Hash,
        },
    };
}
