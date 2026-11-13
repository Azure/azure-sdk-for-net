# Azure Provisioning HealthBot client library for .NET

Azure.Provisioning.HealthBot simplifies declarative resource provisioning for Azure Health Bot in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.HealthBot --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library lets you define Azure Health Bot resources declaratively in .NET.
Build an `Infrastructure` definition to produce Bicep that can be deployed to Azure
without writing or maintaining Bicep or ARM templates by hand.

## Examples

### Create an Azure Health Bot

Define a Health Bot with the free SKU and expose its name and resource ID as outputs:

```C# Snippet:HealthBotBasic
Infrastructure infra = new();

HealthBot bot =
    new(nameof(bot), HealthBot.ResourceVersions.V2025_11_01)
    {
        SkuName = HealthBotSkuName.F0,
        Tags = { ["environment"] = "test" },
    };
infra.Add(bot);

infra.Add(new ProvisioningOutput("botName", typeof(string)) { Value = bot.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = bot.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

Learn more about [Azure Health Bot](https://learn.microsoft.com/azure/health-bot/overview)
and the [Azure Provisioning libraries](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

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
