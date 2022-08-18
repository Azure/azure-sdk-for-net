// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Automanage.Models;
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
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between best practices profiles and VM
            string profileID = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var data = new ConfigurationProfileAssignmentData()
            {
                Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profileID }
            };

            await vm.GetConfigurationProfileAssignments().CreateOrUpdateAsync(WaitUntil.Completed, "default", data);

            // fetch assignment
            var assignment = vm.GetConfigurationProfileAssignmentAsync("default").Result.Value;

            // assert
            Assert.True(assignment.HasData);
            Assert.NotNull(assignment.Data.Name);
            Assert.NotNull(assignment.Data.Id);
            Assert.AreEqual(vm.Id, assignment.Data.Properties.TargetId);
        }

        [TestCase]
        public async Task CanCreateBestPracticesProductionProfileAssignment()
        {
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between best practices profile and VM
            string profileID = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var data = new ConfigurationProfileAssignmentData()
            {
                Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profileID }
            };

            var assignment = vm.GetConfigurationProfileAssignments().CreateOrUpdateAsync(WaitUntil.Completed, "default", data).Result.Value;

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
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var profileCollection = rg.GetConfigurationProfiles();

            // create configuration profile
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create VM from existing ARM template
            var vm = CreateVirtualMachineFromTemplate(vmName, rg).Result;

            // create assignment between custom profile and VM
            var data = new ConfigurationProfileAssignmentData()
            {
                Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profile.Id }
            };

            var assignment = vm.GetConfigurationProfileAssignments().CreateOrUpdateAsync(WaitUntil.Completed, "default", data).Result.Value;

            // assert
            Assert.True(assignment.HasData);
            Assert.NotNull(assignment.Data.Name);
            Assert.NotNull(assignment.Data.Id);
        }
    }
}
