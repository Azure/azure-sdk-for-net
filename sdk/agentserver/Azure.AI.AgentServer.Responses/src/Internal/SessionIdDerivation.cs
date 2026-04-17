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
/// this helper derives one from the agent identity and conversational context
/// (conversation ID or previous_response_id partition key). If no conversational
/// context is available, a random 63-char hex string is generated.
/// </para>
/// </summary>
internal static class SessionIdDerivation
{
    /// <summary>
    /// Session IDs are 63 lowercase hex characters (one less than a full SHA-256 hex digest).
    /// This matches the cross-language session ID derivation contract.
    /// </summary>
    private const int SessionIdLength = 63;

    private const string DefaultAgentName = "server-default-agent";

    /// <summary>
    /// Derives a session ID from conversational context and agent identity.
    /// </summary>
    /// <param name="conversationId">Conversation ID from the request, if any.</param>
    /// <param name="previousResponseId">Previous response ID from the request, if any.</param>
    /// <param name="agentReference">Agent reference containing name/version, if any.</param>
    /// <returns>A 63-char lowercase hex session ID.</returns>
    public static string Derive(
        string? conversationId,
        string? previousResponseId,
        AgentReference? agentReference)
    {
        // Select partition source: conversation_id first, then previous_response_id
        var partitionSource = !string.IsNullOrEmpty(conversationId) ? conversationId
            : !string.IsNullOrEmpty(previousResponseId) ? previousResponseId
            : null;

        if (partitionSource is not null)
        {
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

        // One-shot: no conversational context → random session
        return GenerateRandomHex();
    }

    /// <summary>
    /// Extracts the agent name and version from an agent reference.
    /// </summary>
    private static (string Name, string Version) ExtractAgentIdentity(AgentReference? agentReference)
    {
        if (agentReference is null)
        {
            return (DefaultAgentName, "");
        }

        var name = agentReference.Name;
        var version = agentReference.Version;
        return (
            string.IsNullOrEmpty(name) ? DefaultAgentName : name,
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

    /// <summary>
    /// Generates a random 63-char lowercase hex string.
    /// </summary>
    private static string GenerateRandomHex()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToHexString(bytes).ToLowerInvariant()[..SessionIdLength];
    }
}
