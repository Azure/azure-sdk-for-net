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
    public class VirtualHardDiskOperationTests: HciManagementTestBase
    {
        public VirtualHardDiskOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task VirtualHardDiskGetDelete()
        {
            var virtualHardDisk = await CreateVirtualHardDiskAsync();

            VirtualHardDiskResource virtualHardDiskFromGet = await virtualHardDisk.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(virtualHardDiskFromGet), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(virtualHardDiskFromGet.Data.Name, virtualHardDisk.Data.Name);
                Assert.AreEqual(virtualHardDiskFromGet.Data.Dynamic, true);
            }
            Assert.AreEqual(virtualHardDiskFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await virtualHardDiskFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [RecordedTest]
        public async Task VirtualHardDiskSetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var virtualHardDisk = await CreateVirtualHardDiskAsync();

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            VirtualHardDiskResource updatedVirtualHardDisk = await virtualHardDisk.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedVirtualHardDisk), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedVirtualHardDisk.Data.Tags);
            }
            Assert.AreEqual(updatedVirtualHardDisk.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
