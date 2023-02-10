// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    [ClientTestFixture]
    [NonParallelizable]
    public abstract class SqlManagementClientBase : ManagementRecordedTestBase<SqlManagementTestEnvironment>
    {
        protected string DefaultLocation = "westus2";

        protected SqlManagementClientBase(bool isAsync)
            : base(isAsync)
        {
        }
        public SqlManagementClientBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
        [SetUp]
        public virtual void TestSetup()
        {
        }

        [TearDown]
        public virtual Task TestCleanup()
        {
            return Task.CompletedTask;
        }

        protected string CreateGeneralPassword()
        {
            return "HvVJ%paVC@%GBKmi";
        }

        /// <summary>
        /// create a defaut managed instance.
        /// defaut vnet AddressPrefixes = 10.10.0.0/16
        /// </summary>
        /// <param name="managedInstanceName"></param>
        /// <param name="location"></param>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        protected async Task<ManagedInstanceResource> CreateDefaultManagedInstance(string managedInstanceName,string networkSecurityGroupName, string routeTableName , string vnetName , AzureLocation location, ResourceGroupResource resourceGroup)
        {
            //1. create NetworkSecurityGroup
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
            {
                Location = location,
            };
            var networkSecurityGroup = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);

            //2. create Route table
            RouteTableData routeTableData = new RouteTableData()
            {
                Location = location,
            };
            var routeTable = await resourceGroup.GetRouteTables().CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTableData);

            //3. create vnet(subnet bind NetworkSecurityGroup and RouteTable)
            var vnetData = new VirtualNetworkData()
            {
                Location = location,
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData()
                    {
                        Name = "ManagedInstance",
                        AddressPrefix = "10.10.2.0/24",
                        Delegations =
                        {
                            new ServiceDelegation() { ServiceName  = "Microsoft.Sql/managedInstances",Name="Microsoft.Sql/managedInstances" ,ResourceType="Microsoft.Sql/managedInstances"}
                        },
                        RouteTable = new RouteTableData(){ Id = routeTable.Value.Data.Id },
                        NetworkSecurityGroup = new NetworkSecurityGroupData(){ Id = networkSecurityGroup.Value.Data.Id },
                    }
                },
            };
            vnetData.AddressPrefixes.Add("10.10.0.0/16");
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData);
            ResourceIdentifier subnetId = new ResourceIdentifier($"{vnet.Value.Data.Id}/subnets/ManagedInstance");

            //4. create ManagedInstance
            ManagedInstanceData data = new ManagedInstanceData(location)
            {
                AdministratorLogin = $"admin-{managedInstanceName}",
                AdministratorLoginPassword = CreateGeneralPassword(),
                SubnetId = subnetId,
                IsPublicDataEndpointEnabled = false,
                MaintenanceConfigurationId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default"),
                ProxyOverride = new ManagedInstanceProxyOverride("Proxy") { },
                TimezoneId = "UTC",
                IsZoneRedundant = false,
            };
            var managedInstanceLro = await resourceGroup.GetManagedInstances().CreateOrUpdateAsync(WaitUntil.Completed, managedInstanceName, data);
            var managedInstance = managedInstanceLro.Value;
            return managedInstance;
        }

        /// <summary>
        /// create a default private endpoint for managed instance.
        /// please make sure your MI built using CreateDefaultManagedInstance() or vnet AddressPrefixes = 10.10.0.0/16
        /// </summary>
        /// <param name="managedInstance"></param>
        /// <param name="location"></param>
        /// <param name="resourceGroup"></param>
        /// <param name=""></param>
        /// <returns></returns>
        protected async Task<PrivateEndpointResource> CreateDefaultPrivateEndpoint(ManagedInstanceResource managedInstance,VirtualNetworkResource vnet, AzureLocation location, ResourceGroupResource resourceGroup)
        {
            // Add new subnet
            SubnetData subnetData = new SubnetData()
            {
                AddressPrefix = "10.10.5.0/24",
                PrivateEndpointNetworkPolicy = "Disabled"
            };
            var privateEndpointSubnet = await vnet.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, $"private-endpoint-subnet", subnetData);

            // Create private endpoint
            string privateEndpointName = $"{managedInstance.Data.Name}-private-endpoint";
            var endpointCollection = resourceGroup.GetPrivateEndpoints();
            PrivateEndpointData data = new PrivateEndpointData()
            {
                Subnet = new SubnetData() { Id = privateEndpointSubnet.Value.Data.Id },
                Location = location,
                PrivateLinkServiceConnections =
                {
                    new NetworkPrivateLinkServiceConnection()
                    {
                        Name = privateEndpointName,
                        PrivateLinkServiceId = managedInstance.Data.Id,
                        GroupIds = { "managedInstance" },
                    }
                },
            };
            var privateEndpoint = await resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointName, data);
            return privateEndpoint.Value;
        }

        /// <summary>
        /// create a defaut sql server.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="location"></param>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        protected async Task<SqlServerResource> CreateDefaultSqlServer(string serverName, AzureLocation location, ResourceGroupResource resourceGroup)
        {
            // create SqlServer
            SqlServerData data = new SqlServerData(location)
            {
                AdministratorLogin = $"admin-{serverName}",
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var sqlServerResponse = await resourceGroup.GetSqlServers().CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            return sqlServerResponse.Value;
        }
    }
}
