# Microsoft.Azure.Data.Extensions

This repository contains helper libraries that can be used to connect to Azure Database for Postgresql and Mysql using Azure AD authentication. Many Azure services support Azure AD authentication, they require an Azure AD access token with specific scopes. Azure Database for Postgres and Azure Database for MySql expect an Azure AD access token with <https://ossrdbms-aad.database.windows.net> audience. It is possible to get an access of this kind using Azure.Identity library or even using Azure CLI.

This repository provides a core library that gets access tokens for Azure Database for Postgresql and MySql and also caches them while they are not expired.

## Actual challenges

Azure Database for MySQL and Postgresql support using Azure AD authentication. The most direct way to authenticate using Azure AD is retrieving an access token and using it as password to connect to the database. Something similar to this:

```csharp
using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Npgsql;
using Azure.Identity;

namespace Driver
{
    class Script
    {
        // Obtain connection string information from the portal for use in the following variables
        private static string Host = "HOST";
        private static string User = "USER";
        private static string Database = "DATABASE";

        static async Task Main(string[] args)
        {
            //
            // Get an access token for PostgreSQL.
            //
            Console.Out.WriteLine("Getting access token from Azure AD...");

            // Azure AD resource ID for Azure Database for PostgreSQL Flexible Server is https://ossrdbms-aad.database.windows.net/
            string accessToken = null;

            try
            {
                // Call managed identities for Azure resources endpoint.
                var sqlServerTokenProvider = new DefaultAzureCredential();
                accessToken = (await sqlServerTokenProvider.GetTokenAsync(
                    new Azure.Core.TokenRequestContext(scopes: new string[] { "https://ossrdbms-aad.database.windows.net/.default" }) { })).Token;

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("{0} \n\n{1}", e.Message, e.InnerException != null ? e.InnerException.Message : "Acquire token failed");
                System.Environment.Exit(1);
            }

            //
            // Open a connection to the PostgreSQL server using the access token.
            //
            string connString =
                String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4}; SSLMode=Prefer",
                    Host,
                    User,
                    Database,
                    5432,
                    accessToken);

            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection using access token...");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT version()", conn))
                {

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\nConnected!\n\nPostgres version: {0}", reader.GetString(0));
                    }
                }
            }
        }
    }
}
```

> [!NOTE]
> Code snippet extracted from https://learn.microsoft.com/azure/postgresql/flexible-server/how-to-connect-with-managed-identity#connect-using-managed-identity-in-c

> [!WARNING]
> This is not the recommended way to connect to use Azure AD authentication as it will be explained later in this document.

This approach has some drawbacks:

**It's not connection pool friendly.** .Net manages connection pools automatically. It considers that a connection is the same if it has the same connection string. In this case, the connection string contains the access token, which is a time-limited credential. So, the connection pool will be invalidated every time the access token expires. This is not a problem if the application is short-lived, but it can be a problem if the application is long-lived. In addition, if another part of the application retrieves a connection in the same way, the connection pool will be invalidated again.

**It's not Asp.Net/Entity Framework friendly**. Usually Entity Framework connection is configured during application startup. The connection string is not configured later, hence the access token cannot be refreshed. The problem is that connection pools by default are dynamic. It means that few connections are created at startup, and more connections are created as needed. So, if the application is long-lived, and a new connection needs to be created after the access token is expired it will fail.

## Proposed solution

The proposed solution is using Azure.Identity library in a way that it retrieves an access token with the correct audience and scope. That should be done transparently for the user. There are few application scenarios when developers create a database connection explicitly, while ASP.Net Core and Entity Framework are much more common. The proposed solution is to create a library that can be used in all scenarios.

The implication should retrieve an access token before creating a connection, cache the access token, and retrieve a new access token only if it expires. Each database driver provides different solutions:

* Postgresql: Npgsql library provides a mechanism to obtain a password periodically. That is using NpgsqlDataSourceBuilder and [_UsePeriodicPasswordProvider_ method](https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSourceBuilder.html#Npgsql_NpgsqlDataSourceBuilder_UsePeriodicPasswordProvider_System_Nullable_Func_Npgsql_NpgsqlConnectionStringBuilder_CancellationToken_ValueTask_System_String____TimeSpan_TimeSpan_). The library Microsoft.Azure.Data.Extensions.Npgsql contains a class that provides a callback that obtains the password from Azure AD.
* Mysql:
  * MySql.Data library provides a mechanism to configure an authentication plugin. The library Microsoft.Azure.Data.Extensions.MySql provides a class that implements the authentication plugin and obtains the password from Azure AD. The problem of this library is that the configuration uses old System.Configuration library, which is not supported in .Net Core. So, the library is not usable in .Net Core applications.
  This library was tested with Azure Database for MySQL Flexible Server and Azure Database for MySQL Single Server, but **token as password only works in Azure Database for MySQL Single Server**.
  * [MySqlConnector](https://mysqlconnector.net/) is an open source driver for dotnet. It provides a similar mechanism to Postgresql for this scenario. It provides a [_ProvidePasswordCallback_ delegate](https://mysqlconnector.net/api/mysqlconnector/mysqlconnection/providepasswordcallback/). The library Microsoft.Azure.Data.Extensions.MySqlConnector provides a class that implements the delegate signature and obtains the password from Azure AD. This driver works with Azure Database for MySQL Flexible Server and Azure Database for MySQL Single Server. It doesn't provide an Entity Framework implementation, but it is possible to use [Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql).

> [!NOTE] This [fork of MySql.Data](https://github.com/mysql/mysql-connector-net/compare/8.0...felipmiguel:mysql-connector-net:8.0.tunned) library implements a couple of experimental workarounds to make it work in .Net Core applications.

The solution relies on Azure.Identity library. This library supports different authentication mechanisms, such as Managed Identities, IDE identities (Visual Studio, Visual Studio Code, IntelliJ). The solution should support support both System Managed Identity and User Managed Identity.

### Connection pooling

To make this library connection pool friendly, it should use a valid token, not an expired one, and the connection string should be the same for all connections to avoid pool fragmentation.

Here is an example using Postgresql:

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(GetConnectionString());
NpgsqlDataSource dataSource = dataSourceBuilder
                 .UsePeriodicPasswordProvider(async (settings, cancellationToken) =>
                 {
                     var azureCredential = new DefaultAzureCredential();
                     AccessToken token = await azureCredential.GetTokenAsync(new TokenRequestContext(new string[] { "https://ossrdbms-aad.database.windows.net/.default" }));
                     return token.Token;
                 }, TimeSpan.FromMinutes(55), TimeSpan.FromMilliseconds(100))
                 .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

To facilitate the above implementation it is provided the class _TokenCredentialMysqlPasswordProvider_. It provides an access token and also provides a caching mechanism to avoid retrieving an access token if it is not yet expired.

```csharp
TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider();
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(GetConnectionString());
NpgsqlDataSource dataSource = dataSourceBuilder
                .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

And to make it simplier there is an extension method for NpgsqlDataSourceBuilder named `UseAzureADAuthentication`, this is the recommended option:

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString());
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential())
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

> [!NOTE] According to Npgsql driver documentation, the password callback is called by a timer, not when it is going to be used. For that reason, in the first code sample the timer is set to a value lower than the default AAD access token expiration time - 1 hour. The second example uses TokenCredentialMysqlPasswordProvider which reuses the token if it is not expired, for that reason it can be checked more frequently and it won't perform an access token retrieval unless it expired. 

### Entity Framework Core

To facilitate the use of this library with Entity Framework Core it is provided an extension for each driver with the following signature.

```csharp
namespace Microsoft.EntityFrameworkCore;

public static class DbContextOptionsBuilderExtension
{
    public static DbContextOptionsBuilder UseAzureADAuthentication(this DbContextOptionsBuilder optionsBuilder, TokenCredential credential)
    {
        // Specific driver implementation
    }
}
```

The `TokenCredential` will be used to retrieve the access token.

### Developer friendly

Developers need to test their application from their development machine. It means that the solution should be tested from their machines using credentials different to Managed Identities. For instance, their IDE Azure credentials (Visual Studio, Visual Studio Code, IntelliJ) or their azure cli credentials. As the implementation is based on `Azure.Identity.DefaultAzureCredential` it allows to use all mentioned mechanisms.

The library Microsoft.Azure.Data.Extensions.Core implements a caching mechanism, so the access token is retrieved only once per application execution, and it is refreshed if it is expired. Even if some of the DefaultAzureCredential mechanism already implement caching, it causes to try all fallback mechanisms, which is not necessary.

## Postgresql

[Npgsql](https://www.npgsql.org/doc/security.html?tabs=tabid-1) library offers a mechanism that periodically retrieves a password that can be used to create a physical connection to the database. That is `UsePeriodicPasswordProvider` method. The library Microsoft.Azure.Data.Extensions.Npgsql provides a class that implements with a property that can be used to retrieved to obtains the password from Azure AD.

It is provided an extension method for NpgsqlDataSource named `UseAzureADAuthentication` that simplifies the code and is the recomended option:

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString());
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential())
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

The equivalent code is this:

```csharp
TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential());
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(GetConnectionString());
NpgsqlDataSource dataSource = dataSourceBuilder
                .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                .Build();
using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
```

### Entity Framework Core

Npgsql Entity Framework Core provider provides two mechanisms:

* Using a NpgsqlDataSource
* Using a DbContextOptionsBuilderOptions.ProvidePasswordCallback. This delegate provides a mechanism to retrieve a the password before the connection is created. 

#### NpgsqlDataSource

This is the recommended option.

DbContext factories:

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("PSQL CONNECTION STRING");
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential())
                .Build();
ServiceCollection services = new ServiceCollection();
services.AddDbContextFactory<ChecklistContext>(options =>
{
    options.UseNpgsql(dataSource);
});
```

DbContext:

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder("PSQL CONNECTION STRING");
NpgsqlDataSource dataSource = dataSourceBuilder
                .UseAzureADAuthentication(new DefaultAzureCredential())
                .Build();
ServiceCollection services = new ServiceCollection();
services.AddDbContext<ChecklistContext>(options =>
{
    options.UseNpgsql(dataSource);
});
```

#### DbContextOptionsBuilderOptions.ProvidePasswordCallback

DbContext factories:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContextFactory<MyContext>(options =>
    {        
        TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential());
        string connectionString = "PSQL CONNECTION STRING";
        options.UseNpgsql(connectionString, npgopts =>
        {
            npgopts.ProvidePasswordCallback(passwordProvider.ProvidePasswordCallback);
        });
    });
}
```

DbContext:

```csharp
builder.Services.AddDbContext<MyContext>(options =>
{
    TokenCredentialMysqlPasswordProvider passwordProvider = new TokenCredentialMysqlPasswordProvider();
    string connectionString = "PSQL CONNECTION STRING";
    options.UseNpgsql(connectionString, npgopts =>
    {
        npgopts.ProvidePasswordCallback(passwordProvider.ProvidePasswordCallback);
    });
});
```

There are more usage examples in project [Microsoft.Azure.Data.Extensions.NpgsqlTests](./Microsoft.Azure.Data.Extensions.NpgsqlTests/)

## MySql

### MySql.Data

MySql allows to configure a custom [authentication plugin](https://dev.mysql.com/doc/connector-net/en/connector-net-programming-authentication-user-plugin.html). It should derive from `MySql.Data.MySqlClient.Authentication.MySqlAuthenticationPlugin`. Active Directory authentication is very similar to Clear Text authentication. For that reason, the [AzureIdentityMysqlAuthenticationPlugin](Microsoft.Azure.Data.Extensions.MySql/AzureIdentityMysqlAuthenticationPlugin.cs) implementation in this repository is based on the [ClearPasswordPlugin](https://github.com/mysql/mysql-connector-net/blob/8.0/MySQL.Data/src/Authentication/ClearPasswordPlugin.cs) from MySql.Data library.

To override the default client/server negotiation of the plugin to use, it is necessary to specify _DefaultAuthenticationPlugin_ in the connection string.

```bash
server=myserver.mysql.database.azure.com;user id=myuser@myserver;database=mydb;sslmode=Required;defaultauthenticationplugin=mysql_clear_password;
```

To configure the authentication plugin it is necessary to enable the plugin in the configuration file:

```xml
<?xml version="1.0"?>
<configuration>
  <configSections>
    <section name="MySQL" type="MySql.Data.MySqlClient.MySqlConfiguration,
MySql.Data"/>
  </configSections>
  <MySQL>
    <AuthenticationPlugins>
      <add name="mysql_clear_password"
type="Microsoft.Azure.Data.Extensions.MySql.AzureIdentityMysqlAuthenticationPlugin, Microsoft.Azure.Data.Extensions.MySql"></add>
    </AuthenticationPlugins>  
  </MySQL>
...
</configuration>
```

This configuration implementation has a major issue. It is based on legacy System.Configuration implementation, and most of the .NET Core applications do not use it. The configuration file is not read by default and it can mess the implementation of the application.

#### Experimental plugin implementation

Microsoft.Azure.Data.Extensions.MySql.AzureIdentityMysqlAuthenticationPlugin implements a workaround for the configuration issue described above. To set the configuration it uses reflection to update the internal configuration of the client. This is not a recommended approach, but it is the only way to configure the plugin without using the configuration file.

The purpose is configuring the private field [_Plugins_](https://github.com/mysql/mysql-connector-net/blob/a53e0c62cf416116ae650aa84065e45385019612/MySQL.Data/src/Authentication/AuthenticationManager.cs#L37), setting the plugin implemented in this library.

The following code snippet shows how to configure the plugin using reflection:

```csharp
public static void RegisterAuthenticationPlugin()
{
    Type authenticationPluginManagerType = Type.GetType("MySql.Data.MySqlClient.Authentication.AuthenticationPluginManager, MySql.Data");
    FieldInfo pluginsField = authenticationPluginManagerType.GetField("Plugins", BindingFlags.Static | BindingFlags.NonPublic);
    IDictionary plugins = pluginsField.GetValue(null) as IDictionary;
    object clearTextPasswordPlugin = plugins["mysql_clear_password"];
    clearTextPasswordPlugin.GetType().GetField("Type").SetValue(clearTextPasswordPlugin, typeof(AzureIdentityMysqlAuthenticationPlugin).AssemblyQualifiedName);
    plugins["mysql_clear_password"] = clearTextPasswordPlugin;
}
```

>[!WARNING] This is an experimental and not recommended approach. It can break in future versions of the driver.

#### Experimental driver implementation

I created an [experimental implementation](https://github.com/felipmiguel/mysql-connector-net) that can configure the authentication plugin using the connection string. In this case, the connection string should contain the _AuthenticationPlugins_ parameter, with a list of the plugins to use. Then the connection string looks like this:

```bash
server=myserver.mysql.database.azure.com;user id=myuser@myserver;database=mydb;sslmode=Required;defaultauthenticationplugin=mysql_clear_password;authenticationplugins=mysql_clear_password:Microsoft.Azure.Data.Extensions.MySql.AzureIdentityMysqlAuthenticationPlugin# Microsoft.Azure.Data.Extensions.MySql# Version=1.0.0.0# Culture=neutral# PublicKeyToken=null;
```

> [!NOTE] the plugin list replaced character , with character #. This is because the attribute is an array it can be confused with item separator.

If you want to use this connector, you can add the [following package(s)](https://github.com/felipmiguel?tab=packages&repo_name=mysql-connector-net) to your project:

For MySql connections:

```dotnetcli
dotnet add <PROJECT> package MySql.Data --version 8.0.30.1
```

And for MySql Entity Framework Core provider:

```dotnetcli
dotnet add <PROJECT> package MySql.EntityFrameworkCore --version 6.0.4
```

There are more usage examples in project [Microsoft.Azure.Data.Extensions.MySqlTests](./Microsoft.Azure.Data.Extensions.MySqlTests/)

### MySqlConnector and Pomelo.EntityFrameworkCore.MySql

[MySqlConnector](https://mysqlconnector.net/) is a popular and alternative driver for MySql and .Net. It is the driver used by [Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql), a popular implementation of Entity Framework Core provider for MySql.

MySqlConnector provides the same mechanism than Postgresql driver to delegate the password acquisition. It is necessary to provide a delegate for [_ProvidePasswordCallback_](https://mysqlconnector.net/api/mysqlconnector/mysqlconnection/providepasswordcallback/).

There is an implementation of this delegate in [Microsoft.Azure.Data.Extensions.MySqlConnector.TokenCredentialMysqlPasswordProvider](./Microsoft.Azure.Data.Extensions.MySqlConnector/TokenCredentialMysqlPasswordProvider.cs) class.

Here an example of usage:

```csharp
TokenCredentialMysqlPasswordProvider passwordProvider = new TokenCredentialMysqlPasswordProvider(new DefaultAzureCredential());
using MySqlConnection connection = new MySqlConnection(GetConnectionString());
connection.ProvidePasswordCallback = passwordProvider.ProvidePassword;
await connection.OpenAsync();
MySqlCommand cmd = new MySqlCommand("SELECT now()", connection);
DateTime? serverDate = (DateTime?) await cmd.ExecuteScalarAsync();
```

To facilitate the usage in Entity Framework Core, there is an extension method in [Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore](Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore/DbContextOptionsBuilderExtension.cs) class. It has the same signature as the extension method provided for Postgresql driver.

```csharp
usingMicrosoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore;

public static class DbContextOptionsBuilderExtension
{
    public static DbContextOptionsBuilder UseAzureADAuthentication(this DbContextOptionsBuilder optionsBuilder, TokenCredential credential)
    {
        // see: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/1643
        return optionsBuilder.AddInterceptors(new TokenCredentialMysqlPasswordProviderInterceptor(credential));
    }
}
```

In this case, the implementation is a bit more complex, as Pomelo does not provide a way to configure the password provider. To do it, there is an interceptor that is registered in the context. The interceptor is responsible for setting the password provider just before opening the connector.

```csharp
using Microsoft.Azure.Data.Extensions.MySqlConnector;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MySqlConnector;
using System.Data.Common;

namespaceMicrosoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore
{
    internal class TokenCredentialMysqlPasswordProviderInterceptor : DbConnectionInterceptor
    {
        private readonly TokenCredentialMysqlPasswordProvider _passwordProvider;

        public TokenCredentialMysqlPasswordProviderInterceptor(TokenCredential credential)
        {
            _passwordProvider = new TokenCredentialMysqlPasswordProvider(credential);
        }

        public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            var mysqlConnection = (MySqlConnection)connection;
            mysqlConnection.ProvidePasswordCallback = _passwordProvider.ProvidePassword;
            return result;
        }

        public override ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            var mysqlConnection = (MySqlConnection)connection;
            mysqlConnection.ProvidePasswordCallback = _passwordProvider.ProvidePassword;
            return ValueTask.FromResult(result);
        }
    }
}
```

There are more usage examples in project [Microsoft.Azure.Data.Extensions.MySqlConnectorTests](./Microsoft.Azure.Data.Extensions.MySqlConnectorTests/)

## Nuget packages

This repository contains the following Nuget packages:

* [Microsoft.Azure.Data.Extensions.Npgsql](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.Npgsql)
* [Microsoft.Azure.Data.Extensions.MySql](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.MySql). This package references [MySql.Data experimental implementation](https://github.com/felipmiguel?tab=packages&repo_name=mysql-connector-net). [!WARNING] This is an experimental and not recommended approach. It can break in future versions of the driver.
* [Microsoft.Azure.Data.Extensions.MySqlConnector](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.MySqlConnector)
* [Microsoft.Azure.Data.Extensions.Core](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.Core). This package is referenced by the other two packages.

And here the Entity Framework packages:
* [Microsoft.Azure.Data.Extensions.Npgsql.EntityFrameworkCore](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.Npgsql.EntityFrameworkCore)
* [Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore)
* [Microsoft.Azure.Data.Extensions.MySql.EntityFrameworkCore](https://github.com/felipmiguel/AzureDb.Passwordless/pkgs/nuget/Microsoft.Azure.Data.Extensions.MySql.EntityFrameworkCore)

If you want to use above packages you should add the nuget feed to your project:

```bash
dotnet nuget add source --username [YOUR GITHUB USERID] --password [YOUR PAT] --store-password-in-clear-text --name github "https://nuget.pkg.github.com/felipmiguel/index.json"
```

You PAT should include the following scope `_read:packages_`.

## Test projects

* [Microsoft.Azure.Data.Extensions.NpgsqlTests](./Microsoft.Azure.Data.Extensions.NpgsqlTests/)
* [Microsoft.Azure.Data.Extensions.MySqlConnectorTests](./Microsoft.Azure.Data.Extensions.MySqlConnectorTests/)
* [Microsoft.Azure.Data.Extensions.MySqlTests](./Microsoft.Azure.Data.Extensions.MySqlTests/)

### Entity Framework Core

There is a sample Entity Framework Core project that can be used with all tests. It is located in [Sample.Repository](./Sample.Repository/). 
To use it in your project:
* Reference the project
* Add a class implementing `IDesignTimeDbContextFactory<ChecklistContext>`

Here an example for Postgresql:

```csharp
public class ChecklistContextFactory : IDesignTimeDbContextFactory<ChecklistContext>
{
    public ChecklistContext CreateDbContext(string[] args)
    {
        Console.WriteLine("args {0}", string.Join(",", args));
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Deployment.json");
        IConfigurationRoot config = configBuilder.Build();
        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<ChecklistContext>(options =>
        {
            options.UseNpgsql(GetPGConnString(config), optionsBuilder =>
            optionsBuilder
                .MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
                .UseAzureADAuthentication(new DefaultAzureCredential()));
        });
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<ChecklistContext>();
    }
    private string GetPGConnString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("AZURE_POSTGRESQL_CONNECTIONSTRING");
    }
}
```

Then execute the following dotnet commands to initialize the database.

```bash
dotnet build
# Get connections string
CONNSTRING="YOUR CONNECTION STRING"
ASPNETCORE_ENVIRONMENT=Deployment
# replace AZURE_POSTGRESQL_CONNECTIONSTRING by the connection string referenced in your code
echo "{\"ConnectionStrings\":{\"AZURE_POSTGRESQL_CONNECTIONSTRING\":\"${CONNSTRING}\"}}" >appsettings.Deployment.json
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
> [!NOTE] It is necessary to install entity framework tool `dotnet tool install --global dotnet-ef`

## Sample project

[Dotnet.Passwordless.Samples](https://github.com/felipmiguel/DotNet.Passwordless.Samples) contains a sample with a webapi that can be deployed to Azure App Service, using Azure Managed Identity to access a database. There is a sample for Azure Database for Postgresql flexible server, MySqlAzure Database for MySql flexible server and Azure Sql Server.

## Reference links

* Postgresql: <https://www.npgsql.org/doc/security.html?tabs=tabid-1>
* MySql: <https://dev.mysql.com/doc/connector-net/en/connector-net-programming-authentication-user-plugin.html>
* MySqlConnector: <https://mysqlconnector.net/>
* Pomelo: <https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql>
