// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.CloudMachine;

public readonly struct StorageServices
{
    private readonly CloudMachineClient _cm;
    internal StorageServices(CloudMachineClient cm) => _cm = cm;

    private BlobContainerClient GetDefaultContainer()
    {
        string blobContainerClientId = typeof(BlobContainerClient).FullName;
        CloudMachineClient cm = _cm;
        BlobContainerClient container = cm.Subclients.Get(blobContainerClientId, () =>
        {
            string endpoint = cm.GetConfiguration(blobContainerClientId)!.Value.Endpoint;
            BlobContainerClient container = new(new Uri(endpoint), cm.Credential);
            return container;
        });
        return container;
    }
    public string UploadBlob(object json, string? name = default)
    {
        BlobContainerClient container = GetDefaultContainer();

        if (name == default) name = $"b{Guid.NewGuid()}";

        container.UploadBlob(name, BinaryData.FromObjectAsJson(json));

        return name;
    }

    public BinaryData DownloadBlob(string name)
    {
        BlobContainerClient container = GetDefaultContainer();
        BlobClient blob = container.GetBlobClient(name);
        BlobDownloadResult result = blob.DownloadContent();
        return result.Content;
    }

    public void WhenBlobUploaded(Action<string> function)
    {
        throw new NotImplementedException();
    }
    public void WhenBlobCreated(Func<string, Task> function)
    {
        throw new NotImplementedException();
    }
}
