# Azure Provisioning Qumulo client library for .NET

Azure.Provisioning.Qumulo simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Qumulo --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
To provision a Qumulo file system, you also need a delegated subnet and a Qumulo marketplace offer and plan.

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET.
You can then use Azure Developer CLI (`azd`) to deploy your infrastructure to Azure without writing or maintaining Bicep or ARM templates.

Sensitive values such as administrator passwords and user email addresses can be supplied through secure provisioning parameters.

## Examples

### Create a Qumulo file system

This example defines a Qumulo file system with marketplace details, a delegated subnet, and secure administrator credentials.
Provide the parameter values when deploying the generated infrastructure.

```C# Snippet:QumuloBasic
Infrastructure infra = new();

ProvisioningParameter adminPassword =
    new(nameof(adminPassword), typeof(string)) { IsSecure = true };
infra.Add(adminPassword);

ProvisioningParameter userEmail =
    new(nameof(userEmail), typeof(string)) { IsSecure = true };
infra.Add(userEmail);

ProvisioningParameter delegatedSubnetId =
    new(nameof(delegatedSubnetId), typeof(string));
infra.Add(delegatedSubnetId);

ProvisioningParameter marketplacePlanId =
    new(nameof(marketplacePlanId), typeof(string));
infra.Add(marketplacePlanId);

ProvisioningParameter marketplaceOfferId =
    new(nameof(marketplaceOfferId), typeof(string));
infra.Add(marketplaceOfferId);

QumuloFileSystemResource fileSystem =
    new(nameof(fileSystem), QumuloFileSystemResource.ResourceVersions.V2026_04_16)
    {
        Name = "qumulo-filesystem",
        StorageSkuName = "Standard",
        AdminPassword = adminPassword,
        UserDetailsEmail = userEmail,
        DelegatedSubnetId = delegatedSubnetId,
        MarketplaceDetails = new MarketplaceDetails
        {
            PlanId = marketplacePlanId,
            OfferId = marketplaceOfferId,
        },
    };
infra.Add(fileSystem);

infra.Add(new ProvisioningOutput("fileSystemId", typeof(string)) { Value = fileSystem.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the Azure and .NET tags.

## Next steps

Learn more about [Azure Native Qumulo](https://learn.microsoft.com/azure/partner-solutions/qumulo/).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately. Follow the instructions provided by the bot.
You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
