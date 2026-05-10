# Getting started with Entra ID authentication for PostgreSQL

This sample demonstrates how to configure Entra ID (formerly Azure Active Directory) authentication for Azure Database for PostgreSQL using the Npgsql driver.
To get started, you'll need an Azure Database for PostgreSQL Flexible Server with Entra ID authentication enabled. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/postgresql/Microsoft.Azure.PostgreSQL.Auth/README.md) for links and instructions.

## Configuring synchronous authentication

To configure Entra ID authentication, create an `NpgsqlDataSourceBuilder` with your connection string and call `UseEntraAuthentication` with a `TokenCredential`.
The extension method extracts the username from the Entra ID token and configures a password provider that supplies fresh tokens for each connection.

```C# Snippet:PostgreSqlAuth_Sample01_Sync
var credential = new DefaultAzureCredential();
var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require";

var builder = new NpgsqlDataSourceBuilder(connectionString);
builder.UseEntraAuthentication(credential);

await using var dataSource = builder.Build();
```

## Configuring asynchronous authentication

For applications that prefer asynchronous initialization, use `UseEntraAuthenticationAsync`. This performs the same token acquisition and username extraction asynchronously.

```C# Snippet:PostgreSqlAuth_Sample01_Async
var credential = new DefaultAzureCredential();
var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require";

var builder = new NpgsqlDataSourceBuilder(connectionString);
await builder.UseEntraAuthenticationAsync(credential);

await using var dataSource = builder.Build();
```

## Querying the database

Once the data source is configured, you can open connections and execute queries as usual. The password provider automatically acquires fresh tokens as needed.

```C# Snippet:PostgreSqlAuth_Sample01_Query
await using var connection = await dataSource.OpenConnectionAsync();
await using var cmd = new NpgsqlCommand("SELECT version()", connection);
var version = await cmd.ExecuteScalarAsync();
```

## Using a specific connection string username

If your connection string already includes a `Username`, the extension method will skip token-based username extraction and use the provided value. This is useful when the database role name differs from the Entra ID identity.

```C# Snippet:PostgreSqlAuth_Sample01_ExplicitUsername
var credential = new DefaultAzureCredential();
var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;Username=my-db-role;SSL Mode=Require";

var builder = new NpgsqlDataSourceBuilder(connectionString);
builder.UseEntraAuthentication(credential);
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
