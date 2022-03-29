# Device Update for IoT Hub SDK Samples

There are multiple simple projects demonstrating how to use some of the basic Device Update for IoT Hub APIs.

## Samples

### Configuration

The samples projects are referencing `Constant.cs` file which contains some of the common configuration values
used throughout the samples.

| Constant        | Description                                                                                  |
|-----------------|----------------------------------------------------------------------------------------------|
| TenantId        | AAD tenant identifier                                                                        |
| ClientId        | AAD client identifier                                                                        |
| AccountEndpoint | Device Update for IoT Hub account endpoint. Insert your account id into the endpoint address |
| Instance        | Device Update for IoT Hub account instance                                                   |
| Provider        | Update provider to be used                                                                   |
| Name            | Update name to be used                                                                       |

### Running

After you update configuration (by updating `Constant.cs` file), you could either compile and run the samples
from your favorite IDE, or you can run them from command line.

To see the syntax, run the following command from the samples folder that you want to run:

``` shell
dotnet run -- --help
```

### Import new update

To import a new update, use **ImportUpdate** sample. To run the tool you need to provide two arguments `--connection-string` 
and `--blob-container`. In the first argument, specify Azure Blob Storage connection string. The sample will use it to 
upload payload and manifest file there. The second argument contains the name of the blob container where the files 
will be uploaded.

### Enumerate existing updates

To enumerate existing updates, use **EnumerateUpdates** sample. The sample doesn't require any special argument to run.

### Retrieve existing update

To view existing update metadata, use **GetUpdate** sample. The sample requires you to specify `--update-version` argument.

### Delete existing update

To delete existing update, use **DeleteUpdate** sample. The sample requires you to specify `--update-version` argument.

### Deploy update to device group

To deploy an update to a device group, use **DeployUpdate** sample. The sample requires you to specify `--update-version` 
and `--device-group` arguments.

### Get device information

To display device information, use **GetDevice** sample. The sample requires you to specify `--device` argument.

## Common

### Creating Client

There are two different clients - **DeviceUpdateClient** for update management, **DeviceManagementClient** for device, device
group and deployment management. To create a new client, you need the Device Update for IoT Hub account, instance and
credentials. Once you create your own Device Update for IoT Hub account and instance, you need to properly configure the samples
(by updating `Constant.cs` file).

For authentication, the SDK clients requires an instance of 
[TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In the samples, we use a token credential derived class for interactive login called `InteractiveBrowserCredential`. 
There are other options if you want to use client certificates for authentication (`ClientCertificateCredential`) or 
client secret (`ClientSecretCredential`).

```c#
// By using the InteractiveBrowserCredential, the current user can login using a web browser
// interactively with the AAD
var credential = new InteractiveBrowserCredential(
    tenantId,
    clientId);

var client = new DeviceUpdateClient(
    accountEndpoint,
    instanceId,
    credential);
```

If you need to override pipeline behavior, such as provide your own HttpClient instance, you can do that via an optional `options` argument.

```C#
// This illustrates how to specify client options, in this case, by providing an
// instance of HttpClient for the digital twins client to use.
var options = new DeviceUpdateClientOptions
{
    Transport = new HttpClientTransport(httpClient),
};

var updateClient = new DeviceUpdateClient(
    accountEndpoint,
    instanceId,
    credential,
    options);
```
### Error Handling

If there is a problem calling Device Update for IoT Hub SDK API, the client library will throw `RequestFailedException` exception.
