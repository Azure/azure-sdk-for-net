// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class ExtensionTests : VMTestBase
    {
        public ExtensionTests(bool isAsync)
           : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        private VirtualMachineExtension GetTestVMExtension()
        {
            var vmExtension = new VirtualMachineExtension(null, "vmext01", "Microsoft.Compute/virtualMachines/extensions", "southeastasia",
                new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                "RerunExtension",
                "Microsoft.Compute",
                 "VMAccessAgent", "2.0", true, "{}", "{}", null, null
                );
            //{
            //    Tags = new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
            //    Publisher = "Microsoft.Compute",
            //    //VirtualMachineExtensionType = "VMAccessAgent",
            //    TypeHandlerVersion = "2.0",
            //    AutoUpgradeMinorVersion = true,
            //    ForceUpdateTag = "RerunExtension",
            //    Settings = "{}",
            //    ProtectedSettings = "{}"
            //};
            //typeof(Compute.Models.Resource).GetRuntimeProperty("Name").SetValue(vmExtension, "vmext01");
            //typeof(Compute.Models.Resource).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/virtualMachines/extensions");

            return vmExtension;
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private VirtualMachineExtensionUpdate GetTestVMUpdateExtension()
        {
            var vmExtensionUpdate = new VirtualMachineExtensionUpdate
            {
                Tags =
                    new Dictionary<string, string>
                    {
                        {"extensionTag1", "1"},
                        {"extensionTag2", "2"},
                        {"extensionTag3", "3"}
                    }
            };

            return vmExtensionUpdate;
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestVMExtensionOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var returnTwovm = await CreateVM(rgName, asName, storageAccountOutput, imageRef);
            var vm = returnTwovm.Item1;
            inputVM = returnTwovm.Item2;
            // Delete an extension that does not exist in the VM. A http status code of NoContent should be returned which translates to operation success.
            var xx = await WaitForCompletionAsync(await VirtualMachineExtensionsOperations.StartDeleteAsync(rgName, vm.Name, "VMExtensionDoesNotExist"));
            // Add an extension to the VM
            var vmExtension = GetTestVMExtension();
            var resp = await VirtualMachineExtensionsOperations.StartCreateOrUpdateAsync(rgName, vm.Name, vmExtension.Name, vmExtension);
            var response = await WaitForCompletionAsync(resp);
            ValidateVMExtension(vmExtension, response);

            // Perform a Get operation on the extension
            var getVMExtResponse = await VirtualMachineExtensionsOperations.GetAsync(rgName, vm.Name, vmExtension.Name);
            ValidateVMExtension(vmExtension, getVMExtResponse);

            // Perform a GetExtensions on the VM
            var getVMExtsResponse = (await VirtualMachineExtensionsOperations.ListAsync(rgName, vm.Name)).Value;

            Assert.True(getVMExtsResponse.Value.Count > 0);
            var vme = getVMExtsResponse.Value.Where(c => c.Name == "vmext01");
            Assert.AreEqual(vme.Count(), 1);
            //Assert.Single(vme);
            ValidateVMExtension(vmExtension, vme.First());

            // Validate Get InstanceView for the extension
            var getVMExtInstanceViewResponse = (await VirtualMachineExtensionsOperations.GetAsync(rgName, vm.Name, vmExtension.Name, "instanceView")).Value;
            ValidateVMExtensionInstanceView(getVMExtInstanceViewResponse.InstanceView);

            // Update extension on the VM
            var vmExtensionUpdate = GetTestVMUpdateExtension();
            await WaitForCompletionAsync(await VirtualMachineExtensionsOperations.StartUpdateAsync(rgName, vm.Name, vmExtension.Name, vmExtensionUpdate));
            vmExtension.Tags["extensionTag3"] = "3";
            getVMExtResponse = await VirtualMachineExtensionsOperations.GetAsync(rgName, vm.Name, vmExtension.Name);
            ValidateVMExtension(vmExtension, getVMExtResponse);

            // Validate the extension in the VM info
            var getVMResponse = (await VirtualMachinesOperations.GetAsync(rgName, vm.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            ValidateVMExtension(vmExtension, getVMResponse.Resources.FirstOrDefault(c => c.Name == vmExtension.Name));

            // Validate the extension instance view in the VM instance-view
            var getVMWithInstanceViewResponse = (await VirtualMachinesOperations.GetAsync(rgName, vm.Name)).Value;
            ValidateVMExtensionInstanceView(getVMWithInstanceViewResponse.InstanceView.Extensions.FirstOrDefault());

            // Validate the extension delete API
            await WaitForCompletionAsync(await VirtualMachineExtensionsOperations.StartDeleteAsync(rgName, vm.Name, vmExtension.Name));
        }

        private void ValidateVMExtension(VirtualMachineExtension vmExtExpected, VirtualMachineExtension vmExtReturned)
        {
            Assert.NotNull(vmExtReturned);
            Assert.True(!string.IsNullOrEmpty(vmExtReturned.ProvisioningState));

            Assert.True(vmExtExpected.Publisher == vmExtReturned.Publisher);
            Assert.True(vmExtExpected.TypePropertiesType == vmExtReturned.TypePropertiesType);
            Assert.True(vmExtExpected.AutoUpgradeMinorVersion == vmExtReturned.AutoUpgradeMinorVersion);
            Assert.True(vmExtExpected.TypeHandlerVersion == vmExtReturned.TypeHandlerVersion);
            Assert.True(vmExtExpected.Settings.ToString() == vmExtReturned.Settings.ToString());
            Assert.True(vmExtExpected.ForceUpdateTag == vmExtReturned.ForceUpdateTag);
            Assert.True(vmExtExpected.Tags.SequenceEqual(vmExtReturned.Tags));
        }

        private void ValidateVMExtensionInstanceView(VirtualMachineExtensionInstanceView vmExtInstanceView)
        {
            Assert.NotNull(vmExtInstanceView);
            Assert.NotNull(vmExtInstanceView.Statuses[0].DisplayStatus);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Code);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Level);
            Assert.NotNull(vmExtInstanceView.Statuses[0].Message);
        }
    }
}
