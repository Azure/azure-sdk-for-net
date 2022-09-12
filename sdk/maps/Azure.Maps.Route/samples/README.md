---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.Maps.Route samples for .NET
description: Samples for the Azure.Maps.Route client library.
---

# Azure.Maps.Route Samples

## Import the namespaces

```C# Snippet:RouteImportNamespace
using Azure.Core.GeoJson;
using Azure.Maps.Route;
using Azure.Maps.Route.Models;
```

## Create Route Client

Before rendering any images or tiles, create a `MapsRouteClient` first. Either use subscription key or AAD.

Instantiate route client with subscription key:

```C# Snippet:InstantiateRouteClientViaSubscriptionKey
// Create a MapsRouteClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
MapsRouteClient client = new MapsRouteClient(credential);
```

Instantiate route client via AAD authentication:

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRouteClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
MapsRouteClient client = new MapsRouteClient(credential, clientId);
```

## Use Cases

For different APIs, please refer the following samples:

* [Route Directions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteDirectionsSamples.md)
* [Route Range](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteRangeSamples.md)
* [Route Matrix](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteMatrixSamples.md)
