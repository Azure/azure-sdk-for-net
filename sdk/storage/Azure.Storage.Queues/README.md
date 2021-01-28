# Azure Storage Queues client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2019-02-02

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
dotnet add package Azure.Storage.Queues
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

### Send messages

```C# Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_SendMessage
// We'll need a connection string to your Azure Storage account.
// You can obtain your connection string from the Azure Portal
// (click Access Keys under Settings in the Portal Storage account
// blade) or using the Azure CLI with:
//
//     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
//
// You would normally provide the connection string to your
// application using an environment variable.
string connectionString = "<connection_string>";

// Name of the queue we'll send messages to
string queueName = "sample-queue";

// Get a reference to a queue and then create it
QueueClient queue = new QueueClient(connectionString, queueName);
queue.Create();

// Send a message to our queue
queue.SendMessage("Hello, Azure!");
```

### Receive messages

```C# Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_ReceiveMessages
// We'll need a connection string to your Azure Storage account.
string connectionString = "<connection_string>";

// Name of an existing queue we'll operate on
string queueName = "sample-queue";

// Get a reference to a queue and then fill it with messages
QueueClient queue = new QueueClient(connectionString, queueName);
queue.SendMessage("first");
queue.SendMessage("second");
queue.SendMessage("third");

// Get the next messages from the queue
foreach (QueueMessage message in queue.ReceiveMessages(maxMessages: 10).Value)
{
    // "Process" the message
    Console.WriteLine($"Message: {message.Body}");

    // Let the service know we're finished with the message and
    // it can be safely deleted.
    queue.DeleteMessage(message.MessageId, message.PopReceipt);
}
```

### Async APIs

We fully support both synchronous and asynchronous APIs.

```C# Snippet:Azure_Storage_Queues_Samples_Sample01b_HelloWorld_SendMessageAsync
// We'll need a connection string to your Azure Storage account.
string connectionString = "<connection_string>";

// Name of the queue we'll send messages to
string queueName = "sample-queue";

// Get a reference to a queue and then create it
QueueClient queue = new QueueClient(connectionString, queueName);
await queue.CreateAsync();

// Send a message to our queue
await queue.SendMessageAsync("Hello, Azure!");
```

### Authenticating with Azure.Identity

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

```C# Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_IdentityAuth
// Create a QueueClient that will authenticate through Active Directory
Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
QueueClient queue = new QueueClient(accountUri, new DefaultAzureCredential());
```

Learn more about enabling Azure Active Directory for authentication with Azure Storage in [our documentation][storage_ad] and [our samples](#next-steps).

## Troubleshooting

All Azure Storage Queue service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.

```C# Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_Errors
// We'll need a connection string to your Azure Storage account.
string connectionString = "<connection_string>";

// Name of an existing queue we'll operate on
string queueName = "sample-queue";

try
{
    // Try to create a queue that already exists
    QueueClient queue = new QueueClient(connectionString, queueName);
    queue.Create();
}
catch (RequestFailedException ex)
    when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
{
    // Ignore any errors if the queue already exists
}
```

## Next steps

Get started with our [Queue samples][samples]:

1. [Hello World](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/samples/Sample01a_HelloWorld.cs): Enqueue, Dequeue, Peek, and Update queue messages (or [asynchronously](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/samples/Sample02_Auth.cs): Authenticate with connection strings, shared keys, shared access signatures, and Azure Active Directory.

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
[docs]: https://docs.microsoft.com/dotnet/api/azure.storage.queues
[rest_docs]: https://docs.microsoft.com/rest/api/storageservices/queue-service-rest-api
[product_docs]: https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://docs.microsoft.com/azure/storage/common/storage-auth-aad
[storage_ad_sample]: samples/Sample02c_Auth_ActiveDirectory.cs
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/queue-service-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/samples/
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
