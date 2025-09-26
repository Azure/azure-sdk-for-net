// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public class ThreadAndRunOptions
    {
        public PersistentAgentThreadCreationOptions ThreadOptions { get; set; } = null;
        public string OverrideModelName { get; set; } = default;
        public string OverrideInstructions { get; set; } = default;
        public IEnumerable<ToolDefinition> OverrideTools { get; set; } = null;
        public ToolResources ToolResources { get; set; } = null;
        public bool? Stream { get; set; } = null;
        public float? Temperature { get; set; } = null;
        public float? TopP { get; set; } = null;
        public int? MaxPromptTokens { get; set; } = null;
        public int? MaxCompletionTokens { get; set; } = null;
        public Truncation TruncationStrategy { get; set; } = null;
        public BinaryData ToolChoice { get; set; } = null;
        public BinaryData ResponseFormat { get; set; } = null;
        public bool? ParallelToolCalls { get; set; } = null;
        public IReadOnlyDictionary<string, string> Metadata { get; set; } = null;
    }
}
