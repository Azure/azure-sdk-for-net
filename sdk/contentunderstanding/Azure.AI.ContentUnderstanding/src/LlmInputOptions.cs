// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Options for <see cref="LlmInputHelper.ToLlmInput(AnalysisResult, IDictionary{string, object}, LlmInputOptions)"/>.
    /// </summary>
    public class LlmInputOptions
    {
        /// <summary>
        /// Gets or sets whether to include structured fields in the output. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeFields { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to include markdown content in the output. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeMarkdown { get; set; } = true;
    }
}
