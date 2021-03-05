# Azure Device Update for IoT Hub client library for .NET

The library provides access to the Device Update for IoT Hub service that enables customers to publish updates for their IoT devices to the cloud, and then deploy these updates to their devices (approve updates to groups of devices managed and provisioned in IoT Hub). 

  [Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk) | [Package](https://www.nuget.org) | [Product documentation](https://docs.microsoft.com/azure/iot-hub-device-update/understand-device-update)


## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads](https://azure.microsoft.com/downloads/?sdk=net) page and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, you need to create an [Azure subscription](https://azure.microsoft.com/free/)
- Device Update for IoT Hub instance
- Azure IoT Hub instance

### Install the package

Install the Device Update for IoT Hub client library for .NET with [NuGet](https://www.nuget.org/ ):

```PowerShell
dotnet add package Azure.Iot.DeviceUpdate --version 1.0.0-beta.1
```

### Authenticate the Client

In order to interact with the Device Update for IoT Hub service, you will need to create an instance of a [TokenCredential class](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) and pass it to the constructor of your UpdateClient, DeviceClient and DeploymentClient class.

## Key concepts

Device Update for IoT Hub is a managed service that enables you to deploy over-the-air updates for your IoT devices. The client library has three main components:
- **UpdatesClient**: update management (import, enumerate, delete, etc.)
- **DevicesClient**: device management (enumerate devices and retrieve device properties)
- **DeploymentsClient**: deployment management (start and monitor update deployments to a set of devices)

You can learn more about Device Update for IoT Hub by visiting [Device Update for IoT Hub](https://github.com/azure/iot-hub-device-update).

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk).

## Troubleshooting

All Device Update for IoT Hub service operations will throw a RequestFailedException on failure with helpful ErrorCodes.

For example, if you use the `GetUpdateAsync` operation and the model you are looking for doesn't exist, you can catch that specific [HttpStatusCode](https://docs.microsoft.com/dotnet/api/system.net.httpstatuscode?view=netcore-3.1) to decide the operation that follows in that case.

```csharp
try
{
    Response<Update> update = await _updatesClient.GetUpdateAsync(
      "provider", "name", "1.0.0.0")
      .ConfigureAwait(false);
}
catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
{
    // Update does not exist.
}

```

## Next steps

Get started with our [Device Update for IoT Hub samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk)

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.
