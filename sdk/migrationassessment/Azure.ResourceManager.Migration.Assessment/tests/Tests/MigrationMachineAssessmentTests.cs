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

        [TestCase]
        [RecordedTest]
        public async Task TestMachineOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sdktest-net");

            var response =
                await rg.GetMigrationAssessmentAssessmentProjectAsync("sdktestproject");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            var machineCollection = assessmentProjectResource.GetMigrationAssessmentMachines();

            // Get All Machines
            var allMachines = await machineCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allMachines);
            Assert.GreaterOrEqual(allMachines.Count, 1);

            // Get Machine
            var machineResponse = await machineCollection.GetAsync(allMachines.First().Data.Name);
            var machineResource = machineResponse.Value;
            Assert.IsNotNull(machineResource);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAssessmentOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("sdktest-net");

            var response =
                await rg.GetMigrationAssessmentAssessmentProjectAsync("sdktestproject");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            var collection = await assessmentProjectResource.GetMigrationAssessmentGroupAsync("sdktestgroup");

            var assessmentCollection = collection.Value.GetMigrationAssessmentAssessments();

            // Create Assessment
            string assessmentName = "asm1";
            MigrationAssessmentAssessmentData asmData = new MigrationAssessmentAssessmentData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                EASubscriptionId = null,
                AzurePricingTier = AzurePricingTier.Standard,
                AzureStorageRedundancy = AzureStorageRedundancy.Unknown,
                ReservedInstance = AzureReservedInstance.None,
                AzureHybridUseBenefit = AzureHybridUseBenefit.Unknown,
                AzureDiskTypes =
                    {
                    AzureDiskType.Premium,AzureDiskType.StandardSsd
                    },
                AzureVmFamilies =
                    {
                    AzureVmFamily.DSeries,AzureVmFamily.Lsv2Series,AzureVmFamily.MSeries,AzureVmFamily.Mdsv2Series,AzureVmFamily.Msv2Series,AzureVmFamily.Mv2Series
                    },
                VmUptime = new VmUptime()
                {
                    DaysPerMonth = 13,
                    HoursPerDay = 26,
                },
                AzureLocation = AzureLocation.BrazilSouth,
                AzureOfferCode = AzureOfferCode.SavingsPlan1Year,
                Currency = AzureCurrency.USD,
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
            Assert.IsTrue(assessmentResponse.HasCompleted);
            Assert.IsNotNull(assessmentResource);
            Assert.AreEqual(assessmentResource.Data.Name, assessmentName);

            // Get Assessment
            assessmentResource = await assessmentCollection.GetAsync(assessmentName);
            Assert.IsNotNull(assessmentResource);
            Assert.AreEqual(assessmentResource.Data.Name, assessmentName);

            // Get All Assessments
            var allAssessments = await assessmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allAssessments);
            Assert.GreaterOrEqual(allAssessments.Count, 1);

            // Download Assessment Report
            BinaryData body = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
            });
            var downloadReportResponse = await assessmentResource.DownloadUrlAsync(WaitUntil.Completed, body);
            Assert.IsNotNull(downloadReportResponse.Value.AssessmentReportUri);

            // Get Assessed Machines
            var assessedMachines = await assessmentResource.GetAssessedMachines().ToEnumerableAsync();
            Assert.IsNotNull(assessedMachines);
            Assert.GreaterOrEqual(assessedMachines.Count, 1);

            // Get an Assessed Machine
            var assessedMachine = await assessmentResource.GetAssessedMachineAsync(assessedMachines.First().Data.Name);
            Assert.IsNotNull(assessedMachine);

            // Delete Assessment
            await assessmentResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
