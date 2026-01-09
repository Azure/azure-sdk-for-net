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
        private static MigrationAssessmentProjectResource assessmentProjectResource;

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

            var assessmentProjectData = new MigrationAssessmentProjectData(targetRegion);
            var assessmentProjectCollection = rg.GetMigrationAssessmentProjects();

            // Create Assessment Project
            var response =
                await assessmentProjectCollection.CreateOrUpdateAsync(WaitUntil.Completed, assessmentProjName, assessmentProjectData);
            await response.WaitForCompletionAsync();
            assessmentProjectResource = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.HasCompleted, Is.True);
                Assert.That(assessmentProjectResource, Is.Not.Null);
            });
        }

        [TearDown]
        public async Task Cleanup()
        {
            if (rg != null)
            {
                await rg.DeleteAsync(WaitUntil.Completed);
            }
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAssessmentProjectOperations()
        {
            string rgName = rg.Id.Name;
            var assessmentProjectCollection = rg.GetMigrationAssessmentProjects();

            string assessmentProjName = assessmentProjectResource.Data.Name;

            // Get Assessment Project
            assessmentProjectResource = await assessmentProjectCollection.GetAsync(assessmentProjName);
            Assert.Multiple(() =>
            {
                Assert.That(assessmentProjectResource.Data.ProvisioningState, Is.EqualTo(MigrationAssessmentProvisioningState.Succeeded));
                Assert.That(assessmentProjectResource.Id, Is.Not.Null);
            });

            // Update Assessment Project
            var assessmentProjectPatch = new MigrationAssessmentProjectPatch();
            assessmentProjectPatch.Tags.Add("Key1", "TestPatchValue");
            var response = await assessmentProjectResource.UpdateAsync(WaitUntil.Completed, assessmentProjectPatch);
            assessmentProjectResource = response.Value;
            string assessmentProjectTagValue = string.Empty;
            Assert.Multiple(() =>
            {
                Assert.That(assessmentProjectResource.Data.Tags.TryGetValue("Key1", out assessmentProjectTagValue), Is.True);
                Assert.That(assessmentProjectTagValue, Is.EqualTo("TestPatchValue"));
            });

            // Delete Assessment Project
            await assessmentProjectResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAssessmentProjectSummaryOperations()
        {
            var collection = assessmentProjectResource.GetMigrationAssessmentProjectSummaries();

            // Get Assessment Project Summary
            var assessmentProjectSummaryResource = await collection.GetAsync("default");
            Assert.That(assessmentProjectSummaryResource, Is.Not.Null);

            // Get All Assessment Project Summaries
            var allAssessmentProjectSummaries = collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allAssessmentProjectSummaries, Is.Not.Null);
            Assert.That(allAssessmentProjectSummaries.Result, Is.Not.Empty);
        }
    }
}
