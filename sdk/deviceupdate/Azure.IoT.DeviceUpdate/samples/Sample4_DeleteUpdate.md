# Get updates

This sample demonstrates using `DeviceUpdateClient` class in this library to delete an existing device update. `DeviceUpdateClient` is used to manage updates in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
Let's assume you have an already import device update that we want to remove from your Device Update for IoT Hub instance. 
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C#
var credentials = new DefaultAzureCredential();
var client = new DeviceUpdateClient(accountEndpoint, instance, credentials);
```

## Delete device update

Now that we have import request ready, we can start the import operation. The import is a long running operation that might take up to an hour for really big files.

```C#
var response = client.DeleteUpdate(WaitUntil.Completed, provider, name, version);
var doc = JsonDocument.Parse(response.Value.ToMemory());
Console.WriteLine(doc.RootElement.GetProperty("status").ToString());
```
