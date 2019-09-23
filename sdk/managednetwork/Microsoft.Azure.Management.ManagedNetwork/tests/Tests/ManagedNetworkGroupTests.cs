// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedNetworkTests.cs" company="Microsoft">
//   
// </copyright>
// <summary>
//   Runs tests on Managed Network operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ManagedNetwork.Tests
{
    using System;
    using System.Collections.Generic;
    using ManagedNetwork.Tests.Helpers;
    using Microsoft.Azure.Management.ManagedNetwork;
    using Microsoft.Azure.Management.ManagedNetwork.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class ManagedNetworkGroupTests
    {
        public ManagedNetworkManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        [Fact]
        public void ManagedNetworkGroupTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                #region Initialization
                this.client = context.GetServiceClient<ManagedNetworkManagementClient>();
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();

                string resourceGroupName = TestUtilities.GenerateName("MNCRP_RSG");
                string location = "West US";

                ResourceGroup rsg;
                try
                {
                    rsg = this.resourcesClient.ResourceGroups.Get(resourceGroupName);
                }
                catch
                {
                    rsg = this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });
                }
                Assert.Equal(rsg.Name, resourceGroupName);
                #endregion

                #region Create managedNetwork
                string managedNetworkName = TestUtilities.GenerateName("myManagedNetwork");
                ManagedNetworkModel managedNetwork = new ManagedNetworkModel()
                {
                    Location = location,
                    Scope = new Scope()
                    {
                        VirtualNetworks = new List<ResourceId>(){
                            new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/testvnet"
                            },
                            new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/testvnet2"
                            },
                            new ResourceId()
                            {
                                Id = "subscriptions/6bb4a28a-db84-4e8a-b1dc-fabf7bd9f0b2/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/NewTestVNet"
                            }
                        },
                    }
                };
                // Put ManagedNetwork
                ManagedNetworkModel putManagedNetworkResponse = this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                #endregion

                string managedNetworkGroupName = TestUtilities.GenerateName("myGroup");
                ManagedNetworkGroup managedNetworkGroup = new ManagedNetworkGroup()
                {
                    Location = location,
                    VirtualNetworks = new List<ResourceId>()
                    {
                            new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/testvnet2"
                            },
                            new ResourceId()
                            {
                                Id = "subscriptions/6bb4a28a-db84-4e8a-b1dc-fabf7bd9f0b2/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/NewTestVNet"
                            }
                    }
                };
                ManagedNetworkGroup putManagedNetworkGroup = this.client.ManagedNetworkGroups.CreateOrUpdate(managedNetworkGroup, resourceGroupName, managedNetworkName, managedNetworkGroupName);
                Comparator.CompareManagedNetworkGroup(managedNetworkGroup, putManagedNetworkGroup);

                ManagedNetworkGroup getManagedNetworkGroup = this.client.ManagedNetworkGroups.Get(resourceGroupName, managedNetworkName, managedNetworkGroupName);
                Comparator.CompareManagedNetworkGroup(managedNetworkGroup, getManagedNetworkGroup);

                ManagedNetworkModel getManagedNetworkResponse = this.client.ManagedNetworks.Get(resourceGroupName, managedNetworkName);
                Comparator.CompareManagedNetworkGroup(managedNetworkGroup, getManagedNetworkResponse.Connectivity.Groups[0]);

                var listManagedNetworkGroupResponse = this.client.ManagedNetworkGroups.ListByManagedNetwork(resourceGroupName, managedNetworkName);
                Assert.Single(listManagedNetworkGroupResponse);
            }

        }
    }
}