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
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.AreEqual(ContainerEndpointName, jobDefinition.Data.TargetName);
            Assert.AreEqual(NfsEndpointName, jobDefinition.Data.SourceName);
            Assert.AreEqual("Additive", jobDefinition.Data.CopyMode.ToString());

            jobDefinition = (await jobDefinitions.GetAsync(JobDefinitionName)).Value;

            int counter = 0;
            await foreach (JobDefinitionResource _ in jobDefinitions.GetAllAsync())
            {
                counter++;
            }
            Assert.GreaterOrEqual(counter, 1);

            Assert.IsTrue((await jobDefinitions.ExistsAsync(JobDefinitionName)).Value);

            JobDefinitionResource jobDefinition2 = (await jobDefinition.GetAsync()).Value;
            Assert.AreEqual(jobDefinition.Id.Name, jobDefinition2.Id.Name);
            Assert.AreEqual(jobDefinition.Id.Location, jobDefinition2.Id.Location);
            Assert.AreEqual(jobDefinition.Data.Name, jobDefinition2.Data.Name);
            Assert.AreEqual(jobDefinition.Data.TargetName, jobDefinition2.Data.TargetName);
            Assert.AreEqual(jobDefinition.Data.AgentName, jobDefinition2.Data.AgentName);
            Assert.AreEqual(jobDefinition.Data.SourceName, jobDefinition2.Data.SourceName);
            Assert.AreEqual(jobDefinition.Data.Id, jobDefinition2.Data.Id);

            JobRunResourceId jobRunResourceId = (await jobDefinition.StartJobAsync()).Value;

            jobRunResourceId = (await jobDefinition.StopJobAsync()).Value;
        }
    }
}
