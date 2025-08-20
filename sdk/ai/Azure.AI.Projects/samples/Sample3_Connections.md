# Sample using `Connections` in Azure.AI.Projects

In this example, we will demonstrate listing and retrieving connections using the `Connections` client in `Azure.AI.Projects`. This includes listing all connections, filtering by connection type, and retrieving specific connection details.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `CONNECTION_NAME`: The name of the connection to retrieve.

## Synchronous sample:
```C# Snippet:AI_Projects_ConnectionsExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Connections connectionsClient = projectClient.GetConnectionsClient();

Console.WriteLine("List the properties of all connections:");
foreach (var connection in connectionsClient.GetConnections())
{
    Console.WriteLine(connection);
    Console.Write(connection.Name);
}

Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
foreach (var connection in connectionsClient.GetConnections(connectionType: ConnectionType.AzureOpenAI))
{
    Console.WriteLine(connection);
}

Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
var specificConnection = connectionsClient.Get(connectionName, includeCredentials: false);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
var specificConnectionCredentials = connectionsClient.Get(connectionName, includeCredentials: true);
Console.WriteLine(specificConnectionCredentials);

Console.WriteLine($"Get the properties of the default connection:");
var defaultConnection = connectionsClient.GetDefault(includeCredentials: false);
Console.WriteLine(defaultConnection);

Console.WriteLine($"Get the properties of the default connection with credentials:");
var defaultConnectionCredentials = connectionsClient.GetDefault(includeCredentials: true);
Console.WriteLine(defaultConnectionCredentials);
```

## Asynchronous sample:
```C# Snippet:AI_Projects_ConnectionsExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Connections connectionsClient = projectClient.GetConnectionsClient();

Console.WriteLine("List the properties of all connections:");
await foreach (var connection in connectionsClient.GetConnectionsAsync())
{
    Console.WriteLine(connection);
    Console.Write(connection.Name);
}

Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
await foreach (var connection in connectionsClient.GetConnectionsAsync(connectionType: ConnectionType.AzureOpenAI))
{
    Console.WriteLine(connection);
}

Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
var specificConnection = await connectionsClient.GetAsync(connectionName, includeCredentials: false);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
var specificConnectionCredentials = await connectionsClient.GetAsync(connectionName, includeCredentials: true);
Console.WriteLine(specificConnectionCredentials);

Console.WriteLine($"Get the properties of the default connection:");
var defaultConnection = await connectionsClient.GetDefaultAsync(includeCredentials: false);
Console.WriteLine(defaultConnection);

Console.WriteLine($"Get the properties of the default connection with credentials:");
var defaultConnectionCredentials = await connectionsClient.GetDefaultAsync(includeCredentials: true);
Console.WriteLine(defaultConnectionCredentials);
```
