// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Configuration for interim responses using AI-generated content from a language model.
    /// These responses provide contextually appropriate user feedback during delays in voice interactions.
    /// </summary>
    public class LlmInterimResponseConfig : InterimResponseConfigBase
    {
        /// <summary>
        /// Gets or sets the language model to use for generating interim responses.
        /// For example: "gpt-4", "gpt-4-mini", etc.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the instructions that guide the language model in generating appropriate interim responses.
        /// These instructions should specify the tone, style, and content constraints for the responses.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of tokens the language model can use when generating interim responses.
        /// This helps control the length and cost of generated responses.
        /// </summary>
        public int? MaxCompletionTokens { get; set; }
    }
}