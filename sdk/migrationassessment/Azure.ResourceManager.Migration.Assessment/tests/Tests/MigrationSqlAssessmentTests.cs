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
    public class MigrationSqlAssessmentTests : MigrationAssessmentManagementTestBase
    {
        public MigrationSqlAssessmentTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestSqlAssessmentOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("dhlodhiCCY");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("sql-ecy-05197632project");
            var assessmentProjectResource = response.Value;
            Assert.That(assessmentProjectResource, Is.Not.Null);

            var collection = await assessmentProjectResource.GetMigrationAssessmentGroupAsync("suyashtest");

            var assessmentCollection = collection.Value.GetMigrationSqlAssessmentV2s();

            // Create Sql Assessment
            string assessmentName = "Sql-asm0";
            MigrationSqlAssessmentV2Data asmData = new MigrationSqlAssessmentV2Data()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                OSLicense = MigrationAssessmentOSLicense.Unknown,
                EnvironmentType = AssessmentEnvironmentType.Production,
                OptimizationLogic = SqlOptimizationLogic.MinimizeCost,
                ReservedInstanceForVm = AssessmentReservedInstance.None,
                GroupType = MigrationAssessmentGroupType.Default,
                AssessmentType = MigrationAssessmentType.SqlAssessment,
                SqlServerLicense = AssessmentSqlServerLicense.Unknown,
                ReservedInstance = AssessmentReservedInstance.None,
                AzureSecurityOfferingType = AssessmentSecurityOfferingType.No,
                IsHadrAssessmentEnabled = false,
                IsInternetAccessAvailable = true,
                AzureSqlVmSettings = new AssessmentSqlVmSettings(),
                MultiSubnetIntent = MultiSubnetIntent.None,
                AsyncCommitModeIntent = AsyncCommitModeIntent.None,
                AzureSqlDatabaseSettings = new AssessmentSqlDBSettings()
                {
                    AzureSqlComputeTier = MigrationAssessmentComputeTier.Automatic,
                    AzureSqlDataBaseType = AssessmentSqlDataBaseType.Automatic,
                    AzureSqlServiceTier = AssessmentSqlServiceTier.Automatic,
                    AzureSqlPurchaseModel = AssessmentSqlPurchaseModel.VCore,
                },
                AzureSqlManagedInstanceSettings = new AssessmentSqlMISettings()
                {
                    AzureSqlInstanceType = AssessmentSqlInstanceType.Automatic,
                    AzureSqlServiceTier = AssessmentSqlServiceTier.Automatic
                },
                Currency = AssessmentCurrency.USD,
                AzureLocation = AzureLocation.SouthCentralUS,
                AzureOfferCode = AssessmentOfferCode.MSAZR0023P,
                AzureOfferCodeForVm = AssessmentOfferCode.MSAZR0023P,
                ScalingFactor = 2,
                Percentile = PercentileOfUtilization.Percentile50,
                TimeRange = AssessmentTimeRange.Month,
                PerfDataStartOn = DateTimeOffset.Parse("2024-09-26T09:36:48.491Z"),
                PerfDataEndOn = DateTimeOffset.Parse("2024-10-26T09:36:48.491Z"),
                DiscountPercentage = 10,
                SizingCriterion = AssessmentSizingCriterion.PerformanceBased
            };
            asmData.AzureSqlVmSettings.InstanceSeries.Add(AssessmentVmFamily.MSeries);

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

            // add wait period of 10 mins
            //await Task.Delay(360000);

            // Download Assessment Report
            BinaryData body = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
            });
            var downloadReportResponse = await assessmentResource.DownloadUrlAsync(WaitUntil.Completed, body);
            Assert.That(downloadReportResponse.Value.AssessmentReportUri, Is.Not.Null);

            // Get Assessed Machines
            var assessedMachines = await assessmentResource.GetMigrationAssessedSqlMachines().ToEnumerableAsync();
            Assert.That(assessedMachines, Is.Not.Null);
            Assert.That(assessedMachines.Count, Is.GreaterThanOrEqualTo(1));

            // Get an Assessed Machine
            var assessedMachine = await assessmentResource.GetMigrationAssessedSqlMachineAsync(assessedMachines.First().Data.Name);
            Assert.That(assessedMachine, Is.Not.Null);

            // Get Assessed DBs
            var assessedDBs = await assessmentResource.GetMigrationAssessedSqlDatabaseV2s().ToEnumerableAsync();
            Assert.That(assessedDBs, Is.Not.Null);
            Assert.That(assessedDBs.Count, Is.GreaterThanOrEqualTo(1));

            // Get an Assessed DB
            var assessedDB = await assessmentResource.GetMigrationAssessedSqlDatabaseV2Async(assessedDBs.First().Data.Name);
            Assert.That(assessedDB, Is.Not.Null);

            // Get Assessed Instances
            var assessedInstances = await assessmentResource.GetMigrationAssessedSqlInstanceV2s().ToEnumerableAsync();
            Assert.That(assessedInstances, Is.Not.Null);
            Assert.That(assessedInstances.Count, Is.GreaterThanOrEqualTo(1));

            // Get an Assessed Machine
            var assessedInstance = await assessmentResource.GetMigrationAssessedSqlInstanceV2Async(assessedInstances.First().Data.Name);
            Assert.That(assessedInstance, Is.Not.Null);

            // Get Assessed Machines
            var recommendedEntities = await assessmentResource.GetMigrationAssessedSqlRecommendedEntities().ToEnumerableAsync();
            Assert.That(recommendedEntities, Is.Not.Null);
            Assert.That(recommendedEntities.Count, Is.GreaterThanOrEqualTo(1));

            // Get an Assessed Machine
            var recommendedEntity = await assessmentResource.GetMigrationAssessedSqlRecommendedEntityAsync(recommendedEntities.First().Data.Name);
            Assert.That(recommendedEntity, Is.Not.Null);

            // Get Assessment Summary
            var assessmentSummary = await assessmentResource.GetMigrationSqlAssessmentV2SummaryAsync("default");
            Assert.That(assessmentSummary, Is.Not.Null);

            // Delete Assessment
            await assessmentResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestSqlAssessmentOptionsOperations()
        {
            string assessmentOptionsName = "default";
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("dhlodhiCCY");

            var response =
                await rg.GetMigrationAssessmentProjectAsync("sql-ecy-05197632project");
            var assessmentProjectResource = response.Value;
            Assert.That(assessmentProjectResource, Is.Not.Null);
            MigrationSqlAssessmentOptionCollection collection = assessmentProjectResource.GetMigrationSqlAssessmentOptions();

            // Get Assessment Options
            var assessmentOptionResponse = await collection.GetAsync(assessmentOptionsName);
            var assessmentOptionsResource = assessmentOptionResponse.Value;
            Assert.That(assessmentOptionsResource, Is.Not.Null);
            Assert.That(assessmentOptionsName, Is.EqualTo(assessmentOptionsResource.Data.Name));

            // Get All Assessment Options
            var allAssessmentOptions = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allAssessmentOptions, Is.Not.Null);
            Assert.That(allAssessmentOptions.Count, Is.GreaterThanOrEqualTo(1));
        }
    }
}
