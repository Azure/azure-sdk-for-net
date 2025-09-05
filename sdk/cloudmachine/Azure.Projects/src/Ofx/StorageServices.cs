// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using ContentType = Azure.Core.ContentType;

namespace Azure.Projects;

/// <summary>
/// The storage services for the project client.
/// </summary>
public readonly struct StorageServices
{
    private readonly ProjectClient _project;

    internal StorageServices(ProjectClient project) => _project = project;

    // TODO: do we want Azure.Storage.Blobs in the public API? This would prevent us from using a custom implementation.
    /// <summary>
    /// Gets the container client.
    /// </summary>
    /// <param name="containerName"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BlobContainerClient GetContainer(string containerName = default)
    {
        if (containerName == default) containerName = "default";
        string blobContainerClientId = $"{typeof(BlobContainerClient).FullName}@{containerName}";

        ProjectClient project = _project;
        BlobContainerClientKey blobContainerClientKey = new(containerName);
        BlobContainerClient container = project.Subclients.GetClient(blobContainerClientKey, () =>
        {
            ClientConnection connection = project.GetConnection(blobContainerClientId);

            if (!connection.TryGetLocatorAsUri(out Uri uri))
            {
                throw new InvalidOperationException("The connection is not a valid URI.");
            }

            BlobContainerClient container = new(uri, (TokenCredential)connection.Credential);
            return container;
        });
        return container;
    }

    /// <summary>
    /// Uploads a JSON object to the storage account.
    /// </summary>
    /// <param name="serializable"></param>
    /// <param name="name"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public string UploadJson(object serializable, string name = default, bool overwrite = false)
    {
        BinaryData data = BinaryData.FromObjectAsJson(serializable);
        return Upload(data, name, overwrite);
    }

    /// <summary>
    /// Uploads a JSON object to the storage account.
    /// </summary>
    /// <param name="serializable"></param>
    /// <param name="name"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public async Task<string> UploadJsonAsync(object serializable, string name = default, bool overwrite = false)
    {
        BinaryData data = BinaryData.FromObjectAsJson(serializable);
        return await UploadAsync(data, name, overwrite).ConfigureAwait(false);
    }

    /// <summary>
    /// Uploads a file to the storage account.
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="name"></param>
    /// <param name="contentType"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public string Upload(Stream fileStream, string name = default, string contentType = default, bool overwrite = false)
    {
        BlockBlobClient client = GetBlobClient(ref name);
        BlobUploadOptions options = StorageServices.CreateUploadOptions(overwrite, contentType);

        client.Upload(fileStream, options);
        return name;
    }

    /// <summary>
    /// Uploads a file to the storage account.
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="name"></param>
    /// <param name="contentType"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public async Task<string> UploadAsync(Stream fileStream, string name = default, string contentType = default, bool overwrite = false)
    {
        BlockBlobClient client = GetBlobClient(ref name);
        BlobUploadOptions options = StorageServices.CreateUploadOptions(overwrite, contentType);

        await client.UploadAsync(fileStream, options).ConfigureAwait(false);
        return name;
    }

    private BlockBlobClient GetBlobClient(ref string name)
    {
        BlobContainerClient container = GetContainer(default);
        if (name == default) name = $"b{Guid.NewGuid()}";
        BlockBlobClient client = container.GetBlockBlobClient(name);
        return client;
    }

    private static BlobUploadOptions CreateUploadOptions(bool overwrite, string contentType)
    {
        contentType ??= ContentType.ApplicationOctetStream.ToString();
        BlobUploadOptions options = new()
        {
            Conditions = overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag("*") },
            HttpHeaders = new BlobHttpHeaders { ContentType = contentType },
        };
        return options;
    }

    /// <summary>
    /// Uploads a binary data object to the storage account.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="name"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public string Upload(BinaryData data, string name = default, bool overwrite = false)
        => Upload(data.ToStream(), name, data.MediaType, overwrite);

    /// <summary>
    /// Uploads a binary data object to the storage account.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="name"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public async Task<string> UploadAsync(BinaryData data, string name = default, bool overwrite = false)
        => await UploadAsync(data.ToStream(), name, data.MediaType, overwrite).ConfigureAwait(false);

    /// <summary>
    /// Uploads a file to the storage account.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public BinaryData Download(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, containerName: default);
        BlobDownloadResult result = blob.DownloadContent();
        BinaryData content = result.Content;

        string contentType = result.Details.ContentType;
        if (contentType != default)
            content = content.WithMediaType(contentType);

        return content;
    }

    /// <summary>
    /// Uploads a file to the storage account.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task<BinaryData> DownloadAsync(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, containerName: default);
        BlobDownloadResult result = await blob.DownloadContentAsync().ConfigureAwait(false);
        BinaryData content = result.Content;

        string contentType = result.Details.ContentType;
        if (contentType!=default) content = content.WithMediaType(contentType);

        return content;
    }

    /// <summary>
    /// Deletes a blob from the storage account.
    /// </summary>
    /// <param name="path"></param>
    public void Delete(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, null);
        blob.DeleteIfExists();
    }

    /// <summary>
    /// Deletes a blob from the storage account.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task DeleteAsync(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, null);
        await blob.DeleteIfExistsAsync().ConfigureAwait(false);
    }

    private BlobClient GetBlobClientFromPath(string path, string containerName)
    {
        BlobContainerClient _blobContainer = GetContainer(default);
        string blobPath = ConvertPathToBlobPath(path, _blobContainer);
        if (containerName is null)
        {
            return _blobContainer.GetBlobClient(blobPath);
        }
        else
        {
            BlobContainerClient container = GetContainer(containerName);
            container.CreateIfNotExists();
            return container.GetBlobClient(blobPath);
        }
    }

    private static string ConvertPathToBlobPath(string path, BlobContainerClient container)
    {
        if (Uri.TryCreate(path, UriKind.Absolute, out Uri blobUri))
        {
            if (blobUri.Host == container.Uri.Host)
                return blobUri.AbsoluteUri.Substring(container.Uri.AbsoluteUri.Length);
            if (!string.IsNullOrEmpty(blobUri.LocalPath))
            {
                return blobUri.LocalPath.Substring(Path.GetPathRoot(path).Length).Replace('\\', '/');
            }
        }
        return path.Substring(Path.GetPathRoot(path).Length).Replace('\\', '/');
    }

    /// <summary>
    /// Adds a function to be called when a blob is uploaded.
    /// </summary>
    /// <param name="function"></param>
    public void WhenUploaded(Action<StorageFile> function)
    {
        // TODO (Pri 0): once the cache gets GCed, we will stop receiving events
        ServiceBusProcessor processor = _project.GetServiceBusProcessor(_project.ProjectId, "cm_servicebus_subscription_private");
        StorageServices storage = this;

        // TODO: How to unsubscribe?
        processor.ProcessMessageAsync += async (args) =>
        {
            EventGridEvent e = EventGridEvent.Parse(args.Message.Body);
            if (e.TryGetSystemEventData(out object systemEvent))
            {
                switch (systemEvent)
                {
                    case StorageBlobCreatedEventData bc:
                        var blobUri = bc.Url;
                        var requestId = bc.ClientRequestId;
                        // _logger.Log.EventReceived(nameof(OnProcessMessage), $"StorageBlobCreatedEventData: blobUri='{blobUri}' requestId='{requestId}'");

                        var eventArgs = new StorageFile(storage, blobUri, requestId, default);
                        function(eventArgs);
                        await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
                        break;
                    default:
                        break;
                }
            }
            await Task.CompletedTask.ConfigureAwait(false);
        };
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        processor.StartProcessingAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    }

    /// <summary>
    /// Adds a function to be called when a blob is uploaded.
    /// </summary>
    /// <param name="function"></param>
    public void WhenUploaded(Action<BinaryData> function)
    {
        WhenUploaded((StorageFile file) =>
        {
            BinaryData data = file.Download();
            function(data);
        });
    }

    private record BlobContainerClientKey(string ContainerName);
}
