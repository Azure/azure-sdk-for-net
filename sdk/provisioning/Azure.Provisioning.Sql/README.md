# Azure Provisioning Sql client library for .NET

Azure.Provisioning.Sql simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Sql
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a SQL Server with database

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Sql;

Infrastructure infrastructure = new Infrastructure();

// Define parameters for SQL Server configuration
ProvisioningParameter adminLogin = new ProvisioningParameter("adminLogin", typeof(string))
{
    Description = "The administrator username of the SQL logical server."
};
infrastructure.Add(adminLogin);

ProvisioningParameter adminPassword = new ProvisioningParameter("adminPassword", typeof(string))
{
    Description = "The administrator password of the SQL logical server.",
    IsSecure = true
};
infrastructure.Add(adminPassword);

// Create the SQL Server
SqlServer sqlServer = new SqlServer("sqlServer")
{
    AdministratorLogin = adminLogin,
    AdministratorLoginPassword = adminPassword
};
infrastructure.Add(sqlServer);

// Create a SQL Database
SqlDatabase database = new SqlDatabase("database")
{
    Parent = sqlServer,
    Name = "SampleDB",
    Sku = new SqlSku { Name = "Standard", Tier = "Standard" }
};
infrastructure.Add(database);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a SQL Server with multiple databases

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Sql;

Infrastructure infrastructure = new Infrastructure();

// Create SQL Server with parameters
ProvisioningParameter adminLogin = new ProvisioningParameter("adminLogin", typeof(string));
ProvisioningParameter adminPassword = new ProvisioningParameter("adminPassword", typeof(string)) { IsSecure = true };
infrastructure.Add(adminLogin);
infrastructure.Add(adminPassword);

SqlServer sqlServer = new SqlServer("sqlServer")
{
    AdministratorLogin = adminLogin,
    AdministratorLoginPassword = adminPassword
};
infrastructure.Add(sqlServer);

// Create multiple databases
string[] databaseNames = { "ProductionDB", "StagingDB", "DevelopmentDB" };
foreach (string dbName in databaseNames)
{
    SqlDatabase database = new SqlDatabase($"db_{dbName.ToLower()}")
    {
        Parent = sqlServer,
        Name = dbName,
        Sku = new SqlSku { Name = "Basic", Tier = "Basic" }
    };
    infrastructure.Add(database);
}

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

For detailed examples and resource-specific configurations, please refer to the test files in the `tests/` directory of this library, which demonstrate practical usage scenarios and configuration patterns.

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

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
