# WCF Azure Queue Storage client library

WCF Azure Queue Storage client is the client side library that will help WCF clients to be able to use Azure Queue Storage instead of using MSMQ.

## Getting started

### Install the package

Install the Azure.WCF.AzureQueueStorage.Client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.WCF.AzureQueueStorage.Client
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

Once you have the value of the connection string, you can create the AzureQueueStorageBinding by also passing in a encoding type:

```C# Snippet:CreateConfigurationClient
string connectionString = "<connection_string>";
AzureQueueStorageMessageEncoding encoding = <AzureQueueStorageMessageEncoding>;
AzureQueueStorageBinding azureQueueStorageBinding = new(connectionString, encoding);
```

#### Create ChannelFactory and communicate with Queue

```C# Snippet
Var endpointUrl = <Url_of_Queue>;
 var factory = new ChannelFactory<IServiceContract>(binding, new EndpointAddress(endpointUrl));
            factory.Open();
            try
            {
                IServiceContract client = factory.CreateChannel();
                ((System.ServiceModel.Channels.IChannel)channel).Open();
                await client.Send("Hello World!");
                channel.Close();
            }
            finally
            {
                factory.Close();
            }
```

## Key concepts

The goal of this project is to enable WCF clients to be able to use Azure Queue Storage.


