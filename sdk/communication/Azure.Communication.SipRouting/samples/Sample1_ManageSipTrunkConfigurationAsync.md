# Retrieving and updating resource calling configuration

This sample demonstrates how to get and update calling configuration for Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp) for links and instructions.

## Creating a CallingConfigurationClient

To create a new `CallingConfigurationClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateCallingConfigurationClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var clientOptions = new CallingConfigurationClientOptions();
var client = new CallingConfigurationClient(connectionString, clientOptions);
```


## Retrieve current calling configuration

```C# Snippet:GetCallingConfigurationAsync
// Get calling configuration for resource
AcsResourceCallingConfiguration config = await client.GetCallingConfigurationAsync();

foreach (var trunk in config.OnlinePstnGateways)
{
    Console.WriteLine($"Sip trunk is set with {trunk.Fqdn} and port {trunk.SipSignalingPort}");
}

foreach (var routingRule in config.OnlinePstnRoutingSettings)
{
    Console.WriteLine($"{routingRule.Name}: {routingRule.Description}");
}
```
## Update calling configuration

```C# Snippet:UpdatePstnGatewaysAsync
// Update calling configuration for resource
var updatedPstnGateways = new List<TrunkConfig>()
{
    new TrunkConfig("sbs1.contoso.com", 1122),
    new TrunkConfig("sbs2.contoso.com", 8888),
};
response = await client.UpdatePstnGatewaysAsync(updatedPstnGateways);
// Output:
//
```


```C# Snippet:UpdatePstnRoutingSettingsAsync
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
response = await client.UpdateRoutingSettingsAsync(updatedPstnRoutingSettings);
// Output:
//
```


```C# Snippet:UpdateCallingConfigurationAsync
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
var response = await client.UpdateSipTrunkConfigurationAsync(onlinePstnGateways, onlinePstnRoutingSettings);
// Output:
//
```

