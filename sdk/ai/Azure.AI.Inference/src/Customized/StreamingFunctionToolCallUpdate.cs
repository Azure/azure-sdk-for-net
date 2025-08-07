// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference
{
    /// <summary>
    /// Represents an incremental update to a streaming function tool call that is part of a streaming chat completions
    /// choice.
    /// </summary>
    public partial class StreamingFunctionToolCallUpdate : StreamingToolCallUpdate
    {
        // CUSTOM CODE NOTE:
        //   This is an entirely custom-code-only type created to handle tool call details within a streaming chat
        //   completions response.

        /// <summary>
        /// The name of the function requested by the tool call.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].delta.tool_calls[0].function.name in the REST API schema.
        /// </para>
        /// <para>
        /// For a streaming function tool call, this name will appear in a single streaming update payload, typically the
        /// first. Use the <see cref="StreamingToolCallUpdate.ToolCallIndex"/> property to differentiate between multiple,
        /// parallel tool calls when streaming.
        /// </para>
        /// </remarks>
        public string Name { get; }

        /// <summary>
        /// The next new segment of the function arguments for the function tool called by a streaming tool call.
        /// These must be accumulated for the complete contents of the function arguments.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].delta.tool_calls[0].function.arguments in the REST API schema.
        /// </para>
        /// Note that the model does not always generate valid JSON and may hallucinate parameters
        /// not defined by your function schema. Validate the arguments in your code before calling
        /// your function.
        /// </remarks>
        public string ArgumentsUpdate { get; }

        internal StreamingFunctionToolCallUpdate(
            string id,
            int toolCallIndex,
            string functionName,
            string functionArgumentsUpdate)
            : base("function", id, toolCallIndex)
        {
            Name = functionName;
            ArgumentsUpdate = functionArgumentsUpdate;
        }
    }
}
