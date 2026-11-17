// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerService.Tests;

public class ContainerServiceApiVersionTests
{
    [Test]
    public void ResourcesDefaultToAlignedApiVersion()
    {
        ProvisionableResource[] resources =
        [
            new ContainerServiceManagedCluster("cluster"),
            new ContainerServiceAgentPool("pool"),
            new AgentPoolSnapshot("snapshot"),
            new ContainerServiceMaintenanceConfiguration("maintenance"),
            new ContainerServiceTrustedAccessRoleBinding("binding"),
            new ManagedClusterNamespace("managedNamespace"),
            new ContainerServicePrivateEndpointConnection("connection"),
            new ManagedClusterIdentityBinding("identityBinding"),
            ContainerServiceMachine.FromExisting("machine"),
            AgentPoolUpgradeProfile.FromExisting("poolUpgrade"),
            ManagedClusterUpgradeProfile.FromExisting("clusterUpgrade"),
            MeshRevisionProfile.FromExisting("meshRevision"),
            MeshUpgradeProfile.FromExisting("meshUpgrade")
        ];
        foreach (ProvisionableResource resource in resources)
        {
            Assert.That(resource.ResourceVersion, Is.EqualTo("2026-07-01"), resource.GetType().Name);
        }
    }

    [TestCase("2025-10-01")]
    [TestCase("2026-01-01")]
    public void ExplicitApiVersionIsPreserved(string version)
    {
        ContainerServiceManagedCluster cluster = new("cluster", version);
        Assert.That(cluster.ResourceVersion, Is.EqualTo(version));
        Assert.That(ContainerServiceManagedCluster.ResourceVersions.V2025_10_01, Is.EqualTo("2025-10-01"));
        Assert.That(ContainerServiceManagedCluster.ResourceVersions.V2026_01_01, Is.EqualTo("2026-01-01"));
        Assert.That(ContainerServiceManagedCluster.ResourceVersions.V2026_07_01, Is.EqualTo("2026-07-01"));
    }

    [TestCase(null, "2026-07-01")]
    [TestCase("2026-01-01", "2026-01-01")]
    public async Task CreateClusterUsingSelectedApiVersion(string? resourceVersion, string expectedVersion)
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ContainerServiceManagedCluster cluster = new("cluster", resourceVersion)
                {
                    DnsPrefix = "aks"
                };
                infra.Add(cluster);
                return infra;
            });
        test.Compare(
            $$"""
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cluster 'Microsoft.ContainerService/managedClusters@{{expectedVersion}}' = {
              name: take('cluster-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                dnsPrefix: 'aks'
              }
            }
            """);
    }
}
