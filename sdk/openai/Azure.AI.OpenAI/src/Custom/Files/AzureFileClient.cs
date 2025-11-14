// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Files;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Azure.AI.OpenAI.Files;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("AOAI001")]
internal partial class AzureFileClient : OpenAIFileClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFileClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    protected AzureFileClient()
    { }

    /// <inheritdoc />
    public override ClientResult<OpenAIFile> UploadFile(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default)
    {
        if (purpose != FileUploadPurpose.FineTune && purpose != FileUploadPurpose.Batch)
        {
            ClientResult<OpenAIFile> baseResult = base.UploadFile(file, filename, purpose, cancellationToken);
            return GetAzureFileResult(baseResult);
        }

        // need to set the content type for fine tuning file uploads in Azure OpenAI
        Argument.AssertNotNull(file, "file");
        Argument.AssertNotNullOrEmpty(filename, "filename");

        using MultiPartFormDataBinaryContent content = CreateMultiPartContentWithMimeType(file, filename, purpose);
        ClientResult clientResult = UploadFile(content, content.ContentType, new() { CancellationToken = cancellationToken });
        return GetAzureFileResult(clientResult);
    }

    /// <inheritdoc />
    public override async Task<ClientResult<OpenAIFile>> UploadFileAsync(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default)
    {
        if (purpose != FileUploadPurpose.FineTune && purpose != FileUploadPurpose.Batch)
        {
            ClientResult<OpenAIFile> baseResult = await base.UploadFileAsync(file, filename, purpose, cancellationToken)
                .ConfigureAwait(false);
            return GetAzureFileResult(baseResult);
        }

        // need to set the content type for fine tuning file uploads in Azure OpenAI
        Argument.AssertNotNull(file, "file");
        Argument.AssertNotNullOrEmpty(filename, "filename");

        using MultiPartFormDataBinaryContent content = CreateMultiPartContentWithMimeType(file, filename, purpose);
        ClientResult result = await UploadFileAsync(content, content.ContentType, new() { CancellationToken = cancellationToken })
            .ConfigureAwait(continueOnCapturedContext: false);
        return GetAzureFileResult(result);
    }

    public override async Task<ClientResult<OpenAIFile>> GetFileAsync(string fileId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetFileAsync(fileId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return GetAzureFileResult(protocolResult);
    }

    public override ClientResult<OpenAIFile> GetFile(string fileId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetFile(fileId, cancellationToken.ToRequestOptions());
        return GetAzureFileResult(protocolResult);
    }

    public override async Task<ClientResult<OpenAIFileCollection>> GetFilesAsync(CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetFilesAsync(null, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return GetTypedResult<OpenAIFileCollection, AzureOpenAIFileCollection>(protocolResult, AzureOpenAIFileCollection.FromResponse);
    }

    public override ClientResult<OpenAIFileCollection> GetFiles(CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetFiles(null, cancellationToken.ToRequestOptions());
        return GetTypedResult<OpenAIFileCollection, AzureOpenAIFileCollection>(protocolResult, AzureOpenAIFileCollection.FromResponse);
    }

    public override async Task<ClientResult<OpenAIFileCollection>> GetFilesAsync(FilePurpose purpose, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetFilesAsync(purpose.ToSerialString(), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return GetTypedResult<OpenAIFileCollection, AzureOpenAIFileCollection>(protocolResult, AzureOpenAIFileCollection.FromResponse);
    }

    public override ClientResult<OpenAIFileCollection> GetFiles(FilePurpose purpose, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetFiles(purpose.ToSerialString(), cancellationToken.ToRequestOptions());
        return GetTypedResult<OpenAIFileCollection, AzureOpenAIFileCollection>(protocolResult, AzureOpenAIFileCollection.FromResponse);
    }

    internal static MultiPartFormDataBinaryContent CreateMultiPartContentWithMimeType(
        Stream file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions = null)
    {
        MultiPartFormDataBinaryContent multipartFormDataBinaryContent = new();
        string contentType = "text/plain";
        if (purpose == FileUploadPurpose.Batch)
        {
            contentType = "application/json";
        }
        multipartFormDataBinaryContent.Add(file, "file", filename, contentType);
        multipartFormDataBinaryContent.Add(purpose.ToString(), "purpose");

        if (expirationOptions is not null)
        {
            multipartFormDataBinaryContent.Add(ModelReaderWriter.Write(expirationOptions, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default), "expires_after");
        }

        return multipartFormDataBinaryContent;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ClientResult<T> GetTypedResult<T, U>(ClientResult result, Func<PipelineResponse, U> fromResponseFunc)
        where T : class
        where U : T
    {
        PipelineResponse rawResponse = result.GetRawResponse();
        U compatibleInstance = fromResponseFunc.Invoke(rawResponse);
        return ClientResult.FromValue(compatibleInstance as T, rawResponse);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ClientResult<OpenAIFile> GetAzureFileResult(ClientResult protocolResult)
        => GetTypedResult<OpenAIFile, AzureOpenAIFile>(protocolResult, AzureOpenAIFile.FromResponse);
}
