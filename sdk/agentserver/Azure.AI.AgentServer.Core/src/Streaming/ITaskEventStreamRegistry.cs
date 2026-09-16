// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming.Backings;

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

    // Durable deletion-close journal. A hard task deletion removes the record that would otherwise
    // name the streams still owing an EOF, so the intent is recorded here (before the provider
    // delete) and drained on restart. These are no-ops / empty for non-file-backed backings, whose
    // streams do not survive a process crash.
    void RecordPendingDeletion(string taskId, IReadOnlyCollection<string> inputIds);

    void RemovePendingDeletion(string taskId);

    IReadOnlyList<PendingStreamDeletion> ListPendingDeletions();
}
