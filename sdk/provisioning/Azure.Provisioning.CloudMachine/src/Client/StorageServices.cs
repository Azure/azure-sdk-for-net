// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.CloudMachine;

public static class StorageServices
{
    public static string Upload(this CloudMachineClient cm, object json, string? name = default)
    {
        BlobContainerClient container = cm.ClientCache.Get(cm.Properties.DefaultContainerUri.AbsoluteUri, () =>
        {
            BlobContainerClient container = new(cm.Properties.DefaultContainerUri, cm.Credential);
            return container;
        });

        if (name == default) name = "b" + Guid.NewGuid().ToString();

        container.UploadBlob(name, BinaryData.FromObjectAsJson(json));

        return name;
    }

    public static BinaryData Download(this CloudMachineClient cm, string name)
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
}
