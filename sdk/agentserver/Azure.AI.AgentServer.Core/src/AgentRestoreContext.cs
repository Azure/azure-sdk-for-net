// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Describes the session context supplied by the platform after restoring an agent process.
/// </summary>
public sealed class AgentRestoreContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AgentRestoreContext"/> class.
    /// </summary>
    /// <param name="sessionId">The opaque identifier for the session this process will serve.</param>
    /// <param name="restoreId">The opaque identifier for this process materialization.</param>
    /// <param name="sessionEnvironmentOverrides">
    /// The sparse set of process environment values that differ from the captured process.
    /// </param>
    public AgentRestoreContext(
        string sessionId,
        string restoreId,
        IReadOnlyDictionary<string, string>? sessionEnvironmentOverrides = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sessionId);
        ArgumentException.ThrowIfNullOrWhiteSpace(restoreId);

        SessionId = sessionId;
        RestoreId = restoreId;
        SessionEnvironmentOverrides = new ReadOnlyDictionary<string, string>(
            sessionEnvironmentOverrides is null
                ? new Dictionary<string, string>(StringComparer.Ordinal)
                : new Dictionary<string, string>(sessionEnvironmentOverrides, StringComparer.Ordinal));
    }

    /// <summary>
    /// Gets the opaque identifier for the session this process will serve.
    /// </summary>
    public string SessionId { get; }

    /// <summary>
    /// Gets the opaque identifier for this process materialization.
    /// </summary>
    public string RestoreId { get; }

    /// <summary>
    /// Gets the sparse set of process environment values that differ from the captured process.
    /// </summary>
    public IReadOnlyDictionary<string, string> SessionEnvironmentOverrides { get; }
}
