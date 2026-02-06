// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceGroups.Tests.Scenario
{
    public class ServiceGroupResourceTests : ServiceGroupsManagementTestBase
    {
        private ServiceGroupResource _serviceGroup;
        private ServiceGroupResource _parentServiceGroup;
        private ServiceGroupCollection _serviceGroupCollection;

        public ServiceGroupResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                _serviceGroupCollection = tenant.GetServiceGroups();
                break;
            }
        }

        private async Task<ServiceGroupResource> CreateServiceGroupAsync(string name, string parentServiceGroupId)
        {
            ServiceGroupData data = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Test ServiceGroup {name}",
                    Parent = new ParentServiceGroupProperties
                    {
                        ResourceId = new ResourceIdentifier($"/providers/Microsoft.Management/serviceGroups/{parentServiceGroupId}"),
                    }
                },
            };

            var lro = await _serviceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            return lro.Value;
        }

        [RecordedTest]
        public async Task Get()
        {
            string serviceGroupName = Recording.GenerateAssetName("testsg-");
            _serviceGroup = await CreateServiceGroupAsync(serviceGroupName, TestEnvironment.TenantId);

            ServiceGroupResource serviceGroup = await _serviceGroup.GetAsync();

            Assert.IsNotNull(serviceGroup);
            Assert.IsNotNull(serviceGroup.Data);
            Assert.AreEqual(serviceGroupName, serviceGroup.Data.Name);
            Assert.AreEqual(ServiceGroupResource.ResourceType, serviceGroup.Data.ResourceType);
            Assert.AreEqual(TestEnvironment.TenantId, serviceGroup.Data.Properties.Parent.ResourceId.Name);

            await _serviceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Update()
        {
            string serviceGroupName = Recording.GenerateAssetName("testsg-");
            _serviceGroup = await CreateServiceGroupAsync(serviceGroupName, TestEnvironment.TenantId);

            // Update the service group with a new display name
            ServiceGroupData updateData = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Updated ServiceGroup {serviceGroupName}",
                },
            };

            var lro = await _serviceGroup.UpdateAsync(WaitUntil.Completed, updateData);
            ServiceGroupResource updatedServiceGroup = lro.Value;

            Assert.IsNotNull(updatedServiceGroup);
            Assert.AreEqual(serviceGroupName, updatedServiceGroup.Data.Name);
            Assert.AreEqual($"Updated ServiceGroup {serviceGroupName}", updatedServiceGroup.Data.Properties.DisplayName);
            Assert.AreEqual(TestEnvironment.TenantId, updatedServiceGroup.Data.Properties.Parent.ResourceId.Name);
            await _serviceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string serviceGroupName = Recording.GenerateAssetName("testsg-");
            _serviceGroup = await CreateServiceGroupAsync(serviceGroupName, TestEnvironment.TenantId);

            // Verify it exists before deletion
            bool exists = await _serviceGroupCollection.ExistsAsync(serviceGroupName);
            Assert.IsTrue(exists);

            // Delete the service group
            await _serviceGroup.DeleteAsync(WaitUntil.Completed);

            // Verify it no longer exists
            exists = await _serviceGroupCollection.ExistsAsync(serviceGroupName);
            Assert.IsFalse(exists);
            _serviceGroup = null; // Set to null to avoid trying to delete again in TearDown
        }

        [RecordedTest]
        public async Task CreateWithParent()
        {
            // First create a parent service group
            string parentName = Recording.GenerateAssetName("parentsg-");
            _parentServiceGroup = await CreateServiceGroupAsync(parentName, TestEnvironment.TenantId);

            // Create a child service group with parent
            string childName = Recording.GenerateAssetName("childsg-");
            ServiceGroupData childData = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Child ServiceGroup {childName}",
                    ParentResourceId = _parentServiceGroup.Id,
                },
            };

            var lro = await _serviceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, childName, childData);
            _serviceGroup = lro.Value;

            Assert.IsNotNull(_serviceGroup);
            Assert.AreEqual(childName, _serviceGroup.Data.Name);
            Assert.AreEqual(_parentServiceGroup.Id, _serviceGroup.Data.Properties.Parent.ResourceId);
            await _serviceGroup.DeleteAsync(WaitUntil.Completed);
            await _parentServiceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
