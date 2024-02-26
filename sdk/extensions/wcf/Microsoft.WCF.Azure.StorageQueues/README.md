# WCF Azure Queue Storage client library

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

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

### Authenticate the client

In order to send requests to the Azure Queue Storage service, you'll need to configure WCF with the appropriate endpoint and credentials.  The [Azure Identity library][identity] makes it easy to add Azure Active Directory support for authenticating with Azure services.

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
Learn more about enabling Azure Active Directory for authentication with Azure Storage in [our documentation][storage_ad].  

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

## Key concepts

The goal of this project is to enable migrating existing WCF clients to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://docs.microsoft.com/azure/storage/common/storage-auth-aad