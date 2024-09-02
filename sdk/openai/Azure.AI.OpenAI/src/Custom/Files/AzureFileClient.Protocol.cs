// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.AI.OpenAI.Files;

internal partial class AzureFileClient : FileClient
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
}
