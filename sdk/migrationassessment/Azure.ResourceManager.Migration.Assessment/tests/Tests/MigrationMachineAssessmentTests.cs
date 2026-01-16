// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Migration.Assessment.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Tests
{
    public class MigrationMachineAssessmentTests : MigrationAssessmentManagementTestBase
    {
        public MigrationMachineAssessmentTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestMachineOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sdktest-net");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("sdktestproject");
            var assessmentProjectResource = response.Value;
            Assert.That(assessmentProjectResource, Is.Not.Null);

            var machineCollection = assessmentProjectResource.GetMigrationAssessmentMachines();

            // Get All Machines
            var allMachines = await machineCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allMachines, Is.Not.Null);
            Assert.That(allMachines.Count, Is.GreaterThanOrEqualTo(1));

            // Get Machine
            var machineResponse = await machineCollection.GetAsync(allMachines.First().Data.Name);
            var machineResource = machineResponse.Value;
            Assert.That(machineResource, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAssessmentOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sdktest-net");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("sdktestproject");
            var assessmentProjectResource = response.Value;
            Assert.That(assessmentProjectResource, Is.Not.Null);

            var collection = await assessmentProjectResource.GetMigrationAssessmentGroupAsync("sdktestgroup");

            var assessmentCollection = collection.Value.GetMigrationAssessments();

            // Create Assessment
            string assessmentName = "asm1";
            MigrationAssessmentData asmData = new MigrationAssessmentData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                EASubscriptionId = null,
                AzurePricingTier = AssessmentPricingTier.Standard,
                AzureStorageRedundancy = AssessmentStorageRedundancy.Unknown,
                ReservedInstance = AssessmentReservedInstance.None,
                AzureHybridUseBenefit = AssessmentHybridUseBenefit.Unknown,
                AzureDiskTypes =
                    {
                    AssessmentDiskType.Premium,AssessmentDiskType.StandardSsd
                    },
                AzureVmFamilies =
                    {
                    AssessmentVmFamily.DSeries,AssessmentVmFamily.Lsv2Series,AssessmentVmFamily.MSeries,AssessmentVmFamily.Mdsv2Series,AssessmentVmFamily.Msv2Series,AssessmentVmFamily.Mv2Series
                    },
                VmUptime = new AssessmentVmUptime()
                {
                    DaysPerMonth = 13,
                    HoursPerDay = 26,
                },
                AzureLocation = AzureLocation.BrazilSouth,
                AzureOfferCode = AssessmentOfferCode.SavingsPlan1Year,
                Currency = AssessmentCurrency.USD,
                ScalingFactor = 2,
                Percentile = PercentileOfUtilization.Percentile50,
                TimeRange = AssessmentTimeRange.Month,
                PerfDataStartOn = DateTimeOffset.Parse("2024-09-26T09:36:48.491Z"),
                PerfDataEndOn = DateTimeOffset.Parse("2024-10-26T09:36:48.491Z"),
                DiscountPercentage = 10,
                SizingCriterion = AssessmentSizingCriterion.PerformanceBased,
            };

            var assessmentResponse = await assessmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, assessmentName, asmData);
            var assessmentResource = assessmentResponse.Value;
            Assert.That(assessmentResponse.HasCompleted, Is.True);
            Assert.That(assessmentResource, Is.Not.Null);
            Assert.That(assessmentName, Is.EqualTo(assessmentResource.Data.Name));

            // Get Assessment
            assessmentResource = await assessmentCollection.GetAsync(assessmentName);
            Assert.That(assessmentResource, Is.Not.Null);
            Assert.That(assessmentName, Is.EqualTo(assessmentResource.Data.Name));

            // Get All Assessments
            var allAssessments = await assessmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allAssessments, Is.Not.Null);
            Assert.That(allAssessments.Count, Is.GreaterThanOrEqualTo(1));

            // Download Assessment Report
            BinaryData body = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
            });
            var downloadReportResponse = await assessmentResource.DownloadUrlAsync(WaitUntil.Completed, body);
            Assert.That(downloadReportResponse.Value.AssessmentReportUri, Is.Not.Null);

            // Get Assessed Machines
            var assessedMachines = await assessmentResource.GetMigrationAssessedMachines().ToEnumerableAsync();
            Assert.That(assessedMachines, Is.Not.Null);
            Assert.That(assessedMachines.Count, Is.GreaterThanOrEqualTo(1));

            // Get an Assessed Machine
            var assessedMachine = await assessmentResource.GetMigrationAssessedMachineAsync(assessedMachines.First().Data.Name);
            Assert.That(assessedMachine, Is.Not.Null);

            // Delete Assessment
            await assessmentResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
