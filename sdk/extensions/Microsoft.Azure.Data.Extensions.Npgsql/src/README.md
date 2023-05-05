# Authentication helper library for Azure Database for Postgresql

Azure Database for Postgresql accepts using an Azure AD issued access token as password. That access token should be issued for a specific audience `https://ossrdbms-aad.database.windows.net/.default`.
As described in [README](../README.md) there are some concepts to keep in mind, such as access token caching and connection pool fragementation.
This library provides some utilities to facilitate the connection to Postgresql without worring for those implementation details.
For that purpose, this library provide extensions to [Npgsql](https://www.nuget.org/packages/Npgsql/7.0.2) library.

## Npgsql

Npgsql provides [NpgsqlDataSourceBuilder](https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSourceBuilder.html) class for configuring and creating a NpgsqlDataSource, from which it is possible to create connections.

[NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider](https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSourceBuilder.html#Npgsql_NpgsqlDataSourceBuilder_UsePeriodicPasswordProvider_System_Nullable_Func_Npgsql_NpgsqlConnectionStringBuilder_CancellationToken_ValueTask_System_String____TimeSpan_TimeSpan_) configures a password provider that is invoked periodically to get a password that can change, as an OAuth access token.

## Infrastructure setup

The following samples require an Azure Database for Postgresql server, a database and user in the database that is linked to an Azure AD identity. Postgresql should have AAD enabled, the simplest way is configuring an Azure AD administrator.

```bash
# Define some constants
RESOURCE_GROUP=rg-passwordless
LOCATION=eastus
SERVER_NAME=psql-passwordless
DATABASE_NAME=sampledb
ADMIN_USER=azureuser
# Generating a random password for Posgresql admin user as it is mandatory
# postgresql admin won't be used as Azure AD authentication is leveraged also for administering the database
POSTGRESQL_ADMIN_PASSWORD=$(pwgen -s 15 1)
APPSERVICE_PLAN=asp-passwordless
APPSERVICE=app-passwordless

# login to azure
az login
# Ensure serviceconnector-passwordless extension is installed
az extension add --name serviceconnector-passwordless
# Create a resource group
az group create --name ${RESOURCE_GROUP} --location ${LOCATION}
# Create postgresql flexible server
az postgres flexible-server create \
    --name ${SERVER_NAME} \
    --resource-group ${RESOURCE_GROUP} \
    --location ${LOCATION} \
    --admin-user ${ADMIN_USER} \
    --admin-password ${POSTGRESQL_ADMIN_PASSWORD} \
    --public-access 0.0.0.0 \
    --tier Burstable \
    --sku-name Standard_B1ms \
    --version 14 \
    --storage-size 32 
# create postgres database
az postgres flexible-server db create \
    -g ${RESOURCE_GROUP} \
    -s ${SERVER_NAME} \
    -d ${DATABASE_NAME}
```

There are different possibilities for the identity, depending on the scenario:

* Local development. It is possible to connect a user account, for instance
* Azure hosted application, for instance Azure App Services, Azure Functions, Azure Container Apps, Azure Kubernetes Services, Azure Spring Apps or just an Azure Virtual Machine. All those Azure services support managed identity, it can be system or user assigned.

In both cases, it is possible to use a serviceconnector-passwordless azure cli extension to automate the creation of the identity, the server configuration and connect the identity to a user in the database.

### Local environment

The following command creates a user in the target database that is binded to same user logged-in in azure cli.
>[!NOTE] It can take few minutes to complete.

```bash
az connection create postgres-flexible \
    --client-type dotnet \
    --connection demo \
    --database ${DATABASE_NAME} \
    --location ${LOCATION} \
    --resource-group ${RESOURCE_GROUP} \
    --server ${SERVER_NAME} \
    --target-resource-group ${RESOURCE_GROUP} \
    --user-account
```

### Azure hosted service

The following commands shows how to create and configure an Azure App Service. But same approach can be used with other Azure hosted services.

```bash
# Create app service plan
az appservice plan create --name $APPSERVICE_PLAN --resource-group $RESOURCE_GROUP --location $LOCATION --sku B1 --is-linux

az webapp create \
    --name ${APPSERVICE} \
    --resource-group ${RESOURCE_GROUP} \
    --plan ${APPSERVICE_PLAN} \
    --runtime "DOTNETCORE:6.0"
```

The following command creates a service connection from the app service to the database. It means that:
* Configures Postgres with Azure AD authentication
* Assign current logged-in user in azure cli as AAD administrator in postgres
* Assign a system managed identity to the app service
* Create a user in the database and it is binded to the identity of the appservice
* Create a configuration setting with the connection string that can be used to connect to the database

```bash
az webapp connection create postgres-flexible \
    --resource-group ${RESOURCE_GROUP} \
    --name ${APPSERVICE} \
    --tg ${RESOURCE_GROUP} \
    --server ${SERVER_NAME} \
    --database ${DATABASE_NAME} \
    --client-type dotnet \
    --system-identity
```

> [!NOTE] It can take few minutes to complete

## NpgsqlDataSourceBuilder extension methods

Instead of creating the TokenCredentialNpgsqlPasswordProvider to be passed to _NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider_ method, there are some extension methods that can be used to configure the _NpgsqlDataSourceBuilder_, simplifying the code. It provides some overloads of method `UseAzureADAuthentication`

It can be used with different implementations of TokenCredential, for example:

* Using [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet). This component has a fallback mechanism trying to get an access token using different mechanisms. This is the default implementation.
* Specify an Azure Managed Identity. It uses DefaultAzureCredential, but tries to use a specific Managed Identity if the application hosting has more than one managed identity assigned.
* Specify a [AzureCliCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet). It uses a TokenCredential provided by the caller to retrieve an access token.

### Sample NpgsqlDataSourceBuilder UseAzureADAuthentication

This is the simpler solution, as it only requires to invoke `UseAzureADAuthentication` extension method for NpgsqlDataSourceBuilder passing a DefaultAzureCredential

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential())
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

### Sample NpgsqlDataSourceBuilder UseAzureADAuthentication with Managed Identity

This sample uses UseAzureADAuthentication passing a DefaultAzureCredential with a preferred Managed Identity client id.

```csharp
string managedIdentityClientId = "00000000-0000-0000-0000-000000000000";
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = managedIdentityClientId }))
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

You can use the following command to retrieve the managed identity client id:

```bash
az identity show --resource-group ${RESOURCE_GROUP} --name ${MSI_NAME} --query clientId -o tsv
```

### Sample NpgsqlDataSourceBuilder UseAzureADAuthentication with AzureCliCredential

In this sample the caller provides a TokenCredential that will be used to retrieve the access token. For simplicity, this sample uses azure cli credential.

```csharp
AzureCliCredential tokenCredential = new AzureCliCredential();
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(tokenCredential)
                .Build();
await ValidateDataSourceAsync(dataSource);
```

## TokenCredentialNpgsqlPasswordProvider

[TokenCredentialNpgsqlPasswordProvider](./TokenCredentialNpgsqlPasswordProvider.cs) exposes _PasswordProvider_ property that can be used as provider callback of [NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider](https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSourceBuilder.html).

TokenCredentialNpgsqlPasswordProvider requires a TokenCredential. Here some samples of usage of TokenCredential.

* Using [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet). This component has a fallback mechanism trying to get an access token using different mechanisms. This is the default implementation.
* Specify an Azure Managed Identity. Try to use a specific Managed Identity if the application hosting has more than one managed identity assigned.
* Specify a [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet). It uses a TokenCredential provided by the caller to retrieve an access token.

### Sample TokenCredentialNpgsqlPasswordProvider with DefaultAzureCredential

If you execute this sample in your local development environment it can take the credentials from environment variables, your IDE (Visual Studio, Visual Studio Code, IntelliJ) or Azure cli, see [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) for more details.

```csharp
TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential());
// Connection string does not contain password
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                            .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                            .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

### Sample TokenCredentialNpgsqlPasswordProvider using specific Managed Identity

This sample uses the _TokenCredentialNpgsqlPasswordProvider_ using a DefaultAzureCredential with a managed identity. It is necessary to pass the managed identity client id, not the object id.

```csharp
string managedIdentityClientId = "00000000-0000-0000-0000-000000000000";
TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = managedIdentityClientId }));
// Connection string does not contain password
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                            .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                            .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

You can use the following command to retrieve the managed identity client id:

```bash
az identity show --resource-group ${RESOURCE_GROUP} --name ${MSI_NAME} --query clientId -o tsv
```

### Sample TokenCredentialNpgsqlPasswordProvider using TokenCredential

This sample uses the _TokenCredentialNpgsqlPasswordProvider_ constructor with a TokenCredential. For simplicity, this sample uses Azure cli credential

```csharp
AzureCliCredential credential = new AzureCliCredential();
TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(credential);
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=psql-passwordless.postgres.database.azure.com;Database=sampledb;Port=5432;User Id=myuser@mydomain.onmicrosoft.com;Ssl Mode=Require;");
NpgsqlDataSource dataSource = dataSourceBuilder
                 .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                 .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```



