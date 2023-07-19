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
    public class PoolOperationsTests : DevCenterManagementTestBase
    {
        public PoolOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task PoolResourceFull()
        {
            ResourceIdentifier projectId = new ResourceIdentifier(TestEnvironment.DefaultProjectId);
            ResourceIdentifier devBoxDefinitionId = new ResourceIdentifier(TestEnvironment.DefaultMarketplaceDefinitionId);

            var projectResponse = await Client.GetDevCenterProjectResource(projectId).GetAsync();
            var projectResource = projectResponse.Value;

            DevCenterPoolCollection resourceCollection = projectResource.GetDevCenterPools();

            string resourceName = "sdktest-pool";

            // Create a Pool resource

            var poolData = new DevCenterPoolData(new AzureLocation(TestEnvironment.Location))
            {
                DevBoxDefinitionName = devBoxDefinitionId.Name,
                NetworkConnectionName = TestEnvironment.DefaultAttachedNetworkName,
                LicenseType = DevCenterLicenseType.WindowsClient,
                LocalAdministrator = LocalAdminStatus.IsEnabled,
            };
            ArmOperation<DevCenterPoolResource> createdResourceResponse = await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, poolData);
            DevCenterPoolResource createdResource = createdResourceResponse.Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<DevCenterPoolResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<DevCenterPoolResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Update
            DevCenterPoolPatch updateRequest = new DevCenterPoolPatch()
            {
                LocalAdministrator = LocalAdminStatus.IsDisabled,
            };
            ArmOperation<DevCenterPoolResource> updateResponse = await retrievedResource.Value.UpdateAsync(WaitUntil.Completed, updateRequest);

            // Delete
            ArmOperation deleteOp = await updateResponse.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
