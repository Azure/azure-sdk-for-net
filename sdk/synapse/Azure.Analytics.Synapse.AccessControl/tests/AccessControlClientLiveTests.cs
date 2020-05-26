// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.AccessControl
{
    /// <summary>
    /// The suite of tests for the <see cref="AccessControlClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class AccessControlClientLiveTests : AccessControlClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public AccessControlClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetRoleDefinition()
        {
            var roles = await AccessControlClient.GetRoleDefinitionsAsync().ToEnumerableAsync();
            CollectionAssert.IsNotEmpty(roles);
            foreach (var expectedRole in roles)
            {
                SynapseRole actualRole = await AccessControlClient.GetRoleDefinitionByIdAsync(expectedRole.Id.ToString());
                Assert.AreEqual(expectedRole.Name, actualRole.Name);
                Assert.AreEqual(expectedRole.Id, actualRole.Id);
                Assert.AreEqual(expectedRole.IsBuiltIn, actualRole.IsBuiltIn);
            }
        }

        [Test]
        public async Task TestGetRoleAssignment()
        {
            var roleAssignments = (await AccessControlClient.GetRoleAssignmentsAsync()).Value;
            CollectionAssert.IsNotEmpty(roleAssignments);
            foreach (var expectedRoleAssignment in roleAssignments)
            {
                RoleAssignmentDetails actualRoleAssignment = await AccessControlClient.GetRoleAssignmentByIdAsync(expectedRoleAssignment.Id);
                Assert.AreEqual(expectedRoleAssignment.Id, actualRoleAssignment.Id);
                Assert.AreEqual(expectedRoleAssignment.PrincipalId, actualRoleAssignment.PrincipalId);
                Assert.AreEqual(expectedRoleAssignment.RoleId, actualRoleAssignment.RoleId);
            }
        }

        [Test]
        public async Task TestCreateAndDeleteRoleAssignment()
        {
            var sqlAdminRoleId = "7af0c69a-a548-47d6-aea3-d00e69bd83aa";
            var principalId = Guid.NewGuid().ToString();

            // Create role assignment.
            RoleAssignmentDetails actualRoleAssignment = await AccessControlClient.CreateRoleAssignmentAsync(new RoleAssignmentRequest(roleId:sqlAdminRoleId, principalId: principalId));

            // Verify the role assignment exists.
            Assert.NotNull(actualRoleAssignment);
            Assert.AreEqual(sqlAdminRoleId, actualRoleAssignment.RoleId);
            Assert.AreEqual(principalId, actualRoleAssignment.PrincipalId);

            // Remove the role assignment.
            await AccessControlClient.DeleteRoleAssignmentByIdAsync(actualRoleAssignment.Id);

            // Verify the role assignment doesn't exist.
            actualRoleAssignment = (await AccessControlClient.GetRoleAssignmentsAsync()).Value.FirstOrDefault(ra => ra.PrincipalId == principalId);
            Assert.IsNull(actualRoleAssignment);
        }

        [Test]
        public async Task TesGetCallerRoleAssignments()
        {
            var expectedRoleIds = (await AccessControlClient.GetRoleDefinitionsAsync().ToEnumerableAsync())
                .Where(role=>role.IsBuiltIn)
                .Select(role => role.Id);
            var actualRoleIds = await AccessControlClient.GetCallerRoleAssignmentsAsync();
            CollectionAssert.AreEquivalent(expectedRoleIds, actualRoleIds.Value);
        }
    }
}
