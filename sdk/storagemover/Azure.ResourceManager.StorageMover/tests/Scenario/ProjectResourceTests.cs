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
    public class ProjectResourceTests : StorageMoverManagementTestBase
    {
        public ProjectResourceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource _resourceGroup;

        [Test]
        [RecordedTest]
        public async Task GetUpdateDeleteTest()
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
            StorageMoverProjectResource project2 = (await project.GetAsync()).Value;
            Assert.AreEqual(project.Data.Name, project2.Data.Name);
            Assert.AreEqual(project.Data.Description, project2.Data.Description);
            Assert.AreEqual(project.Id.Name, project2.Id.Name);
            Assert.AreEqual(project.Id.Location, project2.Id.Location);

            StorageMoverProjectPatch patch = new StorageMoverProjectPatch
            {
                Description = "This is an updated project"
            };
            project = (await project.UpdateAsync(patch)).Value;
            Assert.AreEqual(patch.Description, project.Data.Description);

            await project.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await projects.ExistsAsync(projectName)).Value);
        }
    }
}
