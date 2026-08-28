// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Shared defaults for the deterministic session- and chain-id derivation helpers.
/// </summary>
internal static class DerivationDefaults
{
    /// <summary>
    /// Agent name used when the request does not carry an explicit agent name.
    /// </summary>
    public const string DefaultAgentName = "server-default-agent";
}
