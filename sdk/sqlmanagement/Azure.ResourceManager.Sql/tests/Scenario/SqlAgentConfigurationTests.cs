﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class SqlAgentConfigurationTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public SqlAgentConfigurationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("Re-record before GA")]
        public async Task SqlAgentConfigurationApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetSqlAgentConfiguration();

            // 1.CreateOrUpdate
            SqlAgentConfigurationData data = new SqlAgentConfigurationData()
            {
            };
            var agentConfig = await collection.CreateOrUpdateAsync(WaitUntil.Completed, data);
            Assert.IsNotNull(agentConfig);
            Assert.AreEqual("current", agentConfig.Value.Data.Name);
            Assert.AreEqual("Enabled", agentConfig.Value.Data.State.ToString());
            Assert.AreEqual("Microsoft.Sql/managedInstances/sqlAgent", agentConfig.Value.Data.ResourceType.ToString());

            // 3.Get
            var getAgentConfig = await collection.GetAsync();
            Assert.IsNotNull(getAgentConfig);
            Assert.AreEqual("current", getAgentConfig.Value.Data.Name);
            Assert.AreEqual("Enabled", getAgentConfig.Value.Data.State.ToString());
            Assert.AreEqual("Microsoft.Sql/managedInstances/sqlAgent", getAgentConfig.Value.Data.ResourceType.ToString());

            // 4.GetAvailableLocations
            var getAvailableLocationsAgentConf = await collection.GetAvailableLocationsAsync();
            Assert.IsNotNull(getAvailableLocationsAgentConf);
        }
    }
}
