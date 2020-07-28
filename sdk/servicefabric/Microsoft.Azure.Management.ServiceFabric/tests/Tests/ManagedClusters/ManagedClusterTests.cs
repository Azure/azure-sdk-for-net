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

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName);
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                var clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                var updateParams = new ManagedClusterUpdateParameters()
                {
                    ClientConnectionPort = 5000
                };

                serviceFabricClient.ManagedClusters.Update(resourceGroupName, clusterName, updateParams);
                cluster = serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal(50000, cluster.ClientConnectionPort);

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
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
                var nodeTypeName1 = TestUtilities.GenerateName();
                var nodeTypeName2 = TestUtilities.GenerateName();

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

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName);
                cluster = serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                var clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(resourceClient, serviceFabricClient, resourceGroupName, clusterName, nodeTypeName1, isPrimary: true, vmInstanceCount: 3);
                Assert.NotNull(primaryNodeType);
                

                // update node count on primary node type
                var updateParams = new NodeTypeUpdateParameters()
                {
                    VmInstanceCount = 5
                };

                serviceFabricClient.NodeTypes.Update(resourceGroupName, clusterName, nodeTypeName1, updateParams);
                primaryNodeType = serviceFabricClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName1);
                Assert.NotNull(primaryNodeType);
                Assert.Equal(5, primaryNodeType.VmInstanceCount);

                // add secondary node type
                var secondaryNodeType = this.CreateNodeType(resourceClient, serviceFabricClient, resourceGroupName, clusterName, nodeTypeName2, isPrimary: false, vmInstanceCount: 5);
                Assert.NotNull(secondaryNodeType);
                secondaryNodeType = serviceFabricClient.NodeTypes.Get(resourceGroupName, clusterName, nodeTypeName2);
                Assert.NotNull(secondaryNodeType);

                var nodeTypes = serviceFabricClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Equal(2, nodeTypes.Count());

                // delete secondary node type
                serviceFabricClient.NodeTypes.Delete(resourceGroupName, clusterName, nodeTypeName2);

                nodeTypes = serviceFabricClient.NodeTypes.ListByManagedClusters(resourceGroupName, clusterName);
                Assert.Single(nodeTypes);

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.True(!clusters.IsAny());
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
                var nodeTypeName = TestUtilities.GenerateName();

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

                var cluster = this.CreateManagedCluster(resourceClient, serviceFabricClient, resourceGroupName, Location, clusterName);
                cluster = serviceFabricClient.ManagedClusters.Get(resourceGroupName, clusterName);
                Assert.NotNull(cluster);
                Assert.Equal("Succeeded", cluster.ProvisioningState);
                Assert.Equal("WaitingForNodes", cluster.ClusterState);

                var clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(clusters);

                // add primary node type
                var primaryNodeType = this.CreateNodeType(resourceClient, serviceFabricClient, resourceGroupName, clusterName, nodeTypeName, isPrimary: true, vmInstanceCount: 5);
                Assert.NotNull(primaryNodeType);

                serviceFabricClient.n

                serviceFabricClient.ManagedClusters.Delete(resourceGroupName, clusterName);
                clusters = serviceFabricClient.ManagedClusters.ListByResourceGroup(resourceGroupName);
                Assert.True(!clusters.IsAny());
            }
        }
    }
}

