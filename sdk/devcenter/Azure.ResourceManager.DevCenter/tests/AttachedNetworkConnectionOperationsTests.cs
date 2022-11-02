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
    public class AttachedNetworkConnectionOperationsTests : DevCenterManagementTestBase
    {
        public AttachedNetworkConnectionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task AttachedNetworkConnectionResourceFull()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            AttachedNetworkConnectionCollection resourceCollection = Client.GetDevCenterResource(devCenterId).GetAttachedNetworkConnections();

            string devCenterName = "sdk-attachedNetwork";

            // Create a AttachedNetworkConnection resource

            var devCenterData = new AttachedNetworkConnectionData()
            {
                NetworkConnectionId = TestEnvironment.DefaultNetworkConnection2Id,
            };

            AttachedNetworkConnectionResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, devCenterData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List AttachedNetworkConnections
            List<AttachedNetworkConnectionResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<AttachedNetworkConnectionResource> retrievedAttachedNetworkConnection = await resourceCollection.GetAsync(devCenterName);
            Assert.NotNull(retrievedAttachedNetworkConnection.Value);
            Assert.NotNull(retrievedAttachedNetworkConnection.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedAttachedNetworkConnection.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
