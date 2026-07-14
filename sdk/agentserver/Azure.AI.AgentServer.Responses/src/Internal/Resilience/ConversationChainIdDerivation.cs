// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Derives the stable conversation chain identifier
/// (<c>derive_conversation_chain_id</c>, Spec 038).
/// <para>
/// The chain id (which equals the resilient <c>task_id</c>) is shared across every turn of one
/// conversation chain and distinct across unrelated requests. It is a pure function of the
/// persisted inputs so it reconstructs identically on cross-process recovery. Three cases:
/// </para>
/// <list type="number">
/// <item><description><c>conversation_id</c> present → <c>cchain_{partition}{scope}</c>.</description></item>
/// <item><description>steerable, no <c>conversation_id</c> → <c>rchain_{partition(prev||resp)}{scope}</c>.</description></item>
/// <item><description>everything else (one-shot) → the <c>response_id</c> verbatim.</description></item>
/// </list>
/// <para>
/// <c>scope</c> is a deterministic 32-char alphanumeric digest of <c>agent_name</c> +
/// <c>session_id</c> (separated by <c>\x1f</c>, which cannot appear in a DNS agent name so the
/// pair encodes injectively).
/// </para>
/// </summary>
internal static class ConversationChainIdDerivation
{
    private const string ConvChainPrefix = "cchain";
    private const string RespChainPrefix = "rchain";
    private const int ScopeLength = 32;
    private const int PartitionHexLength = 16;
    private const string PartitionSuffix = "00";
    private const char Separator = '\x1f';

    /// <summary>
    /// Derives the stable conversation chain id. See the type summary for the per-case shapes.
    /// </summary>
    /// <param name="conversationId">Explicit conversation scope (highest priority).</param>
    /// <param name="previousResponseId">Chain parent (used when no conversation id).</param>
    /// <param name="responseId">This response's unique id (fallback / one-shot key).</param>
    /// <param name="agentName">Agent identity, for cross-agent scoping.</param>
    /// <param name="sessionId">Session scope identifier.</param>
    /// <param name="steerable">Whether steerable conversations are enabled.</param>
    /// <returns>The stable conversation chain id.</returns>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        string agentName,
        string sessionId,
        bool steerable = true)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));
        agentName ??= string.Empty;
        sessionId ??= string.Empty;

        if (!string.IsNullOrEmpty(conversationId))
        {
            string pk = PartitionKey(conversationId!, agentName, sessionId);
            return $"{ConvChainPrefix}_{pk}{Scope(agentName, sessionId)}";
        }

        if (steerable)
        {
            string sourceId = !string.IsNullOrEmpty(previousResponseId) ? previousResponseId! : responseId;
            string pk = PartitionKey(sourceId, agentName, sessionId);
            return $"{RespChainPrefix}_{pk}{Scope(agentName, sessionId)}";
        }

        // Case 3 — one-shot: the response id is already globally unique + native.
        return responseId;
    }

    private static string PartitionKey(string sourceId, string agentName, string sessionId)
    {
        try
        {
            return IdGenerator.ExtractPartitionKey(sourceId);
        }
        catch (ArgumentException)
        {
            string seed = $"{agentName}{Separator}{sessionId}{Separator}{sourceId}";
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(seed));
            return Convert.ToHexString(hash).ToLowerInvariant()[..PartitionHexLength] + PartitionSuffix;
        }
    }

    private static string Scope(string agentName, string sessionId)
        => DeterministicAlphanumeric($"{agentName}{Separator}{sessionId}", ScopeLength);

    /// <summary>
    /// Returns a deterministic alphanumeric (<c>[A-Za-z0-9]</c>) digest of <paramref name="seed"/>
    /// of the requested length. Mirrors Python <c>_det_alnum</c>: repeatedly SHA-256 hashes
    /// <c>seed:{counter}</c>, base64-encodes, and keeps alphanumeric characters until enough
    /// are collected. Reproducible across turns and recovery.
    /// </summary>
    private static string DeterministicAlphanumeric(string seed, int length)
    {
        var sb = new StringBuilder(length + 16);
        int counter = 0;
        while (sb.Length < length)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes($"{seed}:{counter}"));
            string block = Convert.ToBase64String(hash);
            foreach (char c in block)
            {
                if (char.IsLetterOrDigit(c) && c < 128)
                {
                    sb.Append(c);
                }
            }

            counter++;
        }

        return sb.ToString(0, length);
    }
}
