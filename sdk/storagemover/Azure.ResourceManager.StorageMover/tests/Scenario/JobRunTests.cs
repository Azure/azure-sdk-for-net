// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class JobRunTests : StorageMoverManagementTestBase
    {
        public JobRunTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetExistTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionResource jobDefinition = (await project.GetJobDefinitions().GetAsync(JobDefinitionName)).Value;
            JobRunCollection jobRuns = jobDefinition.GetJobRuns();

            JobRunResource jobRun = (await jobRuns.GetAsync(JobName)).Value;

            int counter = 0;
            await foreach (JobRunResource _ in jobRuns.GetAllAsync())
            {
                counter++;
            }

            Assert.That((await jobRuns.ExistsAsync(JobName)).Value, Is.True);

            JobRunResource jobRun2 = (await jobRun.GetAsync()).Value;
        }
    }
}
