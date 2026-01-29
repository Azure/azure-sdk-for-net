// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Audio;

internal partial class AzureAudioClient : AudioClient
{
#if !AZURE_OPENAI_GA
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

    internal override PipelineMessage CreateTranscribeAudioRequest(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "transcriptions")
            .WithContent(content, contentType)
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateTranslateAudioRequest(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "translations")
            .WithContent(content, contentType)
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGenerateSpeechRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("audio", "speech")
            .WithContent(content, "application/json")
            .WithOptions(options)
            .Build();
}
