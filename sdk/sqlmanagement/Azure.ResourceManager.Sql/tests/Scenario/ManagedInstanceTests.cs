// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ManagedInstanceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<ManagedInstance> CreateOrUpdateManagedInstance(string managedInstanceName)
        {
            //1. create NetworkSecurityGroup
            string networkSecurityGroupName = Recording.GenerateAssetName("networkSecurityGroup-");
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
            {
                Location = Location.WestUS2,
            };
            var networkSecurityGroup = await _resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroupData);

            //2. create Route table
            string routeTableName = Recording.GenerateAssetName("routeTable-");
            RouteTableData routeTableData = new RouteTableData()
            {
                Location = Location.WestUS2,
            };
            var routeTable = await _resourceGroup.GetRouteTables().CreateOrUpdateAsync(routeTableName, routeTableData);

            //3. create Virtual network
            string vnetName = Recording.GenerateAssetName("vnet-");
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
                    }
                },
            };
            var vnet = await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);

            string subid = vnet.Value.Data.Id.ToString() + "/subnets/ManagedInstance";

            ManagedInstanceData data = new ManagedInstanceData(Location.WestUS2)
            {
                AdministratorLogin = $"admin-{managedInstanceName}",
                AdministratorLoginPassword = CreateGeneralPassword(),
                SubnetId = subid,
                PublicDataEndpointEnabled = false,
                MaintenanceConfigurationId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default",
                ProxyOverride = new ManagedInstanceProxyOverride("Proxy") { },
                TimezoneId = "UTC",
                StorageAccountType = new StorageAccountType("GRS"),
                ZoneRedundant = false,
            };
            var managedInstancedLro = await _resourceGroup.GetManagedInstances().CreateOrUpdateAsync(managedInstanceName, data);
            var managedInstanced = managedInstancedLro.Value;
            return managedInstanced;
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string managedInstanceName = Recording.GenerateAssetName("Managed-Instance-");
            var managedInstance = await CreateOrUpdateManagedInstance(managedInstanceName);
            Assert.NotNull(managedInstance.Data);
        }
    }
}
