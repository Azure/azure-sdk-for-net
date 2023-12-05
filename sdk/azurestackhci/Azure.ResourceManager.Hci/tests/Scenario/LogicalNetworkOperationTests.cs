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
    public class LogicalNetworkOperationTests: HciManagementTestBase
    {
        public LogicalNetworkOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task LogicalNetworkGetDelete()
        {
            var logicalNetwork = await CreateLogicalNetworkAsync();
            var vmSwitchName = "testswitch";

            LogicalNetworkResource logicalNetworkFromGet = await logicalNetwork.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(logicalNetworkFromGet), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(logicalNetworkFromGet.Data.Name, logicalNetwork.Data.Name);
                Assert.AreEqual(logicalNetworkFromGet.Data.VmSwitchName, vmSwitchName);
            }
            Assert.AreEqual(logicalNetworkFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await logicalNetworkFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [RecordedTest]
        public async Task LogicalNetworkSetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var logicalNetwork = await CreateLogicalNetworkAsync();

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            LogicalNetworkResource updatedLogicalNetwork = await logicalNetwork.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedLogicalNetwork), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedLogicalNetwork.Data.Tags);
            }
            Assert.AreEqual(updatedLogicalNetwork.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
