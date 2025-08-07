// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleManagementPolicyResourceTests : AuthorizationManagementTestBase
    {
        public RoleManagementPolicyResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleManagementPolicyCollection> GetRoleManagementPolicyCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleManagementPolicies();
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleManagementPolicyCollectionAsync();
            var roleManagementPolicies = await collection.GetAllAsync().ToEnumerableAsync();
            var roleManagementPolicy1 = roleManagementPolicies.FirstOrDefault();
            if (roleManagementPolicy1 != null)
            {
                var roleManagementPolicy2 = await roleManagementPolicy1.GetAsync();
                Assert.AreEqual(roleManagementPolicy2.Value.Data.Name, roleManagementPolicy1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Update()
        {
            var collection = await GetRoleManagementPolicyCollectionAsync();
            var roleManagementPolicies = await collection.GetAllAsync().ToEnumerableAsync();
            var roleManagementPolicy1 = roleManagementPolicies.FirstOrDefault();
            RoleManagementPolicyData data = roleManagementPolicy1.Data;
            data.Description = data.Description + "SDK test";
            if (roleManagementPolicy1 != null)
            {
                var roleManagementPolicy2 = await roleManagementPolicy1.UpdateAsync(data);
                Assert.IsNull(roleManagementPolicy2.Value.Data.Description);
            }
        }
    }
}
