// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Represents a streaming update that serves as a keep-alive signal within a sequence of run steps.
/// </summary>
/// <remarks>A KeepAliveUpdate is used to indicate ongoing activity or maintain a connection during streaming
/// operations. It does not contain any run step data and is typically used internally to prevent timeouts or signal
/// liveness in long-running processes.</remarks>
public class KeepAliveUpdate : StreamingUpdate
{
    internal KeepAliveUpdate() : base(StreamingUpdateReason.KeepAlive) { }
    internal static IEnumerable<StreamingUpdate> GetRunSteps()
    {
        return [new KeepAliveUpdate()];
    }
}
