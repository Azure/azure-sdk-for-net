# Authentication helper library for Azure Database for MySQL and Entity Framework Core

This library provides some extension methods to facilitate the usage of Azure AD authentication when connecting to Azure Database for MySQL.

[Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) provides Entity Framework support for MySqlConnector.

## DbContextOptionsBuilder extensions

DbContextOptionsBuilder is used to configure the Entity Framework context. [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) library provides the `UseMySql` method to configure MySql connections. This library provides some extensions to facilitate the configuration for MySql using Azure AD authentication.
This library uses Microsoft.Azure.Data.Extensions.MySqlConnector library to get an Azure AD access token that can be used to authenticate to MySql. It requires a TokenCredential, here some some options:
* Using [DefaultAzureCredential](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet). This component has a fallback mechanism trying to get an access token using different mechanisms. This is the default implementation.
* Specify an Azure Managed Identity. It uses DefaultAzureCredential, but tries to use a specific Managed Identity if the application hosting has more than one managed identity assigned.
* Specify another [TokenCredential](https://learn.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet). It uses a TokenCredential provided by the caller to retrieve an access token.

### Sample DefaultAzureCredential

It uses [DefaultAzureCredential](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) to get a token.

```csharp
// Pomelo requires to specify the server version
ServerVersion serverVersion = ServerVersion.Parse("5.7", Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
// configuring services
var services = new ServiceCollection();
services.AddDbContextFactory<SampleContext>(options =>
{
    options
        .UseMySql("MYSQL CONNECTION STRING", serverVersion)
        .UseAzureADAuthentication(new DefaultAzureCredential()); // Usage of this library
});
```

### Sample with specific Managed Identity

It uses _UseAzureADAuthentication_ passing a DefaultAzureCredential with the client id of the prefered managed identity in case the hosting service has more than one assigned. It uses [DefaultAzureCredential](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) passing the preferred managed identity.

```csharp
// Pomelo requires to specify the server version
ServerVersion serverVersion = ServerVersion.Parse("5.7", Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
// configuring services
var services = new ServiceCollection();
string managedIdentityClientId = "00000000-0000-0000-000000000000";
services.AddDbContextFactory<SampleContext>(options =>
{
    options
        .UseMySql("MYSQL CONNECTION STRING", serverVersion)
        .UseAzureADAuthentication(new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = managedIdentityClientId })); // Usage of this library
});
```

### Sample using TokenCredential

It uses _UseAzureADAuthentication_ passing a TokenCredential provided by the caller. For simplicity, this sample use AzureCliCredential

```csharp
// Pomelo requires to specify the server version
ServerVersion serverVersion = ServerVersion.Parse("5.7", Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
// configuring services
var services = new ServiceCollection();
AzureCliCredential tokenCredential = new AzureCliCredential();
services.AddDbContextFactory<SampleContext>(options =>
{
    options
        .UseMySql("MYSQL CONNECTION STRING", serverVersion)
        .UseAzureADAuthentication(tokenCredential)); // Usage of this library
});
```