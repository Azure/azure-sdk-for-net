# Basic device update enumerations

This sample demonstrates basic operations with `DeviceUpdateClient` class in this library. `DeviceUpdateClient` is used to manage updates, devices and deployments in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need Device Update for IoT Hub AccountId (hostname) and InstanceId which you can access in Azure Porta. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceUpdateClient`. You use an endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, use proper `account-id` and `instance-id`. You can find the right value in Azure Portal.

```C# Snippet:AzDeviceUpdateSample1_CreateDeviceUpdateClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
string instanceId = "<instance-id>";
TokenCredential credentials = new DefaultAzureCredential();
DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);
```

## Enumerate all device update providers

First, let's try to enumerate all available (already imported) device update providers.

```C# Snippet:AzDeviceUpdateSample1_EnumerateProvidersAsync
AsyncPageable<BinaryData> providers = client.GetProvidersAsync();
await foreach (var provider in providers)
{
    JsonDocument doc = JsonDocument.Parse(provider.ToMemory());
    Console.WriteLine(doc.RootElement.GetString());
}
```

## Enumerate all device update provider names

First, let's try to enumerate all available (already imported) device update names.

```C# Snippet:AzDeviceUpdateSample1_EnumerateNamesAsync
string updateProvider = "<update-provider>";
AsyncPageable<BinaryData> names = client.GetNamesAsync(updateProvider);
await foreach (var name in names)
{
    JsonDocument doc = JsonDocument.Parse(name.ToMemory());
    Console.WriteLine(doc.RootElement.GetString());
}
```

## Enumerate all device update versions

First, let's try to enumerate all available (already imported) device update versions.

```C# Snippet:AzDeviceUpdateSample1_EnumerateVersionsAsync
string updateName = "<update-name>";
AsyncPageable<BinaryData> versions = client.GetVersionsAsync(updateProvider, updateName);
await foreach (var version in versions)
{
    JsonDocument doc = JsonDocument.Parse(version.ToMemory());
    Console.WriteLine(doc.RootElement.GetString());
}
```
