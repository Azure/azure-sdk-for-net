// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI;

#pragma warning disable CS0618

[Experimental("AOAI001")]
public static partial class AzureFileExtensions
{
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

    [Experimental("AOAI001")]
    public static AzureOpenAIFileStatus ToAzureOpenAIFileStatus(this FileStatus fileStatus)
    {
        if (fileStatus == FileStatus.Uploaded) return AzureOpenAIFileStatus.Uploaded;
        if (fileStatus == FileStatus.Processed) return AzureOpenAIFileStatus.Processed;
        if (fileStatus == FileStatus.Error) return AzureOpenAIFileStatus.Error;

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
                ["expires_after"] = ModelReaderWriter.Write(expirationOptions),
            }
        };

        using MultiPartFormDataBinaryContent content = AzureFileClient.CreateMultiPartContentWithMimeType(file, filename, purpose, expirationOptions);
        ClientResult result = await client.UploadFileAsync(content, content.ContentType, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return AzureFileClient.GetAzureFileResult(result);
    }

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
                ["expires_after"] = ModelReaderWriter.Write(expirationOptions),
            }
        };

        using MultiPartFormDataBinaryContent content = AzureFileClient.CreateMultiPartContentWithMimeType(file, filename, purpose, expirationOptions);
        ClientResult result = client.UploadFile(content, content.ContentType, cancellationToken.ToRequestOptions());
        return AzureFileClient.GetAzureFileResult(result);
    }

    [Experimental("AOAI001")]
    public static Task<ClientResult<OpenAIFile>> UploadFileAsync(
        this OpenAIFileClient client,
        BinaryData file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFileAsync(file.ToStream(), filename, purpose, expirationOptions, cancellationToken);

    [Experimental("AOAI001")]
    public static ClientResult<OpenAIFile> UploadFile(
        this OpenAIFileClient client,
        BinaryData file,
        string filename,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFile(file.ToStream(), filename, purpose, expirationOptions, cancellationToken);

    [Experimental("AOAI001")]
    public static Task<ClientResult<OpenAIFile>> UploadFileAsync(
        this OpenAIFileClient client,
        string filePath,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFileAsync(File.OpenRead(filePath), filePath, purpose, expirationOptions, cancellationToken);

    [Experimental("AOAI001")]
    public static ClientResult<OpenAIFile> UploadFile(
        this OpenAIFileClient client,
        string filePath,
        FileUploadPurpose purpose,
        AzureFileExpirationOptions expirationOptions,
        CancellationToken cancellationToken = default)
            => client.UploadFile(File.OpenRead(filePath), filePath, purpose, expirationOptions, cancellationToken);
}
