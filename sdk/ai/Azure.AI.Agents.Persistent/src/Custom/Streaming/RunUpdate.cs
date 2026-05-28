// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The update type presented when the status of a <see cref="ThreadRun"/> has changed.
/// </summary>
public class RunUpdate : StreamingUpdate<ThreadRun>
{
    internal RunUpdate(ThreadRun run, StreamingUpdateReason updateKind) : base(run, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<ThreadRun>> DeserializeRunUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        ThreadRun run = ThreadRun.DeserializeThreadRun(element, options);
        return updateKind switch
        {
            _ => new List<StreamingUpdate<ThreadRun>> { new RunUpdate(run, updateKind) },
        };
    }
}
