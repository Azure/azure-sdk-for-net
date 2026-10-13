# Azure Provisioning KubernetesConfiguration FluxConfigurations client library for .NET

Azure.Provisioning.KubernetesConfiguration.FluxConfigurations simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.KubernetesConfiguration.FluxConfigurations --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

Azure.Provisioning libraries do not authenticate directly. When you deploy the generated infrastructure, the deployment tool uses your Azure credentials.

## Key concepts

This library allows you to specify Kubernetes Flux configuration infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure without writing or maintaining Bicep or ARM templates.

## Examples

### Create a Flux configuration

```C# Snippet:KubernetesConfigurationFluxConfigurationsBasic
Infrastructure infra = new();

FluxConfiguration flux =
    new(nameof(flux), FluxConfiguration.ResourceVersions.V2025_04_01)
    {
        Namespace = "flux-system",
        GitRepository = new FluxGitRepository
        {
            Uri = "https://github.com/Azure/arc-k8s-demo",
        },
    };
infra.Add(flux);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

Use the generated `Infrastructure` with the [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/) to provision your resources.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
