// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineExtensionTests
    {
        [Fact]
        public void CanResetPasswordUsingVMAccessExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();
                var vm = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIpAddressDynamic()
                    .WithoutPrimaryPublicIpAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_14_04_LTS)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("BaR@12abc!")
                    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                    .Create();

                var availableSizes = vm.AvailableSizes();

                vm.Update()
                    .DefineNewExtension("VMAccessForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("VMAccessForLinux")
                        .WithVersion("1.4")
                        .WithProtectedSetting("username", "Foo12")
                        .WithProtectedSetting("password", "B12a6@12xyz!")
                        .WithProtectedSetting("reset_ssh", "true")
                    .Attach()
                    .Apply();

                Assert.True(vm.Extensions.Count() > 0);
                Assert.True(vm.Extensions.ContainsKey("VMAccessForLinux"));

                vm.Update()
                        .UpdateExtension("VMAccessForLinux")
                            .WithProtectedSetting("username", "Foo12")
                            .WithProtectedSetting("password", "muy!234OR")
                            .WithProtectedSetting("reset_ssh", "true")
                        .Parent()
                        .Apply();
            }
        }

        [Fact]
        public void CanInstallUninstallCustomExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                string mySqlInstallScript = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/4397e808d07df60ff3cdfd1ae40999f0130eb1b3/mysql-standalone-server-ubuntu/scripts/install_mysql_server_5.6.sh";
                string installCommand = "bash install_mysql_server_5.6.sh Abc.123x(";
                List<string> fileUris = new List<string>()
            {
                mySqlInstallScript
            };

                var azure = TestHelper.CreateRollupClient();
                // Create Linux VM with a custom extension to install MySQL
                //
                var vm = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(location)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithoutPrimaryPublicIpAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_14_04_LTS)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("BaR@12abc!")
                        .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                        .DefineNewExtension("CustomScriptForLinux")
                            .WithPublisher("Microsoft.OSTCExtensions")
                            .WithType("CustomScriptForLinux")
                            .WithVersion("1.4")
                            .WithMinorVersionAutoUpgrade()
                            .WithPublicSetting("fileUris", fileUris)
                            .WithPublicSetting("commandToExecute", installCommand)
                        .Attach()
                        .Create();

                Assert.True(vm.Extensions.Count > 0);
                Assert.True(vm.Extensions.ContainsKey("CustomScriptForLinux"));
                IVirtualMachineExtension customScriptExtension;
                Assert.True(vm.Extensions.TryGetValue("CustomScriptForLinux", out customScriptExtension));
                Assert.Equal(customScriptExtension.PublisherName, "Microsoft.OSTCExtensions");
                Assert.Equal(customScriptExtension.TypeName, "CustomScriptForLinux");
                Assert.Equal(customScriptExtension.AutoUpgradeMinorVersionEnabled, true);

                // Remove the custom extension
                //
                vm.Update()
                        .WithoutExtension("CustomScriptForLinux")
                        .Apply();

                Assert.True(vm.Extensions.Count() == 0);
            }
        }

        [Fact]
        public void CanHandleExtensionReference()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                // Create a Linux VM
                //
                var vm = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIpAddressDynamic()
                    .WithoutPrimaryPublicIpAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_14_04_LTS)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("BaR@12abc!")
                    .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                    .DefineNewExtension("VMAccessForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("VMAccessForLinux")
                        .WithVersion("1.4")
                        .WithProtectedSetting("username", "Foo12")
                        .WithProtectedSetting("password", "B12a6@12xyz!")
                        .WithProtectedSetting("reset_ssh", "true")
                    .Attach()
                    .Create();

                Assert.True(vm.Extensions.Count() > 0);

                // Get the created virtual machine via VM List not by VM GET
                var virtualMachines = azure.VirtualMachines
                    .ListByGroup(rgName);
                IVirtualMachine vmWithExtensionReference = null;
                foreach (var virtualMachine in virtualMachines)
                {
                    if (virtualMachine.Name.Equals(vmName, StringComparison.OrdinalIgnoreCase))
                    {
                        vmWithExtensionReference = virtualMachine;
                        break;
                    }
                }
                // The VM retrieved from the list will contain extensions as reference (i.e. with only id)
                Assert.NotNull(vmWithExtensionReference);

                // Update the extension
                var vmWithExtensionUpdated = vmWithExtensionReference.Update()
                    .UpdateExtension("VMAccessForLinux")
                    .WithProtectedSetting("username", "Foo12")
                    .WithProtectedSetting("password", "muy!234OR")
                    .WithProtectedSetting("reset_ssh", "true")
                    .Parent()
                    .Apply();

                // Again getting VM with extension reference
                virtualMachines = azure.VirtualMachines
                    .ListByGroup(rgName);
                vmWithExtensionReference = null;
                foreach (var virtualMachine in virtualMachines)
                {
                    vmWithExtensionReference = virtualMachine;
                }

                Assert.NotNull(vmWithExtensionReference);

                IVirtualMachineExtension accessExtension = null;
                foreach (var extension in vmWithExtensionReference.Extensions.Values)
                {
                    if (extension.Name.Equals("VMAccessForLinux", StringComparison.OrdinalIgnoreCase))
                    {
                        accessExtension = extension;
                        break;
                    }
                }

                // Even though VM's inner contain just extension reference VirtualMachine::extensions()
                // should resolve the reference and get full extension.
                Assert.NotNull(accessExtension);
                Assert.NotNull(accessExtension.PublisherName);
                Assert.NotNull(accessExtension.TypeName);
                Assert.NotNull(accessExtension.VersionName);
            }
        }
    }
}
