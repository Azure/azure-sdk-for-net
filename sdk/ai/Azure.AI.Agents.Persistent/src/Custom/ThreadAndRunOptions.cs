// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> Options for creating a thread and immediately starting a run against it. </summary>
    public class ThreadAndRunOptions
    {
        /// <summary> Gets or sets the options for the thread to create. </summary>
        public PersistentAgentThreadCreationOptions ThreadOptions { get; set; } = null;
        /// <summary> Gets or sets the model name to use for the run, overriding the agent's default. </summary>
        public string OverrideModelName { get; set; } = default;
        /// <summary> Gets or sets the system instructions to use for the run, overriding the agent's default. </summary>
        public string OverrideInstructions { get; set; } = default;
        /// <summary> Gets or sets the tools to enable for the run, overriding the agent's default. </summary>
        public IEnumerable<ToolDefinition> OverrideTools { get; set; } = null;
        /// <summary> Gets or sets the tool resources available to the run. </summary>
        public ToolResources ToolResources { get; set; } = null;
        /// <summary> Gets or sets a value indicating whether the run should stream its response. </summary>
        public bool? Stream { get; set; } = null;
        /// <summary> Gets or sets the sampling temperature, between 0 and 2. </summary>
        public float? Temperature { get; set; } = null;
        /// <summary> Gets or sets the nucleus sampling value, where the model considers the top probability mass. </summary>
        public float? TopP { get; set; } = null;
        /// <summary> Gets or sets the maximum number of prompt tokens that may be used over the course of the run. </summary>
        public int? MaxPromptTokens { get; set; } = null;
        /// <summary> Gets or sets the maximum number of completion tokens that may be used over the course of the run. </summary>
        public int? MaxCompletionTokens { get; set; } = null;
        /// <summary> Gets or sets the strategy to use for dropping messages as the context window moves forward. </summary>
        public Truncation TruncationStrategy { get; set; } = null;
        /// <summary> Gets or sets a value controlling which tool is called by the model. </summary>
        public BinaryData ToolChoice { get; set; } = null;
        /// <summary> Gets or sets the format that the model must output. </summary>
        public BinaryData ResponseFormat { get; set; } = null;
        /// <summary> Gets or sets a value indicating whether functions run in parallel during tool use. </summary>
        public bool? ParallelToolCalls { get; set; } = null;
        /// <summary> Gets or sets a set of up to 16 key/value pairs for storing additional structured information. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; set; } = null;
    }
}
