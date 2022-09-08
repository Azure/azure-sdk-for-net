# Delete update

This sample demonstrates using `DeviceUpdateClient` class in this library to delete an existing device update. `DeviceUpdateClient` is used to manage updates, devices and deployments in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need Device Update for IoT Hub AccountId (hostname) and InstanceId which you can access in Azure Porta. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
Let's assume you have an already import device update that we want to remove from your Device Update for IoT Hub instance. 
 
For the sample below, use proper `account-id` and `instance-id`. You can find the right value in Azure Portal.

```C# Snippet:AzDeviceUpdateSample2_CreateDeviceUpdateClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
string instanceId = "<instance-id>"
TokenCredential credentials = new DefaultAzureCredential();
DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);
```

## Delete device update

Now that we have import request ready, we can start the import operation. The import is a long running operation that might take up to an hour for really big files.

```C#
Operation response = await client.DeleteUpdateAsync(WaitUntil.Completed, provider, name, version);
```
