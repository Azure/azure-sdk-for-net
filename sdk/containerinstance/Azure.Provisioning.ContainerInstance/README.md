# Azure Provisioning ContainerInstance client library for .NET

Azure.Provisioning.ContainerInstance simplifies declarative resource provisioning for Azure Container Instances in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ContainerInstance --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Linux Container Group with a Public IP

This example demonstrates how to create a Linux container group with a public IP address, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.containerinstance/aci-linuxcontainer-public-ip/main.bicep).

```C# Snippet:ContainerInstanceBasic
Infrastructure infra = new();

ProvisioningParameter image =
    new(nameof(image), typeof(string))
    {
        Value = "mcr.microsoft.com/azuredocs/aci-helloworld",
        Description = "Container image to deploy.",
    };
infra.Add(image);

ProvisioningParameter port =
    new(nameof(port), typeof(int))
    {
        Value = 80,
        Description = "Port to open on the container and the public IP address.",
    };
infra.Add(port);

ContainerGroup containerGroup =
    new(nameof(containerGroup), ContainerGroup.ResourceVersions.V2025_09_01)
    {
        ContainerGroupOSType = ContainerInstanceOperatingSystemType.Linux,
        RestartPolicy = ContainerGroupRestartPolicy.Always,
        IPAddress = new ContainerGroupIPAddress
        {
            AddressType = ContainerGroupIPAddressType.Public,
            Ports =
            {
                new ContainerGroupPort { Port = port, Protocol = ContainerGroupNetworkProtocol.Tcp }
            },
        },
        Containers =
        {
            new ContainerInstanceContainer
            {
                Name = "helloworld",
                Image = image,
                Ports =
                {
                    new ContainerPort { Port = port, Protocol = ContainerNetworkProtocol.Tcp }
                },
                Resources = new ContainerResourceRequirements
                {
                    Requests = new ContainerResourceRequestsContent
                    {
                        Cpu = 1,
                        MemoryInGB = 1.5,
                    },
                },
            }
        },
    };
infra.Add(containerGroup);

infra.Add(new ProvisioningOutput("containerIPv4Address", typeof(string)) { Value = containerGroup.IPAddress.IP });
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