// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabVirtualMachineTests : LabServicesManagementTestBase
    {
        public LabVirtualMachineTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task LabVMCRUD()
        {
            // Prepare lab resource with 2 additional vms
            var rg = await CreateResourceGroupAsync();
            var labCollection = rg.GetLabs();
            var labData = GetLabData();
            var labName = Recording.GenerateAssetName("sdklab-");
            var lab = (await labCollection.CreateOrUpdateAsync(WaitUntil.Completed, labName, labData)).Value;

            // GetAll test
            var vmCollection = lab.GetLabVirtualMachines();
            var list = await vmCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, list.Count);
            var vmName = list[0].Data.Name;

            // Exists test
            bool boolResult = await vmCollection.ExistsAsync(vmName);
            Assert.IsTrue(boolResult);
            boolResult = await vmCollection.ExistsAsync("foo");
            Assert.IsFalse(boolResult);

            // Get test - 1
            var vm = (await vmCollection.GetAsync(vmName)).Value;
            Assert.AreEqual(vm.Data.Name, vmName);

            // Start test
            // Start before redeploy
            await vm.StartAsync(WaitUntil.Completed);
            vm = (await vmCollection.GetAsync(vmName)).Value;
            Assert.AreEqual(vm.Data.State, LabVirtualMachineState.Running);

            // Redeploy test
            await vm.RedeployAsync(WaitUntil.Completed);
            vm = (await vmCollection.GetAsync(vmName)).Value;
            Assert.AreEqual(vm.Data.State, LabVirtualMachineState.Running);

            // Reimage test
            await vm.ReimageAsync(WaitUntil.Completed);
            vm = (await vmCollection.GetAsync(vmName)).Value;
            Assert.AreEqual(vm.Data.State, LabVirtualMachineState.Running);

            // Get test - 2
            vm = await vm.GetAsync();
            Assert.AreEqual(vm.Data.Name, vmName);
            Assert.AreEqual(vm.Data.State, LabVirtualMachineState.Running);

            // Reset password test
            // Set the password if not in playback mode
            var pwd = Mode == RecordedTestMode.Playback ? "Sanitized" : Environment.GetEnvironmentVariable("USER_PWD");
            var content = new LabVirtualMachineResetPasswordContent("tester", pwd);
            await vm.ResetPasswordAsync(WaitUntil.Completed, content);

            // Stop test
            await vm.StopAsync(WaitUntil.Completed);
            vm = (await vmCollection.GetAsync(vmName)).Value;
            Assert.AreEqual(vm.Data.State, LabVirtualMachineState.Stopped);
        }

        public LabData GetLabData()
        {
            return new LabData(DefaultLocation)
            {
                Title = "test lab",
                AutoShutdownProfile = new LabAutoShutdownProfile()
                {
                    ShutdownOnDisconnect = LabServicesEnableState.Disabled,
                    ShutdownOnIdle = LabVirtualMachineShutdownOnIdleMode.UserAbsence,
                    ShutdownWhenNotConnected = LabServicesEnableState.Disabled,
                    IdleDelay = TimeSpan.FromMinutes(15)
                },
                ConnectionProfile = new LabConnectionProfile()
                {
                    ClientRdpAccess = LabVirtualMachineConnectionType.Public,
                    ClientSshAccess = LabVirtualMachineConnectionType.Public,
                    WebRdpAccess = LabVirtualMachineConnectionType.None,
                    WebSshAccess = LabVirtualMachineConnectionType.None
                },
                VirtualMachineProfile = new LabVirtualMachineProfile(
                    createOption: LabVirtualMachineCreateOption.TemplateVm,
                    imageReference: new LabVirtualMachineImageReference()
                    {
                        Sku = "20_04-lts",
                        Offer = "0001-com-ubuntu-server-focal",
                        Publisher = "canonical",
                        Version = "latest"
                    },
                    sku: new LabServicesSku("Standard_Fsv2_2_4GB_64_S_SSD")
                    {
                        Capacity = 2
                    },
                    usageQuota: TimeSpan.FromHours(2),
                    adminUser: new LabVirtualMachineCredential("tester")
                    {
                        // Set the password if not in playback mode
                        Password = Mode == RecordedTestMode.Playback ? "Sanitized" : Environment.GetEnvironmentVariable("USER_PWD"),
                    }
                    )
                {
                    UseSharedPassword = LabServicesEnableState.Enabled
                },
                SecurityProfile = new LabSecurityProfile()
                {
                    OpenAccess = LabServicesEnableState.Disabled
                }
            };
        }
    }
}
