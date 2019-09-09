# Azure Storage Queues client library for .NET

> Server Version: 2018-11-09

Azure Queue storage is a service for storing large numbers of messages that 
can be accessed from anywhere in the world via authenticated calls using
HTTP or HTTPS.  A single queue message can be up to 64 KB in size, and a
queue can contain millions of messages, up to the total capacity limit of
a storage account.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Queues client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Storage.Queues --version 12.0.0-preview.1
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

Common uses of Queue storage include:

- Creating a backlog of work to process asynchronously
- Passing messages between different parts of a distributed application

## Examples

### Enqueue messages

```c#
using Azure.Storage;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

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

// Get a reference to a queue named "sample-queue" and then create it
QueueClient queue = new QueueClient(connectionString, "sample-queue");
queue.Create();

// Add a message to our queue
queue.EnqueueMessage("Hello, Azure!");
```

### Dequeue messages

```c#
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";

// Get a reference to a queue named "sample-queue" and then create it
QueueClient queue = new QueueClient(connectionString, "sample-queue");
queue.Create();

// Add several messages to the queue
queue.EnqueueMessage("first");
queue.EnqueueMessage("second");
queue.EnqueueMessage("third");

// Get the next 10 messages from the queue
foreach (DequeuedMessage message in queue.DequeueMessages(maxMessages: 10).Value)
{
    // "Process" the message
    Console.WriteLine(message.MessageText)

    // Let the service know we finished with the message and
    // it can be safely deleted.
    queue.DeleteMessage(message.MessageId, message.PopReceipt);
}
```

### Async APIs

We fully support both synchronous and asynchronous APIs.

```c#
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";

// Get a reference to a queue named "sample-queue" and then create it
QueueClient queue = new QueueClient(connectionString, "sample-queue");
await queue.CreateAsync();

// Add a message to our queue
await queue.EnqueueMessageAsync("Hello, Azure!");
```

### Authenticating with Azure.Identity

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

```c#
using Azure.Identity;

// Create a QueueClient that will authenticate through Active Directory
Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
QueueClient queue = new QueueClient(accountUri, new DefaultAzureCredential());
```

Learn more about enabling Azure Active Directory for authentication with Azure Storage in [our documentation][storage_ad] and [our samples](#next-steps).

## Troubleshooting

All Azure Storage Queue service operations will throw a
[StorageRequestFailedException][StorageRequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.

```c#
// Get a connection string to our Azure Storage account
string connectionString = "<connection_string>";

// Try to create a queue named "sample-queue" and avoid any potential race
// conditions that might arise by checking if the queue exists before creating
QueueClient queue = new QueueClient(connectionString, "sample-queue");
try
{
    queue.Create();
}
catch (StorageRequestFailedException ex)
    when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
{
    // Ignore any errors if the queue already exists
}
```

## Next steps

Get started with our [Queue samples][samples]:

1. [Hello World](samples/Sample01a_HelloWorld.cs): Enqueue, Dequeue, Peek, and Update queue messages (or [asynchronously](samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](samples/Sample02_Auth.cs): Authenticate with connection strings, shared keys, shared access signatures, and Azure Active Directory.

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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Queues%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues/src
[package]: https://www.nuget.org/packages/Azure.Storage.Queues/
[docs]: https://azure.github.io/azure-sdk-for-net/api/Storage/Azure.Storage.Queues.html
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/queue-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/queues/storage-queues-introduction
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad
[storage_ad_sample]: samples/Sample02c_Auth_ActiveDirectory.cs
[StorageRequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src/StorageRequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/queue-service-error-codes
[samples]: samples/
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
