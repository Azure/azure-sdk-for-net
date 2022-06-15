# Managing SIP routing configuration

This sample demonstrates how to retrieve and manage SIP routing configuration for Azure Communication resources.
To get started, you'll need a URI to an Azure Communication Services resource. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.PhoneNumbers/README.md) for links and instructions.

## Creating a SipRoutingClient

To create a new `SipRoutingClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` as an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateSipRoutingClient
// Get a connection string to Azure Communication resource.
var connectionString = "<connection_string>";
var client = new SipRoutingClient(connectionString);
```

## Operations on collections
To retrieve or replace current Trunk or Route configuration, SDK provides several functions that operate on the whole collection.

#### Set SIP configuration
Set SIP trunks and routes in bulk.

```C# Snippet:Replace
// The service will not allow trunks that are used in any of the routes to be deleted, therefore first set the routes as empty list, and then update the routes.
var newTrunks = "<new_trunks_list>";
var newRoutes = "<new_routes_list>";
client.SetRoutes(new List<SipTrunkRoute>());
client.SetTrunks(newTrunks);
client.SetRoutes(newRoutes);
```

#### Retrieve SIP trunks and routes
```C# Snippet:RetrieveList
var trunksResponse = client.GetTrunks();
var routesResponse = client.GetRoutes();
```

## Operations on a single trunk
The SDK allows also for retrieving, setting and deleting single trunk from the collection.

#### Retrieve single trunk
```C# Snippet:RetrieveTrunk
// Get trunk object, based on it's FQDN.
var fqdnToRetrieve = "<fqdn>";
var trunkResponse = client.GetTrunk(fqdnToRetrieve);
```

#### Set single trunk
```C# Snippet:SetTrunk
// Set function will either modify existing item or add new item to the collection.
// The trunk is matched based on it's FQDN.
var trunkToSet = "<trunk_to_set>";
client.SetTrunk(trunkToSet);
```

#### Delete single trunk
```C# Snippet:DeleteTrunk
// Deletes trunk with supplied FQDN.
var fqdnToDelete = "<fqdn>";
client.DeleteTrunk(fqdnToDelete);
```
