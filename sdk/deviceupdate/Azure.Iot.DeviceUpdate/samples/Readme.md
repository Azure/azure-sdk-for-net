# Device Update for IoT Hub Samples
You can explore Device Update for IoT Hub APIs (using the SDK) with our samples project. This document describes the most commonly used API methods for the most common scenarios (this section does not attempt to be a complete API documentation).

 The sample covers these scanarios and actions:

- publish new update 
- retrieve the newly imported update
- create device group (if not exists already)
- wait for update to be installable to our device group
- create deployment to deploy our new update to our device
- check deployment and wait for the device to report the update being deployed
- retrieve all updates installed on the device
- delete the update
- retrieve the deleted update and check that it no longer exists

## Running the samples

To run the samples, you need to compile console DeviceUpdateClientSample project. The executable accepts the following command-line arguments:

| Argument           | Description                             | Required | Default value                                                |
| ------------------ | --------------------------------------- | -------- | ------------------------------------------------------------ |
| --tenant           | AAD tenant id                           | True     | Env:DEVICEUPDATE_TENANT_ID                                   |
| --client           | AAD client id                           | True     | Env:DEVICEUPDATE_CLIENT_ID                                   |
| --clientSecret     | AAD client secret                       | True     | Env:DEVICEUPDATE_CLIENT_SECRET                               |
| --accountEndpoint  | ADU account endpoint                    | True     | Env:DEVICEUPDATE_ACCOUNT_ENDPOINT                            |
| --instance         | ADU instance id                         | True     | Env:DEVICEUPDATE_INSTANCE_ID                                 |
| --connectionString | Azure Storage account connection string | True     | Formats default connection string from Env:DEVICEUPDATE_STORAGE_NAME and Env:DEVICEUPDATE_STORAGE_KEY. |
| --device           | Registered ADU simulator device id      | True     |                                                              |
| --deviceTag        | IoT device tag for the device           | True     |                                                              |
| --delete           | Delete update when finished             | False    | false                                                        |

So, as an example let's assume we have set the environment and we have tenant, client, client secret and storage settings set in environment variables. To run the samples we use the following arguments:

``` powershell
.\DeviceUpdateClientSample.exe --device "device-test" --deviceTag "device-test"
```


## Creating Client

There are three different clients - UpdatesClient for update management, DevicesClient for device management and finally DeploymentsClient for deployment management. To create a new client, you need the Device Update for IoT Hub account, instance and credentials.
In the sample below, you can set `accountEndpoint`, `instanceId`, `tenantId` and `clientId` as command-line arguments. The client requires an instance of [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In these samples, we illustrate how to use just derived class: InteractiveLogin. There are other options if you want to use client certificates for authentication (ClientCertificateCredential) or client secret (ClientSecretCredential).

```C#
// By using the InteractiveBrowserCredential, the current user can login using a web browser
// interactively with the AAD
var tokenCredential = new InteractiveBrowserCredential(
    tenantId,
    clientId,
    new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

var updateClient = new UpdatesClient(
    accountEndpoint,
    instanceId,
    tokenCredential);
```

Also, if you need to override pipeline behavior, such as provide your own HttpClient instance, you can do that via client options. This parameter is optional.

```C#
// This illustrates how to specify client options, in this case, by providing an
// instance of HttpClient for the digital twins client to use.
var clientOptions = new UpdateClientOptions
{
    Transport = new HttpClientTransport(httpClient),
};

var updateClient = new UpdateClient(
    accountEndpoint,
    instanceId,
    tokenCredential,
    clientOptions);
```

## Update Management

### Import Update

Device Update for IoT Hub client library allows you to import a device update into ADU, as well as the ability to view and delete previously imported update. For Public Preview, ADU supports rolling out a single update per device, making it ideal for full-image updates that update an entire OS partition at once as well as a Desired-State Manifest that describes all the packages you might want to update on your device.

Each update in ADU is described by an **Update** entity. The Update entity describes basic metadata about the entity itself, like its identity and version, as well as metadata about the files that make up the update.

Update identity in ADU consists of three parts: **provider**, **name**, and **version**. In the ADU Public Preview, the names that make up the identity must follow some simple rules in order for updates to be delivered to the correct, compatible devices. The `provider` must match the device manufacturer name, and the `name` must match the device model name.

The importing workflow is as follows:

1. Build/download a device image update or create a Desired-State Manifest for package update
2. Create an ADU import manifest describing the update and its files
3. Upload the manifest and files to an Azure Blob storage
4. Call the API NewUpdate API, passing it the URLs of the manifest and other files
5. Wait for the import process to finish
6. Deploy the update to one or more devices via the ADU Deployment Management API

#### Create Update Payload

We mentioned above that you need to build/download a device image update or create Device-State Manifest. In this Sample code we will deploy an update to a simulator device and we can therefore create simulated device image (arbitrary file would do). In the Samples you will see that we simply create a simple JSON file that we name `setup.exe` and deploy to the simulator device.

#### Create Import Manifest

Create an ADU import manifest (metadata about the update). The manifest will contain compatibility/applicability information, as well as file names and hashes for validation.

#### Upload Import Manifest and Update Payload to Azure Blob

The Samples application takes two command-line arguments `connectionString` and `blobContainer` that will be used to upload the two files to Azure Blob container.

#### Import the update

Now that we have the update artifacts ready, we can create `ImportUpdateInput` and start the import. The Samples uses the following code to create the proper object:

``` C#
var update = new ImportUpdateInput(
                new ImportManifestMetadata(
                    importManifestUrl, 
                    importManifestFileSize, 
                    new Dictionary<string, string>()
                    {
                        { "SHA256", importManifestFileHash}
                    }), 
                new[]
                {
                    new FileImportMetadata(payloadUrl)
                });
```

With that we can the import:

```c#
Response<string> operationResponse = await _updatesClient.ImportUpdateAsync(update);
string operationId = operationIdResponse.Value;
```

The import operation is asynchronous long-running operation that uses step-aside approach. The operation returns the operation identifier, that you can use to check the status of the import operation.

```c#
while (true)
{
    Response<Operation> response = await _updatesClient.GetOperationAsync(operationId);
    if (response.Value.Status == "Succeeded")
    {
		break;
    }
    else if (response.Value.Status == "Failed")
    {
        throw new ApplicationException("Import failed:\n" + JsonConvert.SerializeObject(response.Value, Formatting.Indented));
    }
    else
    {
        await Task.Delay(GetRetryAfterFromResponse(response));
    }
}
```

`GetRetryAfterFromResponse` is a helper method that retrieves `Retry-After` header value to wait before checking the status again.

### Retrieve existing Update

Using `GetUpdateAsync` you can retrieve existing update:

```C#
Response<Update> response = await _updatesClient.GetUpdateAsync(
    provider, name, version);
```

If the update doesn't exist, then the method will throw `RequestFailedException` exception where you can check the status:

```c#
 if (e.Status == (int)HttpStatusCode.NotFound) // TODO...
```

### Delete Update

To delete an update, pass in the update identity to `DeleteUpdateAsync` method:

```C#
Response<string> operationResponse = await _updatesClient.DeleteUpdateAsync(
    provider, name, version);
```

Similar to importing update, the method will return job identity and you need to check the status of the asynchronous job.

## Device Management

### Create Simulator Device

To create a simulator device, follow steps on [Getting Started Using Ubuntu (18.04 x64) Simulator Reference Client](https://docs.microsoft.com/azure/iot-hub-device-update/device-update-simulator) page.

When you do that and have your simulator running, use your device identifier as `device` command-line argument.

### Device properties

Before you install something on a device you might want to check the currently installed update on a device:

```c#
Response<Device> deviceResponse = await _devicesClient.GetDeviceAsync(_deviceId);
UpdateId currentlyInstalledUpdateId = deviceResponse.Value.InstalledUpdateId;
```

Instead of checking all individual devices, you can check update compliance for a device group:

```c#
UpdateCompliance compliance = await _devicesClient.GetGroupUpdateComplianceAsync(groupId);
int totalNumberOfDevicesInGroup = compliance.GetTotalDeviceCount();
int devicesThatCouldBeUpdated = compliance.GetNewUpdatesAvailableDeviceCount();
```

Based on this we can decided to deploy a specific update to the group of devices.

## Deployment Management

### Deploy Update to Device

We can deploy ADU update to our simulator device:

```c#
Response<Deployment> response = await _deploymentsClient.CreateOrUpdateDeploymentAsync(
    deploymentId,
    new Deployment(
        deploymentId,
        DeploymentType.Complete,
        DateTimeOffset.UtcNow,
        DeviceGroupType.DeviceGroupDefinitions,
        new[] { groupId },
        new UpdateId(manufacturer, name, version)));
```

`DeploymentId` must be a new unique string identifier for this particular deployment. Because in our Samples we are deploying to a simulator device, we need to specify the identifier of the device group to which the device belong and the update identity.

It will take some time for the update to get deployed. You should periodically check the deployment status:

```c#
Response<DeploymentStatus> status = await _deploymentsClient.GetDeploymentStatusAsync(deploymentId);
```

The response object has `DeploymentState` property where you can see the current status. When the deployment is finished with success, the property will have value of `DeploymentState.Completed`.

### Cancel Deployment

You can cancel current deployment by calling `CancelDeploymentAsync` method.

```c#
Response<Deployment> response = await _deploymentsClient.CancelDeploymentAsync(deploymentId);
```