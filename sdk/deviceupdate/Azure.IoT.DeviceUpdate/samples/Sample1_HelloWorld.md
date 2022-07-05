# Basic device update enumerations

This sample demonstrates basic operations with `DeviceUpdateClient` class in this library. `DeviceUpdateClient` is used to manage updates in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceUpdateClient`. You use either an endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C# 
var credentials = new DefaultAzureCredential();
var client = new DeviceUpdateClient(accountEndpoint, instance, credentials);
```

## Enumerate all device update providers

First, let's try to enumerate all available (already imported) device update providers.

```C# 
var providers = client.GetProviders();
foreach(var provider in providers)
{
  var doc = JsonDocument.Parse(provider.ToMemory());
  Console.WriteLine(doc.RootElement.GetString());
}
```

## Enumerate all device update provider names

First, let's try to enumerate all available (already imported) device update providers.

```C# 
var names = client.GetNames(provider);
foreach(var name in names)
{
  var doc = JsonDocument.Parse(provider.ToMemory());
  Console.WriteLine(doc.RootElement.GetString());
}
```

## Enumerate all device update versions

First, let's try to enumerate all available (already imported) device update providers.

```C#
var versions = client.GetNames(provider, name);
foreach(var version in versions)
{
  var doc = JsonDocument.Parse(provider.ToMemory());
  Console.WriteLine(doc.RootElement.GetString());
}
```
