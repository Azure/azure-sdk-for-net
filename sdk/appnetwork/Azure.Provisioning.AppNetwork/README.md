# Azure Provisioning AppNetwork client library for .NET

Azure.Provisioning.AppNetwork simplifies declarative provisioning for Azure App Network in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.AppNetwork --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library lets you define Azure App Network infrastructure declaratively in .NET and deploy it with Azure Developer CLI.

## Examples

### Create an App Network

```C# Snippet:AppLinkBasic
Infrastructure infra = new();

AppLink appLink = new(nameof(appLink), AppLink.ResourceVersions.V2026_08_01_PREVIEW)
{
    Name = "app-link",
    Location = new AzureLocation("eastus")
};
infra.Add(appLink);
```

### Add an AKS cluster to an existing App Network

Create an `AppLinkMember` referencing an existing App Network and AKS cluster, with connectivity and upgrade profiles. The metrics endpoint is a read-only property that can be exposed as a deployment output.

```C# Snippet:AppLinkMemberBasic
Infrastructure infra = new();

AppLink appLink = AppLink.FromExisting(nameof(appLink), AppLink.ResourceVersions.V2026_08_01_PREVIEW);
appLink.Name = "app-link";
infra.Add(appLink);

AppLinkMember member = new(nameof(member), AppLinkMember.ResourceVersions.V2026_08_01_PREVIEW)
{
    Parent = appLink,
    Name = "aks-member",
    Location = new AzureLocation("eastus"),
    Properties = new AppLinkMemberProperties
    {
        ClusterType = AppLinkClusterType.Aks,
        MetadataResourceId = new ResourceIdentifier(
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.ContainerService/managedClusters/my-aks-cluster"),
        ConnectivityProfile = new AppLinkConnectivityProfile
        {
            Network = "app-network",
            EastWestGatewayVisibility = AppLinkEastWestGatewayVisibility.Internal,
            PrivateConnectSubnetResourceId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.Network/virtualNetworks/my-vnet/subnets/my-subnet")
        },
        UpgradeProfile = new AppLinkUpgradeProfile
        {
            Mode = AppLinkUpgradeMode.FullyManaged,
            FullyManagedUpgradeReleaseChannel = AppLinkUpgradeReleaseChannel.Stable
        }
    }
};
infra.Add(member);

ProvisioningOutput metricsEndpoint = new(nameof(metricsEndpoint), typeof(string))
{
    Value = member.Properties.ObservabilityMetricsEndpoint
};
infra.Add(metricsEndpoint);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).
