# Authentication helper library for Azure Database for Postgresql and Entity Framework Core

This library provides some extension methods to facilitate the usage of Azure AD authentication when connecting to Azure Database for Postgresql.

## DbContextOptionsBuilder extensions

DbContextOptionsBuilder is used to configure the Entity Framework context. This library provides the `UseAzureADAuthentication` method to configure PostgreSQL connections.

This library uses Microsoft.Azure.Data.Extensions.Npgsql library to get an Azure AD access token that can be used to authenticate to Postgresql. This method expects a TokenCredential, here some examples that can be used:

* Using [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet). This component has a fallback mechanism trying to get an access token using different mechanisms. This is the default implementation.
* Specify an Azure Managed Identity. It uses DefaultAzureCredential, but tries to use a specific Managed Identity if the application hosting has more than one managed identity assigned.
* Specify a [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet). It uses a TokenCredential provided by the caller to retrieve an access token.

### Sample using DefaultAzureCredential

Using [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) to get a token.

```csharp
// configuring services
var services = new ServiceCollection();
services.AddDbContextFactory<SampleContext>(options =>
{
    options.UseNpgsql("POSTGRESQL CONNECTION STRING",
        npgsqlOptions => npgsqlOptions.UseAzureADAuthentication(new DefaultAzureCredential())); // Usage of this library
});
```

### Sample with specific Managed Identity


It uses _UseAzureADAuthentication_ passing the client id of the prefered managed identity in case the hosting service has more than one assigned. It uses [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) passing the preferred managed identity.

```csharp
// configuring services
var services = new ServiceCollection();
string managedIdentityClientId = "00000000-0000-0000-000000000000";
services.AddDbContextFactory<SampleContext>(options =>
{
    options.UseNpgsql("POSTGRESQL CONNECTION STRING",
        npgsqlOptions => npgsqlOptions.UseAzureADAuthentication(new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = managedIdentityClientId })));
});
```

### Sample using AzureCliCredential

It uses _UseAzureADAuthentication_ passing a TokenCredential provided by the caller. For simplicity, this sample use AzureCliCredential

```csharp
// configuring services
AzureCliCredential tokenCredential = new AzureCliCredential();
var services = new ServiceCollection();
services.AddDbContextFactory<ChecklistContext>(options =>
{
    options.UseNpgsql("POSTGRESQL CONNECTION STRING",
        options => options.UseAzureADAuthentication(tokenCredential)); // Usage of this library
});
```