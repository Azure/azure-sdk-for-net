# Azure Storage Files client library for .NET
Azure Files offers fully managed file shares in the cloud that are accessible
via the industry standard Server Message Block (SMB) protocol. Azure file
shares can be mounted concurrently by cloud or on-premises deployments of
Windows, Linux, and macOS. Additionally, Azure file shares can be cached on
Windows Servers with Azure File Sync for fast access near where the data is
being used.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][rest_docs] | [Product documentation][product_docs]

## Getting started
### Install the package
Install the Azure Storage Files client library for .NET with [NuGet][nuget]:

```Powershell
Install-Package Azure.Storage.Files -Version 1.0.0-preview.1
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a
[Storage Account][storage_account_docs] to use this package.

To create a Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps] or [Azure CLI][storage_account_create_cli]:

## Key concepts
Azure file shares can be used to:
- Completely replace or supplement traditional on-premises file servers or NAS devices.
- "Lift and shift" applications to the cloud that expect a file share to store file application or user data.
- Simplify new cloud development projects with shared application settings, diagnostic shares, and Dev/Test/Debug tool file shares.

## Examples
### Create a file share
```c#
string connectionString = <connection_string>;
var service = new FileServiceClient(connectionString);
var share = service.GetShareClient("myshare");
await share.CreateAsync();
```

### Upload a file
```c#
string connectionString = <connection_string>;
var service = new FileServiceClient(connectionString);
var share = service.GetShareClient("myshare");
var directory = share.GetDirectoryClient("mydirectory");
await directory.CreateAsync();
var file = directory.GetFileClient("myfile");
await file.CreateAsync(maxSize: 1024);
using (var data = File.OpenRead("Data.txt"))
{
    await file.UploadRangeAsync(
        writeType: FileRangeWriteType.Update,
        range: new HttpRange(0, 1024),
        content: data);
}
```

## Troubleshooting
All Azure Storage File service operations will throw a
[StorageRequestFailedException][StorageRequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].

## Next steps
Get started with our [File samples][samples].

## Contributing
This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Files%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files/
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/file-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/files/storage-files-introduction
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[StorageRequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src/StorageRequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/file-service-error-codes
[samples]: tests/Samples/