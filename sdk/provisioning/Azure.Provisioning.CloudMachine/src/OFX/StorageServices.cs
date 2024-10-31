// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.CloudMachine;

public readonly struct StorageServices
{
    private readonly CloudMachineClient _cm;
    internal StorageServices(CloudMachineClient cm) => _cm = cm;

    private BlobContainerClient GetDefaultContainer()
    {
        CloudMachineClient cm = _cm;
        BlobContainerClient container = _cm.Subclients.Get(() =>
        {
            ClientConnectionOptions connection = cm.GetConnectionOptions(typeof(BlobContainerClient));
            BlobContainerClient container = new(connection.Endpoint, connection.TokenCredential);
            return container;
        });
        return container;
    }

    private BlobContainerClient GetContainer(string containerName)
    {
        string blobContainerClientId = typeof(BlobContainerClient).FullName;
        CloudMachineClient cm = _cm;
        BlobContainerClient container = cm.Subclients.Get(() =>
        {
            ClientConnectionOptions connection = cm.GetConnectionOptions(typeof(BlobContainerClient), containerName);
            BlobContainerClient container = new(connection.Endpoint, connection.TokenCredential);
            return container;
        });
        return container;
    }

    public string UploadJson(object json, string? name = default, bool overwrite = false)
    {
        BlobContainerClient container = GetDefaultContainer();

        if (name == default)
            name = $"b{Guid.NewGuid()}";

        var client = container.GetBlockBlobClient(name);
        var options = new BlobUploadOptions
        {
            Conditions = overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag("*") },
            HttpHeaders = new BlobHttpHeaders { ContentType = ContentType.ApplicationJson.ToString() }
        };

        client.Upload(BinaryData.FromObjectAsJson(json).ToStream(), options);
        return name;
    }

    public string UploadStream(Stream fileStream, string? name = default, bool overwrite = false)
    {
        BlobContainerClient container = GetDefaultContainer();

        if (name == default)
            name = $"b{Guid.NewGuid()}";

        var client = container.GetBlockBlobClient(name);
        var options = new BlobUploadOptions
        {
            Conditions = overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag("*") },
            HttpHeaders = new BlobHttpHeaders { ContentType = ContentType.ApplicationOctetStream.ToString() }
        };

        client.Upload(fileStream, options);
        return name;
    }

    public string UploadBinaryData(BinaryData data, string? name = default, bool overwrite = false)
    {
        BlobContainerClient container = GetDefaultContainer();
        if (name == default)
            name = $"b{Guid.NewGuid()}";

        var client = container.GetBlockBlobClient(name);
        var options = new BlobUploadOptions
        {
            Conditions = overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag("*") },
            HttpHeaders = new BlobHttpHeaders { ContentType = ContentType.ApplicationOctetStream.ToString() }
        };

        client.Upload(data.ToStream(), options);
        return name;
    }

    public string UploadBytes(byte[] bytes, string? name = default, bool overwrite = false)
        => UploadBinaryData(BinaryData.FromBytes(bytes), name, overwrite);
    public string UploadBytes(ReadOnlyMemory<byte> bytes, string? name = default, bool overwrite = false)
        => UploadBinaryData(BinaryData.FromBytes(bytes), name, overwrite);

    public BinaryData DownloadBlob(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, null);
        BlobDownloadResult result = blob.DownloadContent();
        return result.Content;
    }

    public void DeleteBlob(string path)
    {
        BlobClient blob = GetBlobClientFromPath(path, null);
        blob.DeleteIfExists();
    }

    private BlobClient GetBlobClientFromPath(string path, string? containerName)
    {
        var _blobContainer = GetDefaultContainer();
        var blobPath = ConvertPathToBlobPath(path, _blobContainer);
        if (containerName is null)
        {
            return _blobContainer.GetBlobClient(blobPath);
        }
        else
        {
            var container = GetContainer(containerName);
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

    public void WhenBlobUploaded(Action<StorageFile> function)
    {
        var processor = _cm.Messaging.GetServiceBusProcessor();
        var cm = _cm;

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

                        var eventArgs = new StorageFile(cm.Storage, blobUri, requestId, default);
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
}
