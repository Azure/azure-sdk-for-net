// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// The representation of a single prompt completion as part of an overall completions request.
    /// Generally, `n` choices are generated per provided prompt with a default value of 1.
    /// Token limits and other settings may limit the number of choices generated.
    /// </summary>
    public partial class Choice
    {
        /// <summary> Initializes a new instance of Choice. </summary>
        /// <param name="text"> The generated text for a given completions prompt. </param>
        /// <param name="index"> The ordered index associated with this completions choice. </param>
        /// <param name="logProbabilityModel"> The log probabilities model for tokens associated with this completions choice. </param>
        /// <param name="finishReason"> Reason for finishing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        internal Choice(string text, int index, CompletionsLogProbabilityModel logProbabilityModel, CompletionsFinishReason finishReason)
        {
            Argument.AssertNotNull(text, nameof(text));
            // CUSTOM: pending codegen update for non-optional nullables, this needs to be manually
            //          allowed to be null.
            // Argument.AssertNotNull(logProbabilityModel, nameof(logProbabilityModel));

            Text = text;
            Index = index;
            LogProbabilityModel = logProbabilityModel;
            FinishReason = finishReason;
        }
    }
}
