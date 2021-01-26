// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using PrivateEndpointConnection = Microsoft.Azure.Management.Sql.Models.PrivateEndpointConnection;

namespace Sql.Tests
{
    public class PrivateEndpointConnectionCrudScenarioTests
    {
        SqlManagementClient sqlClient = null;
        NetworkManagementClient networkClient = null;

        [Fact]
        public void TestAllScenariosPrivateEndpointConnection()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                sqlClient = context.GetClient<SqlManagementClient>();
                networkClient = context.GetClient<NetworkManagementClient>();

                var location = TestEnvironmentUtilities.DefaultEuapPrimaryLocationId;
                ResourceGroup resourceGroup = context.CreateResourceGroup(location);
                Server server = context.CreateServer(resourceGroup, location);
                VirtualNetwork vnet = CreateVirtualNetwork(resourceGroup, location);
                IList<PrivateEndpointConnection> pecs = CreatePrivateEndpoints(resourceGroup, location, server, vnet, n:2);

                PrivateEndpointConnection pec1 = pecs[0];
                pec1.PrivateLinkServiceConnectionState.Status = "Approved";
                sqlClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroup.Name, server.Name, pec1.Name, pec1);
                PrivateEndpointConnection pec1r = sqlClient.PrivateEndpointConnections.Get(resourceGroup.Name, server.Name, pec1.Name);
                SqlManagementTestUtilities.ValidatePrivateEndpointConnection(pec1, pec1r);

                PrivateEndpointConnection pec2 = pecs[1];
                pec2.PrivateLinkServiceConnectionState.Status = "Rejected";
                sqlClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroup.Name, server.Name, pec2.Name, pec2);
                PrivateEndpointConnection pec2r = sqlClient.PrivateEndpointConnections.Get(resourceGroup.Name, server.Name, pec2.Name);
                SqlManagementTestUtilities.ValidatePrivateEndpointConnection(pec2, pec2r);

                // Get server and verify correct PECs are returned
                Server retrievedServer = sqlClient.Servers.Get(resourceGroup.Name, server.Name);

                Assert.Equal(2, retrievedServer.PrivateEndpointConnections.Count());
                ValidatePECOnServer(pec1, retrievedServer.PrivateEndpointConnections[0]);
                ValidatePECOnServer(pec2, retrievedServer.PrivateEndpointConnections[1]);

                sqlClient.PrivateEndpointConnections.Delete(resourceGroup.Name, server.Name, pec1.Name);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.PrivateEndpointConnections.Get(resourceGroup.Name, server.Name, pec1.Name));

                sqlClient.PrivateEndpointConnections.Delete(resourceGroup.Name, server.Name, pec2.Name);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.PrivateEndpointConnections.Get(resourceGroup.Name, server.Name, pec2.Name));
            }
        }

        /// <summary>
        /// Verify PEC and PEC on server match
        /// </summary>
        /// <param name="pec">Private endpoint connections</param>
        /// <param name="serverPEC">Server private endpoint connections</param>
        private void ValidatePECOnServer(PrivateEndpointConnection pec, ServerPrivateEndpointConnection serverPEC)
        {
            Assert.Equal(pec.Id, serverPEC.Id);
            Assert.Equal(pec.PrivateEndpoint.Id, serverPEC.Properties.PrivateEndpoint.Id);
        }

        private IList<PrivateEndpointConnection> CreatePrivateEndpoints(ResourceGroup resourceGroup, string location, Server server, VirtualNetwork vnet, int n = 1)
        {
            string testPrefix = "privateendpointconnectioncrudtest-";

            for (int i = 0; i < n; i++)
            {
                string privateEndpointName = SqlManagementTestUtilities.GenerateName(testPrefix);

                PrivateEndpoint pe = new PrivateEndpoint()
                {
                    Location = location,
                    ManualPrivateLinkServiceConnections = new List<PrivateLinkServiceConnection>()
                    {
                        new PrivateLinkServiceConnection()
                        {
                            Name = testPrefix + "pls",
                            PrivateLinkServiceId = server.Id,
                            GroupIds = new List<string>()
                            {
                                "sqlServer"
                            },
                            RequestMessage = "Please approve my request"
                        }
                    },
                    Subnet = vnet.Subnets[0]
                };

                PrivateEndpoint per = networkClient.PrivateEndpoints.CreateOrUpdate(resourceGroup.Name, privateEndpointName, pe);
                Assert.Equal(privateEndpointName, per.Name);
                Assert.Equal("Pending", per.ManualPrivateLinkServiceConnections[0].PrivateLinkServiceConnectionState.Status);
            }

            var pecs = sqlClient.PrivateEndpointConnections.ListByServer(resourceGroup.Name, server.Name).ToList();
            Assert.Equal(n, (int)pecs.Count());

            return pecs;
        }

        private VirtualNetwork CreateVirtualNetwork(ResourceGroup resourceGroup, string location)
        {
            // Create vnet andinitialize subnets
            string vnetName = SqlManagementTestUtilities.GenerateName();

            List<Subnet> subnetList = new List<Subnet>();

                string subnetName = SqlManagementTestUtilities.GenerateName();
                String addressPrefix = "10.0.0.0/24";
                Subnet subnet = new Subnet()
                {
                    Name = subnetName,
                    AddressPrefix = addressPrefix,
                    PrivateEndpointNetworkPolicies = "Disabled"
                };
                subnetList.Add(subnet);

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
                Subnets = subnetList
            };

            // Put Vnet
            var putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(resourceGroup.Name, vnetName, vnet);
            Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

            // Get Vnet
            var getVnetResponse = networkClient.VirtualNetworks.Get(resourceGroup.Name, vnetName);

            return getVnetResponse;
        }
    }
}
