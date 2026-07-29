# Get updates

This sample demonstrates using `DeviceUpdateClient` class in this library to retrieve device update metadata. `DeviceUpdateClient` is used to manage updates, devices and deployments in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need Device Update for IoT Hub AccountId (hostname) and InstanceId which you can access in Azure Porta. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceUpdateClient`. You use an endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, use proper `account-id` and `instance-id`. You can find the right value in Azure Portal.

```C# Snippet:AzDeviceUpdateSample2_CreateDeviceUpdateClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
string instanceId = "<instance-id>";
TokenCredential credentials = new DefaultAzureCredential();
DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);
```

## Get update metadata

First, let's try to retrieve update metadata.

```C# Snippet:AzDeviceUpdateSample2_GetUpdate
string provider = "<update-provider>";
string name = "<update-name>";
string version = "<update-version>";
Response response = client.GetUpdate(provider, name, version);
JsonDocument update = JsonDocument.Parse(response.Content.ToMemory());
Console.WriteLine("Update:");
Console.WriteLine($"  Provider: {update.RootElement.GetProperty("updateId").GetProperty("provider").GetString()}");
Console.WriteLine($"  Name: {update.RootElement.GetProperty("updateId").GetProperty("name").GetString()}");
Console.WriteLine($"  Version: {update.RootElement.GetProperty("updateId").GetProperty("version").GetString()}");
Console.WriteLine("Metadata:");
Console.WriteLine(update.RootElement.ToString());
```

## Enumerate update files identities

Now that we have update metadata, let's try to retrieve payload file identities that correspond to this update.

```C# Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentities
Pageable<BinaryData> fileIds = client.GetFiles(provider, name, version);
List<string> files = new List<string>();
foreach (var fileId in fileIds)
{
    JsonDocument doc = JsonDocument.Parse(fileId.ToMemory());
    files.Add(doc.RootElement.GetString());
}
```

## Enumerate update files

In this step, we will retrieve full file metadata for each file associated with the update.

```C# Snippet:AzDeviceUpdateSample2_EnumerateUpdateFiles
foreach (var file in files)
{
    Console.WriteLine("\nFile:");
    Console.WriteLine($"  FileId: {file}");
    Response fileResponse = client.GetFile(provider, name, version, file);
    JsonDocument fileDoc = JsonDocument.Parse(fileResponse.Content.ToMemory());
    Console.WriteLine("Metadata:");
    Console.WriteLine(fileDoc.RootElement.ToString());
}
```
