---
page_type: sample
languages:
- csharp
products:
- azure
- azure-event-hubs
name: Samples for the Azure.Messaging.EventHubs client library
description: Samples for the Azure.Messaging.EventHubs.Processor client library
---

# Azure.Messaging.EventHubs.Processor Samples

The  Azure Event Hubs Processor samples are intended to serve as an example and introduction to common scenarios in which the Event Hubs Processor client library is used, and to help demonstrate library features.  The samples are accompanied by a [console application](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Program.cs) which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred IDE and provide the Event Hubs connection information in response to the prompts.

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

## Getting started

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  You can still use the library with older versions of C#, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the C# 8.0 syntax improvements.  

  In order to take advantage of the C# 8.0 syntax, you will need the the [.NET Core SDK](https://dotnet.microsoft.com/download) installed and your application will need to either [target .NET Core 3.0](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks) or [specify a language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of 8.0 or higher.  Visual Studio users wishing to take advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).

  **Important Note:** In order to build or run the the [samples](#available-samples) without modification, use of C# 8.0 is mandatory.  You can still run the samples if you decide to tweak them for other language versions.

To quickly create the needed resources in Azure and to receive connection strings for them, you can deploy our sample template by clicking:  

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

## Available samples

- [Hello world](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample01_HelloWorld.cs)  
  An introduction to the Event Processor client, illustrating how to create the client and perform basic operations.
  
- [Create an Event Processor client with custom options](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample02_ProcessorWithCustomOptions.cs)  
  An introduction to the Event Processor client, exploring additional options for creating the processor.

- [Perform basic event processing](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_BasicEventProcessing.cs)  
  An introduction to the Event Processor client, illustrating how to perform basic event processing.

- [Create checkpoints to track processing state](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample04_BasicCheckpointing.cs)  
  An introduction to the Event Processor client, illustrating how to create simple checkpoints.
  
- [Initialize an Event Hub partition for processing by a specific Event Processor client](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample05_InitializeAPartition.cs)  
  An introduction to the Event Processor client, illustrating how to participate in initialization for a partition.

- [Track when an Event Hub partition will no longer be processed by a specific Event Processor client](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample06_TrackWhenAPartitionIsClosed.cs)  
  An introduction to the Event Processor client, illustrating how to track when processing stops for a partition.
  
- [Manage the Event Processor when an error is encountered](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample07_RestartProcessingOnError.cs)  
  An example of stopping and restarting the Event Processor client when a specific error is encountered.

- [Send a heartbeat for health monitoring while processing events](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample08_EventProcessingHeartbeat.cs)  
  An example of ensuring that the handler for processing events is invoked on a fixed interval when no events are available.

- [Process events in batches](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample09_ProcessEventsByBatch.cs)  
  An example of grouping events into batches for downstream processing.

- [Run in Azure Stack Hub using a different version of Azure Storage](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample10_RunningWithDifferentStorageVersion.cs)
  An example of running the Event Processor in the Azure Stack Hub platform by using a different version of the Azure Storage service.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor/samples/%2FREADME.png)
