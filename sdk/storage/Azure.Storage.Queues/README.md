# Azure Storage Queues client library for .NET

> Server Version: 2018-11-09

Azure Queue storage is a service for storing large numbers of messages that 
can be accessed from anywhere in the world via authenticated calls using
HTTP or HTTPS.  A single queue message can be up to 64 KB in size, and a
queue can contain millions of messages, up to the total capacity limit of
a storage account.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][rest_docs] | [Product documentation][product_docs]

## Getting started
### Install the package
Install the Azure Storage Queues client library for .NET with [NuGet][nuget]:

```Powershell
Install-Package Azure.Storage.Queues
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a
[Storage Account][storage_account_docs] to use this package.

To create a Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps] or [Azure CLI][storage_account_create_cli]:

## Key concepts
Common uses of Queue storage include:
- Creating a backlog of work to process asynchronously
- Passing messages between different parts of a distributed application

## Examples
### Create a queue
```c#
string connectionString = <connection_string>;
var service = new QueueServiceClient(connectionString);
var queue = service.GetQueueClient("myqueue");

await queue.CreateAsync();
```

### Enqueue messages
```c#
string connectionString = <connection_string>;
var service = new QueueServiceClient(connectionString);
var queue = service.GetQueueClient("myqueue");

var messages = queue.GetMessagesClient();
await messages.EnqueueAsync("Start using Azure");
await messages.EnqueueAsync("Get started with Queues");
```

### Dequeue messages
```c#
string connectionString = <connection_string>;
var service = new QueueServiceClient(connectionString);
var queue = service.GetQueueClient("myqueue");

var messages = queue.GetMessagesClient();
response = await messages.DequeueAsync();
foreach (var message in response.Value)
{
    Console.WriteLine(message.MessageText);
}
```

## Troubleshooting
All Azure Storage Queue service operations will throw a
[StorageRequestFailedException][StorageRequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].

## Next steps
Get started with our [Queue samples][samples].

## Contributing
This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Queues%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues/src
[package]: https://www.nuget.org/packages/Azure.Storage.Queues/
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/queue-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/queues/storage-queues-introduction
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[StorageRequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src/StorageRequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/queue-service-error-codes
[samples]: tests/Samples/