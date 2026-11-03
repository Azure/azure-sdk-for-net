// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppNetwork.Tests;

public class BasicAppNetworkTests
{
    internal static Trycep CreateAppLinkTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AppLinkBasic
                Infrastructure infra = new();

                AppLink appLink = new(nameof(appLink), AppLink.ResourceVersions.V2026_08_01_PREVIEW)
                {
                    Name = "app-link",
                    Location = new AzureLocation("eastus")
                };
                infra.Add(appLink);
                #endregion

                return infra;
            });
    }

    // Reference schema (2025-08-01-preview; this test uses 2026-08-01-preview):
    // https://learn.microsoft.com/en-us/azure/templates/microsoft.applink/2025-08-01-preview/applinks?pivots=deployment-language-bicep
    [Test]
    public async Task CreateAppLink()
    {
        await using Trycep test = CreateAppLinkTest();

        test.Compare(
            """
            resource appLink 'Microsoft.AppLink/appLinks@2026-08-01-preview' = {
              name: 'app-link'
              location: 'eastus'
            }
            """);
    }

    internal static Trycep CreateAppLinkMemberTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AppLinkMemberBasic
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
                #endregion

                return infra;
            });
    }

    // Reference schema (2025-08-01-preview; this test uses 2026-08-01-preview):
    // https://learn.microsoft.com/en-us/azure/templates/microsoft.applink/2025-08-01-preview/applinks/applinkmembers?pivots=deployment-language-bicep
    [Test]
    public async Task CreateAppLinkMember()
    {
        await using Trycep test = CreateAppLinkMemberTest();

        test.Compare(
            """
            resource appLink 'Microsoft.AppLink/appLinks@2026-08-01-preview' existing = {
              name: 'app-link'
            }

            resource member 'Microsoft.AppLink/appLinks/appLinkMembers@2026-08-01-preview' = {
              name: 'aks-member'
              location: 'eastus'
              parent: appLink
              properties: {
                clusterType: 'AKS'
                connectivityProfile: {
                  eastWestGateway: {
                    visibility: 'Internal'
                  }
                  network: 'app-network'
                  privateConnect: {
                    subnetResourceId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.Network/virtualNetworks/my-vnet/subnets/my-subnet'
                  }
                }
                metadata: {
                  resourceId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.ContainerService/managedClusters/my-aks-cluster'
                }
                upgradeProfile: {
                  fullyManagedUpgradeProfile: {
                    releaseChannel: 'Stable'
                  }
                  mode: 'FullyManaged'
                }
              }
            }

            output metricsEndpoint string = member.properties.observabilityProfile.metrics.metricsEndpoint
            """);
    }
}
