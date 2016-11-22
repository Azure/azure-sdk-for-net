// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using System;
using System.Linq;
using Xunit;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Fluent;
using System.Collections.Generic;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Network.Fluent;

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
            var computeManager = TestHelper.CreateComputeManager();
            var resourceManager = TestHelper.CreateResourceManager();

            try
            {
                // Create
                var vm = computeManager.VirtualMachines
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

                var foundedVM = computeManager.VirtualMachines.ListByGroup(RG_NAME)
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
                var jsonResult = foundedVM.Capture("capturedVhds", true);
                Assert.NotNull(jsonResult);

                // Delete VM
                computeManager.VirtualMachines.DeleteById(foundedVM.Id);
            } finally {
                resourceManager.ResourceGroups.DeleteByName(RG_NAME);
            }
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCreateVirtualMachinesAndRelatedResourcesInParallel()
        {
            var resourceGroupName = ResourceNamer.RandomResourceName("rgvmtest-", 20);
            var vmNamePrefix = "vmz";
            var publicIpNamePrefix = ResourceNamer.RandomResourceName("pip-", 15);
            var networkNamePrefix = ResourceNamer.RandomResourceName("vnet-", 15);

            var region = Region.US_EAST;
            int count = 5;

            var azure = TestHelper.CreateRollupClient();
            try
            {
                var resourceGroupCreatable = azure.ResourceGroups
                .Define(resourceGroupName)
                .WithRegion(region);

                var storageAccountCreatable = azure.StorageAccounts
                    .Define(ResourceNamer.RandomResourceName("stg", 20))
                    .WithRegion(region)
                    .WithNewResourceGroup(resourceGroupCreatable);

                var networkCreatableKeys = new List<string>();
                var publicIpCreatableKeys = new List<string>();
                var virtualMachineCreatables = new List<ICreatable<IVirtualMachine>>();
                for (int i = 0; i < count; i++)
                {
                    var networkCreatable = azure.Networks
                            .Define($"{networkNamePrefix}-{i}")
                            .WithRegion(region)
                            .WithNewResourceGroup(resourceGroupCreatable)
                            .WithAddressSpace("10.0.0.0/28");
                    networkCreatableKeys.Add(networkCreatable.Key);

                    var publicIpAddressCreatable = azure.PublicIpAddresses
                            .Define($"{publicIpNamePrefix}-{i}")
                            .WithRegion(region)
                            .WithNewResourceGroup(resourceGroupCreatable);
                    publicIpCreatableKeys.Add(publicIpAddressCreatable.Key);

                    var virtualMachineCreatable = azure.VirtualMachines
                            .Define($"{vmNamePrefix}-{i}")
                            .WithRegion(region)
                            .WithNewResourceGroup(resourceGroupCreatable)
                            .WithNewPrimaryNetwork(networkCreatable)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(publicIpAddressCreatable)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUserName("tirekicker")
                            .WithPassword("BaR@12!#")
                            .WithNewStorageAccount(storageAccountCreatable);
                    virtualMachineCreatables.Add(virtualMachineCreatable);
                }

                var createdVirtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables.ToArray());
                Assert.True(createdVirtualMachines.Count() == count);

                HashSet<string> virtualMachineNames = new HashSet<string>();
                for (int i = 0; i < count; i++)
                {
                    virtualMachineNames.Add($"{vmNamePrefix}-{i}");
                }

                foreach (var virtualMachine in createdVirtualMachines)
                {
                    Assert.True(virtualMachineNames.Contains(virtualMachine.Name));
                    Assert.NotNull(virtualMachine.Id);
                }

                var networkNames = new HashSet<string>();
                for (int i = 0; i < count; i++)
                {
                    networkNames.Add($"{networkNamePrefix}-{i}");
                }

                foreach (var networkCreatableKey in networkCreatableKeys)
                {
                    var createdNetwork = (INetwork)createdVirtualMachines.CreatedRelatedResource(networkCreatableKey);
                    Assert.NotNull(createdNetwork);
                    Assert.True(networkNames.Contains(createdNetwork.Name));
                }

                HashSet<string> publicIpAddressNames = new HashSet<string>();
                for (int i = 0; i < count; i++)
                {
                    publicIpAddressNames.Add($"{publicIpNamePrefix}-{i}");
                }

                foreach (string publicIpCreatableKey in publicIpCreatableKeys)
                {
                    var createdPublicIpAddress = (IPublicIpAddress)createdVirtualMachines.CreatedRelatedResource(publicIpCreatableKey);
                    Assert.NotNull(createdPublicIpAddress);
                    Assert.True(publicIpAddressNames.Contains(createdPublicIpAddress.Name));
                }
            }
            finally
            {
                azure.ResourceGroups.DeleteByName(resourceGroupName);
            }
        }
    }
}