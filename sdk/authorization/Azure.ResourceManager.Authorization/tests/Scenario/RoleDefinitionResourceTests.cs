// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleDefinitionResourceTests : AuthorizationManagementTestBase
    {
        public RoleDefinitionResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AuthorizationRoleDefinitionCollection> GetRoleDefinitionCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAuthorizationRoleDefinitions();
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            var roleDefinition1 = roleDefinitions.FirstOrDefault();
            if (roleDefinition1 != null)
            {
                var roleDefinition2 = await roleDefinition1.GetAsync();
                Assert.AreEqual(roleDefinition2.Value.Data.Name, roleDefinition1.Data.Name);
            }
        }

        [RecordedTest]
        [Ignore("Permission issue")]
        public async Task Delete()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            var roleDefinition1 = roleDefinitions.FirstOrDefault();
            if (roleDefinition1 != null)
            {
                await roleDefinition1.DeleteAsync(WaitUntil.Completed);
                roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
                var roleDefinition2 = roleDefinitions.FirstOrDefault();
                Assert.AreNotEqual(roleDefinition2.Data.Name, roleDefinition1.Data.Name);
            }
        }

        [RecordedTest]
        [Ignore("Permission issue")]
        public async Task Update()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            var roleDefinition1 = roleDefinitions.FirstOrDefault();
            if (roleDefinition1 != null)
            {
                var data = roleDefinition1.Data;
                var roleDefinition2 = await roleDefinition1.UpdateAsync(WaitUntil.Completed, data);
                Assert.AreEqual(roleDefinition2.Value.Data.Name, roleDefinition1.Data.Name);
            }
        }
    }
}
