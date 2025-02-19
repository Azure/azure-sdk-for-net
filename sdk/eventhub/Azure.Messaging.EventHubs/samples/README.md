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

The Azure Event Hubs client library offers samples in two forms. Common application scenarios are presented as markdown documents, providing a detailed explanation of context while also demonstrating implementation details with snippets of code.  More specialized scenarios are presented as stand-alone projects to both illustrate the deeper end-to-end context and allow exploring interactively.

The markdown-based samples are ordered by increasing complexity, starting with more basic scenarios to help get started quickly.  Though each sample is independent, they will assume an understanding of the content discussed in earlier samples.

Each of the application samples are intended to be self-contained and focused on illustrating one specific scenario.  The simplest way to begin is to launch the project for debugging in Visual Studio, or your preferred IDE, and provide the Event Hubs connection information in response to the prompts.  Each of these sample applications is accompanied by a dedicated README, offering more specific detail about its hosting needs and operation.

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://learn.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://learn.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).

To quickly create a basic set of Event Hubs resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.EventHubs
```

### Authenticate the client

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with using connection strings with Event Hubs, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://learn.microsoft.com/azure/event-hubs/event-hubs-get-connection-string).

## Common samples

- [Hello world](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample01_HelloWorld.md)
  An introduction to Event Hubs, illustrating the basic flow of events through an Event Hub, with the goal of quickly allowing you to view events being published and read from the Event Hubs service.

- [Event Hubs Clients](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md)
  An overview of the Event Hubs clients, detailing the available client types, the scenarios they serve, and demonstrating options for customizing their configuration, such as specifying a proxy.

- [Event Hubs Metadata](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample03_EventHubMetadata.md)
  A discussion of the metadata available for an Event Hub instance and demonstration of how to query and inspect the information.

- [Publishing Events](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md)
  A deep dive into publishing events using the Event Hubs client library, detailing the different options available and illustrating common scenarios.

- [Reading Events](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadingEvents.md)
  A deep dive into reading events using the Event Hubs client library, detailing the different options available and illustrating common scenarios.

- [Identity and Shared Access Credentials](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_IdentityAndSharedAccessCredentials.md)
  A discussion of the different types of authorization supported, focusing on identity-based credentials for Azure Active Directory and use the of shared access signatures and keys.

- [Earlier Language Versions](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample07_EarlierLanguageVersions.md)
  A demonstration of how to interact with the client library using earlier versions of C#, where newer syntax for asynchronous enumeration and disposal are not available.

- [Building a Custom Event Processor using EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_CustomEventProcessor.md)
  An introduction to the `EventProcessor<TPartition>` base class which is used when building advanced processors which need full control over state management.

- [Observable Event Data Batch](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ObservableEventBatch.md)
  A demonstration of how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch.

- [Capturing Event Hubs logs using AzureEventSourceListener class](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample10_AzureEventSourceListener.md)
  A demonstration of how to use the [`AzureEventSourceListener`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) from the `Azure.Core` package to capture logs emitted by the Event Hubs client library.

- [Mocking Client Types](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample11_MockingClientTypes.md)
  A demonstration of how to mock the types in the Event Hubs client library, focusing on common application scenarios.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
