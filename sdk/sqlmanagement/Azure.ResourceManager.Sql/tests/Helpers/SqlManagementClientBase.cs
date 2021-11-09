// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
    [RunFrequency(RunTestFrequency.Manually)]
    [ClientTestFixture]
    [NonParallelizable]
    public abstract class SqlManagementClientBase : ManagementRecordedTestBase<SqlManagementTestEnvironment>
    {
        protected string DefaultLocation = "westus2";

        protected SqlManagementClientBase(bool isAsync)
            : base(isAsync)
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

        protected async Task<ManagedInstance> CreateDefaultManagedInstance(string managedInstanceName,ResourceGroup resourceGroup)
        {
            Random random = new Random();
            string suffix = random.Next(9999).ToString();

            //1. create NetworkSecurityGroup
            string networkSecurityGroupName = $"networkSecurityGroup-{suffix}";
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
            {
                Location = Location.WestUS2,
            };
            var networkSecurityGroup = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroupData);

            //2. create Route table
            string routeTableName = $"routeTable-{suffix}";
            RouteTableData routeTableData = new RouteTableData()
            {
                Location = Location.WestUS2,
            };
            var routeTable = await resourceGroup.GetRouteTables().CreateOrUpdateAsync(routeTableName, routeTableData);

            //3. create vnet(subnet bind NetworkSecurityGroup and RouteTable)
            string vnetName = $"vnet-{suffix}";
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.10.0.0/16", }
                },
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData()
                    {
                        Name = "ManagedInstance",
                        AddressPrefix = "10.10.2.0/24",
                        Delegations =
                        {
                            new Delegation() { ServiceName  = "Microsoft.Sql/managedInstances",Name="Microsoft.Sql/managedInstances" ,Type="Microsoft.Sql"}
                        },
                        RouteTable = new RouteTableData(){ Id = routeTable.Value.Data.Id.ToString() },
                        NetworkSecurityGroup = new NetworkSecurityGroupData(){ Id = networkSecurityGroup.Value.Data.Id.ToString() },
                    }
                },
            };
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
            string subnetId = $"{vnet.Value.Data.Id}/subnets/ManagedInstance";

            //4. create ManagedInstance
            ManagedInstanceData data = new ManagedInstanceData(Location.WestUS2)
            {
                AdministratorLogin = $"admin-{managedInstanceName}",
                AdministratorLoginPassword = CreateGeneralPassword(),
                SubnetId = subnetId,
                PublicDataEndpointEnabled = false,
                MaintenanceConfigurationId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default",
                ProxyOverride = new ManagedInstanceProxyOverride("Proxy") { },
                TimezoneId = "UTC",
                StorageAccountType = new StorageAccountType("GRS"),
                ZoneRedundant = false,
            };
            var managedInstanceLro = await resourceGroup.GetManagedInstances().CreateOrUpdateAsync(managedInstanceName, data);
            var managedInstance = managedInstanceLro.Value;
            return managedInstance;
        }
    }
}
