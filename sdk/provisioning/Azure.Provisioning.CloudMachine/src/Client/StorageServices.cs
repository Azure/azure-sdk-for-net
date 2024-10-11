// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.CloudMachine;

public static class StorageServices
{
    private static BlobContainerClient GetDefaultContainer(this WorkspaceClient cm)
    {
        string blobContainerClientId = typeof(BlobContainerClient).FullName;

        BlobContainerClient container = cm.Subclients.Get(blobContainerClientId, () =>
        {
            string endpoint = cm.GetConnection(blobContainerClientId)!.Value.Endpoint;
            BlobContainerClient container = new(new Uri(endpoint), cm.Credential);
            return container;
        });
        return container;
    }
    public static string UploadBlob(this WorkspaceClient cm, object json, string? name = default)
    {
        BlobContainerClient container = cm.GetDefaultContainer();

        if (name == default) name = $"b{Guid.NewGuid()}";

        container.UploadBlob(name, BinaryData.FromObjectAsJson(json));

        return name;
    }

    public static BinaryData DownloadBlob(this CloudMachineClient cm, string name)
    {
        BlobContainerClient container = cm.GetDefaultContainer();
        BlobClient blob = container.GetBlobClient(name);
        BlobDownloadResult result = blob.DownloadContent();
        return result.Content;
    }

    public static void WhenBlobUploaded(this CloudMachineClient cm, Action<string> function)
    {
        throw new NotImplementedException();
    }
    public static void WhenBlobCreated(this CloudMachineClient cm, Func<string, Task> function)
    {
        throw new NotImplementedException();
    }
}
