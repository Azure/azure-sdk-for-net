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
    public class NetworkInterfaceCollectionTests: HciManagementTestBase
    {
        public NetworkInterfaceCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        public async Task NetworkInterfaceCreateGetList()
        {
            var networkInterfaceCollection = ResourceGroup.GetNetworkInterfaces();

            //create logicalnetwork first
            var logicalNetwork = await CreateLogicalNetworkAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(logicalNetwork), TimeSpan.FromSeconds(100));
            Assert.AreEqual(logicalNetwork.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var networkInterface = await CreateNetworkInterfaceAsync(logicalNetwork.Data.Id);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(networkInterface), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(networkInterface.Data.Name, networkInterface.Data.Name);
                foreach (IPConfiguration ip in networkInterface.Data.IPConfigurations)
                {
                    Assert.AreEqual(ip.Properties.SubnetId, logicalNetwork.Data.Id);
                }
            }

            await foreach (NetworkInterfaceResource networkInterfaceFromList in networkInterfaceCollection)
            {
                foreach (IPConfiguration ip in networkInterfaceFromList.Data.IPConfigurations)
                {
                    Assert.AreEqual(ip.Properties.SubnetId, logicalNetwork.Data.Id);
                }
            }
        }
    }
}
