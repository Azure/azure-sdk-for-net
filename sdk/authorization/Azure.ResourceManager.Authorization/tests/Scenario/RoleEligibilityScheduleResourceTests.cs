// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleEligibilityScheduleResourceTests : AuthorizationManagementTestBase
    {
        public RoleEligibilityScheduleResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [Ignore("InsufficientPermissions")]
        public async Task Get()
        {
            var id = RoleEligibilityScheduleResource.CreateResourceIdentifier("/providers/Microsoft.Management/managementGroups/CnAIOrchestrationServicePublicCorpprod", "0ec10fdb-ef51-481d-bbf0-fd87c484cb3c");
            var resource = Client.GetRoleEligibilityScheduleResource(id);
            resource = await resource.GetAsync();
            Assert.NotNull(resource.Data.Name);
        }
    }
}
