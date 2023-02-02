// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI.Models
{
    public partial class CompletionsOptions
    {
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the
        /// model considers the results of the tokens with top_p probability mass. So 0.1
        /// means only the tokens comprising the top 10% probability mass are
        /// considered.
        /// We generally recommend using this or `temperature` but not
        /// both.
        /// Minimum of 0 and maximum of 1 allowed.
        ///
        /// </summary>
        [CodeGenMember("TopP")]
        public float? NucleusSamplingFactor { get; set; }
        /// <summary>
        /// How many snippets to generate for each prompt. Minimum of 1 and maximum of 128
        /// allowed.
        /// </summary>
        [CodeGenMember("N")]
        public int? SnippetCount { get; set; }
        /// <summary>
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the
        /// chosen tokens. So for example, if `logprobs` is 10, the API will return a list
        /// of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will
        /// have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        /// </summary>
        [CodeGenMember("Logprobs")]
        public int? LogProbability { get; set; }
        /// <summary>
        /// How many generations to create server side, and display only the best. Will not
        /// stream intermediate progress if best_of &gt; 1. Has maximum value of 128.
        /// </summary>
        [CodeGenMember("BestOf")]
        public int? GenerationSampleCount { get; set; }
    }
}
