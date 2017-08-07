// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of the AD group definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithEmailAlias
    {
    }

    /// <summary>
    /// An AD Group definition allowing mail nickname to be specified.
    /// </summary>
    public interface IWithEmailAlias  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithEmailAliasBeta
    {
    }

    /// <summary>
    /// An AD group definition with sufficient inputs to create a new
    /// group in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithMember
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithEmailAlias,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate
    {
    }

    /// <summary>
    /// An AD Group definition allowing members to be added.
    /// </summary>
    public interface IWithMember  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithMemberBeta
    {
    }

    /// <summary>
    /// An AD Group definition allowing mail nickname to be specified.
    /// </summary>
    public interface IWithEmailAliasBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithEmailAlias(string mailNickname);
    }

    /// <summary>
    /// An AD Group definition allowing members to be added.
    /// </summary>
    public interface IWithMemberBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Add a member based on its object id. The member can be a user, a group, a service principal, or an application.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group definition stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithMember(string objectId);

        /// <summary>
        /// Adds a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to add.</param>
        /// <return>The next AD group definition stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithMember(IActiveDirectoryUser user);

        /// <summary>
        /// Adds a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to add.</param>
        /// <return>The next AD group definition stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithMember(IActiveDirectoryGroup group);

        /// <summary>
        /// Adds a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to add.</param>
        /// <return>The next AD group definition stage.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithMember(IServicePrincipal servicePrincipal);
    }
}