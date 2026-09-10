# Azure Provisioning ServiceNetworking client library for .NET

Azure.Provisioning.ServiceNetworking simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.ServiceNetworking --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Traffic Controller

This example demonstrates how to create an Azure Application Gateway for Containers (Traffic Controller).

```C# Snippet:ServiceNetworkingBasic
Infrastructure infra = new();

TrafficController controller =
    new(nameof(controller), TrafficController.ResourceVersions.V2025_01_01)
    {
        Tags = { ["environment"] = "test" },
    };
infra.Add(controller);

TrafficControllerFrontend frontend =
    new(nameof(frontend), TrafficControllerFrontend.ResourceVersions.V2025_01_01)
    {
        Parent = controller,
    };
infra.Add(frontend);

TrafficControllerAssociation association =
    new(nameof(association), TrafficControllerAssociation.ResourceVersions.V2025_01_01)
    {
        Parent = controller,
        AssociationType = TrafficControllerAssociationType.Subnets,
        SubnetId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet"),
    };
infra.Add(association);
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
