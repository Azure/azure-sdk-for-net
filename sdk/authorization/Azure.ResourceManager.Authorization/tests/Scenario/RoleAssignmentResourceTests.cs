// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    internal class RoleAssignmentResourceTests : AuthorizationManagementTestBase
    {
        public RoleAssignmentResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task DeleteIfNotExist()
        {
            var roleAssignmentName = "06640649-9667-478a-a27e-59e940fee731";
            var roleAssignmentResourceId = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}";
            var resource = Client.GetRoleAssignmentResource(new ResourceIdentifier(roleAssignmentResourceId));
            try
            {
                await resource.DeleteAsync(WaitUntil.Started);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }
    }
}
