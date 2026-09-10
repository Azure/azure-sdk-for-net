---
page_type: sample
languages:
- csharp
products:
- azure
- azure-iot-hub
- azure-event-hubs
urlFragment: iothub-connect-to-eventhubs
name: How to request the IoT Hub built-in Event Hubs-compatible endpoint connection string
description: This sample illustrates the flow of querying an IoT instance to obtain a connection string that can be used with the Event Hub instance to which IoT Hub is currently publishing as its "built-in" endpoint.
---
# How to request the IoT Hub built-in Event Hubs-compatible endpoint connection string

IoT Hub is a managed service that acts as a central message hub for bi-directional communication between an IoT application and the devices it manages. IoT Hub supports communications both from the device to the cloud and from the cloud to the device. IoT Hub supports multiple messaging patterns and may be integrated with other Azure services to build complete, end-to-end solutions.

A common pattern is for users of IoT Hub to consume information from an Event Hub instance that is provisioned and owned by the IoT Hub service. The [IoT Hub documentation](https://learn.microsoft.com/azure/iot-hub/iot-hub-devguide-endpoints) refers to this Event Hub instance as the "built-in Event Hub-compatible endpoint that IoT Hub exposes", making it an important part of the IoT Hub story.  One of the features supported by IoT Hub is a fail-over scenario, which may be initiated by customers, and which is likely to result in IoT Hub changing the Event Hub instance to which it publishes events. Because this Event Hub instance association is owned by IoT Hub, developers cannot assume a static connection string to access it, but instead must query the IoT Hub service for the active instance.

This sample illustrates querying the IoT Hub service to obtain the connection string of the Event Hub instance to which IoT Hub is currently publishing as its "built-in" endpoint.

## Getting started

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).

- **.NET 10:** This sample targets [.NET 10](https://learn.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks). In order to build and run the sample without modifications, you will need the [.NET SDK](https://dotnet.microsoft.com/download) and a version of Visual Studio or another development environment that supports .NET 10. Visual Studio 2026, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com/vs/).

- **IoT Hub:** To interact with Azure IoT Hub, you'll also need to have an IoT Hub instance available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an IoT hub using the Azure portal](https://learn.microsoft.com/azure/iot-hub/iot-hub-create-through-portal).  There, you can also find detailed instructions for using the [Azure CLI](https://learn.microsoft.com/azure/iot-hub/iot-hub-create-using-cli), [Azure PowerShell](https://learn.microsoft.com/azure/iot-hub/iot-hub-create-using-powershell), or [Azure Resource Manager (ARM) templates](https://learn.microsoft.com/azure/iot-hub/iot-hub-rm-template-powershell) to create an IoT Hub.

To quickly create the needed IoT Hub resource in Azure and to receive a connection string for it, you can deploy our sample template by clicking:

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fgithub.com%2FAzure%2Fazure-sdk-for-net%2Ftree%2Fmain%2Fsamples%2Feventhubs%2Fiothub-connect-to-eventhubs%2Fsample-resources.json)

## References

- [What is Azure IoT Hub?](https://learn.microsoft.com/azure/iot-hub/about-iot-hub)
- [IoT Hub - Endpoints documentation](https://learn.microsoft.com/azure/iot-hub/iot-hub-devguide-endpoints)
- [IoT Hub - Read device-to-cloud messages from the built-in endpoint](https://learn.microsoft.com/azure/iot-hub/iot-hub-devguide-messages-read-builtin)
