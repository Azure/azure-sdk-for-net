// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabricManagedClusters.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ManagedClusterTests : ServiceFabricManagedTestBase
    {
        internal const string Location = "South Central US";
        internal const string ResourceGroupPrefix = "sfmc-net-sdk-rg-";
        internal const string ClusterNamePrefix = "sfmcnetsdk";

        [Fact]
        public void CrudClusterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);

                var ex = Assert.ThrowsAsync<ErrorModelException>(
                    () => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName)).Result;
                Assert.True(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricMcClient, resourceGroupName, Location, clusterName, sku: "Basic");
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                var clusters = serviceFabricMcClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                clusters = serviceFabricMcClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                cluster.ClientConnectionPort = 50000;
                cluster.FabricSettings = new List<SettingsSectionDescription>()
                {
                    new SettingsSectionDescription()
                    {
                        Name = "NamingService",
                        Parameters = new List<SettingsParameterDescription>()
                        {
                            new SettingsParameterDescription()
                            {
                                Name = "MaxOperationTimeout",
                                Value = "10001"
                            }
                        }
                    }
                };

                serviceFabricMcClient.ManagedClusters.CreateOrUpdate(resourceGroupName, clusterName, cluster);
                cluster = serviceFabricMcClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal(50000, cluster.ClientConnectionPort);
                Assert.NotNull(cluster.FabricSettings);
                Assert.Single(cluster.FabricSettings);

                serviceFabricMcClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.ThrowsAsync<ErrorModelException>(() => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName));

                clusters = serviceFabricMcClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.True(!clusters.IsAny());
            }
        }

        [Fact]
        public void CrudNodeTypeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);
                var nodeTypeName1 = TestUtilities.GenerateName("pnt");
                var nodeTypeName2 = TestUtilities.GenerateName("snt");

                var ex = Assert.ThrowsAsync<ErrorModelException>(
                    () => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName)).Result;
                Assert.True(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricMcClient, resourceGroupName, Location, clusterName, sku: "Standard");
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(serviceFabricMcClient, resourceGroupName, clusterName, nodeTypeName1, isPrimary: true, vmInstanceCount: 5);
                Assert.NotNull(primaryNodeType);
                Assert.Equal("Succeeded", primaryNodeType.ProvisioningState);

                var nodeTypes = serviceFabricMcClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Single(nodeTypes);

                // update node count on primary node type
                primaryNodeType.VmInstanceCount = 6;

                serviceFabricMcClient.NodeTypes.CreateOrUpdate(resourceGroupName, clusterName, nodeTypeName1, primaryNodeType);
                primaryNodeType = serviceFabricMcClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName1);
                Assert.Equal(6, primaryNodeType.VmInstanceCount);

                // add secondary node type
                var secondaryNodeType = this.CreateNodeType(serviceFabricMcClient, resourceGroupName, clusterName, nodeTypeName2, isPrimary: false, vmInstanceCount: 5);
                Assert.False(secondaryNodeType.IsPrimary);

                nodeTypes = serviceFabricMcClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Equal(2, nodeTypes.Count());

                serviceFabricMcClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.ThrowsAsync<ErrorModelException>(() => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName));
            }
        }

        [Fact]
        public void NodeTypeNodeOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricMcClient = GetServiceFabricMcClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);
                var nodeTypeName = TestUtilities.GenerateName("nt");

                var ex = Assert.ThrowsAsync<ErrorModelException>(
                    () => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName)).Result;
                Assert.True(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                ex = Assert.ThrowsAsync<ErrorModelException>(
                    () => serviceFabricMcClient.ManagedClusters.DeleteAsync(resourceGroupName, clusterName)).Result;
                Assert.True(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricMcClient, resourceGroupName, Location, clusterName, sku: "Basic");
                cluster = serviceFabricMcClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(serviceFabricMcClient, resourceGroupName, clusterName, nodeTypeName, isPrimary: true, vmInstanceCount: 6);

                var restartParams = new NodeTypeActionParameters()
                {
                    Nodes = new List<string>()
                    {
                        $"{nodeTypeName}_3"
                    }
                };

                // wait for baseline upgrade to finish
                this.WaitForClusterReadyState(serviceFabricMcClient, resourceGroupName, clusterName);

                // Restart nodes
                serviceFabricMcClient.NodeTypes.Restart(resourceGroupName, clusterName, nodeTypeName, restartParams);
                primaryNodeType = serviceFabricMcClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName);
                Assert.Equal(6, primaryNodeType.VmInstanceCount);

                var deleteParams = new NodeTypeActionParameters()
                {
                    Nodes = new List<string>()
                    {
                        $"{nodeTypeName}_0"
                    }
                };

                // Delete nodes
                serviceFabricMcClient.NodeTypes.DeleteNode(resourceGroupName, clusterName, nodeTypeName, deleteParams);
                primaryNodeType = serviceFabricMcClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName);
                Assert.True(primaryNodeType.IsPrimary);

                var reimageParams = new NodeTypeActionParameters()
                {
                    Nodes = new List<string>()
                    {
                        $"{nodeTypeName}_3"
                    }
                };

                // Reimage nodes
                serviceFabricMcClient.NodeTypes.Reimage(resourceGroupName, clusterName, nodeTypeName, reimageParams);
                primaryNodeType = serviceFabricMcClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName);
                Assert.True(primaryNodeType.IsPrimary);

                serviceFabricMcClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.ThrowsAsync<ErrorModelException>(() => serviceFabricMcClient.ManagedClusters.GetAsync(resourceGroupName, clusterName));
            }
        }
    }
}

