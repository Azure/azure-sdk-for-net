// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class ProjectCollectionTests :StorageMoverManagementTestBase
    {
        public ProjectCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
            {
            }

        private ResourceGroupResource _resourceGroup;

        [Test]
        [RecordedTest]
        public async Task CrateGetExistTest()
        {
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupNamePrefix, TestLocation);
            StorageMoverCollection storageMovers = _resourceGroup.GetStorageMovers();
            string storageMoverName = Recording.GenerateAssetName("stomover-");
            StorageMoverData storageMoverData = new StorageMoverData(TestLocation);
            StorageMoverResource storageMover = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, storageMoverData)).Value;
            StorageMoverProjectCollection projects = storageMover.GetStorageMoverProjects();

            string projectName = Recording.GenerateAssetName("project-");
            StorageMoverProjectData projectData = new StorageMoverProjectData();
            StorageMoverProjectResource project = (await projects.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectData)).Value;
            Assert.AreEqual(projectName, project.Data.Name);
            Assert.AreEqual(null, project.Data.Description);
            Assert.AreEqual("microsoft.storagemover/storagemovers/projects", project.Data.ResourceType.ToString());

            project = (await projects.GetAsync(projectName)).Value;
            Assert.AreEqual(projectName, project.Data.Name);
            Assert.AreEqual(null, project.Data.Description);
            Assert.AreEqual("microsoft.storagemover/storagemovers/projects", project.Data.ResourceType.ToString());

            int counter = 0;
            await foreach (StorageMoverProjectResource _ in projects.GetAllAsync())
            {
                counter++;
            }

            Assert.IsTrue((await projects.ExistsAsync(projectName)).Value);
        }
    }
}
