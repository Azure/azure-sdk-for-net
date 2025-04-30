# Sample for Azure.AI.Projects with `Connections`

In this example, we will demonstrate listing and retrieving connections using the `Connections` client in `Azure.AI.Projects`. This includes listing all connections, filtering by connection type, and retrieving specific connection details.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `CONNECTION_NAME`: The name of the connection to retrieve.

## Synchronous sample:
```C# Snippet:ConnectionsExampleSync
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
var specificConnection = connectionsClient.GetConnection(connectionName);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
var specificConnectionCredentials = connectionsClient.GetWithCredentials(connectionName);
Console.WriteLine(specificConnectionCredentials);
```

## Asynchronous sample:
```C# Snippet:ConnectionsExampleAsync
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
var specificConnection = await connectionsClient.GetConnectionAsync(connectionName);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
var specificConnectionCredentials = await connectionsClient.GetWithCredentialsAsync(connectionName);
Console.WriteLine(specificConnectionCredentials);
```
