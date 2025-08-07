// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleManagementPolicyCollectionTests : AuthorizationManagementTestBase
    {
        public RoleManagementPolicyCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleManagementPolicyCollection> GetRoleManagementPolicyCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleManagementPolicies();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetRoleManagementPolicyCollectionAsync();
            var roleManagementPolicies = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleManagementPolicies.Count, 0);
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleManagementPolicyCollectionAsync();
            var roleManagementPolicies = await collection.GetAllAsync().ToEnumerableAsync();
            var roleManagementPolicy1 = roleManagementPolicies.FirstOrDefault();
            if (roleManagementPolicy1 != null)
            {
                var roleManagementPolicy2 = await collection.GetAsync(roleManagementPolicy1.Data.Name);
                Assert.AreEqual(roleManagementPolicy2.Value.Data.Name, roleManagementPolicy1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetRoleManagementPolicyCollectionAsync();
            var roleManagementPolicies = await collection.GetAllAsync().ToEnumerableAsync();
            var roleManagementPolicy1 = roleManagementPolicies.FirstOrDefault();
            if (roleManagementPolicy1 != null)
            {
                var roleManagementPolicy2 = await collection.ExistsAsync(roleManagementPolicy1.Data.Name);
                Assert.IsTrue(roleManagementPolicy2.Value);
            }
        }
    }
}
