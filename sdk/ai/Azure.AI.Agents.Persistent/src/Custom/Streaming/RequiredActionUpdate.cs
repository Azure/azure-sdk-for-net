// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The update type presented when the status of a <see cref="ThreadRun"/> has changed to <c>requires_action</c>,
/// indicating that tool output submission or another intervention is needed for the run to continue.
/// </summary>
/// <remarks>
/// Distinct <see cref="RequiredActionUpdate"/> instances will generated for each required action, meaning that
/// parallel function calling will present multiple updates even if the tool calls arrive at the same time.
/// </remarks>
public class RequiredActionUpdate : RunUpdate
{
    /// <inheritdoc cref="RequiredFunctionToolCall.Name"/>
    public string FunctionName => AsFunctionCall?.Name;

    /// <inheritdoc cref="RequiredFunctionToolCall.Arguments"/>
    public string FunctionArguments => AsFunctionCall?.Arguments;

    public string ToolCallId => AsFunctionCall?.Id;

    private RequiredFunctionToolCall AsFunctionCall => _requiredAction as RequiredFunctionToolCall;

    private readonly RequiredAction _requiredAction;

    internal RequiredActionUpdate(ThreadRun run, RequiredAction action)
        : base(run, StreamingUpdateReason.RunRequiresAction)
    {
        _requiredAction = action;
    }

    /// <summary>
    /// Gets the full, deserialized <see cref="ThreadRun"/> instance associated with this streaming required action
    /// update.
    /// </summary>
    /// <returns></returns>
    public ThreadRun GetThreadRun() => Value;

    internal static IEnumerable<RequiredActionUpdate> DeserializeRequiredActionUpdates(JsonElement element)
    {
        ThreadRun run = ThreadRun.DeserializeThreadRun(element);
        List<RequiredActionUpdate> updates = [];
        foreach (RequiredAction action in run.RequiredActions ?? [])
        {
            updates.Add(new(run, action));
        }
        return updates;
    }
}
