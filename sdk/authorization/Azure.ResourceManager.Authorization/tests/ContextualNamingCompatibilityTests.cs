// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.ResourceManager.Authorization.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests
{
#pragma warning disable CS0618 // These tests verify the intentionally obsolete GA compatibility surface.
    public class ContextualNamingCompatibilityTests
    {
        [Test]
        public void NotificationDeliveryTypeCompatibilityUsesSameWireValue()
        {
            var rule = new RoleManagementPolicyNotificationRule
            {
                NotificationDeliveryType = NotificationDeliveryType.Email
            };

            Assert.AreEqual(RoleManagementNotificationDeliveryType.Email, rule.RoleManagementNotificationDeliveryType);
            Assert.AreEqual(NotificationDeliveryType.Email, rule.NotificationDeliveryType);
        }

        [Test]
        public void PolicyAssignmentPropertiesCompatibilityForwardsToGeneratedModel()
        {
            PolicyAssignmentProperties legacy = ArmAuthorizationModelFactory.PolicyAssignmentProperties(
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleManagementPolicyAssignments/assignment"),
                null,
                default,
                null,
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleManagementPolicies/policy"),
                ArmAuthorizationModelFactory.RoleManagementPrincipal(),
                default(DateTimeOffset?),
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleDefinitions/role"),
                "role",
                AuthorizationRoleType.BuiltInRole,
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000"),
                "scope",
                RoleManagementScopeType.Subscription);

            RoleManagementPolicyAssignmentData data = ArmAuthorizationModelFactory.RoleManagementPolicyAssignmentData(
                policyAssignmentProperties: legacy);

            Assert.AreSame(legacy, data.PolicyAssignmentProperties);
            Assert.AreEqual(legacy.PolicyId, data.RoleManagementPolicyAssignmentProperties.PolicyId);
            Assert.AreEqual(legacy.ScopeDisplayName, data.RoleManagementPolicyAssignmentProperties.ScopeDisplayName);
        }

        [Test]
        public void PolicyAssignmentPropertiesCompatibilityRoundTrips()
        {
            PolicyAssignmentProperties legacy = ArmAuthorizationModelFactory.PolicyAssignmentProperties(
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleManagementPolicyAssignments/assignment"),
                null,
                default,
                null,
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleManagementPolicies/policy"),
                ArmAuthorizationModelFactory.RoleManagementPrincipal(),
                default(DateTimeOffset?),
                new ResourceIdentifier("/providers/Microsoft.Authorization/roleDefinitions/role"),
                "role",
                AuthorizationRoleType.BuiltInRole,
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000"),
                "scope",
                RoleManagementScopeType.Subscription);

            BinaryData json = ModelReaderWriter.Write(legacy);
            PolicyAssignmentProperties roundTripped = ModelReaderWriter.Read<PolicyAssignmentProperties>(json);

            Assert.AreEqual(legacy.PolicyId, roundTripped.PolicyId);
            Assert.AreEqual(legacy.ScopeDisplayName, roundTripped.ScopeDisplayName);
        }
    }
#pragma warning restore CS0618
}
