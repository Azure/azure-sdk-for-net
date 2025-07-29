// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public class CreateRunStreamingOptions
    {
        public CreateRunStreamingOptions() { }
        /// <summary> The overridden model name that the Agent should use to run the thread. </summary>
        public string OverrideModelName { get; set; } = default;
        /// <summary> The overridden system instructions that the Agent should use to run the thread. </summary>
        public string OverrideInstructions { get; set; } = default;
        /// <summary>
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </summary>
        public string AdditionalInstructions { get; set; } = default;
        /// <summary> Adds additional messages to the thread before creating the run. </summary>
        public IEnumerable<ThreadMessageOptions> AdditionalMessages { get; set; } = null;
        /// <summary> The overridden list of enabled tools that the Agent should use to run the thread. </summary>
        public IEnumerable<ToolDefinition> OverrideTools { get; set; } = null;
        /// <summary> The overridden tool resources that the Agent should use to run the thread. </summary>
        public ToolResources ToolResources { get; set; } = null;
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        public float? Temperature { get; set; } = null;
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        public float? TopP { get; set; } = null;
        /// <summary>
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </summary>
        public int? MaxPromptTokens { get; set; } = null;
        /// <summary>
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </summary>
        public int? MaxCompletionTokens { get; set; } = null;
        /// <summary> The strategy to use for dropping messages as the context windows moves forward. </summary>
        public Truncation TruncationStrategy { get; set; } = null;
        /// <summary> Controls whether or not and which tool is called by the model. </summary>
        public BinaryData ToolChoice { get; set; } = null;
        /// <summary> Specifies the format that the model must output. </summary>
        public BinaryData ResponseFormat { get; set; } = null;
        /// <summary> If `true` functions will run in parallel during tool use. </summary>
        public bool? ParallelToolCalls { get; set; } = null;
        /// <summary> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; set; } = null;
        /// <summary>
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content`
        /// </summary>
        public IEnumerable<RunAdditionalFieldList> Include { get; set; } = null;
        /// <summary> If specified, function calls defined in tools will be called automatically. </summary>
        public AutoFunctionCallOptions AutoFunctionCallOptions { get; set; } = null;
    }
}
