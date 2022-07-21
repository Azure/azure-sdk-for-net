// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class IotHubMiscTests : IotHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public IotHubMiscTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("IotHub-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task GetIotHubUserSubscriptionQuota()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            var subs = Client.GetDefaultSubscriptionAsync().Result;
            var quota = subs.GetIotHubUserSubscriptionQuotaAsync().ConfigureAwait(false);
            await foreach (var q in quota)
            {
                Assert.IsNotNull(q.Name.Value);
                Assert.IsNotNull(q.Name.LocalizedValue);
                Assert.IsTrue(q.Limit > 0);
            }
        }
    }
}
