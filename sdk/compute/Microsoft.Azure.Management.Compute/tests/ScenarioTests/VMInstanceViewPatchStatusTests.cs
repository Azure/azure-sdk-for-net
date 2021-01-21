// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    public class VMInstanceViewPatchStatusTests : VMTestBase
    {
        private const string RgName = "RGforSDKtestResources";
        private const string VmName = "VMforTest";

        //How to re-record this test:
        // 1. Manually create Resource group and VM
        // update the constants for RgName and VmName
        // 2. invoke CRP install patch api
        // 3. Then run this test
        [Fact()]
        public void GetVMInstanceViewWithPatchStatus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                VirtualMachineInstanceView vmInstanceView = m_CrpClient.VirtualMachines.InstanceView(RgName, VmName);

                Assert.NotNull(vmInstanceView);
                Assert.NotNull(vmInstanceView.PatchStatus);
            }
        }
    }
}
