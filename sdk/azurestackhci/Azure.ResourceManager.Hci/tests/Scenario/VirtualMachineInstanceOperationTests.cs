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
    public class VirtualMachineInstanceOperationTests: HciManagementTestBase
    {
        public VirtualMachineInstanceOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        public async Task VirtualHardDiskGetDelete()
        {
            var virtualMachineInstance = await CreateVirtualMachineInstanceAsync();

            VirtualMachineInstanceResource virtualMachineInstanceFromGet = await virtualMachineInstance.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(virtualMachineInstanceFromGet), TimeSpan.FromSeconds(6000)))
            {
                Assert.AreEqual(virtualMachineInstanceFromGet.Data.OSProfile.ComputerName, "dotnetvm");
                Assert.AreEqual(virtualMachineInstanceFromGet.Data.SecurityProfile.EnableTPM, false);
            }
            Assert.AreEqual(virtualMachineInstanceFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await virtualMachineInstanceFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
