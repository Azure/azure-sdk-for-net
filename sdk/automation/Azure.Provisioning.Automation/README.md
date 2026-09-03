# Azure Provisioning Automation client library for .NET

Azure.Provisioning.Automation simplifies declarative resource provisioning for Azure Automation in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Automation --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to specify Azure Automation infrastructure declaratively in .NET. You can then use `azd` to deploy the generated Bicep without writing or maintaining ARM templates directly.

## Examples

### Create an Automation account

```C# Snippet:AutomationAccountBasic
Infrastructure infra = new();

AutomationAccount account =
    new(nameof(account), AutomationAccount.ResourceVersions.V2024_10_23)
    {
        Tags = { ["environment"] = "test" },
        Sku = new AutomationSku { Name = AutomationSkuName.Basic },
        IsLocalAuthDisabled = true,
    };
infra.Add(account);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

<!-- LINKS -->

[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md