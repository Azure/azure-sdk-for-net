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
    public class InstancePoolTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstancePoolTests(bool isAsync)
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

        private async Task CreateInstancePool(string instancePoolName)
        {
            //-ResourceGroupName "Sql-RG-0001" `  -Name "mi-pool-name" `  -SubnetId $subnet.Id `  -LicenseType "LicenseIncluded" `
            //-VCore 8 `  -Edition "GeneralPurpose" `  -ComputeGeneration "Gen5" `  -Location "westus2"
            InstancePoolData data = new InstancePoolData(Location.WestUS2)
            {
                Sku = new Models.Sku("P3", "GeneralPurpose", "2", "Gen5", 8),
                LicenseType = InstancePoolLicenseType.LicenseIncluded,
                Location = Location.WestUS2,
                //SubnetId = subnetId,
            };
            await _resourceGroup.GetInstancePools().CreateOrUpdateAsync(instancePoolName, data);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExiest()
        {
            string instancePoolName = Recording.GenerateAssetName("instance-pool-");
            await CreateInstancePool(instancePoolName);
        }
    }
}
