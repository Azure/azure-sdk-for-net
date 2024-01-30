// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI;

/// <summary> Model factory for models. </summary>
[CodeGenModel("AIOpenAIModelFactory")]
public static partial class AzureOpenAIModelFactory
{
    // CUSTOM CODE NOTE:
    //   This portion of the partial class ensures we have factory exposure for all needed types, including ones
    //   added in custom code.

    /// <summary> Initializes a new instance of ChatChoice. </summary>
    /// <param name="message"> The chat message associated with this chat completions choice. </param>
    /// <param name="index"> The ordered index associated with this chat completions choice. </param>
    /// <param name="finishReason"> The reason that this chat completions choice completed. </param>
    /// <param name="finishDetails"> The reason, with details, that this choice completed. </param>
    /// <param name="deltaMessage"> For streamed choices, the internal representation of a 'delta' payload. </param>
    /// <param name="contentFilterResults"> The category annotations for this chat choice's content filtering. </param>
    /// <param name="enhancements"> The enhancements for this choice. </param>
    /// <returns> A new <see cref="OpenAI.ChatChoice"/> instance for mocking. </returns>
    public static ChatChoice ChatChoice(
        ChatResponseMessage message = null,
        int index = default,
        CompletionsFinishReason? finishReason = null,
        ChatFinishDetails finishDetails = null,
        ChatResponseMessage deltaMessage = null,
        ContentFilterResultsForChoice contentFilterResults = null,
        AzureChatEnhancements enhancements = null)
    {
        return new ChatChoice(message, index, finishReason, finishDetails, deltaMessage, contentFilterResults, enhancements, serializedAdditionalRawData: null);
    }

    public static StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(
        string id,
        DateTimeOffset created,
        string systemFingerprint,
        int? choiceIndex = null,
        ChatRole? role = null,
        string authorName = null,
        string contentUpdate = null,
        CompletionsFinishReason? finishReason = null,
        string functionName = null,
        string functionArgumentsUpdate = null,
        StreamingToolCallUpdate toolCallUpdate = null,
        AzureChatExtensionsMessageContext azureExtensionsContext = null)
    {
        return new StreamingChatCompletionsUpdate(
            id,
            created,
            systemFingerprint,
            choiceIndex,
            role,
            authorName,
            contentUpdate,
            finishReason,
            functionName,
            functionArgumentsUpdate,
            toolCallUpdate,
            azureExtensionsContext);
    }

    public static StreamingFunctionToolCallUpdate StreamingFunctionToolCallUpdate(
        string id,
        int toolCallIndex,
        string functionName,
        string functionArgumentsUpdate)
    {
        return new StreamingFunctionToolCallUpdate(id, toolCallIndex, functionName, functionArgumentsUpdate);
    }

    // CUSTOM CODE NOTE:
    // Because we customized one of the properties to be internal, this method cannot be
    // auto-generated and must be added manually.

    /// <summary> Initializes a new instance of AudioTranscription. </summary>
    /// <param name="text"> Transcribed text. </param>
    /// <param name="language"> Language detected in the source audio file. </param>
    /// <param name="duration"> Duration. </param>
    /// <param name="segments"> Segments. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
    public static AudioTranscription AudioTranscription(string text, string language, TimeSpan duration, IReadOnlyList<AudioTranscriptionSegment> segments)
    {
        return new AudioTranscription(text, default, language, duration, segments, serializedAdditionalRawData: null);
    }

    // CUSTOM CODE NOTE:
    // Because we customized one of the properties to be internal, this method cannot be
    // auto-generated and must be added manually.

    /// <summary> Initializes a new instance of AudioTranslation. </summary>
    /// <param name="text"> Translated text. </param>
    /// <param name="language"> Language detected in the source audio file. </param>
    /// <param name="duration"> Duration. </param>
    /// <param name="segments"> Segments. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
    public static AudioTranslation AudioTranslation(string text, string language, TimeSpan duration, IReadOnlyList<AudioTranslationSegment> segments)
    {
        return new AudioTranslation(text, default, language, duration, segments, serializedAdditionalRawData: null);
    }
}
