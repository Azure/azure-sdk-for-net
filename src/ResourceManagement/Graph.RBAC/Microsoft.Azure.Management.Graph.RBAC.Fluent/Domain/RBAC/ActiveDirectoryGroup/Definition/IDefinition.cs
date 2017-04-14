// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithDisplayName,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithMailNickname,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of group definition allowing mail nickname to be specified.
    /// </summary>
    public interface IWithMailNickname 
    {
        /// <summary>
        /// Specifies the mail nickname of the group.
        /// </summary>
        /// <param name="mailNickname">The mail nickname for the group.</param>
        /// <return>The next stage of group definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithCreate WithMailNickname(string mailNickname);
    }

    /// <summary>
    /// The first stage of the group definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithDisplayName
    {
    }

    /// <summary>
    /// An AD group definition with sufficient inputs to create a new
    /// group in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>
    {
    }

    /// <summary>
    /// The stage of group definition allowing display name to be specified.
    /// </summary>
    public interface IWithDisplayName 
    {
        /// <summary>
        /// Specifies the display name of the group.
        /// </summary>
        /// <param name="displayName">The human readable display name.</param>
        /// <return>The next stage of group definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition.IWithMailNickname WithDisplayName(string displayName);
    }
}