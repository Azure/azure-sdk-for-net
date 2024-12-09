// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Projects;

/// <summary>
/// The update type presented when run step details, including tool call progress, have changed.
/// </summary>
public class RunStepDetailsUpdate : StreamingUpdate
{
    internal readonly RunStepDeltaChunk _delta;
    internal readonly RunStepDeltaToolCall _toolCall;
    private readonly RunStepDeltaMessageCreation _asMessageCreation;
    private readonly RunStepDeltaCodeInterpreterToolCall _asCodeCall;
    private readonly RunStepDeltaFileSearchToolCall _asFileSearchCall;
    private readonly RunStepDeltaFunctionToolCall _asFunctionCall;

    /// <inheritdoc cref="RunStepDeltaChunk.Id"/>
    public string StepId => _delta?.Id;

    /// <inheritdoc cref="RunStepDeltaMessageCreation"/>
    public string CreatedMessageId => _asMessageCreation?.MessageCreation?.MessageId;

    /// <inheritdoc cref="RunStepDeltaToolCall.Id"/>
    public string ToolCallId
        => _asCodeCall?.Id
        ?? _asFileSearchCall?.Id
        ?? _asFunctionCall?.Id
        ?? (_toolCall?.SerializedAdditionalRawData?.TryGetValue("id", out BinaryData idData) == true
            ? idData.ToString()
            : null);

    /// <inheritdoc cref="RunStepDeltaToolCall.Index"/>
    public int? ToolCallIndex => _asCodeCall?.Index ?? _asFileSearchCall?.Index ?? _asFunctionCall?.Index;

    /// <inheritdoc cref="RunStepDeltaCodeInterpreterDetailItemObject.Input"/>
    public string CodeInterpreterInput => _asCodeCall?.CodeInterpreter?.Input;

    /// <inheritdoc cref="RunStepDeltaCodeInterpreterDetailItemObject.Outputs"/>
    public IReadOnlyList<RunStepDeltaCodeInterpreterOutput> CodeInterpreterOutputs
        => _asCodeCall?.CodeInterpreter?.Outputs;

    /// <inheritdoc cref="RunStepDeltaFunction.Name"/>
    public string FunctionName => _asFunctionCall.Function?.Name;

    /// <inheritdoc cref="RunStepDeltaFunction.Arguments"/>
    public string FunctionArguments => _asFunctionCall?.Function?.Arguments;

    /// <inheritdoc cref="RunStepDeltaFunction.Output"/>
    public string FunctionOutput => _asFunctionCall?.Function?.Output;

    internal RunStepDetailsUpdate(
        RunStepDeltaChunk stepDelta,
        RunStepDeltaToolCall toolCall = null)
            : base(StreamingUpdateReason.RunStepUpdated)
    {
        _asMessageCreation = stepDelta?.Delta?.StepDetails as RunStepDeltaMessageCreation;
        _asCodeCall = toolCall as RunStepDeltaCodeInterpreterToolCall;
        _asFileSearchCall = toolCall as RunStepDeltaFileSearchToolCall;
        _asFunctionCall = toolCall as RunStepDeltaFunctionToolCall;
        _delta = stepDelta;
        _toolCall = toolCall;
    }

    internal static IEnumerable<RunStepDetailsUpdate> DeserializeRunStepDetailsUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        RunStepDeltaChunk stepDelta = RunStepDeltaChunk.DeserializeRunStepDeltaChunk(element, options);
        List<RunStepDetailsUpdate> updates = [];
        if (stepDelta?.Delta?.StepDetails is RunStepDeltaMessageCreation)
        {
            updates.Add(new RunStepDetailsUpdate(stepDelta));
        }
        else if (stepDelta?.Delta?.StepDetails is RunStepDeltaToolCallObject toolCalls)
        {
            foreach (RunStepDeltaToolCall toolCall in toolCalls.ToolCalls)
            {
                updates.Add(new RunStepDetailsUpdate(stepDelta, toolCall));
            }
        }
        return updates;
    }
}
