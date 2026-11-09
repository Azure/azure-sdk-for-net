// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

internal interface ITaskOwnedEventStream
{
    string? TaskId { get; }

    void ValidateOrClaimTask(string taskId);
}
