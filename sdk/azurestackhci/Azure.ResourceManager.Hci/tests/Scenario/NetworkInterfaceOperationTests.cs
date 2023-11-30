// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class NetworkInterfaceOperationTests: HciManagementTestBase
    {
        public NetworkInterfaceOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        public async Task NetworkInterfaceGetDelete()
        {
            // create a logicalnetwork as prerequisite
            var logicalNetwork = await CreateLogicalNetworkAsync();
            var subnetId = logicalNetwork.Data.Id;
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(logicalNetwork), TimeSpan.FromSeconds(100));
            Assert.AreEqual(logicalNetwork.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var networkInterface = await CreateNetworkInterfaceAsync(subnetId);

            NetworkInterfaceResource networkInterfaceFromGet = await networkInterface.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(networkInterfaceFromGet), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(networkInterfaceFromGet.Data.Name, networkInterface.Data.Name);
                foreach (IPConfiguration ip in networkInterfaceFromGet.Data.IPConfigurations)
                {
                    Assert.AreEqual(ip.Properties.SubnetId, subnetId);
                }
            }
            Assert.AreEqual(networkInterfaceFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
            await networkInterfaceFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [RecordedTest]
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        public async Task NetworkInterfaceSetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            // create a logicalnetwork as prerequisite
            var logicalNetwork = await CreateLogicalNetworkAsync();
            var subnetId = logicalNetwork.Data.Id;
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(logicalNetwork), TimeSpan.FromSeconds(100));
            Assert.AreEqual(logicalNetwork.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var networkInterface = await CreateNetworkInterfaceAsync(subnetId);

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            NetworkInterfaceResource updatedNetworkInterface = await networkInterface.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedNetworkInterface), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedNetworkInterface.Data.Tags);
            }
            Assert.AreEqual(updatedNetworkInterface.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
