# CoreWCF Azure Queue Storage library for .NET

CoreWCF Azure Queue Storage is the service side library that will help existing WCF services to be able to use Azure Queue Storage to communicate with clients as a modern replacement to using MSMQ.

## Getting started

### Install the package

Install the Microsoft.CoreWCF.Azure.StorageQueues library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.CoreWCF.Azure.StorageQueues
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```azurecli
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

### Authenticate the service to Azure

In order to receive requests from the Azure Queue Storage service, you'll need to configure CoreWCF with the appropriate endpoint and credentials.  The [Azure Identity library][identity] makes it easy to add Microsoft Entra ID support for authenticating with Azure services.

```C# Snippet:CoreWCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
app.UseServiceModel(services =>
{
    // Configure CoreWCF to dispatch to service type Service
    services.AddService<Service>();
    // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue 
    var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");
    // Configure the client credential type to use DefaultAzureCredential
    binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.Default;
    string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
    services.AddServiceEndpoint<Service, IServiceContract>(aqsBinding, queueEndpointString);
});
```
Learn more about enabling Microsoft Entra ID for authentication with Azure Storage in [our documentation][storage_ad].  

If you are using a different credential mechanism such as `StorageSharedKeyCredential`, you can configure the appropriate `ClientCredentialType` and set the credential on an `AzureServiceCredential` instance via an extension method.
```C# Snippet:CoreWCF_Azure_Storage_Queus_Sample_StorageSharedKey
StorageSharedKeyCredential storageSharedKey = GetStorageSharedKey();
app.UseServiceModel(services =>
{
    // Configure CoreWCF to dispatch to service type Service
    services.AddService<Service>();
    // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue 
    var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");
    // Configure the client credential type to use StorageSharedKeyCredential
    binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;
    string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
    services.AddServiceEndpoint<Service, IServiceContract>(aqsBinding, queueEndpointString);
    services.UseAzureCredentials<Service>(credentials =>
    {
        credentials.StorageSharedKey = storageSharedKey;
    });
});
```

## Troubleshooting

Queue send operations will throw an exception if the operation fails.

```C# Snippet: CoreWCF_Azure_Storage_Queues_Sample_ReceiveMessage_TryCatch

// Receive a message from the queue.
QueueMessage message = null;

try
{
    message = await _client.ReceiveMessageAsync(visibilityTimeout, cancellationToken).ConfigureAwait(false);
}
catch (Exception e)
{
    _logger.LogDebug(Task.CurrentId + "MessageQueue ReceiveMessageAsync: ReceiveMessageAsync failed with error message: " + e.Message);
}
```

## Key concepts

CoreWCF is an implementation of the service side features of Windows Communication Foundation (WCF) for .NET. The goal of this project is to enable migrating existing WCF services to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

## Examples

## Examples

Get started with a sample of CoreWCF https://github.com/CoreWCF/samples

## Next steps

Get started with our examples below:

1. [Sample code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/wcf/Microsoft.CoreWCF.Azure.StorageQueue/tests/IntegrationTests_EndToEnd.cs): Send and receive messages using Azure Storage Queues.)
2. [Auth](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/wcf/Microsoft.CoreWCF.Azure.StorageQueue/tests/AuthenticationTests.cs): Authenticate with shared keys, connection strings and token.

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-account-create?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-account-create?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-account-create?tabs=azure-portal
[azure_cli]: https://learn.microsoft.com/cli/azure/
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://learn.microsoft.com/azure/storage/blobs/authorize-access-azure-active-directory
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://opensource.microsoft.com/cla/
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com