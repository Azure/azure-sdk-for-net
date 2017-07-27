// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class BootDiagnostics
    {
        [Fact]
        public void CanEnableWithImplicitStorageOnManagedVMCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();
                IVirtualMachine virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithBootDiagnostics()
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
            }
        }

        [Fact]
        public void CanEnableWithCreatableStorageOnManagedVMCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                var storageName = TestUtilities.GenerateName("stgbnc");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                var creatableStorageAccount = azure.StorageAccounts
                    .Define(storageName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName);

                var virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithBootDiagnostics(creatableStorageAccount)
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
                Assert.True(virtualMachine.BootDiagnosticsStorageUri.Contains(storageName));
            }
        }

        [Fact]
        public void CanEnableWithExplicitStorageOnManagedVMCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                var storageName = TestUtilities.GenerateName("stgbnc");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                var storageAccount = azure.StorageAccounts
                    .Define(storageName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .Create();

                IVirtualMachine virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithBootDiagnostics(storageAccount)
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
                Assert.True(virtualMachine.BootDiagnosticsStorageUri.Contains(storageName));
            }
        }

        [Fact]
        public void CanDisable()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();
                var virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithBootDiagnostics()
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);

                virtualMachine.Update()
                    .WithoutBootDiagnostics()
                    .Apply();

                Assert.False(virtualMachine.IsBootDiagnosticsEnabled);
                // Disabling boot diagnostics will not remove the storage uri from the vm payload.
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
            }
        }

        [Fact]
        public void ShouldUseOSUnManagedDiskImplicitStorage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();
                var virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithUnmanagedDisks()   // The implicit storage account for OS disk should be used for boot diagnostics as well
                    .WithBootDiagnostics()
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
                Assert.NotNull(virtualMachine.OSUnmanagedDiskVhdUri);
                Assert.True(virtualMachine.OSUnmanagedDiskVhdUri.ToLower().StartsWith(virtualMachine.BootDiagnosticsStorageUri.ToLower()));
            }
        }

        [Fact]
        public void ShouldUseUnManagedDisksExplicitStorage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                var storageName = TestUtilities.GenerateName("stgbnc");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                var storageAccount = azure.StorageAccounts
                    .Define(storageName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .Create();

                var virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithUnmanagedDisks()
                    .WithBootDiagnostics(storageAccount)  // This storage account must be shared by disk and boot diagnostics
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
                Assert.True(virtualMachine.BootDiagnosticsStorageUri.Contains(storageName));
            }
        }

        [Fact]
        public void CanEnableWithImplicitStorageOnUnManagedVMCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                var virtualMachine1 = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithUnmanagedDisks()
                    .Create();

                var osDiskVhd = virtualMachine1.OSUnmanagedDiskVhdUri;
                Assert.NotNull(osDiskVhd);
                azure.VirtualMachines.DeleteById(virtualMachine1.Id);

                var virtualMachine2 = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithSpecializedOSUnmanagedDisk(osDiskVhd, Microsoft.Azure.Management.Compute.Fluent.Models.OperatingSystemTypes.Linux)
                    .WithBootDiagnostics()  // A new storage account should be created and used
                    .Create();

                Assert.NotNull(virtualMachine2);
                Assert.True(virtualMachine2.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine2.BootDiagnosticsStorageUri);
                Assert.NotNull(virtualMachine2.OSUnmanagedDiskVhdUri);
                Assert.False(virtualMachine2.OSUnmanagedDiskVhdUri.ToLower().StartsWith(virtualMachine2.BootDiagnosticsStorageUri.ToLower()));
            }
        }

        [Fact]
        public void CanEnableWithCreatableStorageOnUnManagedVMCreation()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmbdtest");
                var storageName = TestUtilities.GenerateName("stgbnc");
                string regionName = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                var creatableStorageAccount = azure.StorageAccounts
                    .Define(storageName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName);

                var virtualMachine = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(regionName)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("abc!@#F0orL")
                    .WithUnmanagedDisks()
                    .WithBootDiagnostics(creatableStorageAccount)
                    .Create();

                Assert.NotNull(virtualMachine);
                Assert.True(virtualMachine.IsBootDiagnosticsEnabled);
                Assert.NotNull(virtualMachine.BootDiagnosticsStorageUri);
                Assert.True(virtualMachine.BootDiagnosticsStorageUri.Contains(storageName));
                // There should be a different storage account created for the OS Disk
                Assert.False(virtualMachine.OSUnmanagedDiskVhdUri.ToLower().StartsWith(virtualMachine.BootDiagnosticsStorageUri.ToLower()));
            }
        }
    }
}
