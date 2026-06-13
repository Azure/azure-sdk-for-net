// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Canonicalizes user-supplied agent keys into the form used as an environment-variable
/// suffix (uppercase, hyphens replaced with underscores, ASCII-only).
/// </summary>
/// <remarks>
/// Multi-agent env vars follow the convention
/// <c>OPTIMIZATION_&lt;VAR&gt;__&lt;CANONICAL_KEY&gt;</c>, e.g. <c>"triage-agent"</c> ⇒
/// <c>"TRIAGE_AGENT"</c> ⇒ <c>OPTIMIZATION_CANDIDATE_ID__TRIAGE_AGENT</c>. The
/// double-underscore separator matches Microsoft.Extensions.Configuration's section
/// separator and avoids collisions with hyphenated agent keys after canonicalization.
/// </remarks>
public static class AgentKeyCanonicalizer
{
    /// <summary>
    /// Canonicalizes <paramref name="agentKey"/> into the form used as an env-var suffix.
    /// Returns <c>null</c> when the key is invalid (empty, or contains characters that
    /// cannot be canonicalized into <c>[A-Z0-9_]</c>).
    /// </summary>
    public static string TryCanonicalize(string agentKey)
    {
        if (string.IsNullOrWhiteSpace(agentKey))
        {
            return null;
        }

        var buffer = new char[agentKey.Length];
        for (int i = 0; i < agentKey.Length; i++)
        {
            char c = agentKey[i];

            if (c == '-' || c == '_')
            {
                buffer[i] = '_';
            }
            else if ((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
            {
                buffer[i] = c;
            }
            else if (c >= 'a' && c <= 'z')
            {
                buffer[i] = char.ToUpperInvariant(c);
            }
            else
            {
                return null;
            }
        }

        return new string(buffer);
    }

    /// <summary>
    /// Canonicalizes <paramref name="agentKey"/>, throwing when invalid.
    /// </summary>
    public static string Canonicalize(string agentKey, string paramName)
    {
        string canonical = TryCanonicalize(agentKey);
        if (canonical is null)
        {
            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture,
                    "Agent key '{0}' is invalid. Allowed characters: letters, digits, hyphen, underscore.",
                    agentKey ?? "<null>"),
                paramName);
        }

        return canonical;
    }
}
