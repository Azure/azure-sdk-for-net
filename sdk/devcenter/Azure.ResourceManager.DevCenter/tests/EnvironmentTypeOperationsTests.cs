// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class EnvironmentTypeOperationsTests : DevCenterManagementTestBase
    {
        public EnvironmentTypeOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task EnvironmentTypeResourceFull()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            DevCenterEnvironmentTypeCollection resourceCollection = Client.GetDevCenterResource(devCenterId).GetDevCenterEnvironmentTypes();

            string environmentTypeName = "sdk-envType";

            // Create an EnvironmentType resource

            var data = new DevCenterEnvironmentTypeData();
            DevCenterEnvironmentTypeResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, environmentTypeName, data)).Value;

            Assert.That(createdResource, Is.Not.Null);
            Assert.That(createdResource.Data, Is.Not.Null);

            // List EnvironmentTypes
            List<DevCenterEnvironmentTypeResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(resources.Any(r => r.Id == createdResource.Id), Is.True);

            // Get
            Response<DevCenterEnvironmentTypeResource> retrievedEnvironmentType = await resourceCollection.GetAsync(environmentTypeName);
            Assert.That(retrievedEnvironmentType.Value, Is.Not.Null);
            Assert.That(retrievedEnvironmentType.Value.Data, Is.Not.Null);

            // Delete
            ArmOperation deleteOp = await retrievedEnvironmentType.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
