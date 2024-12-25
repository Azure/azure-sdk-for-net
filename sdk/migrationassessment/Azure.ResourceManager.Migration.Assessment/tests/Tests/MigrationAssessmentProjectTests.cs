// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Migration.Assessment.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Tests
{
    public class MigrationAssessmentProjectTests : MigrationAssessmentManagementTestBase
    {
        private static AzureLocation targetRegion;
        private static string targetSubscriptionId;
        private static ResourceGroupResource rg;
        private static MigrationAssessmentAssessmentProjectResource assessmentProjectResource;

        public MigrationAssessmentProjectTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            targetRegion = AzureLocation.BrazilSouth;
            targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            rg = await CreateResourceGroup(
                DefaultSubscription,
                "SdkTest-Net-",
                targetRegion);

            string assessmentProjName = Recording.GenerateAssetName("assessmentProj-");

            var assessmentProjectData = new MigrationAssessmentAssessmentProjectData(targetRegion);
            var assessmentProjectCollection = rg.GetMigrationAssessmentAssessmentProjects();

            // Create Assessment Project
            var response =
                await assessmentProjectCollection.CreateOrUpdateAsync(WaitUntil.Completed, assessmentProjName, assessmentProjectData);
            await response.WaitForCompletionAsync();
            assessmentProjectResource = response.Value;
            Assert.IsTrue(response.HasCompleted);
            Assert.IsNotNull(assessmentProjectResource);
        }

        [TearDown]
        public async Task Cleanup()
        {
            if (rg != null)
            {
                await rg.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAssessmentProjectOperations()
        {
            string rgName = rg.Id.Name;
            var assessmentProjectCollection = rg.GetMigrationAssessmentAssessmentProjects();

            string assessmentProjName = assessmentProjectResource.Data.Name;

            // Get Assessment Project
            assessmentProjectResource = await assessmentProjectCollection.GetAsync(assessmentProjName);
            Assert.AreEqual(MigrationAssessmentProvisioningState.Succeeded, assessmentProjectResource.Data.ProvisioningState);
            Assert.IsNotNull(assessmentProjectResource.Id);

            // Update Assessment Project
            var assessmentProjectPatch = new MigrationAssessmentAssessmentProjectPatch();
            assessmentProjectPatch.Tags.Add("Key1", "TestPatchValue");
            var response = await assessmentProjectResource.UpdateAsync(WaitUntil.Completed, assessmentProjectPatch);
            assessmentProjectResource = response.Value;
            string assessmentProjectTagValue = string.Empty;
            Assert.IsTrue(assessmentProjectResource.Data.Tags.TryGetValue("Key1", out assessmentProjectTagValue));
            Assert.AreEqual(assessmentProjectTagValue, "TestPatchValue");

            // Delete Assessment Project
            await assessmentProjectResource.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAssessmentProjectSummaryOperations()
        {
            var collection = assessmentProjectResource.GetMigrationAssessmentAssessmentProjectSummaries();

            // Get Assessment Project Summary
            var assessmentProjectSummaryResource = await collection.GetAsync("default");
            Assert.IsNotNull(assessmentProjectSummaryResource);

            // Get All Assessment Project Summaries
            var allAssessmentProjectSummaries = collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allAssessmentProjectSummaries);
            Assert.GreaterOrEqual(allAssessmentProjectSummaries.Result.Count, 1);
        }
    }
}
