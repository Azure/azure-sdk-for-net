// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal control-flow signal raised by <see cref="ResponseContext.ExitForRecoveryAsync"/> to
/// defer a resilient background response's handler to the next process lifetime's recovery scan
/// instead of failing it. The orchestrator catches this signal, marks the execution deferred, and
/// deliberately skips the pre-terminal persist in finalization so the last checkpoint snapshot is
/// preserved for recovery (FR-036). The acceptance-time recovery entry is retained because the
/// durable status remains non-terminal (<c>in_progress</c>).
/// <para>
/// Mirrors Python's <c>ResponseExitForRecovery(BaseException)</c>. It is never surfaced to the
/// client and is not an error — a handler must not catch it.
/// </para>
/// </summary>
internal sealed class ResponseExitForRecovery : Exception
{
    public ResponseExitForRecovery()
        : base("Response handler deferred for next-lifetime recovery via ExitForRecoveryAsync().")
    {
    }
}
