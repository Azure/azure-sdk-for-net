# WCF Azure Queue Storage client library for .NET

WCF Azure Queue Storage client is the client side library that will enable WCF clients to be able to send requests to a CoreWCF service which uses Azure Queue Storage as a transport. 

## Getting started

### Install the package

Install the Microsoft.WCF.Azure.StorageQueues.Client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.WCF.Azure.StorageQueues.Client --prerelease
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

### Authenticate the service to Azure Queue Storage

To send requests to the Azure Queue Storage service, you'll need to configure WCF with the appropriate endpoint, and configure credentials.  The [Azure Identity library][identity] makes it easy to add Microsoft Entra ID support for authenticating with Azure services.

There are multiple authentication mechanisms for Azure Queue Storage. Which mechanism to use is configured via the property `AzureQueueStorageBinding.Security.Transport.ClientCredentialType`. The default authentication mechanism is `Default` which uses `DefaultAzureCredential`.

```C# Snippet:WCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
// Create a binding instance to use Azure Queue Storage.
// The default client credential type is Default, which uses DefaultAzureCredential
var aqsBinding = new AzureQueueStorageBinding();

// Create a ChannelFactory to using the binding and endpoint address, open it, and create a channel
string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
var factory = new ChannelFactory<IService>(aqsBinding, new EndpointAddress(queueEndpointString));
factory.Open();
IService channel = factory.CreateChannel();

// IService dervies from IChannel so you can call channel.Open without casting
channel.Open();
await channel.SendDataAsync(42);
```

Learn more about enabling Microsoft Entra ID for authentication with Azure Storage in [our documentation][storage_ad].  

### Other authentication credential mechanisms

If you are using a different credential mechanism such as `StorageSharedKeyCredential`, you configure the appropriate `ClientCredentialType` on the binding and set the credential on an `AzureClientCredentials` instance via an extension method.

```C# Snippet:WCF_Azure_Storage_Queus_Sample_StorageSharedKey
// Create a binding instance to use Azure Queue Storage.
var aqsBinding = new AzureQueueStorageBinding();

// Configure the client credential type to use StorageSharedKeyCredential
aqsBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;

// Create a ChannelFactory to using the binding and endpoint address
string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
var factory = new ChannelFactory<IService>(aqsBinding, new EndpointAddress(queueEndpointString));

// Use extension method to configure WCF to use AzureClientCredentials and set the
// StorageSharedKeyCredential instance.
factory.UseAzureCredentials(credentials =>
{
    credentials.StorageSharedKey = GetStorageSharedKey();
});

// Local function to get the StorageSharedKey
StorageSharedKeyCredential GetStorageSharedKey()
{
    // Fetch shared key using a secure mechanism such as Azure Key Vault
    // and construct an instance of StorageSharedKeyCredential to return;
    return default;
}

// Open the factory and create a channel
factory.Open();
IService channel = factory.CreateChannel();

// IService dervies from IChannel so you can call channel.Open without casting
channel.Open();
await channel.SendDataAsync(42);
```

Other values for ClientCredentialType are `Sas`, `Token`, and `ConnectionString`. The credentials class `AzureClientCredentials` has corresponding properties to set each of these credential types.

## Troubleshooting

If there is a problem with sending a request to Azure Queue Storage, the operation call will throw a `CommunicationException` exception. See `CommunicationException.InnerException` for the original exception thrown by the Azure Storage Queues client.

## Key concepts

The goal of this project is to enable migrating existing WCF clients to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

More general samples of using WCF can be found in the [.NET samples repository][dotnet_repo_wcf_samples].
To create a service to receive messages sent to an Azure Storage Queue, see the [Microsoft.CoreWCF.Azure.StorageQueues documentation][corewcf_docs]. 

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
[dotnet_repo_wcf_samples]: https://github.com/dotnet/samples/tree/main/framework/wcf
[corewcf_docs]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/extension-wcf/Microsoft.CoreWCF.Azure.StorageQueues