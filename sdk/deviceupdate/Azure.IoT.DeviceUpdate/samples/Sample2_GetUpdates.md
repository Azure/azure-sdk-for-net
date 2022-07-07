# Get updates

This sample demonstrates using `DeviceUpdateClient` class in this library to retrieve device update metadata. `DeviceUpdateClient` is used to manage updates in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceUpdateClient`. You use either an endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C# Snippet:AzDeviceUpdateSample2_CreateDeviceUpdateClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
var instanceId = "<instance-id>"
var credentials = new DefaultAzureCredential();
var client = new DeviceUpdateClient(endpoint, instanceId, credentials);
```

## Get update metadata

First, let's try to retrieve update metadata.

```C# Snippet:AzDeviceUpdateSample2_GetUpdate
string provider = "<update-provider>";
string name = "<update-name>";
string version = "<update-version>";
var response = client.GetUpdate(provider, name, version);
Console.WriteLine(response.Content.ToString());
```

## Enumerate update files identities

Now that we have update metadata, let's try to retrieve payload file identities that correspond to this update.

```C# Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentities
var fileIds = client.GetFiles(provider, name, version);
foreach (var fileId in fileIds)
{
    var doc = JsonDocument.Parse(fileId.ToMemory());
    Console.WriteLine(doc.RootElement.GetString());
}
```

## Enumerate update files

In this step, we will retrieve full file metadata for each file associated with the update.

```C# Snippet:AzDeviceUpdateSample2_EnumerateUpdateFiles
var files = client.GetFiles(provider, name, version);
foreach (var file in files)
{
    var doc = JsonDocument.Parse(file.ToMemory());
    Console.WriteLine(doc.RootElement.GetString());
}
```
