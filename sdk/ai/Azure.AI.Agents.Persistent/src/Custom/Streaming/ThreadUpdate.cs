// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The update type presented when a streamed event indicates a thread was created.
/// </summary>
public class ThreadUpdate : StreamingUpdate<PersistentAgentThread>
{
    /// <see cref="PersistentAgentThread.Id"/>
    public string Id => Value.Id;
    /// <see cref="PersistentAgentThread.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => Value.Metadata;
    /// <see cref="PersistentAgentThread.CreatedAt"/>
    public DateTimeOffset CreatedAt => Value.CreatedAt;
    /// <see cref="PersistentAgentThread.ToolResources"/>
    public ToolResources ToolResources => Value.ToolResources;

    internal ThreadUpdate(PersistentAgentThread thread) : base(thread, StreamingUpdateReason.ThreadCreated)
    { }

    internal static IEnumerable<StreamingUpdate<PersistentAgentThread>> DeserializeThreadCreationUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        PersistentAgentThread thread = PersistentAgentThread.DeserializePersistentAgentThread(element, options);
        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => new List<StreamingUpdate<PersistentAgentThread>> { new ThreadUpdate(thread) },
            _ => new List<StreamingUpdate<PersistentAgentThread>> { new StreamingUpdate<PersistentAgentThread>(thread, updateKind) },
        };
    }
}
