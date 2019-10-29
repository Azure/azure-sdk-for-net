// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedNetworkTests.cs" company="Microsoft">
//   
// </copyright>
// <summary>
//   Defines the  PeeringTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ManagedNetwork.Tests
{
    using System.Collections.Generic;

    using Microsoft.Azure.Management.ManagedNetwork;
    using Microsoft.Azure.Management.ManagedNetwork.Models;
    using ManagedNetwork.Tests.Helpers;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;


    public class ManagedNetworkTests
    {

        public ManagedNetworkManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        [Fact]
        public void ManagedNetworkTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                #region Initialization
                this.client = context.GetServiceClient<ManagedNetworkManagementClient>();
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();

                string resourceGroupName = TestUtilities.GenerateName("MNCRP_RSG");
                string location = "Central US";

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
                        ManagementGroups = new List<ResourceId>(),
                        Subscriptions = new List<ResourceId>(),
                        VirtualNetworks = new List<ResourceId>(){
                                new ResourceId()
                                {
                                    Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNCRG/providers/Microsoft.Network/virtualnetworks/testvnet"
                                }
                            },
                        Subnets = new List<ResourceId>(),
                    }
                };
                #endregion

                // Put ManagedNetwork
                ManagedNetworkModel putManagedNetworkResponse = this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                Assert.NotNull(putManagedNetworkResponse);
                Comparator.CompareManagedNetwork(managedNetwork, putManagedNetworkResponse);


                // Get ManagedNetwork
                ManagedNetworkModel getManagedNetworkResponse = this.client.ManagedNetworks.Get(resourceGroupName, managedNetworkName);
                Comparator.CompareManagedNetwork(managedNetwork, getManagedNetworkResponse);

                var listManagedNetworkResponse = this.client.ManagedNetworks.ListBySubscription();
                Assert.NotEmpty(listManagedNetworkResponse);

                this.client.ManagedNetworks.Delete(resourceGroupName, managedNetworkName);
                listManagedNetworkResponse = this.client.ManagedNetworks.ListByResourceGroup(resourceGroupName);
                Assert.Empty(listManagedNetworkResponse);
            }
        }
    }
}