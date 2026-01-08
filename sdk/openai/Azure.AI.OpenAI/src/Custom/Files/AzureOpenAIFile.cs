// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Files;

#pragma warning disable CS0618

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[CodeGenType("AzureOpenAIFile")]
[Experimental("AOAI001")]
internal partial class AzureOpenAIFile : OpenAIFile
{
    public new string Id => base.Id;

    public new DateTimeOffset CreatedAt => base.CreatedAt;

    public new string Filename => base.Filename;

    public new string StatusDetails => base.StatusDetails;

    [CodeGenMember("Bytes")]
    public new long? SizeInBytesLong => base.SizeInBytesLong;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int? SizeInBytes => base.SizeInBytes;

    [CodeGenMember("Status")]
    private readonly AzureOpenAIFileStatus _azureStatus;

    public new FileStatus Status => AzureFileExtensions.ToFileStatus(_azureStatus);

    [CodeGenMember("Purpose")]
    private string _purpose;

    public new FilePurpose Purpose
    {
        get => base.Purpose;
        set => _purpose = value.ToSerialString();
    }

    [CodeGenMember("Object")]
    internal string _object;

    internal new IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

    /// <summary> Initializes a new instance of <see cref="AzureOpenAIFile"/>. </summary>
    /// <param name="id"> The file identifier, which can be referenced in the API endpoints. </param>
    /// <param name="bytes"> The size of the file, in bytes. </param>
    /// <param name="createdAt"> The Unix timestamp (in seconds) for when the file was created. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="purpose"> The intended purpose of the file. Supported values are `assistants`, `assistants_output`, `batch`, `batch_output`, `fine-tune`, `fine-tune-results` and `vision`. </param>
    /// <param name="azureStatus"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="filename"/> or <paramref name="purpose"/> is null. </exception>
    internal AzureOpenAIFile(string id, long? bytes, DateTimeOffset createdAt, string filename, string purpose, AzureOpenAIFileStatus azureStatus)
        : base(id, bytes, createdAt, filename, purpose.ToFilePurpose(), azureStatus.ToFileStatus())
    {
        _object = "file";
        _purpose = purpose;
        _azureStatus = azureStatus;
    }

    /// <summary> Initializes a new instance of <see cref="AzureOpenAIFile"/>. </summary>
    /// <param name="id"> The file identifier, which can be referenced in the API endpoints. </param>
    /// <param name="bytes"> The size of the file, in bytes. </param>
    /// <param name="createdAt"> The Unix timestamp (in seconds) for when the file was created. </param>
    /// <param name="filename"> The name of the file. </param>
    /// <param name="object"> The object type, which is always `file`. </param>
    /// <param name="purpose"> The intended purpose of the file. Supported values are `assistants`, `assistants_output`, `batch`, `batch_output`, `fine-tune`, `fine-tune-results` and `vision`. </param>
    /// <param name="statusDetails"> Deprecated. For details on why a fine-tuning training file failed validation, see the `error` field on `fine_tuning.job`. </param>
    /// <param name="azureStatus"></param>
    /// <param name="expiresAt"></param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal AzureOpenAIFile(string id, long? bytes, DateTimeOffset createdAt, DateTimeOffset? expiresAt, string filename, string @object, string purpose, string statusDetails, AzureOpenAIFileStatus azureStatus, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        : base(id, bytes, createdAt, expiresAt, filename, @object, purpose.ToFilePurpose(), azureStatus.ToFileStatus(), statusDetails, additionalBinaryDataProperties)
    {
        _object = @object;
        _purpose = purpose;
        _azureStatus = azureStatus;
    }

    /// <summary> Initializes a new instance of <see cref="AzureOpenAIFile"/> for deserialization. </summary>
    internal AzureOpenAIFile()
    {
    }
}
