// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The update type presented when the status of a run step changes.
/// </summary>
public class RunStepUpdate : StreamingUpdate<RunStep>
{
    internal RunStepUpdate(RunStep runStep, StreamingUpdateReason updateKind)
        : base(runStep, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<RunStep>> DeserializeRunStepUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        RunStep runStep = RunStep.DeserializeRunStep(element, options);
        return updateKind switch
        {
            _ => new List<StreamingUpdate<RunStep>> { new RunStepUpdate(runStep, updateKind) },
        };
    }
}
