// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        public int? ChoiceCount { get; set; }

        /// <inheritdoc cref="CompletionsOptions.FrequencyPenalty"/>
        public float? FrequencyPenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.MaxTokens"/>
        public int? MaxTokens { get; set; }

        /// <inheritdoc cref="CompletionsOptions.NucleusSamplingFactor"/>
        public float? NucleusSamplingFactor { get; set; }

        /// <inheritdoc cref="CompletionsOptions.PresencePenalty"/>
        public float? PresencePenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.StopSequences"/>
        public IList<string> StopSequences { get; }

        /// <inheritdoc cref="CompletionsOptions.Temperature"/>
        public float? Temperature { get; set; }

        /// <inheritdoc cref="CompletionsOptions.TokenSelectionBiases"/>
        public IDictionary<int, int> TokenSelectionBiases { get; }

        /// <inheritdoc cref="CompletionsOptions.User"/>
        public string User { get; set; }

         /// <summary> A list of functions the model may generate JSON inputs for. </summary>
        public IList<FunctionDefinition> Functions { get; set; }

        private Either<FunctionCallPreset, FunctionName>? _functionCall;
        /// <summary>
        /// Controls how the model responds to function calls. "none" means the model does not call a function,
        /// and responds to the end-user. "auto" means the model can pick between an end-user or calling a function.
        ///  Specifying a particular function via `{"name": "my_function"}` forces the model to call that function.
        ///  "none" is the default when no functions are present. "auto" is the default if functions are present.
        /// </summary>
        public object FunctionCall {
            get
            {
                if (_functionCall.HasValue)
                {
                    return _functionCall.Value.Value;
                }
                return null;
            }
            set
            {
                switch (value)
                {
                    case null:
                        _functionCall = null;
                        break;
                    case FunctionCallPreset preset:
                        _functionCall = preset;
                        break;
                    case FunctionName name:
                        _functionCall = name;
                        break;
                    default:
                        throw new ArgumentException($"FunctionCall must be of type {nameof(FunctionCallPreset)} or {nameof(FunctionName)}");
                }
            }
        }

        internal IDictionary<string, int> InternalStringKeyedTokenSelectionBiases { get; }

        internal string InternalNonAzureModelName { get; set; }

        internal bool? InternalShouldStreamResponse { get; set; }

        /// <summary> Initializes a new instance of ChatCompletionsOptions. </summary>
        /// <param name="messages">
        /// The collection of context messages associated with this chat completions request.
        /// Typical usage begins with a chat message for the System role that provides instructions for
        /// the behavior of the assistant, followed by alternating messages between the User and
        /// Assistant roles.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="messages"/> is null. </exception>
        public ChatCompletionsOptions(IEnumerable<ChatMessage> messages)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            Messages = messages.ToList();
            TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
            StopSequences = new ChangeTrackingList<string>();
        }

        /// <inheritdoc cref="ChatCompletionsOptions(IEnumerable{ChatMessage})"/>
        public ChatCompletionsOptions()
            : this(new ChangeTrackingList<ChatMessage>())
        {
        }
    }
}
