// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Assistants;

/// <summary>
/// The update type presented when a streamed event indicates a thread was created.
/// </summary>
public class ThreadUpdate : StreamingUpdate<AssistantThread>
{
    /// <see cref="AssistantThread.Id"/>
    public string Id => Value.Id;
    /// <see cref="AssistantThread.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => Value.Metadata;
    /// <see cref="AssistantThread.CreatedAt"/>
    public DateTimeOffset CreatedAt => Value.CreatedAt;
    /// <see cref="AssistantThread.ToolResources"/>
    public ToolResources ToolResources => Value.ToolResources;

    internal ThreadUpdate(AssistantThread thread) : base(thread, StreamingUpdateReason.ThreadCreated)
    { }

    internal static IEnumerable<StreamingUpdate<AssistantThread>> DeserializeThreadCreationUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        AssistantThread thread = AssistantThread.DeserializeAssistantThread(element, options);
        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => new List<StreamingUpdate<AssistantThread>> { new ThreadUpdate(thread) },
            _ => new List<StreamingUpdate<AssistantThread>> { new StreamingUpdate<AssistantThread>(thread, updateKind) },
        };
    }
}
