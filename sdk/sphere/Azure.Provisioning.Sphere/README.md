# Azure Provisioning Sphere client library for .NET

Azure.Provisioning.Sphere simplifies declarative resource provisioning for Azure Sphere in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Sphere --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library lets you define Azure Sphere infrastructure declaratively in .NET. It generates Bicep that can be deployed to Azure without writing or maintaining Bicep or ARM templates manually.

## Examples

### Create an Azure Sphere catalog

The following example defines a catalog and outputs its resource ID.

```C# Snippet:SphereCatalogBasic
Infrastructure infra = new();

SphereCatalog catalog =
    new(nameof(catalog), SphereCatalog.ResourceVersions.V2024_04_01)
    {
        Name = "my-catalog",
        Tags = { ["environment"] = "test" },
    };
infra.Add(catalog);

infra.Add(new ProvisioningOutput("catalogId", typeof(string)) { Value = catalog.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) on Stack Overflow using the Azure and .NET tags.

## Next steps

See the [Azure Sphere documentation](https://learn.microsoft.com/azure-sphere/) to learn more about catalogs and device management.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. You only need to do this once across all repositories using this CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
