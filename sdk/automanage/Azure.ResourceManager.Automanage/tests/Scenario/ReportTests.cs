// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ReportTests : AutomanageTestBase
    {
        public ReportTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetAssignmentReports()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");
            string vmName = "sdk-test-vm";

            // act
            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create VM from existing ARM template
            var vmId = await CreateVirtualMachineFromTemplate(vmName, rg);

            // create assignment between custom profile and VM
            var assignment = await CreateAssignment(vmId, profile.Id);

            // get reports
            var reports = assignment.GetAutomanageVmConfigurationProfileAssignmentReports();

            // assert
            await foreach (var report in reports)
            {
                var reportData = report.Data;
                Assert.IsNotNull(reportData);
                Assert.IsNotNull(reportData.Name);
                Assert.AreEqual(profileName, reportData.ConfigurationProfile);
                Assert.IsNotNull(reportData.Id);
            }
        }
    }
}
