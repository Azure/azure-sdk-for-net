// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineTests
    {
        private readonly string RG_NAME = ResourceNamer.RandomResourceName("rgfluentchash-", 20);
        private const string LOCATION = "southcentralus";
        private const string VMNAME = "chashvm";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCreateVirtualMachine()
        {
            IComputeManager computeManager = TestHelper.CreateComputeManager();
            IResourceManager resourceManager = TestHelper.CreateResourceManager();

            try
            {
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

                IVirtualMachine foundedVM = computeManager.VirtualMachines.ListByGroup(RG_NAME)
                    .FirstOrDefault(v => v.Name.Equals(VMNAME, StringComparison.OrdinalIgnoreCase));

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

                // Capture the VM [Requires VM to be Poweroff and generalized]
                foundedVM.PowerOff();
                foundedVM.Generalize();
                string jsonResult = foundedVM.Capture("capturedVhds", true);
                Assert.NotNull(jsonResult);

                // Delete VM
                computeManager.VirtualMachines.DeleteById(foundedVM.Id);
            } finally {
                resourceManager.ResourceGroups.DeleteByName(RG_NAME);
            }
        }
    }
}