// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.CloudMachine;

public static class StorageServices
{
    public static string UploadBlob(this CloudMachineClient cm, object json, string? name = default)
    {
        BlobContainerClient container = cm.ClientCache.Get(cm.Properties.DefaultContainerUri.AbsoluteUri, () =>
        {
            BlobContainerClient container = new(cm.Properties.DefaultContainerUri, cm.Credential);
            return container;
        });

        if (name == default) name = $"b{Guid.NewGuid()}";

        container.UploadBlob(name, BinaryData.FromObjectAsJson(json));

        return name;
    }

    public static BinaryData DownloadBlob(this CloudMachineClient cm, string name)
    {
        BlobContainerClient container = cm.ClientCache.Get(cm.Properties.DefaultContainerUri.AbsoluteUri, () =>
        {
            BlobContainerClient container = new(cm.Properties.DefaultContainerUri, cm.Credential);
            return container;
        });

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
