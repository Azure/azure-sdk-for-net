using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;

namespace Sql.Tests
{
    public class ManagedInstanceTestFixture : IDisposable
    {
        public SqlManagementTestContext Context { get; set; }

        public ResourceGroup ResourceGroup { get; set; }

        public ManagedInstance ManagedInstance { get; set; }

        public ManagedInstanceTestFixture()
        {
            Context = new SqlManagementTestContext(this);

            try
            {
                SqlManagementClient sqlClient = Context.GetClient<SqlManagementClient>();

                ResourceGroup = Context.CreateResourceGroup();

                // Create vnet and get the subnet id
                VirtualNetwork vnet = CreateVirtualNetwork(Context, ResourceGroup, TestEnvironmentUtilities.DefaultLocationId);
                
                Sku sku = new Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                ManagedInstance = sqlClient.ManagedInstances.CreateOrUpdate(ResourceGroup.Name,
                    "crud-tests-" + SqlManagementTestUtilities.GenerateName(), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });
            }
            catch(Exception ex)
            {
                Context.Dispose();
            }
        }

        public static VirtualNetwork CreateVirtualNetwork(SqlManagementTestContext context, ResourceGroup resourceGroup, string location)
        {
            NetworkManagementClient networkClient = context.GetClient<NetworkManagementClient>();

            // Create vnet andinitialize subnets
            string vnetName = SqlManagementTestUtilities.GenerateName();

            // Create network security group
            NetworkSecurityGroup networkSecurityGroupParams = new NetworkSecurityGroup()
            {
                Location = TestEnvironmentUtilities.DefaultLocationId,
                SecurityRules = new List<SecurityRule>()
                {
                    new SecurityRule()
                    {
                        Direction = "Inbound",
                        Name = "allow_management_inbound",
                        DestinationAddressPrefix = "*",
                        DestinationPortRanges = new List<string>() { "1433", "1434", "5022", "9000", "9003", "1438", "1440", "1452", "80", "443" },
                        SourceAddressPrefix = "*",
                        SourcePortRange = "*",
                        Protocol = "Tcp",
                        Access = "Allow",
                        Priority = 100
                    },
                    new SecurityRule()
                    {
                        Direction = "Inbound",
                        Name = "allow_misubnet_inbound",
                        DestinationPortRange = "*",
                        DestinationAddressPrefix = "*",
                        SourceAddressPrefix = "10.0.0.0/26",
                        SourcePortRange = "*",
                        Protocol = "*",
                        Access = "Allow",
                        Priority = 200
                    },
                    new SecurityRule()
                    {
                        Direction = "Inbound",
                        Name = "allow_health_probe",
                        DestinationAddressPrefix = "*",
                        DestinationPortRange = "*",
                        SourceAddressPrefix = "AzureLoadBalancer",
                        SourcePortRange = "*",
                        Protocol = "*",
                        Access = "Allow",
                        Priority = 300
                    },
                    new SecurityRule()
                    {
                        Direction = "Outbound",
                        Name = "allow_management_outbound",
                        DestinationAddressPrefix = "*",
                        DestinationPortRanges = new List<string>() { "80", "443", "12000" },
                        Protocol = "*",
                        SourceAddressPrefix = "*",
                        SourcePortRange = "*",
                        Access = "Allow",
                        Priority = 100
                    },
                    new SecurityRule()
                    {
                        Direction = "Outbound",
                        Name = "allow_misubnet_outbound",
                        DestinationAddressPrefix = "10.0.0.0/26",
                        DestinationPortRange = "*",
                        Protocol = "*",
                        SourceAddressPrefix = "*",
                        SourcePortRange = "*",
                        Access = "Allow",
                        Priority = 200
                    }
                }
            };
            string networkSecurityGroupName = SqlManagementTestUtilities.GenerateName();
            networkClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroup.Name, networkSecurityGroupName, networkSecurityGroupParams);
            NetworkSecurityGroup securityGroup = networkClient.NetworkSecurityGroups.Get(resourceGroup.Name, networkSecurityGroupName);

            // Create route table
            RouteTable routeTableParams = new RouteTable()
            {
                Location = TestEnvironmentUtilities.DefaultLocationId,
                Routes = new List<Route>()
                {
                    new Route()
                    {
                        Name = SqlManagementTestUtilities.GenerateName(),
                        AddressPrefix = "0.0.0.0/0",
                        NextHopType = "Internet"
                    },
                    new Route()
                    {
                        Name = SqlManagementTestUtilities.GenerateName(),
                        AddressPrefix = "10.0.0.0/26",
                        NextHopType = "VnetLocal"
                    }
                }
            };
            string routeTableName = SqlManagementTestUtilities.GenerateName();
            networkClient.RouteTables.CreateOrUpdate(resourceGroup.Name, routeTableName, routeTableParams);
            RouteTable routeTable = networkClient.RouteTables.Get(resourceGroup.Name, routeTableName);
            IList<Delegation> delegations = new List<Delegation>() { new Delegation() {
                ServiceName = "Microsoft.Sql/managedInstances",
                Name = "0"
            }};

            // Create subnet
            List<Subnet> subnetList = new List<Subnet>();
            Subnet subnet = new Subnet()
            {
                Name = "MISubnet",
                AddressPrefix = "10.0.0.0/26",
                NetworkSecurityGroup = securityGroup,
                RouteTable = routeTable,
                Delegations = delegations
            };
            subnetList.Add(subnet);

            // Create vnet
            var vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/22",
                        }
                },
                Subnets = subnetList
            };

            // Put Vnet
            var putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(resourceGroup.Name, vnetName, vnet);
            Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

            // Get Vnets
            var getVnetResponse = networkClient.VirtualNetworks.Get(resourceGroup.Name, vnetName);

            return getVnetResponse;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
