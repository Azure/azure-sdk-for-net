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
            Assert.That(project2.Data.Name, Is.EqualTo(project.Data.Name));
            Assert.That(project2.Data.Description, Is.EqualTo(project.Data.Description));
            Assert.That(project2.Id.Name, Is.EqualTo(project.Id.Name));
            Assert.That(project2.Id.Location, Is.EqualTo(project.Id.Location));

            StorageMoverProjectPatch patch = new StorageMoverProjectPatch
            {
                Description = "This is an updated project"
            };
            project = (await project.UpdateAsync(patch)).Value;
            Assert.That(project.Data.Description, Is.EqualTo(patch.Description));

            await project.DeleteAsync(WaitUntil.Completed);
            Assert.That((await projects.ExistsAsync(projectName)).Value, Is.False);
        }
    }
}
