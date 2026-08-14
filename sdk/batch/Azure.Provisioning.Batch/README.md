# Azure Provisioning Batch client library for .NET

Azure.Provisioning.Batch simplifies declarative resource provisioning for Azure Batch in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Batch --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Batch Account with Pool and Application

This example demonstrates how to create a Batch account with a pool and application, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep).

```C# Snippet:BatchAccountBasic
Infrastructure infra = new();

BatchAccount account =
    new(nameof(account), BatchAccount.ResourceVersions.V2025_06_01)
    {
        Tags = { ["environment"] = "test" },
    };
infra.Add(account);

BatchAccountPool pool =
    new(nameof(pool), BatchAccountPool.ResourceVersions.V2025_06_01)
    {
        Parent = account,
        DisplayName = "MyPool",
        VmSize = "Standard_D2s_v3",
        ScaleSettings = new BatchAccountPoolScaleSettings
        {
            FixedScale = new BatchAccountFixedScaleSettings
            {
                TargetDedicatedNodes = 1,
                TargetLowPriorityNodes = 0,
            },
        },
    };
infra.Add(pool);

BatchApplication app =
    new(nameof(app), BatchApplication.ResourceVersions.V2025_06_01)
    {
        Parent = account,
        DisplayName = "MyApp",
        AllowUpdates = true,
    };
infra.Add(app);

infra.Add(new ProvisioningOutput("accountName", typeof(string)) { Value = account.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = account.Id });
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
