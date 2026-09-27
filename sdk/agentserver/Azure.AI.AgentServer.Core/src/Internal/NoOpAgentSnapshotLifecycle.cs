// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Internal;

internal sealed class NoOpAgentSnapshotLifecycle : IAgentSnapshotLifecycle
{
    public Task BeforeSnapshotAsync(CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public Task AfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
