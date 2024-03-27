// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2020-06-01", "2022-11-01", "2023-07-01", "2023-09-01")]
    public class VirtualMachineManagedIdentityTests : VirtualMachineTestBase
    {
        public VirtualMachineManagedIdentityTests(bool async, string apiVersion)
            : base(async, VirtualMachineResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        private async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testRi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData(DefaultLocation);
            var response = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, userIdentityId, input);
            return response.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateVmWithSystemAssignedIdentity()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(virtualMachine.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.TenantId);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateVmWithUserAssignedIdentity()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateVmWithSystemAndUserAssignedIdentity()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromNoneToSystem()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.Null(virtualMachine.Data.Identity);

            var updateOptions = new VirtualMachinePatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(updatedVM.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromNoneToUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.Null(virtualMachine.Data.Identity);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromNoneToSystemAndUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.Null(virtualMachine.Data.Identity);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemToNone()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(virtualMachine.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.TenantId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.Null(updatedVM.Data.Identity);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemToUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(virtualMachine.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.TenantId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemToSystemUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(virtualMachine.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.TenantId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromUserToNone()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.Null(updatedVM.Data.Identity);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromUserToSystem()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var updateOptions = new VirtualMachinePatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(updatedVM.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromUserToSystemUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromUserToTwoUsers()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            // With JSON Merge Patch, we only need to put the identity to add in the dictionary for update operation.
            var identity2 = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity2.UserAssignedIdentities.Add(userAssignedIdentity2.Id, new UserAssignedIdentity());
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity2
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        [Ignore("Service throws exception validating that None type cannot have user assigned identity even its value is null which means to delete an existing one. Use the operations in UpdateVmIdentityFromUserToNone to achieve the same result.")]
        public async Task UpdateVmIdentityToRemoveUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            // With JSON Merge Patch, we only need to put the identity to add in the dictionary for update operation.
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, null);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.Null(updatedVM.Data.Identity);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromTwoUsersToOneUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity1 = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity1.Id, new UserAssignedIdentity());
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity2.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id].PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId);

            // With JSON Merge Patch, we can use null to delete an identity from the dictionary.
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            identity.UserAssignedIdentities.Add(userAssignedIdentity1.Id, null);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(updatedVM.Data.Identity.PrincipalId);
            Assert.IsFalse(updatedVM.Data.Identity.UserAssignedIdentities.ContainsKey(userAssignedIdentity1.Id));
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemUserToNone()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            var updateOptions = new VirtualMachinePatch()
            {
                Identity = identity
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.Null(updatedVM.Data.Identity);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemUserToSystem()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var updateOptions = new VirtualMachinePatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.IsEmpty(updatedVM.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVmIdentityFromSystemUserToUser()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            input.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, virtualMachine.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(virtualMachine.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(virtualMachine.Data.Identity.PrincipalId);
            Assert.NotNull(virtualMachine.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);

            var updateOptions = new VirtualMachinePatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            lro = await virtualMachine.UpdateAsync(WaitUntil.Completed, updateOptions);
            VirtualMachineResource updatedVM = lro.Value;
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, updatedVM.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(updatedVM.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(updatedVM.Data.Identity.PrincipalId);
            Assert.NotNull(updatedVM.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId);
        }
    }
}
