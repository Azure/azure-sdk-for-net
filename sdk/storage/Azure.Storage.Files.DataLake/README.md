# Azure Storage Files Data Lake client library for .NET

> Server Version: 2021-02-12, 2020-12-06, 2020-10-02, 2020-08-04, 2020-06-12, 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2019-02-02

Azure Data Lake includes all the capabilities required to make it easy for developers, data scientists,
and analysts to store data of any size, shape, and speed, and do all types of processing and analytics
across platforms and languages. It removes the complexities of ingesting and storing all of your data
while making it faster to get up and running with batch, streaming, and interactive analytics.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Files Data Lake client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Storage.Files.DataLake
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

DataLake Storage Gen2 was designed to:
- Service multiple petabytes of information while sustaining hundreds of gigabits of throughput
- Allow you to easily manage massive amounts of data

Key Features of DataLake Storage Gen2 include:
- Hadoop compatible access
- A superset of POSIX permissions
- Cost effective in terms of low-cost storage capacity and transactions
- Optimized driver for big data analytics

A fundamental part of Data Lake Storage Gen2 is the addition of a hierarchical namespace to Blob storage. The hierarchical namespace organizes objects/files into a hierarchy of directories for efficient data access.

In the past, cloud-based analytics had to compromise in areas of performance, management, and security. Data Lake Storage Gen2 addresses each of these aspects in the following ways:
- Performance is optimized because you do not need to copy or transform data as a prerequisite for analysis. The hierarchical namespace greatly improves the performance of directory management operations, which improves overall job performance.
- Management is easier because you can organize and manipulate files through directories and subdirectories.
- Security is enforceable because you can define POSIX permissions on directories or individual files.
- Cost effectiveness is made possible as Data Lake Storage Gen2 is built on top of the low-cost Azure Blob storage. The additional features further lower the total cost of ownership for running big data analytics on Azure.

Data Lake Storage Gen2 offers two types of resources:

- The _filesystem_ used via 'DataLakeFileSystemClient'
- The _path_ used via 'DataLakeFileClient' or 'DataLakeDirectoryClient'

|ADLS Gen2 	                | Blob       |
| --------------------------| ---------- |
|Filesystem                 | Container  |
|Path (File or Directory)   | Blob       |

Note: This client library does not support hierarchical namespace (HNS) disabled storage accounts.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Create a DataLakeServiceClient
```C# Snippet:SampleSnippetDataLakeServiceClient_Create
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);
```

### Create a DataLakeFileSystemClient
```C# Snippet:SampleSnippetDataLakeFileSystemClient_Create
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

// Create a DataLake Filesystem
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();
```

### Create a DataLakeDirectoryClient
```C# Snippet:SampleSnippetDataLakeDirectoryClient_Create
StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

// Create DataLakeServiceClient using StorageSharedKeyCredentials
DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

// Get a reference to a filesystem named "sample-filesystem-append" and then create it
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-append");
filesystem.Create();

// Create
DataLakeDirectoryClient directory = filesystem.GetDirectoryClient("sample-file");
directory.Create();
```

### Create a DataLakeFileClient

Create DataLakeFileClient from a DataLakeDirectoryClient
```C# Snippet:SampleSnippetDataLakeFileClient_Create_Directory
// Create a DataLake Directory
DataLakeDirectoryClient directory = filesystem.CreateDirectory("sample-directory");
directory.Create();

// Create a DataLake File using a DataLake Directory
DataLakeFileClient file = directory.GetFileClient("sample-file");
file.Create();
```

Create DataLakeFileClient from a DataLakeFileSystemClient
```C# Snippet:SampleSnippetDataLakeFileClient_Create
// Create a DataLake Filesystem
DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
filesystem.Create();

// Create a DataLake file using a DataLake Filesystem
DataLakeFileClient file = filesystem.GetFileClient("sample-file");
file.Create();
```

### Appending Data to a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_Append
// Create a file
DataLakeFileClient file = filesystem.GetFileClient("sample-file");
file.Create();

// Append data to the DataLake File
file.Append(File.OpenRead(sampleFilePath), 0);
file.Flush(SampleFileContent.Length);
```

### Reading Data from a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_Read
Response<FileDownloadInfo> fileContents = file.Read();
```

### Reading Streaming Data from a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_ReadStreaming
Response<DataLakeFileReadStreamingResult> fileContents = file.ReadStreaming();
Stream readStream = fileContents.Value.Content;
```

### Reading Content Data from a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_ReadContent
Response<DataLakeFileReadResult> fileContents = file.ReadContent();
BinaryData readData = fileContents.Value.Content;
```

### Listing/Traversing through a DataLake Filesystem
```C# Snippet:SampleSnippetDataLakeFileClient_List
foreach (PathItem pathItem in filesystem.GetPaths())
{
    names.Add(pathItem.Name);
}
```

### Set Permissions on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_SetPermissions
// Create a DataLake file so we can set the Access Controls on the files
DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
fileClient.Create();

// Set the Permissions of the file
PathPermissions pathPermissions = PathPermissions.ParseSymbolicPermissions("rwxrwxrwx");
fileClient.SetPermissions(permissions: pathPermissions);
```

### Set Access Controls (ACLs) on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_SetAcls
// Create a DataLake file so we can set the Access Controls on the files
DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
fileClient.Create();

// Set Access Control List
IList<PathAccessControlItem> accessControlList
    = PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,mask::rwx,other::---");
fileClient.SetAccessControlList(accessControlList);
```

### Get Access Controls (ACLs) on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_GetAcls
// Get Access Control List
PathAccessControl accessControlResponse = fileClient.GetAccessControl();
```

### Rename a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_RenameFile
DataLakeFileClient renamedFileClient = fileClient.Rename("sample-file2");
```

### Rename a DataLake Directory
```C# Snippet:SampleSnippetDataLakeFileClient_RenameDirectory
DataLakeDirectoryClient renamedDirectoryClient = directoryClient.Rename("sample-directory2");
```

### Get Properties on a DataLake File
```C# Snippet:SampleSnippetDataLakeFileClient_GetProperties
// Get Properties on a File
PathProperties filePathProperties = fileClient.GetProperties();
```
### Get Properties on a DataLake Directory
```C# Snippet:SampleSnippetDataLakeDirectoryClient_GetProperties
// Get Properties on a Directory
PathProperties directoryPathProperties = directoryClient.GetProperties();
```

## Troubleshooting

All File DataLake service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.
If multiple failures occur, an [AggregateException][AggregateException] will be thrown,
containing each failure instance.

## Next steps

Get started with our [DataLake samples][samples]:

1. [Hello World](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples/Sample01a_HelloWorld.cs): Append, Read, and List DataLake Files (or [asynchronously](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples/Sample02_Auth.cs): Authenticate with public access, shared keys, shared access signatures, and Azure Active Directory.

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

<!-- LINKS -->
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.DataLake/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files.DataLake/
[docs]: https://learn.microsoft.com/dotnet/api/azure.storage.files.datalake
[rest_docs]: https://learn.microsoft.com/rest/api/storageservices/datalakestoragegen2/filesystem
[product_docs]: https://learn.microsoft.com/azure/storage/blobs/?toc=%2fazure%2fstorage%2fblobs%2ftoc.json
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/blob-service-error-codes
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Files.DataLake/samples
[AggregateException]: https://learn.microsoft.com/dotnet/api/system.aggregateexception?view=net-9.0
