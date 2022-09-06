// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileAssignmentTests : AutomanageTestBase
    {
        public ConfigurationProfileAssignmentTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetAssigment()
        {
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between best practices profile and VM
            string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var result = await CreateAssignment(vm, profileId);

            // fetch assignment
            var assignment = await ArmClient.GetConfigurationProfileAssignmentAsync(vm.Id, "default");

            // assert
            Assert.True(assignment.Value.HasData);
            Assert.NotNull(assignment.Value.Data.Name);
            Assert.NotNull(assignment.Value.Data.Id);
            Assert.AreEqual(vm.Id, assignment.Value.Data.Properties.TargetId);
        }

        [TestCase]
        public async Task CanCreateBestPracticesProductionProfileAssignment()
        {
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between best practices profile and VM
            string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var assignment = CreateAssignment(vm, profileId).Result;

            // assert
            Assert.True(assignment.HasData);
            Assert.NotNull(assignment.Data.Name);
            Assert.NotNull(assignment.Data.Id);
        }

        [TestCase]
        public async Task CanCreateCustomProfileAssignment()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var profileCollection = rg.GetConfigurationProfiles();

            // create configuration profile
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between custom profile and VM
            var assignment = CreateAssignment(vm, profile.Id).Result;

            // assert
            Assert.True(assignment.HasData);
            Assert.NotNull(assignment.Data.Name);
            Assert.NotNull(assignment.Data.Id);
        }
    }
}
