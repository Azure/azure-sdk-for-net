// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void DedicatedClusterGetCreateNamespace()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "southcentralus";

                var resourceGroupCluster = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroupCluster))
                {
                    resourceGroupCluster = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroupCluster);
                }

                var testClusterName = TestUtilities.GenerateName(EventHubManagementHelper.ClusterPrefix);

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                /// the Test for to the IEH self-serve cluster,we have dependency on deleting a self-serve cluster, Cluster can be deleted only after 4 hours                

                try
                {
                    Cluster createClusterResponse = EventHubManagementClient.Clusters.CreateOrUpdate(resourceGroupCluster, testClusterName, new Cluster() { 
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        Location = "southcentralus",
                        Sku = new ClusterSku()
                        {
                            Capacity = 1
                        }
                    });

                    Cluster getClusterResponse = EventHubManagementClient.Clusters.Get(resourceGroupCluster, testClusterName);

                    Assert.Equal(testClusterName.ToLower(), getClusterResponse.Name.ToLower());
                    Assert.True(getClusterResponse.Tags.Count() == 2);
                    Assert.Equal(1, getClusterResponse.Sku.Capacity);

                    var checkNameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(namespaceName);

                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName,
                        new EHNamespace()
                        {
                            Location = location,
                            Sku = new Microsoft.Azure.Management.EventHub.Models.Sku
                            {
                                Name = Microsoft.Azure.Management.EventHub.Models.SkuName.Standard,
                                Tier = SkuTier.Standard
                            },
                            Tags = new Dictionary<string, string>()
                            {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                            },
                            IsAutoInflateEnabled = false,
                            MaximumThroughputUnits = 0,
                            ClusterArmId = getClusterResponse.Id,
                            Identity = new Identity() { Type = ManagedServiceIdentityType.SystemAssigned }
                        });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(namespaceName, createNamespaceResponse.Name);
                    Assert.Equal(getClusterResponse.Id, createNamespaceResponse.ClusterArmId);
                    Assert.False(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(0, createNamespaceResponse.MaximumThroughputUnits);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    getClusterResponse.Tags = new Dictionary<string, string>()
                    {
                        { "k1", "v1" },
                        { "k2", "v2" },
                        { "k3", "v3" }
                    };

                    var updatedClusterResponse = this.EventHubManagementClient.Clusters.Update(resourceGroupCluster, testClusterName, getClusterResponse);

                    Assert.Equal(testClusterName.ToLower(), getClusterResponse.Name.ToLower());
                    Assert.True(getClusterResponse.Tags.Count() == 3);
                    Assert.Equal(1, getClusterResponse.Sku.Capacity);

                    var listOfNamespaces = this.EventHubManagementClient.Clusters.ListNamespaces(resourceGroupCluster, testClusterName);
                    Assert.Equal(1, listOfNamespaces.Value.Count);

                    var listClusterByResourceGroup = this.EventHubManagementClient.Clusters.ListByResourceGroup(resourceGroupCluster);
                    Assert.True(1 == listClusterByResourceGroup.Count());

                    var listClusterBySubscription = this.EventHubManagementClient.Clusters.ListBySubscription();
                    Assert.True(1 < listClusterBySubscription.Count());

                    //Delete the namesapce within the cluster
                    this.EventHubManagementClient.Namespaces.DeleteAsync(resourceGroupCluster, namespaceName, default(CancellationToken)).ConfigureAwait(false);

                    Assert.Throws<ErrorResponseException>(() => this.EventHubManagementClient.Clusters.Delete(resourceGroupCluster, testClusterName));

                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupCluster, null, default(CancellationToken)).ConfigureAwait(false);
                }

            }
        }
    }
}