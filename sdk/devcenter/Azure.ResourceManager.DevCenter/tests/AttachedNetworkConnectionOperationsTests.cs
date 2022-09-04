// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
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

            var devCenter = Client.GetDevCenterResource(devCenterId);

            AttachedNetworkConnectionCollection devCenterCollection = devCenter.GetAttachedNetworkConnections();

            string devCenterName = "sdk-attachedNetwork";

            // Create a AttachedNetworkConnection resource

            var devCenterData = new AttachedNetworkConnectionData()
            {
                NetworkConnectionId = TestEnvironment.DefaultNetworkConnection2Id,
            };

            ArmOperation<AttachedNetworkConnectionResource> createdResource = await devCenterCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, devCenterData);
            AttachedNetworkConnectionResource devCenterResource = createdResource.Value;

            Assert.NotNull(devCenterResource);
            Assert.NotNull(devCenterResource.Data);

            // List AttachedNetworkConnections
            AsyncPageable<AttachedNetworkConnectionResource> devCenters = devCenterCollection.GetAllAsync();
            int count = 0;
            await foreach (AttachedNetworkConnectionResource v in devCenters)
            {
                if (v.Id == devCenterResource.Id)
                {
                    count++;
                    break;
                }
            }
            Assert.True(count == 1);

            // Get
            Response<AttachedNetworkConnectionResource> retrievedAttachedNetworkConnection = await devCenterCollection.GetAsync(devCenterName);
            Assert.NotNull(retrievedAttachedNetworkConnection.Value);
            Assert.NotNull(retrievedAttachedNetworkConnection.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedAttachedNetworkConnection.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
