// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.AI.Projects;

/// <summary>
/// The update type presented when a streamed event indicates a thread was created.
/// </summary>
public class ThreadUpdate : StreamingUpdate<AgentThread>
{
    /// <see cref="AgentThread.Id"/>
    public string Id => Value.Id;
    /// <see cref="AgentThread.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => Value.Metadata;
    /// <see cref="AgentThread.CreatedAt"/>
    public DateTimeOffset CreatedAt => Value.CreatedAt;
    /// <see cref="AgentThread.ToolResources"/>
    public ToolResources ToolResources => Value.ToolResources;

    internal ThreadUpdate(AgentThread thread) : base(thread, StreamingUpdateReason.ThreadCreated)
    { }

    internal static IEnumerable<StreamingUpdate<AgentThread>> DeserializeThreadCreationUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        AgentThread thread = AgentThread.DeserializeAgentThread(element, options);
        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => new List<StreamingUpdate<AgentThread>> { new ThreadUpdate(thread) },
            _ => new List<StreamingUpdate<AgentThread>> { new StreamingUpdate<AgentThread>(thread, updateKind) },
        };
    }
}
