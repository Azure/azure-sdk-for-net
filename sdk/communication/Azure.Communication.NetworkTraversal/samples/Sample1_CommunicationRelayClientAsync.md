# Obtain a Relay Configuration for Network Traversal from Azure Communication Services

This sample demonstrates how to obtain a relay configuration for network traversal from Azure Communication Services. You can use this configuration for STUN/TURN relay scenarios.

To get started you'll need an Azure Communication Services resource. See the README for prerequisites and instructions.

## Create a `CommunicationRelayClient`

To create a new `CommunicationRelayClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateCommunicationRelayClientAsync
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

## Get Relay Configuration

The example code snippet below shows how to get a relay configuration for an Azure Communication user. For examples on how to create a Azure Communication user, view the [Identity Samples][identity_samples].
A configuration is returned for the user. Each configuration consists of a URL for a TURN server, its corresponding username and a credential. 

Every relay configuration has an expiry date and time stamped on it, indicating when the set of TURN credentials will no longer be accepted. Once the credentials have expired, you can renew the token by calling the same method.

```C# Snippet:GetRelayConfigurationAsync
Response<CommunicationRelayConfiguration> relayConfiguration = await client.GetRelayConfigurationAsync();
DateTimeOffset turnTokenExpiresOn = relayConfiguration.Value.ExpiresOn;
IReadOnlyList<CommunicationIceServer> iceServers = relayConfiguration.Value.IceServers;
Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
foreach (CommunicationIceServer iceServer in iceServers)
{
    foreach (string url in iceServer.Urls)
    {
        Console.WriteLine($"ICE Server Url: {url}");
    }
    Console.WriteLine($"ICE Server Username: {iceServer.Username}");
    Console.WriteLine($"ICE Server Credential: {iceServer.Credential}");
    Console.WriteLine($"ICE Server RouteType: {iceServer.RouteType}");
}
```

<!-- LINKS -->

[azure_portal]: https://portal.azure.com
[identity_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Identity/samples
