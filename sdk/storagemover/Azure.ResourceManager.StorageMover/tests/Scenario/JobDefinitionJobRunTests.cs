// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class JobDefinitionJobRunTests : StorageMoverManagementTestBase
    {
        public JobDefinitionJobRunTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task JobDefinitionJobRunTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionCollection jobDefinitions = project.GetJobDefinitions();

            string jobDefinitionName = Recording.GenerateAssetName("jobdef-");
            JobDefinitionData jobDefinitionData = new JobDefinitionData(Models.StorageMoverCopyMode.Additive, NfsEndpointName, ContainerEndpointName);
            JobDefinitionResource jobDefinition = (await jobDefinitions.CreateOrUpdateAsync(WaitUntil.Completed, jobDefinitionName, jobDefinitionData)).Value;
            Assert.That(jobDefinition.Data.Name, Is.EqualTo(jobDefinitionName));
            Assert.That(jobDefinition.Data.TargetName, Is.EqualTo(ContainerEndpointName));
            Assert.That(jobDefinition.Data.SourceName, Is.EqualTo(NfsEndpointName));
            Assert.That(jobDefinition.Data.CopyMode.ToString(), Is.EqualTo("Additive"));

            jobDefinition = (await jobDefinitions.GetAsync(JobDefinitionName)).Value;

            int counter = 0;
            await foreach (JobDefinitionResource _ in jobDefinitions.GetAllAsync())
            {
                counter++;
            }
            Assert.That(counter, Is.GreaterThanOrEqualTo(1));

            Assert.That((await jobDefinitions.ExistsAsync(JobDefinitionName)).Value, Is.True);

            JobDefinitionResource jobDefinition2 = (await jobDefinition.GetAsync()).Value;
            Assert.That(jobDefinition2.Id.Name, Is.EqualTo(jobDefinition.Id.Name));
            Assert.That(jobDefinition2.Id.Location, Is.EqualTo(jobDefinition.Id.Location));
            Assert.That(jobDefinition2.Data.Name, Is.EqualTo(jobDefinition.Data.Name));
            Assert.That(jobDefinition2.Data.TargetName, Is.EqualTo(jobDefinition.Data.TargetName));
            Assert.That(jobDefinition2.Data.AgentName, Is.EqualTo(jobDefinition.Data.AgentName));
            Assert.That(jobDefinition2.Data.SourceName, Is.EqualTo(jobDefinition.Data.SourceName));
            Assert.That(jobDefinition2.Data.Id, Is.EqualTo(jobDefinition.Data.Id));

            JobRunResourceId jobRunResourceId = (await jobDefinition.StartJobAsync()).Value;

            jobRunResourceId = (await jobDefinition.StopJobAsync()).Value;
        }
    }
}
