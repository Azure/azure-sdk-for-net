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

            DevCenterProjectCollection resourceCollection = rg.GetDevCenterProjects();

            string projectName = "sdktest-project";

            // Create a Project resource

            var projectData = new DevCenterProjectData(TestEnvironment.Location)
            {
                DevCenterId = new Core.ResourceIdentifier(TestEnvironment.DefaultDevCenterId),
            };

            DevCenterProjectResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectData)).Value;

            Assert.That(createdResource, Is.Not.Null);
            Assert.That(createdResource.Data, Is.Not.Null);

            // List Projects
            List<DevCenterProjectResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(resources.Any(r => r.Id == createdResource.Id), Is.True);

            // Get
            Response<DevCenterProjectResource> retrievedProject = await resourceCollection.GetAsync(projectName);
            Assert.That(retrievedProject.Value, Is.Not.Null);
            Assert.That(retrievedProject.Value.Data, Is.Not.Null);

            // Delete
            ArmOperation deleteOp = await retrievedProject.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
