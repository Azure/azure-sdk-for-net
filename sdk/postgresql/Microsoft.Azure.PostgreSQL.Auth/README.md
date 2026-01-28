## Overview

This library enables Microsoft Entra ID authentication for Azure Database for PostgreSQL using the Npgsql driver. It eliminates database password management by using secure, token-based authentication through Azure's identity platform.

### Key Benefits

- **Passwordless Authentication**: Uses OAuth 2.0 access tokens instead of database passwords
- **Centralized Identity Management**: Leverages existing Entra ID users and groups  
- **Zero Secrets**: No database credentials stored in application code
- **Automatic Token Handling**: Manages token acquisition and renewal transparently

## Prerequisites

**Azure Database for PostgreSQL Setup:**
- Azure Database for PostgreSQL server with Entra ID authentication enabled
- Entra ID administrator configured (to set up database users)
- Application's Entra ID identity created as a database user with appropriate permissions

**Application Identity (choose one):**
- **Managed Identity**: For applications running in Azure (App Service, Functions, VMs)
- **Service Principal**: For applications with client credentials
- **User Identity**: For development or interactive scenarios

**Example PostgreSQL Setup:**
```sql
-- Connect as Entra ID administrator and create database user
CREATE ROLE "myapp@domain.com" WITH LOGIN;
GRANT CONNECT ON DATABASE mydb TO "myapp@domain.com";
GRANT USAGE ON SCHEMA public TO "myapp@domain.com";
-- Grant additional permissions as needed
```

## Usage

In your program, import the namespace `Microsoft.Azure.PostgreSQL.Auth` 

```csharp
using Microsoft.Azure.PostgreSQL.Auth;
```
Use the extension methods as needed:

### Asynchronous Authentication (Recommended)
```csharp
using Azure.Identity;

// Fill in with connection information to Azure PostgreSQL server
// Note: No username/password in connection string - authentication handled by Entra ID
var connectionString = "Host=myserver.postgres.database.azure.com;Database=mydb;Port=5432;SSL Mode=Require;";
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

// Use the async extension method for Entra authentication
// This will automatically:
// - Detect the current Azure identity (managed identity, service principal, or user)
// - Acquire a PostgreSQL-scoped access token
// - Configure the connection to use token-based authentication
var credential = new DefaultAzureCredential();
await dataSourceBuilder.UseEntraAuthenticationAsync(credential);
```

### Synchronous Authentication
```csharp
using Azure.Identity;

// Fill in with connection information to Azure PostgreSQL server
var connectionString = "Host=myserver.postgres.database.azure.com;Database=mydb;Port=5432;SSL Mode=Require;";
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

// Use the sync extension method for Entra authentication
var credential = new DefaultAzureCredential();
dataSourceBuilder.UseEntraAuthentication(credential);
```

## Benefits

- **Enhanced Security**: No database passwords to manage or rotate
- **Simplified Deployment**: Works seamlessly with Azure managed identities
- **Compliance**: Supports enterprise identity governance and MFA requirements
- **Developer Experience**: Transparent authentication - existing Npgsql code works unchanged
