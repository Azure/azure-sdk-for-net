// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using Xunit;

namespace Compute.Tests
{
    public class VMRunCommandsTests : VMTestBase
    {
        [Fact]
        public void TestListVMRunCommands()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                string location = ComputeManagementTestUtilities.DefaultLocation.Replace(" ", "");
                string documentId = "RunPowerShellScript";

                // Verify the List of commands
                IEnumerable<RunCommandDocumentBase> runCommandListResponse = computeClient.VirtualMachineRunCommands.List(location);
                Assert.NotNull(runCommandListResponse);
                Assert.True(runCommandListResponse.Count() > 0, "ListRunCommands should return at least 1 command");
                RunCommandDocumentBase documentBase =
                    runCommandListResponse.FirstOrDefault(x => string.Equals(x.Id, documentId));
                Assert.NotNull(documentBase);

                // Verify Get a specific RunCommand
                RunCommandDocument document = computeClient.VirtualMachineRunCommands.Get(location, documentId);
                Assert.NotNull(document);
                Assert.NotNull(document.Script);
                Assert.True(document.Script.Count > 0, "Script should contain at least one command.");
                Assert.NotNull(document.Parameters);
                Assert.True(document.Parameters.Count == 2, "Script should have 2 parameters.");
            }
        }

        [Fact]
        public void TestVMRunCommandOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    // Create a VM with supportsMultipleExtensions = true tag to enable the multiconfig support
                    var vm = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, vmApiModel =>
                        { vmApiModel.Tags = new Dictionary<string, string>() { { "supportsMultipleExtensions", "true" } }; });

                    // Delete a run command that does not exist in the VM. A http status code of NoContent should be returned which translates to operation success.
                    m_CrpClient.VirtualMachineRunCommands.Delete(rgName, vm.Name, "NonExistingRunCommand");

                    // Add a run command to the VM
                    var vmRunCommand = GetTestVMRunCommand("Microsoft.Compute/virtualMachines/runCommands");
                    var response = m_CrpClient.VirtualMachineRunCommands.CreateOrUpdate(rgName, vm.Name, vmRunCommand.Name, vmRunCommand);
                    ValidateVMRunCommand(vmRunCommand, response);

                    // Perform a GetByVirtualMachine operation on the run command
                    var getVMRunCommandResponse = m_CrpClient.VirtualMachineRunCommands.GetByVirtualMachine(rgName, vm.Name, vmRunCommand.Name);
                    ValidateVMRunCommand(vmRunCommand, getVMRunCommandResponse);

                    // Perform a ListByVirtualMachine on the VM
                    var getVMRunCommandsResponse = m_CrpClient.VirtualMachineRunCommands.ListByVirtualMachine(rgName, vm.Name);
                    Assert.True(getVMRunCommandsResponse.Any());
                    var vmRunCommands = getVMRunCommandsResponse.Where(c => c.Name == vmRunCommand.Name);
                    // Assert.Single(vmRunCommands);
                    ValidateVMRunCommand(vmRunCommand, vmRunCommands.First());

                    // Validate Get InstanceView for the run command
                    var getVMRunCommandInstanceViewResponse = m_CrpClient.VirtualMachineRunCommands.GetByVirtualMachine(rgName, vm.Name, vmRunCommand.Name, "instanceView");
                    ValidateVMRunCommandInstanceView(getVMRunCommandInstanceViewResponse.InstanceView);

                    // Update run command on the VM
                    var vmRunCommandUpdate = GetTestVMUpdateRunCommand();
                    m_CrpClient.VirtualMachineRunCommands.Update(rgName, vm.Name, vmRunCommand.Name, vmRunCommandUpdate);
                    vmRunCommand.Source.Script = vmRunCommandUpdate.Source.Script;
                    vmRunCommand.TimeoutInSeconds = 0;
                    vmRunCommand.Parameters = null;
                    getVMRunCommandResponse = m_CrpClient.VirtualMachineRunCommands.GetByVirtualMachine(rgName, vm.Name, vmRunCommand.Name);
                    ValidateVMRunCommand(vmRunCommand, getVMRunCommandResponse);

                    // Validate the run command delete API
                    m_CrpClient.VirtualMachineRunCommands.Delete(rgName, vm.Name, vmRunCommand.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        internal static VirtualMachineRunCommand GetTestVMRunCommand(string type)
        {
            var vmRunCommand = new VirtualMachineRunCommand
            {
                Location = ComputeManagementTestUtilities.DefaultLocation,
                Source = new VirtualMachineRunCommandScriptSource("Write-Host Hello World!"),
                Parameters = new List<RunCommandInputParameter>()
                {
                    new RunCommandInputParameter("param1", "value1"),
                    new RunCommandInputParameter("param2", "value2")
                },
                ProtectedParameters = new List<RunCommandInputParameter>()
                {
                    new RunCommandInputParameter("secret", "protectedSecret"),
                },
                TimeoutInSeconds = 3600,
                AsyncExecution = false,
                Tags = new Dictionary<string, string>() { { "Tag1", "1" } },
            };
            typeof(Resource).GetRuntimeProperty("Name").SetValue(vmRunCommand, "firstRunCommand");
            typeof(Resource).GetRuntimeProperty("Type").SetValue(vmRunCommand, type);

            return vmRunCommand;
        }

        internal static VirtualMachineRunCommandUpdate GetTestVMUpdateRunCommand()
        {
            var vmRunCommandUpdate = new VirtualMachineRunCommandUpdate
            {
                Source = new VirtualMachineRunCommandScriptSource("Write-Host Update Hello World!"),
            };

            return vmRunCommandUpdate;
        }

        internal static void ValidateVMRunCommand(VirtualMachineRunCommand vmRunCommandExpected, VirtualMachineRunCommand vmRunCommandReturned)
        {
            Assert.True(!string.IsNullOrEmpty(vmRunCommandReturned.ProvisioningState));
            Assert.True(!string.IsNullOrEmpty(vmRunCommandReturned.Id));
            Assert.Equal(vmRunCommandExpected.ErrorBlobUri, vmRunCommandReturned.ErrorBlobUri);
            Assert.Equal(vmRunCommandExpected.OutputBlobUri, vmRunCommandReturned.OutputBlobUri);
            Assert.Equal(vmRunCommandExpected.Source?.Script, vmRunCommandReturned.Source?.Script);
            Assert.Equal(vmRunCommandExpected.Source?.ScriptUri, vmRunCommandReturned.Source?.ScriptUri);
            Assert.Equal(vmRunCommandExpected.Source?.CommandId, vmRunCommandReturned.Source?.CommandId);
            Assert.Equal(vmRunCommandExpected.Type, vmRunCommandReturned.Type);
            Assert.Equal(vmRunCommandExpected.Name, vmRunCommandReturned.Name);
            Assert.Equal(vmRunCommandExpected.AsyncExecution, vmRunCommandReturned.AsyncExecution);
            Assert.Equal(vmRunCommandExpected.RunAsUser, vmRunCommandReturned.RunAsUser);
            Assert.Equal(vmRunCommandExpected.TimeoutInSeconds, vmRunCommandReturned.TimeoutInSeconds);
            Assert.Equal(vmRunCommandExpected.RunAsUser, vmRunCommandReturned.RunAsUser);
            Assert.Equal(vmRunCommandExpected.RunAsUser, vmRunCommandReturned.RunAsUser);
            Assert.Equal(vmRunCommandExpected.RunAsUser, vmRunCommandReturned.RunAsUser);
            Assert.True(vmRunCommandExpected.Tags.SequenceEqual(vmRunCommandReturned.Tags));
            if (vmRunCommandExpected.Parameters != null)
            {
                Assert.NotNull(vmRunCommandReturned.Parameters);
                Assert.Equal(vmRunCommandExpected.Parameters.Count, vmRunCommandReturned.Parameters.Count);
                for (int i = 0; i < vmRunCommandExpected.Parameters.Count(); i++)
                {
                    Assert.Equal(vmRunCommandExpected.Parameters[i].Name, vmRunCommandReturned.Parameters[i].Name);
                    Assert.Equal(vmRunCommandExpected.Parameters[i].Value, vmRunCommandReturned.Parameters[i].Value);
                }
            }
        }

        internal static void ValidateVMRunCommandInstanceView(VirtualMachineRunCommandInstanceView vmRunCommandInstanceView)
        {
            Assert.NotNull(vmRunCommandInstanceView);
            Assert.NotNull(vmRunCommandInstanceView.StartTime);
            Assert.NotNull(vmRunCommandInstanceView.EndTime);
            Assert.NotNull(vmRunCommandInstanceView.Output);
            Assert.Equal(ExecutionState.Succeeded, vmRunCommandInstanceView.ExecutionState);
            Assert.Equal("Hello World!", vmRunCommandInstanceView.Output);
        }
    }
}
