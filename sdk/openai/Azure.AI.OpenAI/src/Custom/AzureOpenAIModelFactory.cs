// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> Model factory for models. </summary>
    [CodeGenModel("AIOpenAIModelFactory")]
    public static partial class AzureOpenAIModelFactory
    {
        /// <summary> Initializes a new instance of ChatChoice. </summary>
        /// <param name="message"> The chat message associated with this chat completions choice. </param>
        /// <param name="index"> The ordered index associated with this chat completions choice. </param>
        /// <param name="finishReason"> The reason that this chat completions choice completed its generated. </param>
        /// <param name="deltaMessage"> For streamed choices, the internal representation of a 'delta' payload. </param>
        /// <param name="contentFilterResults"> The category annotations for this chat choice's content filtering. </param>
        /// <returns> A new <see cref="OpenAI.ChatChoice"/> instance for mocking. </returns>
        public static ChatChoice ChatChoice(
            ChatMessage message = null,
            int index = default,
            CompletionsFinishReason finishReason = default,
            ChatMessage deltaMessage = null,
            ContentFilterResults contentFilterResults = null)
        {
            return new ChatChoice(message, index, finishReason, deltaMessage, contentFilterResults);
        }

        public static StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(
            string id,
            DateTimeOffset created,
            int? choiceIndex = null,
            ChatRole? role = null,
            string authorName = null,
            string contentUpdate = null,
            CompletionsFinishReason? finishReason = null,
            string functionName = null,
            string functionArgumentsUpdate = null,
            AzureChatExtensionsMessageContext azureExtensionsContext = null)
        {
            return new StreamingChatCompletionsUpdate(
                id,
                created,
                choiceIndex,
                role,
                authorName,
                contentUpdate,
                finishReason,
                functionName,
                functionArgumentsUpdate,
                azureExtensionsContext);
        }

        /// <summary> Initializes a new instance of AudioTranscription. </summary>
        /// <param name="text"> Transcribed text. </param>
        /// <param name="language"> Language detected in the source audio file. </param>
        /// <param name="duration"> Duration. </param>
        /// <param name="segments"> Segments. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public static AudioTranscription AudioTranscription(string text, string language, TimeSpan duration, IReadOnlyList<AudioTranscriptionSegment> segments)
        {
            return new AudioTranscription(text, default, language, duration, segments);
        }

        /// <summary> Initializes a new instance of AudioTranslation. </summary>
        /// <param name="text"> Translated text. </param>
        /// <param name="language"> Language detected in the source audio file. </param>
        /// <param name="duration"> Duration. </param>
        /// <param name="segments"> Segments. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public static AudioTranslation AudioTranslation(string text, string language, TimeSpan duration, IReadOnlyList<AudioTranslationSegment> segments)
        {
            return new AudioTranslation(text, default, language, duration, segments);
        }
    }
}
