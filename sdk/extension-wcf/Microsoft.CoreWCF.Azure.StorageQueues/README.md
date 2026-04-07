# CoreWCF Azure Queue Storage library for .NET

CoreWCF Azure Queue Storage is the service side library that will help existing WCF services to be able to use Azure Queue Storage to communicate with clients as a modern replacement to using MSMQ.

## Getting started

### Install the package

Install the Microsoft.CoreWCF.Azure.StorageQueues library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.CoreWCF.Azure.StorageQueues --prerelease
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

### Configure ASP.NET Core to use CoreWCF with Queue transports

In order to receive requests from the Azure Queue Storage service, you'll need to configure CoreWCF to use queue transports.

```C# Snippet:Configure_CoreWCF_QueueTransport
public void ConfigureServices(IServiceCollection services)
{
    services.AddServiceModelServices()
            .AddQueueTransport();
}
```

### Authenticate the service to Azure Queue Storage

To receive requests from the Azure Queue Storage service, you'll need to configure CoreWCF with the appropriate endpoint, and configure credentials.  The [Azure Identity library][identity] makes it easy to add Microsoft Entra ID support for authenticating with Azure services.  

There are multiple authentication mechanisms for Azure Queue Storage. Which mechanism to use is configured via the property `AzureQueueStorageBinding.Security.Transport.ClientCredentialType`. The default authentication mechanism is `Default`, which uses `DefaultAzureCredential`.

```C# Snippet:CoreWCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
public void Configure(IApplicationBuilder app)
{
    app.UseServiceModel(serviceBuilder =>
    {
        // Configure CoreWCF to dispatch to service type Service
        serviceBuilder.AddService<Service>();

        // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue
        // The default client credential type is Default, which uses DefaultAzureCredential
        var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");

        // Add a service endpoint using the AzureQueueStorageBinding
        string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
        serviceBuilder.AddServiceEndpoint<Service, IService>(aqsBinding, queueEndpointString);
    });
}
```

Learn more about enabling Microsoft Entra ID for authentication with Azure Storage in [our documentation][storage_ad].  

### Other authentication credential mechanisms

If you are using a different credential mechanism such as `StorageSharedKeyCredential`, you configure the appropriate `ClientCredentialType` on the binding and set the credential on an `AzureServiceCredentials` instance via an extension method.

```C# Snippet:CoreWCF_Azure_Storage_Queus_Sample_StorageSharedKey
public void Configure(IApplicationBuilder app)
{
    app.UseServiceModel(serviceBuilder =>
    {
        // Configure CoreWCF to dispatch to service type Service
        serviceBuilder.AddService<Service>();

        // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue
        var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");

        // Configure the client credential type to use StorageSharedKeyCredential
        aqsBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;

        // Add a service endpoint using the AzureQueueStorageBinding
        string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
        serviceBuilder.AddServiceEndpoint<Service, IService>(aqsBinding, queueEndpointString);

        // Use extension method to configure CoreWCF to use AzureServiceCredentials and set the
        // StorageSharedKeyCredential instance.
        serviceBuilder.UseAzureCredentials<Service>(credentials =>
        {
            credentials.StorageSharedKey = GetStorageSharedKey();
        });
    });
}

public StorageSharedKeyCredential GetStorageSharedKey()
{
    // Fetch shared key using a secure mechanism such as Azure Key Vault
    // and construct an instance of StorageSharedKeyCredential to return;
    return default;
}
```

Other values for ClientCredentialType are `Sas`, `Token`, and `ConnectionString`. The credentials class `AzureServiceCredentials` has corresponding properties to set each of these credential types.

## Troubleshooting

If there are any errors receiving a message from Azure Queue Storage, the CoreWCF transport will log the details at the `Debug` log level. You can configure logging for the category `Microsoft.CoreWCF` at the `Debug` level to see any errors.

```C# Snippet:CoreWCF_Azure_Storage_Queus_Sample_Logging
.ConfigureLogging((logging) =>
{
    logging.AddFilter("Microsoft.CoreWCF", LogLevel.Debug);
});
```

If a message was recevied from the queue, but wasn't able to be processed, it will be placed in the dead letter queue. You can sepcify the dead letter queue name by passing it to the constructor of `AzureQueueStorageBinding`. If not specified, the default value of `default-dead-letter-queue` will be used.

## Key concepts

CoreWCF is an implementation of the service side features of Windows Communication Foundation (WCF) for .NET. The goal of this project is to enable migrating existing WCF services to .NET that are currently using MSMQ and wish to deploy their service to Azure, replacing MSMQ with Azure Queue Storage.

More general samples of using CoreWCF can be found in the [CoreWCF samples repository][corewcf_repo]. To create a client to send messages to an Azure Storage Queue, see the[Microsoft.WCF.Azure.StorageQueues documentation][wcf_docs]. 

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
[corewcf_repo]: https://github.com/CoreWCF/samples/
[wcf_docs]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/extension-wcf/Microsoft.WCF.Azure.StorageQueues