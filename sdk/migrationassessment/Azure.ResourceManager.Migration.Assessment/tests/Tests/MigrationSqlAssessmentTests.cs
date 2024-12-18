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

        [TestCase]
        [RecordedTest]
        public async Task TestSqlAssessmentOperations()
        {
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("dhlodhiCCY");

            var response =
                await rg.GetMigrationAssessmentAssessmentProjectAsync("sql-ecy-05197632project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);

            var collection = await assessmentProjectResource.GetMigrationAssessmentGroupAsync("suyashtest");

            var assessmentCollection = collection.Value.GetMigrationAssessmentSqlAssessmentV2s();

            // Create Sql Assessment
            string assessmentName = "Sql-asm0";
            MigrationAssessmentSqlAssessmentV2Data asmData = new MigrationAssessmentSqlAssessmentV2Data()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                OSLicense = MigrationAssessmentOSLicense.Unknown,
                EnvironmentType = AssessmentEnvironmentType.Production,
                OptimizationLogic = SqlOptimizationLogic.MinimizeCost,
                ReservedInstanceForVm = AzureReservedInstance.None,
                GroupType = MigrationAssessmentGroupType.Default,
                AssessmentType = AssessmentType.SqlAssessment,
                SqlServerLicense = SqlServerLicense.Unknown,
                ReservedInstance = AzureReservedInstance.None,
                AzureSecurityOfferingType = AzureSecurityOfferingType.NO,
                EnableHadrAssessment = false,
                IsInternetAccessAvailable = true,
                AzureSqlVmSettings = new SqlVmSettings()
                {
                    InstanceSeries = new List<AzureVmFamily>()
                    {
                        AzureVmFamily.MSeries
                    }
                },
                MultiSubnetIntent = MultiSubnetIntent.None,
                AsyncCommitModeIntent = AsyncCommitModeIntent.None,
                AzureSqlDatabaseSettings = new SqlDBSettings()
                {
                    AzureSqlComputeTier = MigrationAssessmentComputeTier.Automatic,
                    AzureSqlDataBaseType = AzureSqlDataBaseType.Automatic,
                    AzureSqlServiceTier = AzureSqlServiceTier.Automatic,
                    AzureSqlPurchaseModel = AzureSqlPurchaseModel.VCore,
                },
                AzureSqlManagedInstanceSettings = new SqlMISettings()
                {
                    AzureSqlInstanceType = AzureSqlInstanceType.Automatic,
                    AzureSqlServiceTier = AzureSqlServiceTier.Automatic
                },
                Currency = AzureCurrency.USD,
                AzureLocation = AzureLocation.SouthCentralUS,
                AzureOfferCode = AzureOfferCode.MSAZR0023P,
                AzureOfferCodeForVm = AzureOfferCode.MSAZR0023P,
                ScalingFactor = 2,
                Percentile = PercentileOfUtilization.Percentile50,
                TimeRange = AssessmentTimeRange.Month,
                PerfDataStartOn = DateTimeOffset.Parse("2024-09-26T09:36:48.491Z"),
                PerfDataEndOn = DateTimeOffset.Parse("2024-10-26T09:36:48.491Z"),
                DiscountPercentage = 10,
                SizingCriterion = AssessmentSizingCriterion.PerformanceBased
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

            // add wait period of 10 mins
            await Task.Delay(360000);

            // Download Assessment Report
            BinaryData body = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
            });
            var downloadReportResponse = await assessmentResource.DownloadUrlAsync(WaitUntil.Completed, body);
            Assert.IsNotNull(downloadReportResponse.Value.AssessmentReportUri);

            // Get Assessed Machines
            var assessedMachines = await assessmentResource.GetAssessedSqlMachines().ToEnumerableAsync();
            Assert.IsNotNull(assessedMachines);
            Assert.GreaterOrEqual(assessedMachines.Count, 1);

            // Get an Assessed Machine
            var assessedMachine = await assessmentResource.GetAssessedSqlMachineAsync(assessedMachines.First().Data.Name);
            Assert.IsNotNull(assessedMachine);

            // Get Assessed DBs
            var assessedDBs = await assessmentResource.GetAssessedSqlDatabaseV2s().ToEnumerableAsync();
            Assert.IsNotNull(assessedDBs);
            Assert.GreaterOrEqual(assessedDBs.Count, 1);

            // Get an Assessed DB
            var assessedDB = await assessmentResource.GetAssessedSqlDatabaseV2Async(assessedDBs.First().Data.Name);
            Assert.IsNotNull(assessedDB);

            // Get Assessed Instances
            var assessedInstances = await assessmentResource.GetAssessedSqlInstanceV2s().ToEnumerableAsync();
            Assert.IsNotNull(assessedInstances);
            Assert.GreaterOrEqual(assessedInstances.Count, 1);

            // Get an Assessed Machine
            var assessedInstance = await assessmentResource.GetAssessedSqlInstanceV2Async(assessedInstances.First().Data.Name);
            Assert.IsNotNull(assessedInstance);

            // Get Assessed Machines
            var recommendedEntities = await assessmentResource.GetAssessedSqlRecommendedEntities().ToEnumerableAsync();
            Assert.IsNotNull(recommendedEntities);
            Assert.GreaterOrEqual(recommendedEntities.Count, 1);

            // Get an Assessed Machine
            var recommendedEntity = await assessmentResource.GetAssessedSqlRecommendedEntityAsync(recommendedEntities.First().Data.Name);
            Assert.IsNotNull(recommendedEntity);

            // Get Assessment Summary
            var assessmentSummary = await assessmentResource.GetMigrationAssessmentSqlAssessmentV2SummaryAsync("default");
            Assert.IsNotNull(assessmentSummary);

            // Delete Assessment
            await assessmentResource.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSqlAssessmentOptionsOperations()
        {
            string assessmentOptionsName = "default";
            AzureLocation targetRegion = AzureLocation.BrazilSouth;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await DefaultSubscription.GetResourceGroups().GetAsync("dhlodhiCCY");

            var response =
                await rg.GetMigrationAssessmentAssessmentProjectAsync("sql-ecy-05197632project");
            var assessmentProjectResource = response.Value;
            Assert.IsNotNull(assessmentProjectResource);
            MigrationAssessmentSqlAssessmentOptionCollection collection = assessmentProjectResource.GetMigrationAssessmentSqlAssessmentOptions();

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
