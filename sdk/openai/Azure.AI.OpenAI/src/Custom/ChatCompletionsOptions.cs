// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
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
        [CodeGenMember("N")]
        public int? ChoicesPerPrompt { get; set; }

        /// <inheritdoc cref="CompletionsOptions.FrequencyPenalty"/>
        public float? FrequencyPenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.TokenSelectionBiases"/>
        public IDictionary<int, int> TokenSelectionBiases { get; }

        /// <inheritdoc cref="CompletionsOptions.MaxTokens"/>
        public int? MaxTokens { get; set; }

        /// <summary>
        ///     Gets or sets the set of chat messages associated with a chat completions request.
        /// </summary>
        /// <remarks>
        ///     This is the full set of chat messages for the history of a conversation between an assistant and user.
        ///     Typical usage begins with a chat message for the System role that provides instructions for the
        ///     behavior of the assistant followed by alternating messages between the User role and Assistant role.
        /// </remarks>
        public IList<ChatMessage> Messages { get; }

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

        internal string NonAzureModel { get; set; }

        /// <summary> Initializes a new instance of ChatCompletionsOptions. </summary>
        public ChatCompletionsOptions()
        {
            Messages = new ChangeTrackingList<ChatMessage>();
            TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
            StopSequences = new ChangeTrackingList<string>();
        }

        internal ChatCompletionsOptions(
            IList<ChatMessage> messages,
            int? maxTokens,
            float? temperature,
            float? nucleusSamplingFactor,
            IDictionary<int, int> tokenSelectionBiases,
            string user,
            int? choicesPerPrompt,
            IList<string> stopSequences,
            float? presencePenalty,
            float? frequencyPenalty)
        {
            Messages = messages.ToList();
            MaxTokens = maxTokens;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            TokenSelectionBiases = tokenSelectionBiases;
            User = user;
            ChoicesPerPrompt = choicesPerPrompt;
            StopSequences = stopSequences.ToList();
            PresencePenalty = presencePenalty;
            FrequencyPenalty = frequencyPenalty;
        }
    }
}
