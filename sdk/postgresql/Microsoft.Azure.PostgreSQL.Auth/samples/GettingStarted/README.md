# Getting Started with Azure Entra Authentication for PostgreSQL

This sample demonstrates how to connect to Azure Database for PostgreSQL using Microsoft Entra (formerly Azure Active Directory) authentication with the Npgsql library.

## Prerequisites

- .NET SDK (6.0 or later)
- Azure subscription
- Azure Database for PostgreSQL server with Entra authentication enabled
- Appropriate Azure credentials configured (Azure CLI, managed identity, or environment variables)

## Project Setup

### 1. Create the Project File

Create a `GettingStarted.csproj` file in the `samples/GettingStarted` directory with the following content:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Azure.Identity" Version="1.10.0" />
    <PackageReference Include="Npgsql" Version="8.0.0" />
    <PackageReference Include="Microsoft.Azure.PostgreSQL.Auth" Version="1.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="8.0.0" />
  </ItemGroup>

</Project>
```

**Note:** Update the package versions to the latest stable versions as needed.

### 2. Restore Dependencies

After creating the project file, restore the NuGet packages:

```bash
cd sdk/postgresql/Microsoft.Azure.PostgreSQL.Auth/samples/GettingStarted
dotnet restore
```

## Configuration

### 1. Create Configuration Files

#### appsettings.sample.json

Create an `appsettings.sample.json` file as a template (commit this to source control):

```json
{
  "Host": "<your-server>.postgres.database.azure.com",
  "Database": "postgres",
  "Port": 5432
}
```

#### appsettings.json

Create an `appsettings.json` file with your actual connection details (add this to `.gitignore`):

```json
{
  "Host": "myserver.postgres.database.azure.com",
  "Database": "mydatabase",
  "Port": 5432
}
```

**Important:** Never commit `appsettings.json` with real credentials to source control. Always use `appsettings.sample.json` as a template.

### 2. Alternative: Use Environment Variables

Instead of creating `appsettings.json`, you can set the following environment variables:

```json
{
  "Host": "<your-server>.postgres.database.azure.com",
  "Database": "postgres",
  "Port": 5432
}
```

### 2. Alternative: Use Environment Variables

Instead of creating `appsettings.json`, you can set the following environment variables:

```bash
# Windows PowerShell
$env:Host = "myserver.postgres.database.azure.com"
$env:Database = "mydatabase"
$env:Port = "5432"

# Windows Command Prompt
set Host=myserver.postgres.database.azure.com
set Database=mydatabase
set Port=5432

# Linux/macOS
export Host=myserver.postgres.database.azure.com
export Database=mydatabase
export Port=5432
```

### 3. Configure Azure Authentication

The sample uses `DefaultAzureCredential`, which attempts to authenticate through multiple mechanisms in the following order:

1. **Environment variables** - Set `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, and `AZURE_CLIENT_SECRET`
2. **Managed Identity** - If running on Azure services (App Service, VM, etc.)
3. **Visual Studio** - If signed in to Visual Studio
4. **Azure CLI** - If signed in via `az login`
5. **Azure PowerShell** - If signed in via `Connect-AzAccount`

For local development, the easiest option is to sign in using Azure CLI:

```bash
az login
```

### 4. Grant Database Access

Ensure your Azure identity has been granted access to the PostgreSQL database:

```sql
-- Connect to your PostgreSQL server as an admin
-- Create a database user for your Entra identity
CREATE ROLE "your-username@domain.com" WITH LOGIN;
GRANT ALL PRIVILEGES ON DATABASE your_database TO "your-username@domain.com";
```

For managed identities:

```sql
CREATE ROLE "your-app-name" WITH LOGIN;
GRANT ALL PRIVILEGES ON DATABASE your_database TO "your-app-name";
```

## Building the Sample

Navigate to the sample directory and build the project:

```bash
cd sdk/postgresql/Microsoft.Azure.PostgreSQL.Auth/samples/GettingStarted
dotnet build
```

## Running the Sample

Execute the compiled application:

```bash
dotnet run
```

## Complete Code Sample

```csharp
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Azure.PostgreSQL.Auth;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GettingStarted;

/// <summary>
/// This example enables Entra authentication before connecting to the database via Npgsql.
/// </summary>
public class CreateDbConnectionNpgsql
{
    public static async Task Main(string[] args)
    {
        // Minimal, copy/paste-friendly snippet.
        string server = "<server>.postgres.database.azure.com";
        string database = "<database>";
        int port = 5432;

        string connectionString = $"Host={server};Database={database};Port={port};SSL Mode=Require;";
        await ExecuteQueriesWithEntraAuth(connectionString, useAsync: true);
        Console.WriteLine("=== Getting Started with Azure Entra Authentication for PostgreSQL ===\n");

        // Build configuration (local dev convenience)
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        var server = configuration["Host"];
        var database = configuration["Database"] ?? "postgres";
        var port = configuration.GetValue<int>("Port", 5432);

        if (string.IsNullOrWhiteSpace(server))
        {
            Console.WriteLine("Missing required configuration: Host");
            Console.WriteLine("Set Host in appsettings.json or via environment variables.");
            return;
        }

        var connectionString = $"Host={server};Database={database};Port={port};SSL Mode=Require;";

        Console.WriteLine("--- Testing UseEntraAuthentication (sync) ---");
        await ExecuteQueriesWithEntraAuth(connectionString, useAsync: false);

        Console.WriteLine("\n--- Testing UseEntraAuthenticationAsync ---");
        await ExecuteQueriesWithEntraAuth(connectionString, useAsync: true);

        Console.WriteLine("\n=== Sample completed ===");

    }

    /// <summary>
    /// Creates a connection to the database with Entra authentication and runs a simple query.
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string</param>
    /// <param name="useAsync">If true, uses UseEntraAuthenticationAsync; otherwise uses UseEntraAuthentication</param>
    private static async Task ExecuteQueriesWithEntraAuth(string connectionString, bool useAsync = false)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

        // Enable Entra Authentication via extension methods.
        var credential = new DefaultAzureCredential();

        if (useAsync)
        {
            await dataSourceBuilder.UseEntraAuthenticationAsync(credential);
        }
        else
        {
            dataSourceBuilder.UseEntraAuthentication(credential);
        }

        await using var dataSource = dataSourceBuilder.Build();
        await using var connection = await dataSource.OpenConnectionAsync();

        await using var cmd = new NpgsqlCommand("SELECT version()", connection);
        var version = await cmd.ExecuteScalarAsync();

#if SNIPPET
        Console.WriteLine(version);
#else
        Console.WriteLine($"PostgreSQL Version: {version}");
#endif
    }
}
```

## How It Works

The sample demonstrates two approaches to enable Entra authentication with Npgsql:

### Synchronous Approach

```csharp
var credential = new DefaultAzureCredential();
dataSourceBuilder.UseEntraAuthentication(credential);
```

### Asynchronous Approach

```csharp
var credential = new DefaultAzureCredential();
await dataSourceBuilder.UseEntraAuthenticationAsync(credential);
```

Both methods configure the `NpgsqlDataSourceBuilder` to use Entra authentication tokens when connecting to the database.

## Troubleshooting

### "Missing required configuration: Host"

Ensure you have either:
- Created an `appsettings.json` file with the `Host` property
- Set the `Host` environment variable

### Authentication Errors

- Verify you're signed in to Azure CLI: `az login`
- Confirm your Azure identity has been granted access to the database
- Check that your PostgreSQL server has Entra authentication enabled

### Connection Errors

- Verify the server name is correct (format: `<server-name>.postgres.database.azure.com`)
- Ensure port 5432 is not blocked by firewalls
- Confirm your IP address is allowed in the PostgreSQL server firewall rules

## Additional Resources

- [Azure Database for PostgreSQL documentation](https://learn.microsoft.com/azure/postgresql/)
- [Npgsql documentation](https://www.npgsql.org/doc/)
- [Azure Identity library](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme)
- [Configure Entra authentication for Azure Database for PostgreSQL](https://learn.microsoft.com/azure/postgresql/flexible-server/how-to-configure-sign-in-azure-ad-authentication)
