// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Resolves the on-disk locations the local (non-hosted) resilient Responses provider uses for
/// durable state. Mirrors the Core provider convention: a single shared state root
/// (<c>~/.agentserver</c>, overridable via the <c>AGENTSERVER_STATE_ROOT</c> environment variable)
/// with responses living under a <c>responses/</c> sub-directory alongside <c>tasks/</c> and
/// <c>streams/</c>, so all durable agent-server state is inspectable under one predictable root.
/// </summary>
internal static class ResponsesStatePaths
{
    private const string StateRootEnvVar = "AGENTSERVER_STATE_ROOT";

    /// <summary>Resolves the shared state root (<c>~/.agentserver</c> or <c>AGENTSERVER_STATE_ROOT</c>).</summary>
    public static string StateRoot()
        => System.Environment.GetEnvironmentVariable(StateRootEnvVar) is { Length: > 0 } env
            ? env
            : Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), ".agentserver");

    /// <summary>Resolves the <c>responses</c> storage root under the shared state root.</summary>
    public static string ResponsesRoot() => Path.Combine(StateRoot(), "responses");

    /// <summary>
    /// Resolves the <c>responses/recovery</c> directory that holds acceptance-time recovery
    /// entries (one fail-closed <see cref="ResponseRecoveryPayload"/> per background response).
    /// The next process lifetime scans this directory to re-invoke or fail interrupted work.
    /// </summary>
    public static string RecoveryRoot() => Path.Combine(ResponsesRoot(), "recovery");

    /// <summary>
    /// Resolves the <c>responses/streams</c> directory that holds durable SSE event-stream replay
    /// files (one per background response) written by the Core file-backed event-stream registry.
    /// A reconnecting client replays pre-restart events from here after a single-sandbox recovery.
    /// </summary>
    public static string StreamsRoot() => Path.Combine(ResponsesRoot(), "streams");
}
