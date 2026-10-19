# Azure Provisioning Site Manager client library for .NET

Azure.Provisioning.SiteManager simplifies declarative resource provisioning for Azure Site Manager in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.SiteManager --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

## Key concepts

This library allows you to define Azure Site Manager resources declaratively in .NET.
Build an `Infrastructure` containing your resources and compile it into Bicep for deployment
without writing or maintaining Bicep or ARM templates yourself.

## Examples

### Create a site

The following example defines a site at resource-group scope with a display name, labels,
and physical address. Outputs expose the site's name and resource ID.

```C# Snippet:SiteManagerSiteBasic
Infrastructure infra = new();

EdgeSite site =
    new(nameof(site), EdgeSite.ResourceVersions.V2025_06_01)
    {
        Name = "example-site",
        Properties = new EdgeSiteProperties
        {
            DisplayName = "Example site",
            Description = "A site managed with Azure Provisioning.",
            Labels = { ["environment"] = "test" },
            SiteAddress = new EdgeSiteAddressProperties
            {
                City = "Seattle",
                StateOrProvince = "WA",
                Country = "US",
                PostalCode = "98101",
            },
        },
    };
infra.Add(site);

infra.Add(new ProvisioningOutput("siteName", typeof(string)) { Value = site.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = site.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask a new question on Stack Overflow using the Azure and .NET tags.

## Next steps

Learn more about [Azure Provisioning](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to
agree to a Contributor License Agreement (CLA) declaring that you have the right to,
and actually do, grant us the rights to use your contribution. For details, visit
<https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need
to provide a CLA and decorate the PR appropriately. You will only need to do this once
across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
