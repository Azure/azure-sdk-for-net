// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An AD Group definition allowing members to be added or removed.
    /// </summary>
    public interface IWithMember  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IWithMemberBeta
    {
    }

    /// <summary>
    /// The template for a group update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IWithMember
    {
    }

    /// <summary>
    /// An AD Group definition allowing members to be added or removed.
    /// </summary>
    public interface IWithMemberBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Removes a member based on its object id.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithoutMember(string objectId);

        /// <summary>
        /// Removes a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to remove.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithoutMember(IActiveDirectoryUser user);

        /// <summary>
        /// Removes a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to remove.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithoutMember(IActiveDirectoryGroup group);

        /// <summary>
        /// Removes a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to remove.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithoutMember(IServicePrincipal servicePrincipal);

        /// <summary>
        /// Adds a member based on its object id. The member can be a user, a group, a service principal, or an application.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithMember(string objectId);

        /// <summary>
        /// Adds a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to add.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithMember(IActiveDirectoryUser user);

        /// <summary>
        /// Adds a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to add.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithMember(IActiveDirectoryGroup group);

        /// <summary>
        /// Adds a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to add.</param>
        /// <return>The next AD group update stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update.IUpdate WithMember(IServicePrincipal servicePrincipal);
    }
}