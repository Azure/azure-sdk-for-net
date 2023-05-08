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

            EnvironmentTypeCollection resourceCollection = Client.GetDevCenterResource(devCenterId).GetEnvironmentTypes();

            string environmentTypeName = "sdk-envType";

            // Create an EnvironmentType resource

            var data = new EnvironmentTypeData();
            EnvironmentTypeResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, environmentTypeName, data)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List EnvironmentTypes
            List<EnvironmentTypeResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<EnvironmentTypeResource> retrievedEnvironmentType = await resourceCollection.GetAsync(environmentTypeName);
            Assert.NotNull(retrievedEnvironmentType.Value);
            Assert.NotNull(retrievedEnvironmentType.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedEnvironmentType.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
