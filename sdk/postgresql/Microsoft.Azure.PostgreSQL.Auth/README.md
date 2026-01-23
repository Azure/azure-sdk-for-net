# Microsoft Azure ProviderShortName management client library for .NET

**[Describe the service briefly first.]**

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

- **Passwordless Authentication**: Uses OAuth 2.0 access tokens instead of database passwords
- **Centralized Identity Management**: Leverages existing Entra ID users and groups  
- **Zero Secrets**: No database credentials stored in application code
- **Automatic Token Handling**: Manages token acquisition and renewal transparently

## Getting started 

### Install the package

Install the Microsoft Azure ProviderShortName management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Microsoft.Azure.PostgreSQL.Auth
```

### Prerequisites

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

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://docs.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
