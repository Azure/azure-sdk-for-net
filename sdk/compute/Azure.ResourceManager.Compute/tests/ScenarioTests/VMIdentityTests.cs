// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMIdentityTests : VMTestBase
    {
        public VMIdentityTests(bool isAsync)
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestVMIdentitySystemAssignedUserAssigned()
        {
            EnsureClientsInitialized(DefaultLocation);
            // Prerequisite: in order to record this test, first create a user identity in resource group 'identitytest' and set the value of identity here.
            const string rgName = "identitytest";
            const string identity = "/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/resourcegroups/identitytest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/userid";

            ImageReference imgageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            bool passed = false;
            try
            {
                var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

                Action<VirtualMachine> addUserIdentity = vm =>
                {
                    vm.Identity = new VirtualMachineIdentity();
                    vm.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
                    vm.Identity.UserAssignedIdentities.Add(identity, new Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties());
                };

                var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imgageRef , addUserIdentity);
                VirtualMachine vmResult = returnTwoVM.Item1;
                inputVM = returnTwoVM.Item2;
                Assert.AreEqual(ResourceIdentityType.SystemAssignedUserAssigned, vmResult.Identity.Type);
                Assert.NotNull(vmResult.Identity.PrincipalId);
                Assert.NotNull(vmResult.Identity.TenantId);
                Assert.True(vmResult.Identity.UserAssignedIdentities.Keys.Contains(identity));
                Assert.NotNull(vmResult.Identity.UserAssignedIdentities[identity].PrincipalId);
                Assert.NotNull(vmResult.Identity.UserAssignedIdentities[identity].ClientId);

                var getVM = (await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name)).Value;
                Assert.AreEqual(ResourceIdentityType.SystemAssignedUserAssigned, getVM.Identity.Type);
                Assert.NotNull(getVM.Identity.PrincipalId);
                Assert.NotNull(getVM.Identity.TenantId);
                Assert.True(getVM.Identity.UserAssignedIdentities.Keys.Contains(identity));
                Assert.NotNull(getVM.Identity.UserAssignedIdentities[identity].PrincipalId);
                Assert.NotNull(getVM.Identity.UserAssignedIdentities[identity].ClientId);

                await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
                passed = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Assert.True(passed);
            }
        }
    }
}
