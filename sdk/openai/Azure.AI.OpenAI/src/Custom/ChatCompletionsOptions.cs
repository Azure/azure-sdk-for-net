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

        /// <summary>
        /// Controls how the model will use provided Functions.
        /// </summary>
        /// <remarks>
        ///     <list type="bullet">
        ///     <item>
        ///         Providing a custom <see cref="FunctionDefinition"/> will request that the model limit its
        ///         completions to function calls for that function.
        ///     </item>
        ///     <item>
        ///         <see cref="FunctionDefinition.Auto"/> represents the default behavior and will allow the model
        ///         to freely select between issuing a stanard completions response or a call to any provided
        ///         function.
        ///     </item>
        ///     <item>
        ///         <see cref="FunctionDefinition.None"/> will request that the model only issue standard
        ///         completions responses, irrespective of provided functions. Note that the function definitions
        ///         provided may still influence the completions content.
        ///     </item>
        ///     </list>
        /// </remarks>
        public FunctionDefinition FunctionCall { get; set; }

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
            Functions = new ChangeTrackingList<FunctionDefinition>();
        }

        /// <inheritdoc cref="ChatCompletionsOptions(IEnumerable{ChatMessage})"/>
        public ChatCompletionsOptions()
            : this(new ChangeTrackingList<ChatMessage>())
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
        }
    }
}
