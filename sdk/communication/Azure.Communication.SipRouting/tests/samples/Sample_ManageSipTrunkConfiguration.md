# Retrieving and updating resource SIP routing configuration

This sample demonstrates how to get and update SIP configuration for Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp) for links and instructions.

## Creating a SipRoutingClient

To create a new `SipRoutingClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```csharp Snippet:CreateSipRoutingClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var clientOptions = new SipRoutingClientOptions();
var client = new SipRoutingClient(connectionString, clientOptions);
```


## Retrieve current SIP configuration

```csharp Snippet:GetSipConfiguration
// Get SIP configuration for resource
SipConfiguration config = client.GetSipConfiguration();

foreach (var trunk in config.Trunks)
{
    Console.WriteLine($"Sip trunk is set with {trunk.Key} and port {trunk.Value.SipSignalingPort}");
}

foreach (var route in config.Routes)
{
    Console.WriteLine($"{route.Name}: {route.Description}");
}
```
## Update SIP configuration

#### Update SIP trunks
```csharp Snippet:UpdateTrunks
var updatedTrunks = new Dictionary<string,Trunk>()
{
    { "sbs1.contoso.com", new Trunk(1122) },
    { "sbs2.contoso.com", new Trunk(8888) }
};
var response = client.UpdateTrunks(updatedTrunks);
```

#### Update SIP routing settings

```csharp Snippet:UpdateRoutingSettings
var updatedRoutes = new List<TrunkRoute>
{
    new TrunkRoute(
        name: "Updated rule",
        description: "Handle all other numbers",
        numberPattern: @"\+[1-9][0-9]{3,23}",
        trunks: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
};
var response = client.UpdateRoutingSettings(updatedRoutes);
```
#### Update full SIP routing configuration

```csharp Snippet:UpdateSipTrunkConfiguration
var trunks = new Dictionary<string,Trunk>()
{
    { "sbs1.contoso.com", new Trunk(1122) }
};
var routes = new List<TrunkRoute>
{
    new TrunkRoute(
        name: "Initial rule",
        description: "Handle all other numbers",
        numberPattern : @"\+123[0-9]+",
        trunks : new List<string>{ "sbs1.contoso.com" })
};
var response = client.UpdateSipTrunkConfiguration(new SipConfiguration(trunks, routes));
```
