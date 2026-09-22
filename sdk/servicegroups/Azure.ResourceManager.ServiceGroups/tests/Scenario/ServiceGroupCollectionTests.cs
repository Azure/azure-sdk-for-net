// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceGroups.Tests.Scenario
{
    public class ServiceGroupCollectionTests : ServiceGroupsManagementTestBase
    {
        public ServiceGroupCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ServiceGroupCollectionApiTests()
        {
            var tenantCollection = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenantCollection.FirstOrDefault();
            Assert.IsNotNull(tenant, "No tenant found");
            var serviceGroupCollection = tenant.GetServiceGroups();

            // 1. Create Collection
            string serviceGroupName = Recording.GenerateAssetName("testsg-");
            string tenantId = TestEnvironment.TenantId;

            ServiceGroupData data = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Test ServiceGroup {serviceGroupName}",
                    Parent = new ParentServiceGroupProperties
                    {
                        ResourceId = new ResourceIdentifier($"/providers/Microsoft.Management/serviceGroups/{tenantId}"),
                    }
                },
            };

            var lro = await serviceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);
            ServiceGroupResource serviceGroup = lro.Value;

            Assert.IsNotNull(serviceGroup);
            Assert.IsNotNull(serviceGroup.Data);
            Assert.AreEqual(serviceGroupName, serviceGroup.Data.Name);
            Assert.AreEqual($"Test ServiceGroup {serviceGroupName}", serviceGroup.Data.Properties.DisplayName);
            Assert.AreEqual(ServiceGroupResource.ResourceType, serviceGroup.Data.ResourceType);

            // 2. Get collection
            serviceGroup = await serviceGroupCollection.GetAsync(serviceGroupName);

            Assert.IsNotNull(serviceGroup);
            Assert.IsNotNull(serviceGroup.Data);
            Assert.AreEqual(serviceGroupName, serviceGroup.Data.Name);
            Assert.AreEqual(ServiceGroupResource.ResourceType, serviceGroup.Data.ResourceType);

            // 3. Update Collection
            ServiceGroupData updatedData = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Updated ServiceGroup {serviceGroupName}",
                    Parent = new ParentServiceGroupProperties
                    {
                        ResourceId = new ResourceIdentifier($"/providers/Microsoft.Management/serviceGroups/{tenantId}"),
                    }
                },
            };

            ServiceGroupResource updatedServiceGroup = (await serviceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, updatedData)).Value;

            Assert.IsNotNull(updatedServiceGroup);
            Assert.AreEqual(serviceGroupName, updatedServiceGroup.Data.Name);
            Assert.AreEqual(updatedData.Properties.DisplayName, updatedServiceGroup.Data.Properties.DisplayName);
            Assert.AreEqual(tenantId, updatedServiceGroup.Data.Properties.Parent.ResourceId.Name);

            // 4. Exists
            Assert.IsTrue(await serviceGroupCollection.ExistsAsync(serviceGroup.Data.Name));
            Assert.IsFalse(await serviceGroupCollection.ExistsAsync(serviceGroup.Data.Name + "x"));

            // 5. GetIfExists
            var serviceGroupIfExists = await serviceGroupCollection.GetIfExistsAsync(serviceGroup.Data.Name);
            Assert.IsTrue(serviceGroupIfExists.HasValue);
            Assert.IsNotNull(serviceGroupIfExists.Value);
            serviceGroupIfExists = await serviceGroupCollection.GetIfExistsAsync(serviceGroup.Data.Name + "x");
            Assert.IsFalse(serviceGroupIfExists.HasValue);
            Assert.AreEqual(404, serviceGroupIfExists.GetRawResponse().Status);

            // 6. Clean up all created SGs
            await serviceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
