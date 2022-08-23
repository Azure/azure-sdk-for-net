---
page_type: sample
languages:
- csharp
products:
- azure
name: Azure.Maps.Geolocation samples for .NET
description: Samples for the Azure.Maps.Geolocation client library.
---

# Azure.Maps.Geolocation Samples

## Import the namespaces

```C# Snippet:GeolocationImportNamespace
using Azure.Maps.Geolocation;
```

## Create Geolocation Client

Create a `MapsGeolocationClient` first before getting the location. Either use subscription key or AAD.

Instantiate geolocation client with subscription key:

```C# Snippet:InstantiateGeolocationClientViaSubscriptionKey
// Create a MapsGeolocationClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
MapsGeolocationClient client = new MapsGeolocationClient(credential);
```

Instantiate geolocation client via AAD authentication:

```C# Snippet:InstantiateGeolocationClientViaAAD
// Create a MapsGeolocationClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);
```

## Use Cases

For different APIs, please refer the following samples:

* [Get Location](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Geolocation/samples/GetLocationSamples.md)
