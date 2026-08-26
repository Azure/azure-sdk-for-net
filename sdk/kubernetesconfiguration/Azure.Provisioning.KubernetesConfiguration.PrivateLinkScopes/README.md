# Azure Provisioning KubernetesConfiguration PrivateLinkScopes client library for .NET

Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

Azure.Provisioning libraries do not authenticate directly. When you deploy the generated infrastructure, the deployment tool uses your Azure credentials.

## Key concepts

This library allows you to specify Kubernetes configuration private link scope infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure without writing or maintaining Bicep or ARM templates.

## Examples

### Create a private link scope

```C# Snippet:KubernetesConfigurationPrivateLinkScopesBasic
Infrastructure infra = new();

KubernetesConfigurationPrivateLinkScope scope =
    new(nameof(scope), KubernetesConfigurationPrivateLinkScope.ResourceVersions.V2024_11_01_PREVIEW)
    {
        Tags = { ["environment"] = "test" },
        Properties = new KubernetesConfigurationPrivateLinkScopeProperties
        {
            ClusterResourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/example"),
            PublicNetworkAccess = KubernetesConfigurationPrivateLinkScopePublicNetworkAccessType.Disabled,
        },
    };
infra.Add(scope);
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
