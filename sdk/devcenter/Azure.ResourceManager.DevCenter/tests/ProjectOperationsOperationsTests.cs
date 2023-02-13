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
    public class ProjectOperationsOperationsTests : DevCenterManagementTestBase
    {
        public ProjectOperationsOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ProjectResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            ProjectCollection resourceCollection = rg.GetProjects();

            string projectName = "sdktest-project";

            // Create a Project resource

            var projectData = new ProjectData(TestEnvironment.Location)
            {
                DevCenterId = TestEnvironment.DefaultDevCenterId,
            };

            ProjectResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List Projects
            List<ProjectResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<ProjectResource> retrievedProject = await resourceCollection.GetAsync(projectName);
            Assert.NotNull(retrievedProject.Value);
            Assert.NotNull(retrievedProject.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedProject.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
