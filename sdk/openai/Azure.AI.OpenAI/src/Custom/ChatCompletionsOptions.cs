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
        /// <inheritdoc cref="CompletionsOptions.FrequencyPenalty"/>
        public float? FrequencyPenalty { get; set; }
        /// <inheritdoc cref="CompletionsOptions.LogitBias"/>
        public IDictionary<int, int> LogitBias { get; }
        /// <inheritdoc cref="CompletionsOptions.MaxTokens"/>
        public int? MaxTokens { get; set; }
        /// <summary>
        /// Gets or sets the set of chat messages associated with a chat completions request.
        /// </summary>
        /// <remarks>
        /// This is the full set of chat messages for the history of a conversation between an assistant and user.
        /// Typical usage begins with a chat message for the System role that provides instructions for the behavior
        /// of the assistant followed by alternating messages between the User role and Assistant role.
        /// </remarks>
        public IList<ChatMessage> Messages { get; }
        /// <inheritdoc cref="CompletionsOptions.NucleusSamplingFactor"/>
        [CodeGenMember("TopP")]
        public float? NucleusSamplingFactor { get; set; }
        /// <inheritdoc cref="CompletionsOptions.PresencePenalty"/>
        public float? PresencePenalty { get; set; }
        /// <inheritdoc cref="CompletionsOptions.SnippetCount"/>
        [CodeGenMember("N")]
        public int? SnippetCount { get; set; }
        /// <inheritdoc cref="CompletionsOptions.StopSequences"/>
        public IList<string> Stop { get; }
        /// <inheritdoc cref="CompletionsOptions.Temperature"/>
        public float? Temperature { get; set; }
        /// <inheritdoc cref="CompletionsOptions.User"/>
        public string User { get; set; }

        internal string NonAzureModel { get; set; }

        /// <summary> Initializes a new instance of ChatCompletionsOptions. </summary>
        public ChatCompletionsOptions()
        {
            Messages = new ChangeTrackingList<ChatMessage>();
            LogitBias = new ChangeTrackingDictionary<int, int>();
            Stop = new ChangeTrackingList<string>();
        }

        internal ChatCompletionsOptions(
            IList<ChatMessage> messages,
            int? maxTokens,
            float? temperature,
            float? nucleusSamplingFactor,
            IDictionary<int, int> logitBias,
            string user,
            int? snippetCount,
            IList<string> stop,
            float? presencePenalty,
            float? frequencyPenalty)
        {
            Messages = messages.ToList();
            MaxTokens = maxTokens;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            LogitBias = logitBias;
            User = user;
            SnippetCount = snippetCount;
            Stop = stop.ToList();
            PresencePenalty = presencePenalty;
            FrequencyPenalty = frequencyPenalty;
        }
    }
}
