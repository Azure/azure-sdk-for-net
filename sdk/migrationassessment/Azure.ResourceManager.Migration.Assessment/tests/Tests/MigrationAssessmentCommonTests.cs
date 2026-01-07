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
    public class MigrationAssessmentCommonTests : MigrationAssessmentManagementTestBase
    {
        private static AzureLocation targetRegion;
        private static string targetSubscriptionId;
        private static ResourceGroupResource rg;
        private static MigrationAssessmentProjectResource assessmentProjectResource;

        public MigrationAssessmentCommonTests(bool isAsync) : base(isAsync)
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
            Assert.That(response.HasCompleted, Is.True);
            Assert.That(assessmentProjectResource, Is.Not.Null);
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
        public async Task TestAssessmentGroupOperations()
        {
            string rgName = rg.Id.Name;
            var assessmentProjName = assessmentProjectResource.Id.Name;
            var collection = assessmentProjectResource.GetMigrationAssessmentGroups();

            // Create Assessment Group
            var data = new MigrationAssessmentGroupData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                GroupType = MigrationAssessmentGroupType.Default,
            };
            string groupName = Recording.GenerateAssetName("group-");
            var groupResponse =
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, data);
            var groupResource = groupResponse.Value;
            Assert.That(groupResponse.HasCompleted, Is.True);
            Assert.That(groupResource, Is.Not.Null);

            // Get Assessment Group
            groupResource = await collection.GetAsync(groupName);
            Assert.That(groupResource.Data.GroupStatus, Is.EqualTo(MigrationAssessmentGroupStatus.Completed));
            Assert.That(groupResource.Id, Is.Not.Null);

            // Get All Assessment Groups
            var allGroups = collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allGroups, Is.Not.Null);
            Assert.GreaterOrEqual(allGroups.Result.Count, 1);

            // Update Machines in Assessment Group
            MigrateGroupUpdateContent content = new MigrateGroupUpdateContent()
            {
                ETag = new ETag("*"),
                Properties = new MigrateGroupUpdateProperties()
                {
                    OperationType = MigrateGroupUpdateOperationType.Add,
                    Machines =
                    {
                        string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Migrate/assessmentprojects/{assessmentProjName}/machines/18895660-c5e5-4247-8cfc-cd24e1fe57f3")
                    },
                },
            };
            var updateMachinesResponse = await groupResource.UpdateMachinesAsync(WaitUntil.Completed, content);
            var updatedGroupResource = updateMachinesResponse.Value;
            Assert.That(updateMachinesResponse.HasCompleted, Is.True);
            Assert.That(updatedGroupResource, Is.Not.Null);

            // Delete Assessment Group
            await groupResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestAssessmentOptionsOperations()
        {
            string assessmentOptionsName = "default";
            MigrationAssessmentOptionCollection collection = assessmentProjectResource.GetMigrationAssessmentOptions();

            // Get Assessment Options
            var assessmentOptionResponse = await collection.GetAsync(assessmentOptionsName);
            var assessmentOptionsResource = assessmentOptionResponse.Value;
            Assert.That(assessmentOptionsResource, Is.Not.Null);
            Assert.That(assessmentOptionsName, Is.EqualTo(assessmentOptionsResource.Data.Name));

            // Get All Assessment Options
            var allAssessmentOptions = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allAssessmentOptions, Is.Not.Null);
            Assert.GreaterOrEqual(allAssessmentOptions.Count, 1);
        }
    }
}
