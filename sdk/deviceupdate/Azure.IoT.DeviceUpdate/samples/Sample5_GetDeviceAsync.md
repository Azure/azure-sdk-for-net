# Get device information

This sample demonstrates using `DeviceUpdateClient` class in this library to retrieve device metadata. `DeviceUpdateClient` is used to manage updates, devices and deployments in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need Device Update for IoT Hub AccountId (hostname) and InstanceId which you can access in Azure Porta. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceUpdateClient`. You use an endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C# Snippet:AzDeviceUpdateSample5_CreateDeviceManagementClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
string instanceId = "<instance-id>";
TokenCredential credentials = new DefaultAzureCredential();
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, credentials);
```

## Enumerate all devices

First, let's try to enumerate all devices currently registered with Device Update for IoT Hub.

```C# Snippet:AzDeviceUpdateSample5_EnumerateDevicesAsync
AsyncPageable<BinaryData> devices = client.GetDevicesAsync();
await foreach (var device in devices)
{
    JsonDocument doc = JsonDocument.Parse(device.ToMemory());
    Console.WriteLine(doc.RootElement.GetProperty("deviceId").GetString());
}
```

## Enumerate all device groups

Let's enumerate all available device groups.

```C# Snippet:AzDeviceUpdateSample5_EnumerateGroupsAsync
AsyncPageable<BinaryData> groups = client.GetGroupsAsync();
await foreach (var group in groups)
{
    JsonDocument doc = JsonDocument.Parse(group.ToMemory());
    Console.WriteLine(doc.RootElement.GetProperty("groupId").GetString());
}
```

## Enumerate all device classes

Let's enumerate all available device classes (device class represents a unique class of devices).

```C# Snippet:AzDeviceUpdateSample5_EnumerateDeviceClassesAsync
AsyncPageable<BinaryData> deviceClasses = client.GetDeviceClassesAsync();
await foreach (var deviceClass in deviceClasses)
{
    JsonDocument doc = JsonDocument.Parse(deviceClass.ToMemory());
    Console.WriteLine(doc.RootElement.GetProperty("deviceClassId").GetString());
}
```

## Get best update for devices in a group

Now that we know how to enumerate groups, let's try to find whether there are any available updates for group devices.

```C# Snippet:AzDeviceUpdateSample5_GetBestUpdatesAsync
string groupId = "<group-id>";
AsyncPageable<BinaryData> updates = client.GetBestUpdatesForGroupsAsync(groupId);
await foreach (var update in updates)
{
    JsonElement e = JsonDocument.Parse(update.ToMemory()).RootElement;
    Console.WriteLine($"For device class '{e.GetProperty("deviceClassId").GetString()}' in group '{groupId}', the best update is:");
    e = e.GetProperty("update").GetProperty("updateId");
    Console.WriteLine(e.GetProperty("provider").GetString());
    Console.WriteLine(e.GetProperty("name").GetString());
    Console.WriteLine(e.GetProperty("version").GetString());
}
```
