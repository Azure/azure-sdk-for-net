# Deploy device update

This sample demonstrates using `DeviceUpdateClient` class in this library to deploy an existing update to a device group. `DeviceUpdateClient` is used to manage updates, devices and deployments in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need Device Update for IoT Hub AccountId (hostname) and InstanceId which you can access in Azure Porta. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

## Create a DeviceUpdateClient
 
To interact with Device Update for IoT Hub, you need to instantiate a `DeviceManagementClient`. You use endpoint URL, instance identity and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C# Snippet:AzDeviceUpdateSample5_CreateDeviceManagementClient
Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
string instanceId = "<instance-id>";
TokenCredential credentials = new DefaultAzureCredential();
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, credentials);
```

## Deploy update to a device group

Now that we have import an update and we have identified that there is a set of devices within a given group that need this update, let's deploy the update to that device group.

```C#
string provider = "<update-provider>";
string name = "<update-name>";
string version = "<update-version>";
string groupId = "<group-id>";
string deploymentId = Guid.NewGuid().ToString("N");

var deployment = new
{
    deploymentId,
    startDateTime = DateTime.UtcNow.ToString("O"),
    update = new
    {
        updateId = new
        {
            provider,
            name,
            version
        }
    },
    groupId,
};

Response response = await client.CreateOrUpdateDeploymentAsync(groupId, deploymentId, RequestContent.Create(deployment));
Debug.Assert(response.Status == (int)HttpStatusCode.OK);
```

## Get deployment state

Now that deployment is created, let's check the deployment status:

```C#
Response response = await client.GetDeploymentStatusAsync(groupId, deploymentId);
JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
Console.WriteLine(doc.RootElement.GetProperty("deploymentState").ToString());
```

## Get deployment information

You can always retrieve deployment metadata:

```C#
Response response = await client.GetDeploymentAsync(groupId, deploymentId);
Console.WriteLine(response.Content.ToString());
```