// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// Helpers for reading wire values leniently, matching the dynamically typed
/// Python implementation which stores whatever the Task Storage service returns.
/// </summary>
/// <remarks>
/// The Foundry Task Storage protocol declares all timestamp fields (lease
/// <c>expires_at</c>/<c>heartbeat_at</c>, record <c>created_at</c>/<c>updated_at</c>/
/// <c>started_at</c>/<c>completed_at</c>) as ISO-8601 strings, but a hosted service
/// has been observed serializing them as JSON numbers (epoch). The framework never
/// interprets these timestamps on the hosted path — the server owns lease arithmetic
/// — so the parser must accept either representation rather than throwing when a
/// direct <c>(string?)</c> cast hits a JSON Number.
/// </remarks>
internal static class WireValue
{
    /// <summary>
    /// Reads a JSON node as a string regardless of its underlying JSON kind. A JSON
    /// string is returned verbatim; a number or boolean is returned as its literal
    /// text (e.g. <c>1784003571</c>); an absent or explicit-null node returns
    /// <see langword="null"/>.
    /// </summary>
    /// <param name="node">The JSON node to read, or <see langword="null"/>.</param>
    /// <returns>The coerced string value, or <see langword="null"/>.</returns>
    public static string? AsString(JsonNode? node)
    {
        if (node is not JsonValue value)
        {
            return null;
        }

        // Fast path: the value is already a JSON string.
        if (value.TryGetValue<string>(out var s))
        {
            return s;
        }

        // Otherwise it is a number/boolean. ToJsonString() emits the canonical literal
        // without surrounding quotes for non-string values (e.g. 1784003571, true), so a
        // numeric timestamp survives as its decimal text. This works for both
        // JsonElement-backed values (parsed from the wire — the production path) and
        // CLR-backed values, and never throws.
        return value.ToJsonString();
    }

    /// <summary>
    /// Reads a JSON node as a string, substituting <see cref="string.Empty"/> when
    /// the node is absent or null. See <see cref="AsString"/> for coercion rules.
    /// </summary>
    /// <param name="node">The JSON node to read, or <see langword="null"/>.</param>
    /// <returns>The coerced string value, or <see cref="string.Empty"/>.</returns>
    public static string AsStringOrEmpty(JsonNode? node) => AsString(node) ?? string.Empty;
}
