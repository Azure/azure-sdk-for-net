// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> Model factory for models. </summary>
    public static partial class AzureOpenAIModelFactory
    {
        /// <summary> Initializes a new instance of Choice. </summary>
        /// <param name="text"> The generated text for a given completions prompt. </param>
        /// <param name="index"> The ordered index associated with this completions choice. </param>
        /// <param name="logProbabilityModel"> The log probabilities model for tokens associated with this completions choice. </param>
        /// <param name="finishReason"> Reason for finishing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        /// <returns> A new <see cref="OpenAI.Choice"/> instance for mocking. </returns>
        public static Choice Choice(string text = null, int index = default, CompletionsLogProbabilityModel logProbabilityModel = null, CompletionsFinishReason finishReason = default)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            // Custom code: remove inappropriate null check of nullable CompletionsLogProbabilityModel

            return new Choice(text, index, logProbabilityModel, finishReason);
        }

        /// <summary> Initializes a new instance of ChatChoice. </summary>
        /// <param name="index"> The ordered index associated with this chat completions choice. </param>
        /// <param name="finishReason"> The reason that this chat completions choice completed its generated. </param>
        /// <returns> A new <see cref="OpenAI.ChatChoice"/> instance for mocking. </returns>
        public static ChatChoice ChatChoice(int index = default, CompletionsFinishReason finishReason = default)
        {
            return new ChatChoice(index, finishReason);
        }

        /// <summary> Initializes a new instance of ChatChoice. </summary>
        /// <param name="message"> The chat message for a given chat completions prompt. </param>
        /// <param name="index"> The ordered index associated with this chat completions choice. </param>
        /// <param name="reason"> The reason that this chat completions choice completed its generated. </param>
        /// <returns> A new <see cref="OpenAI.ChatChoice"/> instance for mocking. </returns>
        public static ChatChoice ChatChoice(ChatMessage message = null, int index = default, CompletionsFinishReason reason = default)
        {
            return new ChatChoice(message, index, reason, null);
        }

        /// <summary> Initializes a new instance of ChatCompletions. </summary>
        /// <param name="id"> A unique identifier associated with this chat completions response. </param>
        /// <param name="created"> The first timestamp associated with generation activity for this completions response. </param>
        /// <param name="choices"> The collection of completions choices associated with this completions response. </param>
        /// <param name="usage"> Usage information for tokens processed and generated as part of this completions operation. </param>
        /// <returns> A new <see cref="OpenAI.ChatCompletions"/> instance for mocking. </returns>
        public static ChatCompletions ChatCompletions(string id = null, DateTimeOffset created = default(DateTimeOffset), IEnumerable<ChatChoice> choices = null, CompletionsUsage usage = null)
        {
            choices ??= new List<ChatChoice>();
            usage ??= AIOpenAIModelFactory.CompletionsUsage();

            long constrainedUnixTimeInSec = Math.Max(
                Math.Min(created.ToUnixTimeSeconds(), int.MaxValue),
                int.MinValue);

            return new ChatCompletions(
                id: id ?? string.Empty,
                internalCreatedSecondsAfterUnixEpoch: (int)constrainedUnixTimeInSec,
                choices: choices,
                usage: usage);
        }
    }
}
