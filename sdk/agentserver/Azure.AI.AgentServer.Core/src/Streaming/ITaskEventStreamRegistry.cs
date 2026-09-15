// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
}
