// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Authorization.Models
{
#pragma warning disable CS0618 // This factory intentionally exposes obsolete GA compatibility overloads.
    // The generated all-optional overloads for the old and new type names would make existing
    // parameterless calls ambiguous. Replace them with the exact GA overloads plus contextual
    // overloads whose new model parameter is required.
    [CodeGenSuppress("RoleManagementPolicyNotificationRule", typeof(string), typeof(RoleManagementPolicyRuleTarget), typeof(RoleManagementNotificationDeliveryType?), typeof(RoleManagementPolicyNotificationLevel?), typeof(RoleManagementPolicyRecipientType?), typeof(IEnumerable<string>), typeof(bool?))]
    [CodeGenSuppress("RoleManagementPolicyAssignmentData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(IEnumerable<RoleManagementPolicyRule>), typeof(RoleManagementPolicyAssignmentProperties))]
    [CodeGenSuppress("RoleManagementPolicyAssignmentData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(IEnumerable<RoleManagementPolicyRule>), typeof(PolicyAssignmentProperties))]
    public static partial class ArmAuthorizationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.RoleManagementPolicyNotificationRule"/>. </summary>
        /// <param name="roleManagementNotificationDeliveryType"> The type of notification. </param>
        /// <param name="id"> The id of the rule. </param>
        /// <param name="target"> The target of the current rule. </param>
        /// <param name="notificationLevel"> The notification level. </param>
        /// <param name="recipientType"> The recipient type. </param>
        /// <param name="notificationRecipients"> The list of notification recipients. </param>
        /// <param name="isDefaultRecipientsEnabled"> Determines if the notification will be sent to the recipient type specified in the policy rule. </param>
        /// <returns> A new <see cref="Models.RoleManagementPolicyNotificationRule"/> instance for mocking. </returns>
        public static RoleManagementPolicyNotificationRule RoleManagementPolicyNotificationRule(
            RoleManagementNotificationDeliveryType? roleManagementNotificationDeliveryType,
            string id = default,
            RoleManagementPolicyRuleTarget target = default,
            RoleManagementPolicyNotificationLevel? notificationLevel = default,
            RoleManagementPolicyRecipientType? recipientType = default,
            IEnumerable<string> notificationRecipients = default,
            bool? isDefaultRecipientsEnabled = default)
        {
            notificationRecipients ??= new ChangeTrackingList<string>();

            return new RoleManagementPolicyNotificationRule(
                id,
                default,
                target,
                default,
                roleManagementNotificationDeliveryType,
                notificationLevel,
                recipientType,
                notificationRecipients.ToList(),
                isDefaultRecipientsEnabled);
        }

        /// <summary> Initializes a new instance of <see cref="Models.RoleManagementPolicyNotificationRule"/>. </summary>
        [Obsolete("Use the overload that takes RoleManagementNotificationDeliveryType instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RoleManagementPolicyNotificationRule RoleManagementPolicyNotificationRule(
            string id = default,
            RoleManagementPolicyRuleTarget target = default,
            NotificationDeliveryType? notificationDeliveryType = default,
            RoleManagementPolicyNotificationLevel? notificationLevel = default,
            RoleManagementPolicyRecipientType? recipientType = default,
            IEnumerable<string> notificationRecipients = default,
            bool? isDefaultRecipientsEnabled = default)
            => RoleManagementPolicyNotificationRule(
                notificationDeliveryType.HasValue
                    ? notificationDeliveryType.Value.Value
                    : default(RoleManagementNotificationDeliveryType?),
                id,
                target,
                notificationLevel,
                recipientType,
                notificationRecipients,
                isDefaultRecipientsEnabled);

        /// <summary> Initializes a new instance of <see cref="Authorization.RoleManagementPolicyAssignmentData"/>. </summary>
        /// <param name="roleManagementPolicyAssignmentProperties"> Additional properties of scope, role definition and policy. </param>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Azure Resource Manager metadata. </param>
        /// <param name="scope"> The role management policy scope. </param>
        /// <param name="roleDefinitionId"> The role definition of management policy assignment. </param>
        /// <param name="policyId"> The policy id role management policy assignment. </param>
        /// <param name="effectiveRules"> The readonly computed rules applied to the policy. </param>
        /// <returns> A new <see cref="Authorization.RoleManagementPolicyAssignmentData"/> instance for mocking. </returns>
        public static RoleManagementPolicyAssignmentData RoleManagementPolicyAssignmentData(
            RoleManagementPolicyAssignmentProperties roleManagementPolicyAssignmentProperties,
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            string scope = default,
            ResourceIdentifier roleDefinitionId = default,
            ResourceIdentifier policyId = default,
            IEnumerable<RoleManagementPolicyRule> effectiveRules = default)
        {
            return new RoleManagementPolicyAssignmentData(
                id,
                name,
                resourceType,
                systemData,
                scope is null && roleDefinitionId is null && policyId is null && effectiveRules is null && roleManagementPolicyAssignmentProperties is null
                    ? default
                    : new RoleManagementPolicyAssignmentDataProperties(
                        scope,
                        roleDefinitionId,
                        policyId,
                        (effectiveRules ?? new ChangeTrackingList<RoleManagementPolicyRule>()).ToList(),
                        roleManagementPolicyAssignmentProperties,
                        default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Authorization.RoleManagementPolicyAssignmentData"/>. </summary>
        [Obsolete("Use the overload that takes RoleManagementPolicyAssignmentProperties instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RoleManagementPolicyAssignmentData RoleManagementPolicyAssignmentData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            string scope = default,
            ResourceIdentifier roleDefinitionId = default,
            ResourceIdentifier policyId = default,
            IEnumerable<RoleManagementPolicyRule> effectiveRules = default,
            PolicyAssignmentProperties policyAssignmentProperties = default)
        {
            RoleManagementPolicyAssignmentData data = RoleManagementPolicyAssignmentData(
                policyAssignmentProperties?.Value,
                id,
                name,
                resourceType,
                systemData,
                scope,
                roleDefinitionId,
                policyId,
                effectiveRules);
            data.SetPolicyAssignmentPropertiesCompatibility(policyAssignmentProperties);
            return data;
        }

        /// <summary> Initializes a new instance of the obsolete <see cref="Models.PolicyAssignmentProperties"/> wrapper. </summary>
        [Obsolete("Use RoleManagementPolicyAssignmentProperties instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyAssignmentProperties PolicyAssignmentProperties(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            ResourceIdentifier scopeId = default,
            string scopeDisplayName = default,
            RoleManagementScopeType? scopeType = default,
            ResourceIdentifier roleDefinitionId = default,
            string roleDefinitionDisplayName = default,
            AuthorizationRoleType? roleType = default,
            ResourceIdentifier policyId = default,
            RoleManagementPrincipal lastModifiedBy = default,
            DateTimeOffset? lastModifiedOn = default)
            => new PolicyAssignmentProperties(
                RoleManagementPolicyAssignmentProperties(
                    id,
                    name,
                    resourceType,
                    systemData,
                    scopeId,
                    scopeDisplayName,
                    scopeType,
                    roleDefinitionId,
                    roleDefinitionDisplayName,
                    roleType,
                    policyId,
                    lastModifiedBy,
                    lastModifiedOn));

        /// <summary> Initializes a new instance of the obsolete <see cref="Models.PolicyAssignmentProperties"/> wrapper. </summary>
        [Obsolete("Use RoleManagementPolicyAssignmentProperties instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyAssignmentProperties PolicyAssignmentProperties(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            ResourceIdentifier policyId = default,
            RoleManagementPrincipal lastModifiedBy = default,
            DateTimeOffset? lastModifiedOn = default,
            ResourceIdentifier roleDefinitionId = default,
            string roleDefinitionDisplayName = default,
            AuthorizationRoleType? roleType = default,
            ResourceIdentifier scopeId = default,
            string scopeDisplayName = default,
            RoleManagementScopeType? scopeType = default)
            => new PolicyAssignmentProperties(
                RoleManagementPolicyAssignmentProperties(
                    id,
                    name,
                    resourceType,
                    systemData,
                    scopeId,
                    scopeDisplayName,
                    scopeType,
                    roleDefinitionId,
                    roleDefinitionDisplayName,
                    roleType,
                    policyId,
                    lastModifiedBy,
                    lastModifiedOn));
    }
#pragma warning restore CS0618
}
