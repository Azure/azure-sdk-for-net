// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;

#nullable disable

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This extends constructor support to allow broader combinations of tool call and output as parameters.
 */

public partial class ToolOutput
{
    /// <summary> Initializes a new instance of <see cref="ToolOutput"/>. </summary>
    /// <param name="toolCallId"> The ID of the tool call being resolved, as provided in the tool calls of a required action from a run. </param>
    /// <remarks>
    /// When using this constructor, the <see cref="Output"/> property should be set prior to submission.
    /// </remarks>
    public ToolOutput(string toolCallId) : this()
    {
        ToolCallId = toolCallId;
    }

    /// <summary> Initializes a new instance of <see cref="ToolOutput"/>. </summary>
    /// <param name="toolCallId"> The ID of the tool call being resolved, as provided in the tool calls of a required action from a run. </param>
    /// <param name="output"> The output from the tool to be submitted. </param>
    public ToolOutput(string toolCallId, string output = null) : this()
    {
        ToolCallId = toolCallId;
        Output = output;
    }

    /// <summary> Initializes a new instance of <see cref="ToolOutput"/>. </summary>
    /// <param name="toolCall"> The tool call the output will resolve, as provided in a required action from a run. </param>
    /// <remarks>
    /// When using this constructor, the <see cref="Output"/> property should be set prior to submission.
    /// </remarks>
    public ToolOutput(RequiredToolCall toolCall) : this()
    {
        ToolCallId = toolCall.Id;
    }

    /// <summary> Initializes a new instance of <see cref="ToolOutput"/>. </summary>
    /// <param name="toolCall"> The tool call the output will resolve, as provided in a required action from a run. </param>
    /// <param name="output"> The output from the tool to be submitted. </param>
    /// <remarks>
    /// When using this constructor, the <see cref="Output"/> property should be set prior to submission.
    /// </remarks>
    public ToolOutput(RequiredToolCall toolCall, string output) : this()
    {
        ToolCallId = toolCall.Id;
        Output = output;
    }
}
