// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;

namespace Azure.Provisioning.ApplicationInsights
{
    public partial class ApplicationInsightsComponent
    {
        private SystemData _systemData;

        /// <summary> Gets the system metadata associated with this resource. </summary>
        public SystemData SystemData
        {
            get { Initialize(); return _systemData; }
        }

        partial void DefineAdditionalProperties()
        {
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ResourceNameRequirements GetResourceNameRequirements() =>
            new(1, 260, ResourceNameCharacters.LowercaseLetters | ResourceNameCharacters.UppercaseLetters | ResourceNameCharacters.Numbers | ResourceNameCharacters.Hyphen | ResourceNameCharacters.Underscore | ResourceNameCharacters.Period | ResourceNameCharacters.Parentheses);

        /// <summary> Creates a role assignment for a user-assigned identity that grants access to this resource. </summary>
        public RoleAssignment CreateRoleAssignment(ApplicationInsightsBuiltInRole role, UserAssignedIdentity identity) =>
            new($"{BicepIdentifier}_{identity.BicepIdentifier}_{ApplicationInsightsBuiltInRole.GetBuiltInRoleName(role)}")
            {
                Name = BicepFunction.CreateGuid(Id, identity.PrincipalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
                Scope = new IdentifierExpression(BicepIdentifier),
                PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
                PrincipalId = identity.PrincipalId
            };

        /// <summary> Creates a role assignment for a principal that grants access to this resource. </summary>
        public RoleAssignment CreateRoleAssignment(ApplicationInsightsBuiltInRole role, BicepValue<RoleManagementPrincipalType> principalType, BicepValue<Guid> principalId, string bicepIdentifierSuffix = null) =>
            new($"{BicepIdentifier}_{ApplicationInsightsBuiltInRole.GetBuiltInRoleName(role)}{(bicepIdentifierSuffix is null ? "" : "_")}{bicepIdentifierSuffix}")
            {
                Name = BicepFunction.CreateGuid(Id, principalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
                Scope = new IdentifierExpression(BicepIdentifier),
                PrincipalType = principalType,
                RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
                PrincipalId = principalId
            };

        /// <summary> Supported API versions retained for compatibility. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2015-05-01". </summary>
            public static readonly string V2015_05_01 = "2015-05-01";
            /// <summary> API version "2014-08-01". </summary>
            public static readonly string V2014_08_01 = "2014-08-01";
            /// <summary> API version "2014-04-01". </summary>
            public static readonly string V2014_04_01 = "2014-04-01";
        }
    }
}
