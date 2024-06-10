// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Files;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Files;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureFileClient : FileClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFileClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureFileClient()
    { }

    /// <inheritdoc />
    public override ClientResult<OpenAIFileInfo> UploadFile(Stream file, string filename, FileUploadPurpose purpose)
    {
        // need to set the content type for fine tuning file uploads in Azure OpenAI
        if (purpose != FileUploadPurpose.FineTune)
        {
            return base.UploadFile(file, filename, purpose);
        }

        Argument.AssertNotNull(file, "file");
        Argument.AssertNotNullOrEmpty(filename, "filename");

        using MultipartFormDataBinaryContent content = CreateMultiPartContentWithMimeType(file, filename, purpose);
        ClientResult clientResult = UploadFile(content, content.ContentType);
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(clientResult.GetRawResponse()), clientResult.GetRawResponse());
    }

    /// <inheritdoc />
    public override async Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(Stream file, string filename, FileUploadPurpose purpose)
    {
        if (purpose != FileUploadPurpose.FineTune)
        {
            return await base.UploadFileAsync(file, filename, purpose)
                .ConfigureAwait(false);
        }

        Argument.AssertNotNull(file, "file");
        Argument.AssertNotNullOrEmpty(filename, "filename");

        using MultipartFormDataBinaryContent content = CreateMultiPartContentWithMimeType(file, filename, purpose);
        ClientResult result = await UploadFileAsync(content, content.ContentType).ConfigureAwait(continueOnCapturedContext: false);
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    private MultipartFormDataBinaryContent CreateMultiPartContentWithMimeType(Stream file, string filename, FileUploadPurpose purpose)
    {
        MultipartFormDataBinaryContent multipartFormDataBinaryContent = new MultipartFormDataBinaryContent();
        multipartFormDataBinaryContent.Add(file, "file", filename, "text/plain");
        multipartFormDataBinaryContent.Add(purpose.ToString(), "purpose");
        return multipartFormDataBinaryContent;
    }
}
