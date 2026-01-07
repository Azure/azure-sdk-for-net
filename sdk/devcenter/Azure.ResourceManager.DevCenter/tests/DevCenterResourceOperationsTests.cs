// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class DevCenterResourceOperationsTests : DevCenterManagementTestBase
    {
        public DevCenterResourceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task DevCenterResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            DevCenterCollection resourceCollection = rg.GetDevCenters();

            string devCenterName = "sdktest-devcenter";

            // Create a DevCenter resource

            var devCenterData = new DevCenterData(TestEnvironment.Location);
            ArmOperation<DevCenterResource> createdDevCenterResponse = await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, devCenterData);
            DevCenterResource createdResource = createdDevCenterResponse.Value;

            Assert.That(createdResource, Is.Not.Null);
            Assert.That(createdResource.Data, Is.Not.Null);

            // List DevCenters
            List<DevCenterResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(resources.Any(r => r.Id == createdResource.Id), Is.True);

            // Get
            Response<DevCenterResource> retrievedDevCenter = await resourceCollection.GetAsync(devCenterName);
            Assert.That(retrievedDevCenter.Value, Is.Not.Null);
            Assert.That(retrievedDevCenter.Value.Data, Is.Not.Null);

            // Update
            DevCenterData updatedData = new DevCenterData(TestEnvironment.Location);
            updatedData.Tags["t1"] = "v1";

            ArmOperation<DevCenterResource> updatedDevCenter = await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, updatedData);

            // Delete
            ArmOperation deleteOp = await updatedDevCenter.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
