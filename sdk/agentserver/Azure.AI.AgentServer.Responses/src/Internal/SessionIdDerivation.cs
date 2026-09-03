// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Deterministic session ID derivation per B39 specification.
/// <para>
/// When the request payload and environment do not supply an explicit session ID,
/// this helper derives one from the agent identity and conversational context — the
/// conversation ID, the previous_response_id, or (on the first turn) this response's own
/// ID. Because a chained response inherits its parent's partition key, every turn of a
/// chain resolves to the same partition and therefore the same session ID, so the value
/// is stable from the very first turn onward.
/// </para>
/// </summary>
internal static class SessionIdDerivation
{
    /// <summary>
    /// Session IDs are 63 lowercase hex characters (one less than a full SHA-256 hex digest).
    /// This matches the cross-language session ID derivation contract.
    /// </summary>
    private const int SessionIdLength = 63;

    /// <summary>
    /// Derives a session ID from conversational context and agent identity.
    /// </summary>
    /// <param name="conversationId">Conversation ID from the request, if any.</param>
    /// <param name="previousResponseId">Previous response ID from the request, if any.</param>
    /// <param name="responseId">This response's own ID, used as the first-turn fallback partition source.</param>
    /// <param name="agentReference">Agent reference containing name/version, if any.</param>
    /// <returns>A 63-char lowercase hex session ID.</returns>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        string responseId,
        AgentReference? agentReference)
    {
        // Select partition source: conversation_id → previous_response_id → this response's own ID.
        var partitionSource = !string.IsNullOrEmpty(conversationId) ? conversationId!
            : !string.IsNullOrEmpty(previousResponseId) ? previousResponseId!
            : responseId;

        string partitionHint;
        try
        {
            partitionHint = IdGenerator.ExtractPartitionKey(partitionSource);
        }
        catch (ArgumentException)
        {
            // If partition key extraction fails, use the raw source as-is
            partitionHint = partitionSource;
        }

        var (agentName, agentVersion) = ExtractAgentIdentity(agentReference);
        var seed = $"{agentName}:{agentVersion}:{partitionHint}";
        return ComputeHexHash(seed);
    }

    /// <summary>
    /// Extracts the agent name and version from an agent reference.
    /// </summary>
    private static (string Name, string Version) ExtractAgentIdentity(AgentReference? agentReference)
    {
        if (agentReference is null)
        {
            return (DerivationDefaults.DefaultAgentName, "");
        }

        var name = agentReference.Name;
        var version = agentReference.Version;
        return (
            string.IsNullOrEmpty(name) ? DerivationDefaults.DefaultAgentName : name,
            version ?? ""
        );
    }

    /// <summary>
    /// SHA-256 hashes a string and returns the first 63 lowercase hex characters.
    /// </summary>
    private static string ComputeHexHash(string value)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
        return Convert.ToHexString(hashBytes).ToLowerInvariant()[..SessionIdLength];
    }
}
