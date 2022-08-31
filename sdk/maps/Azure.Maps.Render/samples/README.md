---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.Maps.Render samples for .NET
description: Samples for the Azure.Maps.Render client library.
---

# Azure.Maps.Render Samples

## Import the namespaces

```C# Snippet:RenderImportNamespace
using Azure.Maps.Render;
```

## Create Render Client

Before rendering any images or tiles, create a `MapsRenderClient` first. Either use subscription key or AAD.

Instantiate render client with subscription key:

```C# Snippet:InstantiateRenderClientViaSubscriptionKey
// Create a MapsRenderClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
MapsRenderClient client = new MapsRenderClient(credential);
```

Instantiate render client via AAD authentication:

```C# #region Snippet:InstantiateRenderClientViaAAD
var client = new MapsRouteClient(credential, clientId);
```

## Use Cases

For different APIs, please refer the following samples:

[Render tiles, imageries and images](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Render/samples/MapsRenderTilesImageriesImagesSamples.md)
