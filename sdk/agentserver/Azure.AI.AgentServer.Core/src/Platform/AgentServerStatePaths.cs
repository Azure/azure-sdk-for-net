// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Resolves the on-disk locations the local (non-hosted) agent-server providers use for
/// durable state. All providers share a single state root — <c>~/.agentserver</c>, overridable
/// via the <c>AGENTSERVER_STATE_ROOT</c> environment variable — so tasks and streams live side by
/// side under one predictable, inspectable directory.
/// </summary>
internal static class AgentServerStatePaths
{
    private const string StateRootEnvVar = "AGENTSERVER_STATE_ROOT";

    /// <summary>Resolves the shared state root (<c>~/.agentserver</c> or <c>AGENTSERVER_STATE_ROOT</c>).</summary>
    public static string StateRoot()
        => Environment.GetEnvironmentVariable(StateRootEnvVar) is { Length: > 0 } env
            ? env
            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".agentserver");

    /// <summary>Resolves the <c>tasks</c> storage root under the shared state root.</summary>
    public static string TasksRoot() => Path.Combine(StateRoot(), "tasks");

    /// <summary>Resolves the <c>streams</c> storage root under the shared state root.</summary>
    public static string StreamsRoot() => Path.Combine(StateRoot(), "streams");
}
