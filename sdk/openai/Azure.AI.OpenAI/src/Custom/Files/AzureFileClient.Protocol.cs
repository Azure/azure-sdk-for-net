// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.AI.OpenAI.Files;

internal partial class AzureFileClient : OpenAIFileClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult DeleteFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteRequestMessage(fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> DeleteFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteRequestMessage(fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult DownloadFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDownloadContentRequestMessage(fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> DownloadFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDownloadContentRequestMessage(fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GetFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetFileRequestMessage(fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GetFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetFileRequestMessage(fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GetFiles(string purpose, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFilesRequestMessage(purpose, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GetFilesAsync(string purpose, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFilesRequestMessage(purpose, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult UploadFile(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateUploadRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> UploadFileAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateUploadRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

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

    private PipelineMessage CreateDeleteRequestMessage(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateDownloadContentRequestMessage(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files", fileId, "content")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetFileRequestMessage(string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetFilesRequestMessage(string purpose, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("files")
            .WithAccept("application/json")
            .WithOptionalQueryParameter("purpose", purpose)
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateUploadRequestMessage(BinaryContent content, string contentType, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("files")
            .WithContent(content, contentType)
            .WithAccept("application/json")
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

    internal PipelineMessage CreateAddUploadPartRequestMessage(string uploadId, BinaryContent content, string contentType, RequestOptions options)
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
