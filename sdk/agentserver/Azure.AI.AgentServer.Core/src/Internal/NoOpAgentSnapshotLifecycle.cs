// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Internal;

#pragma warning disable AAAS002 // Internal implementation of the experimental snapshot lifecycle contract.
internal sealed class NoOpAgentSnapshotLifecycle : IAgentSnapshotLifecycle
{
    public Task BeforeSnapshotAsync(CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public Task AfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
#pragma warning restore AAAS002
