// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleAssignmentScheduleResourceTests : AuthorizationManagementTestBase
    {
        public RoleAssignmentScheduleResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        //[Ignore("InsufficientPermissions")]
        public async Task Get()
        {
            var id = RoleAssignmentScheduleResource.CreateResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/managed-rg-ImportGlossaryTest", "e1cc94a4-2847-4a75-bf98-492fddd6ee6b");
            var resource = Client.GetRoleAssignmentScheduleResource(id);
            resource = await resource.GetAsync();
            Assert.NotNull(resource.Data.Name);
        }
    }
}
