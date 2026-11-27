// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Internal;

#pragma warning disable AAAS002 // Internal transport for the experimental snapshot lifecycle contract.
internal interface ISnapshotLifecycleParticipant
{
    bool UsesTransactionalRestore { get; }

    Task ValidateAfterRestoreAsync(
        AgentRestoreContext context,
        IReadOnlyDictionary<string, string?> prospectiveEnvironment,
        CancellationToken cancellationToken);

    Task CancelAfterRestoreValidationAsync();

    Task PrepareAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken);

    IDisposable EnterAfterRestoreCallbackScope();

    Task CompleteAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken);

    Task RollbackAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken);
}
#pragma warning restore AAAS002
