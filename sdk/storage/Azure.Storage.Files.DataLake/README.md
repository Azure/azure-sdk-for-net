# Azure Storage Files Data Lake client library for .NET

> Server Version: 2019-02-02

Azure Data Lake includes all the capabilities required to make it easy for developers, data scientists, 
and analysts to store data of any size, shape, and speed, and do all types of processing and analytics 
across platforms and languages. It removes the complexities of ingesting and storing all of your data
while making it faster to get up and running with batch, streaming, and interactive analytics.

[Source code][source] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Files Data Lake client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Storage.Files.DataLake --version 12.0.0-preview.5
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

This preview package for .NET includes ADLS Gen2 specific API support made available in Blob SDK. This includes:
1. New directory level operations (Create, Rename/Move, Delete) for both hierarchical namespace enabled (HNS) storage accounts and HNS disabled storage accounts. For HNS enabled accounts, the rename/move operations are atomic.
2. Permission related operations (Get/Set ACLs) for hierarchical namespace enabled (HNS) accounts. 

HNS enabled accounts in ADLS Gen2 can also now leverage all of the operations available in Blob SDK. Support for File level semantics for ADLS Gen2 is planned to be made available in Blob SDK in a later release. In the meantime, please find below mapping for ADLS Gen2 terminology to Blob terminology

|ADLS Gen2 	 | Blob       |
| ---------- | ---------- |
|Filesystem	 | Container  | 
|Folder	   	 | Directory  |
|File		 | Blob       |

## Examples

### Create a DataLakeServiceClient
```C# Snippet:SampleSnippetDataLakeServiceClient_Create
// Make StorageSharedKeyCredential to pass to the serviceClient
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(<storage-account-name>, <storage-account-key>);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(<endpoint-storage-dfs-url>, sharedKeyCredential);
```

### Create a DataLakeFileSystemClient
```C# Snippet:SampleSnippetDataLakeFileSystemClient_Create
// Make StorageSharedKeyCredential to pass to the serviceClient
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(<storage-account-name>, <storage-account-key>);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(<endpoint-storage-dfs-url>, sharedKeyCredential);

// Create a DataLakeFileSystemClient
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();
```

### Create a DataLakeDirectoryClient
```C# Snippet:SampleSnippetDataLakeDirectoryClient_Create
// Make StorageSharedKeyCredential to pass to the serviceClient
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(<storage-account-name>, <storage-account-key>);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(<endpoint-storage-dfs-url>, sharedKeyCredential);

// Get a reference to a filesystem named "sample-filesystem" and then create it
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();

// Create a DataLakeDirectoryClient
DataLakeDirectoryClient directory = filesystem.CreateDirectory("sample-directory");
directory.Create();
```

### Create a DataLakeFileClient

Create DataLakeFileClient from a DataLakeDirectoryClient

```C# Snippet:SampleSnippetDataLakeFileClient_Create
// Make StorageSharedKeyCredential to pass to the serviceClient
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(<storage-account-name>, <storage-account-key>);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(<endpoint-storage-dfs-url>, sharedKeyCredential);

// Get a reference to a filesystem named "sample-filesystem" and then create it
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();

// Create a DataLakeDirectoryClient
DataLakeDirectoryClient directory = filesystem.CreateDirectory("sample-directory");
directory.Create();

// Create a DataLakeFileClient
DataLakeFileClient file = directory.CreateFile("sample-file");
file.Create();
```

Create DataLakeFileClient from a DataLakeFileSystemClient
```C# Snippet:SampleSnippetDataLakeFileClient_Create
// Make StorageSharedKeyCredential to pass to the serviceClient
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(<endpoint-storage-dfs-url>, sharedKeyCredential);

// Get a reference to a filesystem named "sample-filesystem" and then create it
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();

// Create a DataLakeFileClient
DataLakeFileClient file = filesystem.CreateDirectory("sample-file");
file.Create();
```

### Appending Data to a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_Append
// FileAppend usage - e.g. file.Append(<stream-to-file-content>, <offset>)
// Create a DataLakeFileClient
DataLakeFileClient file = filesystem.CreateDirectory("sample-file");
file.Create();

// Append data to the DataLake File
file.Append(File.OpenRead(<path-to-file>, 0);
file.Flush(<length-of-file>);
```

### Reading Data from a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_Read
// Reading data to the DataLake File
Response<FileDownloadInfo> fileContents = file.Read();
```

### Listing/Traversing through a DataLake Filesystem
```C# Snippet:SampleSnippetDataLakeFileClient_List
// Listing/Traversing through a DataLake Filesystem
foreach (PathItem pathItem in filesystem.ListPaths(recursive: true))
{
    Console.WriteLine(pathItem.Name);
}
```
### Set Permissions on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_SetPermissions
// Create a DataLake file so we can set the Access Controls on the files
DataLakeFileClient fileClient = filesystem.GetFileClient(Randomize("sample-file"));
fileClient.Create();

// Set the Permissions of the file
fileClient.SetPermissions(permissions: "rwxrwxrwx");
```
### Set Access Controls (ACLs) on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_SetAcls
// Set the Permissions of the file
fileClient.SetAccessControl("user::rwx,group::r--,mask::rwx,other::---");
```
### Get Access Controls (ACLs) on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_GetAcls
// Get the Permissions of the file
PathAccessControl accessControlResponse = fileClient.GetAccessControl();
```
### Rename a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_RenameFile
// Rename File Client
DataLakeDirectoryClient renamedDirectoryClient = fileClient.Rename("new-file-name");
```
### Rename a DataLake Directory
```C# Snippet:SampleSnippetDataLakeFileClient_RenameDirectory
// Rename File Client
DataLakeDirectoryClient renamedDirectoryClient = directoryClient.Rename("new-directory-name");
```
### Get Properties on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_GetProperties
// Get Properties on DataLake File
PathProperties pathProperties = FileClient.GetProperties();
```
### Get Properties on a DataLake Directory
```C# Snippet:SampleSnippetDataLakeDirectoryClient_GetProperties
// Get Properties on DataLake Directory
PathProperties pathProperties = DirectoryClient.GetProperties();
```
## Troubleshooting

All File DataLake service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.

## Next steps

Get started with our [DataLake samples][samples]:

1. [Hello World](samples/Sample01a_HelloWorld.cs): Append, Read, and List DataLake Files (or [asynchronously](samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](samples/Sample02_Auth.cs): Authenticate with public access, shared keys, shared access signatures, and Azure Active Directory.

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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Files.DataLake%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files.DataLake/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files.DataLake/
[docs]: https://azure.github.io/azure-sdk-for-net/storage.html
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/filesystem
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/blobs/?toc=%2fazure%2fstorage%2fblobs%2ftoc.json
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/blob-service-error-codes
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[samples]: samples