// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Conversation chain identity.
/// <para>
/// A conversation's stable identity is the <em>partition key</em> embedded in its
/// response IDs. IDs have the shape <c>{prefix}_{partitionKey}{entropy}</c>; when a
/// response ID is generated it inherits the partition key of its
/// <c>previousResponseId</c> / <c>conversationId</c> hint (see <see cref="IdGenerator"/>).
/// So every response in a chain carries the <em>same</em> embedded partition key, and
/// extracting it yields a value that is stable across every turn of the chain.
/// </para>
/// <para>
/// <see cref="Derive"/> is the foundational concept here — the agent/session-scoped hash
/// of that partition, exposed to handlers as <see cref="ResponseContext.ConversationChainId"/>.
/// </para>
/// <para>
/// Known limitation: the chain identity is derived from framework-generated IDs. A client
/// that supplies its own response ID carrying a mismatched embedded partition can shift the
/// chain identity for subsequent turns.
/// </para>
/// </summary>
internal static class ChainIdDerivation
{
    /// <summary>
    /// Length of the hex digest used for the chain id (and therefore the task id).
    /// </summary>
    private const int ChainIdHexLength = 32;

    private const string DefaultAgentName = "server-default-agent";

    /// <summary>
    /// Derives the stable, agent/session-scoped conversation chain id.
    /// <para>
    /// The id is the same for every turn of a conversation chain. It is a hex digest, so it
    /// is opaque and fixed-length — suitable as a handler-side correlation key.
    /// </para>
    /// </summary>
    /// <param name="conversationId">Explicit conversation scope (highest priority).</param>
    /// <param name="previousResponseId">Chain parent (used when no conversation ID).</param>
    /// <param name="responseId">This response's unique ID (fallback / fork key).</param>
    /// <param name="agentReference">Agent reference containing the name, for cross-agent scoping.</param>
    /// <param name="sessionId">The resolved session scope identifier.</param>
    /// <param name="steerable">Whether steerable conversations are enabled.</param>
    /// <returns>A stable hex chain id.</returns>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        AgentReference? agentReference,
        string? sessionId,
        bool steerable = true)
    {
        var (discriminator, partition) = ChainPartition(conversationId, previousResponseId, responseId, steerable);

        var agentName = string.IsNullOrEmpty(agentReference?.Name) ? DefaultAgentName : agentReference!.Name;
        var composite = $"{agentName}:{sessionId ?? string.Empty}:{discriminator}:{partition}";

        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(composite));
        return Convert.ToHexString(hashBytes).ToLowerInvariant()[..ChainIdHexLength];
    }

    /// <summary>
    /// Resolves the <c>(discriminator, partition)</c> that identifies the chain.
    /// <para>
    /// Priority:
    /// <list type="number">
    /// <item><c>conversationId</c> — explicit conversation scope (extract its partition key, or use it raw when not in ID format).</item>
    /// <item><c>steerable</c> — the sequential chain shares one identity: extract the partition key from <c>previousResponseId</c> (or <c>responseId</c> on the first turn).</item>
    /// <item>otherwise (non-steerable) — each request is its own fork; the FULL <c>responseId</c> (entropy included) keeps concurrent forks distinct.</item>
    /// </list>
    /// The discriminator namespaces the partition by source type so that, e.g., a client-supplied
    /// <c>conversationId</c> cannot collide with an extracted partition key or a response id.
    /// </para>
    /// </summary>
    private static (string Discriminator, string Partition) ChainPartition(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        bool steerable)
    {
        if (!string.IsNullOrEmpty(conversationId))
        {
            return ("conv", ExtractPartitionOrRaw(conversationId!));
        }

        if (steerable)
        {
            var source = !string.IsNullOrEmpty(previousResponseId) ? previousResponseId! : responseId;
            return ("chain", ExtractPartitionOrRaw(source));
        }

        // Non-steerable: keep parallel forks distinct via the full response_id.
        var discriminator = !string.IsNullOrEmpty(previousResponseId) ? "fork" : "resp";
        return (discriminator, responseId);
    }

    /// <summary>
    /// Extracts the embedded partition key from <paramref name="idValue"/>, or returns it
    /// unchanged. Framework-generated IDs carry an embedded partition key that is shared across
    /// a chain; values not in the ID format (e.g. a raw conversation ID) have no embedded key —
    /// they are themselves the stable identity, so they are returned as-is.
    /// </summary>
    private static string ExtractPartitionOrRaw(string idValue)
    {
        try
        {
            return IdGenerator.ExtractPartitionKey(idValue);
        }
        catch (ArgumentException)
        {
            return idValue;
        }
    }
}
