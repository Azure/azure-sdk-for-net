# Microsoft Azure PostgreSQL Auth client library for .NET

The `Microsoft.Azure.PostgreSQL.Auth` library provides Entra ID (formerly Azure Active Directory) authentication support for the [Npgsql](https://www.npgsql.org/) PostgreSQL driver. It enables passwordless authentication to Azure Database for PostgreSQL using Azure Identity credentials.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/postgresql/Microsoft.Azure.PostgreSQL.Auth/src) | [Package (NuGet)](https://www.nuget.org/packages/Microsoft.Azure.PostgreSQL.Auth) | [Product documentation](https://learn.microsoft.com/azure/postgresql/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Microsoft.Azure.PostgreSQL.Auth --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- An [Azure Database for PostgreSQL](https://learn.microsoft.com/azure/postgresql/) server with Entra ID authentication enabled
- An Entra ID administrator configured on the PostgreSQL server
- The application's Entra ID identity created as a database user with appropriate permissions

### Authenticate the client

This library extends the Npgsql `NpgsqlDataSourceBuilder` with Entra ID authentication. Use any `TokenCredential` from [Azure.Identity](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme):

```C# Snippet:PostgreSqlAuth_ReadMe_Authenticate
var credential = new DefaultAzureCredential();
var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
builder.UseEntraAuthentication(credential);
```

## Key concepts

### Entra ID authentication

The library configures token-based authentication by:
1. Extracting the username from the Entra ID token claims
2. Setting up a password provider that supplies fresh tokens for each connection

### Supported identity types

- **User identities** — extracted from `upn`, `preferred_username`, or `unique_name` claims
- **Managed identities** — extracted from the `xms_mirid` claim
- **Service principals** — extracted from available token claims

### Thread safety

The `UseEntraAuthentication` and `UseEntraAuthenticationAsync` extension methods configure the `NpgsqlDataSourceBuilder` and are intended to be called once during setup. The resulting `NpgsqlDataSource` is thread-safe per Npgsql documentation.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Synchronous authentication

```C# Snippet:PostgreSqlAuth_ReadMe_Sync
var credential = new DefaultAzureCredential();
var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
builder.UseEntraAuthentication(credential);
```

### Asynchronous authentication

```C# Snippet:PostgreSqlAuth_ReadMe_Async
var credential = new DefaultAzureCredential();
var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
await builder.UseEntraAuthenticationAsync(credential);
```

## Troubleshooting

### Common errors

- **"Could not determine username from token claims"** — The token does not contain a recognized username claim. Ensure the identity has the correct permissions and the token contains one of: `upn`, `xms_mirid`, `preferred_username`, or `unique_name`.
- **`NotSupportedException` when calling `Build()`** — A password is already set in the connection string. Remove the `Password` parameter when using Entra ID authentication.

### Logging

This library uses the standard Azure SDK logging mechanisms. For details on configuring logging, see [Logging with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/logging).

## Next steps

- [Azure Database for PostgreSQL documentation](https://learn.microsoft.com/azure/postgresql/)
- [Azure Identity documentation](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme)
- [Npgsql documentation](https://www.npgsql.org/doc/)

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
