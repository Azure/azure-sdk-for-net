// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using OpenAI.Images;

namespace Azure.AI.OpenAI.Images;

internal partial class AzureImageClient : ImageClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImages(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImagesRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImagesAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImagesRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImageEdits(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageEditsRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImageEditsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageEditsRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImageVariations(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageVariationsRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImageVariationsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageVariationsRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateGenerateImagesRequestMessage(BinaryContent content, RequestOptions options = null)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("images", "generations")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGenerateImageEditsRequestMessage(BinaryContent content, string contentType, RequestOptions options = null)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("images", "edits")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGenerateImageVariationsRequestMessage(BinaryContent content, string contentType, RequestOptions options = null)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("images", "variations")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
