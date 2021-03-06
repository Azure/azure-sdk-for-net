// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabricManagedClusters.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ServiceFabricManagedTestBase
    {
        protected string clusterIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.ServiceFabric/managedClusters/{2}";

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        protected ServiceFabricManagedClustersManagementClient GetServiceFabricMcClient(MockContext context)
        {
            return context.GetServiceClient<ServiceFabricManagedClustersManagementClient>();
        }

        protected ManagedCluster CreateManagedCluster(
            ResourceManagementClient resouceClient,
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string rg,
            string rgLocation,
            string clusterName,
            string sku,
            string clusterUpgradeMode = ClusterUpgradeMode.Automatic,
            string clusterUpgradeCadence = ClusterUpgradeCadence.Wave0,
            bool zonalResiliency = false)
        {
            var testTP = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B";
            var userName = "vmadmin";
            var newCluster = new ManagedCluster(
                location: rgLocation,
                sku: new Sku()
                {
                    Name = sku
                },
                dnsName: clusterName,
                adminPassword: "Password123!@#",
                adminUserName: userName,
                clientConnectionPort: 19000,
                httpGatewayConnectionPort: 19080,
                clients: new List<ClientCertificate>()
                {
                    new ClientCertificate()
                    {
                        IsAdmin = true,
                        Thumbprint = testTP
                    }
                },
                clusterUpgradeMode: clusterUpgradeMode,
                zonalResiliency: zonalResiliency);

            resouceClient.ResourceGroups.CreateOrUpdate(
                rg,
                new ResourceGroup(rgLocation));

            var cluster = serviceFabricMcClient.ManagedClusters.CreateOrUpdate(rg, clusterName, newCluster);
            Assert.NotNull(cluster);
            
            Assert.Equal(ManagedResourceProvisioningState.Succeeded, cluster.ProvisioningState);
            Assert.Equal(ClusterState.WaitingForNodes, cluster.ClusterState);
            Assert.NotNull(cluster.Sku);
            Assert.Equal(sku, cluster.Sku.Name);
            Assert.Equal(ClusterUpgradeCadence.Wave0, cluster.ClusterUpgradeCadence);
            Assert.Equal(userName, cluster.AdminUserName);
            Assert.Equal(clusterName, cluster.DnsName);
            Assert.Equal($"{clusterName}.southcentralus.cloudapp.azure.com", cluster.Fqdn);
            Assert.NotNull(cluster.ClusterCertificateThumbprints);
            Assert.Single(cluster.ClusterCertificateThumbprints);
            Assert.Equal(19000, cluster.ClientConnectionPort);
            Assert.Equal(19080, cluster.HttpGatewayConnectionPort);
            Assert.False(cluster.AllowRdpAccess);
            Assert.NotNull(cluster.Clients);
            Assert.Single(cluster.Clients);
            Assert.True(cluster.Clients[0].IsAdmin);
            Assert.Equal(testTP, cluster.Clients[0].Thumbprint);
            Assert.False(cluster.EnableAutoOSUpgrade);
            Assert.Equal(clusterUpgradeMode, cluster.ClusterUpgradeMode);
            Assert.Equal(zonalResiliency, cluster.ZonalResiliency);

            return cluster;
        }

        protected NodeType CreateNodeType(
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string rg,
            string clusterName,
            string nodeTypeName,
            bool isPrimary,
            int vmInstanceCount,
            string vmSize = "Standard_D2",
            string vmImagePublisher = "MicrosoftWindowsServer",
            string vmImageOffer = "WindowsServer",
            string vmImageSku = "2019-Datacenter",
            string vmImageVersion = "latest",
            int dataDiskSizeGB = 100,
            string dataDiskType = DiskType.StandardSSDLRS,
            bool isStateless = false)
        {
            var newNodeType = new NodeType(
                isPrimary: isPrimary,
                vmInstanceCount: vmInstanceCount,
                dataDiskSizeGB: dataDiskSizeGB,
                vmSize: vmSize,
                vmImagePublisher: vmImagePublisher,
                vmImageOffer: vmImageOffer,
                vmImageSku: vmImageSku,
                vmImageVersion: vmImageVersion,
                dataDiskType: dataDiskType,
                isStateless: isStateless);

            var nodeType = serviceFabricMcClient.NodeTypes.CreateOrUpdate(rg, clusterName, nodeTypeName, newNodeType);
            Assert.NotNull(nodeType);
            Assert.Equal(ManagedResourceProvisioningState.Succeeded, nodeType.ProvisioningState);
            Assert.Equal(isPrimary, nodeType.IsPrimary);
            Assert.Equal(vmImagePublisher, nodeType.VmImagePublisher);
            Assert.Equal(vmImageOffer, nodeType.VmImageOffer);
            Assert.Equal(vmImageSku, nodeType.VmImageSku);
            Assert.Equal(vmImageVersion, nodeType.VmImageVersion);
            Assert.Equal(vmSize, nodeType.VmSize);
            Assert.Equal(vmInstanceCount, nodeType.VmInstanceCount);
            Assert.Equal(dataDiskSizeGB, nodeType.DataDiskSizeGB);
            Assert.Equal(dataDiskType, nodeType.DataDiskType);
            Assert.Equal(isStateless, nodeType.IsStateless);

            return nodeType;
        }

        protected void WaitForClusterReadyState(
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string resourceGroupName,
            string clusterName)
        {
            var timeout = TimeSpan.FromMinutes(10);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (true)
            {
                var cluster = serviceFabricMcClient.ManagedClusters.Get(resourceGroupName, clusterName);
                if (cluster.ClusterState == ClusterState.Ready)
                {
                    break;
                }

                if (stopWatch.Elapsed >= timeout)
                    throw new TimeoutException($"Timeout waiting for cluster to be ready. Current state: {cluster.ClusterState}");

                TestUtilities.Wait(TimeSpan.FromSeconds(30));
            }
        }
    }
}

