// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleDefinitionCollectionTests : AuthorizationManagementTestBase
    {
        public RoleDefinitionCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public ResourceGroupResource ResourceGroup {get; set;}

        private async Task<AuthorizationRoleDefinitionCollection> GetRoleDefinitionCollectionAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            return ResourceGroup.GetAuthorizationRoleDefinitions();
        }

        [RecordedTest]
        public async Task Create()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var data = new AuthorizationRoleDefinitionData()
            {
                RoleName = "SDKTestRole",
                Description = "SDKTestDescription",
                RoleType = "CustomRole",
                Permissions = {
                    new RoleDefinitionPermission() {
                        Actions = { "Microsoft.Authorization/*/read" }
                        }
                },
                AssignableScopes = { ResourceGroup.Id }
            };
            var id = "49b923e6-f458-4229-a980-c0e62fcea856";
            var roleDefinition = await collection.CreateOrUpdateAsync(WaitUntil.Completed, new ResourceIdentifier(id), data);
            Assert.AreEqual(roleDefinition.Value.Data.Name, id);
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            var roleDefinition1 = roleDefinitions.FirstOrDefault();
            if (roleDefinition1 != null)
            {
                var roleDefinition2 = await collection.GetAsync(new ResourceIdentifier(roleDefinition1.Data.Name));
                Assert.AreEqual(roleDefinition2.Value.Data.Name, roleDefinition1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleDefinitions.Count, 0);
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetRoleDefinitionCollectionAsync();
            var roleDefinitions = await collection.GetAllAsync().ToEnumerableAsync();
            var roleDefinition = roleDefinitions.FirstOrDefault();
            if (roleDefinition != null)
            {
                var result = await collection.ExistsAsync(new ResourceIdentifier(roleDefinition.Data.Name));
                Assert.IsTrue(result);
            }
        }
    }
}
