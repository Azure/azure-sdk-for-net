// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Conversation chain identity (native per-case ids).
/// <para>
/// A conversation chain's identity must be <em>shared</em> across every turn of one
/// conversation and <em>distinct</em> across unrelated requests. What counts as "one chain"
/// gives two cases:
/// <list type="number">
/// <item><c>conversationId</c> present — the chain is the conversation.</item>
/// <item>otherwise — the chain is the <c>previousResponseId</c> linkage (chained response IDs
/// share one partition key; on the first turn the response's own ID seeds it).</item>
/// </list>
/// </para>
/// <para>
/// The id follows the system's <see cref="IdGenerator"/> convention
/// (<c>{prefix}_{partitionKey}{trailer}</c>) so it looks native and embeds the chain's
/// partition key for co-location:
/// <list type="bullet">
/// <item>case 1 — <c>cchain_{partition(conversationId)}{scope}</c></item>
/// <item>case 2 — <c>rchain_{partition(previousResponseId or responseId)}{scope}</c></item>
/// </list>
/// <c>scope</c> is a deterministic 32-char alphanumeric digest of <c>agentName</c> +
/// <c>sessionId</c> (both are too long / too arbitrary to embed, so they are hashed). The
/// digest fills the native "entropy" slot; a <c>\x1f</c> unit separator delimits the two
/// fields. For the expected DNS-style <c>agentName</c> (which contains no control characters),
/// placing it first makes the <c>(agent, session)</c> pair an injective encoding even when
/// <c>sessionId</c> contains arbitrary bytes. The prefix (<c>cchain_</c> vs <c>rchain_</c> vs
/// the response's own <c>caresp_</c>) namespaces the chain kinds so they never collide.
/// </para>
/// <para>
/// <see cref="Derive"/> is exposed to handlers as
/// <see cref="ResponseContext.ConversationChainId"/>.
/// </para>
/// <para>
/// Known limitation: the chain identity is derived from framework-generated IDs. A client
/// that supplies its own response ID / conversation ID carrying a mismatched embedded
/// partition can shift the chain identity for subsequent turns. Likewise, an <c>agentName</c>
/// that contains the <c>\x1f</c> separator (not expected for DNS-style names) would weaken the
/// injective <c>(agent, session)</c> encoding.
/// </para>
/// </summary>
internal static class ChainIdDerivation
{
    /// <summary>Prefix for a conversation-scoped chain id (native <see cref="IdGenerator"/> convention).</summary>
    private const string ConversationChainPrefix = "cchain";

    /// <summary>Prefix for a response-linkage chain id.</summary>
    private const string ResponseChainPrefix = "rchain";

    /// <summary>Width of the deterministic (agent, session) scope trailer, matching the native <see cref="IdGenerator"/> entropy slot.</summary>
    private const int ScopeLength = 32;

    /// <summary>Number of hex characters in the fallback partition key (before the trailing "00").</summary>
    private const int PartitionKeyHexLength = 16;

    /// <summary>Suffix appended to a fallback partition key so it matches the native 18-char format.</summary>
    private const string PartitionKeySuffix = "00";

    /// <summary>
    /// Unit separator — cannot appear in a DNS-style <c>agentName</c>, so placing the
    /// constrained field first makes <c>(agent, session)</c> an injective encoding.
    /// </summary>
    private const char Separator = '\x1f';

    /// <summary>
    /// Derives the stable conversation chain id.
    /// <para>
    /// The id is the same for every turn of a chain. It is a native id (see the type remarks
    /// for the per-case shapes), so it is opaque, charset-constrained, and fixed-length —
    /// suitable as a handler-side correlation key.
    /// </para>
    /// </summary>
    /// <param name="conversationId">Explicit conversation scope (highest priority).</param>
    /// <param name="previousResponseId">Chain parent (used when no conversation ID).</param>
    /// <param name="responseId">This response's unique ID (fallback / one-shot key).</param>
    /// <param name="agentReference">Agent reference containing the name, for cross-agent scoping.</param>
    /// <param name="sessionId">The resolved session scope identifier.</param>
    /// <returns>A stable, native conversation chain id.</returns>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        AgentReference? agentReference,
        string? sessionId)
    {
        var agentName = string.IsNullOrEmpty(agentReference?.Name) ? DerivationDefaults.DefaultAgentName : agentReference!.Name;
        var session = sessionId ?? string.Empty;

        if (!string.IsNullOrEmpty(conversationId))
        {
            var partition = PartitionKey(conversationId!, agentName, session);
            return $"{ConversationChainPrefix}_{partition}{Scope(agentName, session)}";
        }

        var source = !string.IsNullOrEmpty(previousResponseId) ? previousResponseId! : responseId;
        var chainPartition = PartitionKey(source, agentName, session);
        return $"{ResponseChainPrefix}_{chainPartition}{Scope(agentName, session)}";
    }

    /// <summary>
    /// Returns the deterministic <c>(agent, session)</c> scope trailer that fills the native
    /// entropy slot.
    /// </summary>
    private static string Scope(string agentName, string sessionId)
        => DeterministicAlnum($"{agentName}{Separator}{sessionId}", ScopeLength);

    /// <summary>
    /// Returns the 18-char partition key for the chain. For a framework-generated ID the real
    /// embedded partition key is extracted (so the chain co-locates with its responses); for a
    /// value that is not in ID format (e.g. a raw client conversation ID) a partition key is
    /// derived deterministically.
    /// </summary>
    private static string PartitionKey(string sourceId, string agentName, string sessionId)
    {
        try
        {
            var extracted = IdGenerator.ExtractPartitionKey(sourceId);

            // Legacy-format IDs embed a 16-char partition key; new-format IDs embed 18 (16 hex + "00").
            // Normalize a legacy key the same way IdGenerator.NewId does, so a chain that mixes legacy
            // and new-format IDs resolves to one stable partition key.
            return extracted.Length == PartitionKeyHexLength
                ? string.Concat(extracted, PartitionKeySuffix)
                : extracted;
        }
        catch (ArgumentException)
        {
            var seed = $"{agentName}{Separator}{sessionId}{Separator}{sourceId}";
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(seed));
            return string.Concat(Convert.ToHexString(hash).ToLowerInvariant().AsSpan(0, PartitionKeyHexLength), PartitionKeySuffix);
        }
    }

    /// <summary>
    /// Returns a deterministic alphanumeric digest of <paramref name="seed"/> of
    /// <paramref name="length"/> characters. Mirrors <see cref="IdGenerator"/>'s entropy charset
    /// (<c>[A-Za-z0-9]</c>) but is seeded deterministically (SHA-256 of <c>seed:{counter}</c>)
    /// rather than from random bytes, so the resulting id is reproducible across turns.
    /// </summary>
    private static string DeterministicAlnum(string seed, int length)
    {
        var result = new StringBuilder(length);
        var counter = 0;
        while (result.Length < length)
        {
            var digest = SHA256.HashData(Encoding.UTF8.GetBytes($"{seed}:{counter}"));
            var block = Convert.ToBase64String(digest);
            foreach (var c in block)
            {
                if (result.Length >= length)
                {
                    break;
                }

                if (IsAsciiAlphanumeric(c))
                {
                    result.Append(c);
                }
            }

            counter++;
        }

        return result.ToString();
    }

    /// <summary>
    /// Returns whether <paramref name="c"/> is an ASCII letter or digit (<c>[A-Za-z0-9]</c>).
    /// Matches the Base64 characters kept by the deterministic digest, ensuring the value is
    /// identical across language ports.
    /// </summary>
    private static bool IsAsciiAlphanumeric(char c)
        => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
}
