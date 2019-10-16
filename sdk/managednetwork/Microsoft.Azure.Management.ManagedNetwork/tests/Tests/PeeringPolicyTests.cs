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
    using System.Collections.Generic;
    using ManagedNetwork.Tests.Helpers;
    using Microsoft.Azure.Management.ManagedNetwork;
    using Microsoft.Azure.Management.ManagedNetwork.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;




    public class PeeringPolicyTests
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
                this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                // Create Connectivity Group
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
                // Put Connectivity Group
                ManagedNetworkGroup putConnectivityGroupResponse = this.client.ManagedNetworkGroups.CreateOrUpdate(managedNetworkGroup, resourceGroupName, managedNetworkName, managedNetworkGroupName);
                #endregion

                #region Create peeringPolicy
                string peeringPolicyName = TestUtilities.GenerateName("hubAndSpoke");
                ResourceId hub = new ResourceId()
                {
                    Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/testvnet"
                };

                var spokes = new List<ResourceId>
                {
                    new ResourceId()
                    {
                        Id = putConnectivityGroupResponse.Id
                    },
                };

                ManagedNetworkPeeringPolicyProperties managedNetworkPeeringPolicyProperties = new ManagedNetworkPeeringPolicyProperties
                {
                    Type = "HubAndSpokeTopology",
                    Hub = hub,
                    Spokes = spokes
                };

                ManagedNetworkPeeringPolicy peeringPolicy = new ManagedNetworkPeeringPolicy
                {
                    Location = location,
                    Properties = managedNetworkPeeringPolicyProperties
                };
                #endregion

                // Put PeeringPolicy
                ManagedNetworkPeeringPolicy putPeeringPolicyResult = this.client.ManagedNetworkPeeringPolicies.CreateOrUpdate(peeringPolicy, resourceGroupName, managedNetworkName, peeringPolicyName);
                Assert.NotNull(putPeeringPolicyResult);
                Comparator.ComparePeeringPolicy(peeringPolicy, putPeeringPolicyResult);

                // Get PeeringPolicy
                ManagedNetworkPeeringPolicy getPeeringPolicyResult = this.client.ManagedNetworkPeeringPolicies.Get(resourceGroupName, managedNetworkName, peeringPolicyName);
                Comparator.ComparePeeringPolicy(peeringPolicy, getPeeringPolicyResult);

                //Get PeeringPolicy from ManagedNetwork
                ManagedNetworkModel getManagedNetworkResponse = this.client.ManagedNetworks.Get(resourceGroupName, managedNetworkName);
                Comparator.ComparePeeringPolicy(peeringPolicy, getManagedNetworkResponse.Connectivity.Peerings[0]);

                //List PeeringPolicy from ManagedNetworkm
                var listPeeringPolicyResponse = this.client.ManagedNetworkPeeringPolicies.ListByManagedNetwork(resourceGroupName, managedNetworkName);
                Assert.Single(listPeeringPolicyResponse);

                //Delete PeeringPolicy
                this.client.ManagedNetworkPeeringPolicies.Delete(resourceGroupName, managedNetworkName, peeringPolicyName);
                
            }

        }
    }
}