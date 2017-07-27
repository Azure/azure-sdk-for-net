// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;

    /// <summary>
    /// The first stage of the role assignment definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithAssignee
    {
    }

    /// <summary>
    /// An role assignment definition with sufficient inputs to create a new
    /// role assignment in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithScope,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of role assignment definition allowing specifying the scope of the assignment.
    /// </summary>
    public interface IWithScope 
    {
        /// <summary>
        /// Specifies the scope of the role assignment to be a specific resource.
        /// </summary>
        /// <param name="resource">The resource the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithCreate WithResourceScope(IResource resource);

        /// <summary>
        /// Specifies the scope of the role assignment. The scope is usually the ID of
        /// a subscription, a resource group, a resource, etc.
        /// </summary>
        /// <param name="scope">The scope of the assignment.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithCreate WithScope(string scope);

        /// <summary>
        /// Specifies the scope of the role assignment to be a resource group.
        /// </summary>
        /// <param name="resourceGroup">The resource group the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithCreate WithResourceGroupScope(IResourceGroup resourceGroup);

        /// <summary>
        /// Specifies the scope of the role assignment to be an entire subscription.
        /// </summary>
        /// <param name="subscriptionId">The subscription the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithCreate WithSubscriptionScope(string subscriptionId);
    }

    /// <summary>
    /// The stage of role assignment definition allowing specifying the role.
    /// </summary>
    public interface IWithRole 
    {
        /// <summary>
        /// Specifies the name of a built in role for this assignment.
        /// </summary>
        /// <param name="role">The name of the role.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithScope WithBuiltInRole(BuiltInRole role);

        /// <summary>
        /// Specifies the ID of the custom role for this assignment.
        /// </summary>
        /// <param name="roleDefinitionId">ID of the custom role definition.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithScope WithRoleDefinition(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of role assignment definition allowing specifying the assignee information.
    /// </summary>
    public interface IWithAssignee 
    {
        /// <summary>
        /// Specifies the assignee of the role assignment to be a user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForUser(IActiveDirectoryUser user);

        /// <summary>
        /// Specifies the assignee of the role assignment to be a user.
        /// </summary>
        /// <param name="name">The user's user principal name, full display name, or email address.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForUser(string name);

        /// <summary>
        /// Specifies the assignee of the role assignment to be a group.
        /// </summary>
        /// <param name="activeDirectoryGroup">The user group.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForGroup(IActiveDirectoryGroup activeDirectoryGroup);

        /// <summary>
        /// Specifies the assignee of the role assignment to be a service principal.
        /// </summary>
        /// <param name="servicePrincipal">The service principal object.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForServicePrincipal(IServicePrincipal servicePrincipal);

        /// <summary>
        /// Specifies the assignee of the role assignment to be a service principal.
        /// </summary>
        /// <param name="servicePrincipalName">The service principal name.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForServicePrincipal(string servicePrincipalName);

        /// <summary>
        /// Specifies the assignee of the role assignment.
        /// </summary>
        /// <param name="objectId">The object ID of an Active Directory identity.</param>
        /// <return>The next stage in role assignment definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition.IWithRole ForObjectId(string objectId);
    }
}