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
    public class MigrationAvsAssessmentTests : MigrationAssessmentManagementTestBase
    {
        public MigrationAvsAssessmentTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAvsAssessmentOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("venkatjakka-rvtools");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("anfboliden-prod45e2project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            var collection = await assessmentProjectResource.GetMigrationAssessmentGroupAsync("testgroup");

            var assessmentCollection = collection.Value.GetMigrationAvsAssessments();

            // Create AVS Assessment
            string assessmentName = "avs-asm0";
            MigrationAvsAssessmentData asmData = new MigrationAvsAssessmentData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                FailuresToTolerateAndRaidLevel = FttAndRaidLevel.Ftt1Raid5,
                VcpuOversubscription = 4,
                NodeType = AssessmentAvsNodeType.Av36,
                ReservedInstance = AssessmentReservedInstance.None,
                MemOvercommit = 1.5,
                DedupeCompression = 1.5,
                IsStretchClusterEnabled = false,
                AzureLocation = AzureLocation.BrazilSouth,
                AzureOfferCode = AssessmentOfferCode.MSAZR0003P,
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
            var assessedMachines = await assessmentResource.GetMigrationAvsAssessedMachines().ToEnumerableAsync();
            Assert.IsNotNull(assessedMachines);
            Assert.GreaterOrEqual(assessedMachines.Count, 1);

            // Get an Assessed Machine
            var assessedMachine = await assessmentResource.GetMigrationAvsAssessedMachineAsync(assessedMachines.First().Data.Name);
            Assert.IsNotNull(assessedMachine);

            // Delete Assessment
            await assessmentResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAvsAssessmentOptionsOperations()
        {
            string assessmentOptionsName = "default";
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("venkatjakka-rvtools");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("anf-boliden1307project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);
            MigrationAvsAssessmentOptionCollection collection = assessmentProjectResource.GetMigrationAvsAssessmentOptions();

            // Get Assessment Options
            var assessmentOptionResponse = await collection.GetAsync(assessmentOptionsName);
            var assessmentOptionsResource = assessmentOptionResponse.Value;
            Assert.IsNotNull(assessmentOptionsResource);
            Assert.AreEqual(assessmentOptionsResource.Data.Name, assessmentOptionsName);

            // Get All Assessment Options
            var allAssessmentOptions = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allAssessmentOptions);
            Assert.GreaterOrEqual(allAssessmentOptions.Count, 1);
        }
    }
}
