// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class RoleAssignmentImpl 
    {
        /// <summary>
        /// Gets the role assignment scope.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment.Scope
        {
            get
            {
                return this.Scope();
            }
        }

        /// <summary>
        /// Gets the principal ID.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment.PrincipalId
        {
            get
            {
                return this.PrincipalId();
            }
        }

        /// <summary>
        /// Gets the role definition ID.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment.RoleDefinitionId
        {
            get
            {
                return this.RoleDefinitionId();
            }
        }

        /// <summary>
        /// Specifies the assignee of the role assignment to be a service principal.
        /// </summary>
        /// <param name="servicePrincipal">The service principal object.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            return this.ForServicePrincipal(servicePrincipal) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the assignee of the role assignment to be a service principal.
        /// </summary>
        /// <param name="servicePrincipalName">The service principal name.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForServicePrincipal(string servicePrincipalName)
        {
            return this.ForServicePrincipal(servicePrincipalName) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the assignee of the role assignment to be a user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForUser(IActiveDirectoryUser user)
        {
            return this.ForUser(user) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the assignee of the role assignment to be a user.
        /// </summary>
        /// <param name="name">The user's user principal name, full display name, or email address.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForUser(string name)
        {
            return this.ForUser(name) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the assignee of the role assignment to be a group.
        /// </summary>
        /// <param name="activeDirectoryGroup">The user group.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForGroup(IActiveDirectoryGroup activeDirectoryGroup)
        {
            return this.ForGroup(activeDirectoryGroup) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the assignee of the role assignment.
        /// </summary>
        /// <param name="objectId">The object ID of an Active Directory identity.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithRole RoleAssignment.Definition.IWithAssignee.ForObjectId(string objectId)
        {
            return this.ForObjectId(objectId) as RoleAssignment.Definition.IWithRole;
        }

        /// <summary>
        /// Specifies the name of a built in role for this assignment.
        /// </summary>
        /// <param name="role">The name of the role.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithScope RoleAssignment.Definition.IWithRole.WithBuiltInRole(BuiltInRole role)
        {
            return this.WithBuiltInRole(role) as RoleAssignment.Definition.IWithScope;
        }

        /// <summary>
        /// Specifies the ID of the custom role for this assignment.
        /// </summary>
        /// <param name="roleDefinitionId">ID of the custom role definition.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithScope RoleAssignment.Definition.IWithRole.WithRoleDefinition(string roleDefinitionId)
        {
            return this.WithRoleDefinition(roleDefinitionId) as RoleAssignment.Definition.IWithScope;
        }

        /// <summary>
        /// Specifies the scope of the role assignment to be a resource group.
        /// </summary>
        /// <param name="resourceGroup">The resource group the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithCreate RoleAssignment.Definition.IWithScope.WithResourceGroupScope(IResourceGroup resourceGroup)
        {
            return this.WithResourceGroupScope(resourceGroup) as RoleAssignment.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the scope of the role assignment to be a specific resource.
        /// </summary>
        /// <param name="resource">The resource the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithCreate RoleAssignment.Definition.IWithScope.WithResourceScope(IResource resource)
        {
            return this.WithResourceScope(resource) as RoleAssignment.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the scope of the role assignment to be an entire subscription.
        /// </summary>
        /// <param name="subscriptionId">The subscription the assignee is assigned to access.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithCreate RoleAssignment.Definition.IWithScope.WithSubscriptionScope(string subscriptionId)
        {
            return this.WithSubscriptionScope(subscriptionId) as RoleAssignment.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the scope of the role assignment. The scope is usually the ID of
        /// a subscription, a resource group, a resource, etc.
        /// </summary>
        /// <param name="scope">The scope of the assignment.</param>
        /// <return>The next stage in role assignment definition.</return>
        RoleAssignment.Definition.IWithCreate RoleAssignment.Definition.IWithScope.WithScope(string scope)
        {
            return this.WithScope(scope) as RoleAssignment.Definition.IWithCreate;
        }
    }
}