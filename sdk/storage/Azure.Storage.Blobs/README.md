# Azure Storage Blobs client library for .NET
Azure Blob storage is Microsoft's object storage solution for the cloud. Blob
storage is optimized for storing massive amounts of unstructured data.
Unstructured data is data that does not adhere to a particular data model or
definition, such as text or binary data.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][rest_docs] | [Product documentation][product_docs]

## Getting started
### Install the package
Install the Azure Storage Blobs client library for .NET with [NuGet][nuget]:

```Powershell
Install-Package Azure.Storage.Blobs
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a
[Storage Account][storage_account_docs] to use this package.

To create a Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps] or [Azure CLI][storage_account_create_cli]:

## Key concepts
Blob storage is designed for:
- Serving images or documents directly to a browser.
- Storing files for distributed access.
- Streaming video and audio.
- Writing to log files.
- Storing data for backup and restore, disaster recovery, and archiving.
- Storing data for analysis by an on-premises or Azure-hosted service.

## Examples
### Uploading a blob
```c#
string connectionString = <connection_string>;
var service = new BlobServiceClient(connectionString);
var container = service.GetBlobContainerClient("mycontainer");
await container.CreateAsync();

var blob = container.GetBlockBlobClient("myblob");
using (var data = File.OpenRead("Samples/SampleSource.txt"))
{
    await blob.UploadAsync(data);
}
```

### Downloading a blob
```c#
string connectionString = <connection_string>;
var service = new BlobServiceClient(connectionString);
var container = service.GetBlobContainerClient("mycontainer");
var blob = container.GetBlockBlobClient("myblob");

var download = await blob.DownloadAsync();
using (var file = File.Create("BlockDestination.txt"))
{   
    await download.Value.Content.CopyToAsync(file);
}
```

### Enumerating blobs
```c#
string connectionString = <connection_string>;
var service = new BlobServiceClient(connectionString);
var container = service.GetBlobContainerClient("mycontainer");

string marker;
do
{
    var response = await container.ListBlobsFlatSegmentAsync(marker);
    foreach (var blob in response.Value.BlobItems)
    {
        Console.WriteLine(blob.Name);
    }
    marker = response.Value.NextMarker;
}
while (!string.IsNullOrEmpty(marker));
```

## Troubleshooting
All Blob service operations will throw a
[StorageRequestFailedException][StorageRequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].

## Next steps
Get started with our [Blob samples][samples].

## Contributing
This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Blobs%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs/src
[package]: https://www.nuget.org/packages/Azure.Storage.Blobs/
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/blob-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-overview
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[StorageRequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src/StorageRequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/blob-service-error-codes
[samples]: tests/Samples/