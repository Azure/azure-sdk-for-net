# Azure Service Bus client library for .NET

Azure Service Bus allows you to build applications that take advantage of asynchronous messaging patterns using a highly-reliable service to broker messages between producers and consumers. Azure Service Bus provides flexible, brokered messaging between client and server, along with structured first-in, first-out (FIFO) messaging, and publish/subscribe capabilities with complex routing.

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

Use the client library for Azure Service Bus to:

- Transfer business data: leverage messaging for durable exchange of information, such as sales or purchase orders, journals, or inventory movements.

- Decouple applications: improve reliability and scalability of applications and services, relieving senders and receivers of the need to be online at the same time.

- Control how messages are processed: support traditional competing consumers for messages using queues or allow each consumer their own instance of a message using topics and subscriptions.

- Implement complex workflows: message sessions support scenarios that require message ordering or message deferral.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus) | [Package (NuGet)](https://www.nuget.org/packages/Microsoft.Azure.ServiceBus/) | [API reference documentation](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/service-bus?view=azure-dotnet) | [Product documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

If you are not already familiar with Azure Service Bus, please review: [What is Azure Service Bus](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview).

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

## Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, including Azure Service Bus, you need to first [create an account](https://account.windowsazure.com/Home/Index). If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits.

- The Azure Service Bus client library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

## Samples

Code samples for the Azure Service Bus client library that detail how to get started and how to implement common scenarios can be found in the following locations:

- [Azure Code Samples](https://azure.microsoft.com/en-us/resources/samples/?sort=0&service=service-bus&platform=dotnet)
- [Azure Service Bus Sample Repository](https://github.com/Azure/azure-service-bus/tree/master/samples/)
- [Azure Service Bus Documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)

## To build

For information on building the Azure Service bus client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Running tests

1. Deploy the Azure Resource Manager template located at [sdk/servicebus/Microsoft.Azure.ServiceBus/assets/azure-deploy-test-dependencies.json](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Microsoft.Azure.ServiceBus/assets/azure-deploy-test-dependencies.json) by clicking the following button:

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Fservicebus%2FMicrosoft.Azure.ServiceBus%2Fassets%2Fazure-deploy-test-dependencies.json" target="_blank">
        <img src="http://azuredeploy.net/deploybutton.png"/>
    </a>

    *Running the above template will provision a standard Service Bus namespace along with the required entities to successfully run the unit tests.*

1. Add an Environment Variable named `SERVICE_BUS_CONNECTION_STRING` and set the value as the connection string of the newly created namespace. **Please note that if you are using Visual Studio, you must restart Visual Studio in order to use new Environment Variables.**

Once you have completed the above, you can run `dotnet test` from the `/sdk/servicebus/Microsoft.Azure.ServiceBus/tests` directory.

## Development history

For additional insight and context, the development, release, and issue history for the Azure Service Bus client library will continue to be available in read-only form, located in the stand-alone [Azure Service Bus .NET repository](https://github.com/Azure/azure-service-bus-dotnet).  

## Versioning information

The Azure Service Bus client library uses [the semantic versioning scheme](http://semver.org/).  

## Target frameworks

For information about the target frameworks of the Azure Service Bus client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Additional documentation

- [Azure Service Bus General Documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)
- [Azure Service Bus REST API Reference](https://docs.microsoft.com/en-us/rest/api/servicebus/)
- [Azure Service Bus SDK for .NET Documentation](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/service-bus?view=azure-dotnet)

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fservicebus%2FMicrosoft.Azure.ServiceBus%2FREADME.png)