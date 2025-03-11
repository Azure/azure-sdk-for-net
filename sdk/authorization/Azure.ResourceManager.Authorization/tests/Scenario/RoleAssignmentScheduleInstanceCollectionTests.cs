﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleAssignmentScheduleInstanceCollectionTests : AuthorizationManagementTestBase
    {
        public RoleAssignmentScheduleInstanceCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public ResourceGroupResource ResourceGroup { get; set; }

        private async Task<RoleAssignmentScheduleInstanceCollection> GetRoleAssignmentScheduleInstanceCollectionAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            return ResourceGroup.GetRoleAssignmentScheduleInstances();
        }

        [Test]
        public async Task Get()
        {
            var collection = await GetRoleAssignmentScheduleInstanceCollectionAsync();
            var roleAssignmentScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleInstance1 = roleAssignmentScheduleInstances.FirstOrDefault(x => x.Id.ToString().Contains(ResourceGroup.Data.Name));
            if (roleAssignmentScheduleInstance1 != null)
            {
                var roleAssignmentScheduleInstance2 = await collection.GetAsync(roleAssignmentScheduleInstance1.Data.Name);
                Assert.AreEqual(roleAssignmentScheduleInstance2.Value.Data.Name, roleAssignmentScheduleInstance1.Data.Name);
            }
        }

        [Test]
        public async Task GetAll()
        {
            var collection = await GetRoleAssignmentScheduleInstanceCollectionAsync();
            var roleAssignmentScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleAssignmentScheduleInstances.Count, 0);
        }

        [Test]
        public async Task Exists()
        {
            var collection = await GetRoleAssignmentScheduleInstanceCollectionAsync();
            var roleAssignmentScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleInstance = roleAssignmentScheduleInstances.FirstOrDefault(x => x.Id.ToString().Contains(ResourceGroup.Data.Name));
            if (roleAssignmentScheduleInstance != null)
            {
                Assert.IsTrue(await collection.ExistsAsync(roleAssignmentScheduleInstance.Data.Name));
            }
        }
    }
}
