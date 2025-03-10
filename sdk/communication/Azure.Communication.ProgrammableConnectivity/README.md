# Azure ProgrammableConnectivity client library for .NET

This client library allows .NET applications to interact with Azure Programmable Connectivity Gateway, instead of using `curl` requests. For information on APC, see [docs](https://learn.microsoft.com/azure/programmable-connectivity/).

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.ProgrammableConnectivity/src) | Package (NuGet): `https://www.nuget.org/packages/Azure.Communication.ProgrammableConnectivity` | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/azure)

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.ProgrammableConnectivity/samples).

### Key concepts

For each call that you make to APC with the SDK, you will follow the same pattern:
* Create a client and sub-client for your use case (sim-swap/location/number-verification/device-network)
* Create the content for your request by using the objects given by the SDK
* Call the client with the content
* Access the result returned

```C# Snippet:APC_Sample_SimSwapRetrieveTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
SimSwap client = baseClient.GetSimSwapClient();

SimSwapRetrievalContent content = new SimSwapRetrievalContent(
    new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+50000000000",
};

Response<SimSwapRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, content);
Console.WriteLine(response.Value.Date);
```

When handling an error, catch `RequestFailedException`, and log the details.

```C# Snippet:APC_Sample_NetworkRetrievalBadIdentifierTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
DeviceNetwork client = baseClient.GetDeviceNetworkClient();

NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv5", "127.0.0.1");
try
{
    Response<NetworkRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, networkIdentifier);
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Exception Message: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.Status}");
    Console.WriteLine($"Error Code: {ex.ErrorCode}");
}
```

## Troubleshooting

If your call doesn't work, we recommend logging the exception messages, and progressing from there.

Try sending the request with `curl` or with HTTP files, using postman for example. This will narrow down the issue you're facing.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

APC is currently not accepting/expecting contributions for this codebase. Suggestions/issues are welcome.
