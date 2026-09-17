// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming;

internal interface ITaskEventStreamRegistry
{
    ValueTask<AgentEventStream?> GetTaskStreamAsync(
        string taskId,
        string inputId,
        CancellationToken cancellationToken = default);

    ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(
        string taskId,
        string inputId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// One-shot cold-start cleanup: enumerates persisted task-owned streams and closes (writes the
    /// terminal marker to) each one for which <paramref name="shouldClose"/> returns true, given its
    /// owning <c>(taskId, inputId)</c>. A stream still owned by live/queued work is left open. No-op
    /// for non-persistent backings, whose streams do not survive a process restart.
    /// </summary>
    Task CloseOrphanTaskStreamsAsync(
        Func<string, string, ValueTask<bool>> shouldClose,
        CancellationToken cancellationToken = default);
}
