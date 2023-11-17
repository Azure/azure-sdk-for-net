// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("GetCompletions", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetCompletionsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetCompletions", typeof(string), typeof(CompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetCompletionsAsync", typeof(string), typeof(CompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetCompletionsStreaming", typeof(string), typeof(CompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetCompletionsStreamingAsync", typeof(string), typeof(CompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetChatCompletions", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetChatCompletionsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetChatCompletions", typeof(string), typeof(ChatCompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetChatCompletionsAsync", typeof(string), typeof(ChatCompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetEmbeddings", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetEmbeddingsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetEmbeddings", typeof(string), typeof(EmbeddingsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetEmbeddingsAsync", typeof(string), typeof(EmbeddingsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetChatCompletionsWithAzureExtensions", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetChatCompletionsWithAzureExtensions", typeof(string), typeof(ChatCompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetChatCompletionsWithAzureExtensionsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetChatCompletionsWithAzureExtensionsAsync", typeof(string), typeof(ChatCompletionsOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranscriptionAsPlainText", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranscriptionAsPlainText", typeof(string), typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranscriptionAsPlainTextAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranscriptionAsPlainTextAsync", typeof(string), typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranscriptionAsResponseObject", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranscriptionAsResponseObject", typeof(string), typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranscriptionAsResponseObjectAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranscriptionAsResponseObjectAsync", typeof(string), typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranslationAsPlainText", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranslationAsPlainText", typeof(string), typeof(AudioTranslationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranslationAsPlainTextAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranslationAsPlainTextAsync", typeof(string), typeof(AudioTranslationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranslationAsResponseObject", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranslationAsResponseObject", typeof(string), typeof(AudioTranslationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetAudioTranslationAsResponseObjectAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetAudioTranslationAsResponseObjectAsync", typeof(string), typeof(AudioTranslationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetImageGenerations", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetImageGenerations", typeof(string), typeof(ImageGenerationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("GetImageGenerationsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetImageGenerationsAsync", typeof(string), typeof(ImageGenerationOptions), typeof(CancellationToken))]
    [CodeGenSuppress("CreateGetCompletionsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetChatCompletionsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetEmbeddingsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetChatCompletionsWithAzureExtensionsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetAudioTranscriptionAsPlainTextRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetAudioTranscriptionAsResponseObjectRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetAudioTranslationAsPlainTextRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetAudioTranslationAsResponseObjectRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    public partial class OpenAIClient
    {
    }
}
