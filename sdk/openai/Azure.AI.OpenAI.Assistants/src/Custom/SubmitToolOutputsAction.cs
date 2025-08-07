// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants;

public partial class SubmitToolOutputsAction : RequiredAction
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Used to superficially combine function tool calls and their vacuous container type.
     *      Before: toolOutputsAction.SubmitToolOutputs.ToolCalls
     *      After : toolOutputsAction.ToolCalls
     */

    /// <inheritdoc cref="InternalSubmitToolOutputsDetails.ToolCalls"/>
    public IReadOnlyList<RequiredToolCall> ToolCalls => InternalDetails.ToolCalls;

    /// <summary> The details describing tools that should be called to submit tool outputs. </summary>
    internal InternalSubmitToolOutputsDetails InternalDetails { get; }
}
