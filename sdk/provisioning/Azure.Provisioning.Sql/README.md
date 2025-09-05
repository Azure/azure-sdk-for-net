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

### Create A SQL Server And Database

This example demonstrates how to create a SQL Server with a database, including secure parameter handling for administrator credentials, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.sql/sql-database/main.bicep).

```C# Snippet:SqlServerBasic
Infrastructure infra = new();

ProvisioningParameter dbName =
    new(nameof(dbName), typeof(string))
    {
        Value = "SampleDB",
        Description = "The name of the SQL Database."
    };
infra.Add(dbName);

ProvisioningParameter adminLogin =
    new(nameof(adminLogin), typeof(string))
    {
        Description = "The administrator username of the SQL logical server."
    };
infra.Add(adminLogin);

ProvisioningParameter adminPass =
    new(nameof(adminPass), typeof(string))
    {
        Description = "The administrator password of the SQL logical server.",
        IsSecure = true
    };
infra.Add(adminPass);

SqlServer sql =
    new(nameof(sql), SqlServer.ResourceVersions.V2021_11_01)
    {
        AdministratorLogin = adminLogin,
        AdministratorLoginPassword = adminPass
    };
infra.Add(sql);

SqlDatabase db =
    new(nameof(db), SqlDatabase.ResourceVersions.V2021_11_01)
    {
        Parent = sql,
        Name = dbName,
        Sku = new SqlSku { Name = "Standard", Tier = "Standard" }
    };
infra.Add(db);
```

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
