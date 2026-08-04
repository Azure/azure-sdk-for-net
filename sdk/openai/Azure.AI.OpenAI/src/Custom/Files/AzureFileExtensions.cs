// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI;

#pragma warning disable CS0618

/// <summary> Provides extension methods for Azure-specific file operations, including status conversion and file upload with expiration options. </summary>
[Experimental("AOAI001")]
public static partial class AzureFileExtensions
{
    /// <summary> Converts an <see cref="AzureOpenAIFileStatus"/> to the corresponding <see cref="FileStatus"/> value. </summary>
    /// <param name="azureStatus"> The Azure-specific file status to convert. </param>
    /// <returns> The equivalent <see cref="FileStatus"/> value. </returns>
    [Experimental("AOAI001")]
    public static FileStatus ToFileStatus(this AzureOpenAIFileStatus azureStatus)
    {
        return azureStatus switch
        {
            AzureOpenAIFileStatus.Uploaded => FileStatus.Uploaded,
            AzureOpenAIFileStatus.Processed => FileStatus.Processed,
            AzureOpenAIFileStatus.Error => FileStatus.Error,
            _ => (FileStatus)(-1 * Math.Abs(azureStatus.ToSerialString().GetHashCode()))
        };
    }

    /// <summary> Converts a <see cref="FileStatus"/> to the corresponding <see cref="AzureOpenAIFileStatus"/> value. </summary>
    /// <param name="fileStatus"> The file status to convert. </param>
    /// <returns> The equivalent <see cref="AzureOpenAIFileStatus"/> value. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the file status does not correspond to a known Azure status. </exception>
    [Experimental("AOAI001")]
    public static AzureOpenAIFileStatus ToAzureOpenAIFileStatus(this FileStatus fileStatus)
    {
        if (fileStatus == FileStatus.Uploaded)
            return AzureOpenAIFileStatus.Uploaded;
        if (fileStatus == FileStatus.Processed)
            return AzureOpenAIFileStatus.Processed;
        if (fileStatus == FileStatus.Error)
            return AzureOpenAIFileStatus.Error;

        List<AzureOpenAIFileStatus> otherEncodedStatuses =
            [
                AzureOpenAIFileStatus.Pending,
                AzureOpenAIFileStatus.Running,
                AzureOpenAIFileStatus.Deleting,
                AzureOpenAIFileStatus.Deleted,
            ];

        foreach (AzureOpenAIFileStatus otherEncodedStatus in otherEncodedStatuses)
        {
            if ((int)fileStatus == -1 * Math.Abs(otherEncodedStatus.ToSerialString().GetHashCode()))
            {
                return otherEncodedStatus;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(fileStatus), (int)fileStatus, "Unknown AzureOpenAIFileStatus value.");
    }

    /// <summary> Uploads a file from a stream to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="file"> The stream containing the file content to upload. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static async Task<ClientResult<OpenAIFile>> UploadFileAsync(
        this OpenAIFileClient client,
        Stream file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));
        Argument.AssertNotNull(expirationOptions, nameof(expirationOptions));

        InternalFileUploadOptions options = new()
        {
            Purpose = purpose,
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>
            {
                ["expires_after"] = ModelReaderWriter.Write(expirationOptions, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default),
            }
        };

        using MultiPartFormDataBinaryContent content = AzureFileClient.CreateMultiPartContentWithMimeType(file, filename, purpose, expirationOptions);
        ClientResult result = await client.UploadFileAsync(content, content.ContentType, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return AzureFileClient.GetAzureFileResult(result);
    }

    /// <summary> Uploads a file from a stream to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="file"> The stream containing the file content to upload. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static ClientResult<OpenAIFile> UploadFile(
        this OpenAIFileClient client,
        Stream file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));
        Argument.AssertNotNull(expirationOptions, nameof(expirationOptions));

        InternalFileUploadOptions options = new()
        {
            Purpose = purpose,
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>
            {
                ["expires_after"] = ModelReaderWriter.Write(expirationOptions, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default),
            }
        };

        using MultiPartFormDataBinaryContent content = AzureFileClient.CreateMultiPartContentWithMimeType(file, filename, purpose, expirationOptions);
        ClientResult result = client.UploadFile(content, content.ContentType, cancellationToken.ToRequestOptions());
        return AzureFileClient.GetAzureFileResult(result);
    }

    /// <summary> Uploads a file from binary data to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="file"> The binary data containing the file content to upload. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static Task<ClientResult<OpenAIFile>> UploadFileAsync(
        this OpenAIFileClient client,
        BinaryData file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFileAsync(file.ToStream(), filename, purpose, expirationOptions, cancellationToken);

    /// <summary> Uploads a file from binary data to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="file"> The binary data containing the file content to upload. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static ClientResult<OpenAIFile> UploadFile(
        this OpenAIFileClient client,
        BinaryData file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFile(file.ToStream(), filename, purpose, expirationOptions, cancellationToken);

    /// <summary> Uploads a file from a file path to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="filePath"> The path to the file to upload. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static Task<ClientResult<OpenAIFile>> UploadFileAsync(
        this OpenAIFileClient client,
        string filePath,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFileAsync(File.OpenRead(filePath), filePath, purpose, expirationOptions, cancellationToken);

    /// <summary> Uploads a file from a file path to Azure OpenAI with expiration options. </summary>
    /// <param name="client"> The <see cref="OpenAIFileClient"/> to use for the upload. </param>
    /// <param name="filePath"> The path to the file to upload. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="expirationOptions"> The expiration configuration for the uploaded file. </param>
    /// <param name="cancellationToken"> A token to cancel the operation. </param>
    /// <returns> A <see cref="ClientResult{T}"/> containing the uploaded <see cref="OpenAIFile"/>. </returns>
    [Experimental("AOAI001")]
    public static ClientResult<OpenAIFile> UploadFile(
        this OpenAIFileClient client,
        string filePath,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFile(File.OpenRead(filePath), filePath, purpose, expirationOptions, cancellationToken);
}
