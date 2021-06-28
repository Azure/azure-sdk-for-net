# Azure Communication Network Traversal client library for .NET

Azure Communication Network Traversal enables high bandwidth, low latency connections between peers for real-time communication scenarios and data transfer scenarios by providing access to low-level STUN and TURN services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] <!--| [Samples][source_samples]-->
## Getting started

### Install the package

Install the Azure Communication Network Traversal client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.NetworkTraversal --version 1.0.0-beta.1
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Authenticate the client

The networking client can be authenticated using a connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationRelayClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationRelayClient(connectionString);
```

Or alternatively using the endpoint and access key acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationRelayFromAccessKey
var endpoint = new Uri("https://my-resource.communication.azure.com");
var accessKey = "<access_key>";
var client = new CommunicationRelayClient(endpoint, new AzureKeyCredential(accessKey));
```

Clients also have the option to authenticate using a valid Active Directory token.

```C# Snippet:CreateCommunicationRelayFromToken
var endpoint = new Uri("https://my-resource.communication.azure.com");
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new CommunicationRelayClient(endpoint, tokenCredential);
```

### Key concepts

`CommunicationRelayClient` provides the functionalities to gain STUN/TURN server URLs and credentials for access.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

## Generating TURN credentials for a user

```C# Snippet:GetRelayConfigurationAsync
Response<CommunicationRelayConfiguration> turnTokenResponse = await client.GetRelayConfigurationAsync(user);
DateTimeOffset turnTokenExpiresOn = turnTokenResponse.Value.ExpiresOn;
IReadOnlyList<CommunicationTurnServer> turnServers = turnTokenResponse.Value.TurnServers;
Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
foreach (CommunicationTurnServer turnServer in turnServers)
{
    foreach (string url in turnServer.Urls)
    {
        Console.WriteLine($"TURN Url: {url}");
    }
    Console.WriteLine($"TURN Username: {turnServer.Username}");
    Console.WriteLine($"TURN Credential: {turnServer.Credential}");
}
```

## Troubleshooting

> TODO

## Next steps

> TODO

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.NetworkTraversal/src
<!--[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.NetworkTraversal/samples-->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
<!--[package]: https://www.nuget.org/packages/Azure.Communication.NetworkTraversal-->
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
