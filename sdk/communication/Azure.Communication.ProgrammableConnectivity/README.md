# Azure ProgrammableConnectivity client library for .NET

This client library allows .NET applications to interact with Azure Programmable Connectivity Gateway, instead of using `curl` requests. For information on APC, see [docs](https://learn.microsoft.com/azure/programmable-connectivity/).

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/programmableconnectivity/Azure.Communication.ProgrammableConnectivity/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Communication.ProgrammableConnectivity) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Communication.ProgrammableConnectivity --prerelease
```

### Prerequisites

Before you can use the SDK successfully, you'll need to
* Follow the [guide](https://learn.microsoft.com/azure/programmable-connectivity/azure-programmable-connectivity-create-gateway) to create a gateway, or have one already.
* Note down your endpoint and `apc-gateway-id`, which is retrieved by following the guide linked.

### Authenticate the client

The client library uses [`Azure.Identity`](https://learn.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet) credentials to authenticate with APC. The examples given in this repo use [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/programmableconnectivity/Azure.Communication.ProgrammableConnectivity/samples).

### Key concepts for each example

For each call that you make to APC with the SDK, you will follow the same pattern:
* Create a client `baseClient = new ProgrammableConnectivityClient()`
* Access the sub-client for your use case (sim-swap/location/number-verification/device-network) by calling say `baseClient.GetSimSwapClient()`
* Create the content for your request by using the objects given by the SDK, for example `SimSwapVerificationContent`
* Call the client with the content you've created
* Access the result

When handling an error, catch `RequestFailedException`, and log the details. See [README.md](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/programmableconnectivity/Azure.Communication.ProgrammableConnectivity/samples/README.md) for a specific example.

## Troubleshooting

If your call doesn't work, we recommend logging the exception messages, and progressing from there. You can see an example of how to handle errors [here](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/programmableconnectivity/Azure.Communication.ProgrammableConnectivity/samples/README.md)

## Contributing

APC is currently not accepting/expecting contributions for this codebase.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/programmableconnectivity/Azure.Communication.ProgrammableConnectivity/README.png)
