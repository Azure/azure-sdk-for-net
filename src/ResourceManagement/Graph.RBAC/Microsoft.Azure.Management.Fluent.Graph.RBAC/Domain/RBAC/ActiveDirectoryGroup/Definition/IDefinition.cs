// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Graph.RBAC.ActiveDirectoryGroup.Definition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    /// <summary>
    /// The first stage of the group definition.
    /// </summary>
    public interface IBlank  :
        IWithDisplayName
    {
    }
    /// <summary>
    /// An AD group definition with sufficient inputs to create a new
    /// group in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Fluent.Graph.RBAC.IActiveDirectoryGroup>
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
        /// <param name="displayName">displayName the human readable display name</param>
        /// <returns>the next stage of group definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.ActiveDirectoryGroup.Definition.IWithMailNickname WithDisplayName(string displayName);

    }
    /// <summary>
    /// The stage of group definition allowing mail nickname to be specified.
    /// </summary>
    public interface IWithMailNickname 
    {
        /// <summary>
        /// Specifies the mail nickname of the group.
        /// </summary>
        /// <param name="mailNickname">mailNickname the mail nickname for the group</param>
        /// <returns>the next stage of group definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.ActiveDirectoryGroup.Definition.IWithCreate WithMailNickname(string mailNickname);

    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithDisplayName,
        IWithMailNickname,
        IWithCreate
    {
    }
}