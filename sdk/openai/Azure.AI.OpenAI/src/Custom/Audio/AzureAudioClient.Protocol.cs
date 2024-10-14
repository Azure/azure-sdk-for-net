// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using OpenAI.Audio;

namespace Azure.AI.OpenAI.Audio;

internal partial class AzureAudioClient : AudioClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult TranscribeAudio(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranscribeAudioRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> TranscribeAudioAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranscribeAudioRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult TranslateAudio(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranslateAudioRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> TranslateAudioAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranslateAudioRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

#if !AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateSpeech(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateSpeechFromTextRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateSpeechAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateSpeechFromTextRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }
#else
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateSpeech(BinaryContent content, RequestOptions options = null)
    {
        throw new InvalidOperationException($"{nameof(GenerateSpeech)} is not supported using this GA library version. To use this functionality, please use a preview version of the library.");
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Task<ClientResult> GenerateSpeechAsync(BinaryContent content, RequestOptions options = null)
    {
        throw new InvalidOperationException($"{nameof(GenerateSpeechAsync)} is not supported using this GA library version. To use this functionality, please use a preview version of the library.");
    }
#endif

    private PipelineMessage CreateTranscribeAudioRequestMessage(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "transcriptions")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateTranslateAudioRequestMessage(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "translations")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGenerateSpeechFromTextRequestMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "speech")
            .WithContent(content, "application/json")
            .WithAccept("application/octet-stream")
            .WithOptions(options)
            .Build();
}
