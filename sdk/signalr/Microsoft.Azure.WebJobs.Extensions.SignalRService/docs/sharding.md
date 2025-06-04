# Multiple Azure SignalR Service Instances Support in Azure Functions
Currently we add support for configuring multiple SignalR Service instances. You can distribute your clients to multiple SignalR service instances and send messages to multiple instances as if to one instance.

<!-- TOC -->

- [Multiple Azure SignalR Service Instances Support in Azure Functions](#multiple-azure-signalr-service-instances-support-in-azure-functions)
  - [Usage scenarios](#usage-scenarios)
  - [Limitations](#limitations)
  - [Configuration](#configuration)
  - [Routing](#routing)
    - [Default behavior](#default-behavior)
    - [Customization](#customization)
      - [CSharp](#csharp)
      - [Other languages](#other-languages)
        - [Client routing](#client-routing)
        - [Messages routing](#messages-routing)

<!-- /TOC -->

## Usage scenarios
Routing logic is the way to decide to which SignalR Service instance among multiple instances your clients connect and your messages send. By applying different routing logic, this feature can be used in different scenarios.
* Scaling. Randomly route each client to one SignalR Service instance, send messages to all the SignalR Service instances so that you can scale the concurrent connections.
* Cross-geo scenario. Cross-geo networks can be comparatively unstable. Route your clients to a SignalR Service instance in the same region can reduce cross-geo connections.
* High availability and disaster recovery scenarios. Set up multiple service instances in different regions, so when one region is down, the others can be used as backup. Configure service instances as two roles, **primary** and **secondary**. By default, clients will be routed to a primary online instance. When SDK detects all the primary instances are down, it will route clients to secondary instances. Clients connected before will experience connection drops when there is a disaster and failover take place. You'll need to handle such cases at client side to make it transparent to your end customers. For example, do reconnect after a connection is closed.

## Limitations
Currently multiple-endpoint feature is only supported on `Persistent` transport type.

## Configuration

To enable multiple SignalR Service instances, you should:

### 1. Use `Persistent` transport type

The default transport type is `Transient` mode. You should add the following entry to your `local.settings.json` file or the application setting on Azure.

```json
{
    "AzureSignalRServiceTransportType":"Persistent"
}
```
> Notes for switching from `Transient` mode to `Persistent` mode on **Azure Functions runtime v3**:
>
> Under `Transient` mode, the `Newtonsoft.Json` library is used to serialize arguments of hub methods. However, under `Persistent` mode, the `System.Text.Json` library is used as default on Azure Functions runtime v3. `System.Text.Json` has some key differences in default behavior with `Newtonsoft.Json`. If you want to use `Newtonsoft.Json` under `Persistent` mode, you can add the configuration item `"Azure:SignalR:HubProtocol": "NewtonsoftJson"` in the `local.settings.json` file or `Azure__SignalR__HubProtocol=NewtonsoftJson` in the Azure portal.


### 2. Configure multiple SignalR Service endpoint entries

We use a [`ServiceEndpoint`](https://github.com/Azure/azure-signalr/blob/dev/src/Microsoft.Azure.SignalR.Common/Endpoints/ServiceEndpoint.cs) object to represent a SignalR Service instance. You can define a service endpoint with its `<EndpointName>` and `<EndpointType>` in the entry key, and the connection string in the entry value. The keys are in the following format:

```
Azure:SignalR:Endpoints:<EndpointName>:<EndpointType>
```

`<EndpointType>` is optional and defaults to `primary`. See samples below:

```json
{
    "Azure:SignalR:Endpoints:EndpointName1":"<ConnectionString>",

    "Azure:SignalR:Endpoints:EndpointName2:Secondary":"<ConnectionString>",

    "Azure:SignalR:Endpoints:EndpointName3:Primary":"<ConnectionString>"
}
```

> * When you configure Azure SignalR endpoints in the App Service in the Azure portal, replace `":"` with `"__"` (the double underscore) in the keys. For reasons, see [Environment variables](https://learn.microsoft.com/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#environment-variables-1).
>
> * A connection string configured with the key `{ConnectionStringSetting}` (defaults to "AzureSignalRConnectionString") is also recognized as a primary service endpoint with empty name. But this configuration style isn't recommended for multiple endpoints.

#### Azure Identity support

The [SignalR Service Owner role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#signalr-service-owner) is required to use an Identity-based connection.

Here's an example to configure Azure Identity for a SignalR endpoint named "Endpoint1":

```json
{
  "Values": {
    "Azure:SignalR:Endpoints:Endpoint1:serviceUri": "https://<SignalRServiceHost>",
    "Azure:SignalR:Endpoints:Endpoint1:clientId": "...",
    "Azure:SignalR:Endpoints:Endpoint1:clientSecret": "...",
    "Azure:SignalR:Endpoints:Endpoint1:tenantId": "..."
  }
}
```

The `serviceUri` is required. Other items, such as `clientId` and `clientSecret`, are optional depending upon which credentials you want to use.

For more information, see [Common properties for Identity-based connections](https://learn.microsoft.com/azure/azure-functions/functions-reference?tabs=azurewebjobsstorage#common-properties-for-identity-based-connections). Note that you should replace `<CONNECTION_NAME_PREFIX>` there with `Azure__SignalR__Endpoints__<EndpointName>`.

    
## Routing

### Default behavior
By default, the SDK uses the [DefaultEndpointRouter](https://github.com/Azure/azure-signalr/blob/dev/src/Microsoft.Azure.SignalR/EndpointRouters/DefaultEndpointRouter.cs) to pick up endpoints.

* Client routing: Randomly select one endpoint from **primary online** endpoints. If all the primary endpoints are offline, then randomly select one **secondary online** endpoint. If the selection fails again, then exception is thrown.

* Server message routing: All service endpoints are returned.

### Customization
#### Customize routing in .NET

Here are the steps:
* Implement a customized router. You can leverage information provided from [`ServiceEndpoint`](https://github.com/Azure/azure-signalr/blob/dev/src/Microsoft.Azure.SignalR.Common/Endpoints/ServiceEndpoint.cs) to make routing decision. See guide here: [customize-route-algorithm](https://github.com/Azure/azure-signalr/blob/dev/docs/sharding.md#customize-route-algorithm). **Please note that Http trigger is required in the negotiation function when you need `HttpContext` in custom negotiation method.**

* Register the router to DI container.
```cs
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(SimpleChatV3.Startup))]
namespace SimpleChatV3
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEndpointRouter, CustomizedRouter>();
        }
    }
}
```

#### Customize routing in other languages

For non-.NET languages, we support specifying target endpoints in each request. You'll use new binding types to get endpoint information.

##### Client routing
The `SignalRConnectionInfo` binding selects one endpoint according the default routing rule. If you want to customize routing rule, you should use `SignalRNegotiation` binding instead of `SignalRConnectionInfo` binding.

`SignalRNegotiation` binding configuration properties are the same as `SignalRConnectionInfo`. Here's a `function.json` file sample:
```json
{
    "type": "signalRNegotiation",
    "name": "negotiationContext",
    "hubName": "<HubName>",
    "direction": "in"
}
```

You could also add other binding data such as `userId`, `idToken` and `claimTypeList` just like `SignalRConnectionInfo`.

The object you get from `SignalRNegotiation` binding is in the following format:
```json
{
    "endpoints": [
        {
            "endpointType": "Primary",
            "name": "<EndpointName>",
            "endpoint": "https://****.service.signalr.net",
            "online": true,
            "connectionInfo": {
                "url": "<client-access-url>",
                "accessToken": "<client-access-token>"
            }
        },
        {
            "...": "..."
        }
    ]
}
```

Here's a Javascript usage sample of `SignalRNegotiation` binding:
```js
module.exports = function (context, req, negotiationContext) {
    var userId = req.query.userId;
    if (userId.startsWith("east-")) {
        //return the first endpoint whose name starts with "east-" and status is online.
        context.res.body = negotiationContext.endpoints.find(endpoint => endpoint.name.startsWith("east-") && endpoint.online).connectionInfo;
    }
    else {
        //return the first online endpoint
        context.res.body = negotiationContext.endpoints.filter(endpoint => endpoint.online)[0].connectionInfo;
    }
}
```

##### Messages routing
Messages or actions routing needs two binding types to cooperate. In general, firstly you need a new input binding type `SignalREndpoints` to get all the available endpoint information. Then you filter the endpoints and get an array containing all the endpoints that you want to send to. Lastly you specify the target endpoints in the `SignalR` output binding.

Here's the `SignalREndpoints` binding configuration properties in `functions.json` file:
```json
{
      "type": "signalREndpoints",
      "direction": "in",
      "name": "endpoints",
      "hubName": "<HubName>"
}
```

The object you get from `SignalREndpoints` is an array of endpoints each of which is represented as a JSON object with the following schema:

```json
{
    "endpointType": "<EndpointType>",
    "name": "<EndpointName>",
    "endpoint": "https://****.service.signalr.net",
    "online": true
}
```


After you get the target endpoint array, add an `endpoints` property to the output binding object. This is a Javascript example:
```js
module.exports = function (context, req, endpoints) {
    var targetEndpoints = endpoints.filter(endpoint => endpoint.name.startsWith("east-"));
    context.bindings.signalRMessages = [{
        "target": "chat",
        "arguments": ["hello-world"],
        "endpoints": targetEndpoints,
    }];
    context.done();
}
```
