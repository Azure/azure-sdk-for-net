# Azure Storage Files client library for .NET

> Server Version: 2019-02-02

Azure Files offers fully managed file shares in the cloud that are accessible
via the industry standard Server Message Block (SMB) protocol. Azure file
shares can be mounted concurrently by cloud or on-premises deployments of
Windows, Linux, and macOS. Additionally, Azure file shares can be cached on
Windows Servers with Azure File Sync for fast access near where the data is
being used.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Files client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Storage.Files.Shares --version 12.0.0-preview.4
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

## Key concepts

Azure file shares can be used to:

- Completely replace or supplement traditional on-premises file servers or NAS devices.
- "Lift and shift" applications to the cloud that expect a file share to store file application or user data.
- Simplify new cloud development projects with shared application settings, diagnostic shares, and Dev/Test/Debug tool file shares.

## Examples

### Create a share and upload a file

```c#
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

// Get a connection string to our Azure Storage account.  You can
// obtain your connection string from the Azure Portal (click
// Access Keys under Settings in the Portal Storage account blade)
// or using the Azure CLI with:
//
//     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
//
// And you can provide the connection string to your application
// using an environment variable.
string connectionString = "<connection_string>";

// Get a reference to a share named "sample-share" and then create it
ShareClient share = new ShareClient(connectionString, "sample-share");
share.Create();

// Get a reference to a directory named "sample-dir" and then create it
ShareDirectoryClient directory = share.GetDirectoryClient("sample-dir");
directory.Create();

// Get a reference to a file named "sample-file" in directory "sample-dir"
ShareFileClient file = directory.GetFileClient("sample-file");

// Upload the file
using (FileStream stream = File.OpenRead("local-file.txt"))
{
    file.Create(stream.Length);
    file.UploadRange(
        ShareFileRangeWriteType.Update,
        new HttpRange(0, stream.Length),
        stream);
}
```

### Download a file

```c#
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";

// Get a reference to a share named "sample-share"
ShareClient share = new ShareClient(connectionString, "sample-share");

// Get a reference to a directory named "sample-dir"
ShareDirectoryClient directory = share.GetDirectoryClient("sample-dir");

// Get a reference to a file named "sample-file" in directory "sample-dir"
ShareFileClient file = directory.GetFileClient("sample-file");

// Download the file
ShareFileDownloadInfo download = file.Download();
using (FileStream stream = File.OpenWrite("downloaded-file.txt"))
{
    download.Content.CopyTo(stream);
}
```

### Traverse a share

```c#
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";

// Get a reference to a share named "sample-share"
ShareClient share = new ShareClient(connectionString, "sample-share");

// Track the remaining directories to walk, starting from the root
Queue<ShareDirectoryClient> remaining = new Queue<ShareDirectoryClient>();
remaining.Enqueue(share.GetRootDirectoryClient());
while (remaining.Count > 0)
{
    // Get all of the next directory's files and subdirectories
    ShareDirectoryClient dir = remaining.Dequeue();
    foreach (ShareFileItem item in dir.GetFilesAndDirectories())
    {
        Console.WriteLine(item.Name);

        // Keep walking down directories
        if (item.IsDirectory)
        {
            remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
        }
    }
}
```

### Async APIs

We fully support both synchronous and asynchronous APIs.

```c#
string connectionString = "<connection_string>";
ShareClient share = new ShareClient(connectionString, "sample-share");
ShareDirectoryClient directory = share.GetDirectoryClient("sample-dir");
ShareFileClient file = directory.GetFileClient("sample-file");

// Download the file
ShareFileDownloadInfo download = await file.DownloadAsync();
using (FileStream stream = File.OpenWrite("downloaded-file.txt"))
{
    await download.Content.CopyToAsync(stream);
}
```

## Troubleshooting

All Azure Storage File service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.

```c#
// Get a connection string to our Azure Storage account
string connectionString = "<connection_string>";

// Try to create a share named "sample-share" and avoid any potential race
// conditions that might arise by checking if the share exists before creating
ShareClient share = new ShareClient(connectionString, "sample-share");
try
{
    share.Create();
}
catch (RequestFailedException ex)
    when (ex.ErrorCode == FileErrorCode.ShareAlreadyExists)
{
    // Ignore any errors if the share already exists
}
```

## Next steps

Get started with our [File samples][samples]:

1. [Hello World](samples/Sample01a_HelloWorld.cs): Upload files, download files, and traverse shares (or [asynchronously](samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](samples/Sample02_Auth.cs): Authenticate with connection strings, shared keys, and shared access signatures.

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Files.Shares%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files.Shares/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files.Shares/
[docs]: https://azure.github.io/azure-sdk-for-net/storage.html
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/file-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/files/storage-files-introduction
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/file-service-error-codes
[samples]: samples/
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
