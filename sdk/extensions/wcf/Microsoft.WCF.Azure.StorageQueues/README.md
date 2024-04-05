# WCF Azure Queue Storage client library for .NET

WCF Azure Queue Storage client is the client side library that will enable WCF clients to be able to send requests to a CoreWCF service which uses Azure Queue Storage as a transport. 

## Getting started

### Install the package

Install the Azure.WCF.AzureQueueStorage.Client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.WCF.Azure.StorageQueues.Client
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

### Authenticate the client

In order to send requests to the Azure Queue Storage service, you'll need to configure WCF with the appropriate endpoint and credentials.  The [Azure Identity library][identity] makes it easy to add Microsoft Entra ID support for authenticating with Azure services.

```C# Snippet:WCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
// Create a binding instance to use Azure Queue Storage
var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");
// Configure the client credential type to use DefaultAzureCredential
binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.Default;

await using(var factory = new ChannelFactory<IServiceContract>(aqsBinding, new EndpointAddress(queueEndpointString)))
{
    factory.Open();
    await using (IServiceContract client = factory.CreateChannel())
    {
        ((System.ServiceModel.Channels.IChannel)channel).Open();
        await client.SendAsync("Hello World!");
    }
}
```
Learn more about enabling Microsoft Entra ID for authentication with Azure Storage in [our documentation][storage_ad].  

If you are using a different credential mechanism such as `StorageSharedKeyCredential`, you can configure the appropriate `ClientCredentialType` and set the credential on an `AzureServiceCredential` instance via an extension method.
```C# Snippet:WCF_Azure_Storage_Queus_Sample_StorageSharedKey
StorageSharedKeyCredential storageSharedKey = GetStorageSharedKey();
string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
// Create a binding instance to use Azure Queue Storage
var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");
// Configure the client credential type to use StorageSharedKeyCredential
binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;

await using(var factory = new ChannelFactory<IServiceContract>(aqsBinding, new EndpointAddress(queueEndpointString)))
{
    channelFactory.UseAzureCredentials(credentials =>
    {
        credentials.StorageSharedKey = storageSharedKey;
    });

    factory.Open();
    await using (IServiceContract client = factory.CreateChannel())
    {
        ((System.ServiceModel.Channels.IChannel)channel).Open();
        await client.SendAsync("Hello World!");
    }
}
```

## Troubleshooting

Queue send operations will throw an exception if the operation fails.

```C# Snippet: WCF_Azure_Storage_Queues_Sample_SendMessage_TryCatch

// Try to send a message to the queue.
try
{
    ArraySegment<byte> messageBuffer = EncodeMessage(message);
    BinaryData binaryData = new(new ReadOnlyMemory<byte>(messageBuffer.Array, messageBuffer.Offset, messageBuffer.Count));
    _queueClient.SendMessage(binaryData, default, default, cts.Token);
}
catch (Exception e)
{
    throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
}
```

## Key concepts

The goal of this project is to enable migrating existing WCF clients to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

## Examples

Get started with a sample of CoreWCF https://github.com/CoreWCF/samples


## Next steps

Get started with our examples below:

1. [Sample code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/wcf/Microsoft.WCF.Azure.StorageQueues/tests/IntegrationTests.cs): Send and receive messages using Azure Storage Queues.)
2. [Auth](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/wcf/Microsoft.WCF.Azure.StorageQueues/tests/AuthenticationTests.cs): Authenticate with shared keys, connection strings and token.

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
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://learn.microsoft.com/azure/storage/blobs/authorize-access-azure-active-directory
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://opensource.microsoft.com/cla/
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com