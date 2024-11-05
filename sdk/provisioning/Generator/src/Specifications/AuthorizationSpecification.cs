// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.Provisioning.Generator.Specifications;

public class AuthorizationSpecification : Specification
{
    public AuthorizationSpecification() :
        base("Authorization", typeof(AuthorizationExtensions))
    {
        SkipCleaning = true;
    }

    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<AuthorizationRoleDefinitionResource>("RoleDefinitionId");
        RemoveProperty<PolicyAssignmentProperties>("ResourceType");

        // Patch models
        CustomizeProperty<AuthorizationRoleDefinitionResource>("Name", p => p.GenerateDefaultValue = true);
        CustomizeProperty<RoleAssignmentResource>("Name", p => p.GenerateDefaultValue = true);
        CustomizeProperty<RoleAssignmentResource>("Scope", p => { p.IsReadOnly = false; p.Path = ["scope"]; });
        CustomizePropertyIsoDuration<RoleManagementPolicyExpirationRule>("MaximumDuration");
        CustomizePropertyIsoDuration<RoleAssignmentScheduleRequestResource>("Duration");
        CustomizePropertyIsoDuration<RoleEligibilityScheduleRequestResource>("Duration");

        // Naming requirements
        // RoleAssignmentResource and AuthorizationRoleDefinitionResource must be GUIDs - handled in code
    }
}
