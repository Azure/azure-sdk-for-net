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
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class LogicalNetworkCollectionTests: HciManagementTestBase
    {
        public LogicalNetworkCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task LogicalNetworkCreateGetList()
        {
            var vmSwitchName = "testswitch";
            var logicalNetworkCollection = ResourceGroup.GetLogicalNetworks();
            var logicalNetwork = await CreateLogicalNetworkAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(logicalNetwork), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(logicalNetwork.Data.Name, logicalNetwork.Data.Name);
                Assert.AreEqual(logicalNetwork.Data.VmSwitchName, vmSwitchName);
            }
            Assert.AreEqual(logicalNetwork.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await foreach (LogicalNetworkResource logicalNetworkFromList in logicalNetworkCollection)
            {
                Assert.AreEqual(logicalNetworkFromList.Data.VmSwitchName, vmSwitchName);
            }
        }
    }
}
