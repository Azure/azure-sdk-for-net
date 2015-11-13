﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests
{
    public class SubnetTests
    {
        [Fact(Skip = "TODO: Autorest")]
        public void SubnetApiTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient,
                    "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string subnet1Name = TestUtilities.GenerateName();
                string subnet2Name = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = "10.0.0.0/24",
                        }
                    }
                };

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName,vnetName, vnet);

                // Create a Subnet
                // Populate paramters for a Subnet
                var subnet = new Subnet()
                {
                    Name = subnet2Name,
                    AddressPrefix = "10.0.1.0/24",
                };

                #region Verification

                var putSubnetResponse = networkResourceProviderClient.Subnets.CreateOrUpdate(resourceGroupName, vnetName, subnet2Name, subnet);

                var getVnetResponse = networkResourceProviderClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                Assert.Equal(2, getVnetResponse.Subnets.Count);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnet2Name);

                // Verify the getSubnetResponse
                Assert.True(AreSubnetsEqual(getVnetResponse.Subnets[1], getSubnetResponse));

                var getSubnetListResponse = networkResourceProviderClient.Subnets.List(resourceGroupName, vnetName);

                // Verify ListSubnets
                Assert.True(AreSubnetsEqual(getVnetResponse.Subnets, getSubnetListResponse));

                // Delete the subnet "subnet1"
                networkResourceProviderClient.Subnets.Delete(resourceGroupName, vnetName, subnet2Name);

                // Verify that the deletion was successful
                getSubnetListResponse = networkResourceProviderClient.Subnets.List(resourceGroupName, vnetName);

                Assert.Equal(1, getSubnetListResponse.Count());
                Assert.Equal(subnet1Name, getSubnetListResponse.First().Name);

                #endregion
            }
        }

        private bool AreSubnetsEqual(Subnet subnet1, Subnet subnet2)
        {
            return subnet1.Id == subnet2.Id &&
                   subnet1.Etag == subnet2.Etag &&
                   subnet1.ProvisioningState == subnet2.ProvisioningState &&
                   subnet1.Name == subnet2.Name &&
                   subnet1.AddressPrefix == subnet2.AddressPrefix;
        }

        private bool AreSubnetsEqual(IEnumerable<Subnet> subnets1, IEnumerable<Subnet> subnets2)
        {
            var subnetCollection = subnets1.Zip(subnets2, (s1, s2) => new { subnet1 = s1, subnet2 = s2 });

            return subnetCollection.All(subnets => AreSubnetsEqual(subnets.subnet1, subnets.subnet2));
        }
    }
}
