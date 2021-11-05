// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Managed
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.ServiceFabric;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ManagedClusterTests : ServiceFabricManagedTestBase
    {
        internal const string Location = "South Central US";
        internal const string ResourceGroupPrefix = "sfmc-dotnet-sdk-RG-";
        internal const string ClusterNamePrefix = "sfmcdotnetsdk";

        [Fact]
        public void CrudClusterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);

                try
                {
                    serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                    serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                catch (ErrorModelException e)
                {
                    Assert.True(e.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                }

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName, sku: "Basic");
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                var clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
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

                serviceFabricClient.ManagedClusters.CreateOrUpdate(resourceGroupName, clusterName, cluster);
                cluster = serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal(50000, cluster.ClientConnectionPort);
                Assert.NotNull(cluster.FabricSettings);
                Assert.Single(cluster.FabricSettings);

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.Throws<ErrorModelException>(() => serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName));

                clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.True(!clusters.IsAny());
            }
        }

        [Fact]
        public void CrudNodeTypeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);
                var nodeTypeName1 = TestUtilities.GenerateName("pnt");
                var nodeTypeName2 = TestUtilities.GenerateName("snt");

                try
                {
                    serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                    serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                catch (ErrorModelException e)
                {
                    Assert.True(e.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                }

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName, sku: "Standard");
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(serviceFabricClient, resourceGroupName, clusterName, nodeTypeName1, isPrimary: true, vmInstanceCount: 5);
                Assert.NotNull(primaryNodeType);
                Assert.Equal("Succeeded", primaryNodeType.ProvisioningState);

                var nodeTypes = serviceFabricClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Single(nodeTypes);

                // update node count on primary node type
                primaryNodeType.VmInstanceCount = 6;

                serviceFabricClient.NodeTypes.CreateOrUpdate(resourceGroupName, clusterName, nodeTypeName1, primaryNodeType);
                primaryNodeType = serviceFabricClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName1);
                Assert.Equal(6, primaryNodeType.VmInstanceCount);

                // add secondary node type
                var secondaryNodeType = this.CreateNodeType(serviceFabricClient, resourceGroupName, clusterName, nodeTypeName2, isPrimary: false, vmInstanceCount: 5);
                Assert.False(secondaryNodeType.IsPrimary);

                nodeTypes = serviceFabricClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Equal(2, nodeTypes.Count());

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.Throws<ErrorModelException>(() => serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName));
            }
        }

        [Fact]
        public void NodeTypeNodeOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resourceClient = GetResourceManagementClient(context);
                var resourceGroupName = TestUtilities.GenerateName(ResourceGroupPrefix);
                var clusterName = TestUtilities.GenerateName(ClusterNamePrefix);
                var nodeTypeName = TestUtilities.GenerateName("nt");

                try
                {
                    serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                    serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                catch (ErrorModelException e)
                {
                    Assert.True(e.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                }

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName, sku: "Basic");
                cluster = serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(serviceFabricClient, resourceGroupName, clusterName, nodeTypeName, isPrimary: true, vmInstanceCount: 7);

                var postParams = new NodeTypeActionParameters()
                {
                    Nodes = new List<string>()
                    {
                        $"{nodeTypeName}_3",
                        $"{nodeTypeName}_4"
                    }
                };

                // Restart nodes
                serviceFabricClient.NodeTypes.Restart(resourceGroupName, clusterName, nodeTypeName, postParams);
                primaryNodeType = serviceFabricClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName);
                Assert.Equal(7, primaryNodeType.VmInstanceCount);

                // Delete nodes
                serviceFabricClient.NodeTypes.DeleteNode(resourceGroupName, clusterName, nodeTypeName, postParams);
                primaryNodeType = serviceFabricClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName);
                Assert.True(primaryNodeType.IsPrimary);

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                Assert.Throws<ErrorModelException>(() => serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName));
            }
        }
    }
}

