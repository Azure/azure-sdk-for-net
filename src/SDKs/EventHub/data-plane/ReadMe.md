<p align="center">
  <img src="event-hubs.png" alt="Microsoft Azure Event Hubs" width="100"/>
</p>

# Microsoft Azure Event Hubs Client for .NET

|Build/Package|Status|
|------|-------------|
|master|[![Build status](https://ci.appveyor.com/api/projects/status/e4lwcdjf51e56i87/branch/master?svg=true)](https://ci.appveyor.com/project/serkantkaraca/azure-event-hubs-dotnet/branch/master) [![codecov](https://codecov.io/gh/Azure/azure-event-hubs-dotnet/branch/master/graph/badge.svg)](https://codecov.io/gh/Azure/azure-event-hubs-dotnet)|
|dev|[![Build status](https://ci.appveyor.com/api/projects/status/e4lwcdjf51e56i87/branch/dev?svg=true)](https://ci.appveyor.com/project/serkantkaraca/azure-event-hubs-dotnet/branch/dev) [![codecov](https://codecov.io/gh/Azure/azure-event-hubs-dotnet/branch/dev/graph/badge.svg)](https://codecov.io/gh/Azure/azure-event-hubs-dotnet)|
|Microsoft.Azure.EventHubs|[![NuGet Version and Downloads count](https://buildstats.info/nuget/Microsoft.Azure.EventHubs?includePreReleases=true)](https://www.nuget.org/packages/Microsoft.Azure.EventHubs/)|
|Microsoft.Azure.EventHubs.Processor|[![NuGet Version and Downloads count](https://buildstats.info/nuget/Microsoft.Azure.EventHubs.Processor?includePreReleases=true)](https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor/)|

This library is built using .NET Standard 2.0. For more information on what platforms are supported see [.NET Platforms Support](https://docs.microsoft.com/en-us/dotnet/articles/standard/library#net-platforms-support).

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them into multiple applications. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters. 

Refer to the [online documentation](https://azure.microsoft.com/services/event-hubs/) to learn more about Event Hubs in general.

## How to provide feedback

See our [Contribution Guidelines](./.github/CONTRIBUTING.md).

## Overview

The .NET client library for Azure Event Hubs allows for both sending events to and receiving events from an Azure Event Hub. 

An **event publisher** is a source of telemetry data, diagnostics information, usage logs, or other log data, as 
part of an embedded device solution, a mobile device application, a game title running on a console or other device, 
some client or server based business solution, or a web site.  

An **event consumer** picks up such information from the Event Hub and processes it. Processing may involve aggregation, complex 
computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion.
Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilites, like Azure 
Stream Analytics, Apache Spark, or Apache Storm.   
   
Most applications will act either as an event publisher or an event consumer, but rarely both. The exception are event 
consumers that filter and/or transform event streams and then forward them on to another Event Hub; an example for such is Azure Stream Analytics.

## FAQ

### Where can I find examples that use this library?

[https://github.com/Azure/azure-event-hubs/tree/master/samples](https://github.com/Azure/azure-event-hubs/tree/master/samples)

### How to build client libraries on Visual Studio 2017? 

Make sure you have .NET Core Cross-Platform Development SDK installed. If it is missing, you can install the SDK by running Visual Studio Installer. See https://www.microsoft.com/net/core#windowscmd for VS 2017 and SDK installation.

### How do I run the unit tests? 

In order to run the unit tests, you will need to do the following:

1. Deploy the Azure Resource Manager template located at [/build/azuredeploy.json](./build/azuredeploy.json) by clicking the following button:

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-event-hubs-dotnet%2Fdev%2Fbuild%2Fazuredeploy.json" target="_blank">
        <img src="http://azuredeploy.net/deploybutton.png"/>
    </a>

    *Running the above template will provision an Event Hubs namespace along with the required entities to successfully run the unit tests.*

1. Add an Environment Variable named `azure-event-hubs-dotnet/connectionstring` and set the value as the connection string of the newly created namespace. **Please note that if you are using Visual Studio, you must restart Visual Studio in order to use new Environment Variables.**

1. Add an Environment Variable named `azure-event-hubs-dotnet/storageconnectionstring` and set the value as the connection string of the newly created storage account.

Once you have completed the above, you can run `dotnet test` from the `/test/Microsoft.Azure.EventHubs.Tests` directory.

### Can I manage Event Hubs entities with this library?

The standard way to manage Azure resources is by using [Azure Resource Manager](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview). In order to use functionality that previously existed in the .NET Framework Service Bus client library, you will need to use the `Microsoft.Azure.Management.EventHub` library. This will enable use cases that dynamically create/read/update/delete resources. The following links will provide more information on the new library and how to use it.

* GitHub repo - [https://github.com/Azure/azure-sdk-for-net/tree/AutoRest/src/ResourceManagement/EventHub](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest/src/ResourceManagement/EventHub)
* NuGet package - [https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub/](https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub/)
* Sample - [https://github.com/Azure-Samples/event-hubs-dotnet-management](https://github.com/Azure-Samples/event-hubs-dotnet-management)
