// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class InstanceFailoverGroupTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstanceFailoverGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup resourceGroup = rgLro.Value;
            _resourceGroupIdentifier = resourceGroup.Id;
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<InstanceFailoverGroup> CreateInstanceFailoverGroup(string locationName,string instanceFailoverGroupName)
        {
            InstanceFailoverGroupData data = new InstanceFailoverGroupData()
            {
                ReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint(new ReadWriteEndpointFailoverPolicy()),
            };
            var instanceFailoverGroupLro = await _resourceGroup.GetInstanceFailoverGroups().CreateOrUpdateAsync(locationName, instanceFailoverGroupName, data);
            return instanceFailoverGroupLro.Value;
        }

        [Test]
        public async Task CheckIfExist()
        {
            string instanceFailoverGroupName = Recording.GenerateAssetName("InstanceFailoverGroup-");
            string locationName = Location.WestUS2.ToString();
            await CreateInstanceFailoverGroup(locationName,instanceFailoverGroupName);
            Assert.IsTrue(_resourceGroup.GetInstanceFailoverGroups().CheckIfExists(locationName,instanceFailoverGroupName));
        }
    }
}
