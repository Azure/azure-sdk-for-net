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
            var vmId = await CreateVirtualMachineFromTemplate(vmName, rg);

            // create assignment between best practices profile and VM
            string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var result = await CreateAssignment(vmId, profileId);

            // fetch assignment
            var assignment = await ArmClient.GetAutomanageVmConfigurationProfileAssignmentAsync(vmId, "default");

            Assert.Multiple(() =>
            {
                // assert
                Assert.That(assignment.Value.HasData, Is.True);
                Assert.That(assignment.Value.Data.Name, Is.Not.Null);
                Assert.That(assignment.Value.Data.Id, Is.Not.Null);
                Assert.That(assignment.Value.Data.Properties.TargetId, Is.EqualTo(vmId));
            });
        }

        [TestCase]
        public async Task CanCreateBestPracticesProductionProfileAssignment()
        {
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create VM from existing ARM template
            var vmId = await CreateVirtualMachineFromTemplate(vmName, rg);

            // create assignment between best practices profile and VM
            string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";
            var assignment = await CreateAssignment(vmId, profileId);

            Assert.Multiple(() =>
            {
                // assert
                Assert.That(assignment.HasData, Is.True);
                Assert.That(assignment.Data.Name, Is.Not.Null);
                Assert.That(assignment.Data.Id, Is.Not.Null);
            });
        }

        [TestCase]
        public async Task CanCreateCustomProfileAssignment()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var profileCollection = rg.GetAutomanageConfigurationProfiles();

            // create configuration profile
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create VM from existing ARM template
            var vmId = await CreateVirtualMachineFromTemplate(vmName, rg);

            // create assignment between custom profile and VM
            var assignment = await CreateAssignment(vmId, profile.Id);

            Assert.Multiple(() =>
            {
                // assert
                Assert.That(assignment.HasData, Is.True);
                Assert.That(assignment.Data.Name, Is.Not.Null);
                Assert.That(assignment.Data.Id, Is.Not.Null);
            });
        }
    }
}
