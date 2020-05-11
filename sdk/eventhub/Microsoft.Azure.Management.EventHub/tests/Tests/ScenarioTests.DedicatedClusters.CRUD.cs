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

                var location = "West US";

                var resourceGroupCluster = EventHubManagementHelper.ResourceGroupCluster;

                var testClusterName = EventHubManagementHelper.TestClusterName;
                
                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                /// the Test for to the IEH self-serve cluster,we have dependency on deleting a self-serve cluster, Cluster can be deleted only after 4 hours                

                try
                {
                    Cluster getClusterResponse = EventHubManagementClient.Clusters.Get(resourceGroupCluster, testClusterName);

                    var checkNameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(new CheckNameAvailabilityParameter() { Name = namespaceName });

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
                            Identity = new Identity() { Type = IdentityType.SystemAssigned}
                        });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(namespaceName, createNamespaceResponse.Name);
                    Assert.Equal(getClusterResponse.Id, createNamespaceResponse.ClusterArmId);
                    Assert.False(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(0,createNamespaceResponse.MaximumThroughputUnits);
                                                         
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    //Delete the namesapce within the cluster
                    this.EventHubManagementClient.Namespaces.DeleteAsync(resourceGroupCluster, namespaceName, default(CancellationToken)).ConfigureAwait(false);

                }
                finally
                {
                    //Delete Resource Group
                }

            }
        }
    }
}
