# Azure Provisioning Resource Connector client library for .NET

Azure.Provisioning.ResourceConnector simplifies declarative resource provisioning for Azure Resource Connector in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ResourceConnector --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

## Key concepts

This library allows you to define Azure Resource Connector appliances declaratively in .NET and compile them into Bicep templates for deployment to Azure.

## Examples

### Create a Resource Connector appliance

The following example defines an appliance with infrastructure configuration and a system-assigned identity.

```C# Snippet:ResourceConnectorBasic
Infrastructure infra = new();

ResourceConnectorAppliance appliance =
    new(nameof(appliance), ResourceConnectorAppliance.ResourceVersions.V2022_10_27)
    {
        Name = "my-appliance",
        Distro = ApplianceDistro.AksEdge,
        InfrastructureConfigProvider = ApplianceProvider.VMware,
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
        },
        Tags = { ["environment"] = "test" },
    };
infra.Add(appliance);

infra.Add(new ProvisioningOutput("applianceId", typeof(string)) { Value = appliance.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

See the [Azure.Provisioning documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning) for more information about building and deploying infrastructure.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
