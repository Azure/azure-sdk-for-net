// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Files;

internal partial class AzureFileClient : OpenAIFileClient
{
    public override async Task<ClientResult> CreateUploadAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateUploadRequestMessage(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateUpload(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateUploadRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> AddUploadPartAsync(string uploadId, BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateAddUploadPartRequestMessage(uploadId, content, contentType, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult AddUploadPart(string uploadId, BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateAddUploadPartRequestMessage(uploadId, content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelUploadAsync(string uploadId, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));

        using PipelineMessage message = CreateCancelUploadRequest(uploadId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CancelUpload(string uploadId, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));

        using PipelineMessage message = CreateCancelUploadRequest(uploadId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CompleteUploadAsync(string uploadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCompleteUploadRequestMessage(uploadId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CompleteUpload(string uploadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(uploadId, nameof(uploadId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCompleteUploadRequestMessage(uploadId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    internal override PipelineMessage CreateUploadFileRequest(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("files")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteFileRequest(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDownloadFileRequest(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files", fileId, "content")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetFileRequest(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetFilesRequest(string purpose, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files")
            .WithAccept("application/json")
            .WithOptionalQueryParameter("purpose", purpose)
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCreateUploadRequestMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("uploads")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateAddUploadPartRequestMessage(string uploadId, BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"uploads/{uploadId}/parts")
            .WithContent(content, contentType)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal PipelineMessage CreateCompleteUploadRequestMessage(string uploadId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"uploads/{uploadId}/complete")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal PipelineMessage CreateCancelUploadRequest(string uploadId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"uploads/{uploadId}/cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
