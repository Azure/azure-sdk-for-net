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

            var poolResource = await Client.GetDevCenterPoolResource(poolId).GetAsync();
            DevCenterScheduleCollection resourceCollection = poolResource.Value.GetDevCenterSchedules();

            string resourceName = "default";

            // Create a Schedule resource

            var scheduleData = new DevCenterScheduleData()
            {
                ScheduledType = DevCenterScheduledType.StopDevBox,
                Frequency = DevCenterScheduledFrequency.Daily,
                State = DevCenterScheduleEnableStatus.IsEnabled,
                Time = "17:30",
                TimeZone = "America/Los_Angeles",
            };
            ArmOperation<DevCenterScheduleResource> createdResourceResponse = await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, scheduleData);
            DevCenterScheduleResource createdResource = createdResourceResponse.Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<DevCenterScheduleResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<DevCenterScheduleResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Update
            DevCenterSchedulePatch updateRequest = new DevCenterSchedulePatch()
            {
                State = DevCenterScheduleEnableStatus.IsDisabled,
            };
            ArmOperation<DevCenterScheduleResource> updateResponse = await retrievedResource.Value.UpdateAsync(WaitUntil.Completed, updateRequest);

            // Delete
            ArmOperation deleteOp = await updateResponse.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
