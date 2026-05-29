// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
public partial class AIProjectModels
{
    /// <summary>
    /// Update an existing ModelVersion with the given version id
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="name"> The name of the resource. </param>
    /// <param name="version"> The specific version id of the UpdateModelVersionRequest to create or update. </param>
    /// <param name="updateOptions"> The update model options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="updateOptions"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<ModelVersion> UpdateModelVersion(string name, string version, UpdateModelVersionOptions updateOptions, CancellationToken cancellationToken = default)
    {
        BinaryData data = ModelReaderWriter.Write(updateOptions, ModelReaderWriterOptions.Json, AzureAIProjectsContext.Default);
        using BinaryContent content = BinaryContent.Create(data);
        ClientResult result = UpdateModelVersion(
            name: name,
            version: version,
            content: content,
            options: cancellationToken.ToRequestOptions()
        );
        return ClientResult.FromValue((ModelVersion)result, result.GetRawResponse());
    }

    /// <summary>
    /// Update an existing ModelVersion with the given version id
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="name"> The name of the resource. </param>
    /// <param name="version"> The specific version id of the UpdateModelVersionRequest to create or update. </param>
    /// <param name="updateOptions"> The update model options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="updateOptions"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<ModelVersion>> UpdateModelVersionAsync(string name, string version, UpdateModelVersionOptions updateOptions, CancellationToken cancellationToken = default)
    {
        BinaryData data = ModelReaderWriter.Write(updateOptions, ModelReaderWriterOptions.Json, AzureAIProjectsContext.Default);
        using BinaryContent content = BinaryContent.Create(data);
        ClientResult result = await UpdateModelVersionAsync(
            name: name,
            version: version,
            content: content,
            options: cancellationToken.ToRequestOptions()
        ).ConfigureAwait(false);
        return ClientResult.FromValue((ModelVersion)result, result.GetRawResponse());
    }

    public virtual Uri UploadModel(string path, string name, string version)
    {
        if (!Directory.Exists(path))
        {
            throw new ArgumentException($"The provided folder does not exist: {path}");
        }
        ModelPendingUploadResponse uploadResponse = StartModelPendingUpload(
            name: name,
            version: version,
            pendingUploadRequest: new()
        );
        BlobContainerClient client = GetContainerClientOrRaise(uploadResponse);

        var filesUploaded = false;
        BlobClient blobClient;
        foreach (var filePath in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            string fileName = Path.GetFileName(filePath);
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                blobClient = client.GetBlobClient(fileName);
                blobClient.Upload(fileStream);
                filesUploaded = true;
            }
        }

        if (!filesUploaded)
        {
            throw new ArgumentException("The provided folder is empty.");
        }
        return uploadResponse.BlobReferenceForConsumption.BlobUri;
    }

    public virtual async Task<Uri> UploadModelAsync(string path, string name, string version)
    {
        if (!Directory.Exists(path))
        {
            throw new ArgumentException($"The provided folder does not exist: {path}");
        }
        ModelPendingUploadResponse uploadResponse = await StartModelPendingUploadAsync(
            name: name,
            version: version,
            pendingUploadRequest: new()
        ).ConfigureAwait(false);
        BlobContainerClient client = GetContainerClientOrRaise(uploadResponse);

        var filesUploaded = false;
        BlobClient blobClient;
        foreach (var filePath in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            string fileName = Path.GetFileName(filePath);
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                blobClient = client.GetBlobClient(fileName);
                await blobClient.UploadAsync(fileStream).ConfigureAwait(false);
                filesUploaded = true;
            }
        }

        if (!filesUploaded)
        {
            throw new ArgumentException("The provided folder is empty.");
        }
        return uploadResponse.BlobReferenceForConsumption.BlobUri;
    }

    /// <summary>
    /// The convenience method to get the container client.
    /// </summary>
    /// <param name="pendingUploadResult">The pending upload request.</param>
    /// <returns></returns>
    private BlobContainerClient GetContainerClientOrRaise(ModelPendingUploadResponse pendingUploadResult)
    {
        if (pendingUploadResult.BlobReferenceForConsumption == null)
        {
            throw new InvalidOperationException("Blob reference is not present.");
        }
        if (pendingUploadResult.BlobReferenceForConsumption.Credential == null || pendingUploadResult.BlobReferenceForConsumption.Credential.SasUri == null)
        {
            throw new InvalidOperationException("SAS credential is not present.");
        }

        BlobContainerClient containerClient;
        containerClient = new BlobContainerClient(pendingUploadResult.BlobReferenceForConsumption.Credential.SasUri);
        return containerClient;
    }
}
