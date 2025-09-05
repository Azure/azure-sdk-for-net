// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

public class ArmSpecification : Specification
{
    public ArmSpecification() :
        base("Arm", typeof(ArmClient))
    {
        Namespace = "Azure.Provisioning.Resources";
    }

    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ManagementGroupResource>("CacheControl");
        RemoveProperty<ManagementGroupResource>("GroupId");
        RemoveProperty<GenericResource>("ResourceId");
        RemoveProperty<ManagementGroupSubscriptionResource>("CacheControl");
        RemoveProperty<ManagementGroupSubscriptionResource>("SubscriptionId");
        RemoveProperty<PolicyAssignmentResource>("Identity");
        RemoveProperty<SubscriptionResource>("Arg");
        RemoveProperty<TenantResource>("Arg");

        // Patch models
        CustomizeResource<ResourceGroupResource>(r => r.FromExpression = true);
        CustomizeModel<GenericResource>(m => m.Name = "GenericResource");
        CustomizeModel<TagResource>(m => m.Name = "TagResource");
        CustomizeModel<WritableSubResource>(m => m.Name = "WritableSubResource");
        CustomizeModel<ExtendedLocation>(m => m.Name = "ExtendedAzureLocation");
        CustomizeModel<UserAssignedIdentity>(m => m.Name = "UserAssignedIdentityDetails");
        CustomizeResource<SubscriptionResource>(r => r.FromExpression = true);
        CustomizeResource<TenantResource>(r => r.FromExpression = true);
        CustomizeProperty<ManagedServiceIdentity>("PrincipalId", p => p.Path = ["principalId"]);
        CustomizeProperty<ManagedServiceIdentity>("TenantId", p => p.Path = ["tenantId"]);
        CustomizeProperty<ManagedServiceIdentity>("ManagedServiceIdentityType", p => p.Path = ["type"]);
        CustomizeProperty<ManagedServiceIdentity>("UserAssignedIdentities", p => p.Path = ["userAssignedIdentities"]);
#pragma warning disable CS0618 // Type or member is obsolete
        CustomizeProperty<SystemAssignedServiceIdentity>("PrincipalId", p => p.Path = ["principalId"]);
        CustomizeProperty<SystemAssignedServiceIdentity>("TenantId", p => p.Path = ["tenantId"]);
        CustomizeProperty<SystemAssignedServiceIdentity>("SystemAssignedServiceIdentityType", p => p.Path = ["type"]);
#pragma warning restore CS0618 // Type or member is obsolete

        // Naming requirements
        AddNameRequirements<ManagementGroupResource>(min: 1, max: 90, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<ResourceGroupResource>(min: 1, max: 90, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<TagResource>(min: 1, max: 512, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<ManagementLockResource>(min: 1, max: 90, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PolicyAssignmentResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<ManagementGroupPolicyDefinitionResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<SubscriptionPolicyDefinitionResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<ManagementGroupPolicySetDefinitionResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<SubscriptionPolicySetDefinitionResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);

        // Roles
        Roles.Add(new Role("Contributor", "b24988ac-6180-42a0-ab88-20f7382dd24c", "Grants full access to manage all resources, but does not allow you to assign roles in Azure RBAC, manage assignments in Azure Blueprints, or share image galleries."));
        Roles.Add(new Role("Owner", "8e3af657-a8ff-443c-a75c-2fe8c4bcb635", "Grants full access to manage all resources, including the ability to assign roles in Azure RBAC."));
        Roles.Add(new Role("Reader", "acdd72a7-3385-48ef-bd42-f606fba81ae7", "View all resources, but does not allow you to make any changes."));
        Roles.Add(new Role("RoleBasedAccessControlAdministrator", "f58310d9-a9f6-439a-9e8d-f62e7b41a168", "Manage access to Azure resources by assigning roles using Azure RBAC. This role does not allow you to manage access using other ways, such as Azure Policy."));
        Roles.Add(new Role("UserAccessAdministrator", "18d7d88d-d35e-4fb5-a5c3-7773c20a72d9", "Lets you manage user access to Azure resources."));
        Roles.Add(new Role("ManagedIdentityContributor", "e40ec5ca-96e0-45a2-b4ff-59039f2c2b59", "Create, Read, Update, and Delete User Assigned Identity"));
        Roles.Add(new Role("ManagedIdentityOperator", "f1a07417-d97a-45cb-824c-7a7467783830", "Read and Assign User Assigned Identity"));
    }
}
