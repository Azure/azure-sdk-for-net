// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Configuration options for the Invocations protocol server.
/// </summary>
public class InvocationsServerOptions
{
    /// <summary>
    /// Gets the allowed browser origins for Invocations WebSocket endpoints.
    /// An empty list (the default) disables origin validation.
    /// </summary>
    /// <remarks>
    /// Entries must be HTTP or HTTPS origins containing only a scheme, host, and optional port,
    /// without a trailing slash. Matching uses the exact scheme, host, and effective port;
    /// scheme and host comparisons are case-insensitive. Wildcards are not supported.
    /// When configured, requests with an invalid or unlisted Origin header receive HTTP 403
    /// before the WebSocket is accepted. Requests without Origin remain allowed for
    /// server-to-server compatibility. Origin validation is not authentication.
    /// Configure this list before the application starts.
    /// </remarks>
    public IList<string> AllowedWebSocketOrigins { get; } = new List<string>();
}
