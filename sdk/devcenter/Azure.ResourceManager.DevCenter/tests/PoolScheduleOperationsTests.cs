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
    public class PoolScheduleOperationsTests : DevCenterManagementTestBase
    {
        public PoolScheduleOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task PoolScheduleResourceFull()
        {
            ResourceIdentifier projectId = new ResourceIdentifier(TestEnvironment.DefaultProjectId);
            ResourceIdentifier poolId = new ResourceIdentifier(TestEnvironment.DefaultPoolId);

            var projectResponse = await Client.GetProjectResource(projectId).GetAsync();
            var projectResource = projectResponse.Value;

            var poolResource = await Client.GetPoolResource(poolId).GetAsync();
            ScheduleCollection resourceCollection = poolResource.Value.GetSchedules();

            string resourceName = "default";

            // Create a Schedule resource

            var scheduleData = new ScheduleData()
            {
                ScheduledType = ScheduledType.StopDevBox,
                Frequency = ScheduledFrequency.Daily,
                State = ScheduleEnableStatus.Enabled,
                Time = "17:30",
                TimeZone = "America/Los_Angeles",
            };
            ArmOperation<ScheduleResource> createdResourceResponse = await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, scheduleData);
            ScheduleResource createdResource = createdResourceResponse.Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<ScheduleResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<ScheduleResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Update
            SchedulePatch updateRequest = new SchedulePatch()
            {
                State = ScheduleEnableStatus.Disabled,
            };
            ArmOperation<ScheduleResource> updateResponse = await retrievedResource.Value.UpdateAsync(WaitUntil.Completed, updateRequest);

            // Delete
            ArmOperation deleteOp = await updateResponse.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
