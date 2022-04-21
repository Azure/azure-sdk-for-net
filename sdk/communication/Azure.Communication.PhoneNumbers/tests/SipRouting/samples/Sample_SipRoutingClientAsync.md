# Managing SIP routing configuration

This sample demonstrates how to retrieve and manage SIP Trunks and SIP routing configuration for Azure Communication resources.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.PhoneNumbers/README.md) for links and instructions.

## Creating a SipRoutingClient

To create a new `SipRoutingClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateSipRoutingClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new SipRoutingClient(connectionString);
```

## Operations on collections
To retrieve or replace current Trunk or Route configuration, SDK provides several functions that operate on whole collection.

#### Set SIP configuration
Set SIP trunks and routes in bulk.

```C# Snippet: Replace SIP trunks and routes
// Cannot delete trunks that are used in any of the routes, therefore first set the routes as empty list, and then update routes.
var newTrunks = <new_trunks_list>;
var newRoutes = <new_routes_list>;

await client.SetRoutesAsync(new List<SipTrunkRoute>());
await client.SetTrunksAsync(<trunks_list>);
await client.SetRoutesAsync(<routes_list>);
```

#### Retrieve SIP configuration
```C# Snippet:Retrieve SIP trunks and routes
var trunks = await client.GetTrunksAsync();
var routes = await client.GetRoutesAsync();
```

## Operations on a single trunk
The SDK allows also for retrieving, setting and deleting single item from the collection.

#### Retrieve single item
```C# Snippet:Retrieve one item
var trunk = client.GetTrunkAsync("<trunk_fqdn>");
var route = client.GetRouteAsync("<route_name>");
```

#### Set single item
```C# Snippet:Set one item
// Set function will either modify existing item, or append the new item to the collection.
client.SetTrunkAsync(<updated_trunk_object>);
client.SetRouteAsync(<updated_route_object>);
```

#### Delete single item
```C# Snippet:Delete one item
client.DeleteTrunkAsync("<trunk_fqdn>");
client.DeleteRouteAsync("<route_name>");
```
