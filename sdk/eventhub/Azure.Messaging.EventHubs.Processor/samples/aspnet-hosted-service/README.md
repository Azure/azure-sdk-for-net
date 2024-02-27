---
page_type: sample
languages:
- csharp
products:
- azure
- azure-event-hubs
name: Using the EventProcessorClient with an ASP.NET hosted service
description: Using the EventProcessorClient with an ASP.NET hosted service
---

# Using the `EventProcessorClient` with an ASP.NET hosted service

This is an example of how to create and configure the `EventProcessorClient` in an ASP.NET context as an `IHostedService` implementation.  ASP.NET hosted services can be used to implement background task processing, making them a good choice if your application needs to continually process events from Azure Event Hubs.  For more information, please see the [hosted services documentation](https://learn.microsoft.com/aspnet/core/fundamentals/host/hosted-services).

The [Azure.Messaging.EventHubs.Processor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/README.md) package provides a stand-alone client for consuming events in a robust, durable, and scalable way that is suitable for the majority of production scenarios.

## Getting Started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account)).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://learn.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  The Azure Storage account used for the processor should have soft delete and blob versioning disabled.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

- **Azure Storage blob container:** Checkpoint and ownership data in Azure Storage will be written to blobs in a specific container.  The `EventProcessorClient` requires an existing container and will not implicitly create one to help guard against accidental misconfiguration.  It is recommended that you use a unique container for each Event Hub and consumer group combination.  If you are not familiar with Azure Storage containers, you may wish to refer to the documentation on [managing containers](https://learn.microsoft.com/azure/storage/blobs/storage-blob-container-create?tabs=dotnet).  There, you can find detailed instructions for using .NET, the Azure CLI, or Azure PowerShell to create a container.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`. 

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://learn.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).  

To quickly create a basic set of resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmain%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

### Project Structure

The sample project contains the following structure:

1. `SampleProgram.cs` This is the entry point to the application. The class handles the initial setup of the `EventProcessorClient` instance, and the hosted service.

2. `EventProcessorClientService.cs` This is the hosted service, implementing the IHostedService interface.

3. `SampleApplicationProcessor.cs` This contains a basic implementation of the application specific event processing logic - for demonstration purposes, it simply logs the event body.

4. `appsettings.Development.json` The app settings configuration file for the sample application.

### ASP.NET Configuration Setup

The sample project uses basic application configuration in the form of a settings file (appsettings.json).

Open the `appsettings.Development.json` file and replace the Storage and EventHub configuration item values as shown below:

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "Storage": {
        "ConnectionString": "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>",
        "ContainerName": "<< NAME OF THE BLOB CONTAINER >>"
    },
    "EventHub": {
        "ConsumerGroup": "<< NAME OF THE EVENT HUB CONSUMER GROUP >>",
        "ConnectionString": "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>",
        "HubName": "<< NAME OF THE EVENT HUB >>"
    }
}
```

### Running the Application

#### From the dotnet CLI

1. Open a terminal in the root of the HostedService sample project folder.
2. Run the following dotnet command: ```dotnet run --framework net7.0```

#### Publish an Event

1. Publish an event to your Event Hubs instance using one of these options:
    * [Publishing Events](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md) A deep dive into publishing events using the Event Hubs client library.
    * [Send events using Event Hubs Data Generator](https://learn.microsoft.com/azure/event-hubs/send-and-receive-events-using-data-generator#send-events-using-event-hubs-data-generator) Publish events directly in the Azure portal.
    
2. Observe the event body being processing via the application logs. Example:

```
info: Azure.Messaging.EventHubs.Processor.Samples.HostedService.SampleApplicationProcessor[0]
      Event body has been processed: [
    {
        "key1": "value1",
        "key2": "value2",
        "key3": "value3",
        "nestedKey": {
            "nestedKey1": "nestedValue1"
        },
        "arrayKey": [
            "arrayValue1",
            "arrayValue2"
        ]
    }
]
```

### Next Steps

The sample provided demonstrates a basic implementation of how to consume and process events using the the `EventProcessorClient` within an ASP.NET hosted service. Consider building on this sample for your application specific event processing needs.
