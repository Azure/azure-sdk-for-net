# Azure Functions Bindings for Azure SignalR Service

## Build Status

Travis: [![travis](https://travis-ci.org/Azure/azure-functions-signalrservice-extension.svg?branch=dev)](https://travis-ci.org/Azure/azure-functions-signalrservice-extension)

## NuGet Packages

Package Name | Target Framework | NuGet
---|---|---
Microsoft.Azure.WebJobs.Extensions.SignalRService | .NET Core App 2.1 <br/> .NET Core App 3.1 | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.WebJobs.Extensions.SignalRService.svg)](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.SignalRService)


## Intro

These bindings allow Azure Functions to integrate with [Azure SignalR Service](http://aka.ms/signalr_service).

### Supported scenarios

- Allow clients to serverlessly connect to a SignalR Service hub without requiring an ASP.NET Core backend
- Use Azure Functions (any language supported by V2) to broadcast messages to all clients connected to a SignalR Service hub.
- Use Azure Functions (any language supported by V2) to send messages to a single user, or all the users in a group.
- Use Azure Functions (any language supported by V2) to manage group users like add/remove a single user in a group.
- Example scenarios include: broadcast messages to a SignalR Service hub on HTTP requests and events from Cosmos DB change feed, Event Hub, Event Grid, etc
- Use multiple Azure SignalR Service instances for resiliency and disaster recovery in Azure Functions. See details in [Multiple SignalR service endpoint support](./docs/sharding.md).

### Bindings

`SignalRConnectionInfo` input binding makes it easy to generate the token required for clients to initiate a connection to Azure SignalR Service.

`SignalR` output binding allows messages to be broadcast to an Azure SignalR Service hub.

## Prerequisites

- [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools) (V2 or V3)

## Usage

### Create Azure SignalR Service instance

1. Create Azure SignalR Service instances in the Azure Portal. Note the connection strings, you'll need them later.

### Create Function App with extension

1. In a new folder, create a new Azure Functions app.
    - `func init`
1. Install this Functions extension.
    - `func extensions install -p Microsoft.Azure.WebJobs.Extensions.SignalRService -v 1.0.0`

### Add application setting for SignalR connection string

1. Create an app setting called `AzureSignalRConnectionString` with the SignalR connection string.
    - On localhost, use `local.settings.json`
    - In Azure, use App Settings

### Using the SignalRConnectionInfo input binding

In order for a client to connect to SignalR, it needs to obtain the SignalR Service client hub URL and an access token.

1. Create a new function named `negotiate` and use the `SignalRConnectionInfo` input binding to obtain the connection information and return it. Take a look at this [sample](samples/simple-chat/js/functionapp/negotiate/).
1. Client connects to the `negotiate` function as it's a normal SignalR hub. See [this file](samples/simple-chat/content/index.html) for a sample usage.

Binding schema:

```javascript
{
  "type": "signalRConnectionInfo",
  "name": "connectionInfo",
  "hubName": "<hub_name>",
  "connectionStringSetting": "<setting_name>", // Defaults to AzureSignalRConnectionString
  "direction": "in"
}
```

### Using the SignalR output binding

The `SignalR` output binding can be used to broadcast messages to all clients connected a hub. Take a look at this sample:

- [HttpTrigger function to send messages](samples/simple-chat/js/functionapp/messages/)
- [Simple chat app](samples/simple-chat/content/index.html)
    - Calls negotiate endpoint to fetch connection information
    - Connects to SignalR Service
    - Sends messages to HttpTrigger function, which then broadcasts the messages to all clients

Binding schema:

```javascript
{
  "type": "signalR",
  "name": "signalRMessages", // name of the output binding
  "hubName": "<hub_name>",
  "connectionStringSetting": "<setting_name>", // Defaults to AzureSignalRConnectionString
  "direction": "out"
}
```

To send one or more messages, set the output binding to an array of objects:

```javascript
module.exports = function (context, req) {
  context.bindings.signalRMessages = [{
    "target": "newMessage", // name of the client method to invoke
    "arguments": [
      req.body // arguments to pass to client method
    ]
  }];
  context.done();
};
```

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
