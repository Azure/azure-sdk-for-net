// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class DevBoxDefinitionOperationsTests : DevCenterManagementTestBase
    {
        public DevBoxDefinitionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task DevBoxDefinitionResourceFull()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            DevBoxDefinitionCollection resourceCollection = devCenterResource.GetDevBoxDefinitions();

            string resourceName = "sdktest-devboxdefinition";

            // Create a DevBox Definition resource

            var devBoxDefinitionData = new DevBoxDefinitionData(TestEnvironment.Location)
            {
                ImageReference = new ImageReference()
                {
                    Id = $"{devCenterId}/galleries/default/images/MicrosoftWindowsDesktop_windows-ent-cpc_win11-21h2-ent-cpc-m365",
                },
                Sku = new DevCenterSku(name: "general_a_8c32gb_v1"),
                OSStorageType = "ssd_512gb",
            };
            DevBoxDefinitionResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, devBoxDefinitionData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<DevBoxDefinitionResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<DevBoxDefinitionResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Update
            var updateRequest = new DevBoxDefinitionPatch()
            {
                OSStorageType = "ssd_256gb",
            };
            ArmOperation<DevBoxDefinitionResource> updateResponse = await retrievedResource.Value.UpdateAsync(WaitUntil.Completed, updateRequest);

            // Delete
            ArmOperation deleteOp = await updateResponse.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
