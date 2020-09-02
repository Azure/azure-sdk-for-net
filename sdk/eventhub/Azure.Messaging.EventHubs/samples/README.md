---
page_type: sample
languages:
- csharp
products:
- azure
- azure-event-hubs
name: Samples for the Azure.Messaging.EventHubs client library
description: Samples for the Azure.Messaging.EventHubs client library
---

# Azure.Messaging.EventHubs Samples

The  Azure Event Hubs samples are intended to serve as an example and introduction to common scenarios in which the Event Hubs client library is used, and to help demonstrate library features.  The samples are accompanied by a [console application](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Program.cs) which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred IDE and provide the Event Hubs connection information in response to the prompts.

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

## Getting started

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  You can still use the library with older versions of C#, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the C# 8.0 syntax improvements.  

  In order to take advantage of the C# 8.0 syntax, you will need the the [.NET Core SDK](https://dotnet.microsoft.com/download) installed and your application will need to either [target .NET Core 3.0](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks) or [specify a language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of 8.0 or higher.  Visual Studio users wishing to take advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).

  **Important Note:** In order to build or run the the [samples](#available-samples) without modification, use of C# 8.0 is mandatory.  You can still run the samples if you decide to tweak them for other language versions.

To quickly create the needed Event Hubs resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

If you'd like to run samples that use [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity), you'll also need a service principal with the correct roles. To make configuration for the identity samples easier, a [PowerShell script](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/identity-samples-azure-setup.ps1) script is available. Please see the [Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md#Azure-Identity-Samples) for more details about the script.

## Available samples

- [Hello world](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample01_HelloWorld.cs)  
  An introduction to Event Hubs, illustrating how to create a client and explore an Event Hub.

- [Create an Event Hub client with custom options](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_ClientWithCustomOptions.cs)  
  An introduction to Event Hubs, exploring additional options for creating the different Event Hub clients.

- [Publish an event batch to an Event Hub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample03_PublishAnEventBatch.cs)  
  An introduction to publishing events, using a batch with single event.  
  
- [Publish multiple event batches to an Event Hub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishMultipleEventBatches.cs)  
  An example of publishing events using multiple batches.    

- [Read events from an Event Hub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadEvents.cs)  
  An introduction to reading all events available from an Event Hub.

- [Publish an event batch using a partition key](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_PublishAnEventBatchWithPartitionKey.cs)  
  An introduction to publishing events using a partition key to group batches together.

- [Publish an event batch to a specific partition](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample07_PublishAnEventBatchToASpecificPartition.cs)  
  An introduction to publishing events, specifying a specific partition for the batch to be published to.

- [Publish events with custom metadata](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_PublishEventsWithCustomMetadata.cs)  
  An example of publishing events, extending the event data with custom metadata.

- [Read only new events from an Event Hub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ReadOnlyNewEvents.cs)  
  An example of reading events, beginning with only those newly available from an Event Hub.

- [Read events from a known position in an Event Hub partition](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample10_ReadEventsFromAKnownPosition.cs)  
  An example of reading events from a single Event Hub partition, starting at a well-known position.

- [Publish an event batch with a custom size limit](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample11_PublishAnEventBatchWithCustomSizeLimit.cs)  
  An example of publishing events using a custom size limitation with the batch.

- [Authorize using a service principal with client secret](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample12_AuthenticateWithClientSecretCredential.cs)  
  An example of interacting with an Event Hub using an Azure Active Directory application with client secret for authorization.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs/samples/%2FREADME.png)
