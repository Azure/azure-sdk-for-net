// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// The configuration information used for a chat completions request.
    /// </summary>
    public partial class ChatCompletionsOptions
    {
        /// <inheritdoc cref="CompletionsOptions.ChoicesPerPrompt"/>
        public int? ChoicesPerPrompt { get; set; }

        /// <inheritdoc cref="CompletionsOptions.FrequencyPenalty"/>
        public float? FrequencyPenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.TokenSelectionBiases"/>
        public IDictionary<int, int> TokenSelectionBiases
        {
            get
            {
                var convertedDictionary = new Dictionary<int, int>();
                foreach (KeyValuePair<string, int> pair in InternalStringKeyedTokenSelectionBiases)
                {
                    convertedDictionary.Add(int.Parse(pair.Key, CultureInfo.InvariantCulture.NumberFormat), pair.Value);
                }
                return convertedDictionary;
            }
        }

        /// <inheritdoc cref="CompletionsOptions.MaxTokens"/>
        public int? MaxTokens { get; set; }

        /// <inheritdoc cref="CompletionsOptions.NucleusSamplingFactor"/>
        [CodeGenMember("TopP")]
        public float? NucleusSamplingFactor { get; set; }

        /// <inheritdoc cref="CompletionsOptions.PresencePenalty"/>
        public float? PresencePenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.StopSequences"/>
        public IList<string> StopSequences { get; }

        /// <inheritdoc cref="CompletionsOptions.Temperature"/>
        public float? Temperature { get; set; }

        /// <inheritdoc cref="CompletionsOptions.User"/>
        public string User { get; set; }

        internal IDictionary<string, int> InternalStringKeyedTokenSelectionBiases { get; }

        internal string InternalNonAzureModelName { get; set; }

        internal bool? InternalShouldStreamResponse { get; set; }
    }
}
