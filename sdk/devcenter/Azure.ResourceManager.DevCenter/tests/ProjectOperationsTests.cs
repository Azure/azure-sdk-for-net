// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class ProjectOperationsTests : DevCenterManagementTestBase
    {
        public ProjectOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("TODO")]
        public async Task ProjectResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            ProjectCollection projectCollection = rg.GetProjects();

            string projectName = "sdktest-project";

            // Create a Project resource

            var projectData = new ProjectData(TestEnvironment.Location)
            {
                DevCenterId = TestEnvironment.DefaultDevCenterId,
            };

            ArmOperation<ProjectResource> createdProjectResponse = await projectCollection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectData);
            ProjectResource projectResource = createdProjectResponse.Value;

            Assert.NotNull(projectResource);
            Assert.NotNull(projectResource.Data);

            // List Projects
            AsyncPageable<ProjectResource> projects = projectCollection.GetAllAsync();
            int count = 0;
            await foreach (ProjectResource v in projects)
            {
                if (v.Id == projectResource.Id)
                {
                    count++;
                    break;
                }
            }
            Assert.True(count == 1);

            // Get
            Response<ProjectResource> retrievedProject = await projectCollection.GetAsync(projectName);
            Assert.NotNull(retrievedProject.Value);
            Assert.NotNull(retrievedProject.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedProject.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
