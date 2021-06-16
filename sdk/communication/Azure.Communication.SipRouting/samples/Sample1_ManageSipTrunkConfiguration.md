# Retrieving and updating resource calling configuration

This sample demonstrates how to get and update calling configuration for Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp) for links and instructions.

## Creating a SipRoutingClient

To create a new `SipRoutingClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateSipRoutingClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var clientOptions = new SipRoutingClientOptions();
var client = new SipRoutingClient(connectionString, clientOptions);
```


## Retrieve current SIP configuration

```C# Snippet:GetSipConfiguration
// Get SIP configuration for resource
AcsResourceCallingConfiguration config = client.GetSipConfiguration();

foreach (var trunk in config.trunks)
{
    Console.WriteLine($"Sip trunk is set with {trunk.Fqdn} and port {trunk.SipSignalingPort}");
}

foreach (var routingRule in config.OnlinePstnRoutingSettings)
{
    Console.WriteLine($"{routingRule.Name}: {routingRule.Description}");
}
```
## Update calling configuration

```C# Snippet:UpdatePstnGateways
// Update SIP configuration for resource
var updatedPstnGateways = new List<TrunkConfig>()
{
    new TrunkConfig("sbs1.contoso.com", 1122),
    new TrunkConfig("sbs2.contoso.com", 8888),
};
var response1 = client.UpdatePstnGatewaysAsync(updatedPstnGateways);
// Output:
//
```


```C# Snippet:UpdatePstnRoutingSettings
var updatedPstnRoutingSettings = new List<OnlineRoute>
{
    new OnlineRoute(
        name: "Updated rule",
        numberPattern: @"\+[1-9][0-9]{3,23}",
        onlinePstnGatewayList: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
    {
        Description = "Handle all othe runmbers'",
    }
};
var response2 = client.UpdateRoutingSettings(updatedPstnRoutingSettings);
// Output:
//
```


```C# Snippet:UpdateCallingConfiguration
// Update calling configuration for resource
var onlinePstnGateways = new List<TrunkConfig>()
{
    new TrunkConfig("sbs1.contoso.com", 1122),
};
var onlinePstnRoutingSettings = new List<OnlineRoute>
{
    new OnlineRoute(
        name: "Initial rule",
        numberPattern : @"\+123[0-9]+",
        onlinePstnGatewayList : new List<string>{ "sbs1.contoso.com" })
    {
        Description = "Handle numbers starting with '+123'",
    },
};
var response = client.UpdateSipTrunkConfigurationAsync(onlinePstnGateways, onlinePstnRoutingSettings);
// Output:
//
```

