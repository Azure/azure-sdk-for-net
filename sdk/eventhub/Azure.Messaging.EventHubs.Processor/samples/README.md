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

The Azure Event Hubs Processor client library offers samples in two forms.  Common application scenarios are presented as markdown documents, providing a detailed explanation of context while also demonstrating implementation details with snippets of code.  More specialized scenarios are presented as stand-alone projects to both illustrate the deeper end-to-end context and allow exploring interactively.

The markdown-based samples are ordered by increasing complexity, starting with more basic scenarios to help get started quickly.  Though each sample is independent, they will assume an understanding of the content discussed in earlier samples.

Each of the application samples are intended to be self-contained and focused on illustrating one specific scenario.  The simplest way to begin is to launch the project for debugging in Visual Studio, or your preferred IDE, and provide the Event Hubs connection information in response to the prompts.  Each of these sample applications is accompanied by a dedicated README, offering more specific detail about its hosting needs and operation. 

## Getting started

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.   

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).  

To quickly create a basic set of resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.EventHubs.Processor --version 5.3.0-beta.4
```

### Authenticate the client

#### Obtain an Event Hubs connection string

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with using connection strings with Event Hubs, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string).

#### Obtain an Azure Storage connection string

For the event processor client to make use of Azure Storage blobs for checkpointing, it will need to understand how to connect to a storage account and authorize with it.  The most straightforward method of doing so is to use a connection string, which is generated at the time that the storage account is created.  If you aren't familiar with storage account connection string authorization in Azure, you may wish to follow the step-by-step guide to [configure Azure Storage connection strings](https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string).

## Common samples

- [Hello world](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample01_HelloWorld.md)  
  An introduction to the Event Processor client, illustrating how to create the client and perform basic operations.  
  
- [Event Processor Configuration](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample02_EventProcessorConfiguration.md)  
  A demonstration of the options for customizing the Event Processor client configuration, such as specifying a proxy. 
  
- [Event Processor Handlers](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md)  
  A discussion of using event handlers for interacting with the Event Processor client as it is running, illustrating the available events and common usage scenarios like processing events, detecting errors, and specifying a position to begin reading events if a checkpoint does not exist.
  
- [Processing Events](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample04_ProcessingEvents.md)  
  A deep dive into processing events, handling errors, and creating checkpoints using the Event Processor client. 
  
- [Identity and Shared Access Credentials](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample05_IdentityAndSharedAccessCredentials.md)  
  A discussion of the different types of authorization supported, focusing on identity-based credentials for Azure Active Directory and use the of shared access signatures and keys.
  
- [Requesting Azure Storage Service Versions](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample06_RequestingStorageServiceVersions.md)  
  An illustration of configuring the Blob Storage client to use a specific version of the service, rather than the default (latest).  This is useful when the Azure host environment that you are targeting supports a different version of Blob Storage service than is available in the Azure public cloud, such as Azure Stack Hub 2002.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor/samples/%2FREADME.png)
