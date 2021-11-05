// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetRunCommandTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Create VMSS VM RunCommand
        /// Get VMSS VM RunCommand
        /// Get VMSS VM RunCommand instance view
        /// List VMSS VM RunCommands
        /// Delete VMSS VM RunCommand
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetRunCommands()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                string instanceId = "0";
                bool passed = false;
                try
                {
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        vmScaleSetCustomizer: vmssModel =>
                        {
                            vmssModel.Tags = new Dictionary<string, string>() { { "supportsMultipleExtensions", "true" } };
                        });

                    // Add a run command to the VMSS
                    VirtualMachineRunCommand vmssRunCommand = VMRunCommandsTests.GetTestVMRunCommand("Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands");
                    var response = m_CrpClient.VirtualMachineScaleSetVMRunCommands.CreateOrUpdate(rgName, vmssName, instanceId, vmssRunCommand.Name, vmssRunCommand);
                    VMRunCommandsTests.ValidateVMRunCommand(vmssRunCommand, response);

                    // Perform a Get operation on the run command
                    var getVmssRunCommandResponse = m_CrpClient.VirtualMachineScaleSetVMRunCommands.Get(rgName, vmssName, instanceId, vmssRunCommand.Name);
                    VMRunCommandsTests.ValidateVMRunCommand(vmssRunCommand, getVmssRunCommandResponse);

                    // Validate the run command instance view
                    var getVmssWithInstanceViewResponse = m_CrpClient.VirtualMachineScaleSetVMRunCommands.Get(rgName, vmssName, instanceId, vmssRunCommand.Name, "instanceView");
                    VMRunCommandsTests.ValidateVMRunCommandInstanceView(getVmssWithInstanceViewResponse.InstanceView);

                    // Perform a List operation on vmss vm run command
                    var listVmssVMRunCommandsResponse = m_CrpClient.VirtualMachineScaleSetVMRunCommands.List(rgName, vmssName, instanceId);
                    VMRunCommandsTests.ValidateVMRunCommand(vmssRunCommand, listVmssVMRunCommandsResponse.FirstOrDefault(c => c.Name == vmssRunCommand.Name));

                    // Validate the run command delete API
                    m_CrpClient.VirtualMachineScaleSetVMRunCommands.Delete(rgName, vmssName, instanceId, vmssRunCommand.Name);

                    passed = true;
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}
