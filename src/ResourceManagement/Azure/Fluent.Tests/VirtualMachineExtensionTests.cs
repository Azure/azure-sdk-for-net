using Fluent.Tests;
using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class VirtualMachineExtensionTests
    {
        [Fact]
        public void canResetPasswordUsingVMAccessExtension()
        {
            string rgName = ResourceNamer.RandomResourceName("vmexttest", 15);
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
                .WithRootUserName("Foo12")
                .WithPassword("BaR@12abc!")
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
}
