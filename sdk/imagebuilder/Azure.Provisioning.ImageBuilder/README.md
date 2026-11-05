# Azure Provisioning ImageBuilder client library for .NET

Azure.Provisioning.ImageBuilder simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ImageBuilder --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to specify Azure VM Image Builder infrastructure in a declarative style using .NET. You can then use `azd` to deploy your infrastructure to Azure without writing or maintaining Bicep or ARM templates.

## Examples

### Create an image template

This example creates an image template from an existing managed image and distributes the result as another managed image.

```C# Snippet:ImageBuilderBasic
Infrastructure infra = new();

ImageTemplate template =
    new(nameof(template), ImageTemplate.ResourceVersions.V2025_10_01)
    {
        Identity = new ImageTemplateIdentity
        {
            Type = ImageBuilderIdentityType.None,
        },
        Source = new ImageTemplateManagedImageSource
        {
            ImageId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/source-rg/providers/Microsoft.Compute/images/source-image")
        },
        Tags = { ["environment"] = "test" },
    };
template.Distribute.Add(
    new ImageTemplateManagedImageDistributor
    {
        ImageId = new ResourceIdentifier(
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/output-rg/providers/Microsoft.Compute/images/output-image"),
        Location = new AzureLocation("westus2"),
        RunOutputName = "managed-image",
    });
infra.Add(template);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. Follow the instructions provided by the bot. You only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
