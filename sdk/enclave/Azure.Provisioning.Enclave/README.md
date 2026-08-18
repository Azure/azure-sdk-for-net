# Azure Provisioning Enclave client library for .NET

Azure.Provisioning.Enclave simplifies declarative resource provisioning for Azure Virtual Enclaves in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Enclave --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

To use `Azure.Provisioning.Enclave`, construct the infrastructure definition using the provisioning resources and deploy it with a credentials-aware deployment tool (e.g., `AzureDeploymentProvisioner` from `Azure.Provisioning`). Authentication is handled at deployment time by the configured `TokenCredential`.

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain Bicep or ARM templates.

## Examples

### Create a Virtual Enclave

This example demonstrates how to create a Virtual Enclave resource.

```C# Snippet:EnclaveBasic
Infrastructure infra = new();

VirtualEnclave enclave =
    new(nameof(enclave), VirtualEnclave.ResourceVersions.V2026_03_01_PREVIEW)
    {
        Properties = new VirtualEnclaveProperties
        {
            CommunityResourceId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Mission/communities/example"),
            EnclaveVirtualNetwork = new EnclaveVirtualNetwork
            {
                NetworkName = "enclave-vnet",
                NetworkSize = "small",
                CustomCidrRange = "10.0.0.0/16",
                AllowSubnetCommunication = true,
            },
            IsBastionEnabled = false,
        },
    };
infra.Add(enclave);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

- [Azure Provisioning SDK for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/provisioning?view=azure-dotnet)
- [Azure Enclave deployment templates](https://learn.microsoft.com/azure/enclave/azure-enclave-templates)

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

This project has adopted the Microsoft Open Source Code of Conduct. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
