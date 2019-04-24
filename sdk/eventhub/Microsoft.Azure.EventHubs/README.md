# Azure Event Hubs client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them into multiple applications. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters. 

The Azure Events Hubs client library for .NET allows for both sending and receiving of events.  Most common scenarios call for an application to act as either an event publisher or an event consumer, but rarely both. 

An **event publisher** is a source of telemetry data, diagnostics information, usage logs, or other log data, as 
part of an embedded device solution, a mobile device application, a game title running on a console or other device, 
some client or server based business solution, or a web site.  

An **event consumer** picks up such information from the Event Hub and processes it. Processing may involve aggregation, complex 
computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion.
Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilities, like Azure 
Stream Analytics, Apache Spark, or Apache Storm.  

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

Use the client library for Event Hubs to:

- Emit telemetry about your application for business intelligence and diagnostic purposes.

- Publish facts about the state of your application which interested parties may observe and use as a trigger for taking action.

- Observe interesting operations and interactions happening within your business or other ecosystem, allowing loosely coupled systems to interact without the need to bind them together.

- Receive events from one or more publishers, transform them to better meet the needs of your ecosystem, then publish the transformed events to a new stream for consumers to observe.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Microsoft.Azure.EventHubs) | [Package (NuGet)](https://www.nuget.org/packages/Microsoft.Azure.EventHubs/) | [API reference documentation](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/event-hubs?view=azure-dotnet) | [Product documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

If you are not already familiar with Azure Event Hubs, please review: [What is Event Hubs?](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about).

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

## Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, including Azure Event Hubs, you need to first [create an account](https://account.windowsazure.com/Home/Index). If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits.

- The Azure Event Hubs client library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

## Samples

Code samples for the Azure Event Hubs client library that detail how to get started and how to implement common scenarios can be found in the following locations:

- [Azure Code Samples](https://azure.microsoft.com/en-us/resources/samples/?sort=0&service=event-hubs&platform=dotnet)
- [Azure Event Hubs Documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)
- [Azure Event Hubs Sample Repository](https://github.com/Azure/azure-event-hubs/tree/master/samples)
- [Azure Event Hubs Notification Sample](https://github.com/Azure-Samples/event-hubs-dotnet-user-notifications)
- [Azure Event Hubs Publishing Sample](https://github.com/Azure-Samples/event-hubs-dotnet-ingest)

## To build

For information on building the Azure Event Hubs client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Running tests

1. Deploy the Azure Resource Manager template located at [/sdk/eventhub/Microsoft.Azure.EventHubs/assets/azure-deploy-test-dependencies.json](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Microsoft.Azure.EventHubs/assets/azure-deploy-test-dependencies.json) by clicking the following button:

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FMicrosoft.Azure.EventHubs%2Fassets%2Fazure-deploy-test-dependencies.json" target="_blank">
        <img src="http://azuredeploy.net/deploybutton.png"/>
    </a>

    *Running the above template will provision a standard Event Hubs namespace along with the required entities to successfully run the unit tests.*

1. Add an Environment Variable named `EVENT_HUBS_CONNECTION_STRING` and set the value as the connection string of the newly created namespace. **Please note that if you are using Visual Studio, you must restart Visual Studio in order to use new Environment Variables.**

1. Add an Environment Variable named `EVENT_HUBS_STORAGE_CONNECTION_STRING` and set the value as the connection string of the newly created storage account. **Please note that if you are using Visual Studio, you must restart Visual Studio in order to use new Environment Variables.**

Once you have completed the above, you can run `dotnet test` from the `/sdk/eventhub/Microsoft.Azure.EventHubs/tests` directory.

## Versioning information

The Azure Event Hubs client library uses [the semantic versioning scheme.](http://semver.org/)

## Target frameworks

For information about the target frameworks of the Azure Event Hubs client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.  

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Additional documentation

- [Azure Event Hubs General Documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)
- [Azure Event Hubs REST API Reference](https://docs.microsoft.com/en-us/rest/api/eventhub/)
- [Azure Event Hubs SDK for .NET Documentation](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/event-hubs?view=azure-dotnet)

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FMicrosoft.Azure.EventHubs%2FFREADME.png)