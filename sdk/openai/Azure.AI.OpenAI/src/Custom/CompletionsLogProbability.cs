// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> LogProbs model within completion choice. </summary>
    [CodeGenModel("CompletionsLogProbs")]
    public partial class CompletionsLogProbability
    {
        /// <summary> Log Probability of Tokens. </summary>
        [CodeGenMember("TokenLogprobs")]
        public IReadOnlyList<float> TokenLogProbability { get; }
        /// <summary> Top Log Probabilities. </summary>
        [CodeGenMember("TopLogprobs")]
        public IReadOnlyList<IDictionary<string, float>> TopLogProbability { get; }
    }
}
