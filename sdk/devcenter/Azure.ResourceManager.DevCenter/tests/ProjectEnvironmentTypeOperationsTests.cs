// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class ProjectEnvironmentTypeOperationsTests : DevCenterManagementTestBase
    {
        public ProjectEnvironmentTypeOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ProjectEnvironmentTypeResourceFull()
        {
            ResourceIdentifier projectId = new ResourceIdentifier(TestEnvironment.DefaultProjectId);
            var projectResponse = await Client.GetDevCenterProjectResource(projectId).GetAsync();
            var projectResource = projectResponse.Value;

            DevCenterProjectEnvironmentCollection resourceCollection = projectResource.GetDevCenterProjectEnvironments();

            string ProjectEnvironmentTypeName = TestEnvironment.DefaultEnvironmentTypeName;

            // Create a ProjectEnvironmentType resource

            var data = new DevCenterProjectEnvironmentData(TestEnvironment.Location)
            {
                DeploymentTargetId = new ResourceIdentifier($"/subscriptions/{projectResource.Id.SubscriptionId}"),
                Status = EnvironmentTypeEnableStatus.IsEnabled,
            };

            data.UserRoleAssignments[TestEnvironment.TestUserOid] = new DevCenterUserRoleAssignments(new Dictionary<string, DevCenterEnvironmentRole> { { "4cbf0b6c-e750-441c-98a7-10da8387e4d6", new DevCenterEnvironmentRole() } }, null);
            data.CreatorRoleAssignment = new ProjectEnvironmentTypeUpdatePropertiesCreatorRoleAssignment(new Dictionary<string, DevCenterEnvironmentRole> { { "4cbf0b6c-e750-441c-98a7-10da8387e4d6", new DevCenterEnvironmentRole() } }, null);

            DevCenterProjectEnvironmentResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, ProjectEnvironmentTypeName, data)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List ProjectEnvironmentTypes
            List<DevCenterProjectEnvironmentResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<DevCenterProjectEnvironmentResource> retrievedProjectEnvironmentType = await resourceCollection.GetAsync(ProjectEnvironmentTypeName);
            Assert.NotNull(retrievedProjectEnvironmentType.Value);
            Assert.NotNull(retrievedProjectEnvironmentType.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedProjectEnvironmentType.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
