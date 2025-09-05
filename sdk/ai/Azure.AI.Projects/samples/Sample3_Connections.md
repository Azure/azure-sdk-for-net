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

Console.WriteLine("List the properties of all connections:");
foreach (ConnectionProperties connection in projectClient.Connections.GetConnections())
{
    Console.WriteLine(connection);
    Console.WriteLine(connection.Name);
}

Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
foreach (ConnectionProperties connection in projectClient.Connections.GetConnections(connectionType: ConnectionType.AzureOpenAI))
{
    Console.WriteLine(connection);
}

Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
ConnectionProperties specificConnection = projectClient.Connections.GetConnection(connectionName, includeCredentials: false);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
ConnectionProperties specificConnectionCredentials = projectClient.Connections.GetConnection(connectionName, includeCredentials: true);
Console.WriteLine(specificConnectionCredentials);

Console.WriteLine($"Get the properties of the default connection:");
ConnectionProperties defaultConnection = projectClient.Connections.GetDefaultConnection(includeCredentials: false);
Console.WriteLine(defaultConnection);

Console.WriteLine($"Get the properties of the default connection with credentials:");
ConnectionProperties defaultConnectionCredentials = projectClient.Connections.GetDefaultConnection(includeCredentials: true);
Console.WriteLine(defaultConnectionCredentials);
```

## Asynchronous sample:
```C# Snippet:AI_Projects_ConnectionsExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("List the properties of all connections:");
await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync())
{
    Console.WriteLine(connection);
    Console.Write(connection.Name);
}

Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync(connectionType: ConnectionType.AzureOpenAI))
{
    Console.WriteLine(connection);
}

Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
ConnectionProperties specificConnection = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: false);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
ConnectionProperties specificConnectionCredentials = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: true);
Console.WriteLine(specificConnectionCredentials);

Console.WriteLine($"Get the properties of the default connection:");
ConnectionProperties defaultConnection = await projectClient.Connections.GetDefaultConnectionAsync(includeCredentials: false);
Console.WriteLine(defaultConnection);

Console.WriteLine($"Get the properties of the default connection with credentials:");
ConnectionProperties defaultConnectionCredentials = await projectClient.Connections.GetDefaultConnectionAsync(includeCredentials: true);
Console.WriteLine(defaultConnectionCredentials);
```
