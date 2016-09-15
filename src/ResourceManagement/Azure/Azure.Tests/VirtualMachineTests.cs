using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Resource;
using Xunit;

namespace Azure.Tests
{
    public class VirtualMachineTests
    {
        private const string RG_NAME = "javacsmrg";
        private const string LOCATION = "southcentralus";
        private const string VMNAME = "javavm3";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCreateVirtualMachine()
        {
            IComputeManager computeManager = TestHelper.CreateComputeManager();
            IResourceManager resourceManager = TestHelper.CreateResourceManager();

            // Create
            IVirtualMachine vm = computeManager.VirtualMachines
                .Define(VMNAME)
                .WithRegion(LOCATION)
                .WithNewResourceGroup(RG_NAME)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIpAddressDynamic()
                .WithoutPrimaryPublicIpAddress()
                .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_DATACENTER)
                .WithAdminUserName("Foo12")
                .WithPassword("BaR@12!Foo")
                .WithSize(VirtualMachineSizeTypes.StandardD3)
                .WithOsDiskCaching(CachingTypes.ReadWrite)
                .WithOsDiskName("javatest")
                .Create();

            IVirtualMachine foundedVM = null;
            var vms = computeManager.VirtualMachines.ListByGroup(RG_NAME);
            foreach (IVirtualMachine vm1 in vms)
            {
                if (vm1.Name.Equals(VMNAME))
                {
                    foundedVM = vm1;
                    break;
                }
            }

            Assert.NotNull(foundedVM);
            Assert.Equal(LOCATION, foundedVM.RegionName);
            // Get
            foundedVM = computeManager.VirtualMachines.GetByGroup(RG_NAME, VMNAME);
            Assert.NotNull(foundedVM);
            Assert.Equal(LOCATION, foundedVM.RegionName);

            // Fetch instance view
            PowerState? powerState = foundedVM.PowerState;
            Assert.True(powerState == PowerState.RUNNING);
            VirtualMachineInstanceView instanceView = foundedVM.InstanceView;
            Assert.NotNull(instanceView);
            Assert.NotNull(instanceView.Statuses.Count > 0);

            // Delete VM
            computeManager.VirtualMachines.Delete(foundedVM.Id);
            resourceManager.ResourceGroups.Delete(RG_NAME);
        }
    }
}