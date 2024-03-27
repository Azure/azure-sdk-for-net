# CoreWCF Azure Queue Storage library

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

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

### Authenticate the service to Azure

In order to receive requests from the Azure Queue Storage service, you'll need to configure CoreWCF with the appropriate endpoint and credentials.  The [Azure Identity library][identity] makes it easy to add Azure Active Directory support for authenticating with Azure services.

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
Learn more about enabling Azure Active Directory for authentication with Azure Storage in [our documentation][storage_ad].  

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
## Key concepts

CoreWCF is an implementation of the service side features of Windows Communication Foundation (WCF) for .NET. The goal of this project is to enable migrating existing WCF services to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://docs.microsoft.com/azure/storage/common/storage-auth-aad
