# CoreWCF Azure Queue Storage library

CoreWCF Azure Queue Storage  is the sertvice side library that will help existing WCF services to be able to use Azure Queue Storage to communicate with clients instead of using MSMQ.

## Getting started

### Install the package

Install the Azure.CoreWCF.AzureQueueStorage library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.CoreWCF.AzureQueueStorage
```

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing [Configuration Store][configuration_store].

If you need to create a Configuration Store, you can use the Azure Portal or [Azure CLI][azure_cli].

You can use the Azure CLI to create the Configuration Store with the following command:

```PowerShell
az appconfig create --name <config-store-name> --resource-group <resource-group-name> --location eastus
```

### Authenticate the client

In order to interact with the App Configuration service, you'll need to create an instance of the [Configuration Client][configuration_client_class] class. To make this possible, you'll need the connection string of the Configuration Store.

#### Get credentials

Use the snippet below to get the connection string from the Configuration Store.

```PowerShell
az appconfig credential list --name <config-store-name>
```

Alternatively, get the connection string from the Azure Portal.

#### Choose AzureQueueStorageMessageEncoding

Use one of the Message Encoding available.

```C#
public enum AzureQueueStorageMessageEncoding
{
    /// <summary>
    /// Indicates using Binary message encoder.
    /// </summary>
    Binary,

    /// <summary>
    /// Indicates using Text message encoder.
    /// </summary>
    Text,
}
```

#### Create AzureQueueStorageBinding

Once you have the value of the connection string, you can create the AzureQueueStorageBinding by also passing in an optional dead letter queue name:

```C# Snippet:CreateConfigurationClient
string connectionString = "<connection_string>";
string deadletterQueueName = "<queue_name>";
app.UseServiceModel(services =>
{
    services.AddService<ServiceContract>();
    services.AddServiceEndpoint<ServiceContract, IServiceContract>(new AzureQueueStorageBinding(connectionString, deadLetterQueueName)
    {
        MessageEncoding = AzureQueueStorageMessageEncoding.Binary
    },
    endpointUrlString);
});
```

#### Get the service and receive messages.

```C# Snippet
var serviceContract = host.Services.GetRequiredService<ServiceContract>();
var message = serviceContract.ReceiveMessages();
```

## Key concepts

CoreWCF is a port of the service side of Windows Communication Foundation (WCF) to .NET Core. The goal of this project is to enable existing WCF services to be able to use Azure Queue Storage to communiate with clients.
