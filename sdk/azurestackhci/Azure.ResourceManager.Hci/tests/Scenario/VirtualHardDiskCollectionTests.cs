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
    public class VirtualHardDiskCollectionTests: HciManagementTestBase
    {
        public VirtualHardDiskCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task VirtualHardDiskCreateGetList()
        {
            var virtualHardDiskCollection = ResourceGroup.GetVirtualHardDisks();

            var virtualHardDisk = await CreateVirtualHardDiskAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(virtualHardDisk), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(virtualHardDisk.Data.Name, virtualHardDisk.Data.Name);
                Assert.AreEqual(virtualHardDisk.Data.Dynamic, true);
            }
            Assert.AreEqual(virtualHardDisk.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await foreach (VirtualHardDiskResource virtualHardDiskFromList in virtualHardDiskCollection)
            {
                Assert.AreEqual(virtualHardDiskFromList.Data.Dynamic, true);
            }
        }
    }
}
