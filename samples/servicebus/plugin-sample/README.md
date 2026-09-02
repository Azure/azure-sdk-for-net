---
page_type: sample
languages:
- csharp
products:
- azure
- azure-service-bus
urlFragment: servicebus-plugin-sample
name: Extensibility plugin pattern for Azure Service Bus
description: Demonstrates how to create plugin-style extension methods for ServiceBusClient to add pre- and post-processing logic to send and receive operations.
---

# Service Bus Plugin Sample

This sample demonstrates how to implement a plugin-style extensibility pattern for the `ServiceBusClient`. It provides extension methods that wrap `ServiceBusSender`, `ServiceBusReceiver`, `ServiceBusProcessor`, and `ServiceBusSessionProcessor` with pluggable middleware, allowing custom logic to run before sending and after receiving messages.

## Key concepts

- **PluginSender** — wraps `ServiceBusSender`, executing a pipeline of `Func<ServiceBusMessage, Task>` plugins before each send.
- **PluginReceiver** — wraps `ServiceBusReceiver`, executing a pipeline of `Func<ServiceBusReceivedMessage, Task>` plugins after each receive.
- **PluginProcessor / PluginSessionProcessor** — wraps the processor types with the same plugin pipeline.
- **ServiceBusClientExtensions** — extension methods on `ServiceBusClient` to create the plugin-wrapped types.

## Getting started

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- An [Azure Service Bus namespace](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-create-namespace-portal)
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later

### Building the sample

```bash
dotnet build
```
